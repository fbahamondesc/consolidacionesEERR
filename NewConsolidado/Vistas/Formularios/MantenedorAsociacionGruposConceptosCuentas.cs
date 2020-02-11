using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using NewConsolidado.Controladores.Clases;
using NewConsolidado.Controladores.ControladorNegocio;
using NewConsolidado.Modelos.TransporteDatos;

namespace NewConsolidado.Vistas.Formularios
{
	public partial class MantenedorAsociacionGruposConceptosCuentas : Form
	{
		private MyLog4Net hLog = new MyLog4Net("MantencionAsociacionGruposConceptosCuentas.Form");
		private int iAccion;

		public MantenedorAsociacionGruposConceptosCuentas()
		{
			InitializeComponent();
			//
			this.Text = "Mantenedor Asociacion de Grupo/Concepto/Cuenta";
			//
			ConfiguracionFormulario();
		}
		
        private void MantencionAsociacionGruposConceptosCuentas_Load(object sender, EventArgs e)
		{
			CargaFormulario();
		}
		
        private void MantencionAsociacionGruposConceptosCuentas_FormClosed(object sender, FormClosedEventArgs e)
		{

		}
		
        private void MantencionAsociacionGruposConceptosCuentas_FormClosing(object sender, FormClosingEventArgs e)
		{

		}

		private void comboGrupos_SelectedIndexChanged(object sender, EventArgs e)
		{
			CargaGrilla();
		}
		
        private void comboConceptos_SelectedIndexChanged(object sender, EventArgs e)
		{
			CargaGrilla();
		}
		
        private void comboCuentas_SelectedIndexChanged(object sender, EventArgs e)
		{
			CargaGrilla();
		}
		
        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			NuevoRegistro();
		}
		
        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			EditarRegistro();
		}
		
        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			EliminarRegistro();
		}
		
        private void toolNuevo_Click(object sender, EventArgs e)
		{
			NuevoRegistro();
		}
		
        private void toolEditar_Click(object sender, EventArgs e)
		{
			EditarRegistro();
		}
		
        private void toolEliminar_Click(object sender, EventArgs e)
		{
			EliminarRegistro();
		}
		
        private void toolCancelar_Click(object sender, EventArgs e)
		{
			CancelarAccion();
		}
		
        private void toolGrabar_Click(object sender, EventArgs e)
		{
			GrabarRegistro();
		}
		
        private void tabControlAsocia_SelectedIndexChanged(object sender, EventArgs e)
		{
			CambioTabPage();
		}
		
        private void gridAsociacion_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			EditarRegistro();
		}
		
        private void comboGrupo_SelectedIndexChanged(object sender, EventArgs e)
		{
			CambiaGrupo();
		}
		
        private void comboConcepto_SelectedIndexChanged(object sender, EventArgs e)
		{
			CambiaConcepto();
		}
		
        private void comboCuenta_SelectedIndexChanged(object sender, EventArgs e)
		{
			CambiaCuenta();
		}

        private void toolSalir_Click(object sender, EventArgs e)
		{
			CierraFormulario();
		}

        private void toolStripButtonReplicarPlantilla_Click(object sender, EventArgs e)
        {
            LanzaFormularioCopiaPlantilla();
        }

		//------------------------------------------------------------------------------------------------------
		//			Metodo privados
		//------------------------------------------------------------------------------------------------------
		private void ConfiguracionFormulario()
		{
			comboGrupos.DropDownStyle = ComboBoxStyle.DropDownList;
			comboConceptos.DropDownStyle = ComboBoxStyle.DropDownList;
			comboCuentas.DropDownStyle = ComboBoxStyle.DropDownList;
			//
			comboGrupo.DropDownStyle = ComboBoxStyle.DropDownList;
			comboConcepto.DropDownStyle = ComboBoxStyle.DropDownList;
			comboCuenta.DropDownStyle = ComboBoxStyle.DropDownList;

			gridAsociacion.Columns["colIdRegistro"].Visible = Properties.Settings.Default.usrMuestraColumnasOcultas;
			textRegistro.Visible = Properties.Settings.Default.usrMuestraCamposOcultos;
			textGrupo.Visible = Properties.Settings.Default.usrMuestraCamposOcultos;
			textConcepto.Visible = Properties.Settings.Default.usrMuestraCamposOcultos;
			textCuenta.Visible = Properties.Settings.Default.usrMuestraCamposOcultos;

			MisFunciones.ConfiguraToolBar(toolBarra);

		}
		private void CargaFormulario()
		{
			CargaComboGrupos();
			CargaComboConceptos();
			CargaComboCuentas();
			//
			CambiaEstadoBotonera(true);
			iAccion = (int)CFG.ToolAcciones.Nada;
			//
			gridAsociacion.ContextMenuStrip = contextMenuStrip1;
			//
			CargaGrilla();
		}
		private void CargaComboGrupos()
		{
			BOGrupos oBO = new BOGrupos();
			List<DTOGrupos> lGrupos = new List<DTOGrupos>();
			lGrupos = oBO.ConsultaGrupos();
			// Agregar opcion "seleccionar"
			DTOGrupos oGrupos = new DTOGrupos();
			oGrupos.Codigo = "";
			oGrupos.Descripcion = "<Seleccione Grupo>";
			lGrupos.Add(oGrupos);
			// Ordenamos las descripciones
			lGrupos.Sort(delegate(DTOGrupos l1, DTOGrupos l2) { return l1.Combo.CompareTo(l2.Combo); });
			// Asignamos la lista
			comboGrupos.DisplayMember = "Combo";
			comboGrupos.ValueMember = "Codigo";
			comboGrupos.DataSource = lGrupos;
			//
			List<DTOGrupos> lGrupos2 = new List<DTOGrupos>(lGrupos);
			comboGrupo.DisplayMember = "Combo";
			comboGrupo.ValueMember = "Codigo";
			comboGrupo.DataSource = lGrupos2;		
		}
		private void CargaComboConceptos()
		{
			BOConceptos oBO = new  BOConceptos();
			List<DTOConceptos> lConceptos = new List<DTOConceptos>();
			lConceptos = oBO.ConsultaConceptos();
			// Agregar opcion "seleccionar"
			DTOConceptos oConceptos = new DTOConceptos();
			oConceptos.Codigo = "";
			oConceptos.Descripcion = "<Seleccione Concepto>";
			lConceptos.Add(oConceptos);
			// Ordenamos las descripciones
			lConceptos.Sort(delegate(DTOConceptos l1, DTOConceptos l2) { return l1.Combo.CompareTo(l2.Combo); });
			// Asignamos la lista
			comboConceptos.DisplayMember = "Combo";
			comboConceptos.ValueMember = "Codigo";
			comboConceptos.DataSource = lConceptos;
			//
			List<DTOConceptos> lConceptos2 = new List<DTOConceptos>(lConceptos);
			comboConcepto.DisplayMember = "Combo";
			comboConcepto.ValueMember = "Codigo";
			comboConcepto.DataSource = lConceptos2;
		}
		private void CargaComboCuentas()
		{
			BOMaestroCuentas oBO = new BOMaestroCuentas();
			List<DTOMaestroCuentas> lCuentas = new List<DTOMaestroCuentas>();
			lCuentas = oBO.ConsultaMaestroCuentas();
			// Agregar opcion "seleccionar"
			DTOMaestroCuentas oCuentas = new DTOMaestroCuentas();
			oCuentas.idCuenta = "";
			oCuentas.Descripcion = "<Seleccione Cuenta>";
			lCuentas.Add(oCuentas);
			// Ordenamos las descripciones
			lCuentas.Sort(delegate(DTOMaestroCuentas l1, DTOMaestroCuentas l2) { return l1.Combo.CompareTo(l2.Combo); });
			// Asignamos la lista
			comboCuentas.DisplayMember = "Combo";
			comboCuentas.ValueMember = "idCuenta";
			comboCuentas.DataSource = lCuentas;
			//
			List<DTOMaestroCuentas> lCuentas2 = new List<DTOMaestroCuentas>(lCuentas);
			comboCuenta.DisplayMember = "Combo";
			comboCuenta.ValueMember = "idCuenta";
			comboCuenta.DataSource = lCuentas2;
		}
		private void CargaGrilla()
		{
			try
			{
				gridAsociacion.Rows.Clear();
				if (comboGrupos.Items.Count > 0 && comboConceptos.Items.Count > 0 && comboCuentas.Items.Count > 0)
				{
					List<DTOAsociacionGrupos> lDTO = new List<DTOAsociacionGrupos>();
					BOAsociacionGrupo oBO = new BOAsociacionGrupo();
					string p1 = comboGrupos.SelectedValue.ToString();
					string p2 = comboConceptos.SelectedValue.ToString();
					string p3 = comboCuentas.SelectedValue.ToString();
					lDTO = oBO.ConsultaAsociacion(p1, p2, p3);
					foreach (DTOAsociacionGrupos oDTO in lDTO)
					{
						gridAsociacion.Rows.Add();
						gridAsociacion.Rows[gridAsociacion.Rows.Count - 1].Cells["colIdRegistro"].Value = oDTO.IdRegistro.ToString();
						gridAsociacion.Rows[gridAsociacion.Rows.Count - 1].Cells["colIdGrupo"].Value = oDTO.IdGrupo.ToString();
						gridAsociacion.Rows[gridAsociacion.Rows.Count - 1].Cells["colIdConcepto"].Value = oDTO.IdConcepto.ToString();
						gridAsociacion.Rows[gridAsociacion.Rows.Count - 1].Cells["colIdCuenta"].Value = oDTO.IdCuenta.ToString();
						gridAsociacion.Rows[gridAsociacion.Rows.Count - 1].Cells["colGrupoDesc"].Value = oDTO.DescripcionGrupo.ToString();
						gridAsociacion.Rows[gridAsociacion.Rows.Count - 1].Cells["colConceptoDesc"].Value = oDTO.DescripcionConcepto.ToString();
						gridAsociacion.Rows[gridAsociacion.Rows.Count - 1].Cells["colCuentaDesc"].Value = oDTO.DescripcionCuenta.ToString();
					}
				}
			}
			catch (Exception Ex)
			{
				hLog.msgFatal("Error : \n"  + Ex.Message);
			}
		}
		private void CambiaEstadoBotonera(Boolean bEstado)
		{
			toolNuevo.Enabled = bEstado;
			toolEditar.Enabled = bEstado;
			toolEliminar.Enabled = bEstado;
			toolCancelar.Enabled = !bEstado;
			toolGrabar.Enabled = !bEstado;
		}
		private void NuevoRegistro()
		{
			if (tabControlAsocia.SelectedTab != tabPageMantencion)
			{
				tabControlAsocia.SelectedTab = tabPageMantencion;
			}
			tabPageMantencion.Show();
			CambiaEstadoBotonera(false);
			iAccion = (int)CFG.ToolAcciones.Nuevo;

			comboGrupo.SelectedValue = comboGrupos.SelectedValue.ToString();
			comboConcepto.SelectedValue = comboConceptos.SelectedValue.ToString();
			comboCuenta.SelectedValue = comboCuenta.SelectedValue.ToString();
		}
		private void EditarRegistro()
		{
			if (gridAsociacion.Rows.Count > 0)
			{
				if (gridAsociacion.CurrentRow.Selected)
				{
					CambiaEstadoBotonera(false);
					iAccion = (int)CFG.ToolAcciones.Editar;
					tabControlAsocia.SelectedTab = tabPageMantencion;
					tabPageMantencion.Show();

					textRegistro.Text = gridAsociacion.Rows[gridAsociacion.CurrentCell.RowIndex].Cells["colIdRegistro"].Value.ToString();
					comboGrupo.SelectedValue = gridAsociacion.Rows[gridAsociacion.CurrentCell.RowIndex].Cells["colIdGrupo"].Value.ToString();
					comboConcepto.SelectedValue = gridAsociacion.Rows[gridAsociacion.CurrentCell.RowIndex].Cells["colIdConcepto"].Value.ToString();
					comboCuenta.SelectedValue = gridAsociacion.Rows[gridAsociacion.CurrentCell.RowIndex].Cells["colIdCuenta"].Value.ToString();
				}
			}
		}
		private void EliminarRegistro()
		{
			if (gridAsociacion.Rows.Count > 0)
			{
				if (gridAsociacion.CurrentRow.Selected)
				{
					if (NewConsolidado.Properties.Settings.Default.usrPreguntaEliminar)
					{
						DialogResult oDlg = MessageBox.Show("Desea eliminar el registro seleccionado", NewConsolidado.Properties.Settings.Default.appTituloAplicacion, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
						if (oDlg == DialogResult.No)
						{
							iAccion = (int)CFG.ToolAcciones.Eliminar;
							GrabarRegistro();
						}
						else
						{
							iAccion = (int)CFG.ToolAcciones.Eliminar;
							GrabarRegistro();
						}
					}
					else
					{
						iAccion = (int)CFG.ToolAcciones.Eliminar;
						GrabarRegistro();
					}
				}
			}
		}
		private void CancelarAccion()
		{
			CambiaEstadoBotonera(true);
			iAccion = (int)CFG.ToolAcciones.Nada;
		}
		private void GrabarRegistro()
		{
			switch (iAccion)
			{
				case (int)CFG.ToolAcciones.Nuevo:
					{
						if (comboGrupo.SelectedValue.ToString().Trim() == "")
						{
							hLog.msgError("Debe seleccionar un grupo antes de grabar");
							comboGrupo.Focus();
							return;
						}
						if (comboConcepto.SelectedValue.ToString().Trim() == "")
						{
							hLog.msgError("Debe seleccionar un concepto antes de grabar");
							comboConcepto.Focus();
							return;
						}
						if (comboCuenta.SelectedValue.ToString().Trim() == "")
						{
							hLog.msgError("Debe seleccionar una cuenta antes de grabar");
							comboCuenta.Focus();
							return;
						}

						BOAsociacionGrupo oBO = new BOAsociacionGrupo();
						DTOAsociacionGrupos oDTO = new DTOAsociacionGrupos();
						List<DTOAsociacionGrupos> lDTO = new List<DTOAsociacionGrupos>();
						lDTO = oBO.ConsultaAsociacion(textGrupo.Text.Trim(), textConcepto.Text.Trim(), textCuenta.Text.Trim());
						if (lDTO.Count == 0)
						{
							oDTO.IdGrupo = textGrupo.Text.Trim();
							oDTO.IdConcepto = textConcepto.Text.Trim();
							oDTO.IdCuenta = textCuenta.Text.Trim();
							lDTO.Add (oDTO);
							oBO.CrearAsociacion(lDTO);
						}
						else
						{
							hLog.msgError("Debe ingresar otros valores por que ya existe un registro con estos valores.");
							textGrupo.SelectAll();
							textGrupo.Focus();
						}
						break;
					}
				case (int)CFG.ToolAcciones.Editar:
					{
						if (comboGrupo.SelectedValue.ToString().Trim() == "")
						{
							hLog.msgError("Debe seleccionar un grupo antes de grabar");
							comboGrupo.Focus();
							return;
						}
						if (comboConcepto.SelectedValue.ToString().Trim() == "")
						{
							hLog.msgError("Debe seleccionar un concepto antes de grabar");
							comboConcepto.Focus();
							return;
						}
						if (comboCuenta.SelectedValue.ToString().Trim() == "")
						{
							hLog.msgError("Debe seleccionar una cuenta antes de grabar");
							comboCuenta.Focus();
							return;
						}

						BOAsociacionGrupo oBO = new BOAsociacionGrupo();
						List<DTOAsociacionGrupos> lDTO = new List<DTOAsociacionGrupos>();
						lDTO = oBO.ConsultaAsociacion(textRegistro.Text);
						if (lDTO.Count >= 1)
						{
							lDTO[0].IdRegistro = int.Parse(textRegistro.Text);
							lDTO[0].IdGrupo = textGrupo.Text.Trim();
							lDTO[0].IdConcepto = textConcepto.Text.Trim();
							lDTO[0].IdCuenta = textCuenta.Text.Trim();
							oBO.EditarAsociacion(lDTO);
						}
						else
						{
							hLog.msgError("No existe el registro a editar.");
							textGrupo.SelectAll();
							textGrupo.Focus();
						}
						break;
					}
				case (int)CFG.ToolAcciones.Eliminar:
					{
						BOAsociacionGrupo oBO = new BOAsociacionGrupo();
						List<DTOAsociacionGrupos> lDTO = new List<DTOAsociacionGrupos>();
						lDTO = oBO.ConsultaAsociacion(textRegistro.Text);
						if (lDTO.Count >= 1)
						{
							List<DTOAsociacionGrupos> lDTOE = new List<DTOAsociacionGrupos>();
							DTOAsociacionGrupos oDTOE = new DTOAsociacionGrupos();
							oDTOE.IdRegistro = int.Parse(gridAsociacion.Rows[gridAsociacion.CurrentCell.RowIndex].Cells["colIdRegistro"].Value.ToString());
							lDTOE.Add(oDTOE);
							oBO.EliminarAsociacion(lDTOE);
						}
						else
						{
							hLog.msgError("No existe el registro.");
							textGrupo.SelectAll();
							textGrupo.Focus();
						}
						break;
					}
				default:
					{
						hLog.Fatal("Mala clasificacion al {GrabarRegistro}");
						throw new SystemException("Mala clasificacion al {GrabarRegistro}");
						
					}
			}
			tabControlAsocia.SelectedTab = tabPageLista;
			tabPageLista.Show();
			CargaGrilla();
		}
		private void CambioTabPage()
		{
			if (tabControlAsocia.SelectedTab == tabPageLista)
			{
				CambiaEstadoBotonera(true);
                iAccion = (int)CFG.ToolAcciones.Nada;
			}
			else
			{
				CambiaEstadoBotonera(false);
				if (iAccion == (int)CFG.ToolAcciones.Nada)
				{
					//iAccion = (int)CFG.ToolAcciones.Nuevo;
					NuevoRegistro();
				}
			}
		}
		private void CambiaGrupo()
		{
			textGrupo.Text = comboGrupo.SelectedValue.ToString();
		}
		private void CambiaConcepto()
		{
			textConcepto.Text = comboConcepto.SelectedValue.ToString();
		}
		private void CambiaCuenta()
		{
			textCuenta.Text = comboCuenta.SelectedValue.ToString();
		}
		private void CierraFormulario()
		{
			this.Close();
		}

        private void LanzaFormularioCopiaPlantilla()
        {
            MantenedorAsociacionGruposConceptosCuentas_CopiarPlantilla oForm = new MantenedorAsociacionGruposConceptosCuentas_CopiarPlantilla();
            oForm.WindowState = FormWindowState.Normal;
            oForm.StartPosition = FormStartPosition.CenterParent;
            oForm.ShowDialog();
        }
    }
}
