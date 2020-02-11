namespace NewConsolidado.Vistas.Formularios
{
	partial class ConsultaCompanias
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
			this.gridCompanias = new System.Windows.Forms.DataGridView();
			this.colCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.buttonAceptar = new System.Windows.Forms.Button();
			this.buttonSalir = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.gridCompanias)).BeginInit();
			this.SuspendLayout();
			// 
			// gridCompanias
			// 
			this.gridCompanias.AllowUserToAddRows = false;
			this.gridCompanias.AllowUserToDeleteRows = false;
			this.gridCompanias.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.gridCompanias.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.gridCompanias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gridCompanias.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCodigo,
            this.colNombre});
			this.gridCompanias.Location = new System.Drawing.Point(12, 16);
			this.gridCompanias.Name = "gridCompanias";
			this.gridCompanias.ReadOnly = true;
			this.gridCompanias.RowHeadersVisible = false;
			this.gridCompanias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.gridCompanias.Size = new System.Drawing.Size(437, 225);
			this.gridCompanias.TabIndex = 0;
			this.gridCompanias.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridCompania_CellDoubleClick);
			// 
			// colCodigo
			// 
			this.colCodigo.HeaderText = "Código";
			this.colCodigo.Name = "colCodigo";
			this.colCodigo.ReadOnly = true;
			this.colCodigo.Width = 60;
			// 
			// colNombre
			// 
			this.colNombre.HeaderText = "Nombre";
			this.colNombre.Name = "colNombre";
			this.colNombre.ReadOnly = true;
			this.colNombre.Width = 350;
			// 
			// buttonAceptar
			// 
			this.buttonAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonAceptar.Location = new System.Drawing.Point(237, 252);
			this.buttonAceptar.Name = "buttonAceptar";
			this.buttonAceptar.Size = new System.Drawing.Size(75, 23);
			this.buttonAceptar.TabIndex = 1;
			this.buttonAceptar.Text = "Aceptar";
			this.buttonAceptar.UseVisualStyleBackColor = true;
			this.buttonAceptar.Click += new System.EventHandler(this.buttonAceptar_Click);
			// 
			// buttonSalir
			// 
			this.buttonSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSalir.Location = new System.Drawing.Point(348, 252);
			this.buttonSalir.Name = "buttonSalir";
			this.buttonSalir.Size = new System.Drawing.Size(75, 23);
			this.buttonSalir.TabIndex = 2;
			this.buttonSalir.Text = "Salir";
			this.buttonSalir.UseVisualStyleBackColor = true;
			this.buttonSalir.Click += new System.EventHandler(this.buttonSalir_Click);
			// 
			// ConsultaCompanias
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(461, 301);
			this.Controls.Add(this.buttonSalir);
			this.Controls.Add(this.buttonAceptar);
			this.Controls.Add(this.gridCompanias);
			this.Name = "ConsultaCompanias";
			this.ShowIcon = false;
			this.Text = "ConsultaCompanias";
			this.Load += new System.EventHandler(this.ConsultaCompanias_Load);
			((System.ComponentModel.ISupportInitialize)(this.gridCompanias)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView gridCompanias;
		private System.Windows.Forms.Button buttonAceptar;
		private System.Windows.Forms.Button buttonSalir;
		private System.Windows.Forms.DataGridViewTextBoxColumn colCodigo;
		private System.Windows.Forms.DataGridViewTextBoxColumn colNombre;
	}
}