namespace NewConsolidado.Vistas.Formularios
{
	partial class ConsultaCuentasContables
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
            this.buttonAceptar = new System.Windows.Forms.Button();
            this.gridCuentas = new System.Windows.Forms.DataGridView();
            this.colIdCuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridCuentas)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonSalir
            // 
            this.buttonSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSalir.Location = new System.Drawing.Point(274, 320);
            this.buttonSalir.Name = "buttonSalir";
            this.buttonSalir.Size = new System.Drawing.Size(75, 23);
            this.buttonSalir.TabIndex = 5;
            this.buttonSalir.Text = "Cancelar";
            this.buttonSalir.UseVisualStyleBackColor = true;
            this.buttonSalir.Click += new System.EventHandler(this.buttonSalir_Click);
            // 
            // buttonAceptar
            // 
            this.buttonAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAceptar.Location = new System.Drawing.Point(163, 320);
            this.buttonAceptar.Name = "buttonAceptar";
            this.buttonAceptar.Size = new System.Drawing.Size(75, 23);
            this.buttonAceptar.TabIndex = 4;
            this.buttonAceptar.Text = "Aceptar";
            this.buttonAceptar.UseVisualStyleBackColor = true;
            this.buttonAceptar.Click += new System.EventHandler(this.buttonAceptar_Click);
            // 
            // gridCuentas
            // 
            this.gridCuentas.AllowUserToAddRows = false;
            this.gridCuentas.AllowUserToDeleteRows = false;
            this.gridCuentas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridCuentas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridCuentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridCuentas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdCuenta,
            this.colDescripcion,
            this.colTipo});
            this.gridCuentas.Location = new System.Drawing.Point(12, 12);
            this.gridCuentas.Name = "gridCuentas";
            this.gridCuentas.ReadOnly = true;
            this.gridCuentas.RowHeadersVisible = false;
            this.gridCuentas.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.gridCuentas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridCuentas.Size = new System.Drawing.Size(358, 292);
            this.gridCuentas.TabIndex = 3;
            this.gridCuentas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridCuentas_CellDoubleClick);
            // 
            // colIdCuenta
            // 
            this.colIdCuenta.HeaderText = "Código";
            this.colIdCuenta.Name = "colIdCuenta";
            this.colIdCuenta.ReadOnly = true;
            this.colIdCuenta.Width = 60;
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
            this.colTipo.Width = 40;
            // 
            // ConsultaCuentasContables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 364);
            this.Controls.Add(this.buttonSalir);
            this.Controls.Add(this.buttonAceptar);
            this.Controls.Add(this.gridCuentas);
            this.Name = "ConsultaCuentasContables";
            this.ShowIcon = false;
            this.Text = "ConsultaCuentasContables";
            this.Load += new System.EventHandler(this.ConsultaCuentasContables_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridCuentas)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button buttonSalir;
		private System.Windows.Forms.Button buttonAceptar;
		private System.Windows.Forms.DataGridView gridCuentas;
		private System.Windows.Forms.DataGridViewTextBoxColumn colIdCuenta;
		private System.Windows.Forms.DataGridViewTextBoxColumn colDescripcion;
		private System.Windows.Forms.DataGridViewTextBoxColumn colTipo;
	}
}