using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using NewConsolidado.Properties;
using NewConsolidado.Controladores.Clases;
using NewConsolidado.Controladores.ControladorNegocio;
using NewConsolidado.Modelos.TransporteDatos;

namespace NewConsolidado.Vistas.Formularios
{
	public partial class IngresoSaldosContables : Form
	{
		private MyLog4Net hLog = new MyLog4Net("IngresoSaldosContables.Form");
		private int hiAccion = 0;

		public IngresoSaldosContables()
		{
			InitializeComponent();

			this.Text = "Ingreso de Saldos Contables Manuales";
			//
			ConfiguraEntorno();
			hiAccion = (int)CFG.ToolAcciones.Nuevo;
		}

		private void buttonCompania_Click(object sender, EventArgs e)
		{
			BuscaCompania();
		}
		private void buttonCuenta_Click(object sender, EventArgs e)
		{
			BuscaCuenta();
		}
		private void gridSaldos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			EditarSaldo();
		}
		private void toolGrabar_Click(object sender, EventArgs e)
		{
			GrabarSaldo();
		}
		private void toolSalir_Click(object sender, EventArgs e)
		{
			this.Close();
		}
		private void textCompania_KeyUp(object sender, KeyEventArgs e)
		{
			BuscaCodigoCompania();
		}
		private void textPeriodo_KeyUp(object sender, KeyEventArgs e)
		{
			BuscaPeriodo();
		}
		private void textCuentaContabla_TextChanged(object sender, EventArgs e)
		{

		}
		private void textCuentaContable_KeyUp(object sender, KeyEventArgs e)
		{
			CargaGrilla();
		}

		private void textCompania_KeyPress(object sender, KeyPressEventArgs e)
		{
			//if (e.KeyChar == (char)13)
			//{
			//    textPeriodo.Focus();
			//}
		}
		private void textPeriodo_KeyPress(object sender, KeyPressEventArgs e)
		{
            BuscaCodigoCuenta();
		}
		private void textCuentaContable_KeyPress(object sender, KeyPressEventArgs e)
		{
			//if (e.KeyChar == (char)13)
			//{
			//    textMonto.Focus();
			//}
		}
		private void textMonto_KeyPress(object sender, KeyPressEventArgs e)
		{
			//if (e.KeyChar == (char)13)
			//{
			//    MontoLeave();
			//    GrabarSaldo();
			//}
		}

		private void textMonto_Leave(object sender, EventArgs e)
		{
			MontoLeave();
			//GrabarSaldo();
		}

		private void textMonto_Enter(object sender, EventArgs e)
		{
			MontoEnter();
		}

		private void textCompania_Leave(object sender, EventArgs e)
		{
		}

		private void textPeriodo_Leave(object sender, EventArgs e)
		{
			//CargaGrilla();
		}

		private void textCuentaContable_Leave(object sender, EventArgs e)
		{
            //BuscaCuenta();
			//CargaGrilla();
		}

		private void toolNuevo_Click(object sender, EventArgs e)
		{
			NuevoSaldo();
		}

		private void toolEditar_Click(object sender, EventArgs e)
		{
			EditarSaldo();
		}

		private void toolEliminar_Click(object sender, EventArgs e)
		{
			EliminarSaldo();
		}
		private void toolStripButtonImportar_Click(object sender, EventArgs e)
		{
			BotonImportar();
		}

		private void IngresoSaldosContables_Load(object sender, EventArgs e)
		{

		}

        private void toolStripButtonVerFormato_Click(object sender, EventArgs e)
        {
            string sTexto = "El archivo de importacion debe tener el nombre de las columnas en la primera fila, en el siguiente orden :"
                + Environment.NewLine + Environment.NewLine
                + "Compania, Periodo, Cuenta, Monto";
            
            hLog.msgInfo(sTexto);
        }

        private void textCuentaContable_TextChanged(object sender, EventArgs e)
        {
            BuscaCodigoCuenta();
        }

		//------------------------------------------------------------------------------------------------------------------
		// Metodos privados
		//------------------------------------------------------------------------------------------------------------------
		private void ConfiguraEntorno()
		{
			// Damos caracteristicas al boton de Buscar
			buttonCompania.Image = global::NewConsolidado.Properties.Resources.rsc_16_Buscar;
			buttonCompania.Size = new System.Drawing.Size(70, 24);
			buttonCompania.Text = "Buscar";
			buttonCompania.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			buttonCompania.UseVisualStyleBackColor = true;
			//
			buttonCuenta.Image = global::NewConsolidado.Properties.Resources.rsc_16_Buscar;
			buttonCuenta.Size = new System.Drawing.Size(70, 24);
			buttonCuenta.Text = "Buscar";
			buttonCuenta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			buttonCuenta.UseVisualStyleBackColor = true;

			textCompania.Text = "";
			laNombreCompania.Text = "";
			textPeriodo.Text = "";
			textCuentaContable.Text = "";
			laDescripcionCuenta.Text = "";
			textMonto.Text = "0";
			laTipo.Text = "";
			//
			textCompania.TabIndex = 0;
			buttonCompania.TabIndex = 1;
			textPeriodo.TabIndex = 2;
			textCuentaContable.TabIndex = 3;
			buttonCuenta.TabIndex = 4;
			textMonto.TabIndex = 5;
			gridSaldos.TabIndex = 6;
			//
			textCompania.MaxLength = 10;
			textPeriodo.MaxLength = 6;
			textCuentaContable.MaxLength = 8;
			textMonto.MaxLength = 20;
			//
			gridSaldos.Columns["colTipoCuenta"].Visible = Properties.Settings.Default.usrMuestraColumnasOcultas;
			gridSaldos.Columns["colIdRegistro"].Visible = Properties.Settings.Default.usrMuestraColumnasOcultas;

			MisFunciones.ConfiguraToolBar(toolBarra);

		}
		private void BuscaCompania()
		{
			ConsultaCompanias oForm = new ConsultaCompanias();
			oForm.StartPosition = FormStartPosition.CenterScreen;
			oForm.Origen = (int)CFG.OrigenCompania.Manual;
			oForm.ShowIcon = false;
			oForm.ShowInTaskbar = false;
			if (oForm.ShowDialog(this) == DialogResult.OK)
			{
				textCompania.Text = oForm.IdCompania;
				laNombreCompania.Text = oForm.Nombre;
			}
			else
			{
				textCompania.Text = "";
				laNombreCompania.Text = "";
			}
			textCuentaContable.Text = "";
			textPeriodo.Text = "";
			textAcumulaDebito.Text = "";
			textAcumulaCredito.Text = "";
			gridSaldos.Rows.Clear();
		}

		private void BuscaCodigoCompania()
		{
			if (textCompania.Text.Trim().Length > 2)
			{
				List<DTOCompanias> lDTO = new List<DTOCompanias>();
				BOCompanias BOC = new BOCompanias();
				lDTO = BOC.ConsultaCompanias(textCompania.Text, (int)CFG.OrigenCompania.Manual);
				if (lDTO.Count > 0)
				{
					laNombreCompania.Text = lDTO[0].Nombre;
				}
				else
				{
					laNombreCompania.Text = "";
					textCuentaContable.Text = "";
					textPeriodo.Text = "";
					textAcumulaDebito.Text = "";
					textAcumulaCredito.Text = "";
					gridSaldos.Rows.Clear();
				}
			}
			else
			{
				laNombreCompania.Text = "";
				textCuentaContable.Text = "";
				textPeriodo.Text = "";
				textAcumulaDebito.Text = "";
				textAcumulaCredito.Text = "";
				gridSaldos.Rows.Clear();
			}
		}

		private void BuscaCuenta()
		{
			ConsultaCuentasContables oForm = new ConsultaCuentasContables();
			oForm.StartPosition = FormStartPosition.CenterParent;
			oForm.ShowIcon = false;
			oForm.ShowInTaskbar = false;
			DialogResult oDlg = oForm.ShowDialog(this);
			if (oDlg == DialogResult.OK)
			{
				textCuentaContable.Text = oForm.IdCuenta.ToString();
				laDescripcionCuenta.Text = oForm.sGlosa.ToString();
				laTipo.Text = oForm.sTipo.ToString();
			}
		}

		private void BuscaCodigoCuenta()
		{
			if (textCuentaContable.Text.Trim().Length > 5)
			{
				BOMaestroCuentas oBO = new BOMaestroCuentas();
				DTOMaestroCuentas oDto = new DTOMaestroCuentas();
				oDto = oBO.ConsultaMaestroCuentasCodigo(textCuentaContable.Text);
				if (oDto != null)
				{
					laDescripcionCuenta.Text = oDto.Descripcion;
					laTipo.Text = oDto.Tipo;
				}
				else
				{
					laDescripcionCuenta.Text = "";
				}
			}
			else
			{
				laDescripcionCuenta.Text = "";
			}
		}

		private void GrabarSaldo()
		{
			if (ValidaCampos())
			{
				List<DTOSaldosContables> lDTO = new List<DTOSaldosContables>();
				DTOSaldosContables oDTO = new DTOSaldosContables();
				//
				decimal dValor = 0;
				if (!decimal.TryParse(textMonto.Text.Replace(".", ""), out dValor))
				{
					hLog.msgError("Monto no permitido");
					textMonto.Focus();
					textMonto.SelectAll();
					return;
				}
				//
				if ((int)CFG.ToolAcciones.Editar == hiAccion)
				{
					oDTO.IdRegistro = int.Parse(gridSaldos.Rows[gridSaldos.CurrentCell.RowIndex].Cells["colIdRegistro"].Value.ToString());
				}
				oDTO.IdCompania = textCompania.Text;
				oDTO.Periodo = textPeriodo.Text;
				oDTO.IdCuenta = textCuentaContable.Text;
				oDTO.Libro = "REAL";
				oDTO.Origen = (int)CFG.OrigenSaldo.Manual;
				switch (laTipo.Text.ToString().Trim().ToUpper())
				{
					case "1A":
					case "3E":
						{
							if (dValor > 0)
							{
								oDTO.Debito = dValor;
								oDTO.Credito = 0;
							}
							else
							{
								oDTO.Debito = 0;
								oDTO.Credito = dValor * -1;
							}
							break;
						}
					case "2L":
					case "3I":
						{
							if (dValor > 0)
							{
								oDTO.Debito = 0;
								oDTO.Credito = dValor;
							}
							else
							{
								oDTO.Debito = dValor * -1;
								oDTO.Credito = 0;
							}
							break;
						}
					default:
						{
							hLog.Fatal("Mala clasificacion al {GrabarSaldos}");
							throw new SystemException("Mala clasificacion al {GrabarSaldos}");
							
						}
				}
				lDTO.Add(oDTO);
				//
				BOSaldosContables oBO = new BOSaldosContables();
				oBO.GrabarSaldos(lDTO, hiAccion);
				//				
				//textCuentaContable.Text = "";
				textCuentaContable.SelectAll();
				textMonto.Text = "0";
				textCuentaContable.Focus();
				hiAccion = (int)CFG.ToolAcciones.Nuevo;
				CargaGrilla();
			}
		}

		private Boolean ValidaCampos()
		{
			if (textCompania.Text == "")
			{
				hLog.msgError("Debe seleccionar una Compañia");
				textCompania.Focus();
				textCompania.SelectAll();
				return false;
			}
			if (textPeriodo.Text == "")
			{
				hLog.msgError("Debe ingresar un periodo");
				textPeriodo.Focus();
				textPeriodo.SelectAll();
				return false;
			}
			if (textCuentaContable.Text == "")
			{
				hLog.msgError("Debe ingresar una Cuenta Contable");
				textCuentaContable.Focus();
				textCuentaContable.SelectAll();
				return false;
			}
			if (laTipo.Text == "")
			{
				hLog.msgError("Debe ingresar una Cuenta Contable Valida");
				textCuentaContable.Focus();
				textCuentaContable.SelectAll();
				return false;
			}
			if (textMonto.Text == "")
			{
				hLog.msgError("Debe ingresar un monto para el saldo");
				textMonto.Focus();
				textMonto.SelectAll();
				return false;
			}
			string sPaso = textMonto.Text.Replace(".", "");
			int iValor = 0;
			if (!int.TryParse(sPaso, out iValor))
			{
				hLog.msgError("Debe ingresar un monto para el saldo");
				textMonto.Focus();
				textMonto.SelectAll();
				return false;
			}
			if (iValor == 0)
			{
				hLog.msgError("Debe ingresar un monto para el saldo");
				textMonto.Focus();
				textMonto.SelectAll();
				return false;
			}

			return true;
		}

		private void MontoEnter()
		{
			if (textMonto.Text != "")
			{
				textMonto.Text = textMonto.Text.Replace(".", "");
			}
		}

		private void MontoLeave()
		{
			if (textMonto.Text != "")
			{
				int iP = 0;
				if (int.TryParse(textMonto.Text.Replace(".", ""), out iP))
				{
					if (iP != 0)
					{
						textMonto.Text = iP.ToString(CFG.sFormatDisplayNumber);
					}
					else
					{
						textMonto.Text = "0";
					}
				}
			}
			else
			{
				textMonto.Text = "0";
			}
		}

		private void CargaGrilla()
		{
			BOSaldosContables oBO = new BOSaldosContables();
			List<DTOSaldosContables> lDto = new List<DTOSaldosContables>();

			gridSaldos.Rows.Clear();
			lDto = oBO.ConsultaAjustesConsolidado(textCompania.Text, textCuentaContable.Text, textPeriodo.Text);
			foreach (DTOSaldosContables oDTO in lDto)
			{
				gridSaldos.Rows.Add();
				//gridSaldos.Rows[gridSaldos.Rows.Count - 1].Cells["colIdCompania"].Value = oDTO.IdCompania;
				//gridSaldos.Rows[gridSaldos.Rows.Count - 1].Cells["colNombreCompania"].Value = oDTO.NombreCompania;
				gridSaldos.Rows[gridSaldos.Rows.Count - 1].Cells["colPeriodo"].Value = oDTO.Periodo.ToString();
				gridSaldos.Rows[gridSaldos.Rows.Count - 1].Cells["colIdCuenta"].Value = oDTO.IdCuenta;
				gridSaldos.Rows[gridSaldos.Rows.Count - 1].Cells["colDescripcionCuenta"].Value = oDTO.DescripcionCuenta;
				gridSaldos.Rows[gridSaldos.Rows.Count - 1].Cells["colLibro"].Value = oDTO.Libro;
				gridSaldos.Rows[gridSaldos.Rows.Count - 1].Cells["colOrigen"].Value = CFG.aOrigenSaldo[oDTO.Origen];
				gridSaldos.Rows[gridSaldos.Rows.Count - 1].Cells["colDebito"].Value = oDTO.Debito.ToString(CFG.sFormatDisplayNumber);
				gridSaldos.Rows[gridSaldos.Rows.Count - 1].Cells["colCredito"].Value = oDTO.Credito.ToString(CFG.sFormatDisplayNumber);
				gridSaldos.Rows[gridSaldos.Rows.Count - 1].Cells["colTipoCuenta"].Value = oDTO.TipoCuenta.ToString();
				gridSaldos.Rows[gridSaldos.Rows.Count - 1].Cells["colIdRegistro"].Value = oDTO.IdRegistro.ToString();
			}
			if (lDto.Count > 0)
			{
				DTOSaldosContables oDTO = new DTOSaldosContables();
				oDTO = oBO.ConsultaSaldosAcumulados(textCompania.Text, textPeriodo.Text, textCuentaContable.Text);
				if (oDTO != null)
				{
					textAcumulaDebito.Text = oDTO.Debito.ToString(CFG.sFormatDisplayNumber);
					textAcumulaCredito.Text = oDTO.Credito.ToString(CFG.sFormatDisplayNumber);
				}
			}
		}

		private void NuevoSaldo()
		{
			textCompania.Text = "";
			laNombreCompania.Text = "";
			textPeriodo.Text = "";
			textCuentaContable.Text = "";
			laDescripcionCuenta.Text = "";
			textMonto.Text = "0";
			laTipo.Text = "";
			//
			hiAccion = (int)CFG.ToolAcciones.Nuevo;
			//
			textCompania.Focus();
		}

		private void EditarSaldo()
		{
			if (gridSaldos.Rows.Count > 0)
			{
				string sPaso = gridSaldos.Rows[gridSaldos.CurrentCell.RowIndex].Cells["colOrigen"].Value.ToString();
				if (sPaso == CFG.OrigenSaldo.Manual.ToString())
				{
					hiAccion = (int)CFG.ToolAcciones.Editar;
					//textCompania.Text = gridSaldos.Rows[gridSaldos.CurrentCell.RowIndex].Cells["colIdCompania"].Value.ToString();
					//laNombreCompania.Text = gridSaldos.Rows[gridSaldos.CurrentCell.RowIndex].Cells["colNombreCompania"].Value.ToString();
					textPeriodo.Text = gridSaldos.Rows[gridSaldos.CurrentCell.RowIndex].Cells["colPeriodo"].Value.ToString();
					textCuentaContable.Text = gridSaldos.Rows[gridSaldos.CurrentCell.RowIndex].Cells["colIdCuenta"].Value.ToString();
					laDescripcionCuenta.Text = gridSaldos.Rows[gridSaldos.CurrentCell.RowIndex].Cells["colDescripcionCuenta"].Value.ToString();
					//
					if (gridSaldos.Rows[gridSaldos.CurrentCell.RowIndex].Cells["ColDebito"].Value.ToString() == "0")
					{
						textMonto.Text = gridSaldos.Rows[gridSaldos.CurrentCell.RowIndex].Cells["colCredito"].Value.ToString();
					}
					else
					{
						textMonto.Text = gridSaldos.Rows[gridSaldos.CurrentCell.RowIndex].Cells["colDebito"].Value.ToString();
					}
					laTipo.Text = gridSaldos.Rows[gridSaldos.CurrentCell.RowIndex].Cells["colTipoCuenta"].Value.ToString();

					textMonto.Focus();
					textMonto.SelectAll();
				}
				else
				{
					hLog.msgError("No se pueden editar los registro de Dynamics");
				}
			}
		}

		private void EliminarSaldo()
		{
			if (gridSaldos.Rows.Count > 0)
			{

				DialogResult oDlg = MessageBox.Show("Quieres eliminar el saldo?", Settings.Default.appTituloAplicacion, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (oDlg == DialogResult.Yes)
				{
					string sPaso = gridSaldos.Rows[gridSaldos.CurrentCell.RowIndex].Cells["colOrigen"].Value.ToString();
					if (sPaso == CFG.OrigenSaldo.Manual.ToString())
					{
						List<DTOSaldosContables> lDTO = new List<DTOSaldosContables>();
						DTOSaldosContables oDTO = new DTOSaldosContables();
						//
						oDTO.IdRegistro = int.Parse(gridSaldos.Rows[gridSaldos.CurrentCell.RowIndex].Cells["colIdRegistro"].Value.ToString());
						lDTO.Add(oDTO);
						//
						BOSaldosContables oBO = new BOSaldosContables();
						oBO.GrabarSaldos(lDTO, (int)CFG.ToolAcciones.Eliminar);
						//				
						textMonto.Text = "0";
						textMonto.Focus();
						textMonto.SelectAll();
						hiAccion = (int)CFG.ToolAcciones.Nuevo;
						CargaGrilla();
					}
					else
					{
						hLog.msgError("Solo esta permitido Eliminar saldos manuales");
					}
				}
			}
		}

		private void BuscaPeriodo()
		{
			if (textPeriodo.Text.Trim() == "")
			{
				textCuentaContable.Text = "";
				gridSaldos.Rows.Clear();
			}
			else
			{
				CargaGrilla();
			}
		}

		private void BotonImportar()
		{
			if (textCompania.Text.Trim() == "")
			{
				hLog.msgError("Debe seleccionar una Compañia");
				textCompania.SelectAll();
				textCompania.Focus();
				return;
			}
			if (textPeriodo.Text.Trim() == "")
			{
				hLog.msgError("Debe seleccionar un periodo");
				textPeriodo.SelectAll();
				textPeriodo.Focus();
				return;
			}
			hLog.Debug("Defino ventana de dialo con Filtro solo para planillas Microsoft Excel");
			OpenFileDialog oDlg = new OpenFileDialog();
			oDlg.Filter = "Excel|*.xls;*.xlsx";
			if (oDlg.ShowDialog()  == DialogResult.OK)
			{
				IngresoSaldosContables_Importacion oForm = new IngresoSaldosContables_Importacion();
				oForm.StartPosition = FormStartPosition.CenterParent;
				oForm.Compania = textCompania.Text.Trim();
				oForm.Periodo = textPeriodo.Text.Trim();
				oForm.RutaArchivo = oDlg.FileName;
				oForm.ShowIcon = false;
				oForm.ShowInTaskbar = false;
				if (oForm.ShowDialog(this) == DialogResult.OK)
				{
					CargaGrilla();
				}
			}
		}
	}
}
