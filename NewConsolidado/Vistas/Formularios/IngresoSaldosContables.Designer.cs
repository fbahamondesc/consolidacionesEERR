namespace NewConsolidado.Vistas.Formularios
{
	partial class IngresoSaldosContables
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.textCompania = new System.Windows.Forms.TextBox();
            this.buttonCompania = new System.Windows.Forms.Button();
            this.laNombreCompania = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textPeriodo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textCuentaContable = new System.Windows.Forms.TextBox();
            this.buttonCuenta = new System.Windows.Forms.Button();
            this.laDescripcionCuenta = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textAcumulaCredito = new System.Windows.Forms.TextBox();
            this.textAcumulaDebito = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textMonto = new System.Windows.Forms.TextBox();
            this.toolBarra = new System.Windows.Forms.ToolStrip();
            this.toolSalir = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolNuevo = new System.Windows.Forms.ToolStripButton();
            this.toolEditar = new System.Windows.Forms.ToolStripButton();
            this.toolEliminar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolGrabar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonImportar = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonVerFormato = new System.Windows.Forms.ToolStripButton();
            this.gridSaldos = new System.Windows.Forms.DataGridView();
            this.colPeriodo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdCuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescripcionCuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLibro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrigen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDebito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCredito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTipoCuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdRegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.laTipo = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.toolBarra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSaldos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Compañia";
            // 
            // textCompania
            // 
            this.textCompania.Location = new System.Drawing.Point(107, 48);
            this.textCompania.Name = "textCompania";
            this.textCompania.Size = new System.Drawing.Size(65, 20);
            this.textCompania.TabIndex = 1;
            this.textCompania.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textCompania_KeyUp);
            this.textCompania.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textCompania_KeyPress);
            // 
            // buttonCompania
            // 
            this.buttonCompania.Location = new System.Drawing.Point(219, 46);
            this.buttonCompania.Name = "buttonCompania";
            this.buttonCompania.Size = new System.Drawing.Size(75, 23);
            this.buttonCompania.TabIndex = 2;
            this.buttonCompania.Text = "Buscar";
            this.buttonCompania.UseVisualStyleBackColor = true;
            this.buttonCompania.Click += new System.EventHandler(this.buttonCompania_Click);
            // 
            // laNombreCompania
            // 
            this.laNombreCompania.AutoSize = true;
            this.laNombreCompania.Location = new System.Drawing.Point(105, 74);
            this.laNombreCompania.Name = "laNombreCompania";
            this.laNombreCompania.Size = new System.Drawing.Size(91, 13);
            this.laNombreCompania.TabIndex = 3;
            this.laNombreCompania.Text = "NombreCompania";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Periodo";
            // 
            // textPeriodo
            // 
            this.textPeriodo.Location = new System.Drawing.Point(107, 94);
            this.textPeriodo.Name = "textPeriodo";
            this.textPeriodo.Size = new System.Drawing.Size(65, 20);
            this.textPeriodo.TabIndex = 5;
            this.textPeriodo.Leave += new System.EventHandler(this.textPeriodo_Leave);
            this.textPeriodo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textPeriodo_KeyUp);
            this.textPeriodo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textPeriodo_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Cuenta Contable";
            // 
            // textCuentaContable
            // 
            this.textCuentaContable.Location = new System.Drawing.Point(107, 121);
            this.textCuentaContable.Name = "textCuentaContable";
            this.textCuentaContable.Size = new System.Drawing.Size(65, 20);
            this.textCuentaContable.TabIndex = 7;
            this.textCuentaContable.TextChanged += new System.EventHandler(this.textCuentaContable_TextChanged);
            this.textCuentaContable.Leave += new System.EventHandler(this.textCuentaContable_Leave);
            this.textCuentaContable.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textCuentaContable_KeyUp);
            this.textCuentaContable.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textCuentaContable_KeyPress);
            // 
            // buttonCuenta
            // 
            this.buttonCuenta.Location = new System.Drawing.Point(219, 119);
            this.buttonCuenta.Name = "buttonCuenta";
            this.buttonCuenta.Size = new System.Drawing.Size(75, 23);
            this.buttonCuenta.TabIndex = 8;
            this.buttonCuenta.Text = "Buscar";
            this.buttonCuenta.UseVisualStyleBackColor = true;
            this.buttonCuenta.Click += new System.EventHandler(this.buttonCuenta_Click);
            // 
            // laDescripcionCuenta
            // 
            this.laDescripcionCuenta.AutoSize = true;
            this.laDescripcionCuenta.Location = new System.Drawing.Point(137, 146);
            this.laDescripcionCuenta.Name = "laDescripcionCuenta";
            this.laDescripcionCuenta.Size = new System.Drawing.Size(97, 13);
            this.laDescripcionCuenta.TabIndex = 9;
            this.laDescripcionCuenta.Text = "DescripcionCuenta";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textAcumulaCredito);
            this.groupBox1.Controls.Add(this.textAcumulaDebito);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(354, 43);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(258, 145);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Acumulado del periodo";
            // 
            // textAcumulaCredito
            // 
            this.textAcumulaCredito.Location = new System.Drawing.Point(88, 86);
            this.textAcumulaCredito.Name = "textAcumulaCredito";
            this.textAcumulaCredito.ReadOnly = true;
            this.textAcumulaCredito.Size = new System.Drawing.Size(147, 20);
            this.textAcumulaCredito.TabIndex = 3;
            this.textAcumulaCredito.TabStop = false;
            this.textAcumulaCredito.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textAcumulaDebito
            // 
            this.textAcumulaDebito.Location = new System.Drawing.Point(88, 40);
            this.textAcumulaDebito.Name = "textAcumulaDebito";
            this.textAcumulaDebito.ReadOnly = true;
            this.textAcumulaDebito.Size = new System.Drawing.Size(147, 20);
            this.textAcumulaDebito.TabIndex = 2;
            this.textAcumulaDebito.TabStop = false;
            this.textAcumulaDebito.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Credito";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Debito";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 170);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Monto";
            // 
            // textMonto
            // 
            this.textMonto.Location = new System.Drawing.Point(107, 167);
            this.textMonto.Name = "textMonto";
            this.textMonto.Size = new System.Drawing.Size(114, 20);
            this.textMonto.TabIndex = 14;
            this.textMonto.Leave += new System.EventHandler(this.textMonto_Leave);
            this.textMonto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textMonto_KeyPress);
            this.textMonto.Enter += new System.EventHandler(this.textMonto_Enter);
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
            this.toolStripSeparator1,
            this.toolGrabar,
            this.toolStripSeparator2,
            this.toolStripButtonImportar,
            this.toolStripButtonVerFormato});
            this.toolBarra.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolBarra.Location = new System.Drawing.Point(0, 0);
            this.toolBarra.Name = "toolBarra";
            this.toolBarra.Padding = new System.Windows.Forms.Padding(2);
            this.toolBarra.Size = new System.Drawing.Size(677, 35);
            this.toolBarra.TabIndex = 16;
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
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
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // toolStripButtonImportar
            // 
            this.toolStripButtonImportar.Image = global::NewConsolidado.Properties.Resources.rsc_24_MoverAbajo;
            this.toolStripButtonImportar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonImportar.Name = "toolStripButtonImportar";
            this.toolStripButtonImportar.Size = new System.Drawing.Size(81, 28);
            this.toolStripButtonImportar.Text = "Importar";
            this.toolStripButtonImportar.Click += new System.EventHandler(this.toolStripButtonImportar_Click);
            // 
            // toolStripButtonVerFormato
            // 
            this.toolStripButtonVerFormato.Image = global::NewConsolidado.Properties.Resources.rsc_24_Preferencias;
            this.toolStripButtonVerFormato.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonVerFormato.Name = "toolStripButtonVerFormato";
            this.toolStripButtonVerFormato.Size = new System.Drawing.Size(100, 28);
            this.toolStripButtonVerFormato.Text = "Ver Formato";
            this.toolStripButtonVerFormato.Click += new System.EventHandler(this.toolStripButtonVerFormato_Click);
            // 
            // gridSaldos
            // 
            this.gridSaldos.AllowUserToAddRows = false;
            this.gridSaldos.AllowUserToDeleteRows = false;
            this.gridSaldos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridSaldos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridSaldos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridSaldos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPeriodo,
            this.colIdCuenta,
            this.colDescripcionCuenta,
            this.colLibro,
            this.colOrigen,
            this.colDebito,
            this.colCredito,
            this.colTipoCuenta,
            this.colIdRegistro});
            this.gridSaldos.Location = new System.Drawing.Point(12, 207);
            this.gridSaldos.MultiSelect = false;
            this.gridSaldos.Name = "gridSaldos";
            this.gridSaldos.ReadOnly = true;
            this.gridSaldos.RowHeadersVisible = false;
            this.gridSaldos.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.gridSaldos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridSaldos.Size = new System.Drawing.Size(653, 382);
            this.gridSaldos.TabIndex = 17;
            this.gridSaldos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridSaldos_CellDoubleClick);
            // 
            // colPeriodo
            // 
            this.colPeriodo.HeaderText = "Periodo";
            this.colPeriodo.Name = "colPeriodo";
            this.colPeriodo.ReadOnly = true;
            this.colPeriodo.Width = 50;
            // 
            // colIdCuenta
            // 
            this.colIdCuenta.HeaderText = "Cuenta";
            this.colIdCuenta.Name = "colIdCuenta";
            this.colIdCuenta.ReadOnly = true;
            this.colIdCuenta.Width = 60;
            // 
            // colDescripcionCuenta
            // 
            this.colDescripcionCuenta.HeaderText = "Descripción";
            this.colDescripcionCuenta.Name = "colDescripcionCuenta";
            this.colDescripcionCuenta.ReadOnly = true;
            this.colDescripcionCuenta.Width = 130;
            // 
            // colLibro
            // 
            this.colLibro.HeaderText = "Libro";
            this.colLibro.Name = "colLibro";
            this.colLibro.ReadOnly = true;
            this.colLibro.Width = 70;
            // 
            // colOrigen
            // 
            this.colOrigen.HeaderText = "Origen";
            this.colOrigen.Name = "colOrigen";
            this.colOrigen.ReadOnly = true;
            this.colOrigen.Width = 70;
            // 
            // colDebito
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colDebito.DefaultCellStyle = dataGridViewCellStyle3;
            this.colDebito.HeaderText = "Debito";
            this.colDebito.Name = "colDebito";
            this.colDebito.ReadOnly = true;
            // 
            // colCredito
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colCredito.DefaultCellStyle = dataGridViewCellStyle4;
            this.colCredito.HeaderText = "Credito";
            this.colCredito.Name = "colCredito";
            this.colCredito.ReadOnly = true;
            // 
            // colTipoCuenta
            // 
            this.colTipoCuenta.HeaderText = "Tipo";
            this.colTipoCuenta.Name = "colTipoCuenta";
            this.colTipoCuenta.ReadOnly = true;
            this.colTipoCuenta.Width = 25;
            // 
            // colIdRegistro
            // 
            this.colIdRegistro.HeaderText = "IdRegistro";
            this.colIdRegistro.Name = "colIdRegistro";
            this.colIdRegistro.ReadOnly = true;
            this.colIdRegistro.Width = 20;
            // 
            // laTipo
            // 
            this.laTipo.AutoSize = true;
            this.laTipo.Location = new System.Drawing.Point(107, 146);
            this.laTipo.Name = "laTipo";
            this.laTipo.Size = new System.Drawing.Size(20, 13);
            this.laTipo.TabIndex = 18;
            this.laTipo.Text = "1A";
            // 
            // IngresoSaldosContables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 600);
            this.Controls.Add(this.laTipo);
            this.Controls.Add(this.gridSaldos);
            this.Controls.Add(this.toolBarra);
            this.Controls.Add(this.textMonto);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.laDescripcionCuenta);
            this.Controls.Add(this.buttonCuenta);
            this.Controls.Add(this.textCuentaContable);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textPeriodo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.laNombreCompania);
            this.Controls.Add(this.buttonCompania);
            this.Controls.Add(this.textCompania);
            this.Controls.Add(this.label1);
            this.Name = "IngresoSaldosContables";
            this.ShowIcon = false;
            this.Text = "IngresoSaldosContables";
            this.Load += new System.EventHandler(this.IngresoSaldosContables_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolBarra.ResumeLayout(false);
            this.toolBarra.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSaldos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textCompania;
		private System.Windows.Forms.Button buttonCompania;
		private System.Windows.Forms.Label laNombreCompania;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textPeriodo;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textCuentaContable;
		private System.Windows.Forms.Button buttonCuenta;
		private System.Windows.Forms.Label laDescripcionCuenta;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textAcumulaCredito;
		private System.Windows.Forms.TextBox textAcumulaDebito;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox textMonto;
		private System.Windows.Forms.ToolStrip toolBarra;
		private System.Windows.Forms.ToolStripButton toolSalir;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripButton toolGrabar;
		private System.Windows.Forms.DataGridView gridSaldos;
		private System.Windows.Forms.Label laTipo;
		private System.Windows.Forms.ToolStripButton toolNuevo;
		private System.Windows.Forms.ToolStripButton toolEditar;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton toolEliminar;
		private System.Windows.Forms.DataGridViewTextBoxColumn colPeriodo;
		private System.Windows.Forms.DataGridViewTextBoxColumn colIdCuenta;
		private System.Windows.Forms.DataGridViewTextBoxColumn colDescripcionCuenta;
		private System.Windows.Forms.DataGridViewTextBoxColumn colLibro;
		private System.Windows.Forms.DataGridViewTextBoxColumn colOrigen;
		private System.Windows.Forms.DataGridViewTextBoxColumn colDebito;
		private System.Windows.Forms.DataGridViewTextBoxColumn colCredito;
		private System.Windows.Forms.DataGridViewTextBoxColumn colTipoCuenta;
		private System.Windows.Forms.DataGridViewTextBoxColumn colIdRegistro;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton toolStripButtonImportar;
        private System.Windows.Forms.ToolStripButton toolStripButtonVerFormato;
	}
}