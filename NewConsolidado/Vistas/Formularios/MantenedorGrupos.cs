using System;
using System.Collections;
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
	public partial class MantenedorGrupos : Form
	{
		private MyLog4Net hLog = new MyLog4Net("MantenedorGrupos.Form");
		private int hiAccion = (int)CFG.ToolAcciones.Nada;

		public MantenedorGrupos()
		{
			InitializeComponent();
			//
			this.Text = "Mantenedor de Grupos";
			//
			ConfiguracionFormulario();
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

		private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
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
		private void tabControlGrupos_SelectedIndexChanged(object sender, EventArgs e)
		{
			CambioTabPage();
		}
		private void MantenedorGrupos_Load(object sender, EventArgs e)
		{
			CargaGrupos();

			CambiaEstadoBotonera(true);
		}
		private void gridGrupos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			BotonEditar();
		}
		//-----------------------------------------------------------------------------------------------------
		//				Metodo privados
		//-----------------------------------------------------------------------------------------------------
		private void ConfiguracionFormulario()
		{
			gridGrupos.Columns["colIdGrupo"].Visible = Properties.Settings.Default.usrMuestraColumnasOcultas;
			gridGrupos.Columns["colidTipo"].Visible = Properties.Settings.Default.usrMuestraColumnasOcultas;
			
			textCodigo.MaxLength = 3;
			textDescripcion.MaxLength = 200;

			comboTipo.DropDownStyle = ComboBoxStyle.DropDownList;

			textCodigo.TabIndex = 0;
			textDescripcion.TabIndex = 1;
			comboTipo.TabIndex = 2;
			numOrden.TabIndex = 3;
			try
			{
				Dictionary<int, string> aDic = new Dictionary<int, string> { 
				{-1, "<Seleccione Tipo>"},{ 0, "Activo" }, { 1, "Pasivo" }, { 2, "Resultado" } };
				comboTipo.DataSource = aDic.ToList();
				comboTipo.DisplayMember = "value";
				comboTipo.ValueMember = "key";
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

			MisFunciones.ConfiguraToolBar(toolBarra);

		}
		private void CargaGrupos()
		{
			gridGrupos.Rows.Clear();
			List<DTOGrupos> lDTO = new List<DTOGrupos>();
			BOGrupos oBO = new BOGrupos();
			lDTO = oBO.ConsultaGrupos();
			foreach (DTOGrupos oDTO in lDTO)
			{
				gridGrupos.Rows.Add();
				gridGrupos.Rows[gridGrupos.Rows.Count - 1].Cells["colIdGrupo"].Value = oDTO.IdGrupo.ToString();
				gridGrupos.Rows[gridGrupos.Rows.Count - 1].Cells["colCodigo"].Value = oDTO.Codigo.ToString();
				gridGrupos.Rows[gridGrupos.Rows.Count - 1].Cells["colDescripcion"].Value = oDTO.Descripcion.ToString();
				gridGrupos.Rows[gridGrupos.Rows.Count - 1].Cells["colTipo"].Value = CFG.aTipoGrupo[oDTO.Tipo].ToString();
				gridGrupos.Rows[gridGrupos.Rows.Count - 1].Cells["colidTipo"].Value = oDTO.Tipo.ToString();
				gridGrupos.Rows[gridGrupos.Rows.Count - 1].Cells["colOrden"].Value = oDTO.Orden.ToString();
			}
		}
		private void BotonNuevo()
		{
			if (tabControlGrupos.SelectedTab != tabPageMantencion)
			{
				tabControlGrupos.SelectedTab = tabPageMantencion;
			}
			tabPageMantencion.Show();
			CambiaEstadoBotonera(false);
			hiAccion = (int)CFG.ToolAcciones.Nuevo;

			textCodigo.Enabled = true;
			textCodigo.Text = "";
			textDescripcion.Text = "";
			//comboTipo.SelectedIndex = -1;
			comboTipo.SelectedValue = -1;
			numOrden.Value = 0;
		}
		private void BotonEditar()
		{
			if (gridGrupos.Rows.Count > 0)
			{
				if (gridGrupos.CurrentRow.Selected)
				{
					CambiaEstadoBotonera(false);
					hiAccion = (int)CFG.ToolAcciones.Editar;
					tabControlGrupos.SelectedTab = tabPageMantencion;
					tabPageMantencion.Show();

					textCodigo.Enabled = false;
					textCodigo.Text = gridGrupos.Rows[gridGrupos.CurrentCell.RowIndex].Cells["colCodigo"].Value.ToString().Trim();
					textDescripcion.Text = gridGrupos.Rows[gridGrupos.CurrentCell.RowIndex].Cells["colDescripcion"].Value.ToString().Trim();
					comboTipo.SelectedValue = int.Parse(gridGrupos.Rows[gridGrupos.CurrentCell.RowIndex].Cells["colidTipo"].Value.ToString().Trim());
					numOrden.Value = int.Parse(gridGrupos.Rows[gridGrupos.CurrentCell.RowIndex].Cells["colOrden"].Value.ToString().Trim());

					textCodigo.SelectAll();
					textCodigo.Focus();
				}
			}
		}
		private void BotonEliminar()
		{
			if (gridGrupos.Rows.Count > 0)
			{
				if (gridGrupos.CurrentRow.Selected)
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
							textCodigo.Text = gridGrupos.Rows[gridGrupos.CurrentCell.RowIndex].Cells["colCodigo"].Value.ToString().Trim();
							BotonGrabar();
						}
					}
					else
					{
						hiAccion = (int)CFG.ToolAcciones.Eliminar;
						textCodigo.Text = gridGrupos.Rows[gridGrupos.CurrentCell.RowIndex].Cells["colCodigo"].Value.ToString().Trim();
						BotonGrabar();
					}
				}
			}
		}
		private void BotonCancelar()
		{
			CambiaEstadoBotonera(true);
			hiAccion = (int)CFG.ToolAcciones.Nada;

			tabControlGrupos.SelectedTab = tabPageLista;
		}
		private void BotonGrabar()
		{
			try
			{
				DTOGrupos oDTO = new DTOGrupos();
				BOGrupos oBO = new BOGrupos();

				switch (hiAccion)
				{
					case (int)CFG.ToolAcciones.Nuevo:
						{
							if (ValidarCampos())
							{
								oDTO.Codigo = textCodigo.Text;
								oDTO.Descripcion = textDescripcion.Text;
								oDTO.Tipo = int.Parse( comboTipo.SelectedValue.ToString());
								oDTO.Orden = int.Parse( numOrden.Value.ToString());

								oBO.GrabarGrupo(hiAccion, oDTO);
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

								oBO.GrabarGrupo(hiAccion, oDTO);
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
							oBO.GrabarGrupo(hiAccion, oDTO);

							break;
						}
					default:
						{
							hLog.Fatal("Mala clasificacion al {BotonGrabar}");
							throw new SystemException("Mala clasificacion al {BotonGrabar}");
						}
				}
				tabControlGrupos.SelectedTab = tabPageLista;
				tabPageLista.Show();
				CargaGrupos();
				hiAccion = (int)CFG.ToolAcciones.Nada;
			}
			catch (Exception Ex)
			{
				hLog.msgError(Ex.Message);
			}
		}
		private void CambioTabPage()
		{
			if (tabControlGrupos.SelectedTab == tabPageLista)
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
				hLog.msgError("Debe ingresar un código para el grupo");
				textCodigo.SelectAll();
				textCodigo.Focus();
				return false;
			}
			if (textDescripcion.Text.Trim() == "")
			{
				hLog.msgError("Debe ingresar una descripción para el grupo");
				textDescripcion.SelectAll();
				textDescripcion.Focus();
				return false;
			}
			if (comboTipo.SelectedValue.ToString() == "-1")
			{
				hLog.msgError("Debe seleccionar un tipo de grupo");
				comboTipo.DroppedDown = true;
				comboTipo.Focus();
				return false;
			}
			return true;
		}
	}
}
