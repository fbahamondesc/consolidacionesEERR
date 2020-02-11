namespace NewConsolidado.Vistas.Formularios
{
	partial class MantenedorConsolidados_Empresas
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
			this.checkEmpresaMatriz = new System.Windows.Forms.CheckBox();
			this.textEmpresaCodigo = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.textEmpresaParticipacion = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.textEmpesaObservaciones = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.textEmpresaDescripcion = new System.Windows.Forms.TextBox();
			this.buttonBuscarEmpresa = new System.Windows.Forms.Button();
			this.buttonSalir = new System.Windows.Forms.Button();
			this.buttonGrabar = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.textDescripcionPadre = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// checkEmpresaMatriz
			// 
			this.checkEmpresaMatriz.AutoSize = true;
			this.checkEmpresaMatriz.Location = new System.Drawing.Point(115, 173);
			this.checkEmpresaMatriz.Name = "checkEmpresaMatriz";
			this.checkEmpresaMatriz.Size = new System.Drawing.Size(54, 17);
			this.checkEmpresaMatriz.TabIndex = 67;
			this.checkEmpresaMatriz.Text = "Matriz";
			this.checkEmpresaMatriz.UseVisualStyleBackColor = true;
			// 
			// textEmpresaCodigo
			// 
			this.textEmpresaCodigo.Location = new System.Drawing.Point(115, 37);
			this.textEmpresaCodigo.Name = "textEmpresaCodigo";
			this.textEmpresaCodigo.Size = new System.Drawing.Size(98, 20);
			this.textEmpresaCodigo.TabIndex = 66;
			this.textEmpresaCodigo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textEmpresaCodigo_KeyUp);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(15, 40);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(40, 13);
			this.label5.TabIndex = 65;
			this.label5.Text = "Código";
			// 
			// textEmpresaParticipacion
			// 
			this.textEmpresaParticipacion.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.textEmpresaParticipacion.Location = new System.Drawing.Point(115, 147);
			this.textEmpresaParticipacion.Name = "textEmpresaParticipacion";
			this.textEmpresaParticipacion.Size = new System.Drawing.Size(149, 20);
			this.textEmpresaParticipacion.TabIndex = 64;
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(15, 150);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(68, 13);
			this.label12.TabIndex = 63;
			this.label12.Text = "Participación";
			// 
			// textEmpesaObservaciones
			// 
			this.textEmpesaObservaciones.AcceptsReturn = true;
			this.textEmpesaObservaciones.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.textEmpesaObservaciones.Location = new System.Drawing.Point(115, 86);
			this.textEmpesaObservaciones.MaxLength = 2000;
			this.textEmpesaObservaciones.Multiline = true;
			this.textEmpesaObservaciones.Name = "textEmpesaObservaciones";
			this.textEmpesaObservaciones.Size = new System.Drawing.Size(309, 57);
			this.textEmpesaObservaciones.TabIndex = 62;
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(15, 89);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(78, 13);
			this.label13.TabIndex = 61;
			this.label13.Text = "Observaciones";
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(15, 64);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(63, 13);
			this.label14.TabIndex = 60;
			this.label14.Text = "Descripción";
			// 
			// textEmpresaDescripcion
			// 
			this.textEmpresaDescripcion.BackColor = System.Drawing.SystemColors.Control;
			this.textEmpresaDescripcion.Location = new System.Drawing.Point(115, 61);
			this.textEmpresaDescripcion.Name = "textEmpresaDescripcion";
			this.textEmpresaDescripcion.ReadOnly = true;
			this.textEmpresaDescripcion.Size = new System.Drawing.Size(309, 20);
			this.textEmpresaDescripcion.TabIndex = 59;
			// 
			// buttonBuscarEmpresa
			// 
			this.buttonBuscarEmpresa.Image = global::NewConsolidado.Properties.Resources.rsc_16_Buscar;
			this.buttonBuscarEmpresa.Location = new System.Drawing.Point(236, 33);
			this.buttonBuscarEmpresa.Name = "buttonBuscarEmpresa";
			this.buttonBuscarEmpresa.Size = new System.Drawing.Size(75, 24);
			this.buttonBuscarEmpresa.TabIndex = 58;
			this.buttonBuscarEmpresa.Text = "Buscar";
			this.buttonBuscarEmpresa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.buttonBuscarEmpresa.UseVisualStyleBackColor = true;
			this.buttonBuscarEmpresa.Click += new System.EventHandler(this.buttonBuscarEmpresa_Click);
			// 
			// buttonSalir
			// 
			this.buttonSalir.Location = new System.Drawing.Point(320, 201);
			this.buttonSalir.Name = "buttonSalir";
			this.buttonSalir.Size = new System.Drawing.Size(104, 36);
			this.buttonSalir.TabIndex = 69;
			this.buttonSalir.Text = "button2";
			this.buttonSalir.UseVisualStyleBackColor = true;
			this.buttonSalir.Click += new System.EventHandler(this.buttonSalir_Click);
			// 
			// buttonGrabar
			// 
			this.buttonGrabar.Location = new System.Drawing.Point(207, 201);
			this.buttonGrabar.Name = "buttonGrabar";
			this.buttonGrabar.Size = new System.Drawing.Size(104, 36);
			this.buttonGrabar.TabIndex = 68;
			this.buttonGrabar.Text = "button1";
			this.buttonGrabar.UseVisualStyleBackColor = true;
			this.buttonGrabar.Click += new System.EventHandler(this.buttonGrabar_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(15, 14);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(96, 13);
			this.label1.TabIndex = 70;
			this.label1.Text = "Consolidado Padre";
			// 
			// textDescripcionPadre
			// 
			this.textDescripcionPadre.Location = new System.Drawing.Point(115, 11);
			this.textDescripcionPadre.Name = "textDescripcionPadre";
			this.textDescripcionPadre.ReadOnly = true;
			this.textDescripcionPadre.Size = new System.Drawing.Size(309, 20);
			this.textDescripcionPadre.TabIndex = 71;
			// 
			// MantenedorConsolidados_Empresas
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(438, 249);
			this.Controls.Add(this.textDescripcionPadre);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.buttonSalir);
			this.Controls.Add(this.buttonGrabar);
			this.Controls.Add(this.checkEmpresaMatriz);
			this.Controls.Add(this.textEmpresaCodigo);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.textEmpresaParticipacion);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.textEmpesaObservaciones);
			this.Controls.Add(this.label13);
			this.Controls.Add(this.label14);
			this.Controls.Add(this.textEmpresaDescripcion);
			this.Controls.Add(this.buttonBuscarEmpresa);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "MantenedorConsolidados_Empresas";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "MantenedorConsolidados_Empresas";
			this.Load += new System.EventHandler(this.MantenedorConsolidados_Empresas_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.CheckBox checkEmpresaMatriz;
		private System.Windows.Forms.TextBox textEmpresaCodigo;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textEmpresaParticipacion;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox textEmpesaObservaciones;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.TextBox textEmpresaDescripcion;
		private System.Windows.Forms.Button buttonBuscarEmpresa;
		private System.Windows.Forms.Button buttonSalir;
		private System.Windows.Forms.Button buttonGrabar;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textDescripcionPadre;
	}
}