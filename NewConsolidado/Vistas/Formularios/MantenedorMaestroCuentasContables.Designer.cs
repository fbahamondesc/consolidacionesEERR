namespace NewConsolidado.Vistas.Formularios
{
	partial class MantenedorMaestroCuentasContables
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
			this.tabControlCuentas = new System.Windows.Forms.TabControl();
			this.tabPageLista = new System.Windows.Forms.TabPage();
			this.gridMaestroCuentas = new System.Windows.Forms.DataGridView();
			this.colIdCuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colOrden = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colManual = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colImprime = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colAjuste = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colPatrimonio = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.EliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tabPageMantenedor = new System.Windows.Forms.TabPage();
			this.checkPatrimonio = new System.Windows.Forms.CheckBox();
			this.checkImprime = new System.Windows.Forms.CheckBox();
			this.checkAjuste = new System.Windows.Forms.CheckBox();
			this.comboOrigen = new System.Windows.Forms.ComboBox();
			this.label6 = new System.Windows.Forms.Label();
			this.textTipo = new System.Windows.Forms.TextBox();
			this.numOrden = new System.Windows.Forms.NumericUpDown();
			this.label4 = new System.Windows.Forms.Label();
			this.textDescripcion = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.textCodigo = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.toolBarra.SuspendLayout();
			this.tabControlCuentas.SuspendLayout();
			this.tabPageLista.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridMaestroCuentas)).BeginInit();
			this.contextMenuStrip1.SuspendLayout();
			this.tabPageMantenedor.SuspendLayout();
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
			this.toolBarra.Size = new System.Drawing.Size(639, 31);
			this.toolBarra.TabIndex = 3;
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
			// tabControlCuentas
			// 
			this.tabControlCuentas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
									| System.Windows.Forms.AnchorStyles.Left)
									| System.Windows.Forms.AnchorStyles.Right)));
			this.tabControlCuentas.Controls.Add(this.tabPageLista);
			this.tabControlCuentas.Controls.Add(this.tabPageMantenedor);
			this.tabControlCuentas.Location = new System.Drawing.Point(9, 47);
			this.tabControlCuentas.Name = "tabControlCuentas";
			this.tabControlCuentas.SelectedIndex = 0;
			this.tabControlCuentas.Size = new System.Drawing.Size(622, 325);
			this.tabControlCuentas.TabIndex = 4;
			this.tabControlCuentas.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
			// 
			// tabPageLista
			// 
			this.tabPageLista.Controls.Add(this.gridMaestroCuentas);
			this.tabPageLista.Location = new System.Drawing.Point(4, 22);
			this.tabPageLista.Name = "tabPageLista";
			this.tabPageLista.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageLista.Size = new System.Drawing.Size(614, 299);
			this.tabPageLista.TabIndex = 0;
			this.tabPageLista.Text = "Maestro de Cuentas Contables";
			this.tabPageLista.UseVisualStyleBackColor = true;
			// 
			// gridMaestroCuentas
			// 
			this.gridMaestroCuentas.AllowUserToAddRows = false;
			this.gridMaestroCuentas.AllowUserToDeleteRows = false;
			this.gridMaestroCuentas.AllowUserToResizeRows = false;
			this.gridMaestroCuentas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
									| System.Windows.Forms.AnchorStyles.Left)
									| System.Windows.Forms.AnchorStyles.Right)));
			this.gridMaestroCuentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gridMaestroCuentas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdCuenta,
            this.colDescripcion,
            this.colTipo,
            this.colOrden,
            this.colManual,
            this.colImprime,
            this.colAjuste,
            this.colPatrimonio});
			this.gridMaestroCuentas.ContextMenuStrip = this.contextMenuStrip1;
			this.gridMaestroCuentas.Location = new System.Drawing.Point(9, 7);
			this.gridMaestroCuentas.MultiSelect = false;
			this.gridMaestroCuentas.Name = "gridMaestroCuentas";
			this.gridMaestroCuentas.ReadOnly = true;
			this.gridMaestroCuentas.RowHeadersVisible = false;
			this.gridMaestroCuentas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.gridMaestroCuentas.Size = new System.Drawing.Size(596, 282);
			this.gridMaestroCuentas.TabIndex = 0;
			this.gridMaestroCuentas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridMaestroCuentas_CellDoubleClick);
			// 
			// colIdCuenta
			// 
			this.colIdCuenta.HeaderText = "Cuenta";
			this.colIdCuenta.Name = "colIdCuenta";
			this.colIdCuenta.ReadOnly = true;
			this.colIdCuenta.Width = 80;
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
			this.colTipo.Width = 50;
			// 
			// colOrden
			// 
			this.colOrden.HeaderText = "Ord.";
			this.colOrden.Name = "colOrden";
			this.colOrden.ReadOnly = true;
			this.colOrden.Width = 35;
			// 
			// colManual
			// 
			this.colManual.HeaderText = "Origen";
			this.colManual.Name = "colManual";
			this.colManual.ReadOnly = true;
			this.colManual.Width = 60;
			// 
			// colImprime
			// 
			this.colImprime.HeaderText = "Imp.";
			this.colImprime.Name = "colImprime";
			this.colImprime.ReadOnly = true;
			this.colImprime.Width = 30;
			// 
			// colAjuste
			// 
			this.colAjuste.HeaderText = "Ajus.";
			this.colAjuste.Name = "colAjuste";
			this.colAjuste.ReadOnly = true;
			this.colAjuste.Width = 30;
			// 
			// colPatrimonio
			// 
			this.colPatrimonio.HeaderText = "Pat.";
			this.colPatrimonio.Name = "colPatrimonio";
			this.colPatrimonio.ReadOnly = true;
			this.colPatrimonio.Width = 30;
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripMenuItem,
            this.editarToolStripMenuItem,
            this.EliminarToolStripMenuItem});
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
			// EliminarToolStripMenuItem
			// 
			this.EliminarToolStripMenuItem.Name = "EliminarToolStripMenuItem";
			this.EliminarToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
			this.EliminarToolStripMenuItem.Text = "Eliminar";
			this.EliminarToolStripMenuItem.Click += new System.EventHandler(this.EliminarToolStripMenuItem_Click);
			// 
			// tabPageMantenedor
			// 
			this.tabPageMantenedor.Controls.Add(this.checkPatrimonio);
			this.tabPageMantenedor.Controls.Add(this.checkImprime);
			this.tabPageMantenedor.Controls.Add(this.checkAjuste);
			this.tabPageMantenedor.Controls.Add(this.comboOrigen);
			this.tabPageMantenedor.Controls.Add(this.label6);
			this.tabPageMantenedor.Controls.Add(this.textTipo);
			this.tabPageMantenedor.Controls.Add(this.numOrden);
			this.tabPageMantenedor.Controls.Add(this.label4);
			this.tabPageMantenedor.Controls.Add(this.textDescripcion);
			this.tabPageMantenedor.Controls.Add(this.label3);
			this.tabPageMantenedor.Controls.Add(this.label2);
			this.tabPageMantenedor.Controls.Add(this.textCodigo);
			this.tabPageMantenedor.Controls.Add(this.label1);
			this.tabPageMantenedor.Location = new System.Drawing.Point(4, 22);
			this.tabPageMantenedor.Name = "tabPageMantenedor";
			this.tabPageMantenedor.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageMantenedor.Size = new System.Drawing.Size(614, 299);
			this.tabPageMantenedor.TabIndex = 1;
			this.tabPageMantenedor.Text = "Mantenedor";
			this.tabPageMantenedor.UseVisualStyleBackColor = true;
			// 
			// checkPatrimonio
			// 
			this.checkPatrimonio.AutoSize = true;
			this.checkPatrimonio.Location = new System.Drawing.Point(89, 201);
			this.checkPatrimonio.Name = "checkPatrimonio";
			this.checkPatrimonio.Size = new System.Drawing.Size(127, 17);
			this.checkPatrimonio.TabIndex = 16;
			this.checkPatrimonio.Text = "Cuenta de Patrimonio";
			this.checkPatrimonio.UseVisualStyleBackColor = true;
			// 
			// checkImprime
			// 
			this.checkImprime.AutoSize = true;
			this.checkImprime.Location = new System.Drawing.Point(89, 177);
			this.checkImprime.Name = "checkImprime";
			this.checkImprime.Size = new System.Drawing.Size(109, 17);
			this.checkImprime.TabIndex = 15;
			this.checkImprime.Text = "Cuenta Imprimible";
			this.checkImprime.UseVisualStyleBackColor = true;
			// 
			// checkAjuste
			// 
			this.checkAjuste.AutoSize = true;
			this.checkAjuste.Location = new System.Drawing.Point(89, 153);
			this.checkAjuste.Name = "checkAjuste";
			this.checkAjuste.Size = new System.Drawing.Size(108, 17);
			this.checkAjuste.TabIndex = 14;
			this.checkAjuste.Text = "Solo para Ajustes";
			this.checkAjuste.UseVisualStyleBackColor = true;
			// 
			// comboOrigen
			// 
			this.comboOrigen.FormattingEnabled = true;
			this.comboOrigen.Location = new System.Drawing.Point(89, 121);
			this.comboOrigen.Name = "comboOrigen";
			this.comboOrigen.Size = new System.Drawing.Size(121, 21);
			this.comboOrigen.TabIndex = 13;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(22, 124);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(38, 13);
			this.label6.TabIndex = 12;
			this.label6.Text = "Origen";
			// 
			// textTipo
			// 
			this.textTipo.Location = new System.Drawing.Point(89, 69);
			this.textTipo.Name = "textTipo";
			this.textTipo.Size = new System.Drawing.Size(38, 20);
			this.textTipo.TabIndex = 10;
			// 
			// numOrden
			// 
			this.numOrden.Location = new System.Drawing.Point(89, 95);
			this.numOrden.Name = "numOrden";
			this.numOrden.Size = new System.Drawing.Size(38, 20);
			this.numOrden.TabIndex = 9;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(20, 97);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(36, 13);
			this.label4.TabIndex = 6;
			this.label4.Text = "Orden";
			// 
			// textDescripcion
			// 
			this.textDescripcion.Location = new System.Drawing.Point(89, 43);
			this.textDescripcion.Name = "textDescripcion";
			this.textDescripcion.Size = new System.Drawing.Size(249, 20);
			this.textDescripcion.TabIndex = 4;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(20, 72);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(28, 13);
			this.label3.TabIndex = 3;
			this.label3.Text = "Tipo";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(20, 46);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(63, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Descripción";
			// 
			// textCodigo
			// 
			this.textCodigo.Location = new System.Drawing.Point(89, 17);
			this.textCodigo.Name = "textCodigo";
			this.textCodigo.Size = new System.Drawing.Size(100, 20);
			this.textCodigo.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(20, 20);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Código";
			// 
			// MantenedorMaestroCuentasContables
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(639, 381);
			this.Controls.Add(this.tabControlCuentas);
			this.Controls.Add(this.toolBarra);
			this.Name = "MantenedorMaestroCuentasContables";
			this.ShowIcon = false;
			this.Text = "MantenedorMaestroCuentasContables";
			this.Load += new System.EventHandler(this.MantenedorMaestroCuentasContables_Load);
			this.toolBarra.ResumeLayout(false);
			this.toolBarra.PerformLayout();
			this.tabControlCuentas.ResumeLayout(false);
			this.tabPageLista.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridMaestroCuentas)).EndInit();
			this.contextMenuStrip1.ResumeLayout(false);
			this.tabPageMantenedor.ResumeLayout(false);
			this.tabPageMantenedor.PerformLayout();
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
		private System.Windows.Forms.TabControl tabControlCuentas;
		private System.Windows.Forms.TabPage tabPageLista;
		private System.Windows.Forms.DataGridView gridMaestroCuentas;
		private System.Windows.Forms.TabPage tabPageMantenedor;
		private System.Windows.Forms.NumericUpDown numOrden;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textDescripcion;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textCodigo;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem EliminarToolStripMenuItem;
		private System.Windows.Forms.TextBox textTipo;
		private System.Windows.Forms.CheckBox checkImprime;
		private System.Windows.Forms.CheckBox checkAjuste;
		private System.Windows.Forms.ComboBox comboOrigen;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.CheckBox checkPatrimonio;
		private System.Windows.Forms.DataGridViewTextBoxColumn colIdCuenta;
		private System.Windows.Forms.DataGridViewTextBoxColumn colDescripcion;
		private System.Windows.Forms.DataGridViewTextBoxColumn colTipo;
		private System.Windows.Forms.DataGridViewTextBoxColumn colOrden;
		private System.Windows.Forms.DataGridViewTextBoxColumn colManual;
		private System.Windows.Forms.DataGridViewTextBoxColumn colImprime;
		private System.Windows.Forms.DataGridViewTextBoxColumn colAjuste;
		private System.Windows.Forms.DataGridViewTextBoxColumn colPatrimonio;

	}
}