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
	public partial class MantenedorMaestroCuentasContables : Form
	{
		private MyLog4Net hLog = new MyLog4Net("MantenedorMaestroCuentasContables.Form");
		private int hiAccion = (int)CFG.ToolAcciones.Nada;
	
		public MantenedorMaestroCuentasContables()
		{
			InitializeComponent();
			this.Text = "Mantenedor Maestro Cuentas Contables";
			ConfigurarFormulario();

		}
		private void MantenedorMaestroCuentasContables_Load(object sender, EventArgs e)
		{
			CargaCuentasContables();
		}

		private void toolSalir_Click(object sender, EventArgs e)
		{
			BotonSalir();
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

		private void gridMaestroCuentas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			BotonEditar();
		}

		private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
		{
			CambioTabPage();
		}
		private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			BotonNuevo();
		}

		private void editarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			BotonEditar();
		}

		private void EliminarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			BotonEliminar();
		}
		//-----------------------------------------------------------------------------------------------------
		//				Metodo privados
		//-----------------------------------------------------------------------------------------------------
		private void ConfigurarFormulario()
		{
			textCodigo.MaxLength = 8;
			textDescripcion.MaxLength = 200;
			textTipo.MaxLength = 2;
			textCodigo.Enabled = false;

			comboOrigen.DropDownStyle = ComboBoxStyle.DropDownList;
			comboOrigen.Enabled = false;

			try
			{
				Dictionary<int, string> aDic = new Dictionary<int, string> { 
				{-1, "<Seleccione Tipo>"},{ 0, "Dynamics" }, { 1, "Manual" } };
				comboOrigen.DataSource = aDic.ToList();
				comboOrigen.DisplayMember = "value";
				comboOrigen.ValueMember = "key";
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

			MisFunciones.ConfiguraToolBar(toolBarra);

		}
		private void CargaCuentasContables()
		{

			gridMaestroCuentas.Rows.Clear();

			List<DTOMaestroCuentas> lDTO = new List<DTOMaestroCuentas>();
			BOMaestroCuentas BO = new BOMaestroCuentas();
			lDTO = BO.ConsultaMaestroCuentas();

			foreach (DTOMaestroCuentas DTO in lDTO)
			{
				gridMaestroCuentas.Rows.Add();
				gridMaestroCuentas.Rows[gridMaestroCuentas.Rows.Count - 1].Cells["colIdCuenta"].Value = DTO.idCuenta.ToString();
				gridMaestroCuentas.Rows[gridMaestroCuentas.Rows.Count - 1].Cells["colDescripcion"].Value = DTO.Descripcion;
				gridMaestroCuentas.Rows[gridMaestroCuentas.Rows.Count - 1].Cells["colTipo"].Value = DTO.Tipo.ToString();
				gridMaestroCuentas.Rows[gridMaestroCuentas.Rows.Count - 1].Cells["colOrden"].Value = DTO.Orden.ToString();
				gridMaestroCuentas.Rows[gridMaestroCuentas.Rows.Count - 1].Cells["colAjuste"].Value = CFG.aBool[DTO.SoloAjuste];
				gridMaestroCuentas.Rows[gridMaestroCuentas.Rows.Count - 1].Cells["colImprime"].Value = CFG.aBool[DTO.Imprime];
				gridMaestroCuentas.Rows[gridMaestroCuentas.Rows.Count - 1].Cells["colManual"].Value = CFG.aOrigenSaldo[DTO.IngresoManual];
				gridMaestroCuentas.Rows[gridMaestroCuentas.Rows.Count - 1].Cells["colPatrimonio"].Value = CFG.aBool[DTO.Patrimonio];
			}
		}
		private void BotonSalir()
		{
			this.Close();
		}
		private void BotonNuevo()
		{
			if (tabControlCuentas.SelectedTab != tabPageMantenedor)
			{
				tabControlCuentas.SelectedTab = tabPageMantenedor;
			}
			tabPageMantenedor.Show();
			CambiaEstadoBotonera(false);
			hiAccion = (int)CFG.ToolAcciones.Nuevo;

			textCodigo.Enabled = true;
			textCodigo.Text = "";
			textDescripcion.Text = "";
			comboOrigen.SelectedValue = (int)CFG.OrigenSaldo.Manual;
			numOrden.Value = 0;

			textCodigo.Focus();
		}
		private void BotonEditar()
		{
			if (gridMaestroCuentas.Rows.Count > 0)
			{
				if (gridMaestroCuentas.CurrentRow.Selected)
				{
					CambiaEstadoBotonera(false);
					hiAccion = (int)CFG.ToolAcciones.Editar;
					tabControlCuentas.SelectedTab = tabPageMantenedor;
					tabPageMantenedor.Show();

					textCodigo.Enabled = false;
					textCodigo.Text = gridMaestroCuentas.Rows[gridMaestroCuentas.CurrentCell.RowIndex].Cells["colIdCuenta"].Value.ToString().Trim();
					textDescripcion.Text = gridMaestroCuentas.Rows[gridMaestroCuentas.CurrentCell.RowIndex].Cells["colDescripcion"].Value.ToString().Trim();
					textTipo.Text = gridMaestroCuentas.Rows[gridMaestroCuentas.CurrentCell.RowIndex].Cells["colTipo"].Value.ToString().Trim();
					comboOrigen.SelectedValue = gridMaestroCuentas.Rows[gridMaestroCuentas.CurrentCell.RowIndex].Cells["colManual"].Value.ToString().Trim() == CFG.OrigenSaldo.Dynamics.ToString() ? (int)CFG.OrigenSaldo.Dynamics : (int)CFG.OrigenSaldo.Manual;
					numOrden.Value = int.Parse(gridMaestroCuentas.Rows[gridMaestroCuentas.CurrentCell.RowIndex].Cells["colOrden"].Value.ToString().Trim());
					checkAjuste.Checked = gridMaestroCuentas.Rows[gridMaestroCuentas.CurrentCell.RowIndex].Cells["colAjuste"].Value.ToString().Trim() == CFG.SiNo.Si.ToString() ? true : false;
					checkImprime.Checked = gridMaestroCuentas.Rows[gridMaestroCuentas.CurrentCell.RowIndex].Cells["colImprime"].Value.ToString().Trim() == CFG.SiNo.Si.ToString() ? true : false;
					checkPatrimonio.Checked = gridMaestroCuentas.Rows[gridMaestroCuentas.CurrentCell.RowIndex].Cells["colPatrimonio"].Value.ToString().Trim() == CFG.SiNo.Si.ToString() ? true : false;

					textCodigo.SelectAll();
					textCodigo.Focus();
				}
			}
		}
		private void BotonEliminar()
		{
			if (gridMaestroCuentas.Rows.Count > 0)
			{
				if (gridMaestroCuentas.CurrentRow.Selected)
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
							textCodigo.Text = gridMaestroCuentas.Rows[gridMaestroCuentas.CurrentCell.RowIndex].Cells["colIdCuenta"].Value.ToString().Trim();
							BotonGrabar();
						}
					}
					else
					{
						hiAccion = (int)CFG.ToolAcciones.Eliminar;
						textCodigo.Text = gridMaestroCuentas.Rows[gridMaestroCuentas.CurrentCell.RowIndex].Cells["colIdCuenta"].Value.ToString().Trim();
						BotonGrabar();
					}
				}
			}
		}
		private void BotonGrabar()
		{
			try
			{
				DTOMaestroCuentas oDTO = new DTOMaestroCuentas();
				BOMaestroCuentas oBO = new BOMaestroCuentas();

				switch (hiAccion)
				{
					case (int)CFG.ToolAcciones.Nuevo:
						{
							if (ValidarCampos())
							{
								oDTO.idCuenta = textCodigo.Text;
								oDTO.Descripcion = textDescripcion.Text;
								oDTO.Tipo = textTipo.Text;
								oDTO.Orden = int.Parse(numOrden.Value.ToString());
								oDTO.IngresoManual = int.Parse(comboOrigen.SelectedValue.ToString());
								oDTO.Imprime = checkImprime.Checked ? (int)CFG.SiNo.Si: (int)CFG.SiNo.No;
								oDTO.Patrimonio = checkPatrimonio.Checked ? (int)CFG.SiNo.Si: (int)CFG.SiNo.No;
								oDTO.SoloAjuste = checkAjuste.Checked ? (int)CFG.SiNo.Si: (int)CFG.SiNo.No;

								oBO.GrabarCuenta(hiAccion, oDTO);
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
								oDTO.idCuenta = textCodigo.Text;
								oDTO.Descripcion = textDescripcion.Text;
								oDTO.Tipo = textTipo.Text;
								oDTO.Orden = int.Parse(numOrden.Value.ToString());
								oDTO.IngresoManual = int.Parse(comboOrigen.SelectedValue.ToString());
								oDTO.Imprime = checkImprime.Checked ? (int)CFG.SiNo.Si : (int)CFG.SiNo.No;
								oDTO.Patrimonio = checkPatrimonio.Checked ? (int)CFG.SiNo.Si : (int)CFG.SiNo.No;
								oDTO.SoloAjuste = checkAjuste.Checked ? (int)CFG.SiNo.Si : (int)CFG.SiNo.No;

								oBO.GrabarCuenta(hiAccion, oDTO);
							}
							else
							{
								return;
							}
							break;
						}
					case (int)CFG.ToolAcciones.Eliminar:
						{
							oDTO.idCuenta = textCodigo.Text;
							oBO.GrabarCuenta(hiAccion, oDTO);

							break;
						}
					default:
						{
							hLog.Fatal("Mala clasificacion al {BotonGrabar}");
							throw new SystemException("Mala clasificacion al {BotonGrabar}");
							
						}
				}
				tabControlCuentas.SelectedTab = tabPageLista;
				tabPageLista.Show();
				CargaCuentasContables();
				hiAccion = (int)CFG.ToolAcciones.Nada;
			}
			catch (Exception Ex)
			{
				hLog.msgError(Ex.Message);
			}
		}
		private void BotonCancelar()
		{
			CambiaEstadoBotonera(true);
			hiAccion = (int)CFG.ToolAcciones.Nada;

			tabControlCuentas.SelectedTab = tabPageLista;
		}
		private void CambioTabPage()
		{
			if (tabControlCuentas.SelectedTab == tabPageLista)
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
				hLog.msgError("Debe ingresar un código para la cuenta");
				textCodigo.SelectAll();
				textCodigo.Focus();
				return false;
			}
			if (textDescripcion.Text.Trim() == "")
			{
				hLog.msgError("Debe ingresar una descripción para la Cuenta");
				textDescripcion.SelectAll();
				textDescripcion.Focus();
				return false;
			}
			if (textTipo.Text.Trim() == "")
			{
				hLog.msgError("Debe ingresar un Tipo de Cuenta");
				textTipo.SelectAll();
				textTipo.Focus();
				return false;
			}
			if (comboOrigen.SelectedValue.ToString() == "-1")
			{
				hLog.msgError("Debe seleccionar un Origen de Cuenta");
				comboOrigen.DroppedDown = true;
				comboOrigen.Focus();
				return false;
			}
			return true;
		}
	}
}
