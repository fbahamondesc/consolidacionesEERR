namespace NewConsolidado.Vistas.Formularios
{
	partial class MantenedorGrupos
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
			this.tabControlGrupos = new System.Windows.Forms.TabControl();
			this.tabPageLista = new System.Windows.Forms.TabPage();
			this.gridGrupos = new System.Windows.Forms.DataGridView();
			this.tabPageMantencion = new System.Windows.Forms.TabPage();
			this.numOrden = new System.Windows.Forms.NumericUpDown();
			this.comboTipo = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.textDescripcion = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.textCodigo = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.colidGrupo = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colidTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colOrden = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.toolBarra.SuspendLayout();
			this.tabControlGrupos.SuspendLayout();
			this.tabPageLista.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridGrupos)).BeginInit();
			this.tabPageMantencion.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numOrden)).BeginInit();
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
			this.toolBarra.Size = new System.Drawing.Size(491, 31);
			this.toolBarra.TabIndex = 1;
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
			// tabControlGrupos
			// 
			this.tabControlGrupos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tabControlGrupos.Controls.Add(this.tabPageLista);
			this.tabControlGrupos.Controls.Add(this.tabPageMantencion);
			this.tabControlGrupos.Location = new System.Drawing.Point(12, 34);
			this.tabControlGrupos.Name = "tabControlGrupos";
			this.tabControlGrupos.SelectedIndex = 0;
			this.tabControlGrupos.Size = new System.Drawing.Size(471, 351);
			this.tabControlGrupos.TabIndex = 2;
			this.tabControlGrupos.SelectedIndexChanged += new System.EventHandler(this.tabControlGrupos_SelectedIndexChanged);
			// 
			// tabPageLista
			// 
			this.tabPageLista.Controls.Add(this.gridGrupos);
			this.tabPageLista.Location = new System.Drawing.Point(4, 22);
			this.tabPageLista.Name = "tabPageLista";
			this.tabPageLista.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageLista.Size = new System.Drawing.Size(463, 325);
			this.tabPageLista.TabIndex = 0;
			this.tabPageLista.Text = "Maestro de Grupos";
			this.tabPageLista.UseVisualStyleBackColor = true;
			// 
			// gridGrupos
			// 
			this.gridGrupos.AllowUserToAddRows = false;
			this.gridGrupos.AllowUserToDeleteRows = false;
			this.gridGrupos.AllowUserToResizeRows = false;
			this.gridGrupos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.gridGrupos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gridGrupos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colidGrupo,
            this.colCodigo,
            this.colDescripcion,
            this.colTipo,
            this.colidTipo,
            this.colOrden});
			this.gridGrupos.Location = new System.Drawing.Point(9, 8);
			this.gridGrupos.MultiSelect = false;
			this.gridGrupos.Name = "gridGrupos";
			this.gridGrupos.ReadOnly = true;
			this.gridGrupos.RowHeadersVisible = false;
			this.gridGrupos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.gridGrupos.Size = new System.Drawing.Size(445, 308);
			this.gridGrupos.TabIndex = 0;
			this.gridGrupos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridGrupos_CellDoubleClick);
			// 
			// tabPageMantencion
			// 
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
			this.tabPageMantencion.Size = new System.Drawing.Size(489, 268);
			this.tabPageMantencion.TabIndex = 1;
			this.tabPageMantencion.Text = "Mantenedor";
			this.tabPageMantencion.UseVisualStyleBackColor = true;
			// 
			// numOrden
			// 
			this.numOrden.Location = new System.Drawing.Point(102, 107);
			this.numOrden.Name = "numOrden";
			this.numOrden.Size = new System.Drawing.Size(38, 20);
			this.numOrden.TabIndex = 9;
			// 
			// comboTipo
			// 
			this.comboTipo.FormattingEnabled = true;
			this.comboTipo.Location = new System.Drawing.Point(102, 79);
			this.comboTipo.Name = "comboTipo";
			this.comboTipo.Size = new System.Drawing.Size(121, 21);
			this.comboTipo.TabIndex = 8;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(28, 109);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(36, 13);
			this.label4.TabIndex = 6;
			this.label4.Text = "Orden";
			// 
			// textDescripcion
			// 
			this.textDescripcion.Location = new System.Drawing.Point(102, 50);
			this.textDescripcion.Name = "textDescripcion";
			this.textDescripcion.Size = new System.Drawing.Size(241, 20);
			this.textDescripcion.TabIndex = 4;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(28, 82);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(28, 13);
			this.label3.TabIndex = 3;
			this.label3.Text = "Tipo";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(28, 53);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(63, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Descripción";
			// 
			// textCodigo
			// 
			this.textCodigo.Location = new System.Drawing.Point(102, 20);
			this.textCodigo.Name = "textCodigo";
			this.textCodigo.Size = new System.Drawing.Size(100, 20);
			this.textCodigo.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(28, 23);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Código";
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripMenuItem,
            this.editarToolStripMenuItem,
            this.eliminarToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(118, 70);
			// 
			// nuevoToolStripMenuItem
			// 
			this.nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
			this.nuevoToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
			this.nuevoToolStripMenuItem.Text = "Nuevo";
			this.nuevoToolStripMenuItem.Click += new System.EventHandler(this.nuevoToolStripMenuItem_Click);
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
			// colidGrupo
			// 
			this.colidGrupo.HeaderText = "ID";
			this.colidGrupo.Name = "colidGrupo";
			this.colidGrupo.ReadOnly = true;
			this.colidGrupo.Width = 25;
			// 
			// colCodigo
			// 
			this.colCodigo.HeaderText = "Grupo";
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
			this.colTipo.Width = 65;
			// 
			// colidTipo
			// 
			this.colidTipo.HeaderText = "id";
			this.colidTipo.Name = "colidTipo";
			this.colidTipo.ReadOnly = true;
			this.colidTipo.Width = 10;
			// 
			// colOrden
			// 
			this.colOrden.HeaderText = "Orden";
			this.colOrden.Name = "colOrden";
			this.colOrden.ReadOnly = true;
			this.colOrden.Width = 40;
			// 
			// MantenedorGrupos
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(491, 398);
			this.Controls.Add(this.tabControlGrupos);
			this.Controls.Add(this.toolBarra);
			this.Name = "MantenedorGrupos";
			this.ShowIcon = false;
			this.Text = "MantenedorGrupos";
			this.Load += new System.EventHandler(this.MantenedorGrupos_Load);
			this.toolBarra.ResumeLayout(false);
			this.toolBarra.PerformLayout();
			this.tabControlGrupos.ResumeLayout(false);
			this.tabPageLista.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridGrupos)).EndInit();
			this.tabPageMantencion.ResumeLayout(false);
			this.tabPageMantencion.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numOrden)).EndInit();
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
		private System.Windows.Forms.TabControl tabControlGrupos;
		private System.Windows.Forms.TabPage tabPageLista;
		private System.Windows.Forms.DataGridView gridGrupos;
		private System.Windows.Forms.TabPage tabPageMantencion;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textDescripcion;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textCodigo;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown numOrden;
		private System.Windows.Forms.ComboBox comboTipo;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
		private System.Windows.Forms.DataGridViewTextBoxColumn colidGrupo;
		private System.Windows.Forms.DataGridViewTextBoxColumn colCodigo;
		private System.Windows.Forms.DataGridViewTextBoxColumn colDescripcion;
		private System.Windows.Forms.DataGridViewTextBoxColumn colTipo;
		private System.Windows.Forms.DataGridViewTextBoxColumn colidTipo;
		private System.Windows.Forms.DataGridViewTextBoxColumn colOrden;
	}
}