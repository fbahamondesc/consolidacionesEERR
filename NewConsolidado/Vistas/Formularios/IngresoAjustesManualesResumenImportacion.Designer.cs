namespace NewConsolidado.Vistas.Formularios
{
	partial class IngresoAjustesManualesResumenImportacion
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
			this.buttonAceptar = new System.Windows.Forms.Button();
			this.buttonCancelar = new System.Windows.Forms.Button();
			this.laMensaje = new System.Windows.Forms.Label();
			this.colImagen = new System.Windows.Forms.DataGridViewImageColumn();
			this.colAccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colLinea = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colAgrupador = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colPeriodoAfecta = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colPeriodoVista = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colCuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colDebito = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colCredito = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colDescripcionAj = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colMensaje = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.progressBarCuenta = new System.Windows.Forms.ProgressBar();
			this.textMensaje = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.gridExcel)).BeginInit();
			this.SuspendLayout();
			// 
			// gridExcel
			// 
			this.gridExcel.AllowUserToAddRows = false;
			this.gridExcel.AllowUserToDeleteRows = false;
			this.gridExcel.AllowUserToOrderColumns = true;
			this.gridExcel.AllowUserToResizeRows = false;
			this.gridExcel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gridExcel.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colImagen,
            this.colAccion,
            this.colLinea,
            this.colAgrupador,
            this.colPeriodoAfecta,
            this.colPeriodoVista,
            this.colCuenta,
            this.colDebito,
            this.colCredito,
            this.colDescripcion,
            this.colDescripcionAj,
            this.colMensaje});
			this.gridExcel.Location = new System.Drawing.Point(12, 12);
			this.gridExcel.MultiSelect = false;
			this.gridExcel.Name = "gridExcel";
			this.gridExcel.ReadOnly = true;
			this.gridExcel.RowHeadersVisible = false;
			this.gridExcel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.gridExcel.Size = new System.Drawing.Size(918, 337);
			this.gridExcel.TabIndex = 1;
			this.gridExcel.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridExcel_CellDoubleClick);
			this.gridExcel.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridExcel_CellMouseEnter);
			this.gridExcel.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridExcel_CellClick);
			// 
			// buttonAceptar
			// 
			this.buttonAceptar.Location = new System.Drawing.Point(946, 12);
			this.buttonAceptar.Name = "buttonAceptar";
			this.buttonAceptar.Size = new System.Drawing.Size(107, 35);
			this.buttonAceptar.TabIndex = 2;
			this.buttonAceptar.Text = "button1";
			this.buttonAceptar.UseVisualStyleBackColor = true;
			this.buttonAceptar.Click += new System.EventHandler(this.buttonAceptar_Click);
			// 
			// buttonCancelar
			// 
			this.buttonCancelar.Location = new System.Drawing.Point(946, 64);
			this.buttonCancelar.Name = "buttonCancelar";
			this.buttonCancelar.Size = new System.Drawing.Size(107, 37);
			this.buttonCancelar.TabIndex = 3;
			this.buttonCancelar.Text = "button2";
			this.buttonCancelar.UseVisualStyleBackColor = true;
			this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
			// 
			// laMensaje
			// 
			this.laMensaje.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.laMensaje.ForeColor = System.Drawing.Color.Red;
			this.laMensaje.Location = new System.Drawing.Point(12, 377);
			this.laMensaje.Name = "laMensaje";
			this.laMensaje.Padding = new System.Windows.Forms.Padding(5);
			this.laMensaje.Size = new System.Drawing.Size(412, 65);
			this.laMensaje.TabIndex = 4;
			this.laMensaje.Text = "Hay lineas que poseen caracteres que no cumplen con las validaciones. \r\n\r\nSelecci" +
					"one la linea para ver la observación";
			// 
			// colImagen
			// 
			this.colImagen.HeaderText = "";
			this.colImagen.Image = global::NewConsolidado.Properties.Resources.rsc_24_Cancelar;
			this.colImagen.Name = "colImagen";
			this.colImagen.ReadOnly = true;
			this.colImagen.Width = 30;
			// 
			// colAccion
			// 
			this.colAccion.HeaderText = "A";
			this.colAccion.Name = "colAccion";
			this.colAccion.ReadOnly = true;
			this.colAccion.Visible = false;
			this.colAccion.Width = 25;
			// 
			// colLinea
			// 
			this.colLinea.HeaderText = "N";
			this.colLinea.Name = "colLinea";
			this.colLinea.ReadOnly = true;
			this.colLinea.Width = 35;
			// 
			// colAgrupador
			// 
			this.colAgrupador.HeaderText = "Agrupa";
			this.colAgrupador.Name = "colAgrupador";
			this.colAgrupador.ReadOnly = true;
			this.colAgrupador.Width = 45;
			// 
			// colPeriodoAfecta
			// 
			this.colPeriodoAfecta.HeaderText = "Período A";
			this.colPeriodoAfecta.Name = "colPeriodoAfecta";
			this.colPeriodoAfecta.ReadOnly = true;
			this.colPeriodoAfecta.Width = 80;
			// 
			// colPeriodoVista
			// 
			this.colPeriodoVista.HeaderText = "Período V";
			this.colPeriodoVista.Name = "colPeriodoVista";
			this.colPeriodoVista.ReadOnly = true;
			this.colPeriodoVista.Width = 80;
			// 
			// colCuenta
			// 
			this.colCuenta.HeaderText = "Cuenta";
			this.colCuenta.Name = "colCuenta";
			this.colCuenta.ReadOnly = true;
			this.colCuenta.Width = 60;
			// 
			// colDebito
			// 
			this.colDebito.HeaderText = "Debito";
			this.colDebito.Name = "colDebito";
			this.colDebito.ReadOnly = true;
			this.colDebito.Width = 80;
			// 
			// colCredito
			// 
			this.colCredito.HeaderText = "Credito";
			this.colCredito.Name = "colCredito";
			this.colCredito.ReadOnly = true;
			this.colCredito.Width = 80;
			// 
			// colDescripcion
			// 
			this.colDescripcion.HeaderText = "Descripción L.";
			this.colDescripcion.Name = "colDescripcion";
			this.colDescripcion.ReadOnly = true;
			this.colDescripcion.Width = 200;
			// 
			// colDescripcionAj
			// 
			this.colDescripcionAj.HeaderText = "Descripcion Aj.";
			this.colDescripcionAj.Name = "colDescripcionAj";
			this.colDescripcionAj.ReadOnly = true;
			this.colDescripcionAj.Width = 200;
			// 
			// colMensaje
			// 
			this.colMensaje.HeaderText = "M";
			this.colMensaje.Name = "colMensaje";
			this.colMensaje.ReadOnly = true;
			this.colMensaje.Visible = false;
			// 
			// progressBarCuenta
			// 
			this.progressBarCuenta.Location = new System.Drawing.Point(946, 126);
			this.progressBarCuenta.Name = "progressBarCuenta";
			this.progressBarCuenta.Size = new System.Drawing.Size(107, 23);
			this.progressBarCuenta.TabIndex = 7;
			// 
			// textMensaje
			// 
			this.textMensaje.AcceptsReturn = true;
			this.textMensaje.AcceptsTab = true;
			this.textMensaje.BackColor = System.Drawing.SystemColors.Info;
			this.textMensaje.Location = new System.Drawing.Point(430, 365);
			this.textMensaje.Multiline = true;
			this.textMensaje.Name = "textMensaje";
			this.textMensaje.ReadOnly = true;
			this.textMensaje.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textMensaje.Size = new System.Drawing.Size(500, 80);
			this.textMensaje.TabIndex = 8;
			// 
			// IngresoAjustesManualesResumenImportacion
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1065, 457);
			this.Controls.Add(this.textMensaje);
			this.Controls.Add(this.progressBarCuenta);
			this.Controls.Add(this.laMensaje);
			this.Controls.Add(this.buttonCancelar);
			this.Controls.Add(this.buttonAceptar);
			this.Controls.Add(this.gridExcel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "IngresoAjustesManualesResumenImportacion";
			this.ShowIcon = false;
			this.Text = "IngresoAjustesManualesResumenImportacion";
			this.Load += new System.EventHandler(this.IngresoAjustesManualesResumenImportacion_Load);
			this.Shown += new System.EventHandler(this.IngresoAjustesManualesResumenImportacion_Shown);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.IngresoAjustesManualesResumenImportacion_FormClosed);
			((System.ComponentModel.ISupportInitialize)(this.gridExcel)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView gridExcel;
		private System.Windows.Forms.Button buttonAceptar;
		private System.Windows.Forms.Button buttonCancelar;
		private System.Windows.Forms.Label laMensaje;
		private System.Windows.Forms.DataGridViewImageColumn colImagen;
		private System.Windows.Forms.DataGridViewTextBoxColumn colAccion;
		private System.Windows.Forms.DataGridViewTextBoxColumn colLinea;
		private System.Windows.Forms.DataGridViewTextBoxColumn colAgrupador;
		private System.Windows.Forms.DataGridViewTextBoxColumn colPeriodoAfecta;
		private System.Windows.Forms.DataGridViewTextBoxColumn colPeriodoVista;
		private System.Windows.Forms.DataGridViewTextBoxColumn colCuenta;
		private System.Windows.Forms.DataGridViewTextBoxColumn colDebito;
		private System.Windows.Forms.DataGridViewTextBoxColumn colCredito;
		private System.Windows.Forms.DataGridViewTextBoxColumn colDescripcion;
		private System.Windows.Forms.DataGridViewTextBoxColumn colDescripcionAj;
		private System.Windows.Forms.DataGridViewTextBoxColumn colMensaje;
		private System.Windows.Forms.ProgressBar progressBarCuenta;
		private System.Windows.Forms.TextBox textMensaje;
	}
}