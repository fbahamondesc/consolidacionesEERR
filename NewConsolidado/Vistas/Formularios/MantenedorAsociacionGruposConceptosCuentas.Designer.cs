namespace NewConsolidado.Vistas.Formularios
{
	partial class MantenedorAsociacionGruposConceptosCuentas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolBarra = new System.Windows.Forms.ToolStrip();
            this.toolSalir = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolNuevo = new System.Windows.Forms.ToolStripButton();
            this.toolEditar = new System.Windows.Forms.ToolStripButton();
            this.toolEliminar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolCancelar = new System.Windows.Forms.ToolStripButton();
            this.toolGrabar = new System.Windows.Forms.ToolStripButton();
            this.tabControlAsocia = new System.Windows.Forms.TabControl();
            this.tabPageLista = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboCuentas = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.comboGrupos = new System.Windows.Forms.ComboBox();
            this.comboConceptos = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.gridAsociacion = new System.Windows.Forms.DataGridView();
            this.tabPageMantencion = new System.Windows.Forms.TabPage();
            this.textRegistro = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textCuenta = new System.Windows.Forms.TextBox();
            this.comboCuenta = new System.Windows.Forms.ComboBox();
            this.textConcepto = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboConcepto = new System.Windows.Forms.ComboBox();
            this.textGrupo = new System.Windows.Forms.TextBox();
            this.comboGrupo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colIdRegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdGrupo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGrupoDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdConcepto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colConceptoDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdCuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCuentaDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonReplicarPlantilla = new System.Windows.Forms.ToolStripButton();
            this.toolBarra.SuspendLayout();
            this.tabControlAsocia.SuspendLayout();
            this.tabPageLista.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAsociacion)).BeginInit();
            this.tabPageMantencion.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            this.toolGrabar,
            this.toolStripSeparator1,
            this.toolStripButtonReplicarPlantilla});
            this.toolBarra.Location = new System.Drawing.Point(0, 0);
            this.toolBarra.Name = "toolBarra";
            this.toolBarra.Size = new System.Drawing.Size(765, 31);
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
            // tabControlAsocia
            // 
            this.tabControlAsocia.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlAsocia.Controls.Add(this.tabPageLista);
            this.tabControlAsocia.Controls.Add(this.tabPageMantencion);
            this.tabControlAsocia.Location = new System.Drawing.Point(11, 39);
            this.tabControlAsocia.Name = "tabControlAsocia";
            this.tabControlAsocia.SelectedIndex = 0;
            this.tabControlAsocia.Size = new System.Drawing.Size(742, 397);
            this.tabControlAsocia.TabIndex = 4;
            this.tabControlAsocia.SelectedIndexChanged += new System.EventHandler(this.tabControlAsocia_SelectedIndexChanged);
            // 
            // tabPageLista
            // 
            this.tabPageLista.Controls.Add(this.groupBox2);
            this.tabPageLista.Controls.Add(this.gridAsociacion);
            this.tabPageLista.Location = new System.Drawing.Point(4, 22);
            this.tabPageLista.Name = "tabPageLista";
            this.tabPageLista.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLista.Size = new System.Drawing.Size(734, 371);
            this.tabPageLista.TabIndex = 0;
            this.tabPageLista.Text = "Conceptos";
            this.tabPageLista.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.comboCuentas);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.comboGrupos);
            this.groupBox2.Controls.Add(this.comboConceptos);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(6, 10);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(722, 73);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filtros";
            // 
            // comboCuentas
            // 
            this.comboCuentas.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.comboCuentas.FormattingEnabled = true;
            this.comboCuentas.Location = new System.Drawing.Point(476, 37);
            this.comboCuentas.Name = "comboCuentas";
            this.comboCuentas.Size = new System.Drawing.Size(240, 21);
            this.comboCuentas.TabIndex = 7;
            this.comboCuentas.SelectedIndexChanged += new System.EventHandler(this.comboCuentas_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Grupo";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(474, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Cuenta";
            // 
            // comboGrupos
            // 
            this.comboGrupos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboGrupos.FormattingEnabled = true;
            this.comboGrupos.Location = new System.Drawing.Point(9, 37);
            this.comboGrupos.Name = "comboGrupos";
            this.comboGrupos.Size = new System.Drawing.Size(204, 21);
            this.comboGrupos.TabIndex = 2;
            this.comboGrupos.SelectedIndexChanged += new System.EventHandler(this.comboGrupos_SelectedIndexChanged);
            // 
            // comboConceptos
            // 
            this.comboConceptos.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.comboConceptos.FormattingEnabled = true;
            this.comboConceptos.Location = new System.Drawing.Point(223, 37);
            this.comboConceptos.Name = "comboConceptos";
            this.comboConceptos.Size = new System.Drawing.Size(247, 21);
            this.comboConceptos.TabIndex = 4;
            this.comboConceptos.SelectedIndexChanged += new System.EventHandler(this.comboConceptos_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(221, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Concepto";
            // 
            // gridAsociacion
            // 
            this.gridAsociacion.AllowUserToAddRows = false;
            this.gridAsociacion.AllowUserToDeleteRows = false;
            this.gridAsociacion.AllowUserToResizeRows = false;
            this.gridAsociacion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridAsociacion.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridAsociacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridAsociacion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdRegistro,
            this.colIdGrupo,
            this.colGrupoDesc,
            this.colIdConcepto,
            this.colConceptoDesc,
            this.colIdCuenta,
            this.colCuentaDesc});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridAsociacion.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridAsociacion.Location = new System.Drawing.Point(6, 89);
            this.gridAsociacion.MultiSelect = false;
            this.gridAsociacion.Name = "gridAsociacion";
            this.gridAsociacion.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridAsociacion.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridAsociacion.RowHeadersVisible = false;
            this.gridAsociacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridAsociacion.Size = new System.Drawing.Size(722, 276);
            this.gridAsociacion.TabIndex = 0;
            this.gridAsociacion.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridAsociacion_CellDoubleClick);
            // 
            // tabPageMantencion
            // 
            this.tabPageMantencion.Controls.Add(this.textRegistro);
            this.tabPageMantencion.Controls.Add(this.groupBox1);
            this.tabPageMantencion.Location = new System.Drawing.Point(4, 22);
            this.tabPageMantencion.Name = "tabPageMantencion";
            this.tabPageMantencion.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMantencion.Size = new System.Drawing.Size(667, 348);
            this.tabPageMantencion.TabIndex = 1;
            this.tabPageMantencion.Text = "Mantenedor";
            this.tabPageMantencion.UseVisualStyleBackColor = true;
            // 
            // textRegistro
            // 
            this.textRegistro.Location = new System.Drawing.Point(116, 181);
            this.textRegistro.Name = "textRegistro";
            this.textRegistro.Size = new System.Drawing.Size(100, 20);
            this.textRegistro.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textCuenta);
            this.groupBox1.Controls.Add(this.comboCuenta);
            this.groupBox1.Controls.Add(this.textConcepto);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.comboConcepto);
            this.groupBox1.Controls.Add(this.textGrupo);
            this.groupBox1.Controls.Add(this.comboGrupo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(19, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(539, 155);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Asociación";
            // 
            // textCuenta
            // 
            this.textCuenta.Location = new System.Drawing.Point(97, 112);
            this.textCuenta.Name = "textCuenta";
            this.textCuenta.Size = new System.Drawing.Size(61, 20);
            this.textCuenta.TabIndex = 6;
            // 
            // comboCuenta
            // 
            this.comboCuenta.FormattingEnabled = true;
            this.comboCuenta.Location = new System.Drawing.Point(164, 112);
            this.comboCuenta.Name = "comboCuenta";
            this.comboCuenta.Size = new System.Drawing.Size(312, 21);
            this.comboCuenta.TabIndex = 5;
            this.comboCuenta.SelectedIndexChanged += new System.EventHandler(this.comboCuenta_SelectedIndexChanged);
            // 
            // textConcepto
            // 
            this.textConcepto.Location = new System.Drawing.Point(97, 71);
            this.textConcepto.Name = "textConcepto";
            this.textConcepto.Size = new System.Drawing.Size(61, 20);
            this.textConcepto.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Cuenta";
            // 
            // comboConcepto
            // 
            this.comboConcepto.FormattingEnabled = true;
            this.comboConcepto.Location = new System.Drawing.Point(164, 71);
            this.comboConcepto.Name = "comboConcepto";
            this.comboConcepto.Size = new System.Drawing.Size(312, 21);
            this.comboConcepto.TabIndex = 3;
            this.comboConcepto.SelectedIndexChanged += new System.EventHandler(this.comboConcepto_SelectedIndexChanged);
            // 
            // textGrupo
            // 
            this.textGrupo.Location = new System.Drawing.Point(97, 29);
            this.textGrupo.Name = "textGrupo";
            this.textGrupo.Size = new System.Drawing.Size(61, 20);
            this.textGrupo.TabIndex = 2;
            // 
            // comboGrupo
            // 
            this.comboGrupo.FormattingEnabled = true;
            this.comboGrupo.Location = new System.Drawing.Point(164, 29);
            this.comboGrupo.Name = "comboGrupo";
            this.comboGrupo.Size = new System.Drawing.Size(312, 21);
            this.comboGrupo.TabIndex = 1;
            this.comboGrupo.SelectedIndexChanged += new System.EventHandler(this.comboGrupo_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Concepto";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Grupo";
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
            // colIdRegistro
            // 
            this.colIdRegistro.HeaderText = "id";
            this.colIdRegistro.Name = "colIdRegistro";
            this.colIdRegistro.ReadOnly = true;
            this.colIdRegistro.Width = 40;
            // 
            // colIdGrupo
            // 
            this.colIdGrupo.HeaderText = "Grupo";
            this.colIdGrupo.Name = "colIdGrupo";
            this.colIdGrupo.ReadOnly = true;
            this.colIdGrupo.Width = 50;
            // 
            // colGrupoDesc
            // 
            this.colGrupoDesc.HeaderText = "Descripción Grupo";
            this.colGrupoDesc.Name = "colGrupoDesc";
            this.colGrupoDesc.ReadOnly = true;
            this.colGrupoDesc.Width = 140;
            // 
            // colIdConcepto
            // 
            this.colIdConcepto.HeaderText = "Concepto";
            this.colIdConcepto.Name = "colIdConcepto";
            this.colIdConcepto.ReadOnly = true;
            this.colIdConcepto.Width = 55;
            // 
            // colConceptoDesc
            // 
            this.colConceptoDesc.HeaderText = "Descripción Concepto";
            this.colConceptoDesc.Name = "colConceptoDesc";
            this.colConceptoDesc.ReadOnly = true;
            this.colConceptoDesc.Width = 180;
            // 
            // colIdCuenta
            // 
            this.colIdCuenta.HeaderText = "Cuenta";
            this.colIdCuenta.Name = "colIdCuenta";
            this.colIdCuenta.ReadOnly = true;
            this.colIdCuenta.Width = 50;
            // 
            // colCuentaDesc
            // 
            this.colCuentaDesc.HeaderText = "Descripción Cuenta";
            this.colCuentaDesc.Name = "colCuentaDesc";
            this.colCuentaDesc.ReadOnly = true;
            this.colCuentaDesc.Width = 180;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // toolStripButtonReplicarPlantilla
            // 
            this.toolStripButtonReplicarPlantilla.Image = global::NewConsolidado.Properties.Resources.rsc_24_Pegar;
            this.toolStripButtonReplicarPlantilla.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonReplicarPlantilla.Name = "toolStripButtonReplicarPlantilla";
            this.toolStripButtonReplicarPlantilla.Size = new System.Drawing.Size(115, 28);
            this.toolStripButtonReplicarPlantilla.Text = "Copiar Plantilla";
            this.toolStripButtonReplicarPlantilla.Click += new System.EventHandler(this.toolStripButtonReplicarPlantilla_Click);
            // 
            // MantenedorAsociacionGruposConceptosCuentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 448);
            this.Controls.Add(this.toolBarra);
            this.Controls.Add(this.tabControlAsocia);
            this.Name = "MantenedorAsociacionGruposConceptosCuentas";
            this.ShowIcon = false;
            this.Text = "MantencionAsociacionGruposConceptosCuentas";
            this.Load += new System.EventHandler(this.MantencionAsociacionGruposConceptosCuentas_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MantencionAsociacionGruposConceptosCuentas_FormClosed);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MantencionAsociacionGruposConceptosCuentas_FormClosing);
            this.toolBarra.ResumeLayout(false);
            this.toolBarra.PerformLayout();
            this.tabControlAsocia.ResumeLayout(false);
            this.tabPageLista.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAsociacion)).EndInit();
            this.tabPageMantencion.ResumeLayout(false);
            this.tabPageMantencion.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
		private System.Windows.Forms.TabControl tabControlAsocia;
		private System.Windows.Forms.TabPage tabPageLista;
		private System.Windows.Forms.DataGridView gridAsociacion;
		private System.Windows.Forms.TabPage tabPageMantencion;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox comboConceptos;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ComboBox comboGrupos;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ComboBox comboCuentas;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox textGrupo;
		private System.Windows.Forms.ComboBox comboGrupo;
		private System.Windows.Forms.TextBox textCuenta;
		private System.Windows.Forms.ComboBox comboCuenta;
		private System.Windows.Forms.TextBox textConcepto;
		private System.Windows.Forms.ComboBox comboConcepto;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
		private System.Windows.Forms.TextBox textRegistro;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdRegistro;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdGrupo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGrupoDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdConcepto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colConceptoDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdCuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCuentaDesc;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButtonReplicarPlantilla;
	}
}