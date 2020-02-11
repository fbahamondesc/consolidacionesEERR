using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO;

using Excel = Microsoft.Office.Interop.Excel;

using NewConsolidado.Controladores.Clases;
using NewConsolidado.Controladores.ControladorNegocio;
using NewConsolidado.Modelos.TransporteDatos;

namespace NewConsolidado.Vistas.Formularios
{
	public partial class IngresoAjustesManuales : Form
	{
		private MyLog4Net hLog = new MyLog4Net("IngresoAjustesManuales.Form");
		private int hiConsolidado = -1;
		private string hsCodigo = "";
		private string hsDescripcion = "";
		private int hiAccion = (int)CFG.ToolAcciones.Nada;

		public IngresoAjustesManuales()
		{
			InitializeComponent();
			//
			ConfiguraFormulario();			
		}

		private void toolSalir_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void buttonConsolidados_Click(object sender, EventArgs e)
		{
			BuscaConsolidados();
		}
		private void gridAjustes_CelltDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			SeleccionaAsiento_VerDetalle();
		}
		private void menuVerDetalleAsiento_Click(object sender, EventArgs e)
		{
			SeleccionaAsiento_VerDetalle();
		}
		private void textPeriodoAfectado_TextChanged(object sender, EventArgs e)
		{
		}
		private void textPeriodoAfectado_KeyUp(object sender, KeyEventArgs e)
		{
			CargaAsientosConsolidado();
		}
		private void tabControlAsientos_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (tabControlAsientos.SelectedTab == tabPageDetalle)
			{
				if (gridAjustes.Rows.Count > 0)
				{
					SeleccionaAsiento_VerDetalle();
				}
				else
				{
					hLog.msgError("No existen registros de asientos para revisar el detalle");
					tabControlAsientos.SelectedTab = tabPageAsientos;
				}
			}
		}
		private void toolNuevo_Click(object sender, EventArgs e)
		{
			ToolNuevoClick();
		}

		private void toolEditar_Click(object sender, EventArgs e)
		{
			ToolEditarClick();
		}

		private void toolCancelar_Click(object sender, EventArgs e)
		{
			CancelarAccion();
		}

		private void toolGrabar_Click(object sender, EventArgs e)
		{
			GrabarAsiento();
		}
		private void toolStripMenuNuevo_Click(object sender, EventArgs e)
		{
			tabControlMantencion.SelectedTab = tabPageMantencionAsientos;
		}

		private void toolStripMenuEditar_Click(object sender, EventArgs e)
		{
			EditarAsiento();
		}
		private void tabControlMantencion_SelectedIndexChanged(object sender, EventArgs e)
		{
			CambioTabPage();
		}
		private void textCodigoConsolidado_TextChanged(object sender, EventArgs e)
		{
		}
		private void textCodigoConsolidado_KeyPress(object sender, KeyPressEventArgs e)
		{
			//BuscaConsolidadosCodigo();
		}
		private void textManDebito_Enter(object sender, EventArgs e)
		{
			if (textManDebito.Text != "")
			{
				textManDebito.Text = textManDebito.Text.Replace(".", "");
			}
		}
		private void textManDebito_Leave(object sender, EventArgs e)
		{
			DebitoLeave();
		}
		private void textManHaber_Enter(object sender, EventArgs e)
		{
			if (textManHaber.Text != "")
			{
				textManHaber.Text = textManHaber.Text.Replace(".", "");
			}
		}
		private void textManHaber_Leave(object sender, EventArgs e)
		{
			HaberLeave();
		}
		private void gridMantencion_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			SeleccionaLineaMantencion();
		}
		private void buttonAgregar_Click(object sender, EventArgs e)
		{
			NuevoRegistro();
		}
		private void buttonActualizar_Click(object sender, EventArgs e)
		{
			EditarRegistro();
		}
		private void buttonEliminar_Click(object sender, EventArgs e)
		{
			EliminarRegistro();
		}
		private void toolStripMenuItemAnular_Click(object sender, EventArgs e)
		{
			AnularAsiento();
		}
		private void toolStripButtonImportar_Click(object sender, EventArgs e)
		{
			ImportarDatosExcel();
		}
		private void buttonBuscaCuenta_Click(object sender, EventArgs e)
		{
			LanzaCuentaContable();
		}
		private void textManCuenta_TextChanged(object sender, EventArgs e)
		{
			BuscaCuentaContable();
		}
		private void toolAjustesAutomaticos_Click(object sender, EventArgs e)
		{
			AjustesAutomaticos();
		}
		private void IngresoAjustesManuales_FormClosed(object sender, FormClosedEventArgs e)
		{
			if (NewConsolidado.Properties.Settings.Default.usrRecorarPosicionFormularios)
			{
				NewConsolidado.Properties.Settings.Default.frmIngresoAjustesManuales = this.Location;
				NewConsolidado.Properties.Settings.Default.frmIngresoAjustesManualesEstado = this.WindowState;
			}
		}
		private void IngresoAjustesManuales_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (NewConsolidado.Properties.Settings.Default.usrPreguntaFormulariosSalir)
			{
				DialogResult oDlg = MessageBox.Show("Quieres salir del ingreso de ajustes?", NewConsolidado.Properties.Settings.Default.appTituloAplicacion, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (oDlg == DialogResult.No)
				{
					e.Cancel = true;
				}
			}
		}
		private void IngresoAjustesManuales_Load(object sender, EventArgs e)
		{
			CargarFormulario();
		}
		private void toolStripButtonExportar_Click(object sender, EventArgs e)
		{
			BotonExportarDatos();
		}
		//------------------------------------------------------------------------------------------------------------------
		// Metodos accesos publicos
		//------------------------------------------------------------------------------------------------------------------

		public int IdConsolidado
		{
			get { return hiConsolidado; }
			set { hiConsolidado = value; }
		}
		public string IdCodigo
		{
			get { return hsCodigo; }
			set { hsCodigo = value; }
		}
		public string DescripcionConsolidado
		{
			get { return hsDescripcion; }
			set { hsDescripcion = value; }
		}

		//------------------------------------------------------------------------------------------------------------------
		// Metodos privados
		//------------------------------------------------------------------------------------------------------------------
		private void ConfiguraFormulario()
		{

			this.Text = "Ingreso de Ajustes Manuales";

			// Damos caracteristicas al boton de Buscar Consolidados
			buttonConsolidados.Image = global::NewConsolidado.Properties.Resources.rsc_16_Buscar;
			buttonConsolidados.Size = new System.Drawing.Size(70, 24);
			buttonConsolidados.Text = "Buscar";
			buttonConsolidados.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			buttonConsolidados.UseVisualStyleBackColor = true;
			//
			// Damos caracteristicas al boton de Buscar Consolidados
			buttonBuscaCuenta.Image = global::NewConsolidado.Properties.Resources.rsc_16_Buscar;
			buttonBuscaCuenta.Size = new System.Drawing.Size(75, 24);
			buttonBuscaCuenta.Text = "Agregar";
			buttonBuscaCuenta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			buttonBuscaCuenta.UseVisualStyleBackColor = true;
			//
			buttonAgregar.Image = global::NewConsolidado.Properties.Resources.rsc_24_Nuevo;
			buttonAgregar.Size = new System.Drawing.Size(CFG.buttonAncho, CFG.buttonAlto);
			buttonAgregar.Text = "Agregar";
			buttonAgregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			buttonAgregar.UseVisualStyleBackColor = true;
			//
			buttonActualizar.Image = global::NewConsolidado.Properties.Resources.rsc_24_Editar;
			buttonActualizar.Size = new System.Drawing.Size(CFG.buttonAncho, CFG.buttonAlto);
			buttonActualizar.Text = "Actualizar";
			buttonActualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			buttonActualizar.UseVisualStyleBackColor = true;
			//
			buttonEliminar.Image = global::NewConsolidado.Properties.Resources.rsc_24_Borrar;
			buttonEliminar.Size = new System.Drawing.Size(CFG.buttonAncho, CFG.buttonAlto);
			buttonEliminar.Text = "Eliminar";
			buttonEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			buttonEliminar.UseVisualStyleBackColor = true;
			//
			textCodigoConsolidado.MaxLength = 18;
			textPeriodoAfectado.MaxLength = 6;
			//
			textViewAsiento.ReadOnly = true;
			textViewAsiento.TabIndex = 0;
			textViewDescripcion.ReadOnly = true;
			textViewDescripcion.TabIndex = 1;
			textViewPeriodoAfecta.ReadOnly = true;
			textViewPeriodoAfecta.TabIndex = 2;
			textViewPeriodoVer.ReadOnly = true;
			textViewPeriodoVer.TabIndex = 3;
			comboViewTipo.Enabled = false;
			comboViewTipo.DropDownStyle = ComboBoxStyle.DropDownList;
			comboViewTipo.TabIndex = 4;
			comboViewTipo.Items.AddRange(CFG.aTipoAsiento);
			comboViewTipo.SelectedIndex = 0;
			textViewSumaDebe.ReadOnly = true;
			textViewSumaDebe.TabIndex = 5;
			textViewSumaHaber.ReadOnly = true;
			textViewSumaHaber.TabIndex = 6;
			// Incializar Objetos Mantenedor
			textManAsiento.TabIndex = 1;
			textDescripcionAjuste.TabIndex = 2;
			textManDescripcion.TabIndex = 3;
			//textManPeriodoAfecta.TabIndex = 3;
			textManPeriodoVer.TabIndex = 4;
			textManCuenta.TabIndex = 5;
			buttonBuscaCuenta.TabIndex = 6;
			textManDebito.TabIndex = 7;
			textManHaber.TabIndex = 8;
			buttonAgregar.TabIndex = 9;
			buttonEliminar.TabIndex = 10;
			gridMantencion.TabIndex = 11;
			//
			textManAsiento.MaxLength = 10;
			textDescripcionAjuste.MaxLength = 350;
			textManDescripcion.MaxLength = 350;
			//textManPeriodoAfecta.MaxLength = 6;
			textManPeriodoVer.MaxLength = 6;
			textManCuenta.MaxLength = 8;
			textManDebito.MaxLength = 20;
			textManHaber.MaxLength = 20;
			//
			EstadoBotonera(true);

			gridAjustes.Columns["colTipo"].Visible = Properties.Settings.Default.usrMuestraColumnasOcultas;
			gridMantencion.Columns["colAccion"].Visible = Properties.Settings.Default.usrMuestraColumnasOcultas;
			gridMantencion.Columns["colid"].Visible = Properties.Settings.Default.usrMuestraColumnasOcultas;

			textIdConsolidado.Visible = Properties.Settings.Default.usrMuestraCamposOcultos;

			laDescripcionConsolidado.Text = "";
			//textCodigoConsolidado.Focus();
			textCodigoConsolidado.TabStop = false;

			MisFunciones.ConfiguraToolBar(toolBarra);

	}
		private void CargarFormulario()
		{
			//this.Location = NewConsolidado.Properties.Settings.Default.frmIngresoAjustesManuales;
			//this.WindowState = NewConsolidado.Properties.Settings.Default.frmIngresoAjustesManualesEstado;
			textIdConsolidado.Text = hiConsolidado.ToString();
			textCodigoConsolidado.Text = hsCodigo;
			laDescripcionConsolidado.Text = hsDescripcion;

			textPeriodoAfectado.Text = "   ";
			textPeriodoAfectado.SelectAll();
			textPeriodoAfectado.Focus();
		}
		private void BuscaConsolidados()
		{
			MantenedorConsolidados_ConsultaArbolConsolidados oForm = new MantenedorConsolidados_ConsultaArbolConsolidados();
			oForm.StartPosition = FormStartPosition.CenterParent;
			oForm.ShowIcon = false;
			oForm.ShowInTaskbar = false;
			if (oForm.ShowDialog(this) == DialogResult.OK)
			{
				//
				BOConsolidados oBO = new BOConsolidados();
				DTOConsolidados oDTO = new DTOConsolidados();
				//
				oDTO = oBO.ConsultaConsolidado(oForm.CodigoRegistro);
				textIdConsolidado.Text = oDTO.IdRegistro.ToString();
				textCodigoConsolidado.Text = oDTO.Codigo;
				laDescripcionConsolidado.Text = oDTO.Descripcion.ToString();
				gridAjustes.Rows.Clear();
				gridDetalleAsiento.Rows.Clear();
				//
				textPeriodoAfectado.Text = "";
				textPeriodoAfectado.Focus();
			}
		}
		private void BuscaConsolidadosCodigo()
		{
			//BOConsolidados oBO = new BOConsolidados();
			//DTOConsolidados oDTO = new DTOConsolidados();
			//oDTO = oBO.ConsultaConsolidados(textCodigoConsolidado.Text);
			//if (oDTO != null)
			//{
			//    textIdConsolidado.Text = oDTO.IdRegistro.ToString();
			//    laDescripcionConsolidado.Text = oDTO.Descripcion;
			//    textPeriodoAfectado.Text = "";
			//    //
			//    //CargaAsientosConsolidado();
			//}
			//else
			//{
			//    textIdConsolidado.Text = "";
			//    laDescripcionConsolidado.Text = "";
			//}
		}
		private void CambioTabPage()
		{
			if (tabControlMantencion.SelectedTab == tabPageMantencionAsientos)
			{
				if (textCodigoConsolidado.Text == "")
				{
					hLog.msgError("Debe seleccionar un Consolidado para agregar Ajustes");
					//toolTip1.ToolTipIcon = ToolTipIcon.Error;
					//toolTip1.ToolTipTitle = "Codigo Consolidado no Valido";
					//toolTip1.Show( "Debe seleccionar un Consolidado para agregar Ajustes", textCodigoConsolidado, 5000 );

					tabControlMantencion.SelectedTab = tabPageConsultaAsientos;
					textCodigoConsolidado.SelectAll();
					textCodigoConsolidado.Focus();
					return;
				}
				if (textPeriodoAfectado.Text == "")
				{
					hLog.msgError("Debe seleccionar un Periodo para agregar Ajustes");
					tabControlMantencion.SelectedTab = tabPageConsultaAsientos;
					textPeriodoAfectado.SelectAll();
					textPeriodoAfectado.Focus();
					return;
				}
				if (int.Parse(textIdConsolidado.Text) == 0)
				{
					hLog.msgError("Debe seleccionar un Consolidado para agregar Ajustes");
					tabControlMantencion.SelectedTab = tabPageConsultaAsientos;
					textCodigoConsolidado.SelectAll();
					textCodigoConsolidado.Focus();
					return;
				}
				//
				gridMantencion.Rows.Clear();
				//
				if (hiAccion != (int)CFG.ToolAcciones.Editar)
				{
					NuevoAsiento();
				}
				else
				{
					EditarAsiento();
				}
			}
			else
			{
				hiAccion = (int)CFG.ToolAcciones.Nada;
				EstadoBotonera(true);
			}
		}
		private void CargaAsientosConsolidado()
		{
			try
			{
				if (textPeriodoAfectado.Text.Trim().Length == 6)
				{
					this.Cursor = Cursors.WaitCursor;

					hLog.Debug("Cargamos datos de asientos del consolidado");

					BOAjustes oBO = new BOAjustes();
					List<DTOAjustes> lAjustes = new List<DTOAjustes>();
					DTOAjustes oDTO = new DTOAjustes();
					int iConsolidado = int.Parse(textIdConsolidado.Text);
					string sPeriodo = textPeriodoAfectado.Text;
					oDTO = oBO.ConsultaCuadraturaConsolidado(iConsolidado, sPeriodo);
					textCuadraturaDebe.Text = "";
					textCuadraturaHaber.Text = "";
					if (oDTO != null)
					{
						textCuadraturaDebe.Text = oDTO.Debito.ToString(CFG.sFormatDisplayNumber);
						textCuadraturaHaber.Text = oDTO.Credito.ToString(CFG.sFormatDisplayNumber);
					}
					//
					gridAjustes.Rows.Clear();
					gridDetalleAsiento.Rows.Clear();
					gridMantencion.Rows.Clear();
					lAjustes = oBO.ConsultaAsientosPorConsolidado(iConsolidado, sPeriodo);
					foreach (DTOAjustes DTO in lAjustes)
					{
						gridAjustes.Rows.Add();
						gridAjustes.Rows[gridAjustes.Rows.Count - 1].Cells["colCodigoAsiento"].Value = DTO.CorrelativoAsiento;
						gridAjustes.Rows[gridAjustes.Rows.Count - 1].Cells["colDescripcion"].Value = DTO.Descripcion;
						gridAjustes.Rows[gridAjustes.Rows.Count - 1].Cells["colPeriodoAfecta"].Value = DTO.PeriodoAfectado;
						gridAjustes.Rows[gridAjustes.Rows.Count - 1].Cells["colPeriodoVisualiza"].Value = DTO.PeriodoVista;
						gridAjustes.Rows[gridAjustes.Rows.Count - 1].Cells["colTipo"].Value = DTO.TipoTransaccion;
						gridAjustes.Rows[gridAjustes.Rows.Count - 1].Cells["colDesTipo"].Value = CFG.aTipoAsiento[DTO.TipoTransaccion];
						gridAjustes.Rows[gridAjustes.Rows.Count - 1].Cells["colAsientoDebe"].Value = DTO.Debito.ToString(CFG.sFormatDisplayNumber);
						gridAjustes.Rows[gridAjustes.Rows.Count - 1].Cells["colAsientoHaber"].Value = DTO.Credito.ToString(CFG.sFormatDisplayNumber);
						if (DTO.TipoTransaccion == (int)CFG.TipoAjuste.Anulado)
						{
							gridAjustes.Rows[gridAjustes.Rows.Count - 1].DefaultCellStyle.BackColor = Color.LightGray;
							gridAjustes.Rows[gridAjustes.Rows.Count - 1].DefaultCellStyle.Font = new Font(this.Font, FontStyle.Strikeout);
						}
					}
					this.Cursor = Cursors.Default;
				}
				else
				{
					gridAjustes.Rows.Clear();
					gridDetalleAsiento.Rows.Clear();
					gridMantencion.Rows.Clear();

					textCuadraturaDebe.Text = "";
					textCuadraturaHaber.Text = "";
				}
			}
			catch (Exception ex)
			{
				hLog.msgError("Problemas con la carga de ajustes {" + ex + "}");
			}
		}
		private void SeleccionaAsiento_VerDetalle()
		{
			if (gridAjustes.Rows.Count > 0)
			{
				hLog.Debug("Cargamos datos de detalle del asiento");

				if (int.Parse(gridAjustes.Rows[gridAjustes.CurrentCell.RowIndex].Cells["colTipo"].Value.ToString()) == (int)CFG.TipoAjuste.Anulado)
				{
					hLog.msgError("El asiento se encuentra anulado, no puede visualizar los ajustes");
					return;
				}
				else
				{
					tabControlAsientos.SelectedTab = tabPageDetalle;
					BOAjustes oBO = new BOAjustes();
					List<DTOAjustes> lDetalle = new List<DTOAjustes>();
					try
					{
						Decimal dDebe = 0;
						Decimal dHaber = 0;
						gridDetalleAsiento.Rows.Clear();
						textViewAsiento.Text = gridAjustes.Rows[gridAjustes.CurrentCell.RowIndex].Cells["colCodigoAsiento"].Value.ToString();
						textViewDescripcion.Text = gridAjustes.Rows[gridAjustes.CurrentCell.RowIndex].Cells["colDescripcion"].Value.ToString();
						textViewPeriodoAfecta.Text = gridAjustes.Rows[gridAjustes.CurrentCell.RowIndex].Cells["colPeriodoAfecta"].Value.ToString();
						textViewPeriodoVer.Text = gridAjustes.Rows[gridAjustes.CurrentCell.RowIndex].Cells["colPeriodoVisualiza"].Value.ToString();
						comboViewTipo.SelectedIndex = int.Parse(gridAjustes.Rows[gridAjustes.CurrentCell.RowIndex].Cells["colTipo"].Value.ToString());
						laViewMensaje.Visible = (textViewSumaDebe.Text != textViewSumaHaber.Text);
						//
						string sCor = gridAjustes.Rows[gridAjustes.CurrentCell.RowIndex].Cells["colCodigoAsiento"].Value.ToString();
						lDetalle = oBO.ConsultaAjustesConsolidado(int.Parse(textIdConsolidado.Text), textPeriodoAfectado.Text, sCor);
						foreach (DTOAjustes DTO in lDetalle)
						{
							gridDetalleAsiento.Rows.Add();
							gridDetalleAsiento.Rows[gridDetalleAsiento.Rows.Count - 1].Cells["colCuenta"].Value = DTO.IdCuenta.ToString();
							gridDetalleAsiento.Rows[gridDetalleAsiento.Rows.Count - 1].Cells["colDescripcionCuenta"].Value = DTO.DescripcionCuenta.ToString();
							gridDetalleAsiento.Rows[gridDetalleAsiento.Rows.Count - 1].Cells["colDebe"].Value = DTO.Debito.ToString(CFG.sFormatDisplayNumber);
							gridDetalleAsiento.Rows[gridDetalleAsiento.Rows.Count - 1].Cells["colHaber"].Value = DTO.Credito.ToString(CFG.sFormatDisplayNumber);
							gridDetalleAsiento.Rows[gridDetalleAsiento.Rows.Count - 1].Cells["colDescripcionLinea"].Value = DTO.Descripcion.ToString();
							dDebe =dDebe + DTO.Debito;
							dHaber = dHaber + DTO.Credito;
						}
						textViewSumaDebe.Text = dDebe.ToString(CFG.sFormatDisplayNumber);
						textViewSumaHaber.Text = dHaber.ToString(CFG.sFormatDisplayNumber);
					}
					catch (Exception ex)
					{
						hLog.msgError("Problemas con la carga de ajustes {" + ex + "}");
					}
				}
			}
		}
		private void NuevoAsiento()
		{

			hiAccion = (int)CFG.ToolAcciones.Nuevo;
			EstadoBotonera(false);
			//
			textManAsiento.Text = "";
			textDescripcionAjuste.Text = "";
			textManDescripcion.Text = "";
			//textManPeriodoAfecta.Text= "";
			//textManPeriodoAfecta.Text = textViewPeriodoAfecta.Text;
			textManPeriodoVer.Text = textPeriodoAfectado.Text;
			textManCuenta.Text = "";
			textManDebito.Text = "0";
			textManHaber.Text = "0";
			gridMantencion.Rows.Clear();
			textDescripcionAjuste.Focus();
		}
		private void CancelarAccion()
		{
			hiAccion = (int)CFG.ToolAcciones.Nada;
			EstadoBotonera(true);
			tabControlMantencion.SelectedTab = tabPageConsultaAsientos;
			gridAjustes.Focus();
		}
		private void EditarAsiento()
		{
			if (textIdConsolidado.Text == "")
			{
				hLog.msgError("Debe seleccionar un Consolidado para trabajar");
				//
				textCodigoConsolidado.SelectAll();
				textCodigoConsolidado.Focus();
				//
				hiAccion = (int)CFG.ToolAcciones.Nada;
				//
				tabControlMantencion.SelectedTab = tabPageConsultaAsientos;
				tabControlAsientos.SelectedTab = tabPageAsientos;
				EstadoBotonera(true);
				return;
			}
			if (textPeriodoAfectado.Text == "")
			{
				hLog.msgError("Debe ingresar un periodo a afectar");
				//
				textPeriodoAfectado.SelectAll();
				textPeriodoAfectado.Focus();
				///
				hiAccion = (int)CFG.ToolAcciones.Nada;
				//
				tabControlMantencion.SelectedTab = tabPageConsultaAsientos;
				tabControlAsientos.SelectedTab = tabPageAsientos;
				EstadoBotonera(true);
				return;
			}
			if (gridAjustes.Rows.Count > 0)
			{
				if (int.Parse(gridAjustes.Rows[gridAjustes.CurrentCell.RowIndex].Cells["colTipo"].Value.ToString()) == (int)CFG.TipoAjuste.Anulado)
				{
					hLog.msgError("El Asiento se encuentra anulado, por lo que no puede editarlo");
					return;
				}
				if (int.Parse(gridAjustes.Rows[gridAjustes.CurrentCell.RowIndex].Cells["colCodigoAsiento"].Value.ToString()) > 0)
				{
					tabControlMantencion.SelectedTab = tabPageMantencionAsientos;

					hiAccion = (int)CFG.ToolAcciones.Editar;
					EstadoBotonera(false);

					int iConsolidado = int.Parse(textIdConsolidado.Text);
					string sPeriodo = textPeriodoAfectado.Text;
					string sCor = gridAjustes.Rows[gridAjustes.CurrentCell.RowIndex].Cells["colCodigoAsiento"].Value.ToString();
					//
					textManAsiento.Text = gridAjustes.Rows[gridAjustes.CurrentCell.RowIndex].Cells["colCodigoAsiento"].Value.ToString();
					textDescripcionAjuste.Text = gridAjustes.Rows[gridAjustes.CurrentCell.RowIndex].Cells["colDescripcion"].Value.ToString();
					//textManPeriodoAfecta.Text = gridAjustes.Rows[gridAjustes.CurrentCell.RowIndex].Cells["colPeriodoAfecta"].Value.ToString();
					textManPeriodoVer.Text = gridAjustes.Rows[gridAjustes.CurrentCell.RowIndex].Cells["colPeriodoVisualiza"].Value.ToString();
					//comboViewTipo.SelectedIndex = int.Parse( gridAjustes.Rows[gridAjustes.CurrentCell.RowIndex].Cells["colTipo"].Value.ToString() );
					//textViewSumaDebe.Text = gridAjustes.Rows[gridAjustes.CurrentCell.RowIndex].Cells["colAsientoDebe"].Value.ToString();
					//textViewSumaHaber.Text = gridAjustes.Rows[gridAjustes.CurrentCell.RowIndex].Cells["colAsientoHaber"].Value.ToString();
					BOAjustes oBO = new BOAjustes();
					List<DTOAjustes> lDetalle = new List<DTOAjustes>();
					lDetalle = oBO.ConsultaAjustesConsolidado(iConsolidado, sPeriodo, sCor);
					foreach (DTOAjustes oDTO in lDetalle)
					{
						gridMantencion.Rows.Add();
						gridMantencion.Rows[gridMantencion.Rows.Count - 1].Cells["colManCuenta"].Value = oDTO.IdCuenta.ToString();
						gridMantencion.Rows[gridMantencion.Rows.Count - 1].Cells["colManDesCuenta"].Value = oDTO.DescripcionCuenta.ToString();
						gridMantencion.Rows[gridMantencion.Rows.Count - 1].Cells["colManDebe"].Value = oDTO.Debito.ToString(CFG.sFormatDisplayNumber);
						gridMantencion.Rows[gridMantencion.Rows.Count - 1].Cells["colManHaber"].Value = oDTO.Credito.ToString(CFG.sFormatDisplayNumber);
						gridMantencion.Rows[gridMantencion.Rows.Count - 1].Cells["colAccion"].Value = (int)CFG.ToolAcciones.Nada;
						gridMantencion.Rows[gridMantencion.Rows.Count - 1].Cells["colId"].Value = oDTO.IdRegistro;
						gridMantencion.Rows[gridMantencion.Rows.Count - 1].Cells["colDescripcionLineaMant"].Value = oDTO.Descripcion;
					}
					if (gridMantencion.Rows.Count > 0)
					{
						//gridMantencion.Rows[0].Selected = true;
						//textManCuenta.Text = gridMantencion.Rows[gridMantencion.CurrentCell.RowIndex].Cells["colManCuenta"].Value.ToString();
						//textManDebito.Text = gridMantencion.Rows[gridMantencion.CurrentCell.RowIndex].Cells["colManDebe"].Value.ToString();
						//textManHaber.Text = gridMantencion.Rows[gridMantencion.CurrentCell.RowIndex].Cells["colManHaber"].Value.ToString();
					}
					//
					ValidaCuadratura();
					//
					textManDescripcion.Focus();
				}
				else
				{
					hLog.msgError("Un asiento generado por el sistema de manera automatica no puede ser editado");
				}
			}
		}
		private void EstadoBotonera(bool bEstado)
		{
			toolNuevo.Enabled = bEstado;
			toolEditar.Enabled = bEstado;
			toolCancelar.Enabled = !bEstado;
			toolGrabar.Enabled = !bEstado;
		}
		private Boolean Validaciones()
		{
			if (textCodigoConsolidado.Text == "")
			{
				hLog.msgError("Debe seleccionar un Consolidado para continuar");
				textCodigoConsolidado.Focus();
				return false;
			}
			if (textPeriodoAfectado.Text == "")
			{
				hLog.msgError("Debe seleccionar un Periodo para continuar");
				textPeriodoAfectado.Focus();
				return false;
			}

			return true;
		}
		private void SeleccionaLineaMantencion()
		{
			if (gridMantencion.Rows.Count > 0)
			{
				textManDescripcion.Text = gridMantencion.Rows[gridMantencion.CurrentCell.RowIndex].Cells["colDescripcionLineaMant"].Value.ToString();
				textManCuenta.Text = gridMantencion.Rows[gridMantencion.CurrentCell.RowIndex].Cells["colManCuenta"].Value.ToString();
				textManDebito.Text = gridMantencion.Rows[gridMantencion.CurrentCell.RowIndex].Cells["colManDebe"].Value.ToString();
				textManHaber.Text = gridMantencion.Rows[gridMantencion.CurrentCell.RowIndex].Cells["colManHaber"].Value.ToString();
				//
				textManCuenta.Focus();
			}
		}
		private void NuevoRegistro()
		{
			if( textManDescripcion.Text.Trim() == "")
			{
				hLog.msgError("Debe ingresar una glosa para el asiento");
				textManDescripcion.Focus();
				textManDescripcion.SelectAll();
				return;
			}
			if( textManCuenta.Text.Trim() == "")
			{
				hLog.msgError("Debe seleccionar una cuenta para el ajustes");
				textManCuenta.Focus();
				textManCuenta.SelectAll();
				return;
			}
			if (laGlosaCuenta.Text.Trim() == "")
			{
				hLog.msgError("Debe seleccionar una cuenta valida para el ajustes");
				textManCuenta.Focus();
				textManCuenta.SelectAll();
				return;
			}
			if (textManDebito.Text.Trim() == "" && textManHaber.Text.Trim() == "")
			{
				hLog.msgError("Debe ingresar un valor para el ajuste");
				textManDebito.Focus();
				textManDebito.SelectAll();
				return;
			}
			gridMantencion.Rows.Add();
			gridMantencion.Rows[gridMantencion.Rows.Count - 1].Cells["colManCuenta"].Value = textManCuenta.Text.Trim();
			gridMantencion.Rows[gridMantencion.Rows.Count - 1].Cells["colManDesCuenta"].Value = laGlosaCuenta.Text.Trim();
			gridMantencion.Rows[gridMantencion.Rows.Count - 1].Cells["colManDebe"].Value = textManDebito.Text == "" ? "0" : textManDebito.Text;
			gridMantencion.Rows[gridMantencion.Rows.Count - 1].Cells["colManHaber"].Value = textManHaber.Text == "" ? "0" : textManHaber.Text;
			gridMantencion.Rows[gridMantencion.Rows.Count - 1].Cells["colAccion"].Value = ((int)CFG.ToolAcciones.Nuevo).ToString();
			gridMantencion.Rows[gridMantencion.Rows.Count - 1].Cells["colId"].Value = "0";
			gridMantencion.Rows[gridMantencion.Rows.Count - 1].Cells["colDescripcionLineaMant"].Value = textManDescripcion.Text;
			//
			textManCuenta.Text = "";
			textManCuenta.Text = "";
			textManDebito.Text = "0";
			textManHaber.Text = "0";
			textManDescripcion.Text = "";
			//
			textManCuenta.Focus();
			//
			ValidaCuadratura();
		}
		private void EditarRegistro()
		{
			if (textManDescripcion.Text.Trim() == "")
			{
				hLog.msgError("Debe ingresar una glosa para el asiento");
				textManDescripcion.Focus();
				textManDescripcion.SelectAll();
				return;
			}
			if (textManCuenta.Text.Trim() == "")
			{
				hLog.msgError("Debe seleccionar una cuenta para el ajustes");
				textManCuenta.Focus();
				textManCuenta.SelectAll();
				return;
			}
			if (laGlosaCuenta.Text.Trim() == "")
			{
				hLog.msgError("Debe seleccionar una cuenta valida para el ajustes");
				textManCuenta.Focus();
				textManCuenta.SelectAll();
				return;
			}
			if (textManDebito.Text.Trim() == "" && textManHaber.Text.Trim() == "")
			{
				hLog.msgError("Debe ingresar un valor para el ajuste");
				textManDebito.Focus();
				textManDebito.SelectAll();
				return;
			}
			if (gridMantencion.Rows.Count <= 0)
			{
				hLog.msgError("Debe seleccionar un registro para ser actualizado");
				return;
			}
			if( int.Parse(gridMantencion.Rows[gridMantencion.CurrentCell.RowIndex].Cells["colAccion"].Value.ToString()) == (int)CFG.ToolAcciones.Nuevo)
			{
				hLog.msgError("Este registro fue recientemente creado, puede eliminarlo y volver a crearlo o grabar y editarlo");
				return;
			}

			gridMantencion.Rows[gridMantencion.CurrentCell.RowIndex].Cells["colManCuenta"].Value = textManCuenta.Text;
			gridMantencion.Rows[gridMantencion.CurrentCell.RowIndex].Cells["colManDesCuenta"].Value = laGlosaCuenta.Text;
			gridMantencion.Rows[gridMantencion.CurrentCell.RowIndex].Cells["colManDebe"].Value = textManDebito.Text;
			gridMantencion.Rows[gridMantencion.CurrentCell.RowIndex].Cells["colManHaber"].Value = textManHaber.Text;
			gridMantencion.Rows[gridMantencion.CurrentCell.RowIndex].Cells["colAccion"].Value = ((int)CFG.ToolAcciones.Editar).ToString();
			gridMantencion.Rows[gridMantencion.CurrentCell.RowIndex].Cells["colDescripcionLineaMant"].Value = textManDescripcion.Text;
			//
			textManCuenta.Text = "";
			textManCuenta.Text = "";
			textManDebito.Text = "0";
			textManHaber.Text = "0";
			textManDescripcion.Text = "";
			//
			textManCuenta.Focus();
			//
			ValidaCuadratura();
		}
		private void EliminarRegistro()
		{
			if (hiAccion == (int)CFG.ToolAcciones.Nuevo)
			{
				gridMantencion.Rows.RemoveAt(gridMantencion.CurrentCell.RowIndex);
			}
			else
			{
				gridMantencion.Rows[gridMantencion.CurrentCell.RowIndex].DefaultCellStyle.Font = new Font(this.Font, FontStyle.Strikeout);
				gridMantencion.Rows[gridMantencion.CurrentCell.RowIndex].Cells["colAccion"].Value = ((int)CFG.ToolAcciones.Eliminar).ToString();
			}
			//
			ValidaCuadratura();
		}
		private void ValidaCuadratura()
		{
			if (gridMantencion.Rows.Count > 0)
			{
				decimal dDebe= 0, dHaber= 0, dD, dP;
				int iA = 0;

				for (int iI = 0; gridMantencion.Rows.Count > iI; ++iI)
				{
					iA = int.Parse(gridMantencion.Rows[iI].Cells["colAccion"].Value.ToString());
					if (iA != (int)CFG.ToolAcciones.Eliminar)
					{
						// Limpiamos las salidas
						dD = 0; dP = 0;

						decimal.TryParse(gridMantencion.Rows[iI].Cells["colManDebe"].Value.ToString().Replace(".", ""), out dD);
						decimal.TryParse(gridMantencion.Rows[iI].Cells["colManHaber"].Value.ToString().Replace(".", ""), out dP);

						dDebe += dD;
						dHaber += dP;
					}
				}
				laMensaje.Visible = (dDebe != dHaber);
			}
			else
			{
				laMensaje.Visible = false;
			}
		}
		private void GrabarAsiento()
		{
			if (laMensaje.Visible)
			{
				hLog.msgError("El asiento debe quedar cuadrado antes de poder grabarlo");
				gridMantencion.Focus();
				return;
			}
			try
			{
				if (gridMantencion.Rows.Count > 0)
				{
					BOAjustes oBO = new BOAjustes();
					List<DTOAjustes> oList = new List<DTOAjustes>();
					int iCorrelativoAsiento = 0;
					//
					switch (hiAccion)
					{
						case (int)CFG.ToolAcciones.Nuevo:
							{
                                #region Nuevo
								iCorrelativoAsiento = oBO.UltimoAsiento(int.Parse(textIdConsolidado.Text), textPeriodoAfectado.Text);
								for (int iI = 0; iI < gridMantencion.Rows.Count; ++iI)
								{
									if (int.Parse(gridMantencion.Rows[iI].Cells["colAccion"].Value.ToString()) != (int)CFG.ToolAcciones.Eliminar)
									{
										DTOAjustes oDTO = new DTOAjustes();
										oDTO.IdConsolidado = int.Parse(textIdConsolidado.Text);
										oDTO.PeriodoAfectado = textPeriodoAfectado.Text;
										oDTO.CorrelativoAsiento = iCorrelativoAsiento;
										oDTO.PeriodoVista = textManPeriodoVer.Text;
										oDTO.TipoTransaccion = (int)CFG.TipoAjuste.Manual;
										oDTO.Descripcion = gridMantencion.Rows[iI].Cells["colDescripcionLineaMant"].Value.ToString();
										oDTO.DescripcionCabecera = textDescripcionAjuste.Text;
										oDTO.IdCuenta = gridMantencion.Rows[iI].Cells["colManCuenta"].Value.ToString();
										oDTO.Debito = decimal.Parse(gridMantencion.Rows[iI].Cells["colManDebe"].Value.ToString());
										oDTO.Credito = decimal.Parse(gridMantencion.Rows[iI].Cells["colManHaber"].Value.ToString());
										oDTO.Accion = int.Parse(gridMantencion.Rows[iI].Cells["colAccion"].Value.ToString());
										oDTO.IdRegistro = int.Parse(gridMantencion.Rows[iI].Cells["colId"].Value.ToString());
										oList.Add(oDTO);
									}
								}
								//
								oBO.GrabarAjustes(oList, hiAccion);
                                #endregion
                                break;
							}
						case (int)CFG.ToolAcciones.Editar:
                            {
                                #region Editar
                                #region elimina Registros
                                oList = new List<DTOAjustes>();
                                for (int iI = 0; iI < gridMantencion.Rows.Count; ++iI)
                                {
                                    DTOAjustes oDTO = new DTOAjustes();
                                    oDTO.IdConsolidado = int.Parse(textIdConsolidado.Text);
                                    oDTO.PeriodoAfectado = textPeriodoAfectado.Text;
                                    oDTO.CorrelativoAsiento = iCorrelativoAsiento;
                                    oDTO.PeriodoVista = textManPeriodoVer.Text;
                                    oDTO.TipoTransaccion = (int)CFG.TipoAjuste.Manual;
                                    oDTO.Descripcion = gridMantencion.Rows[iI].Cells["colDescripcionLineaMant"].Value.ToString();
                                    oDTO.DescripcionCabecera = textDescripcionAjuste.Text;
                                    oDTO.IdCuenta = gridMantencion.Rows[iI].Cells["colManCuenta"].Value.ToString();
                                    oDTO.Debito = decimal.Parse(gridMantencion.Rows[iI].Cells["colManDebe"].Value.ToString());
                                    oDTO.Credito = decimal.Parse(gridMantencion.Rows[iI].Cells["colManHaber"].Value.ToString());
                                    oDTO.Accion = int.Parse(gridMantencion.Rows[iI].Cells["colAccion"].Value.ToString());
                                    oDTO.IdRegistro = int.Parse(gridMantencion.Rows[iI].Cells["colId"].Value.ToString());
                                    oList.Add(oDTO);
                                }
                                hLog.Debug("Primero eliminamos");
                                oBO.GrabarAjustes(oList, (int)CFG.ToolAcciones.Eliminar);
                                #endregion

                                #region Actualiza Registros segun pantalla
                                oList = new List<DTOAjustes>();
                                // Proceso de descarte de registros eliminados en pantalla
                                iCorrelativoAsiento = int.Parse(textManAsiento.Text);
								for (int iI = 0; iI < gridMantencion.Rows.Count; ++iI)
								{
									if (int.Parse(gridMantencion.Rows[iI].Cells["colAccion"].Value.ToString()) != (int)CFG.ToolAcciones.Eliminar)
									{
										DTOAjustes oDTO = new DTOAjustes();
										oDTO.IdConsolidado = int.Parse(textIdConsolidado.Text);
										oDTO.PeriodoAfectado = textPeriodoAfectado.Text;
										oDTO.CorrelativoAsiento = iCorrelativoAsiento;
										oDTO.PeriodoVista = textManPeriodoVer.Text;
										oDTO.TipoTransaccion = (int)CFG.TipoAjuste.Manual;
										oDTO.Descripcion = gridMantencion.Rows[iI].Cells["colDescripcionLineaMant"].Value.ToString();
										oDTO.DescripcionCabecera = textDescripcionAjuste.Text;
										oDTO.IdCuenta = gridMantencion.Rows[iI].Cells["colManCuenta"].Value.ToString();
										oDTO.Debito = decimal.Parse(gridMantencion.Rows[iI].Cells["colManDebe"].Value.ToString());
										oDTO.Credito = decimal.Parse(gridMantencion.Rows[iI].Cells["colManHaber"].Value.ToString());
                                        oDTO.Accion = (int)CFG.ToolAcciones.Editar; //int.Parse(gridMantencion.Rows[iI].Cells["colAccion"].Value.ToString());
										oDTO.IdRegistro = int.Parse(gridMantencion.Rows[iI].Cells["colId"].Value.ToString());
										oList.Add(oDTO);
									}
								}
								hLog.Debug("Luego agregamos nuevamente los regsitros");
								oBO.GrabarAjustes(oList, (int)CFG.ToolAcciones.Editar);
                                #endregion
                                #endregion
                                break;
							}
						default:
							{
								hLog.Fatal("Mala clasificacion al {GrabarAsiento}");
								throw new SystemException("Mala clasificacion al {GrabarAsiento}");
								
							}
					}
				}
				//
				tabControlMantencion.SelectedTab = tabPageConsultaAsientos;
				tabControlAsientos.SelectedTab = tabPageAsientos;
				gridDetalleAsiento.Rows.Clear();
				gridMantencion.Rows.Clear();
				CargaAsientosConsolidado();
				//
				EstadoBotonera(true);
			}
			catch (Exception ex)
			{
				hLog.msgFatal("Error detectado \n{" + ex.Message + "}");
			}
		}
		private void ToolNuevoClick()
		{
			hiAccion = (int)CFG.ToolAcciones.Nuevo;
			tabControlMantencion.SelectedTab = tabPageMantencionAsientos;
		}

		private void ToolEditarClick()
		{
			hiAccion = (int)CFG.ToolAcciones.Editar;
			tabControlMantencion.SelectedTab = tabPageMantencionAsientos;
		}

		private void AnularAsiento()
		{
			try
			{
				if (textIdConsolidado.Text == "")
				{
					hLog.msgError("Debe ingresar un Consolidado para trabajar");
					textCodigoConsolidado.SelectAll();
					textCodigoConsolidado.Focus();
					return;
				}
				if (textPeriodoAfectado.Text == "")
				{
					hLog.msgError("Debe ingresar un periodo a revisar");
					textPeriodoAfectado.SelectAll();
					textPeriodoAfectado.Focus();
					return;
				}
                if (gridAjustes.Rows.Count > 0)
                {
                    if (int.Parse(gridAjustes.Rows[gridAjustes.CurrentCell.RowIndex].Cells["colTipo"].Value.ToString()) == (int)CFG.TipoAjuste.Automatico)
                    {
                        hLog.msgError("Los Asientos Automaticos no pueden ser anulados");
                        return;
                    }
                    else
                    {
                        if (int.Parse(gridAjustes.Rows[gridAjustes.CurrentCell.RowIndex].Cells["colTipo"].Value.ToString()) == (int)CFG.TipoAjuste.Anulado)
                        {
                            hLog.msgError("El Asiento se encuentra anulado, por lo que no puede volver a ejecutar la acción");
                            return;
                        }

                        this.Cursor = Cursors.WaitCursor;
                        int iConsolidado = int.Parse(textIdConsolidado.Text);
                        string sPeriodo = textPeriodoAfectado.Text;
                        int iCorrelativo = int.Parse(gridAjustes.Rows[gridAjustes.CurrentCell.RowIndex].Cells["colCodigoAsiento"].Value.ToString());
                        BOAjustes oBO = new BOAjustes();
                        oBO.AnularAsiento(iConsolidado, iCorrelativo, sPeriodo);
                        //
                        CargaAsientosConsolidado();
                        this.Cursor = Cursors.Default;
                    }
                }
			}
			catch (Exception Ex)
			{
				hLog.msgFatal("Error detectado \n{" + Ex.Message + "}");
			}
		}
		private void ImportarDatosExcel()
		{
			if (textIdConsolidado.Text == "")
			{
				hLog.msgError("Debe seleccionar una consolidado para recibir los datos");
				textCodigoConsolidado.SelectAll();
				textCodigoConsolidado.Focus();
				return;
			}
			//if (textPeriodoAfectado.Text == "")
			//{
			//    hLog.msgAlerta("Debe seleccionar el periodo afectado que recibira los datos");
			//    textPeriodoAfectado.SelectAll();
			//    textPeriodoAfectado.Focus();
			//    return;
			//}
			hLog.Debug("Defino ventana de dialo con Filtro solo para planillas Microsoft Excel");
			OpenFileDialog oDlg = new OpenFileDialog();
			oDlg.Filter = "Excel|*.xls;*.xlsx";
			DialogResult dResult = oDlg.ShowDialog();
			if (dResult == DialogResult.OK)
			{
				try
				{
					string sRutaArchivo = oDlg.FileName;
					hLog.Debug("Apertura del archivo Excel {" + sRutaArchivo + "}");

					IngresoAjustesManualesResumenImportacion oForm = new IngresoAjustesManualesResumenImportacion();
					oForm.RutaArchivo = sRutaArchivo;
					oForm.idConsolidado = int.Parse(textIdConsolidado.Text);
					oForm.ShowIcon = false;
					oForm.ShowInTaskbar = false;
					if (oForm.ShowDialog(this) == DialogResult.OK)
					{
						CargaAsientosConsolidado();
					}
				}
				catch (Exception Ex)
				{
					hLog.Fatal("Error al importar el archivo excel {" + Ex.Message + "}");
				}
			}
		}
		private void LanzaCuentaContable()
		{
			ConsultaCuentasContables oForm = new ConsultaCuentasContables();
			oForm.StartPosition = FormStartPosition.CenterParent;
			oForm.ShowIcon = false;
			oForm.ShowInTaskbar = false;
			DialogResult oDlg = oForm.ShowDialog(this);
			//
			if (oDlg == DialogResult.OK)
			{
				textManCuenta.Text = oForm.IdCuenta.ToString();
				laGlosaCuenta.Text = oForm.sGlosa.ToString();
			}
		}
		private void BuscaCuentaContable()
		{
			BOMaestroCuentas oBO = new BOMaestroCuentas();
			DTOMaestroCuentas oDto = new DTOMaestroCuentas();
			oDto = oBO.ConsultaMaestroCuentasCodigo(textManCuenta.Text);
			if (oDto != null)
			{
				laGlosaCuenta.Text = oDto.Descripcion;
			}
		}
		private void DebitoLeave()
		{
			if (textManDebito.Text != "")
			{
				decimal dP = 0;
				if (decimal.TryParse(textManDebito.Text.Replace(".", ""), out dP))
				{
					if (dP != 0)
					{
						if (dP > 0)
						{
							if (textManHaber.Text != "")
							{
								if (int.Parse(textManHaber.Text.Replace(".", "")) > 0)
								{
									hLog.msgError("No puede ingresar Debe y Haber");
								}
								else
								{
									textManDebito.Text = decimal.Parse(textManDebito.Text).ToString(CFG.sFormatDisplayNumber);
								}
							}
							else
							{
								textManDebito.Text = decimal.Parse(textManDebito.Text).ToString(CFG.sFormatDisplayNumber);
							}
						}
						else
						{
							hLog.msgError("El valor ingresado debe ser positivo");
							textManDebito.SelectAll();
							textManDebito.Focus();
						}
					}
					else
					{
						textManDebito.Text = "0";
					}
				}
				else
				{
					hLog.msgError("Debe ingresar un valor numerico");
					textManDebito.SelectAll();
					textManDebito.Focus();
				}
			}
			else
			{
				textManDebito.Text = "0";
			}
		}
		private void HaberLeave()
		{
			if (textManHaber.Text != "")
			{
				decimal dP = 0;
				if (decimal.TryParse(textManHaber.Text.Replace(".", ""), out dP))
				{
					if (dP != 0)
					{
						if (dP > 0)
						{
							if (textManDebito.Text != "")
							{
								if (decimal.Parse(textManDebito.Text.Replace(".", "")) > 0)
								{
									hLog.msgError("No puede ingresar Debe y Haber");
								}
								else
								{
									textManHaber.Text = decimal.Parse(textManHaber.Text).ToString(CFG.sFormatDisplayNumber);
								}
							}
							else
							{
								textManHaber.Text = decimal.Parse(textManHaber.Text).ToString(CFG.sFormatDisplayNumber);
							}
						}
						else
						{
							hLog.msgError("Debe ingresar un valor positivo");
							textManHaber.SelectAll();
							textManHaber.Focus();
						}
					}
					else
					{
						textManHaber.Text = "0";
					}
				}
				else
				{
					hLog.msgError("Debe ingresar un valor numerico");
					textManHaber.SelectAll();
					textManHaber.Focus();
				}
			}
			else
			{
				textManHaber.Text = "0";
			}
		}
		private void AjustesAutomaticos()
		{
			try
			{
				if (textIdConsolidado.Text.Trim() == "")
				{
					hLog.msgError("Debe seleccionar un Consolidado para procesar");
					textCodigoConsolidado.Focus();
					textCodigoConsolidado.SelectAll();
					return;
				}
				if (textPeriodoAfectado.Text.Trim() == "")
				{
					hLog.msgError("Debe seleccionar un periodo para procesar");
					textPeriodoAfectado.Focus();
					textPeriodoAfectado.SelectAll();
					return;
				}

				this.Cursor = Cursors.WaitCursor;
				//
				gridAjustes.Rows.Clear();

				tabControlMantencion.SelectedTab = tabPageConsultaAsientos;
				tabPageConsultaAsientos.Show();

				tabControlAsientos.SelectedTab = tabPageAsientos;
				tabPageAsientos.Show();
				this.Refresh();

				MisFunciones.AppPausa(3);
				//
				int idConsolidado = int.Parse(textIdConsolidado.Text);
				string sPeriodo = textPeriodoAfectado.Text.Trim();
				BOAjustes oBO = new BOAjustes();
				oBO.EjecutaAjutesAutomaticos(idConsolidado, sPeriodo);
				//
				CargaAsientosConsolidado();
				//
				this.Cursor = Cursors.Default;
			}
			catch (Exception Ex)
			{
				hLog.msgFatal("Error detectado \n {" + Ex.Message + "}");
				this.Cursor = Cursors.Default;
			}
		}

		private void BotonExportarDatos()
		{
			if (textCodigoConsolidado.Text.Trim() == "")
			{
				hLog.msgError("Debe seleccionar el Consolidado para hacer la exportación de datos");
				textCodigoConsolidado.Focus();
				return ;
			}

			//if (textPeriodoAfectado.Text.Trim() == "")
			//{
			//  hLog.msgError("Debe seleccionar el periodo afectado para hacer la exportación de datos");
			//  textPeriodoAfectado.Focus();
			//  return;
			//}

			SaveFileDialog oDlg = new SaveFileDialog();
			oDlg.FileName = "Ajustes";
			oDlg.Filter = "Excel (*.xlsx)|*.xlsx";
			if (oDlg.ShowDialog() == DialogResult.OK)
			{
				try
				{
					this.Cursor = Cursors.WaitCursor;

					// Apertura y creacion del arhivo
					Excel.Application Aplicacion = new Excel.Application();
					Excel.Workbook LibroTrabajo = (Excel.Workbook)Aplicacion.Workbooks.Add(Type.Missing);
					Excel.Worksheet HojaTrabajo = (Excel.Worksheet)LibroTrabajo.Worksheets.get_Item(1);

					HojaTrabajo.Cells[1, 1] = "Agrupador";
					HojaTrabajo.Cells[1, 2] = "Periodo Afectado";
					HojaTrabajo.Cells[1, 3] = "Periodo Visualizar";
					HojaTrabajo.Cells[1, 4] = "Cuenta";
					HojaTrabajo.Cells[1, 5] = "Debito";
					HojaTrabajo.Cells[1, 6] = "Credito";
					HojaTrabajo.Cells[1, 7] = "Descripcion Linea";
					HojaTrabajo.Cells[1, 8] = "Descripcion Ajuste";

					BOAjustes oBO = new BOAjustes();
					List<DTOAjustes> oL = new List<DTOAjustes>();
					oL = oBO.ConsultaAjustesConsolidado(int.Parse(textIdConsolidado.Text), textPeriodoAfectado.Text, "");
					int iLinea = 2;
					foreach (DTOAjustes oDTO in oL)
					{
						if (oDTO.CorrelativoAsiento > 0)
						{
							HojaTrabajo.Cells[iLinea, 1] = oDTO.CorrelativoAsiento.ToString();	// "Agrupador";
							HojaTrabajo.Cells[iLinea, 2] = oDTO.PeriodoAfectado.ToString();			// "PeriodoAfectado";
							HojaTrabajo.Cells[iLinea, 3] = oDTO.PeriodoVista.ToString();				// "PeriodoVisualizar";
							HojaTrabajo.Cells[iLinea, 4] = oDTO.IdCuenta.ToString();						// "Cuenta";
							HojaTrabajo.Cells[iLinea, 5] = oDTO.Debito.ToString();							// "Debito";
							HojaTrabajo.Cells[iLinea, 6] = oDTO.Credito.ToString();							// "Credito";
							HojaTrabajo.Cells[iLinea, 7] = oDTO.Descripcion.ToString();					// "Descripcion";
							HojaTrabajo.Cells[iLinea, 8] = oDTO.DescripcionCabecera.ToString();	// "Descripcion Ajuste";
							iLinea++;
						}
					}

					LibroTrabajo.SaveAs(oDlg.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlShared, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
					LibroTrabajo.Close(true, oDlg.FileName, Type.Missing);
					Aplicacion.Quit();

					this.Cursor = Cursors.Default;
				}
				catch (Exception Ex)
				{
					hLog.msgFatal(Ex.Message);
				}
			}
		}
	}
}
