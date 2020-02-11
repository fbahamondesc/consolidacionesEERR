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
	public partial class MantenedorCompanias : Form
	{
		private MyLog4Net hLog = new MyLog4Net("MantenedorCompanias.Form");
		private int hiAccion = (int)CFG.ToolAcciones.Nada ;

		public MantenedorCompanias()
		{
			InitializeComponent();

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

		private void MantenedorCompanias_Load(object sender, EventArgs e)
		{
			CargaFormulario();
		}
		private void tabControlCompania_SelectedIndexChanged(object sender, EventArgs e)
		{
			CambioTabPage();
		}
		private void gridCompanias_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			BotonEditar();
		}
		private void nuevaCompañiaToolStripMenuItem_Click(object sender, EventArgs e)
		{
			BotonNuevo();
		}

		private void editarCompañiaToolStripMenuItem_Click(object sender, EventArgs e)
		{
			BotonEditar();
		}

		private void eliminarCompañiaToolStripMenuItem_Click(object sender, EventArgs e)
		{
			BotonEliminar();
		}
	
		//-----------------------------------------------------------------------------------------------------
		//				Metodo privados
		//-----------------------------------------------------------------------------------------------------
		private void ConfiguracionFormulario()
		{
			gridCompanias.Columns["colIdOrigen"].Visible = Properties.Settings.Default.usrMuestraColumnasOcultas;
			gridCompanias.Columns["colIdVigencia"].Visible = Properties.Settings.Default.usrMuestraColumnasOcultas;

			textIdCompania.MaxLength = 10;
			textNombre.MaxLength = 100;
			textRUT.MaxLength = 10;
			textBaseDatos.MaxLength = 100;
			textCuentaEjercicio.MaxLength = 10;
			textCuentaAcumulado.MaxLength = 10;

			textIdCompania.TabIndex = 0;
			textNombre.TabIndex = 1;
			textRUT.TabIndex = 2;
			textBaseDatos.TabIndex = 3;
			textCuentaEjercicio.TabIndex = 4;
			textCuentaAcumulado.TabIndex = 5;
			radioDynamics.TabIndex = 6;
			radioManual.TabIndex = 7;

			radioDynamics.Enabled= false;
			radioManual.Enabled= false;

			checkVigente.Checked = true;

			MisFunciones.ConfiguraToolBar(toolBarra);
		}

		private void CargaFormulario()
		{
			CargaCompanias();
		}

		private void CargaCompanias()
		{
			gridCompanias.Rows.Clear();
			List<DTOCompanias> lDTO = new List<DTOCompanias>();
			BOCompanias oBO = new BOCompanias();
			lDTO = oBO.ConsultaCompanias();
			foreach (DTOCompanias oDTO in lDTO)
			{
				gridCompanias.Rows.Add();
				gridCompanias.Rows[gridCompanias.Rows.Count - 1].Cells["colIdCompania"].Value = oDTO.IdCompania.ToString();
				gridCompanias.Rows[gridCompanias.Rows.Count - 1].Cells["colNombre"].Value = oDTO.Nombre.ToString();
				gridCompanias.Rows[gridCompanias.Rows.Count - 1].Cells["colRut"].Value = oDTO.RUT.ToString();
				gridCompanias.Rows[gridCompanias.Rows.Count - 1].Cells["colBaseDatos"].Value = oDTO.BaseDatos.ToString();
				gridCompanias.Rows[gridCompanias.Rows.Count - 1].Cells["colCuentaEjercicio"].Value = oDTO.CuentaEjercicio.ToString();
				gridCompanias.Rows[gridCompanias.Rows.Count - 1].Cells["colCuentaAcumulado"].Value = oDTO.CuentaAcumulado.ToString();
				gridCompanias.Rows[gridCompanias.Rows.Count - 1].Cells["colOrigen"].Value = CFG.aOrigenEmpresa[int.Parse(oDTO.Origen.ToString())];
				gridCompanias.Rows[gridCompanias.Rows.Count - 1].Cells["colVigencia"].Value = CFG.aEstadoCompania[int.Parse(oDTO.Vigencia.ToString())];
				gridCompanias.Rows[gridCompanias.Rows.Count - 1].Cells["colidOrigen"].Value = oDTO.Origen.ToString();
				gridCompanias.Rows[gridCompanias.Rows.Count - 1].Cells["colidVigencia"].Value = oDTO.Vigencia.ToString();
			}
		}
		private void BotonNuevo()
		{
			if (tabControlCompania.SelectedTab != tabPageMantencion)
			{
				tabControlCompania.SelectedTab = tabPageMantencion;
			}
			tabPageMantencion.Show();
			CambiaEstadoBotonera(false);
			hiAccion = (int)CFG.ToolAcciones.Nuevo;

			textIdCompania.Text = "";
			textIdCompania.Enabled = true;
			textNombre.Text = "";
			textRUT.Text = "";
			textBaseDatos.Text = "";
			textCuentaEjercicio.Text = "";
			textCuentaAcumulado.Text = "";
			radioDynamics.Checked = false;
			radioManual.Checked = true;
			//
			textIdCompania.Focus();
		}
		private void BotonEditar()
		{
			if (gridCompanias.Rows.Count > 0)
			{
				if (gridCompanias.CurrentRow.Selected)
				{
					CambiaEstadoBotonera(false);
					hiAccion = (int)CFG.ToolAcciones.Editar;
					tabControlCompania.SelectedTab = tabPageMantencion;
					tabPageMantencion.Show();

					textIdCompania.Text = gridCompanias.Rows[gridCompanias.CurrentCell.RowIndex].Cells["colIdCompania"].Value.ToString().Trim();
					textIdCompania.Enabled = false;
					textNombre.Text = gridCompanias.Rows[gridCompanias.CurrentCell.RowIndex].Cells["colNombre"].Value.ToString().Trim();
					textRUT.Text = gridCompanias.Rows[gridCompanias.CurrentCell.RowIndex].Cells["colRut"].Value.ToString().Trim();
					textBaseDatos.Text = gridCompanias.Rows[gridCompanias.CurrentCell.RowIndex].Cells["colBaseDatos"].Value.ToString().Trim();
					textCuentaEjercicio.Text = gridCompanias.Rows[gridCompanias.CurrentCell.RowIndex].Cells["colCuentaEjercicio"].Value.ToString().Trim();
					textCuentaAcumulado.Text = gridCompanias.Rows[gridCompanias.CurrentCell.RowIndex].Cells["colCuentaAcumulado"].Value.ToString().Trim();
					radioDynamics.Checked = int.Parse(gridCompanias.Rows[gridCompanias.CurrentCell.RowIndex].Cells["colidOrigen"].Value.ToString()) == (int)CFG.OrigenCompania.Dynamics ? true: false;
					radioManual.Checked = int.Parse(gridCompanias.Rows[gridCompanias.CurrentCell.RowIndex].Cells["colidOrigen"].Value.ToString()) == (int)CFG.OrigenCompania.Dynamics ? false : true;
					checkVigente.Checked = int.Parse(gridCompanias.Rows[gridCompanias.CurrentCell.RowIndex].Cells["colidVigencia"].Value.ToString()) == (int)CFG.EstadoCompania.Vigente ? true : false;

				}
			}
		}
		private void BotonEliminar()
		{
			if (gridCompanias.Rows.Count > 0)
			{
				if (gridCompanias.CurrentRow.Selected)
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
							textIdCompania.Text = gridCompanias.Rows[gridCompanias.CurrentCell.RowIndex].Cells["colIdCompania"].Value.ToString().Trim();
							BotonGrabar();
						}
					}
					else
					{
						hiAccion = (int)CFG.ToolAcciones.Eliminar;
						textIdCompania.Text = gridCompanias.Rows[gridCompanias.CurrentCell.RowIndex].Cells["colIdCompania"].Value.ToString().Trim();
						BotonGrabar();
					}
				}
			}
		}
		private void BotonCancelar()
		{
			CambiaEstadoBotonera(true);
			hiAccion = (int)CFG.ToolAcciones.Nada;

			tabControlCompania.SelectedTab = tabPageLista;
		}
		private void CambiaEstadoBotonera(Boolean bEstado)
		{
			toolNuevo.Enabled = bEstado;
			toolEditar.Enabled = bEstado;
			toolEliminar.Enabled = bEstado;
			toolCancelar.Enabled = !bEstado;
			toolGrabar.Enabled = !bEstado;
		}
		private void CambioTabPage()
		{
			if (tabControlCompania.SelectedTab == tabPageLista)
			{
				CambiaEstadoBotonera(true);
			}
			else
			{
				CambiaEstadoBotonera(false);
				if (hiAccion == (int)CFG.ToolAcciones.Nada)
				{
					//iAccion = (int)CFG.ToolAcciones.Nuevo;
					BotonNuevo();
				}
			}
		}
		private void BotonGrabar()
		{
			try
			{
				DTOCompanias oDTO = new DTOCompanias();
				BOCompanias oBO = new BOCompanias();
				switch (hiAccion)
				{
					case (int)CFG.ToolAcciones.Nuevo:
						{
							if (ValidarCampos())
							{
								oDTO.IdCompania = textIdCompania.Text;
								oDTO.Nombre = textNombre.Text.Trim();
								oDTO.RUT = textRUT.Text.Trim();
								oDTO.BaseDatos = textBaseDatos.Text.Trim();
								oDTO.CuentaEjercicio = textCuentaEjercicio.Text.Trim();
								oDTO.CuentaAcumulado = textCuentaAcumulado.Text.Trim();
								oDTO.Origen = radioDynamics.Checked ? (int)CFG.OrigenCompania.Dynamics : (int)CFG.OrigenCompania.Manual;
								oDTO.Vigencia = checkVigente.Checked ? (int)CFG.EstadoCompania.Vigente : (int)CFG.EstadoCompania.Inactivo;
								//
								oBO.GrabarCompania(hiAccion, oDTO);
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
								oDTO.IdCompania = textIdCompania.Text;
								oDTO.Nombre = textNombre.Text.Trim();
								oDTO.RUT = textRUT.Text.Trim();
								oDTO.BaseDatos = textBaseDatos.Text.Trim();
								oDTO.CuentaEjercicio = textCuentaEjercicio.Text.Trim();
								oDTO.CuentaAcumulado = textCuentaAcumulado.Text.Trim();
								oDTO.Origen = radioDynamics.Checked ? (int)CFG.OrigenCompania.Dynamics : (int)CFG.OrigenCompania.Manual;
								oDTO.Vigencia = checkVigente.Checked ? (int)CFG.EstadoCompania.Vigente : (int)CFG.EstadoCompania.Inactivo;
								//
								oBO.GrabarCompania(hiAccion, oDTO);
							}
							break;
						}
					case (int)CFG.ToolAcciones.Eliminar:
						{
							oDTO.IdCompania = textIdCompania.Text;
							oBO.GrabarCompania(hiAccion, oDTO);
							break;						
						}
					default:
						{
							hLog.Fatal("Mala clasificacion al {BotonGrabar}");
							throw new SystemException("Mala clasificacion al {BotonGrabar}");
							
						}
				}
				tabControlCompania.SelectedTab = tabPageLista;
				tabPageLista.Show();
				CargaCompanias();
				hiAccion = (int)CFG.ToolAcciones.Nada;
			}
			catch (Exception ex)
			{
				hLog.Fatal(ex.Message);
				hLog.msgError(ex.Message);
			}
		}

		private Boolean ValidarCampos()
		{
			if (hiAccion == (int)CFG.ToolAcciones.Nuevo)
			{
				BOCompanias oBo = new BOCompanias();
				List<DTOCompanias> lDTO = new List<DTOCompanias>();
				lDTO = oBo.ConsultaCompanias(textIdCompania.Text.Trim());
				if (lDTO.Count > 0)
				{
					hLog.msgError("El codigo ingresado ya existe, favor de intentar con un nuevo código");
					textIdCompania.SelectAll();
					textIdCompania.Focus();
					return false;
				}
			}
			if (textNombre.Text.Trim() == "")
			{
				hLog.msgError("Debe ingresar un nombre para la compañia");
				textNombre.SelectAll();
				textNombre.Focus();
				return false;
			}
			if( radioDynamics.Checked && textRUT.Text.Trim() == "" )
			{
				hLog.msgError("Debe ingresar el RUT de la Compañia");
				textRUT.SelectAll();
				textRUT.Focus();
				return false;
			}
			if ( radioDynamics.Checked && textBaseDatos.Text.Trim() == "")
			{
				hLog.msgError("Debe ingresar la Base de Datos de la compañia");
				textBaseDatos.SelectAll();
				textBaseDatos.Focus();
				return false;
			}
			if (textCuentaEjercicio.Text.Trim() == "")
			{
				hLog.msgError("Debe ingresar la Cuenta de Ejercicio de la compañia");
				textCuentaEjercicio.SelectAll();
				textCuentaEjercicio.Focus();
				return false;
			}
			if (textCuentaAcumulado.Text.Trim() == "")
			{
				hLog.msgError("Debe ingresar la Cuenta Acumulado de la Compañia");
				textCuentaAcumulado.SelectAll();
				textCuentaAcumulado.Focus();
				return false;
			}

			return true;
		}
	}
}
