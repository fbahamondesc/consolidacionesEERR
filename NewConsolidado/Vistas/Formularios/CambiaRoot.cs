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
	public partial class CambiaRoot : Form
	{
		private MyLog4Net hLog = new MyLog4Net("MantenedorConsolidados_Consolidados.Form");

		public CambiaRoot()
		{
			InitializeComponent();
			ConfiguracionFormulario();
		}
		private void CambiaRoot_Load(object sender, EventArgs e)
		{
			CargaFormulario();
		}
		private void buttonAceptar_Click(object sender, EventArgs e)
		{
			BotonAceptar();
		}
		private void buttonCancelar_Click(object sender, EventArgs e)
		{
			BotonSalir();
		}
		//----------------------------------------------------------------------------------------------------------------
		//						Metodos Privados
		//----------------------------------------------------------------------------------------------------------------
		private void ConfiguracionFormulario()
		{
			this.Text = "Cambio de credenciales a Administrador";

			textClave.MaxLength = 10;
			textClave.UseSystemPasswordChar = true;

			buttonGrabar.Image = NewConsolidado.Properties.Resources.rsc_24_Grabar;
			buttonGrabar.Size = new System.Drawing.Size(CFG.buttonAncho, CFG.buttonAlto);
			buttonGrabar.Text = "Aceptar";
			buttonGrabar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			buttonGrabar.UseVisualStyleBackColor = true;
			//
			buttonSalir.Image = global::NewConsolidado.Properties.Resources.rsc_24_SalirForm;
			buttonSalir.Size = new System.Drawing.Size(CFG.buttonAncho, CFG.buttonAlto);
			buttonSalir.Text = "Salir";
			buttonSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			buttonSalir.UseVisualStyleBackColor = true;

			//buttonUsuario.Enabled = Globales.iTipoUsuario == (int)CFG.Usuario.Administrador;

		}
		private void CargaFormulario()
		{
		}
		private void BotonAceptar()
		{
			DTOConfiguraciones oDTO = new DTOConfiguraciones();
			BOConfiguraciones oBO = new BOConfiguraciones();

			try
			{
				oDTO = oBO.ConsultaConfiguraciones("Root");
				if (oDTO != null)
				{
					if (oDTO.ValorConfiguracion == textClave.Text.Trim())
					{
						this.DialogResult = DialogResult.OK;
						this.Close();
					}
					else
					{
						hLog.msgError("Clave no corresponde");
						textClave.Focus();
					}
				}
			}
			catch (Exception ex)
			{
				hLog.msgFatal(ex.Message);
			}
		}
		private void BotonSalir()
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		private void buttonUsuario_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.No;
			this.Close();
		}
	}
}
