namespace NewConsolidado.Vistas.Formularios
{
	partial class IngresoSaldosContables_Importacion
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
            this.gridExcel = new System.Windows.Forms.DataGridView();
            this.colAccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colImagen = new System.Windows.Forms.DataGridViewImageColumn();
            this.colLinea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCompania = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPeriodo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdCuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCuentaTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMonto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMensaje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.laMensaje = new System.Windows.Forms.Label();
            this.buttonAceptar = new System.Windows.Forms.Button();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.textMensaje = new System.Windows.Forms.TextBox();
            this.progressBarCuenta = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.gridExcel)).BeginInit();
            this.SuspendLayout();
            // 
            // gridExcel
            // 
            this.gridExcel.AllowUserToAddRows = false;
            this.gridExcel.AllowUserToDeleteRows = false;
            this.gridExcel.AllowUserToResizeRows = false;
            this.gridExcel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridExcel.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colAccion,
            this.colImagen,
            this.colLinea,
            this.colCompania,
            this.colPeriodo,
            this.colIdCuenta,
            this.colCuentaTipo,
            this.colMonto,
            this.colMensaje});
            this.gridExcel.Location = new System.Drawing.Point(12, 12);
            this.gridExcel.MultiSelect = false;
            this.gridExcel.Name = "gridExcel";
            this.gridExcel.ReadOnly = true;
            this.gridExcel.RowHeadersVisible = false;
            this.gridExcel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridExcel.Size = new System.Drawing.Size(559, 297);
            this.gridExcel.TabIndex = 0;
            this.gridExcel.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridSaldos_CellClick);
            // 
            // colAccion
            // 
            this.colAccion.HeaderText = "A";
            this.colAccion.Name = "colAccion";
            this.colAccion.ReadOnly = true;
            this.colAccion.Visible = false;
            // 
            // colImagen
            // 
            this.colImagen.HeaderText = "";
            this.colImagen.Image = global::NewConsolidado.Properties.Resources.rsc_24_Cancelar;
            this.colImagen.Name = "colImagen";
            this.colImagen.ReadOnly = true;
            this.colImagen.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colImagen.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colImagen.Width = 25;
            // 
            // colLinea
            // 
            this.colLinea.HeaderText = "N°";
            this.colLinea.Name = "colLinea";
            this.colLinea.ReadOnly = true;
            this.colLinea.Width = 30;
            // 
            // colCompania
            // 
            this.colCompania.HeaderText = "Compañia";
            this.colCompania.Name = "colCompania";
            this.colCompania.ReadOnly = true;
            // 
            // colPeriodo
            // 
            this.colPeriodo.HeaderText = "Periodo";
            this.colPeriodo.Name = "colPeriodo";
            this.colPeriodo.ReadOnly = true;
            // 
            // colIdCuenta
            // 
            this.colIdCuenta.HeaderText = "Cuenta";
            this.colIdCuenta.Name = "colIdCuenta";
            this.colIdCuenta.ReadOnly = true;
            // 
            // colCuentaTipo
            // 
            this.colCuentaTipo.HeaderText = "Tipo";
            this.colCuentaTipo.Name = "colCuentaTipo";
            this.colCuentaTipo.ReadOnly = true;
            this.colCuentaTipo.Width = 30;
            // 
            // colMonto
            // 
            this.colMonto.HeaderText = "Monto";
            this.colMonto.Name = "colMonto";
            this.colMonto.ReadOnly = true;
            // 
            // colMensaje
            // 
            this.colMensaje.HeaderText = "O";
            this.colMensaje.Name = "colMensaje";
            this.colMensaje.ReadOnly = true;
            this.colMensaje.Visible = false;
            // 
            // laMensaje
            // 
            this.laMensaje.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.laMensaje.ForeColor = System.Drawing.Color.Red;
            this.laMensaje.Location = new System.Drawing.Point(9, 318);
            this.laMensaje.Name = "laMensaje";
            this.laMensaje.Padding = new System.Windows.Forms.Padding(5);
            this.laMensaje.Size = new System.Drawing.Size(303, 70);
            this.laMensaje.TabIndex = 5;
            this.laMensaje.Text = "Hay lineas que poseen caracteres que no cumplen con las validaciones. \r\n\r\nSelecci" +
                "one la linea para ver la observación";
            // 
            // buttonAceptar
            // 
            this.buttonAceptar.Location = new System.Drawing.Point(590, 12);
            this.buttonAceptar.Name = "buttonAceptar";
            this.buttonAceptar.Size = new System.Drawing.Size(105, 31);
            this.buttonAceptar.TabIndex = 6;
            this.buttonAceptar.Text = "Aceptar";
            this.buttonAceptar.UseVisualStyleBackColor = true;
            this.buttonAceptar.Click += new System.EventHandler(this.buttonAceptar_Click);
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Location = new System.Drawing.Point(590, 63);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(105, 32);
            this.buttonCancelar.TabIndex = 7;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // textMensaje
            // 
            this.textMensaje.AcceptsReturn = true;
            this.textMensaje.AcceptsTab = true;
            this.textMensaje.BackColor = System.Drawing.SystemColors.Info;
            this.textMensaje.Location = new System.Drawing.Point(321, 315);
            this.textMensaje.Multiline = true;
            this.textMensaje.Name = "textMensaje";
            this.textMensaje.ReadOnly = true;
            this.textMensaje.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textMensaje.Size = new System.Drawing.Size(250, 80);
            this.textMensaje.TabIndex = 9;
            // 
            // progressBarCuenta
            // 
            this.progressBarCuenta.Location = new System.Drawing.Point(590, 117);
            this.progressBarCuenta.Name = "progressBarCuenta";
            this.progressBarCuenta.Size = new System.Drawing.Size(105, 23);
            this.progressBarCuenta.TabIndex = 10;
            // 
            // IngresoSaldosContables_Importacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 405);
            this.Controls.Add(this.progressBarCuenta);
            this.Controls.Add(this.textMensaje);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonAceptar);
            this.Controls.Add(this.laMensaje);
            this.Controls.Add(this.gridExcel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "IngresoSaldosContables_Importacion";
            this.Text = "IngresoSaldosContables_Importacion";
            this.Load += new System.EventHandler(this.IngresoSaldosContables_Importacion_Load);
            this.Shown += new System.EventHandler(this.IngresoSaldosContables_Importacion_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.gridExcel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView gridExcel;
		private System.Windows.Forms.Label laMensaje;
		private System.Windows.Forms.Button buttonAceptar;
		private System.Windows.Forms.Button buttonCancelar;
		private System.Windows.Forms.TextBox textMensaje;
		private System.Windows.Forms.ProgressBar progressBarCuenta;
		private System.Windows.Forms.DataGridViewTextBoxColumn colAccion;
		private System.Windows.Forms.DataGridViewImageColumn colImagen;
		private System.Windows.Forms.DataGridViewTextBoxColumn colLinea;
		private System.Windows.Forms.DataGridViewTextBoxColumn colCompania;
		private System.Windows.Forms.DataGridViewTextBoxColumn colPeriodo;
		private System.Windows.Forms.DataGridViewTextBoxColumn colIdCuenta;
		private System.Windows.Forms.DataGridViewTextBoxColumn colCuentaTipo;
		private System.Windows.Forms.DataGridViewTextBoxColumn colMonto;
		private System.Windows.Forms.DataGridViewTextBoxColumn colMensaje;
	}
}