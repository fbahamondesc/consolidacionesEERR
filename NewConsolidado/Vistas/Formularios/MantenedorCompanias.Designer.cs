namespace NewConsolidado.Vistas.Formularios
{
	partial class MantenedorCompanias
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
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			this.toolBarra = new System.Windows.Forms.ToolStrip();
			this.toolSalir = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.toolNuevo = new System.Windows.Forms.ToolStripButton();
			this.toolEditar = new System.Windows.Forms.ToolStripButton();
			this.toolEliminar = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.toolCancelar = new System.Windows.Forms.ToolStripButton();
			this.toolGrabar = new System.Windows.Forms.ToolStripButton();
			this.tabControlCompania = new System.Windows.Forms.TabControl();
			this.tabPageLista = new System.Windows.Forms.TabPage();
			this.gridCompanias = new System.Windows.Forms.DataGridView();
			this.colIdCompania = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colRut = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colBaseDatos = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colCuentaEjercicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colCuentaAcumulado = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colidOrigen = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colOrigen = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colidVigencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colVigencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.tabPageMantencion = new System.Windows.Forms.TabPage();
			this.textIdCompania = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.checkVigente = new System.Windows.Forms.CheckBox();
			this.radioManual = new System.Windows.Forms.RadioButton();
			this.radioDynamics = new System.Windows.Forms.RadioButton();
			this.textCuentaAcumulado = new System.Windows.Forms.TextBox();
			this.textCuentaEjercicio = new System.Windows.Forms.TextBox();
			this.textBaseDatos = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.textRUT = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.textNombre = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.nuevaCompañiaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editarCompañiaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.eliminarCompañiaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolBarra.SuspendLayout();
			this.tabControlCompania.SuspendLayout();
			this.tabPageLista.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridCompanias)).BeginInit();
			this.tabPageMantencion.SuspendLayout();
			this.contextMenuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolBarra
			// 
			this.toolBarra.ImageScalingSize = new System.Drawing.Size(24, 24);
			this.toolBarra.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolSalir,
            this.toolStripSeparator3,
            this.toolNuevo,
            this.toolEditar,
            this.toolEliminar,
            this.toolStripSeparator2,
            this.toolCancelar,
            this.toolGrabar});
			this.toolBarra.Location = new System.Drawing.Point(0, 0);
			this.toolBarra.Name = "toolBarra";
			this.toolBarra.Size = new System.Drawing.Size(842, 31);
			this.toolBarra.TabIndex = 2;
			this.toolBarra.Text = "toolBarra";
			// 
			// toolSalir
			// 
			this.toolSalir.Image = global::NewConsolidado.Properties.Resources.rsc_24_SalirForm;
			this.toolSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolSalir.Name = "toolSalir";
			this.toolSalir.Size = new System.Drawing.Size(57, 28);
			this.toolSalir.Text = "Salir";
			this.toolSalir.ToolTipText = "Salir del Mantenedor";
			this.toolSalir.Click += new System.EventHandler(this.toolSalir_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 31);
			// 
			// toolNuevo
			// 
			this.toolNuevo.Image = global::NewConsolidado.Properties.Resources.rsc_24_Nuevo;
			this.toolNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolNuevo.Name = "toolNuevo";
			this.toolNuevo.Size = new System.Drawing.Size(70, 28);
			this.toolNuevo.Text = "Nuevo";
			this.toolNuevo.ToolTipText = "Crear nuevo nodo en el arbol";
			this.toolNuevo.Click += new System.EventHandler(this.toolNuevo_Click);
			// 
			// toolEditar
			// 
			this.toolEditar.Image = global::NewConsolidado.Properties.Resources.rsc_24_Editar;
			this.toolEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolEditar.Name = "toolEditar";
			this.toolEditar.Size = new System.Drawing.Size(65, 28);
			this.toolEditar.Text = "Editar";
			this.toolEditar.ToolTipText = "Editar nodo seleccionado";
			this.toolEditar.Click += new System.EventHandler(this.toolEditar_Click);
			// 
			// toolEliminar
			// 
			this.toolEliminar.Image = global::NewConsolidado.Properties.Resources.rsc_24_Borrar;
			this.toolEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolEliminar.Name = "toolEliminar";
			this.toolEliminar.Size = new System.Drawing.Size(78, 28);
			this.toolEliminar.Text = "Eliminar";
			this.toolEliminar.ToolTipText = "Eliminar nodo seleccionado";
			this.toolEliminar.Click += new System.EventHandler(this.toolEliminar_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
			// 
			// toolCancelar
			// 
			this.toolCancelar.Image = global::NewConsolidado.Properties.Resources.rsc_24_Cancelar;
			this.toolCancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolCancelar.Name = "toolCancelar";
			this.toolCancelar.Size = new System.Drawing.Size(81, 28);
			this.toolCancelar.Text = "Cancelar";
			this.toolCancelar.ToolTipText = "Cancelar acción actual";
			this.toolCancelar.Click += new System.EventHandler(this.toolCancelar_Click);
			// 
			// toolGrabar
			// 
			this.toolGrabar.Image = global::NewConsolidado.Properties.Resources.rsc_24_Grabar;
			this.toolGrabar.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolGrabar.Name = "toolGrabar";
			this.toolGrabar.Size = new System.Drawing.Size(70, 28);
			this.toolGrabar.Text = "Grabar";
			this.toolGrabar.Click += new System.EventHandler(this.toolGrabar_Click);
			// 
			// tabControlCompania
			// 
			this.tabControlCompania.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
									| System.Windows.Forms.AnchorStyles.Left)
									| System.Windows.Forms.AnchorStyles.Right)));
			this.tabControlCompania.Controls.Add(this.tabPageLista);
			this.tabControlCompania.Controls.Add(this.tabPageMantencion);
			this.tabControlCompania.Location = new System.Drawing.Point(11, 35);
			this.tabControlCompania.Name = "tabControlCompania";
			this.tabControlCompania.SelectedIndex = 0;
			this.tabControlCompania.Size = new System.Drawing.Size(819, 352);
			this.tabControlCompania.TabIndex = 3;
			this.tabControlCompania.SelectedIndexChanged += new System.EventHandler(this.tabControlCompania_SelectedIndexChanged);
			// 
			// tabPageLista
			// 
			this.tabPageLista.Controls.Add(this.gridCompanias);
			this.tabPageLista.Location = new System.Drawing.Point(4, 22);
			this.tabPageLista.Name = "tabPageLista";
			this.tabPageLista.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageLista.Size = new System.Drawing.Size(811, 326);
			this.tabPageLista.TabIndex = 0;
			this.tabPageLista.Text = "Maestro de Comañias";
			this.tabPageLista.UseVisualStyleBackColor = true;
			// 
			// gridCompanias
			// 
			this.gridCompanias.AllowUserToAddRows = false;
			this.gridCompanias.AllowUserToDeleteRows = false;
			this.gridCompanias.AllowUserToResizeRows = false;
			this.gridCompanias.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
									| System.Windows.Forms.AnchorStyles.Left)
									| System.Windows.Forms.AnchorStyles.Right)));
			this.gridCompanias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gridCompanias.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdCompania,
            this.colNombre,
            this.colRut,
            this.colBaseDatos,
            this.colCuentaEjercicio,
            this.colCuentaAcumulado,
            this.colidOrigen,
            this.colOrigen,
            this.colidVigencia,
            this.colVigencia});
			this.gridCompanias.Location = new System.Drawing.Point(9, 8);
			this.gridCompanias.Name = "gridCompanias";
			this.gridCompanias.ReadOnly = true;
			this.gridCompanias.RowHeadersVisible = false;
			this.gridCompanias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.gridCompanias.Size = new System.Drawing.Size(793, 309);
			this.gridCompanias.TabIndex = 0;
			this.gridCompanias.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridCompanias_CellDoubleClick);
			// 
			// colIdCompania
			// 
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.colIdCompania.DefaultCellStyle = dataGridViewCellStyle1;
			this.colIdCompania.HeaderText = "Código";
			this.colIdCompania.Name = "colIdCompania";
			this.colIdCompania.ReadOnly = true;
			this.colIdCompania.Width = 43;
			// 
			// colNombre
			// 
			this.colNombre.HeaderText = "Nombre";
			this.colNombre.Name = "colNombre";
			this.colNombre.ReadOnly = true;
			this.colNombre.Width = 200;
			// 
			// colRut
			// 
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.colRut.DefaultCellStyle = dataGridViewCellStyle2;
			this.colRut.HeaderText = "RUT";
			this.colRut.Name = "colRut";
			this.colRut.ReadOnly = true;
			this.colRut.Width = 80;
			// 
			// colBaseDatos
			// 
			this.colBaseDatos.HeaderText = "Base Datos";
			this.colBaseDatos.Name = "colBaseDatos";
			this.colBaseDatos.ReadOnly = true;
			this.colBaseDatos.Width = 150;
			// 
			// colCuentaEjercicio
			// 
			this.colCuentaEjercicio.HeaderText = "Cta Ejercicio";
			this.colCuentaEjercicio.Name = "colCuentaEjercicio";
			this.colCuentaEjercicio.ReadOnly = true;
			this.colCuentaEjercicio.Width = 70;
			// 
			// colCuentaAcumulado
			// 
			this.colCuentaAcumulado.HeaderText = "Cta Acumulado";
			this.colCuentaAcumulado.Name = "colCuentaAcumulado";
			this.colCuentaAcumulado.ReadOnly = true;
			this.colCuentaAcumulado.Width = 70;
			// 
			// colidOrigen
			// 
			this.colidOrigen.HeaderText = "or";
			this.colidOrigen.Name = "colidOrigen";
			this.colidOrigen.ReadOnly = true;
			this.colidOrigen.Width = 10;
			// 
			// colOrigen
			// 
			this.colOrigen.HeaderText = "Origen";
			this.colOrigen.Name = "colOrigen";
			this.colOrigen.ReadOnly = true;
			this.colOrigen.Width = 70;
			// 
			// colidVigencia
			// 
			this.colidVigencia.HeaderText = "vig";
			this.colidVigencia.Name = "colidVigencia";
			this.colidVigencia.ReadOnly = true;
			this.colidVigencia.Width = 10;
			// 
			// colVigencia
			// 
			this.colVigencia.HeaderText = "Estado";
			this.colVigencia.Name = "colVigencia";
			this.colVigencia.ReadOnly = true;
			this.colVigencia.Width = 60;
			// 
			// tabPageMantencion
			// 
			this.tabPageMantencion.Controls.Add(this.textIdCompania);
			this.tabPageMantencion.Controls.Add(this.label8);
			this.tabPageMantencion.Controls.Add(this.checkVigente);
			this.tabPageMantencion.Controls.Add(this.radioManual);
			this.tabPageMantencion.Controls.Add(this.radioDynamics);
			this.tabPageMantencion.Controls.Add(this.textCuentaAcumulado);
			this.tabPageMantencion.Controls.Add(this.textCuentaEjercicio);
			this.tabPageMantencion.Controls.Add(this.textBaseDatos);
			this.tabPageMantencion.Controls.Add(this.label7);
			this.tabPageMantencion.Controls.Add(this.label6);
			this.tabPageMantencion.Controls.Add(this.label5);
			this.tabPageMantencion.Controls.Add(this.label4);
			this.tabPageMantencion.Controls.Add(this.textRUT);
			this.tabPageMantencion.Controls.Add(this.label3);
			this.tabPageMantencion.Controls.Add(this.label2);
			this.tabPageMantencion.Controls.Add(this.textNombre);
			this.tabPageMantencion.Controls.Add(this.label1);
			this.tabPageMantencion.Location = new System.Drawing.Point(4, 22);
			this.tabPageMantencion.Name = "tabPageMantencion";
			this.tabPageMantencion.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageMantencion.Size = new System.Drawing.Size(811, 326);
			this.tabPageMantencion.TabIndex = 1;
			this.tabPageMantencion.Text = "Mantenedor";
			this.tabPageMantencion.UseVisualStyleBackColor = true;
			// 
			// textIdCompania
			// 
			this.textIdCompania.Location = new System.Drawing.Point(143, 17);
			this.textIdCompania.Name = "textIdCompania";
			this.textIdCompania.Size = new System.Drawing.Size(100, 20);
			this.textIdCompania.TabIndex = 18;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(30, 20);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(40, 13);
			this.label8.TabIndex = 17;
			this.label8.Text = "Código";
			// 
			// checkVigente
			// 
			this.checkVigente.AutoSize = true;
			this.checkVigente.Location = new System.Drawing.Point(143, 215);
			this.checkVigente.Name = "checkVigente";
			this.checkVigente.Size = new System.Drawing.Size(62, 17);
			this.checkVigente.TabIndex = 16;
			this.checkVigente.Text = "Vigente";
			this.checkVigente.UseVisualStyleBackColor = true;
			// 
			// radioManual
			// 
			this.radioManual.AutoSize = true;
			this.radioManual.Location = new System.Drawing.Point(260, 186);
			this.radioManual.Name = "radioManual";
			this.radioManual.Size = new System.Drawing.Size(60, 17);
			this.radioManual.TabIndex = 14;
			this.radioManual.Text = "Manual";
			this.radioManual.UseVisualStyleBackColor = true;
			// 
			// radioDynamics
			// 
			this.radioDynamics.AutoSize = true;
			this.radioDynamics.Checked = true;
			this.radioDynamics.Location = new System.Drawing.Point(143, 186);
			this.radioDynamics.Name = "radioDynamics";
			this.radioDynamics.Size = new System.Drawing.Size(71, 17);
			this.radioDynamics.TabIndex = 13;
			this.radioDynamics.TabStop = true;
			this.radioDynamics.Text = "Dynamics";
			this.radioDynamics.UseVisualStyleBackColor = true;
			// 
			// textCuentaAcumulado
			// 
			this.textCuentaAcumulado.Location = new System.Drawing.Point(143, 157);
			this.textCuentaAcumulado.Name = "textCuentaAcumulado";
			this.textCuentaAcumulado.Size = new System.Drawing.Size(100, 20);
			this.textCuentaAcumulado.TabIndex = 12;
			// 
			// textCuentaEjercicio
			// 
			this.textCuentaEjercicio.Location = new System.Drawing.Point(143, 129);
			this.textCuentaEjercicio.Name = "textCuentaEjercicio";
			this.textCuentaEjercicio.Size = new System.Drawing.Size(100, 20);
			this.textCuentaEjercicio.TabIndex = 11;
			// 
			// textBaseDatos
			// 
			this.textBaseDatos.Location = new System.Drawing.Point(143, 101);
			this.textBaseDatos.Name = "textBaseDatos";
			this.textBaseDatos.Size = new System.Drawing.Size(151, 20);
			this.textBaseDatos.TabIndex = 10;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(30, 216);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(40, 13);
			this.label7.TabIndex = 9;
			this.label7.Text = "Estado";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(30, 188);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(38, 13);
			this.label6.TabIndex = 8;
			this.label6.Text = "Origen";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(30, 160);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(97, 13);
			this.label5.TabIndex = 7;
			this.label5.Text = "Cuenta Acumulado";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(30, 132);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(99, 13);
			this.label4.TabIndex = 6;
			this.label4.Text = "Cuenta de Ejercicio";
			// 
			// textRUT
			// 
			this.textRUT.Location = new System.Drawing.Point(143, 73);
			this.textRUT.Name = "textRUT";
			this.textRUT.Size = new System.Drawing.Size(100, 20);
			this.textRUT.TabIndex = 4;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(30, 104);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(77, 13);
			this.label3.TabIndex = 3;
			this.label3.Text = "Base de Datos";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(30, 76);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(30, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "RUT";
			// 
			// textNombre
			// 
			this.textNombre.Location = new System.Drawing.Point(143, 45);
			this.textNombre.Name = "textNombre";
			this.textNombre.Size = new System.Drawing.Size(302, 20);
			this.textNombre.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(30, 48);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(44, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Nombre";
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevaCompañiaToolStripMenuItem,
            this.editarCompañiaToolStripMenuItem,
            this.eliminarCompañiaToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(176, 70);
			// 
			// nuevaCompañiaToolStripMenuItem
			// 
			this.nuevaCompañiaToolStripMenuItem.Name = "nuevaCompañiaToolStripMenuItem";
			this.nuevaCompañiaToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
			this.nuevaCompañiaToolStripMenuItem.Text = "Nueva Compañia";
			this.nuevaCompañiaToolStripMenuItem.Click += new System.EventHandler(this.nuevaCompañiaToolStripMenuItem_Click);
			// 
			// editarCompañiaToolStripMenuItem
			// 
			this.editarCompañiaToolStripMenuItem.Name = "editarCompañiaToolStripMenuItem";
			this.editarCompañiaToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
			this.editarCompañiaToolStripMenuItem.Text = "Editar Compañia";
			this.editarCompañiaToolStripMenuItem.Click += new System.EventHandler(this.editarCompañiaToolStripMenuItem_Click);
			// 
			// eliminarCompañiaToolStripMenuItem
			// 
			this.eliminarCompañiaToolStripMenuItem.Name = "eliminarCompañiaToolStripMenuItem";
			this.eliminarCompañiaToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
			this.eliminarCompañiaToolStripMenuItem.Text = "Eliminar Compañia";
			this.eliminarCompañiaToolStripMenuItem.Click += new System.EventHandler(this.eliminarCompañiaToolStripMenuItem_Click);
			// 
			// MantenedorCompanias
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(842, 399);
			this.Controls.Add(this.tabControlCompania);
			this.Controls.Add(this.toolBarra);
			this.Name = "MantenedorCompanias";
			this.ShowIcon = false;
			this.Text = "MantenedorCompanias";
			this.Load += new System.EventHandler(this.MantenedorCompanias_Load);
			this.toolBarra.ResumeLayout(false);
			this.toolBarra.PerformLayout();
			this.tabControlCompania.ResumeLayout(false);
			this.tabPageLista.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridCompanias)).EndInit();
			this.tabPageMantencion.ResumeLayout(false);
			this.tabPageMantencion.PerformLayout();
			this.contextMenuStrip1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolBarra;
		private System.Windows.Forms.ToolStripButton toolSalir;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripButton toolNuevo;
		private System.Windows.Forms.ToolStripButton toolEditar;
		private System.Windows.Forms.ToolStripButton toolEliminar;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton toolCancelar;
		private System.Windows.Forms.ToolStripButton toolGrabar;
		private System.Windows.Forms.TabControl tabControlCompania;
		private System.Windows.Forms.TabPage tabPageLista;
		private System.Windows.Forms.DataGridView gridCompanias;
		private System.Windows.Forms.TabPage tabPageMantencion;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textRUT;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textNombre;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textCuentaAcumulado;
		private System.Windows.Forms.TextBox textCuentaEjercicio;
		private System.Windows.Forms.TextBox textBaseDatos;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.CheckBox checkVigente;
		private System.Windows.Forms.RadioButton radioManual;
		private System.Windows.Forms.RadioButton radioDynamics;
		private System.Windows.Forms.DataGridViewTextBoxColumn colIdCompania;
		private System.Windows.Forms.DataGridViewTextBoxColumn colNombre;
		private System.Windows.Forms.DataGridViewTextBoxColumn colRut;
		private System.Windows.Forms.DataGridViewTextBoxColumn colBaseDatos;
		private System.Windows.Forms.DataGridViewTextBoxColumn colCuentaEjercicio;
		private System.Windows.Forms.DataGridViewTextBoxColumn colCuentaAcumulado;
		private System.Windows.Forms.DataGridViewTextBoxColumn colidOrigen;
		private System.Windows.Forms.DataGridViewTextBoxColumn colOrigen;
		private System.Windows.Forms.DataGridViewTextBoxColumn colidVigencia;
		private System.Windows.Forms.DataGridViewTextBoxColumn colVigencia;
		private System.Windows.Forms.TextBox textIdCompania;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem nuevaCompañiaToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem editarCompañiaToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem eliminarCompañiaToolStripMenuItem;
	}
}