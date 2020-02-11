namespace NewConsolidado.Vistas.Formularios
{
	partial class MantenedorConfiguracionAjustesAutomaticos
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			this.toolBarra = new System.Windows.Forms.ToolStrip();
			this.toolSalir = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.toolNuevo = new System.Windows.Forms.ToolStripButton();
			this.toolEditar = new System.Windows.Forms.ToolStripButton();
			this.toolEliminar = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.toolCancelar = new System.Windows.Forms.ToolStripButton();
			this.toolGrabar = new System.Windows.Forms.ToolStripButton();
			this.tabControlConfiguracion = new System.Windows.Forms.TabControl();
			this.tabPageLista = new System.Windows.Forms.TabPage();
			this.gridConfiguracion = new System.Windows.Forms.DataGridView();
			this.colIdCompania = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colCuentaOrigen = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colGlosa = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colCuentaDestino = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colCuentaDestinoNC = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colContraCuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colNgCuentaDestino = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colNgCuentaDestinoNC = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colNgContraCuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.comboCompanias = new System.Windows.Forms.ComboBox();
			this.tabPageMantenedor = new System.Windows.Forms.TabPage();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.textnNgContraCuenta = new System.Windows.Forms.TextBox();
			this.textNgCuentaDestinoNC = new System.Windows.Forms.TextBox();
			this.textNgCuentaDestino = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.textContraCuenta = new System.Windows.Forms.TextBox();
			this.textCuentaDestinoNC = new System.Windows.Forms.TextBox();
			this.textCuentaDestino = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.textGlosa = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.textCuentaOrigen = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.comboCompania = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.comboCuentasOrigen = new System.Windows.Forms.ComboBox();
			this.label11 = new System.Windows.Forms.Label();
			this.toolBarra.SuspendLayout();
			this.tabControlConfiguracion.SuspendLayout();
			this.tabPageLista.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridConfiguracion)).BeginInit();
			this.contextMenuStrip1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.tabPageMantenedor.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox2.SuspendLayout();
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
			this.toolBarra.Size = new System.Drawing.Size(803, 31);
			this.toolBarra.TabIndex = 5;
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
			// tabControlConfiguracion
			// 
			this.tabControlConfiguracion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tabControlConfiguracion.Controls.Add(this.tabPageLista);
			this.tabControlConfiguracion.Controls.Add(this.tabPageMantenedor);
			this.tabControlConfiguracion.Location = new System.Drawing.Point(12, 43);
			this.tabControlConfiguracion.Name = "tabControlConfiguracion";
			this.tabControlConfiguracion.SelectedIndex = 0;
			this.tabControlConfiguracion.Size = new System.Drawing.Size(778, 363);
			this.tabControlConfiguracion.TabIndex = 6;
			this.tabControlConfiguracion.SelectedIndexChanged += new System.EventHandler(this.tabControlConfiguracion_SelectedIndexChanged);
			// 
			// tabPageLista
			// 
			this.tabPageLista.Controls.Add(this.gridConfiguracion);
			this.tabPageLista.Controls.Add(this.groupBox1);
			this.tabPageLista.Location = new System.Drawing.Point(4, 22);
			this.tabPageLista.Name = "tabPageLista";
			this.tabPageLista.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageLista.Size = new System.Drawing.Size(770, 337);
			this.tabPageLista.TabIndex = 0;
			this.tabPageLista.Text = "Configuraciones";
			this.tabPageLista.UseVisualStyleBackColor = true;
			// 
			// gridConfiguracion
			// 
			this.gridConfiguracion.AllowUserToAddRows = false;
			this.gridConfiguracion.AllowUserToDeleteRows = false;
			this.gridConfiguracion.AllowUserToResizeRows = false;
			this.gridConfiguracion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.gridConfiguracion.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
			this.gridConfiguracion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.gridConfiguracion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdCompania,
            this.colNombre,
            this.colCuentaOrigen,
            this.colGlosa,
            this.colCuentaDestino,
            this.colCuentaDestinoNC,
            this.colContraCuenta,
            this.colNgCuentaDestino,
            this.colNgCuentaDestinoNC,
            this.colNgContraCuenta});
			this.gridConfiguracion.ContextMenuStrip = this.contextMenuStrip1;
			dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.gridConfiguracion.DefaultCellStyle = dataGridViewCellStyle5;
			this.gridConfiguracion.Location = new System.Drawing.Point(15, 102);
			this.gridConfiguracion.MultiSelect = false;
			this.gridConfiguracion.Name = "gridConfiguracion";
			this.gridConfiguracion.ReadOnly = true;
			dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.gridConfiguracion.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
			this.gridConfiguracion.RowHeadersVisible = false;
			this.gridConfiguracion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.gridConfiguracion.Size = new System.Drawing.Size(744, 222);
			this.gridConfiguracion.TabIndex = 7;
			this.gridConfiguracion.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridConfiguracion_CellDoubleClick);
			// 
			// colIdCompania
			// 
			this.colIdCompania.HeaderText = "Id";
			this.colIdCompania.Name = "colIdCompania";
			this.colIdCompania.ReadOnly = true;
			this.colIdCompania.Width = 50;
			// 
			// colNombre
			// 
			this.colNombre.HeaderText = "Compañia";
			this.colNombre.Name = "colNombre";
			this.colNombre.ReadOnly = true;
			this.colNombre.Visible = false;
			this.colNombre.Width = 180;
			// 
			// colCuentaOrigen
			// 
			this.colCuentaOrigen.HeaderText = " Origen";
			this.colCuentaOrigen.Name = "colCuentaOrigen";
			this.colCuentaOrigen.ReadOnly = true;
			this.colCuentaOrigen.Width = 60;
			// 
			// colGlosa
			// 
			this.colGlosa.HeaderText = "Descripción Ajuste";
			this.colGlosa.Name = "colGlosa";
			this.colGlosa.ReadOnly = true;
			this.colGlosa.Width = 150;
			// 
			// colCuentaDestino
			// 
			this.colCuentaDestino.HeaderText = "+ Destino";
			this.colCuentaDestino.Name = "colCuentaDestino";
			this.colCuentaDestino.ReadOnly = true;
			this.colCuentaDestino.Width = 70;
			// 
			// colCuentaDestinoNC
			// 
			this.colCuentaDestinoNC.HeaderText = "+ DestinoNC";
			this.colCuentaDestinoNC.Name = "colCuentaDestinoNC";
			this.colCuentaDestinoNC.ReadOnly = true;
			this.colCuentaDestinoNC.Width = 80;
			// 
			// colContraCuenta
			// 
			this.colContraCuenta.HeaderText = "+ Contra Cta";
			this.colContraCuenta.Name = "colContraCuenta";
			this.colContraCuenta.ReadOnly = true;
			this.colContraCuenta.Width = 80;
			// 
			// colNgCuentaDestino
			// 
			this.colNgCuentaDestino.HeaderText = "- Destino";
			this.colNgCuentaDestino.Name = "colNgCuentaDestino";
			this.colNgCuentaDestino.ReadOnly = true;
			this.colNgCuentaDestino.Width = 70;
			// 
			// colNgCuentaDestinoNC
			// 
			this.colNgCuentaDestinoNC.HeaderText = "- DestinoNC";
			this.colNgCuentaDestinoNC.Name = "colNgCuentaDestinoNC";
			this.colNgCuentaDestinoNC.ReadOnly = true;
			this.colNgCuentaDestinoNC.Width = 80;
			// 
			// colNgContraCuenta
			// 
			this.colNgContraCuenta.HeaderText = "- Contra Cta";
			this.colNgContraCuenta.Name = "colNgContraCuenta";
			this.colNgContraCuenta.ReadOnly = true;
			this.colNgContraCuenta.Width = 80;
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
			this.nuevoToolStripMenuItem.Image = global::NewConsolidado.Properties.Resources.rsc_24_Nuevo;
			this.nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
			this.nuevoToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
			this.nuevoToolStripMenuItem.Text = "Nuevo";
			this.nuevoToolStripMenuItem.Click += new System.EventHandler(this.nuevoToolStripMenuItem_Click);
			// 
			// editarToolStripMenuItem
			// 
			this.editarToolStripMenuItem.Image = global::NewConsolidado.Properties.Resources.rsc_24_Editar;
			this.editarToolStripMenuItem.Name = "editarToolStripMenuItem";
			this.editarToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
			this.editarToolStripMenuItem.Text = "Editar";
			this.editarToolStripMenuItem.Click += new System.EventHandler(this.editarToolStripMenuItem_Click);
			// 
			// eliminarToolStripMenuItem
			// 
			this.eliminarToolStripMenuItem.Image = global::NewConsolidado.Properties.Resources.rsc_24_Borrar;
			this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
			this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
			this.eliminarToolStripMenuItem.Text = "Eliminar";
			this.eliminarToolStripMenuItem.Click += new System.EventHandler(this.eliminarToolStripMenuItem_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label11);
			this.groupBox1.Controls.Add(this.comboCuentasOrigen);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.comboCompanias);
			this.groupBox1.Location = new System.Drawing.Point(15, 15);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(744, 71);
			this.groupBox1.TabIndex = 8;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Filtros";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(10, 21);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(59, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Compañias";
			// 
			// comboCompanias
			// 
			this.comboCompanias.FormattingEnabled = true;
			this.comboCompanias.Location = new System.Drawing.Point(8, 40);
			this.comboCompanias.Name = "comboCompanias";
			this.comboCompanias.Size = new System.Drawing.Size(255, 21);
			this.comboCompanias.TabIndex = 0;
			this.comboCompanias.SelectedIndexChanged += new System.EventHandler(this.comboCompanias_SelectedIndexChanged);
			// 
			// tabPageMantenedor
			// 
			this.tabPageMantenedor.Controls.Add(this.groupBox3);
			this.tabPageMantenedor.Controls.Add(this.groupBox2);
			this.tabPageMantenedor.Controls.Add(this.textGlosa);
			this.tabPageMantenedor.Controls.Add(this.label4);
			this.tabPageMantenedor.Controls.Add(this.textCuentaOrigen);
			this.tabPageMantenedor.Controls.Add(this.label3);
			this.tabPageMantenedor.Controls.Add(this.comboCompania);
			this.tabPageMantenedor.Controls.Add(this.label2);
			this.tabPageMantenedor.Location = new System.Drawing.Point(4, 22);
			this.tabPageMantenedor.Name = "tabPageMantenedor";
			this.tabPageMantenedor.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageMantenedor.Size = new System.Drawing.Size(770, 337);
			this.tabPageMantenedor.TabIndex = 1;
			this.tabPageMantenedor.Text = "Mantenedor";
			this.tabPageMantenedor.UseVisualStyleBackColor = true;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.textnNgContraCuenta);
			this.groupBox3.Controls.Add(this.textNgCuentaDestinoNC);
			this.groupBox3.Controls.Add(this.textNgCuentaDestino);
			this.groupBox3.Controls.Add(this.label8);
			this.groupBox3.Controls.Add(this.label9);
			this.groupBox3.Controls.Add(this.label10);
			this.groupBox3.Location = new System.Drawing.Point(381, 171);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(338, 140);
			this.groupBox3.TabIndex = 7;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Cuentas Cuando el valor es negativo";
			// 
			// textnNgContraCuenta
			// 
			this.textnNgContraCuenta.Location = new System.Drawing.Point(205, 90);
			this.textnNgContraCuenta.Name = "textnNgContraCuenta";
			this.textnNgContraCuenta.Size = new System.Drawing.Size(100, 20);
			this.textnNgContraCuenta.TabIndex = 11;
			// 
			// textNgCuentaDestinoNC
			// 
			this.textNgCuentaDestinoNC.Location = new System.Drawing.Point(205, 60);
			this.textNgCuentaDestinoNC.Name = "textNgCuentaDestinoNC";
			this.textNgCuentaDestinoNC.Size = new System.Drawing.Size(100, 20);
			this.textNgCuentaDestinoNC.TabIndex = 10;
			// 
			// textNgCuentaDestino
			// 
			this.textNgCuentaDestino.Location = new System.Drawing.Point(205, 30);
			this.textNgCuentaDestino.Name = "textNgCuentaDestino";
			this.textNgCuentaDestino.Size = new System.Drawing.Size(100, 20);
			this.textNgCuentaDestino.TabIndex = 9;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(112, 93);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(75, 13);
			this.label8.TabIndex = 8;
			this.label8.Text = "Contra Cuenta";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(27, 63);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(160, 13);
			this.label9.TabIndex = 7;
			this.label9.Text = "Cuenta Destino No Controladora";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(107, 33);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(80, 13);
			this.label10.TabIndex = 6;
			this.label10.Text = "Cuenta Destino";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.textContraCuenta);
			this.groupBox2.Controls.Add(this.textCuentaDestinoNC);
			this.groupBox2.Controls.Add(this.textCuentaDestino);
			this.groupBox2.Controls.Add(this.label7);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Location = new System.Drawing.Point(22, 171);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(329, 140);
			this.groupBox2.TabIndex = 6;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Cuentas Cuando el valor es positivo";
			// 
			// textContraCuenta
			// 
			this.textContraCuenta.Location = new System.Drawing.Point(194, 91);
			this.textContraCuenta.Name = "textContraCuenta";
			this.textContraCuenta.Size = new System.Drawing.Size(100, 20);
			this.textContraCuenta.TabIndex = 5;
			// 
			// textCuentaDestinoNC
			// 
			this.textCuentaDestinoNC.Location = new System.Drawing.Point(194, 61);
			this.textCuentaDestinoNC.Name = "textCuentaDestinoNC";
			this.textCuentaDestinoNC.Size = new System.Drawing.Size(100, 20);
			this.textCuentaDestinoNC.TabIndex = 4;
			// 
			// textCuentaDestino
			// 
			this.textCuentaDestino.Location = new System.Drawing.Point(194, 31);
			this.textCuentaDestino.Name = "textCuentaDestino";
			this.textCuentaDestino.Size = new System.Drawing.Size(100, 20);
			this.textCuentaDestino.TabIndex = 3;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(101, 94);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(75, 13);
			this.label7.TabIndex = 2;
			this.label7.Text = "Contra Cuenta";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(16, 64);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(160, 13);
			this.label6.TabIndex = 1;
			this.label6.Text = "Cuenta Destino No Controladora";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(96, 34);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(80, 13);
			this.label5.TabIndex = 0;
			this.label5.Text = "Cuenta Destino";
			// 
			// textGlosa
			// 
			this.textGlosa.Location = new System.Drawing.Point(149, 120);
			this.textGlosa.Name = "textGlosa";
			this.textGlosa.Size = new System.Drawing.Size(318, 20);
			this.textGlosa.TabIndex = 5;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(30, 123);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(90, 13);
			this.label4.TabIndex = 4;
			this.label4.Text = "Glosa para Ajuste";
			// 
			// textCuentaOrigen
			// 
			this.textCuentaOrigen.Location = new System.Drawing.Point(149, 83);
			this.textCuentaOrigen.Name = "textCuentaOrigen";
			this.textCuentaOrigen.Size = new System.Drawing.Size(100, 20);
			this.textCuentaOrigen.TabIndex = 3;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(30, 86);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(90, 13);
			this.label3.TabIndex = 2;
			this.label3.Text = "Cuenta de Origen";
			// 
			// comboCompania
			// 
			this.comboCompania.FormattingEnabled = true;
			this.comboCompania.Location = new System.Drawing.Point(149, 43);
			this.comboCompania.Name = "comboCompania";
			this.comboCompania.Size = new System.Drawing.Size(273, 21);
			this.comboCompania.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(30, 46);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(54, 13);
			this.label2.TabIndex = 0;
			this.label2.Text = "Compañia";
			// 
			// comboCuentasOrigen
			// 
			this.comboCuentasOrigen.FormattingEnabled = true;
			this.comboCuentasOrigen.Location = new System.Drawing.Point(305, 39);
			this.comboCuentasOrigen.Name = "comboCuentasOrigen";
			this.comboCuentasOrigen.Size = new System.Drawing.Size(154, 21);
			this.comboCuentasOrigen.TabIndex = 2;
			this.comboCuentasOrigen.SelectedIndexChanged += new System.EventHandler(this.comboCuentasOrigen_SelectedIndexChanged);
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(305, 20);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(95, 13);
			this.label11.TabIndex = 3;
			this.label11.Text = "Cuentas de Origen";
			// 
			// MantenedorConfiguracionAjustesAutomaticos
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(803, 417);
			this.Controls.Add(this.tabControlConfiguracion);
			this.Controls.Add(this.toolBarra);
			this.Name = "MantenedorConfiguracionAjustesAutomaticos";
			this.ShowIcon = false;
			this.Text = "MantenedorConfiguracionAjustesAutomaticos";
			this.Load += new System.EventHandler(this.MantenedorConfiguracionAjustesAutomaticos_Load);
			this.toolBarra.ResumeLayout(false);
			this.toolBarra.PerformLayout();
			this.tabControlConfiguracion.ResumeLayout(false);
			this.tabPageLista.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridConfiguracion)).EndInit();
			this.contextMenuStrip1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.tabPageMantenedor.ResumeLayout(false);
			this.tabPageMantenedor.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
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
		private System.Windows.Forms.TabControl tabControlConfiguracion;
		private System.Windows.Forms.TabPage tabPageLista;
		private System.Windows.Forms.TabPage tabPageMantenedor;
		private System.Windows.Forms.DataGridView gridConfiguracion;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox comboCompanias;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TextBox textGlosa;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textCuentaOrigen;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox comboCompania;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.TextBox textCuentaDestinoNC;
		private System.Windows.Forms.TextBox textCuentaDestino;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textnNgContraCuenta;
		private System.Windows.Forms.TextBox textNgCuentaDestinoNC;
		private System.Windows.Forms.TextBox textNgCuentaDestino;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox textContraCuenta;
		private System.Windows.Forms.DataGridViewTextBoxColumn colIdCompania;
		private System.Windows.Forms.DataGridViewTextBoxColumn colNombre;
		private System.Windows.Forms.DataGridViewTextBoxColumn colCuentaOrigen;
		private System.Windows.Forms.DataGridViewTextBoxColumn colGlosa;
		private System.Windows.Forms.DataGridViewTextBoxColumn colCuentaDestino;
		private System.Windows.Forms.DataGridViewTextBoxColumn colCuentaDestinoNC;
		private System.Windows.Forms.DataGridViewTextBoxColumn colContraCuenta;
		private System.Windows.Forms.DataGridViewTextBoxColumn colNgCuentaDestino;
		private System.Windows.Forms.DataGridViewTextBoxColumn colNgCuentaDestinoNC;
		private System.Windows.Forms.DataGridViewTextBoxColumn colNgContraCuenta;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.ComboBox comboCuentasOrigen;
	}
}