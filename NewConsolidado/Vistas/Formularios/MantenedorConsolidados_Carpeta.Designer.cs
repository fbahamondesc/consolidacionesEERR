namespace NewConsolidado.Vistas.Formularios
{
	partial class MantenedorConsolidados_Carpeta
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
			this.textDescripcion = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.textObservaciones = new System.Windows.Forms.TextBox();
			this.buttonGrabar = new System.Windows.Forms.Button();
			this.buttonSalir = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.textDescripcionPadre = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// textDescripcion
			// 
			this.textDescripcion.Location = new System.Drawing.Point(120, 48);
			this.textDescripcion.Name = "textDescripcion";
			this.textDescripcion.Size = new System.Drawing.Size(245, 20);
			this.textDescripcion.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 51);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(83, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Nombre carpeta";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 79);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(78, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Observaciones";
			// 
			// textObservaciones
			// 
			this.textObservaciones.Location = new System.Drawing.Point(120, 76);
			this.textObservaciones.Multiline = true;
			this.textObservaciones.Name = "textObservaciones";
			this.textObservaciones.Size = new System.Drawing.Size(245, 40);
			this.textObservaciones.TabIndex = 1;
			// 
			// buttonGrabar
			// 
			this.buttonGrabar.Location = new System.Drawing.Point(151, 138);
			this.buttonGrabar.Name = "buttonGrabar";
			this.buttonGrabar.Size = new System.Drawing.Size(104, 36);
			this.buttonGrabar.TabIndex = 2;
			this.buttonGrabar.Text = "button1";
			this.buttonGrabar.UseVisualStyleBackColor = true;
			this.buttonGrabar.Click += new System.EventHandler(this.buttonGrabar_Click);
			// 
			// buttonSalir
			// 
			this.buttonSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonSalir.Location = new System.Drawing.Point(261, 138);
			this.buttonSalir.Name = "buttonSalir";
			this.buttonSalir.Size = new System.Drawing.Size(104, 36);
			this.buttonSalir.TabIndex = 3;
			this.buttonSalir.Text = "button2";
			this.buttonSalir.UseVisualStyleBackColor = true;
			this.buttonSalir.Click += new System.EventHandler(this.buttonSalir_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 22);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(94, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Descripcion Padre";
			// 
			// textDescripcionPadre
			// 
			this.textDescripcionPadre.Location = new System.Drawing.Point(120, 19);
			this.textDescripcionPadre.Name = "textDescripcionPadre";
			this.textDescripcionPadre.ReadOnly = true;
			this.textDescripcionPadre.Size = new System.Drawing.Size(245, 20);
			this.textDescripcionPadre.TabIndex = 5;
			// 
			// MantenedorConsolidados_Carpeta
			// 
			this.AcceptButton = this.buttonGrabar;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonSalir;
			this.ClientSize = new System.Drawing.Size(377, 186);
			this.Controls.Add(this.textDescripcionPadre);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.buttonSalir);
			this.Controls.Add(this.buttonGrabar);
			this.Controls.Add(this.textObservaciones);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textDescripcion);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "MantenedorConsolidados_Carpeta";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "MantenedorConsolidados_Carpeta";
			this.Load += new System.EventHandler(this.MantenedorConsolidados_Carpeta_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox textDescripcion;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textObservaciones;
		private System.Windows.Forms.Button buttonGrabar;
		private System.Windows.Forms.Button buttonSalir;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textDescripcionPadre;
	}
}