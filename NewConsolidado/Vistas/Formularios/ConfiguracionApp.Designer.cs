namespace NewConsolidado.Vistas.Formularios
{
	partial class ConfiguracionApp
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.buttonSalir = new System.Windows.Forms.Button();
			this.buttonGrabar = new System.Windows.Forms.Button();
			this.tabOpciones = new System.Windows.Forms.TabControl();
			this.tabPageGenerales = new System.Windows.Forms.TabPage();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.listLibrosReporte = new System.Windows.Forms.CheckedListBox();
			this.tabPageDespliegue = new System.Windows.Forms.TabPage();
			this.panel2 = new System.Windows.Forms.Panel();
			this.checkRecordarPosicionFormulario = new System.Windows.Forms.CheckBox();
			this.checkPreguntarFormulariosSalir = new System.Windows.Forms.CheckBox();
			this.checkPreguntarEliminar = new System.Windows.Forms.CheckBox();
			this.checkPreguntarSalir = new System.Windows.Forms.CheckBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.comboDespliegueToolbar = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.comboDespliegueBotones = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.tabPageAdministrador = new System.Windows.Forms.TabPage();
			this.label5 = new System.Windows.Forms.Label();
			this.buttonEjecutarCarga = new System.Windows.Forms.Button();
			this.tabPageDebug = new System.Windows.Forms.TabPage();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPageConexion = new System.Windows.Forms.TabPage();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.radioDesarrollo = new System.Windows.Forms.RadioButton();
			this.radioProduccion = new System.Windows.Forms.RadioButton();
			this.laConexion = new System.Windows.Forms.Label();
			this.tabPageSeguimiento = new System.Windows.Forms.TabPage();
			this.label2 = new System.Windows.Forms.Label();
			this.comboNivelLog = new System.Windows.Forms.ComboBox();
			this.comboEnvioLog = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.tabPageHidden = new System.Windows.Forms.TabPage();
			this.checkMuestraColumnas = new System.Windows.Forms.CheckBox();
			this.checkMuestraCampos = new System.Windows.Forms.CheckBox();
			this.tabPageProcedimientos = new System.Windows.Forms.TabPage();
			this.buttonActualizaCodigo = new System.Windows.Forms.Button();
			this.buttonDebugCambiaUsuario2 = new System.Windows.Forms.Button();
			this.buttonDebugCambiaUsuario = new System.Windows.Forms.Button();
			this.buttonAD = new System.Windows.Forms.Button();
			this.buttonCambioConexion = new System.Windows.Forms.Button();
			this.pictureConfiguracion = new System.Windows.Forms.PictureBox();
			this.label6 = new System.Windows.Forms.Label();
			this.buttonConcurrencias = new System.Windows.Forms.Button();
			this.tabOpciones.SuspendLayout();
			this.tabPageGenerales.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.tabPageDespliegue.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel1.SuspendLayout();
			this.tabPageAdministrador.SuspendLayout();
			this.tabPageDebug.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPageConexion.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.tabPageSeguimiento.SuspendLayout();
			this.tabPageHidden.SuspendLayout();
			this.tabPageProcedimientos.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureConfiguracion)).BeginInit();
			this.SuspendLayout();
			// 
			// buttonSalir
			// 
			this.buttonSalir.Location = new System.Drawing.Point(404, 289);
			this.buttonSalir.Name = "buttonSalir";
			this.buttonSalir.Size = new System.Drawing.Size(75, 33);
			this.buttonSalir.TabIndex = 0;
			this.buttonSalir.Text = "Salir";
			this.buttonSalir.UseVisualStyleBackColor = true;
			this.buttonSalir.Click += new System.EventHandler(this.buttonSalir_Click);
			// 
			// buttonGrabar
			// 
			this.buttonGrabar.Location = new System.Drawing.Point(296, 289);
			this.buttonGrabar.Name = "buttonGrabar";
			this.buttonGrabar.Size = new System.Drawing.Size(75, 33);
			this.buttonGrabar.TabIndex = 1;
			this.buttonGrabar.Text = "Grabar";
			this.buttonGrabar.UseVisualStyleBackColor = true;
			this.buttonGrabar.Click += new System.EventHandler(this.buttonGrabar_Click);
			// 
			// tabOpciones
			// 
			this.tabOpciones.Controls.Add(this.tabPageGenerales);
			this.tabOpciones.Controls.Add(this.tabPageDespliegue);
			this.tabOpciones.Controls.Add(this.tabPageAdministrador);
			this.tabOpciones.Controls.Add(this.tabPageDebug);
			this.tabOpciones.Location = new System.Drawing.Point(12, 12);
			this.tabOpciones.Multiline = true;
			this.tabOpciones.Name = "tabOpciones";
			this.tabOpciones.SelectedIndex = 0;
			this.tabOpciones.Size = new System.Drawing.Size(503, 271);
			this.tabOpciones.TabIndex = 4;
			// 
			// tabPageGenerales
			// 
			this.tabPageGenerales.Controls.Add(this.groupBox1);
			this.tabPageGenerales.Location = new System.Drawing.Point(4, 22);
			this.tabPageGenerales.Name = "tabPageGenerales";
			this.tabPageGenerales.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageGenerales.Size = new System.Drawing.Size(495, 245);
			this.tabPageGenerales.TabIndex = 1;
			this.tabPageGenerales.Text = "Reportes";
			this.tabPageGenerales.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.listLibrosReporte);
			this.groupBox1.Location = new System.Drawing.Point(16, 15);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(227, 176);
			this.groupBox1.TabIndex = 5;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Libros seleccionados para los reportes";
			// 
			// listLibrosReporte
			// 
			this.listLibrosReporte.FormattingEnabled = true;
			this.listLibrosReporte.Location = new System.Drawing.Point(16, 22);
			this.listLibrosReporte.Name = "listLibrosReporte";
			this.listLibrosReporte.Size = new System.Drawing.Size(197, 139);
			this.listLibrosReporte.TabIndex = 0;
			// 
			// tabPageDespliegue
			// 
			this.tabPageDespliegue.Controls.Add(this.panel2);
			this.tabPageDespliegue.Controls.Add(this.panel1);
			this.tabPageDespliegue.Location = new System.Drawing.Point(4, 22);
			this.tabPageDespliegue.Name = "tabPageDespliegue";
			this.tabPageDespliegue.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageDespliegue.Size = new System.Drawing.Size(495, 245);
			this.tabPageDespliegue.TabIndex = 0;
			this.tabPageDespliegue.Text = "Aspecto";
			this.tabPageDespliegue.UseVisualStyleBackColor = true;
			// 
			// panel2
			// 
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.checkRecordarPosicionFormulario);
			this.panel2.Controls.Add(this.checkPreguntarFormulariosSalir);
			this.panel2.Controls.Add(this.checkPreguntarEliminar);
			this.panel2.Controls.Add(this.checkPreguntarSalir);
			this.panel2.Location = new System.Drawing.Point(14, 17);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(365, 113);
			this.panel2.TabIndex = 10;
			// 
			// checkRecordarPosicionFormulario
			// 
			this.checkRecordarPosicionFormulario.AutoSize = true;
			this.checkRecordarPosicionFormulario.Location = new System.Drawing.Point(14, 80);
			this.checkRecordarPosicionFormulario.Name = "checkRecordarPosicionFormulario";
			this.checkRecordarPosicionFormulario.Size = new System.Drawing.Size(165, 17);
			this.checkRecordarPosicionFormulario.TabIndex = 10;
			this.checkRecordarPosicionFormulario.Text = "Recordar posición formularios";
			this.checkRecordarPosicionFormulario.UseVisualStyleBackColor = true;
			// 
			// checkPreguntarFormulariosSalir
			// 
			this.checkPreguntarFormulariosSalir.AutoSize = true;
			this.checkPreguntarFormulariosSalir.Location = new System.Drawing.Point(14, 56);
			this.checkPreguntarFormulariosSalir.Name = "checkPreguntarFormulariosSalir";
			this.checkPreguntarFormulariosSalir.Size = new System.Drawing.Size(172, 17);
			this.checkPreguntarFormulariosSalir.TabIndex = 9;
			this.checkPreguntarFormulariosSalir.Text = "Preguntar al salir de formularios";
			this.checkPreguntarFormulariosSalir.UseVisualStyleBackColor = true;
			// 
			// checkPreguntarEliminar
			// 
			this.checkPreguntarEliminar.AutoSize = true;
			this.checkPreguntarEliminar.Location = new System.Drawing.Point(14, 32);
			this.checkPreguntarEliminar.Name = "checkPreguntarEliminar";
			this.checkPreguntarEliminar.Size = new System.Drawing.Size(121, 17);
			this.checkPreguntarEliminar.TabIndex = 8;
			this.checkPreguntarEliminar.Text = "Preguntar al eliminar";
			this.checkPreguntarEliminar.UseVisualStyleBackColor = true;
			// 
			// checkPreguntarSalir
			// 
			this.checkPreguntarSalir.AutoSize = true;
			this.checkPreguntarSalir.Location = new System.Drawing.Point(14, 8);
			this.checkPreguntarSalir.Name = "checkPreguntarSalir";
			this.checkPreguntarSalir.Size = new System.Drawing.Size(181, 17);
			this.checkPreguntarSalir.TabIndex = 7;
			this.checkPreguntarSalir.Text = "Preguntar al salir de la aplicación";
			this.checkPreguntarSalir.UseVisualStyleBackColor = true;
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.comboDespliegueToolbar);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.comboDespliegueBotones);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Location = new System.Drawing.Point(14, 151);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(362, 81);
			this.panel1.TabIndex = 9;
			// 
			// comboDespliegueToolbar
			// 
			this.comboDespliegueToolbar.FormattingEnabled = true;
			this.comboDespliegueToolbar.Location = new System.Drawing.Point(181, 12);
			this.comboDespliegueToolbar.Name = "comboDespliegueToolbar";
			this.comboDespliegueToolbar.Size = new System.Drawing.Size(144, 21);
			this.comboDespliegueToolbar.TabIndex = 4;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(19, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(147, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Tipo de despliegue de toolbar";
			// 
			// comboDespliegueBotones
			// 
			this.comboDespliegueBotones.FormattingEnabled = true;
			this.comboDespliegueBotones.Location = new System.Drawing.Point(181, 40);
			this.comboDespliegueBotones.Name = "comboDespliegueBotones";
			this.comboDespliegueBotones.Size = new System.Drawing.Size(144, 21);
			this.comboDespliegueBotones.TabIndex = 6;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(19, 43);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(156, 13);
			this.label4.TabIndex = 5;
			this.label4.Text = "Tipo de despliegue de botones ";
			// 
			// tabPageAdministrador
			// 
			this.tabPageAdministrador.Controls.Add(this.buttonConcurrencias);
			this.tabPageAdministrador.Controls.Add(this.label6);
			this.tabPageAdministrador.Controls.Add(this.label5);
			this.tabPageAdministrador.Controls.Add(this.buttonEjecutarCarga);
			this.tabPageAdministrador.Location = new System.Drawing.Point(4, 22);
			this.tabPageAdministrador.Name = "tabPageAdministrador";
			this.tabPageAdministrador.Size = new System.Drawing.Size(495, 245);
			this.tabPageAdministrador.TabIndex = 3;
			this.tabPageAdministrador.Text = "Administrador";
			this.tabPageAdministrador.UseVisualStyleBackColor = true;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(24, 32);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(257, 13);
			this.label5.TabIndex = 1;
			this.label5.Text = "Ejecutar proceso de carga de datos desde Dynamics";
			// 
			// buttonEjecutarCarga
			// 
			this.buttonEjecutarCarga.Location = new System.Drawing.Point(347, 22);
			this.buttonEjecutarCarga.Name = "buttonEjecutarCarga";
			this.buttonEjecutarCarga.Size = new System.Drawing.Size(96, 32);
			this.buttonEjecutarCarga.TabIndex = 0;
			this.buttonEjecutarCarga.Text = "Ejecutar";
			this.buttonEjecutarCarga.UseVisualStyleBackColor = true;
			this.buttonEjecutarCarga.Click += new System.EventHandler(this.buttonEjecutarCarga_Click);
			// 
			// tabPageDebug
			// 
			this.tabPageDebug.Controls.Add(this.tabControl1);
			this.tabPageDebug.Location = new System.Drawing.Point(4, 22);
			this.tabPageDebug.Name = "tabPageDebug";
			this.tabPageDebug.Size = new System.Drawing.Size(495, 245);
			this.tabPageDebug.TabIndex = 2;
			this.tabPageDebug.Text = "Debug";
			this.tabPageDebug.UseVisualStyleBackColor = true;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPageConexion);
			this.tabControl1.Controls.Add(this.tabPageSeguimiento);
			this.tabControl1.Controls.Add(this.tabPageHidden);
			this.tabControl1.Controls.Add(this.tabPageProcedimientos);
			this.tabControl1.Location = new System.Drawing.Point(12, 11);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(466, 222);
			this.tabControl1.TabIndex = 29;
			// 
			// tabPageConexion
			// 
			this.tabPageConexion.Controls.Add(this.groupBox2);
			this.tabPageConexion.Location = new System.Drawing.Point(4, 22);
			this.tabPageConexion.Name = "tabPageConexion";
			this.tabPageConexion.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageConexion.Size = new System.Drawing.Size(458, 196);
			this.tabPageConexion.TabIndex = 0;
			this.tabPageConexion.Text = "Conexión";
			this.tabPageConexion.UseVisualStyleBackColor = true;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.radioDesarrollo);
			this.groupBox2.Controls.Add(this.radioProduccion);
			this.groupBox2.Controls.Add(this.laConexion);
			this.groupBox2.Location = new System.Drawing.Point(16, 18);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(418, 137);
			this.groupBox2.TabIndex = 30;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Conexion";
			// 
			// radioDesarrollo
			// 
			this.radioDesarrollo.AutoSize = true;
			this.radioDesarrollo.Location = new System.Drawing.Point(234, 33);
			this.radioDesarrollo.Name = "radioDesarrollo";
			this.radioDesarrollo.Size = new System.Drawing.Size(72, 17);
			this.radioDesarrollo.TabIndex = 33;
			this.radioDesarrollo.TabStop = true;
			this.radioDesarrollo.Text = "Desarrollo";
			this.radioDesarrollo.UseVisualStyleBackColor = true;
			this.radioDesarrollo.CheckedChanged += new System.EventHandler(this.radioDesarrollo_CheckedChanged);
			// 
			// radioProduccion
			// 
			this.radioProduccion.AutoSize = true;
			this.radioProduccion.Location = new System.Drawing.Point(43, 33);
			this.radioProduccion.Name = "radioProduccion";
			this.radioProduccion.Size = new System.Drawing.Size(79, 17);
			this.radioProduccion.TabIndex = 32;
			this.radioProduccion.TabStop = true;
			this.radioProduccion.Text = "Producción";
			this.radioProduccion.UseVisualStyleBackColor = true;
			this.radioProduccion.CheckedChanged += new System.EventHandler(this.radioProduccion_CheckedChanged);
			// 
			// laConexion
			// 
			this.laConexion.AutoEllipsis = true;
			this.laConexion.Location = new System.Drawing.Point(17, 78);
			this.laConexion.Name = "laConexion";
			this.laConexion.Size = new System.Drawing.Size(379, 39);
			this.laConexion.TabIndex = 30;
			this.laConexion.Text = "laConexion";
			// 
			// tabPageSeguimiento
			// 
			this.tabPageSeguimiento.Controls.Add(this.label2);
			this.tabPageSeguimiento.Controls.Add(this.comboNivelLog);
			this.tabPageSeguimiento.Controls.Add(this.comboEnvioLog);
			this.tabPageSeguimiento.Controls.Add(this.label3);
			this.tabPageSeguimiento.Location = new System.Drawing.Point(4, 22);
			this.tabPageSeguimiento.Name = "tabPageSeguimiento";
			this.tabPageSeguimiento.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageSeguimiento.Size = new System.Drawing.Size(458, 196);
			this.tabPageSeguimiento.TabIndex = 2;
			this.tabPageSeguimiento.Text = "Seguimiento";
			this.tabPageSeguimiento.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(35, 28);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(67, 13);
			this.label2.TabIndex = 9;
			this.label2.Text = "Nivel de Log";
			// 
			// comboNivelLog
			// 
			this.comboNivelLog.FormattingEnabled = true;
			this.comboNivelLog.Location = new System.Drawing.Point(122, 25);
			this.comboNivelLog.Name = "comboNivelLog";
			this.comboNivelLog.Size = new System.Drawing.Size(121, 21);
			this.comboNivelLog.TabIndex = 10;
			// 
			// comboEnvioLog
			// 
			this.comboEnvioLog.FormattingEnabled = true;
			this.comboEnvioLog.Location = new System.Drawing.Point(122, 80);
			this.comboEnvioLog.Name = "comboEnvioLog";
			this.comboEnvioLog.Size = new System.Drawing.Size(121, 21);
			this.comboEnvioLog.TabIndex = 12;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(35, 83);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(66, 13);
			this.label3.TabIndex = 11;
			this.label3.Text = "Envio de log";
			// 
			// tabPageHidden
			// 
			this.tabPageHidden.Controls.Add(this.checkMuestraColumnas);
			this.tabPageHidden.Controls.Add(this.checkMuestraCampos);
			this.tabPageHidden.Location = new System.Drawing.Point(4, 22);
			this.tabPageHidden.Name = "tabPageHidden";
			this.tabPageHidden.Size = new System.Drawing.Size(458, 196);
			this.tabPageHidden.TabIndex = 3;
			this.tabPageHidden.Text = "Hidden";
			this.tabPageHidden.UseVisualStyleBackColor = true;
			// 
			// checkMuestraColumnas
			// 
			this.checkMuestraColumnas.AutoSize = true;
			this.checkMuestraColumnas.Location = new System.Drawing.Point(63, 67);
			this.checkMuestraColumnas.Name = "checkMuestraColumnas";
			this.checkMuestraColumnas.Size = new System.Drawing.Size(149, 17);
			this.checkMuestraColumnas.TabIndex = 5;
			this.checkMuestraColumnas.Text = "Mostrar Columnas Ocultas";
			this.checkMuestraColumnas.UseVisualStyleBackColor = true;
			// 
			// checkMuestraCampos
			// 
			this.checkMuestraCampos.AutoSize = true;
			this.checkMuestraCampos.Location = new System.Drawing.Point(63, 44);
			this.checkMuestraCampos.Name = "checkMuestraCampos";
			this.checkMuestraCampos.Size = new System.Drawing.Size(144, 17);
			this.checkMuestraCampos.TabIndex = 6;
			this.checkMuestraCampos.Text = "Muestra Campos Ocultos";
			this.checkMuestraCampos.UseVisualStyleBackColor = true;
			// 
			// tabPageProcedimientos
			// 
			this.tabPageProcedimientos.Controls.Add(this.buttonActualizaCodigo);
			this.tabPageProcedimientos.Controls.Add(this.buttonDebugCambiaUsuario2);
			this.tabPageProcedimientos.Controls.Add(this.buttonDebugCambiaUsuario);
			this.tabPageProcedimientos.Controls.Add(this.buttonAD);
			this.tabPageProcedimientos.Controls.Add(this.buttonCambioConexion);
			this.tabPageProcedimientos.Location = new System.Drawing.Point(4, 22);
			this.tabPageProcedimientos.Name = "tabPageProcedimientos";
			this.tabPageProcedimientos.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageProcedimientos.Size = new System.Drawing.Size(458, 196);
			this.tabPageProcedimientos.TabIndex = 1;
			this.tabPageProcedimientos.Text = "Acciones";
			this.tabPageProcedimientos.UseVisualStyleBackColor = true;
			// 
			// buttonActualizaCodigo
			// 
			this.buttonActualizaCodigo.Location = new System.Drawing.Point(19, 34);
			this.buttonActualizaCodigo.Name = "buttonActualizaCodigo";
			this.buttonActualizaCodigo.Size = new System.Drawing.Size(207, 21);
			this.buttonActualizaCodigo.TabIndex = 32;
			this.buttonActualizaCodigo.Text = "Actualizar codigo";
			this.buttonActualizaCodigo.UseVisualStyleBackColor = true;
			this.buttonActualizaCodigo.Click += new System.EventHandler(this.buttonActualizaCodigo_Click);
			// 
			// buttonDebugCambiaUsuario2
			// 
			this.buttonDebugCambiaUsuario2.Location = new System.Drawing.Point(232, 6);
			this.buttonDebugCambiaUsuario2.Name = "buttonDebugCambiaUsuario2";
			this.buttonDebugCambiaUsuario2.Size = new System.Drawing.Size(179, 23);
			this.buttonDebugCambiaUsuario2.TabIndex = 31;
			this.buttonDebugCambiaUsuario2.Text = "Volver a carrascom";
			this.buttonDebugCambiaUsuario2.UseVisualStyleBackColor = true;
			//this.buttonDebugCambiaUsuario2.Click += new System.EventHandler(this.buttonDebugCambiaUsuario2_Click);
			// 
			// buttonDebugCambiaUsuario
			// 
			this.buttonDebugCambiaUsuario.Location = new System.Drawing.Point(19, 6);
			this.buttonDebugCambiaUsuario.Name = "buttonDebugCambiaUsuario";
			this.buttonDebugCambiaUsuario.Size = new System.Drawing.Size(207, 23);
			this.buttonDebugCambiaUsuario.TabIndex = 30;
			this.buttonDebugCambiaUsuario.Text = "cambia usuario adominguez";
			this.buttonDebugCambiaUsuario.UseVisualStyleBackColor = true;
			//this.buttonDebugCambiaUsuario.Click += new System.EventHandler(this.buttonDebugCambiaUsuario_Click);
			// 
			// buttonAD
			// 
			this.buttonAD.Location = new System.Drawing.Point(306, 150);
			this.buttonAD.Name = "buttonAD";
			this.buttonAD.Size = new System.Drawing.Size(120, 23);
			this.buttonAD.TabIndex = 28;
			this.buttonAD.Text = "Conexion AD";
			this.buttonAD.UseVisualStyleBackColor = true;
			this.buttonAD.Click += new System.EventHandler(this.buttonAD_Click);
			// 
			// buttonCambioConexion
			// 
			this.buttonCambioConexion.Location = new System.Drawing.Point(303, 121);
			this.buttonCambioConexion.Name = "buttonCambioConexion";
			this.buttonCambioConexion.Size = new System.Drawing.Size(144, 23);
			this.buttonCambioConexion.TabIndex = 9;
			this.buttonCambioConexion.Text = "Conexion por usuario";
			this.buttonCambioConexion.UseVisualStyleBackColor = true;
			this.buttonCambioConexion.Click += new System.EventHandler(this.buttonCambioConexion_Click);
			// 
			// pictureConfiguracion
			// 
			this.pictureConfiguracion.Image = global::NewConsolidado.Properties.Resources.rsc_24_Preferencias;
			this.pictureConfiguracion.Location = new System.Drawing.Point(12, 289);
			this.pictureConfiguracion.Name = "pictureConfiguracion";
			this.pictureConfiguracion.Size = new System.Drawing.Size(26, 22);
			this.pictureConfiguracion.TabIndex = 5;
			this.pictureConfiguracion.TabStop = false;
			this.pictureConfiguracion.DoubleClick += new System.EventHandler(this.pictureBox1_DoubleClick);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(24, 72);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(277, 13);
			this.label6.TabIndex = 2;
			this.label6.Text = "Liberar todos los consolidados tomados en concurrencias";
			// 
			// buttonConcurrencias
			// 
			this.buttonConcurrencias.Location = new System.Drawing.Point(347, 62);
			this.buttonConcurrencias.Name = "buttonConcurrencias";
			this.buttonConcurrencias.Size = new System.Drawing.Size(96, 32);
			this.buttonConcurrencias.TabIndex = 3;
			this.buttonConcurrencias.Text = "Ejecutar";
			this.buttonConcurrencias.UseVisualStyleBackColor = true;
			this.buttonConcurrencias.Click += new System.EventHandler(this.buttonConcurrencias_Click);
			// 
			// ConfiguracionApp
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(527, 337);
			this.Controls.Add(this.pictureConfiguracion);
			this.Controls.Add(this.tabOpciones);
			this.Controls.Add(this.buttonGrabar);
			this.Controls.Add(this.buttonSalir);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "ConfiguracionApp";
			this.ShowIcon = false;
			this.Text = "ConfiguracionApp";
			this.Load += new System.EventHandler(this.ConfiguracionApp_Load);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ConfiguracionApp_FormClosed);
			this.tabOpciones.ResumeLayout(false);
			this.tabPageGenerales.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.tabPageDespliegue.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.tabPageAdministrador.ResumeLayout(false);
			this.tabPageAdministrador.PerformLayout();
			this.tabPageDebug.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.tabPageConexion.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.tabPageSeguimiento.ResumeLayout(false);
			this.tabPageSeguimiento.PerformLayout();
			this.tabPageHidden.ResumeLayout(false);
			this.tabPageHidden.PerformLayout();
			this.tabPageProcedimientos.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureConfiguracion)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button buttonSalir;
		private System.Windows.Forms.Button buttonGrabar;
		private System.Windows.Forms.TabControl tabOpciones;
		private System.Windows.Forms.TabPage tabPageDespliegue;
		private System.Windows.Forms.ComboBox comboDespliegueToolbar;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TabPage tabPageGenerales;
		private System.Windows.Forms.ComboBox comboDespliegueBotones;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TabPage tabPageDebug;
		private System.Windows.Forms.PictureBox pictureConfiguracion;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button buttonCambioConexion;
		private System.Windows.Forms.Button buttonAD;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPageConexion;
		private System.Windows.Forms.TabPage tabPageProcedimientos;
		private System.Windows.Forms.Button buttonDebugCambiaUsuario2;
		private System.Windows.Forms.Button buttonDebugCambiaUsuario;
		private System.Windows.Forms.CheckedListBox listLibrosReporte;
		private System.Windows.Forms.CheckBox checkPreguntarEliminar;
		private System.Windows.Forms.CheckBox checkPreguntarSalir;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.CheckBox checkPreguntarFormulariosSalir;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.CheckBox checkRecordarPosicionFormulario;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.RadioButton radioDesarrollo;
		private System.Windows.Forms.RadioButton radioProduccion;
		private System.Windows.Forms.Label laConexion;
		private System.Windows.Forms.TabPage tabPageSeguimiento;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox comboNivelLog;
		private System.Windows.Forms.ComboBox comboEnvioLog;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TabPage tabPageHidden;
		private System.Windows.Forms.CheckBox checkMuestraColumnas;
		private System.Windows.Forms.CheckBox checkMuestraCampos;
		private System.Windows.Forms.Button buttonActualizaCodigo;
		private System.Windows.Forms.TabPage tabPageAdministrador;
		private System.Windows.Forms.Button buttonEjecutarCarga;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button buttonConcurrencias;
		private System.Windows.Forms.Label label6;

	}
}