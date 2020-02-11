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

using NewConsolidado.Properties;
using NewConsolidado.Controladores.Clases;
using NewConsolidado.Controladores.ControladorNegocio;
using NewConsolidado.Modelos.TransporteDatos;

namespace NewConsolidado.Vistas.Formularios
{
	public partial class IngresoSaldosContables_Importacion : Form
	{
		private MyLog4Net hLog = new MyLog4Net("IngresoSaldosContables_Importacion.Form");
		private string hsCompania = "";
		private string hsPeriodo = "";
		private string hsRutaArchivo = "";
	
		public IngresoSaldosContables_Importacion()
		{
			InitializeComponent();
			ConfiguracionFormulario();
		}
		private void IngresoSaldosContables_Importacion_Load(object sender, EventArgs e)
		{
		}
		private void buttonAceptar_Click(object sender, EventArgs e)
		{
			BotonAceptar();
		}
		private void buttonCancelar_Click(object sender, EventArgs e)
		{
			BotonCancelar();
		}
		private void dataGridSaldos_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			MuestraObservacion();
		}
		private void IngresoSaldosContables_Importacion_Shown(object sender, EventArgs e)
		{
			CargaFormulario();
		}

		//------------------------------------------------------------------------------------------------------------------
		// Metodos Accesos publilcos
		//------------------------------------------------------------------------------------------------------------------
		public string Compania
		{
			get { return hsCompania; }
			set { hsCompania = value; }
		}
		public string Periodo
		{
			get { return hsPeriodo; }
			set { hsPeriodo = value; }
		}
		public string RutaArchivo
		{
			get { return hsRutaArchivo; }
			set { hsRutaArchivo = value; }
		}
		//------------------------------------------------------------------------------------------------------------------
		// Metodos privados
		//------------------------------------------------------------------------------------------------------------------
		private void ConfiguracionFormulario()
		{
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
		private void CargaFormulario()
		{
			this.Cursor = Cursors.WaitCursor;
			try
			{
				
				// Definicion de Variables de trabajo
				Excel._Application xlApp = new Excel.Application();
				Excel._Workbook xlLibro = xlApp.Workbooks.Open(hsRutaArchivo, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
				xlLibro.Application.Visible = false;
				Excel.Sheets xlHojas = xlLibro.Sheets;
				Excel._Worksheet xlHoja1 = (Excel._Worksheet)xlHojas[1];
				////
				//Excel._Workbook xlLibro;
				//Excel._Worksheet xlHoja1;
				//Excel.Sheets xlHojas;
				//Excel._Application xlApp = new Excel.Application();
				//xlLibro = xlApp.Workbooks.Open(hsRutaArchivo, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
				//xlHojas = xlLibro.Sheets;
				//xlHoja1 = (Excel._Worksheet)xlHojas[1];

				if (ValidacionColumnas(xlHoja1))
				{
					hLog.Debug("Comienzo de la importacion desde Excel {" + hsRutaArchivo + "}");
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
						string sCompania = xlHoja1.get_Range(CFG.aImportarCol[0] + iRegistro, Missing.Value).Text.ToString();
						string sPeriodo = xlHoja1.get_Range(CFG.aImportarCol[1] + iRegistro, Missing.Value).Text.ToString();
						string sCuenta = xlHoja1.get_Range(CFG.aImportarCol[2] + iRegistro, Missing.Value).Text.ToString();
						string sMonto = xlHoja1.get_Range(CFG.aImportarCol[3] + iRegistro, Missing.Value).Text.ToString();
						hLog.Debug("Valores a cargar y validar{" + sCompania + "}{" + sPeriodo + "}{" + sCuenta + "}{" + sMonto + "}");

						string sErrorLinea = ValidacionContenidoColumnas(iRegistro.ToString(), sCompania, sPeriodo, sCuenta, sMonto);

						gridExcel.Rows[gridExcel.Rows.Count - 1].Cells["colCompania"].Value = sCompania;
						gridExcel.Rows[gridExcel.Rows.Count - 1].Cells["colPeriodo"].Value = sPeriodo;
						gridExcel.Rows[gridExcel.Rows.Count - 1].Cells["colIdCuenta"].Value = sCuenta;
						string sTipo = "";
						BOMaestroCuentas oBO = new BOMaestroCuentas();
						DTOMaestroCuentas oDTO = new DTOMaestroCuentas();
						oDTO = oBO.ConsultaMaestroCuentasCodigo(sCuenta);
						if (oDTO.Tipo != "")
						{
							sTipo = oDTO.Tipo;
						}
						gridExcel.Rows[gridExcel.Rows.Count - 1].Cells["colCuentaTipo"].Value = sTipo;
						gridExcel.Rows[gridExcel.Rows.Count - 1].Cells["colMonto"].Value = sMonto;
						gridExcel.Rows[gridExcel.Rows.Count - 1].Cells["colMensaje"].Value = sErrorLinea;
						gridExcel.Rows[gridExcel.Rows.Count - 1].Cells["colImagen"].Value = sErrorLinea != "" ? CFG.aImportarImg[0] : CFG.aImportarImg[1];
						gridExcel.Rows[gridExcel.Rows.Count - 1].Cells["colAccion"].Value = sErrorLinea != "" ? 0 : 1;

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
					string sColumnas = string.Join("] \r[", CFG.aExcelSaldos);
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
		private void BotonAceptar()
		{
			GrabarRegistros();
			this.DialogResult = DialogResult.OK;
			this.Close();
		}
		private void BotonCancelar()
		{
			this.Close();
		}
		private void MuestraObservacion()
		{
			if (gridExcel.Rows.Count > 0)
			{
				textMensaje.Text = gridExcel.Rows[gridExcel.CurrentCell.RowIndex].Cells["colMensaje"].Value.ToString();
			}
		}
		private void GrabarRegistros()
		{
			try
			{
				this.Cursor = Cursors.WaitCursor;
				hLog.Debug("Enviamos los registros a la tabla de Saldos Contable");

				List<DTOSaldosContables> oLista = new List<DTOSaldosContables>();
				BOSaldosContables oBO = new BOSaldosContables();
				for (int iI = 0; iI <= gridExcel.Rows.Count - 1; ++iI)
				{
					DTOSaldosContables oDTO = new DTOSaldosContables();
					oDTO.IdCompania = hsCompania;
					oDTO.Periodo = hsPeriodo;
					oDTO.IdCuenta = gridExcel.Rows[iI].Cells["colIdCuenta"].Value.ToString();
					oDTO.Libro = "REAL";
					oDTO.Origen = (int)CFG.OrigenSaldo.Manual;
					decimal dMonto = decimal.Parse(gridExcel.Rows[iI].Cells["colMonto"].Value.ToString());
					#region Carga Monto
					switch (gridExcel.Rows[iI].Cells["colCuentaTipo"].Value.ToString().Trim().ToUpper())
					{
						case "1A":
						case "3E":
							{
								if (dMonto > 0) // Positivo
								{
									oDTO.Debito = dMonto;
									oDTO.Credito = 0;
								}
								else // Negativo
								{
									oDTO.Debito = 0;
									oDTO.Credito = dMonto * -1;
								}
								break;
							}
						case "2L":
						case "3I":
							{
								if (dMonto > 0) // positivo
								{
									oDTO.Debito = 0;
									oDTO.Credito = dMonto;
								}
								else  // Negativo
								{
									oDTO.Debito = dMonto * -1;
									oDTO.Credito = 0;
								}
								break;
							}
						default:
							{
								hLog.Fatal("Mala clasificacion al {GrabaRegistro}");
								throw new SystemException("Mala clasificacion al {GrabarRegistro}");
								
							}
					}
					#endregion
					oLista.Add(oDTO);
				}
				if (oLista.Count > 0)
				{
					oBO.GrabarSaldos(oLista, (int)CFG.ToolAcciones.Nuevo);
				}
				this.Cursor = Cursors.Default;
			}
			catch (Exception EX)
			{
				hLog.msgFatal("Error detectado \n{" + EX.Message + "}");
			}
		}
		private Boolean ValidacionColumnas(Microsoft.Office.Interop.Excel._Worksheet xlHoja_aux)
		{
			hLog.Debug("Validacion de nombre de columnas para el excel");
			string sTexto = "";
			for (int iI = 0; iI < CFG.aExcelSaldos.Length; iI++)
			{
				sTexto = xlHoja_aux.get_Range(CFG.aImportarCol[iI] + "1", Missing.Value).Text.ToString();
				hLog.Debug("Compara la cabecera {" + sTexto + "}{" + CFG.aExcelSaldos[iI] + "}");
				if (sTexto.ToLower() != CFG.aExcelSaldos[iI].ToLower())
				{
					hLog.Debug("Error de formato en la columna " + CFG.aExcelSaldos[iI].ToString() + " ->" + sTexto);
					return false;
				}
			}
			return true;
		}
		private string ValidacionContenidoColumnas(string sL, string sCompania, string sPeriodo, string sCuenta, string sMonto)
		{
			hLog.Debug("Linea a revisar {" + sL + "}");
			string sLinea = "";
			if (sCompania == "")
			{
				sLinea = "Campo Compania vacio {" + sCompania + "}" + Environment.NewLine;
				hLog.Error(sLinea);
			}
			if (sCompania.ToLower().Trim() != hsCompania.ToLower().Trim())
			{
				sLinea = "Campo Compania no corresponde {" + sCompania + "}" + Environment.NewLine;
				hLog.Error(sLinea);
			}
			if (!MisFunciones.ValidaCadenaCorrecta(sPeriodo, "0-9"))
			{
				sLinea += "Campo Periodo tiene caracteres no permitidos {" + sPeriodo + "}" + Environment.NewLine;
				hLog.Error(sLinea);
			}
			if (sPeriodo.ToLower().Trim() != hsPeriodo.ToLower().Trim())
			{
				sLinea = "Campo periodo no corresponde {" + sPeriodo + "}" + Environment.NewLine;
				hLog.Error(sLinea);
			}
			BOMaestroCuentas oBO = new BOMaestroCuentas();
			DTOMaestroCuentas oDTO = new DTOMaestroCuentas();
			oDTO = oBO.ConsultaMaestroCuentasCodigo(sCuenta);
			if (oDTO.idCuenta == "")
			{
				sLinea += "Campo Cuenta tiene  cuenta no valida {" + sCuenta + "}" + Environment.NewLine;
				hLog.Error(sLinea);
			}
			if (sMonto.Trim() == "")
			{
				sLinea += "Se debe ingresar un monto " + Environment.NewLine;
				hLog.Error(sLinea);
			}
			if (sMonto != "")
			{
				decimal dP = 0;
				if (!decimal.TryParse(sMonto, out dP))
				//if (!MisFunciones.ValidaCadenaCorrecta(sMonto, "0-9"))
				{
					sLinea += "Campo Monto tiene carcateres no permitidos {" + sMonto + "}" + Environment.NewLine;
					hLog.Error(sLinea);
				}
				else
				{
					if (dP == 0)
					{
						sLinea += "Campo Monto debe ser ingresado" + Environment.NewLine;
						hLog.Error(sLinea);
					}
				}
			}
			return sLinea;
		}
	}
}
