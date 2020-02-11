using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using NewConsolidado.Controladores.Clases;
using NewConsolidado.Modelos.TransporteDatos;
using NewConsolidado.Controladores.ControladorNegocio;

namespace NewConsolidado.Vistas.Formularios
{
	public partial class MantenedorConceptos : Form
	{
		private MyLog4Net hLog = new MyLog4Net("MantenedorConceptos.Form");
		private int hiAccion = (int)CFG.ToolAcciones.Nada;

		public MantenedorConceptos()
		{
			InitializeComponent();

			this.Text = "Mantenedor de Conceptos";
			//
			ConfiguracionFormulario();
			//
		}
		private void MantenedorConceptos_Load(object sender, EventArgs e)
		{
			CargaConceptos();
		}

		private void toolSalir_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void toolNuevo_Click(object sender, EventArgs e)
		{
			BotonNuevo();
		}

		private void toolEditar_Click(object sender, EventArgs e)
		{
			BotonEditar();
		}

		private void toolEliminar_Click(object sender, EventArgs e)
		{
			BotonEliminar();
		}

		private void toolCancelar_Click(object sender, EventArgs e)
		{
			BotonCancelar();
		}

		private void toolGrabar_Click(object sender, EventArgs e)
		{
			BotonGrabar();
		}
		private void nueToolStripMenuItem_Click(object sender, EventArgs e)
		{
			BotonNuevo();
		}

		private void editarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			BotonEditar();
		}

		private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			BotonEliminar();
		}
		private void tabControlConceptos_SelectedIndexChanged(object sender, EventArgs e)
		{
			CambioTabPage();
		}
		private void gridConceptos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			BotonEditar();
		}
		//-----------------------------------------------------------------------------------------------------
		//				Metodo privados
		//-----------------------------------------------------------------------------------------------------
		private void ConfiguracionFormulario()
		{
			gridConceptos.Columns["colIdConcepto"].Visible = Properties.Settings.Default.usrMuestraColumnasOcultas;
			gridConceptos.Columns["colidtipo"].Visible = Properties.Settings.Default.usrMuestraColumnasOcultas;
            gridConceptos.Columns["colIdSuma"].Visible = Properties.Settings.Default.usrMuestraColumnasOcultas;

			textCodigo.MaxLength = 6;
			textDescripcion.MaxLength = 500;

			comboTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            comboSumaESF.DropDownStyle = ComboBoxStyle.DropDownList;

			textCodigo.TabIndex = 0;
			textDescripcion.TabIndex = 1;
			comboTipo.TabIndex = 3;
			numOrden.TabIndex = 4;

			MisFunciones.ConfiguraToolBar(toolBarra);

			try
			{
				Dictionary<int, string> aDic = new Dictionary<int, string> { 
				{-1, "<Seleccione Tipo>"},{ 0, "Activo" }, { 1, "Pasivo" }, { 2, "Resultado" } };
				comboTipo.DataSource = aDic.ToList();
				comboTipo.DisplayMember = "value";
				comboTipo.ValueMember = "key";

                Dictionary<int, string> aDic2 = new Dictionary<int, string> { 
				{-1, "<Seleccione Tipo>"},{ 0, "Sumar" }, { 1, "No Sumar" } };
                comboSumaESF.DataSource = aDic2.ToList();
                comboSumaESF.DisplayMember = "value";
                comboSumaESF.ValueMember = "key";

			}
			catch (Exception ex)
			{
                hLog.msgError("Se detecto un error \n\n[MantenedorConceptos][ConfiguracionFormulario]"+ex.Message);
			}
		}

		private void CargaConceptos()
		{
            try
            {
                gridConceptos.Rows.Clear();
                List<DTOConceptos> lDTO = new List<DTOConceptos>();
                BOConceptos oBO = new BOConceptos();
                lDTO = oBO.ConsultaConceptos();
                foreach (DTOConceptos oDTO in lDTO)
                {
                    gridConceptos.Rows.Add();
                    gridConceptos.Rows[gridConceptos.Rows.Count - 1].Cells["colIdConcepto"].Value = oDTO.IdConcepto.ToString();
                    gridConceptos.Rows[gridConceptos.Rows.Count - 1].Cells["colCodigo"].Value = oDTO.Codigo.ToString();
                    gridConceptos.Rows[gridConceptos.Rows.Count - 1].Cells["colDescripcion"].Value = oDTO.Descripcion.ToString();
                    gridConceptos.Rows[gridConceptos.Rows.Count - 1].Cells["colTipo"].Value = CFG.aTipoConcepto[oDTO.Tipo].ToString();
                    gridConceptos.Rows[gridConceptos.Rows.Count - 1].Cells["colidtipo"].Value = oDTO.Tipo.ToString();
                    gridConceptos.Rows[gridConceptos.Rows.Count - 1].Cells["colOrden"].Value = oDTO.Orden.ToString();
                    gridConceptos.Rows[gridConceptos.Rows.Count - 1].Cells["colSumaESF"].Value = CFG.aFlagSumaESF[oDTO.FlagSumaESF].ToString();
                    gridConceptos.Rows[gridConceptos.Rows.Count - 1].Cells["colIdSuma"].Value = oDTO.FlagSumaESF.ToString();
                }
            }
            catch (Exception ex)
            {
                hLog.msgError("Se detecto un error \n\n[MantenedorConceptos][ConfiguracionFormulario]" + ex.Message);
            }
		}

		private void BotonNuevo()
		{
			if (tabControlConceptos.SelectedTab != tabPageMantencion)
			{
				tabControlConceptos.SelectedTab = tabPageMantencion;
			}
			tabPageMantencion.Show();
			CambiaEstadoBotonera(false);
			hiAccion = (int)CFG.ToolAcciones.Nuevo;

			textCodigo.Enabled = true;
			textCodigo.Text = "";
			textDescripcion.Text = "";
			//comboTipo.SelectedIndex = -1;
			comboTipo.SelectedValue = -1;
            comboSumaESF.SelectedValue = -1;
			numOrden.Value = 0;

			textCodigo.Focus();
		}
		private void BotonEditar()
		{
			if (gridConceptos.Rows.Count > 0)
			{
				if (gridConceptos.CurrentRow.Selected)
				{
					CambiaEstadoBotonera(false);
					hiAccion = (int)CFG.ToolAcciones.Editar;
					tabControlConceptos.SelectedTab = tabPageMantencion;
					tabPageMantencion.Show();

					textCodigo.Enabled = false;
					textCodigo.Text = gridConceptos.Rows[gridConceptos.CurrentCell.RowIndex].Cells["colCodigo"].Value.ToString().Trim();
					textDescripcion.Text = gridConceptos.Rows[gridConceptos.CurrentCell.RowIndex].Cells["colDescripcion"].Value.ToString().Trim();
					comboTipo.SelectedValue = int.Parse(gridConceptos.Rows[gridConceptos.CurrentCell.RowIndex].Cells["colidTipo"].Value.ToString().Trim());
					numOrden.Value = int.Parse(gridConceptos.Rows[gridConceptos.CurrentCell.RowIndex].Cells["colOrden"].Value.ToString().Trim());
                    comboSumaESF.SelectedValue = int.Parse(gridConceptos.Rows[gridConceptos.CurrentCell.RowIndex].Cells["colIdSuma"].Value.ToString().Trim());

					textCodigo.SelectAll();
					textCodigo.Focus();
				}
			}
		}
		private void BotonEliminar()
		{
			if (gridConceptos.Rows.Count > 0)
			{
				if (gridConceptos.CurrentRow.Selected)
				{
					if (NewConsolidado.Properties.Settings.Default.usrPreguntaEliminar)
					{
						DialogResult oDlg = MessageBox.Show("Desea eliminar el registro seleccionado", NewConsolidado.Properties.Settings.Default.appTituloAplicacion, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
						if (oDlg == DialogResult.No)
						{
							hiAccion = (int)CFG.ToolAcciones.Nada;
						}
						else
						{
							hiAccion = (int)CFG.ToolAcciones.Eliminar;
							textCodigo.Text = gridConceptos.Rows[gridConceptos.CurrentCell.RowIndex].Cells["colCodigo"].Value.ToString().Trim();
							BotonGrabar();
						}
					}
					else
					{
						hiAccion = (int)CFG.ToolAcciones.Eliminar;
						textCodigo.Text = gridConceptos.Rows[gridConceptos.CurrentCell.RowIndex].Cells["colCodigo"].Value.ToString().Trim();
						BotonGrabar();
					}
				}
			}
		}
		private void BotonCancelar()
		{
			CambiaEstadoBotonera(true);
			hiAccion = (int)CFG.ToolAcciones.Nada;

			tabControlConceptos.SelectedTab = tabPageLista;

		}
		private void BotonGrabar()
		{
			try
			{
				DTOConceptos oDTO = new DTOConceptos();
				BOConceptos oBO = new BOConceptos();

				switch (hiAccion)
				{
					case (int)CFG.ToolAcciones.Nuevo:
						{
							if (ValidarCampos())
							{
								oDTO.Codigo = textCodigo.Text;
								oDTO.Descripcion = textDescripcion.Text;
								oDTO.Tipo = int.Parse(comboTipo.SelectedValue.ToString());
								oDTO.Orden = int.Parse(numOrden.Value.ToString());
                                oDTO.FlagSumaESF = int.Parse(comboSumaESF.SelectedValue.ToString());
								oBO.GrabarConcepto(hiAccion, oDTO);
							}
							else
							{
								return;
							}
							break;
						}
					case (int)CFG.ToolAcciones.Editar:
						{
							if (ValidarCampos())
							{
								oDTO.Codigo = textCodigo.Text;
								oDTO.Descripcion = textDescripcion.Text;
								oDTO.Tipo = int.Parse(comboTipo.SelectedValue.ToString());
								oDTO.Orden = int.Parse(numOrden.Value.ToString());
                                oDTO.FlagSumaESF = int.Parse(comboSumaESF.SelectedValue.ToString());
								oBO.GrabarConcepto(hiAccion, oDTO);
							}
							else
							{
								return;
							}
							break;
						}
					case (int)CFG.ToolAcciones.Eliminar:
						{
							oDTO.Codigo = textCodigo.Text;
							oBO.GrabarConcepto(hiAccion, oDTO);

							break;
						}
					default:
						{
							hLog.Fatal("Mala clasificacion al {BotonGrabar}");
							throw new SystemException("Mala clasificacion al {BotonGrabar}");
							
						}
				}
				tabControlConceptos.SelectedTab = tabPageLista;
				tabPageLista.Show();
				CargaConceptos();
				hiAccion = (int)CFG.ToolAcciones.Nada;
			}
			catch (Exception Ex)
			{
				hLog.msgError(Ex.Message);
			}
		}
		private void CambioTabPage()
		{
			if (tabControlConceptos.SelectedTab == tabPageLista)
			{
				CambiaEstadoBotonera(true);
			}
			else
			{
				CambiaEstadoBotonera(false);
				if (hiAccion == (int)CFG.ToolAcciones.Nada)
				{
					BotonNuevo();
				}
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
		private Boolean ValidarCampos()
		{
			if (textCodigo.Text.Trim() == "")
			{
				hLog.msgError("Debe ingresar un código para el concepto");
				textCodigo.SelectAll();
				textCodigo.Focus();
				return false;
			}

			if (textDescripcion.Text.Trim() == "")
			{
				hLog.msgError("Debe ingresar una descripción para el concepto");
				textDescripcion.SelectAll();
				textDescripcion.Focus();
				return false;
			}

			if (comboTipo.SelectedValue.ToString() == "-1")
			{
				hLog.msgError("Debe seleccionar un tipo de concepto");
				comboTipo.DroppedDown = true;
				comboTipo.Focus();
				return false;
			}

            if (comboSumaESF.SelectedValue.ToString() == "-1")
            {
                hLog.msgError("Debe seleccionar un el manejo del concepto para el reporte ESF");
                comboSumaESF.DroppedDown = true;
                comboSumaESF.Focus();
                return false;
            }

            return true;
		}
	}
}
