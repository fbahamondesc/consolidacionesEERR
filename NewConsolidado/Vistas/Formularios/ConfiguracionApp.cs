using System;
using System.Windows.Forms;

using NewConsolidado.Controladores.Clases;
using NewConsolidado.Controladores.ControladorNegocio;

namespace NewConsolidado.Vistas.Formularios
{
	public partial class ConfiguracionApp : Form
	{
		private MyLog4Net hLog = new MyLog4Net("ConfiguracionApp.Form");
        //string[] Args;
		//private MDI oMdi = new MDI();

		public ConfiguracionApp(MDI obj)
		{
			InitializeComponent();

			ConfiguraObjetos();
			CargaObjetos();

			//oMdi = obj;
		}
		private void buttonSalir_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Abort;
			this.Close();
		}
		private void buttonGrabar_Click(object sender, EventArgs e)
		{
			Grabar();
			this.DialogResult = DialogResult.OK;
			this.Close();
		}
		private void pictureBox1_DoubleClick(object sender, EventArgs e)
		{
			if (!tabOpciones.TabPages.Contains(tabPageDebug))
			{
				tabOpciones.TabPages.Insert(tabOpciones.TabPages.Count, tabPageDebug);
			}
		}
		private void buttonCambioConexion_Click(object sender, EventArgs e)
		{
			//CambiaConexion(0);
		}
		private void buttonAD_Click(object sender, EventArgs e)
		{
			//CambiaConexion(1);
		}
		private void ConfiguracionApp_FormClosed(object sender, FormClosedEventArgs e)
		{

		}
		private void ConfiguracionApp_Load(object sender, EventArgs e)
		{

		}
		private void radioProduccion_CheckedChanged(object sender, EventArgs e)
		{
            //CambiaConexion((int)CFG.Conexion.Produccion);
            //hLog.Debug("Cambio de conexion a produccion");
		}
		private void radioDesarrollo_CheckedChanged(object sender, EventArgs e)
		{
            //CambiaConexion((int)CFG.Conexion.Desarrollo);
            //hLog.Debug("Cambio de conexion a desarrollo");
		}
		private void buttonEjecutarCarga_Click(object sender, EventArgs e)
		{
			BotonEjecutarCargaDynamics();
		}
		private void buttonConcurrencias_Click(object sender, EventArgs e)
		{
			BotonConcurrencias();
		}
        //private void buttonDebugCambiaUsuario_Click(object sender, EventArgs e)
        //{
        //    BotonCambiaUsuarioAdominguezv();
        //}

        //private void buttonDebugCambiaUsuario2_Click(object sender, EventArgs e)
        //{
        //    BotonCambiaUsuarioCcarrascom();
        //}

		//------------------------------------------------------------------------------------------------------------------
		//					Metodo Privados
		//------------------------------------------------------------------------------------------------------------------
		private void ConfiguraObjetos()
		{
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
			//
			comboDespliegueToolbar.DropDownStyle = ComboBoxStyle.DropDownList;
			//
			comboDespliegueBotones.DropDownStyle = ComboBoxStyle.DropDownList;
			//
			comboEnvioLog.DropDownStyle = ComboBoxStyle.DropDownList;
			//
			comboNivelLog.DropDownStyle = ComboBoxStyle.DropDownList;
			//
			this.AcceptButton = buttonGrabar;
			this.CancelButton = buttonSalir;
			//
			buttonGrabar.TabIndex = 0;
			buttonSalir.TabIndex = 1;
			comboDespliegueToolbar.TabIndex = 2;
			//
			tabOpciones.TabPages.Remove(tabPageDebug);
			if (Globales.iTipoUsuario == (int)CFG.Usuario.Usuario)
			{
				tabOpciones.TabPages.Remove(tabPageAdministrador);
			}
		}
		private void CargaObjetos()
		{
			#region Reportes
			BOMaestroLibros oBO = new BOMaestroLibros();
			string[] aLista = oBO.ConsultaMaestroLibros();
			listLibrosReporte.Items.AddRange(aLista);
			string sRecordar = NewConsolidado.Properties.Settings.Default.usrLibrosReporte;
			for (int iInd = 0; iInd < listLibrosReporte.Items.Count; iInd++)
			{
				if (sRecordar.Contains(listLibrosReporte.Items[iInd].ToString()))
				{
					listLibrosReporte.SetItemChecked(iInd, true);
				}
			}
			#endregion

			#region Aspecto
			#region preguntas
			checkPreguntarSalir.Checked = NewConsolidado.Properties.Settings.Default.usrPreguntarAlSalir;
			checkPreguntarEliminar.Checked = NewConsolidado.Properties.Settings.Default.usrPreguntaEliminar;
			checkPreguntarFormulariosSalir.Checked = NewConsolidado.Properties.Settings.Default.usrPreguntaFormulariosSalir;
			checkRecordarPosicionFormulario.Checked = NewConsolidado.Properties.Settings.Default.usrRecorarPosicionFormularios;
			checkMuestraCampos.Checked = NewConsolidado.Properties.Settings.Default.usrMuestraCamposOcultos;
			checkMuestraColumnas.Checked = NewConsolidado.Properties.Settings.Default.usrMuestraColumnasOcultas;
			#endregion

			#region Aspecto
			comboDespliegueToolbar.Items.AddRange(CFG.aToolBarDiseño);
			comboDespliegueToolbar.SelectedIndex = NewConsolidado.Properties.Settings.Default.usrDiseñoToolbar;
			comboDespliegueBotones.Items.AddRange(CFG.aToolBarDiseño);
			comboDespliegueBotones.SelectedIndex = NewConsolidado.Properties.Settings.Default.usrDiseñoBotones;
			#endregion

			#endregion

			#region Tab Debug

			#region Conexion
            //radioProduccion.Checked = NewConsolidado.Properties.Settings.Default.appSelecccionBD == (int)CFG.Conexion.Produccion ? true : false;
            //radioDesarrollo.Checked = NewConsolidado.Properties.Settings.Default.appSelecccionBD == (int)CFG.Conexion.Desarrollo ? true : false;
            //laConexion.Text = NewConsolidado.Properties.Settings.Default.usrStringConexion;
			#endregion

			#region Seguimineto
			comboNivelLog.Items.AddRange(MyLog4Net.aNivelLog);
			comboNivelLog.SelectedIndex = NewConsolidado.Properties.Settings.Default.myLog4NetNivel;
			comboEnvioLog.Items.AddRange(MyLog4Net.aDestinoMensaje);
			comboEnvioLog.SelectedIndex = NewConsolidado.Properties.Settings.Default.myLog4NetDestino;
			#endregion

			#endregion
		}

        //private void CambiaConexion(int iTipo)
        //{
        //    MisFunciones.ConexionGlobal(iTipo);
        //    laConexion.Text = NewConsolidado.Properties.Settings.Default.usrStringConexion;
        //    hLog.Debug("Conexion {" + NewConsolidado.Properties.Settings.Default.usrStringConexion + "}");
        //}

		private void Grabar()
		{
			#region Libros
			string sLibros = "";
			string sSep = "";
			foreach (int iInd in listLibrosReporte.CheckedIndices)
			{
				hLog.Debug("{" + iInd.ToString() + "} " + listLibrosReporte.GetItemCheckState(iInd).ToString() + "{" + listLibrosReporte.Items[iInd].ToString() + "}");
				sLibros += sSep + listLibrosReporte.Items[iInd].ToString();
				sSep = ",";
			}
			NewConsolidado.Properties.Settings.Default.usrLibrosReporte = sLibros;
			#endregion

			#region Aspecto
			#region preguntas
			NewConsolidado.Properties.Settings.Default.usrPreguntarAlSalir = checkPreguntarSalir.Checked;
			NewConsolidado.Properties.Settings.Default.usrPreguntaEliminar = checkPreguntarEliminar.Checked;
			NewConsolidado.Properties.Settings.Default.usrPreguntaFormulariosSalir = checkPreguntarFormulariosSalir.Checked;
			NewConsolidado.Properties.Settings.Default.usrRecorarPosicionFormularios = checkRecordarPosicionFormulario.Checked;
			#endregion

			#region Aspecto
			NewConsolidado.Properties.Settings.Default.usrDiseñoToolbar = comboDespliegueToolbar.SelectedIndex;
			NewConsolidado.Properties.Settings.Default.usrDiseñoBotones = comboDespliegueBotones.SelectedIndex;
			#endregion
			#endregion

			#region Debug
			#region Conexion
			//NewConsolidado.Properties.Settings.Default.appSelecccionBD = (radioProduccion.Checked) ? (int)CFG.Conexion.Produccion : (int)CFG.Conexion.Desarrollo;
			#endregion

			#region Seguimiento
			NewConsolidado.Properties.Settings.Default.myLog4NetDestino = comboEnvioLog.SelectedIndex;
			NewConsolidado.Properties.Settings.Default.myLog4NetNivel = comboNivelLog.SelectedIndex;
			#endregion

			#region Hidden
			NewConsolidado.Properties.Settings.Default.usrMuestraCamposOcultos = checkMuestraCampos.Checked;
			NewConsolidado.Properties.Settings.Default.usrMuestraColumnasOcultas = checkMuestraColumnas.Checked;
			#endregion
			#endregion
			NewConsolidado.Properties.Settings.Default.Save();
		}
		private void buttonActualizaCodigo_Click(object sender, EventArgs e)
		{
			ActualizarCodigo oForm = new ActualizarCodigo();
			oForm.StartPosition = FormStartPosition.CenterScreen;
			oForm.ShowIcon = false;
			oForm.ShowInTaskbar = false;
			oForm.ShowDialog();
		}
		private void BotonEjecutarCargaDynamics()
		{
			this.Cursor = Cursors.WaitCursor;
			try
			{
				BOEjecutar oBO = new BOEjecutar();
				oBO.EjecutaCarga();

			}
			catch (Exception ex)
			{
				hLog.msgFatal("Error al ejecutar la accion {" + ex.Message + "}");
			}
			this.Cursor = Cursors.Default;
		}
        //private void BotonCambiaUsuarioAdominguezv()
        //{
        //    Globales.UsuarioActivo = @"ICAFAL\adominguezv";
        //    oMdi.CambiaLabelusuario();
        //}
        //private void BotonCambiaUsuarioCcarrascom()
        //{
        //    Globales.UsuarioActivo = @"ICAFAL\ccarrascom";
        //    oMdi.CambiaLabelusuario();
        //}
		private void BotonConcurrencias()
		{
			this.Cursor = Cursors.WaitCursor;
			try
			{
				BOConcurrencias oBO = new BOConcurrencias();
				oBO.LiberaConcurrencia();
			}
			catch (Exception ex)
			{
				hLog.msgError(ex.Message);
			}
			this.Cursor = Cursors.Default;
		}
	}
}
	