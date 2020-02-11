namespace NewConsolidado.Vistas.Formularios
{
	partial class MantenedorConceptos
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
            this.toolBarra = new System.Windows.Forms.ToolStrip();
            this.toolSalir = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolNuevo = new System.Windows.Forms.ToolStripButton();
            this.toolEditar = new System.Windows.Forms.ToolStripButton();
            this.toolEliminar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolCancelar = new System.Windows.Forms.ToolStripButton();
            this.toolGrabar = new System.Windows.Forms.ToolStripButton();
            this.tabControlConceptos = new System.Windows.Forms.TabControl();
            this.tabPageLista = new System.Windows.Forms.TabPage();
            this.gridConceptos = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.nueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPageMantencion = new System.Windows.Forms.TabPage();
            this.numOrden = new System.Windows.Forms.NumericUpDown();
            this.comboTipo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textDescripcion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textCodigo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboSumaESF = new System.Windows.Forms.ComboBox();
            this.colIdConcepto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colidTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrden = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSumaESF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdSuma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolBarra.SuspendLayout();
            this.tabControlConceptos.SuspendLayout();
            this.tabPageLista.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridConceptos)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.tabPageMantencion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numOrden)).BeginInit();
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
            this.toolBarra.Size = new System.Drawing.Size(549, 31);
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
            // tabControlConceptos
            // 
            this.tabControlConceptos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlConceptos.Controls.Add(this.tabPageLista);
            this.tabControlConceptos.Controls.Add(this.tabPageMantencion);
            this.tabControlConceptos.Location = new System.Drawing.Point(5, 34);
            this.tabControlConceptos.Name = "tabControlConceptos";
            this.tabControlConceptos.SelectedIndex = 0;
            this.tabControlConceptos.Size = new System.Drawing.Size(532, 311);
            this.tabControlConceptos.TabIndex = 3;
            this.tabControlConceptos.SelectedIndexChanged += new System.EventHandler(this.tabControlConceptos_SelectedIndexChanged);
            // 
            // tabPageLista
            // 
            this.tabPageLista.Controls.Add(this.gridConceptos);
            this.tabPageLista.Location = new System.Drawing.Point(4, 22);
            this.tabPageLista.Name = "tabPageLista";
            this.tabPageLista.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLista.Size = new System.Drawing.Size(524, 285);
            this.tabPageLista.TabIndex = 0;
            this.tabPageLista.Text = "Maestro de Conceptos";
            this.tabPageLista.UseVisualStyleBackColor = true;
            // 
            // gridConceptos
            // 
            this.gridConceptos.AllowUserToAddRows = false;
            this.gridConceptos.AllowUserToDeleteRows = false;
            this.gridConceptos.AllowUserToResizeRows = false;
            this.gridConceptos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridConceptos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridConceptos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdConcepto,
            this.colCodigo,
            this.colDescripcion,
            this.colTipo,
            this.colidTipo,
            this.colOrden,
            this.colSumaESF,
            this.colIdSuma});
            this.gridConceptos.ContextMenuStrip = this.contextMenuStrip1;
            this.gridConceptos.Location = new System.Drawing.Point(9, 7);
            this.gridConceptos.MultiSelect = false;
            this.gridConceptos.Name = "gridConceptos";
            this.gridConceptos.ReadOnly = true;
            this.gridConceptos.RowHeadersVisible = false;
            this.gridConceptos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridConceptos.Size = new System.Drawing.Size(506, 268);
            this.gridConceptos.TabIndex = 0;
            this.gridConceptos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridConceptos_CellDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nueToolStripMenuItem,
            this.editarToolStripMenuItem,
            this.eliminarToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(118, 70);
            // 
            // nueToolStripMenuItem
            // 
            this.nueToolStripMenuItem.Name = "nueToolStripMenuItem";
            this.nueToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.nueToolStripMenuItem.Text = "Nuevo";
            this.nueToolStripMenuItem.Click += new System.EventHandler(this.nueToolStripMenuItem_Click);
            // 
            // editarToolStripMenuItem
            // 
            this.editarToolStripMenuItem.Name = "editarToolStripMenuItem";
            this.editarToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.editarToolStripMenuItem.Text = "Editar";
            this.editarToolStripMenuItem.Click += new System.EventHandler(this.editarToolStripMenuItem_Click);
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.eliminarToolStripMenuItem.Text = "Eliminar";
            this.eliminarToolStripMenuItem.Click += new System.EventHandler(this.eliminarToolStripMenuItem_Click);
            // 
            // tabPageMantencion
            // 
            this.tabPageMantencion.Controls.Add(this.comboSumaESF);
            this.tabPageMantencion.Controls.Add(this.label5);
            this.tabPageMantencion.Controls.Add(this.numOrden);
            this.tabPageMantencion.Controls.Add(this.comboTipo);
            this.tabPageMantencion.Controls.Add(this.label4);
            this.tabPageMantencion.Controls.Add(this.textDescripcion);
            this.tabPageMantencion.Controls.Add(this.label3);
            this.tabPageMantencion.Controls.Add(this.label2);
            this.tabPageMantencion.Controls.Add(this.textCodigo);
            this.tabPageMantencion.Controls.Add(this.label1);
            this.tabPageMantencion.Location = new System.Drawing.Point(4, 22);
            this.tabPageMantencion.Name = "tabPageMantencion";
            this.tabPageMantencion.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMantencion.Size = new System.Drawing.Size(473, 285);
            this.tabPageMantencion.TabIndex = 1;
            this.tabPageMantencion.Text = "Mantenedor";
            this.tabPageMantencion.UseVisualStyleBackColor = true;
            // 
            // numOrden
            // 
            this.numOrden.Location = new System.Drawing.Point(158, 108);
            this.numOrden.Name = "numOrden";
            this.numOrden.Size = new System.Drawing.Size(38, 20);
            this.numOrden.TabIndex = 9;
            // 
            // comboTipo
            // 
            this.comboTipo.FormattingEnabled = true;
            this.comboTipo.Location = new System.Drawing.Point(158, 80);
            this.comboTipo.Name = "comboTipo";
            this.comboTipo.Size = new System.Drawing.Size(121, 21);
            this.comboTipo.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Orden";
            // 
            // textDescripcion
            // 
            this.textDescripcion.Location = new System.Drawing.Point(158, 54);
            this.textDescripcion.Name = "textDescripcion";
            this.textDescripcion.Size = new System.Drawing.Size(295, 20);
            this.textDescripcion.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Tipo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Descripción";
            // 
            // textCodigo
            // 
            this.textCodigo.Location = new System.Drawing.Point(158, 24);
            this.textCodigo.Name = "textCodigo";
            this.textCodigo.Size = new System.Drawing.Size(100, 20);
            this.textCodigo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Código";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Separador ESF-Super";
            // 
            // comboSumaESF
            // 
            this.comboSumaESF.FormattingEnabled = true;
            this.comboSumaESF.Location = new System.Drawing.Point(158, 140);
            this.comboSumaESF.Name = "comboSumaESF";
            this.comboSumaESF.Size = new System.Drawing.Size(121, 21);
            this.comboSumaESF.TabIndex = 11;
            // 
            // colIdConcepto
            // 
            this.colIdConcepto.HeaderText = "ID";
            this.colIdConcepto.Name = "colIdConcepto";
            this.colIdConcepto.ReadOnly = true;
            this.colIdConcepto.Width = 25;
            // 
            // colCodigo
            // 
            this.colCodigo.HeaderText = "Código";
            this.colCodigo.Name = "colCodigo";
            this.colCodigo.ReadOnly = true;
            this.colCodigo.Width = 50;
            // 
            // colDescripcion
            // 
            this.colDescripcion.HeaderText = "Descripción";
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.ReadOnly = true;
            this.colDescripcion.Width = 250;
            // 
            // colTipo
            // 
            this.colTipo.HeaderText = "Tipo";
            this.colTipo.Name = "colTipo";
            this.colTipo.ReadOnly = true;
            this.colTipo.Width = 60;
            // 
            // colidTipo
            // 
            this.colidTipo.HeaderText = "idtipo";
            this.colidTipo.Name = "colidTipo";
            this.colidTipo.ReadOnly = true;
            this.colidTipo.Width = 5;
            // 
            // colOrden
            // 
            this.colOrden.HeaderText = "Orden";
            this.colOrden.Name = "colOrden";
            this.colOrden.ReadOnly = true;
            this.colOrden.Width = 40;
            // 
            // colSumaESF
            // 
            this.colSumaESF.HeaderText = "SumaESF";
            this.colSumaESF.Name = "colSumaESF";
            this.colSumaESF.ReadOnly = true;
            this.colSumaESF.Width = 75;
            // 
            // colIdSuma
            // 
            this.colIdSuma.HeaderText = "IdSuma";
            this.colIdSuma.Name = "colIdSuma";
            this.colIdSuma.ReadOnly = true;
            // 
            // MantenedorConceptos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 356);
            this.Controls.Add(this.tabControlConceptos);
            this.Controls.Add(this.toolBarra);
            this.Name = "MantenedorConceptos";
            this.ShowIcon = false;
            this.Text = "MantenedorConceptos";
            this.Load += new System.EventHandler(this.MantenedorConceptos_Load);
            this.toolBarra.ResumeLayout(false);
            this.toolBarra.PerformLayout();
            this.tabControlConceptos.ResumeLayout(false);
            this.tabPageLista.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridConceptos)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabPageMantencion.ResumeLayout(false);
            this.tabPageMantencion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numOrden)).EndInit();
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
		private System.Windows.Forms.TabControl tabControlConceptos;
		private System.Windows.Forms.TabPage tabPageLista;
		private System.Windows.Forms.DataGridView gridConceptos;
		private System.Windows.Forms.TabPage tabPageMantencion;
		private System.Windows.Forms.NumericUpDown numOrden;
		private System.Windows.Forms.ComboBox comboTipo;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textDescripcion;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textCodigo;
		private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem nueToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        private System.Windows.Forms.ComboBox comboSumaESF;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdConcepto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colidTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrden;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSumaESF;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdSuma;
	}
}