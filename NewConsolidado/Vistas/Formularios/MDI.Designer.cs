namespace NewConsolidado.Vistas.Formularios
{
	partial class MDI
	{
		/// <summary>
		/// Variable del diseñador requerida.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Limpiar los recursos que se estén utilizando.
		/// </summary>
		/// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Código generado por el Diseñador de Windows Forms

		/// <summary>
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido del método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MDI));
            this.mnuPrincipal = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mantenedoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compañiasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.gruposToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.conceptosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cuentasContablesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.plantillaConceptosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.consolidadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mantenedorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ingresosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saldosContablesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aplicaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuracionAplicaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.cambiarAAdministradorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ventanasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accederAUltimaVersiónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.acercaDeLaAplicaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabelUsuario = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLabelConcurrencias = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLabelVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusConexion = new System.Windows.Forms.ToolStripStatusLabel();
            this.timerConcurrencias = new System.Windows.Forms.Timer(this.components);
            this.mnuPrincipal.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuPrincipal
            // 
            this.mnuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.mantenedoresToolStripMenuItem,
            this.ingresosToolStripMenuItem,
            this.aplicaciónToolStripMenuItem,
            this.ventanasToolStripMenuItem,
            this.ayudaToolStripMenuItem});
            this.mnuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.mnuPrincipal.MdiWindowListItem = this.ventanasToolStripMenuItem;
            this.mnuPrincipal.Name = "mnuPrincipal";
            this.mnuPrincipal.Size = new System.Drawing.Size(523, 24);
            this.mnuPrincipal.TabIndex = 1;
            this.mnuPrincipal.Text = "mnuPrincipal";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.archivoToolStripMenuItem.Image = global::NewConsolidado.Properties.Resources.rsc_24_SalirApp;
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(28, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            this.archivoToolStripMenuItem.Click += new System.EventHandler(this.archivoToolStripMenuItem_Click);
            // 
            // mantenedoresToolStripMenuItem
            // 
            this.mantenedoresToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.compañiasToolStripMenuItem,
            this.toolStripSeparator1,
            this.gruposToolStripMenuItem,
            this.conceptosToolStripMenuItem,
            this.cuentasContablesToolStripMenuItem,
            this.plantillaConceptosToolStripMenuItem,
            this.toolStripSeparator2,
            this.consolidadosToolStripMenuItem,
            this.toolStripSeparator3,
            this.mantenedorToolStripMenuItem});
            this.mantenedoresToolStripMenuItem.Name = "mantenedoresToolStripMenuItem";
            this.mantenedoresToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.mantenedoresToolStripMenuItem.Text = "Mantenedores";
            // 
            // compañiasToolStripMenuItem
            // 
            this.compañiasToolStripMenuItem.Name = "compañiasToolStripMenuItem";
            this.compañiasToolStripMenuItem.Size = new System.Drawing.Size(330, 22);
            this.compañiasToolStripMenuItem.Text = "Maestro de Compañias";
            this.compañiasToolStripMenuItem.Click += new System.EventHandler(this.compañiasToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(327, 6);
            // 
            // gruposToolStripMenuItem
            // 
            this.gruposToolStripMenuItem.Name = "gruposToolStripMenuItem";
            this.gruposToolStripMenuItem.Size = new System.Drawing.Size(330, 22);
            this.gruposToolStripMenuItem.Text = "Maestro de Grupos";
            this.gruposToolStripMenuItem.Click += new System.EventHandler(this.gruposToolStripMenuItem_Click);
            // 
            // conceptosToolStripMenuItem
            // 
            this.conceptosToolStripMenuItem.Name = "conceptosToolStripMenuItem";
            this.conceptosToolStripMenuItem.Size = new System.Drawing.Size(330, 22);
            this.conceptosToolStripMenuItem.Text = "Maestro de Conceptos";
            this.conceptosToolStripMenuItem.Click += new System.EventHandler(this.conceptosToolStripMenuItem_Click);
            // 
            // cuentasContablesToolStripMenuItem
            // 
            this.cuentasContablesToolStripMenuItem.Name = "cuentasContablesToolStripMenuItem";
            this.cuentasContablesToolStripMenuItem.Size = new System.Drawing.Size(330, 22);
            this.cuentasContablesToolStripMenuItem.Text = "Maestro de Cuentas Contables";
            this.cuentasContablesToolStripMenuItem.Click += new System.EventHandler(this.cuentasContablesToolStripMenuItem_Click);
            // 
            // plantillaConceptosToolStripMenuItem
            // 
            this.plantillaConceptosToolStripMenuItem.Name = "plantillaConceptosToolStripMenuItem";
            this.plantillaConceptosToolStripMenuItem.Size = new System.Drawing.Size(330, 22);
            this.plantillaConceptosToolStripMenuItem.Text = "Maestro de Asociacion Grupo/Concepto/Cuenta";
            this.plantillaConceptosToolStripMenuItem.Click += new System.EventHandler(this.plantillaConceptosToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(327, 6);
            // 
            // consolidadosToolStripMenuItem
            // 
            this.consolidadosToolStripMenuItem.Image = global::NewConsolidado.Properties.Resources.rsc_16_Consolidados;
            this.consolidadosToolStripMenuItem.Name = "consolidadosToolStripMenuItem";
            this.consolidadosToolStripMenuItem.Size = new System.Drawing.Size(330, 22);
            this.consolidadosToolStripMenuItem.Text = "Mantenedor de Consolidados";
            this.consolidadosToolStripMenuItem.Click += new System.EventHandler(this.consolidadosToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(327, 6);
            // 
            // mantenedorToolStripMenuItem
            // 
            this.mantenedorToolStripMenuItem.Name = "mantenedorToolStripMenuItem";
            this.mantenedorToolStripMenuItem.Size = new System.Drawing.Size(330, 22);
            this.mantenedorToolStripMenuItem.Text = "Mantenedor Configuracion Ajustes Automaticos";
            this.mantenedorToolStripMenuItem.Click += new System.EventHandler(this.mantenedorToolStripMenuItem_Click);
            // 
            // ingresosToolStripMenuItem
            // 
            this.ingresosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saldosContablesToolStripMenuItem});
            this.ingresosToolStripMenuItem.Name = "ingresosToolStripMenuItem";
            this.ingresosToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.ingresosToolStripMenuItem.Text = "Ingresos";
            // 
            // saldosContablesToolStripMenuItem
            // 
            this.saldosContablesToolStripMenuItem.Name = "saldosContablesToolStripMenuItem";
            this.saldosContablesToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.saldosContablesToolStripMenuItem.Text = "Saldos Contables";
            this.saldosContablesToolStripMenuItem.Click += new System.EventHandler(this.saldosContablesToolStripMenuItem_Click);
            // 
            // aplicaciónToolStripMenuItem
            // 
            this.aplicaciónToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configuracionAplicaciónToolStripMenuItem,
            this.toolStripSeparator5,
            this.cambiarAAdministradorToolStripMenuItem});
            this.aplicaciónToolStripMenuItem.Name = "aplicaciónToolStripMenuItem";
            this.aplicaciónToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.aplicaciónToolStripMenuItem.Text = "Herramientas";
            // 
            // configuracionAplicaciónToolStripMenuItem
            // 
            this.configuracionAplicaciónToolStripMenuItem.Image = global::NewConsolidado.Properties.Resources.rsc_24_Preferencias;
            this.configuracionAplicaciónToolStripMenuItem.Name = "configuracionAplicaciónToolStripMenuItem";
            this.configuracionAplicaciónToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.configuracionAplicaciónToolStripMenuItem.Text = "Configuracion Aplicación";
            this.configuracionAplicaciónToolStripMenuItem.Click += new System.EventHandler(this.configuracionAplicaciónToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(226, 6);
            // 
            // cambiarAAdministradorToolStripMenuItem
            // 
            this.cambiarAAdministradorToolStripMenuItem.Image = global::NewConsolidado.Properties.Resources.rsc_16_Lock;
            this.cambiarAAdministradorToolStripMenuItem.Name = "cambiarAAdministradorToolStripMenuItem";
            this.cambiarAAdministradorToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.cambiarAAdministradorToolStripMenuItem.Text = "Cambiar credenciales usuario";
            this.cambiarAAdministradorToolStripMenuItem.Click += new System.EventHandler(this.cambiarAAdministradorToolStripMenuItem_Click);
            // 
            // ventanasToolStripMenuItem
            // 
            this.ventanasToolStripMenuItem.Name = "ventanasToolStripMenuItem";
            this.ventanasToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.ventanasToolStripMenuItem.Text = "Ventanas";
            // 
            // ayudaToolStripMenuItem
            // 
            this.ayudaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.accederAUltimaVersiónToolStripMenuItem,
            this.toolStripMenuItem1,
            this.acercaDeLaAplicaciónToolStripMenuItem});
            this.ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            this.ayudaToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.ayudaToolStripMenuItem.Text = "Ayuda";
            // 
            // accederAUltimaVersiónToolStripMenuItem
            // 
            this.accederAUltimaVersiónToolStripMenuItem.Name = "accederAUltimaVersiónToolStripMenuItem";
            this.accederAUltimaVersiónToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.accederAUltimaVersiónToolStripMenuItem.Text = "Acceder a ultima versión";
            this.accederAUltimaVersiónToolStripMenuItem.Click += new System.EventHandler(this.accederAUltimaVersiónToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(201, 6);
            // 
            // acercaDeLaAplicaciónToolStripMenuItem
            // 
            this.acercaDeLaAplicaciónToolStripMenuItem.Name = "acercaDeLaAplicaciónToolStripMenuItem";
            this.acercaDeLaAplicaciónToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.acercaDeLaAplicaciónToolStripMenuItem.Text = "Acerca de la aplicación";
            this.acercaDeLaAplicaciónToolStripMenuItem.Click += new System.EventHandler(this.acercaDeLaAplicaciónToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabelUsuario,
            this.toolStripStatusLabel2,
            this.statusLabelConcurrencias,
            this.toolStripStatusLabel3,
            this.statusLabelVersion,
            this.statusConexion});
            this.statusStrip1.Location = new System.Drawing.Point(0, 204);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(523, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLabelUsuario
            // 
            this.statusLabelUsuario.BackColor = System.Drawing.Color.WhiteSmoke;
            this.statusLabelUsuario.Name = "statusLabelUsuario";
            this.statusLabelUsuario.Size = new System.Drawing.Size(64, 17);
            this.statusLabelUsuario.Text = "Usuario : {}";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(148, 17);
            this.toolStripStatusLabel2.Spring = true;
            // 
            // statusLabelConcurrencias
            // 
            this.statusLabelConcurrencias.Name = "statusLabelConcurrencias";
            this.statusLabelConcurrencias.Size = new System.Drawing.Size(118, 17);
            this.statusLabelConcurrencias.Text = "toolStripStatusLabel1";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(148, 17);
            this.toolStripStatusLabel3.Spring = true;
            // 
            // statusLabelVersion
            // 
            this.statusLabelVersion.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.statusLabelVersion.Name = "statusLabelVersion";
            this.statusLabelVersion.Size = new System.Drawing.Size(15, 17);
            this.statusLabelVersion.Text = "{}";
            this.statusLabelVersion.ToolTipText = "Versión Aplicación";
            // 
            // statusConexion
            // 
            this.statusConexion.BackColor = System.Drawing.SystemColors.MenuBar;
            this.statusConexion.Name = "statusConexion";
            this.statusConexion.Size = new System.Drawing.Size(15, 17);
            this.statusConexion.Text = "[]";
            // 
            // timerConcurrencias
            // 
            this.timerConcurrencias.Tick += new System.EventHandler(this.timerConcurrencias_Tick);
            // 
            // MDI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.ClientSize = new System.Drawing.Size(523, 226);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.mnuPrincipal);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mnuPrincipal;
            this.Name = "MDI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Consolidado EERR";
            this.Load += new System.EventHandler(this.MDI_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MDI_FormClosed);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MDI_FormClosing);
            this.mnuPrincipal.ResumeLayout(false);
            this.mnuPrincipal.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip mnuPrincipal;
		private System.Windows.Forms.ToolStripMenuItem mantenedoresToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ingresosToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem acercaDeLaAplicaciónToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem compañiasToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem gruposToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem cuentasContablesToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem conceptosToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem consolidadosToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saldosContablesToolStripMenuItem;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripMenuItem aplicaciónToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ventanasToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem configuracionAplicaciónToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem plantillaConceptosToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem mantenedorToolStripMenuItem;
		private System.Windows.Forms.ToolStripStatusLabel statusLabelUsuario;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
		private System.Windows.Forms.ToolStripStatusLabel statusLabelVersion;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.ToolStripStatusLabel statusConexion;
		private System.Windows.Forms.ToolStripMenuItem cambiarAAdministradorToolStripMenuItem;
		private System.Windows.Forms.ToolStripStatusLabel statusLabelConcurrencias;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
		private System.Windows.Forms.Timer timerConcurrencias;
        private System.Windows.Forms.ToolStripMenuItem accederAUltimaVersiónToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
	}
}

