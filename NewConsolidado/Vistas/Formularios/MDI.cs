using System;
using System.IO;
using System.Drawing;
using System.Security.Principal;
using System.Windows.Forms;
using NewConsolidado.Controladores.Clases;
using NewConsolidado.Controladores.ControladorNegocio;
using NewConsolidado.Modelos.TransporteDatos;
using System.Diagnostics;

namespace NewConsolidado.Vistas.Formularios
{
	public partial class MDI : Form
	{
		private MyLog4Net hLog = new MyLog4Net("MDI.Form");

        public MDI(string[] Argumentos)
        {            
            try
            {
                InitializeComponent();

                this.Text = NewConsolidado.Properties.Settings.Default.appTituloAplicacion;

                string sRutaApp = System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                sRutaApp += @"\" + Application.CompanyName + @"\" + Application.ProductName;

                #region Asignacion y Validacion de existencia de rutas fijas de la aplicacion
                NewConsolidado.Properties.Settings.Default.usrRutaArchivos = sRutaApp;
                NewConsolidado.Properties.Settings.Default.usrRutaArchivosLog = sRutaApp + @"\log";
                NewConsolidado.Properties.Settings.Default.usrRutaArchivosPaso = sRutaApp + @"\temporales";
                Directory.CreateDirectory(NewConsolidado.Properties.Settings.Default.usrRutaArchivos);
                Directory.CreateDirectory(NewConsolidado.Properties.Settings.Default.usrRutaArchivosLog);
                Directory.CreateDirectory(NewConsolidado.Properties.Settings.Default.usrRutaArchivosPaso);
                #endregion

                // Obtencion de Usuario Activo
                WindowsIdentity currentUser = WindowsIdentity.GetCurrent();
                Globales.UsuarioActivo = currentUser.Name;

                // mnejo de usuario adm y debug
                Globales.ConexionSSPI = true;
                string sNombreConfiguracion = "configuracion.xml";
                if (Argumentos.Length > 0)
                {
                    if (Argumentos[0].ToString() == "Debug")
                    {
                        if (Argumentos[1].ToString() == "Conn=Desa")
                        {
                            sNombreConfiguracion = "configuracion-desa.xml";
                        }
                        if (Argumentos[2].ToString() == "SSPI=false")
                        {
                            Globales.ConexionSSPI = false;
                        }
                        if (Argumentos[3].ToString() == "ROOT=true")
                        {
                            Globales.UsuarioActivo =  @"icafal\msepulvedag";
                            CambiaPrivilegios(true);
                        }
                    }
                }
                sNombreConfiguracion = sRutaApp + @"\" + sNombreConfiguracion;

                #region arma conexion a BD
                NewConsolidado.Properties.Settings.Default.strConnSource = MisFunciones.LeeArchivoConfiguracion(sNombreConfiguracion, "configuracion", "connsource");
                NewConsolidado.Properties.Settings.Default.strConnCatalog = MisFunciones.LeeArchivoConfiguracion(sNombreConfiguracion, "configuracion", "conncatalog"); ;
                NewConsolidado.Properties.Settings.Default.strConnUser = MisFunciones.LeeArchivoConfiguracion(sNombreConfiguracion, "configuracion", "connuser"); ;
                NewConsolidado.Properties.Settings.Default.strConnPassword = Base64.Base64Decode(MisFunciones.LeeArchivoConfiguracion(sNombreConfiguracion, "configuracion", "connpassword"));
                #endregion

                #region Define variable para libreria Log4Net
                NewConsolidado.Properties.Settings.Default.myLog4NetNivel = int.Parse(MisFunciones.LeeArchivoConfiguracion(sNombreConfiguracion, "log4net", "nivel"));
                NewConsolidado.Properties.Settings.Default.myLog4NetDestino = int.Parse(MisFunciones.LeeArchivoConfiguracion(sNombreConfiguracion, "log4net", "destino"));
                #endregion

                // Limpiamos la Consola
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("-----------------------");
                Console.WriteLine("");

                hLog.Debug("Inicia sesion de trabajo");

                CambiaLabelusuario();

                // Obtencion de la version
                statusLabelVersion.Text = Application.ProductVersion.ToString();
                statusConexion.Text = NewConsolidado.Properties.Settings.Default.strConnCatalog;

                    #region Revision de Nueva Version
                    BOVersiones oBO = new BOVersiones();
                    if (oBO.EstadoVersionApp(Application.ProductVersion.ToString()))
                    {
                        DTOVersiones oDTO = new DTOVersiones();
                        oDTO = oBO.ConsultaUltimaVersion();
                        if (oDTO != null)
                        {
                            if (oDTO.Numero != Application.ProductVersion.ToString())
                            {
                                hLog.msgInfo("Existe una nueva version de la aplicación");
                                //statusLabelVersion.BackColor = Color.YellowGreen;
                                statusLabelVersion.ToolTipText = "Existe una nueva version de la aplicación";
                                statusLabelVersion.Image = NewConsolidado.Properties.Resources.rsc_24_update;
                            }
                        }
                    }
                    else
                    {
                        hLog.msgError("La version de la aplicacion no esta activa [" + Application.ProductVersion.ToString() + "]");
                        this.Close();

                    }
                    #endregion

                    #region Revisa Concurrencia de carga de datos Dynamics
                    VerificaConcurrenciaDynamics();
                    #endregion

                    timerConcurrencias.Interval = 5000;
                    timerConcurrencias.Start();

            }
            catch (Exception Ex)
            {
                hLog.msgFatal("Error detectado \n\n" + Ex.Message);
                this.Close();
            }
        }
		private void MDI_Load(object sender, EventArgs e)
		{
            this.WindowState = FormWindowState.Normal;
            this.Height = 690;
            this.Width = 1080;
            this.Top = 30;
            this.Left = 100;

            MdiClient ctlMDI;
            // Loop through all of the form's controls looking
            // for the control of type MdiClient.
            foreach (Control ctl in this.Controls)
            {
                try
                {                    
                    // Attempt to cast the control to type MdiClient.
                    ctlMDI = (MdiClient)ctl;

                    // Set the BackColor of the MdiClient control.
                    ctlMDI.BackColor = this.BackColor;
                }
                catch (InvalidCastException ex)
                {
                    System.Console.WriteLine(ex.Message);
                    // Catch and ignore the error if casting failed.
                }
            }

		}
		private void MDI_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (NewConsolidado.Properties.Settings.Default.usrPreguntarAlSalir)
			{
				DialogResult oDlg = MessageBox.Show("Quieres salir de la aplicación?", NewConsolidado.Properties.Settings.Default.appTituloAplicacion, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (oDlg == DialogResult.No)
				{
					e.Cancel = true;
				}
				else
				{
					NewConsolidado.Properties.Settings.Default.usrAppWindowEstado = this.WindowState;
					if (this.WindowState != FormWindowState.Maximized)
					{
						NewConsolidado.Properties.Settings.Default.usrAppAlto = this.Height;
						NewConsolidado.Properties.Settings.Default.usrAppAncho = this.Width;
						NewConsolidado.Properties.Settings.Default.usrAppTop = this.Top;
						NewConsolidado.Properties.Settings.Default.usrAppIzquierda = this.Left;
					}

					NewConsolidado.Properties.Settings.Default.Save();
					this.Dispose();

				}
			}
		}
		private void MDI_FormClosed(object sender, FormClosedEventArgs e)
		{
			NewConsolidado.Properties.Settings.Default.usrAppWindowEstado = this.WindowState;
			if (this.WindowState != FormWindowState.Maximized)
			{
				NewConsolidado.Properties.Settings.Default.usrAppAlto = this.Height;
				NewConsolidado.Properties.Settings.Default.usrAppAncho = this.Width;
				NewConsolidado.Properties.Settings.Default.usrAppTop = this.Top;
				NewConsolidado.Properties.Settings.Default.usrAppIzquierda = this.Left;
			}

			NewConsolidado.Properties.Settings.Default.Save();
		}
		private void acercaDeLaAplicaciónToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AcercaDe childForm = new AcercaDe();
            childForm.StartPosition = FormStartPosition.CenterParent;
            childForm.ShowDialog();
		}
		private void reportesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MenuReportes childForm = new MenuReportes();
			childForm.MdiParent = this;
			foreach (Form f in this.MdiChildren)
			{
				if (f is MenuReportes)
				{
					childForm = (MenuReportes)f;
					break;
				}
			}
			if (childForm != null)
			{
				childForm.Show();
				childForm.Focus();
			}
			else
			{
				childForm = new MenuReportes();
				childForm.MdiParent = this;
				childForm.Show();
				childForm.Focus();
			}
		}
		private void consolidadosToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;
			MantenedorConsolidados childForm = new MantenedorConsolidados();
			childForm.MdiParent = this;
			foreach (Form f in this.MdiChildren)
			{
				if (f is MantenedorConsolidados)
				{
					childForm = (MantenedorConsolidados)f;
					break;
				}
			}
			if (childForm != null)
			{
				childForm.Show();
				childForm.Focus();
			}
			else
			{
				childForm = new MantenedorConsolidados();
				childForm.MdiParent = this;
				childForm.Show();
				childForm.Focus();
			}
			this.Cursor = Cursors.Default;
		}
		private void archivoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void configuracionAplicaciónToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ConfiguracionApp oDlg = new ConfiguracionApp(this);
			oDlg.StartPosition = FormStartPosition.CenterParent;
			if (oDlg.ShowDialog(this) == DialogResult.OK)
			{
				//statusConexion.Text = CFG.aConexion[NewConsolidado.Properties.Settings.Default.appSelecccionBD].ToString();
			}
		}

		private void anulacionesContablesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			IngresoAjustesManuales childForm = new IngresoAjustesManuales();
			childForm.MdiParent = this;
			foreach (Form f in this.MdiChildren)
			{
				if (f is IngresoAjustesManuales)
				{
					childForm = (IngresoAjustesManuales)f;
					break;
				}
			}
			if (childForm != null)
			{
				childForm.Show();
				childForm.Focus();
			}
			else
			{
				childForm = new IngresoAjustesManuales();
				childForm.MdiParent = this;
				childForm.Show();
				childForm.Focus();
			}
		}
		private void cuentasContablesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MantenedorMaestroCuentasContables childForm = new MantenedorMaestroCuentasContables();
			childForm.MdiParent = this;
			foreach (Form f in this.MdiChildren)
			{
				if (f is MantenedorMaestroCuentasContables)
				{
					childForm = (MantenedorMaestroCuentasContables)f;
					break;
				}
			}
			if (childForm != null)
			{
				childForm.Show();
				childForm.Focus();
			}
			else
			{
				childForm = new MantenedorMaestroCuentasContables();
				childForm.MdiParent = this;
				childForm.Show();
				childForm.Focus();
			}
		}
		private void gruposToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MantenedorGrupos childForm = new MantenedorGrupos();
			childForm.MdiParent = this;
			foreach (Form f in this.MdiChildren)
			{
				if (f is MantenedorGrupos)
				{
					childForm = (MantenedorGrupos)f;
					break;
				}
			}
			if (childForm != null)
			{
				childForm.Show();
				childForm.Focus();
			}
			else
			{
				childForm = new MantenedorGrupos();
				childForm.MdiParent = this;
				childForm.Show();
				childForm.Focus();
			}
		}

		private void conceptosToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MantenedorConceptos childForm = new MantenedorConceptos();
			childForm.MdiParent = this;
			foreach (Form f in this.MdiChildren)
			{
				if (f is MantenedorConceptos)
				{
					childForm = (MantenedorConceptos)f;
					break;
				}
			}
			if (childForm != null)
			{
				childForm.Show();
				childForm.Focus();
			}
			else
			{
				childForm = new MantenedorConceptos();
				childForm.MdiParent = this;
				childForm.Show();
				childForm.Focus();
			}
		}
		private void plantillaConceptosToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;
			MantenedorAsociacionGruposConceptosCuentas childForm = new MantenedorAsociacionGruposConceptosCuentas();
			childForm.MdiParent = this;
			foreach (Form f in this.MdiChildren)
			{
				if (f is MantenedorAsociacionGruposConceptosCuentas)
				{
					childForm = (MantenedorAsociacionGruposConceptosCuentas)f;
					break;
				}
			}
			if (childForm != null)
			{
				childForm.Show();
				childForm.Focus();
			}
			else
			{
				childForm = new MantenedorAsociacionGruposConceptosCuentas();
				childForm.MdiParent = this;
				childForm.Show();
				childForm.Focus();
			}
			this.Cursor = Cursors.Default;
		}
		private void compañiasToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MantenedorCompanias childForm = new MantenedorCompanias();
			childForm.MdiParent = this;
			foreach (Form f in this.MdiChildren)
			{
				if (f is MantenedorCompanias)
				{
					childForm = (MantenedorCompanias)f;
					break;
				}
			}
			if (childForm != null)
			{
				childForm.Show();
				childForm.Focus();
			}
			else
			{
				childForm = new MantenedorCompanias();
				childForm.MdiParent = this;
				childForm.Show();
				childForm.Focus();
			}
		}
		private void saldosContablesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			IngresoSaldosContables childForm = new IngresoSaldosContables();
			childForm.MdiParent = this;
			foreach (Form f in this.MdiChildren)
			{
				if (f is IngresoSaldosContables)
				{
					childForm = (IngresoSaldosContables)f;
					break;
				}
			}
			if (childForm != null)
			{
				childForm.Show();
				childForm.Focus();
			}
			else
			{
				childForm = new IngresoSaldosContables();
				childForm.MdiParent = this;
				childForm.Show();
				childForm.Focus();
			}
		}
		private void mantenedorToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MantenedorConfiguracionAjustesAutomaticos childForm = new MantenedorConfiguracionAjustesAutomaticos();
			childForm.MdiParent = this;
			foreach (Form f in this.MdiChildren)
			{
				if (f is MantenedorConfiguracionAjustesAutomaticos)
				{
					childForm = (MantenedorConfiguracionAjustesAutomaticos)f;
					break;
				}
			}
			if (childForm != null)
			{
				childForm.Show();
				childForm.Focus();
			}
			else
			{
				childForm = new MantenedorConfiguracionAjustesAutomaticos();
				childForm.MdiParent = this;
				childForm.Show();
				childForm.Focus();
			}
		}
		private void cambiarAAdministradorToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CambiaRoot oForm = new CambiaRoot();
			oForm.StartPosition = FormStartPosition.CenterParent;
			oForm.ShowIcon = false;
			oForm.ShowInTaskbar = false;
			DialogResult oDr = oForm.ShowDialog();
			switch (oDr)
			{
				case DialogResult.OK:
					{
                        CambiaPrivilegios(true);
						//Globales.iTipoUsuario = (int)CFG.Usuario.Administrador;
						//statusLabelUsuario.BackColor = Color.Salmon;
						break;
					}
				case DialogResult.No:
					{
                        CambiaPrivilegios(false);
						//statusLabelUsuario.BackColor = Color.WhiteSmoke;
						//Globales.iTipoUsuario = (int)CFG.Usuario.Usuario;
						break;
					}
				case DialogResult.Cancel:
					{
						//statusLabelUsuario.BackColor = Color.WhiteSmoke;
						//Globales.iTipoUsuario = (int)CFG.Usuario.Usuario;
						break;
					}
				default:
					{
						hLog.msgError("Retorno de formulario no valido");
						break;
					}
			}
			CambiaLabelusuario();
		}
		private void timerConcurrencias_Tick(object sender, EventArgs e)
		{
			timerConcurrencias.Stop();
			VerificaConcurrenciaDynamics();
			timerConcurrencias.Start();
		}

        private void accederAUltimaVersiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", @"\\clsticas038\99 Software Usuarios"); 
        }

        private void CambiaPrivilegios(bool bRoot)
        {
            if (bRoot)
            {
                statusLabelUsuario.BackColor = Color.Salmon;
                Globales.iTipoUsuario = (int)CFG.Usuario.Administrador;
            }
            else
            {
                statusLabelUsuario.BackColor = Color.WhiteSmoke;
                Globales.iTipoUsuario = (int)CFG.Usuario.Usuario;
            }
        }

		//-------------------------------------------------------------------------------------------------------------		
		// Metodo privados
		//-------------------------------------------------------------------------------------------------------------		
		public void CambiaLabelusuario()
		{
			statusLabelUsuario.Text = CFG.aUsuario[Globales.iTipoUsuario] + " {" + Globales.UsuarioActivo + "}";
		}

        private void VerificaConcurrenciaDynamics()
		{
			try
			{
				Boolean bEstado = true;
				DTOConcurrencias oDTOConcurrencias = new DTOConcurrencias();
				BOConcurrencias oBOConcurrencias = new BOConcurrencias();
				oDTOConcurrencias = oBOConcurrencias.ConsultaConcurrenciasDynamics();
				if (oDTOConcurrencias.ValueConcurrencia == (int)CFG.Concurrencia.ConConcurrencia)
				{
					statusLabelConcurrencias.BackColor = Color.IndianRed;
					statusLabelConcurrencias.Text = "...Se esta ejecutando la carga de Dynamics. No podra ejecutar ninguna acción hasta que termine...";
					bEstado = false;
					foreach (Form oForm in this.MdiChildren)
					{
						oForm.Enabled = bEstado;
						foreach (Form oFormH in oForm.OwnedForms)
						{
							oFormH.Enabled = bEstado;
						}
					}
					foreach (Form oForm in this.OwnedForms)
					{
						oForm.Enabled = bEstado;
					}
					mnuPrincipal.Enabled = bEstado;
				}
				else
				{
					bEstado = true;
					statusLabelConcurrencias.BackColor = Color.WhiteSmoke;
					statusLabelConcurrencias.Text = "";

					foreach (Form oForm in this.MdiChildren)
					{
						oForm.Enabled = bEstado;
						foreach (Form oFormH in oForm.OwnedForms)
						{
							oFormH.Enabled = bEstado;
						}
					}
					foreach (Form oForm in this.OwnedForms)
					{
						oForm.Enabled = bEstado;
					}
					mnuPrincipal.Enabled = bEstado;
				}
			}
			catch (Exception ex)
			{
				hLog.msgFatal(ex.Message);
			}
		}
	}
}
