using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

using Excel = Microsoft.Office.Interop.Excel;

using NewConsolidado.Controladores.ControladorNegocio;
using NewConsolidado.Controladores.Clases;
using NewConsolidado.Modelos.TransporteDatos;

namespace NewConsolidado.Vistas.Formularios
{
	public partial class IngresoAjustesManualesResumenImportacion : Form
	{
		private MyLog4Net hLog = new MyLog4Net("IngresoAjustesManualesResumenImportacion.Form");
		private string hRutaArchivo = "";
		private int hIdConsolidado = 0;
		public string RutaArchivo
		{
			get { return hRutaArchivo; }
			set { hRutaArchivo = value; }
		}
		public int idConsolidado
		{
			get { return hIdConsolidado; }
			set { hIdConsolidado = value; }
		}
		public IngresoAjustesManualesResumenImportacion()
		{
			InitializeComponent();
			//
			ConfiguracionFormulario();
		}
		private void IngresoAjustesManualesResumenImportacion_FormClosed(object sender, FormClosedEventArgs e)
		{
		}
		private void buttonAceptar_Click(object sender, EventArgs e)
		{
			GrabarRegistros();
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void buttonCancelar_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}
		private void IngresoAjustesManualesResumenImportacion_Shown(object sender, EventArgs e)
		{
			EjecutarCargaExcel();
		}
		private void IngresoAjustesManualesResumenImportacion_Load(object sender, EventArgs e)
		{

		}
		private void gridExcel_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
		}
		private void gridExcel_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			ClickLinea();
		}
		private void gridExcel_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
		{
		}
		//-------------------------------------------------------------------------------------------------------------------------
		// Metodo privados
		//-------------------------------------------------------------------------------------------------------------------------
		private void ConfiguracionFormulario()
		{
			this.Text = "Importación de planilla a Consolidado";

			buttonAceptar.Image = global::NewConsolidado.Properties.Resources.rsc_24_Grabar;
			buttonAceptar.Size = new System.Drawing.Size(CFG.buttonAncho, CFG.buttonAlto);
			buttonAceptar.Text = "Grabar";
			buttonAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			buttonAceptar.UseVisualStyleBackColor = true;
			//
			buttonCancelar.Image = global::NewConsolidado.Properties.Resources.rsc_24_Cancelar;
			buttonCancelar.Size = new System.Drawing.Size(CFG.buttonAncho, CFG.buttonAlto);
			buttonCancelar.Text = "Cancelar";
			buttonCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			buttonCancelar.UseVisualStyleBackColor = true;
			//
			this.CancelButton = buttonCancelar;
			this.AcceptButton = buttonAceptar;

			this.Height = 400;

			laMensaje.Visible = false;
			textMensaje.Visible = false;
			textMensaje.Text = "";
			progressBarCuenta.Visible = false;

		}
		private void EjecutarCargaExcel()
		{
			this.Cursor = Cursors.WaitCursor;
			try
			{
				// Definicion de Variables de trabajo
				//Excel._Workbook xlLibro;
				//Excel._Worksheet xlHoja1;
				//Excel.Sheets xlHojas;
				//Excel._Application xlApp = new Excel.Application();
				//xlLibro = xlApp.Workbooks.Open(hRutaArchivo, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
				//xlHojas = xlLibro.Sheets;
				//xlHoja1 = (Excel._Worksheet)xlHojas[1];
				//
				Excel._Application xlApp = new Excel.Application();
				Excel._Workbook xlLibro = xlApp.Workbooks.Open(hRutaArchivo, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
				xlLibro.Application.Visible = false;
				Excel.Sheets xlHojas = xlLibro.Sheets;
				Excel._Worksheet xlHoja1 = (Excel._Worksheet)xlHojas[1];
				//
				if (ValidacionColumnas(xlHoja1))
				{
					hLog.Debug("Comienzo de la importacion desde Excel {" + hRutaArchivo + "}");
					//
					int iNumeroDeRenglones = xlHoja1.get_Range("A1", Missing.Value).CurrentRegion.Rows.Count;
					hLog.Debug("Obtengo la cantidad de lineas a procesar { " + iNumeroDeRenglones.ToString() + "}");
					progressBarCuenta.Visible = true;
					progressBarCuenta.Maximum = iNumeroDeRenglones;

					for (int iRegistro = 2; iRegistro <= iNumeroDeRenglones; ++iRegistro)
					{
						hLog.Debug("Leemos la linea numero {" + iRegistro.ToString() + "}");
						//Agregamos una linea
						gridExcel.Rows.Add();
						//
						gridExcel.Rows[gridExcel.Rows.Count - 1].Cells["colLinea"].Value = (iRegistro - 1).ToString();
						string sAgrupar = xlHoja1.get_Range(CFG.aImportarCol[0] + iRegistro, Missing.Value).Text.ToString();
						string sPeriodoA = xlHoja1.get_Range(CFG.aImportarCol[1] + iRegistro, Missing.Value).Text.ToString();
						string sPeriosoV = xlHoja1.get_Range(CFG.aImportarCol[2] + iRegistro, Missing.Value).Text.ToString();
						string sCuenta = xlHoja1.get_Range(CFG.aImportarCol[3] + iRegistro, Missing.Value).Text.ToString();
						string sDebito = xlHoja1.get_Range(CFG.aImportarCol[4] + iRegistro, Missing.Value).Text.ToString();
						string sCredito = xlHoja1.get_Range(CFG.aImportarCol[5] + iRegistro, Missing.Value).Text.ToString();
						string sDescripcion = xlHoja1.get_Range(CFG.aImportarCol[6] + iRegistro, Missing.Value).Text.ToString();
						string sDescripcionAj = xlHoja1.get_Range(CFG.aImportarCol[7] + iRegistro, Missing.Value).Text.ToString();
						hLog.Debug("Valores a cargar y validar{" + sAgrupar + "}{" + sPeriodoA + "}{" + sPeriosoV + "}{" + sCuenta + "}{" + sDebito + "}{" + sCredito + "}{" + sDescripcion + "}{" + sDescripcionAj +"}");
						
						string sErrorLinea = ValidacionContenidoColumnas(iRegistro.ToString(), sAgrupar, sPeriodoA, sPeriosoV, sCuenta, sDebito, sCredito, sDescripcion, sDescripcionAj);

						gridExcel.Rows[gridExcel.Rows.Count - 1].Cells["colAgrupador"].Value = sAgrupar;
						gridExcel.Rows[gridExcel.Rows.Count - 1].Cells["colPeriodoAfecta"].Value = sPeriodoA;
						gridExcel.Rows[gridExcel.Rows.Count - 1].Cells["colPeriodoVista"].Value = sPeriosoV;
						gridExcel.Rows[gridExcel.Rows.Count - 1].Cells["colCuenta"].Value = sCuenta;
						gridExcel.Rows[gridExcel.Rows.Count - 1].Cells["colDebito"].Value = sDebito == "" ? "0" : sDebito;
						gridExcel.Rows[gridExcel.Rows.Count - 1].Cells["colCredito"].Value = sCredito == "" ? "0" : sCredito;
						gridExcel.Rows[gridExcel.Rows.Count - 1].Cells["colDescripcion"].Value = sDescripcion;
						gridExcel.Rows[gridExcel.Rows.Count - 1].Cells["colDescripcionAj"].Value = sDescripcionAj;
						gridExcel.Rows[gridExcel.Rows.Count - 1].Cells["colImagen"].Value = sErrorLinea != "" ? CFG.aImportarImg[0] : CFG.aImportarImg[1];
						gridExcel.Rows[gridExcel.Rows.Count - 1].Cells["colAccion"].Value = sErrorLinea != "" ? 0 : 1;
						gridExcel.Rows[gridExcel.Rows.Count - 1].Cells["colMensaje"].Value = sErrorLinea;

						if (sErrorLinea != "")
						{
							gridExcel.Rows[gridExcel.Rows.Count - 1].DefaultCellStyle.ForeColor = Color.Red;
							gridExcel.Rows[gridExcel.Rows.Count - 1].DefaultCellStyle.BackColor = Color.LightGray;
							hLog.Debug("Marcamos que encontramos un error en la linea para deshabilitar el boton Aceptar");
							buttonAceptar.Enabled = false;
							laMensaje.Visible = true;
							textMensaje.Visible = true;
							this.Height = 480;
							this.Refresh();
						}
						progressBarCuenta.Increment(1);
					}
				}
				else
				{
					string sColumnas = string.Join("] \r[", CFG.aExcel);// "[Agrupador][PeriodoAfectado][PeriodoVisualizar][Cuenta][Debito][Credito][Descripcion]";
					hLog.msgError("Existen problemas con las columnas en la planilla.\r\r Recuerde que debe tener obligatoriamente los siguientes Titulos columnas \r[" + sColumnas + "]");
				}
				//
				hLog.Debug("Cierre de la planilla y liberacion de recursos");
				xlLibro.Close(false, Missing.Value, Missing.Value);
				xlApp.Quit();
				//Se liberarn las instancias del los objetos excel
				System.Runtime.InteropServices.Marshal.ReleaseComObject(xlHojas);
				System.Runtime.InteropServices.Marshal.ReleaseComObject(xlHoja1);
				System.Runtime.InteropServices.Marshal.ReleaseComObject(xlLibro);
				System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);
				//Se envian al garbage collection despues de salir de la aplicación
				GC.Collect();
				GC.WaitForPendingFinalizers();
				progressBarCuenta.Visible = false;
			}
			catch (Exception Ex)
			{
				hLog.msgFatal("Error detectado \n{" + Ex.Message + "}");
			}
			this.Cursor = Cursors.Default;
		}
		private Boolean ValidacionColumnas(Excel._Worksheet xlHoja_aux)
		{
			hLog.Debug("Validacion de nombre de columnas para el excel");
			string sTexto = "";
			for (int iI = 0; iI < CFG.aExcel.Length; iI++ )
			{
				sTexto = xlHoja_aux.get_Range(CFG.aImportarCol[iI] + "1", Missing.Value).Text.ToString();
				hLog.Debug("Compara la cabecera {" + sTexto + "}{" + CFG.aExcel[iI] + "}");
				if (sTexto.ToLower() != CFG.aExcel[iI].ToLower())
				{
					hLog.Debug("Error de formato en la columna " + CFG.Importar.Agrupador.ToString() + " ->" + sTexto);
					return false;
				}
			}
			return true;
		}
		private string ValidacionContenidoColumnas(string sL, string sAgrupar, string sPeriodoA, string sPeriosoV, string sCuenta, string sDebito, string sCredito, string sDescripcion, string sDescripcionAj)
		{
			hLog.Debug("Linea a revisar {" + sL + "}");
			string sLinea = "";
			if (sAgrupar == "")
			{
				sLinea = "Campo Agrupador vacio {" + sAgrupar + "}" + Environment.NewLine;
				hLog.Error(sLinea);
			}
			if (!MisFunciones.ValidaCadenaCorrecta(sPeriodoA, "0-9"))
			{
				sLinea += "Campo Periodo Afectado tiene caracteres no permitidos {" + sPeriodoA + "}" + Environment.NewLine;
				hLog.Error(sLinea);
			}
			if (!MisFunciones.ValidaCadenaCorrecta(sPeriosoV, "0-9"))
			{
				sLinea += "Campo Periodo Visualizar tiene caracteres no permitidos {" + sPeriosoV + "}" + Environment.NewLine;
				hLog.Error(sLinea);
			}
			BOMaestroCuentas oBO = new BOMaestroCuentas();
			DTOMaestroCuentas oDTO = new DTOMaestroCuentas();
			oDTO = oBO.ConsultaMaestroCuentasCodigo(sCuenta);
			if (oDTO.idCuenta == "" )
			{
				sLinea += "Campo Cuenta tiene  cuenta no valida {" + sCuenta + "}" + Environment.NewLine;
				hLog.Error(sLinea);
			}
			if (sDebito != "")
			{
				if (!MisFunciones.ValidaCadenaCorrecta(sDebito, "0-9"))
				{
					sLinea += "Campo Debito tiene carcateres no permitidos {" + sDebito + "}" + Environment.NewLine;
					hLog.Error(sLinea);
				}
			}
			if (sCredito != "")
			{
				if (!MisFunciones.ValidaCadenaCorrecta(sCredito, "0-9"))
				{
					sLinea += "Campo Credito tiene caracteres no permitodos {" + sCredito + "}" + Environment.NewLine;
					hLog.Error(sLinea);
				}
			}
			if( sDebito == "" && sCredito == "")
			{
				sLinea += "Se debe ingresar un valor para Debito o Credito" + Environment.NewLine;
				hLog.Error(sLinea);
			}
			if (sDescripcion.Trim() == "")
			{
				sLinea += "Se debe ingresar una Descripcion de Linea " + Environment.NewLine;
				hLog.Error(sLinea);
			}
			if (MisFunciones.ValidaExistenCaracteres(sDescripcion, "?#$%&!/'"))
			{
				sLinea += "Campo Descripcion de Linea tiene caracteres no permitidos {" + sDescripcion + "}" + Environment.NewLine;
				hLog.Error(sLinea);
			}
			if (sDescripcionAj.Trim() == "")
			{
				sLinea += "Se debe ingresar una Descripcion de Ajuste" + Environment.NewLine;
				hLog.Error(sLinea);
			}
			if (MisFunciones.ValidaExistenCaracteres(sDescripcionAj, "?#$%&!/'"))
			{
				sLinea += "Campo Descripcion de Ajuste tiene caracteres no permitidos {" + sDescripcionAj + "}" + Environment.NewLine;
				hLog.Error(sLinea);
			}
			return sLinea;
		}
		public void GrabarRegistros()
		{
			try
			{
				this.Cursor = Cursors.WaitCursor;
				hLog.Debug("Enviamos los registros a la tabla de Ajustes");
				int iCorrelativo = 0;
				int iAgrupa = -100;
				string sGlosa = "";
				string sGlosaAJ = "";
				string sPeriodoA = "";
				string sPeriodoV = "";
				List<DTOAjustes> lAjustes = new List<DTOAjustes>();
				BOAjustes oBO = new BOAjustes();
				for (int iI = 0; iI <= gridExcel.Rows.Count-1; ++iI)
				{
					hLog.Debug("Comparamos si cambio el agrupador {" + iAgrupa + "}{" + gridExcel.Rows[iI].Cells["colAgrupador"].Value.ToString() + "}");
					if (iAgrupa != int.Parse(gridExcel.Rows[iI].Cells["colAgrupador"].Value.ToString()))
					{
						if (iAgrupa != -100)
						{
							oBO.GrabarAjustes(lAjustes, (int)CFG.ToolAcciones.Nuevo);
						}
						lAjustes.Clear();
						iAgrupa = int.Parse(gridExcel.Rows[iI].Cells["colAgrupador"].Value.ToString());
						sGlosa = gridExcel.Rows[iI].Cells["colDescripcion"].Value.ToString();
						sGlosaAJ = gridExcel.Rows[iI].Cells["colDescripcionAj"].Value.ToString();
						sPeriodoA = gridExcel.Rows[iI].Cells["colPeriodoAfecta"].Value.ToString();
						sPeriodoV = gridExcel.Rows[iI].Cells["colPeriodoVista"].Value.ToString();
						iCorrelativo = oBO.UltimoAsiento(hIdConsolidado, sPeriodoA);
						hLog.Debug("Actualizamos Corte control de grupo Agrupa {" + iAgrupa + "} Glosa{" + sGlosa + "} PeriodoA{" + sPeriodoA + "} PeriodoV{" + sPeriodoV + "} Correlativo{" + iCorrelativo + "}");
					}
					DTOAjustes oDTO = new DTOAjustes();
					oDTO.IdConsolidado = hIdConsolidado;
					oDTO.CorrelativoAsiento = iCorrelativo;
					oDTO.PeriodoAfectado = sPeriodoA;
					oDTO.PeriodoVista = sPeriodoV;
					oDTO.IdCuenta = gridExcel.Rows[iI].Cells["colCuenta"].Value.ToString();
					oDTO.Debito = decimal.Parse(gridExcel.Rows[iI].Cells["colDebito"].Value.ToString());
					oDTO.Credito = decimal.Parse(gridExcel.Rows[iI].Cells["colCredito"].Value.ToString());
					//oDTO.Descripcion = sGlosa;
                    oDTO.Descripcion = gridExcel.Rows[iI].Cells["colDescripcion"].Value.ToString();
					oDTO.DescripcionCabecera = sGlosaAJ;
					oDTO.TipoTransaccion = (int)CFG.TipoAjuste.Manual;
					lAjustes.Add(oDTO);
				}
				if (lAjustes.Count > 0)
				{
					oBO.GrabarAjustes(lAjustes, (int)CFG.ToolAcciones.Nuevo);
				}
				this.Cursor = Cursors.Default;
			}
			catch (Exception EX)
			{
				hLog.msgFatal("Error detectado \n{" + EX.Message + "}");
			}
		}
		private void ClickLinea()
		{
			if (gridExcel.Rows.Count > 0)
			{
				textMensaje.Text = gridExcel.Rows[gridExcel.CurrentCell.RowIndex].Cells["colMensaje"].Value.ToString();
			}
		}
	}
}
