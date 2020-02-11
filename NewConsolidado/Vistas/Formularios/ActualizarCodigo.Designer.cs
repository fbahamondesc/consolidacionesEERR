namespace NewConsolidado.Vistas.Formularios
{
	partial class ActualizarCodigo
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
			this.buttonActualizar = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// buttonActualizar
			// 
			this.buttonActualizar.Location = new System.Drawing.Point(86, 31);
			this.buttonActualizar.Name = "buttonActualizar";
			this.buttonActualizar.Size = new System.Drawing.Size(104, 36);
			this.buttonActualizar.TabIndex = 0;
			this.buttonActualizar.Text = "Actualizar";
			this.buttonActualizar.UseVisualStyleBackColor = true;
			this.buttonActualizar.Click += new System.EventHandler(this.buttonActualizar_Click);
			// 
			// ActualizarCodigo
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(291, 108);
			this.Controls.Add(this.buttonActualizar);
			this.Name = "ActualizarCodigo";
			this.Text = "ActualizarCodigo";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button buttonActualizar;
	}
}