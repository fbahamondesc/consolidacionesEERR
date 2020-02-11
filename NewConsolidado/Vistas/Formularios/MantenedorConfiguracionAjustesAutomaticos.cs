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
	public partial class MantenedorConfiguracionAjustesAutomaticos : Form
	{
		private MyLog4Net hLog = new MyLog4Net("MantenedorConfiguracionAjustesAutomaticos.Form");
		private int iAccion = (int)CFG.ToolAcciones.Nada;
	
		public MantenedorConfiguracionAjustesAutomaticos()
		{
			InitializeComponent();
			//
			ConfiguracionFormulario();
		}
		private void MantenedorConfiguracionAjustesAutomaticos_Load(object sender, EventArgs e)
		{
			CargaFormulario();
		}
		private void comboCompania_SelectedIndexChanged(object sender, EventArgs e)
		{
		}
		private void comboCompanias_SelectedIndexChanged(object sender, EventArgs e)
		{
			CargaGrilla();
		}
		private void toolSalir_Click(object sender, EventArgs e)
		{
			this.Close();
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
		private void gridConfiguracion_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			EditarRegistro();
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
		private void tabControlConfiguracion_SelectedIndexChanged(object sender, EventArgs e)
		{
			CambioTabPage();
		}
		private void comboCuentasOrigen_SelectedIndexChanged(object sender, EventArgs e)
		{
			CargaGrilla();
		}
		//-----------------------------------------------------------------------------------------------------
		//				Metodo privados
		//-----------------------------------------------------------------------------------------------------
		private void ConfiguracionFormulario()
		{
			comboCompanias.DropDownStyle = ComboBoxStyle.DropDownList;
			comboCompania.DropDownStyle = ComboBoxStyle.DropDownList;
			comboCuentasOrigen.DropDownStyle = ComboBoxStyle.DropDownList;

			textCuentaOrigen.MaxLength = 8;
			textGlosa.MaxLength = 300;
			textCuentaDestino.MaxLength = 8;
			textCuentaDestinoNC.MaxLength = 8;
			textContraCuenta.MaxLength = 8;
			textNgCuentaDestino.MaxLength = 8;
			textNgCuentaDestinoNC.MaxLength = 8;
			textnNgContraCuenta.MaxLength = 8;

			comboCompania.TabIndex = 0;
			textCuentaOrigen.TabIndex = 1;
			textGlosa.TabIndex = 2;
			textCuentaDestino.TabIndex = 3;
			textCuentaDestinoNC.TabIndex = 4;
			textContraCuenta.TabIndex = 5;
			textNgCuentaDestino.TabIndex = 6;
			textNgCuentaDestinoNC.TabIndex = 7;
			textnNgContraCuenta.TabIndex = 8;

			CargaCompanias();
			CargaCuentasOrigen();

			MisFunciones.ConfiguraToolBar(toolBarra);

		}
		private void CargaFormulario()
		{
			comboCompanias.SelectedValue = "";
			comboCuentasOrigen.SelectedValue = "";
			CargaGrilla();
		}
		private void CargaCompanias()
		{
			try
			{
				BOCompanias oBO = new BOCompanias();
				List<DTOCompanias> lDTO = new List<DTOCompanias>();
				lDTO = oBO.ConsultaCompanias();
				// Agregar opcion "seleccionar"
				DTOCompanias oCom = new DTOCompanias();
				oCom.IdCompania = "";
				oCom.Nombre = "<Seleccione Compañia>";
				lDTO.Add(oCom);
				// Ordenamos las descripciones
				lDTO.Sort(delegate(DTOCompanias l1, DTOCompanias l2) { return l1.Combo.CompareTo(l2.Combo); });
				// Asignamos la lista
				comboCompanias.DisplayMember = "Combo";
				comboCompanias.ValueMember = "IdCompania";
				comboCompanias.DataSource = lDTO;

				List<DTOCompanias> lDTO2 = new List<DTOCompanias>();
				lDTO2 = oBO.ConsultaCompanias();
				lDTO2.Add(oCom);
				comboCompania.DisplayMember = "Combo";
				comboCompania.ValueMember = "IdCompania";
				comboCompania.DataSource = lDTO2;
			}
			catch (Exception ex)
			{
				hLog.msgFatal("Error detectado \n{" + ex.Message + "}");
			}
		}
		private void CargaCuentasOrigen()
		{
			try
			{
				BOConfiguracionAjustesAutomaticos oBo = new BOConfiguracionAjustesAutomaticos();
				List<DTOConfiguracionAjustesAutomaticos> lDTO = new List<DTOConfiguracionAjustesAutomaticos>();
				lDTO = oBo.ConsultaCuentasOrigen();
				DTOConfiguracionAjustesAutomaticos oDTO = new DTOConfiguracionAjustesAutomaticos();
				oDTO.CuentaOrigen = "";
				oDTO.Glosa = "<Seleccione Cuenta>";
				lDTO.Add(oDTO);
				// Ordenamos las descripciones
				lDTO.Sort(delegate(DTOConfiguracionAjustesAutomaticos l1, DTOConfiguracionAjustesAutomaticos l2) { return l1.CuentaOrigen.CompareTo(l2.CuentaOrigen); });
				// Asignamos la lista
				 comboCuentasOrigen.DisplayMember = "Glosa";
				 comboCuentasOrigen.ValueMember = "CuentaOrigen";
				 comboCuentasOrigen.DataSource = lDTO;
			}
			catch (Exception ex)
			{
				hLog.msgFatal("Error detectado \n{" + ex.Message + "}");
			}

		}
		private void CargaGrilla()
		{
			try
			{
				if (comboCompanias.Items.Count > 0 && comboCuentasOrigen.Items.Count > 0)
				{
					List<DTOConfiguracionAjustesAutomaticos> lDTO = new List<DTOConfiguracionAjustesAutomaticos>();
					BOConfiguracionAjustesAutomaticos oBO = new BOConfiguracionAjustesAutomaticos();
					lDTO = oBO.ConsultaConfiguracionAjustesAutomaticos(comboCompanias.SelectedValue.ToString(), comboCuentasOrigen.SelectedValue.ToString());

					gridConfiguracion.Rows.Clear();
					foreach (DTOConfiguracionAjustesAutomaticos oDTO in lDTO)
					{
						gridConfiguracion.Rows.Add();
						gridConfiguracion.Rows[gridConfiguracion.Rows.Count - 1].Cells["colIdCompania"].Value = oDTO.idCompania.ToString();
						gridConfiguracion.Rows[gridConfiguracion.Rows.Count - 1].Cells["colNombre"].Value = oDTO.Nombre.ToString();
						gridConfiguracion.Rows[gridConfiguracion.Rows.Count - 1].Cells["colCuentaOrigen"].Value = oDTO.CuentaOrigen.ToString();
						gridConfiguracion.Rows[gridConfiguracion.Rows.Count - 1].Cells["colGlosa"].Value = oDTO.Glosa.ToString();
						gridConfiguracion.Rows[gridConfiguracion.Rows.Count - 1].Cells["colCuentaDestino"].Value = oDTO.CuentaDestino.ToString();
						gridConfiguracion.Rows[gridConfiguracion.Rows.Count - 1].Cells["colCuentaDestinoNC"].Value = oDTO.CuentaDestinoNC.ToString();
						gridConfiguracion.Rows[gridConfiguracion.Rows.Count - 1].Cells["colContraCuenta"].Value = oDTO.ContraCuenta.ToString();
						gridConfiguracion.Rows[gridConfiguracion.Rows.Count - 1].Cells["colNgCuentaDestino"].Value = oDTO.NgCuentaDestino.ToString();
						gridConfiguracion.Rows[gridConfiguracion.Rows.Count - 1].Cells["colNgCuentaDestinoNC"].Value = oDTO.NgCuentaDestinoNC.ToString();
						gridConfiguracion.Rows[gridConfiguracion.Rows.Count - 1].Cells["colNgContraCuenta"].Value = oDTO.NgContraCuenta.ToString();
					}
				}
			}
			catch (Exception ex)
			{
				hLog.msgFatal("Error detectado \n{" + ex.Message + "}");
			}
		}
		private void NuevoRegistro()
		{
			iAccion = (int)CFG.ToolAcciones.Nuevo;

			tabControlConfiguracion.SelectedTab = tabPageMantenedor;
			tabPageMantenedor.Show();

			comboCompania.SelectedValue = comboCompanias.SelectedValue.ToString();
			textCuentaOrigen.Focus();

			textCuentaOrigen.Text = "";
			textGlosa.Text = "";
			textCuentaDestino.Text = "";
			textCuentaDestinoNC.Text = "";
			textContraCuenta.Text = "";
			textNgCuentaDestino.Text = "";
			textNgCuentaDestinoNC.Text = "";
			textnNgContraCuenta.Text = "";

			comboCompania.Enabled = true;
			textCuentaOrigen.Enabled = true;

			textCuentaOrigen.Focus();
		}
		private void EditarRegistro()
		{
			if (gridConfiguracion.Rows.Count > 0)
			{
				if (gridConfiguracion.CurrentRow.Selected)
				{
					CambiaEstadoBotonera(false);
					iAccion = (int)CFG.ToolAcciones.Editar;
					tabControlConfiguracion.SelectedTab = tabPageMantenedor;
					tabPageMantenedor.Show();

					comboCompania.SelectedValue = gridConfiguracion.Rows[gridConfiguracion.CurrentCell.RowIndex].Cells["colIdCompania"].Value.ToString();
					textCuentaOrigen.Text = gridConfiguracion.Rows[gridConfiguracion.CurrentCell.RowIndex].Cells["colCuentaOrigen"].Value.ToString();
					textGlosa.Text = gridConfiguracion.Rows[gridConfiguracion.CurrentCell.RowIndex].Cells["colGlosa"].Value.ToString();
					textCuentaDestino.Text = gridConfiguracion.Rows[gridConfiguracion.CurrentCell.RowIndex].Cells["colCuentaDestino"].Value.ToString();
					textCuentaDestinoNC.Text = gridConfiguracion.Rows[gridConfiguracion.CurrentCell.RowIndex].Cells["colCuentaDestinoNC"].Value.ToString();
					textContraCuenta.Text = gridConfiguracion.Rows[gridConfiguracion.CurrentCell.RowIndex].Cells["colContraCuenta"].Value.ToString();
					textNgCuentaDestino.Text = gridConfiguracion.Rows[gridConfiguracion.CurrentCell.RowIndex].Cells["colNgCuentaDestino"].Value.ToString();
					textNgCuentaDestinoNC.Text = gridConfiguracion.Rows[gridConfiguracion.CurrentCell.RowIndex].Cells["colNgCuentaDestinoNC"].Value.ToString();
					textnNgContraCuenta.Text = gridConfiguracion.Rows[gridConfiguracion.CurrentCell.RowIndex].Cells["colNgContraCuenta"].Value.ToString();

					textCuentaOrigen.SelectAll();
					textCuentaOrigen.Focus();

					comboCompania.Enabled = false;
					textCuentaOrigen.Enabled = false;
				}
			}
		}
		private void EliminarRegistro()
		{
			if (gridConfiguracion.Rows.Count > 0)
			{
				if (gridConfiguracion.CurrentRow.Selected)
				{
					if (NewConsolidado.Properties.Settings.Default.usrPreguntaEliminar)
					{
						DialogResult oDlg = MessageBox.Show("Desea eliminar el registro seleccionado", NewConsolidado.Properties.Settings.Default.appTituloAplicacion, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
						if (oDlg == DialogResult.No)
						{
							CancelarAccion();
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
			tabControlConfiguracion.SelectedTab = tabPageLista;
		}
		private void GrabarRegistro()
		{
			try
			{
				BOConfiguracionAjustesAutomaticos oBO = new BOConfiguracionAjustesAutomaticos();
				switch (iAccion)
				{
					case (int)CFG.ToolAcciones.Nuevo:
						{
							#region
							if (ValidarCampos())
							{
								List<DTOConfiguracionAjustesAutomaticos> lDTO = new List<DTOConfiguracionAjustesAutomaticos>();
								DTOConfiguracionAjustesAutomaticos oDTO = new DTOConfiguracionAjustesAutomaticos();
								//
								oDTO.idCompania = comboCompania.SelectedValue.ToString();
								oDTO.CuentaOrigen = textCuentaOrigen.Text.Trim();
								oDTO.Glosa = textGlosa.Text.Trim();
								oDTO.CuentaDestino = textCuentaDestino.Text.Trim();
								oDTO.CuentaDestinoNC = textCuentaDestinoNC.Text.Trim();
								oDTO.ContraCuenta = textContraCuenta.Text.Trim();
								oDTO.NgCuentaDestino = textNgCuentaDestino.Text.Trim();
								oDTO.NgCuentaDestinoNC = textNgCuentaDestinoNC.Text.Trim();
								oDTO.NgContraCuenta = textnNgContraCuenta.Text.Trim();
								lDTO.Add(oDTO);
								//
								oBO.GrabarRegistro(lDTO, iAccion);
								//
								tabControlConfiguracion.SelectedTab = tabPageLista;
								tabPageLista.Show();
								CargaGrilla();
							}
							#endregion
							break;
						}
					case (int)CFG.ToolAcciones.Editar:
						{
							#region
							if (ValidarCampos())
							{
								List<DTOConfiguracionAjustesAutomaticos> lDTO = new List<DTOConfiguracionAjustesAutomaticos>();
								DTOConfiguracionAjustesAutomaticos oDTO = new DTOConfiguracionAjustesAutomaticos();
								//
								oDTO.idCompania = comboCompania.SelectedValue.ToString();
								oDTO.CuentaOrigen = textCuentaOrigen.Text.Trim();
								oDTO.Glosa = textGlosa.Text.Trim();
								oDTO.CuentaDestino = textCuentaDestino.Text.Trim();
								oDTO.CuentaDestinoNC = textCuentaDestinoNC.Text.Trim();
								oDTO.ContraCuenta = textContraCuenta.Text.Trim();
								oDTO.NgCuentaDestino = textNgCuentaDestino.Text.Trim();
								oDTO.NgCuentaDestinoNC = textNgCuentaDestinoNC.Text.Trim();
								oDTO.NgContraCuenta = textnNgContraCuenta.Text.Trim();
								lDTO.Add(oDTO);
								//
								oBO.GrabarRegistro(lDTO, iAccion);
								//
								tabControlConfiguracion.SelectedTab = tabPageLista;
								tabPageLista.Show();
								CargaGrilla();
							}
							#endregion
							break;
						}
					case (int)CFG.ToolAcciones.Eliminar:
						{
							#region

							List<DTOConfiguracionAjustesAutomaticos> lDTO = new List<DTOConfiguracionAjustesAutomaticos>();
							DTOConfiguracionAjustesAutomaticos oDTO = new DTOConfiguracionAjustesAutomaticos();
							//
							oDTO.idCompania = comboCompania.SelectedValue.ToString();
							oDTO.CuentaOrigen = textCuentaOrigen.Text.Trim();
							oDTO.Glosa = textGlosa.Text.Trim();
							oDTO.CuentaDestino = textCuentaDestino.Text.Trim();
							oDTO.CuentaDestinoNC = textCuentaDestinoNC.Text.Trim();
							oDTO.ContraCuenta = textContraCuenta.Text.Trim();
							oDTO.NgCuentaDestino = textNgCuentaDestino.Text.Trim();
							oDTO.NgCuentaDestinoNC = textNgCuentaDestinoNC.Text.Trim();
							oDTO.NgContraCuenta = textnNgContraCuenta.Text.Trim();
							lDTO.Add(oDTO);
							//
							oBO.GrabarRegistro(lDTO, iAccion);
							//
							tabControlConfiguracion.SelectedTab = tabPageLista;
							tabPageLista.Show();
							CargaGrilla();
							#endregion
							break;
						}
					default:
						{
							hLog.Fatal("Mala clasificacion al {GrabarRegistro}");
							throw new SystemException("Mala clasificacion al {GrabarRegistro}");
							
						}
				}
			}
			catch (Exception Ex)
			{
				hLog.msgFatal("Error detectado \n{" + Ex.Message + "}");
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
		private void CambioTabPage()
		{
			if ( tabControlConfiguracion.SelectedTab == tabPageLista)
			{
				CambiaEstadoBotonera(true);
				iAccion = (int)CFG.ToolAcciones.Nada;
			}
			else
			{
				CambiaEstadoBotonera(false);
				if (iAccion == (int)CFG.ToolAcciones.Nada)
				{
					NuevoRegistro();
				}
			}
		}
		private Boolean ValidarCampos()
		{
			if (textCuentaOrigen.Text.Trim() == "")
			{
				hLog.msgError("Debe ingresar una cuenta de Origen para el ajuste");
				textCuentaOrigen.SelectAll();
				textCuentaOrigen.Focus();
				return false;
			}
			if (textGlosa.Text.Trim() == "")
			{
				hLog.msgError("Debe ingresa la glosa que tendra el ajuste");
				textGlosa.SelectAll();
				textGlosa.Focus();
				return false;
			}
			if (textCuentaDestino.Text.Trim() == "")
			{
				hLog.msgError("Debe ingresar la cuenta de destino para el valor del Porcentaje de Patrimonio");
				textCuentaDestino.SelectAll();
				textCuentaDestino.Focus();
				return false;
			}
			if (textCuentaDestinoNC.Text.Trim() == "")
			{
				hLog.msgError("Debe ingresar la cuenta de destino para el valor No Controladora");
				textCuentaDestinoNC.SelectAll();
				textCuentaDestinoNC.Focus();
				return false;
			}
			if (textContraCuenta.Text.Trim() == "" && textCuentaOrigen.Text == "0")
			{
				hLog.msgError("Debe ingresar el valor para la contra cuenta de ajuste");
				textContraCuenta.SelectAll();
				textContraCuenta.Focus();
				return false;
			}

			if (textNgCuentaDestino.Text.Trim() == "")
			{
				hLog.msgError("Debe ingresar la cuenta de destino para valores negativos");
				textNgCuentaDestino.SelectAll();
				textNgCuentaDestino.Focus();
				return false;
			}
			if (textNgCuentaDestinoNC.Text.Trim() == "")
			{
				hLog.msgError("Debe ingresar la cuenta de destino para No Controladora para valores negativos");
				textNgCuentaDestinoNC.SelectAll();
				textNgCuentaDestinoNC.Focus();
				return false;
			}
			if ( textnNgContraCuenta.Text.Trim() == "" && textCuentaOrigen.Text == "0")
			{
				hLog.msgError("Debe ingresar la contra cuenta para los valores negativos");
				textnNgContraCuenta.SelectAll();
				textnNgContraCuenta.Focus();
				return false;
			}
			return true;
		}
	}
}
