namespace NewConsolidado.Vistas.Formularios
{
	partial class MantenedorConsolidados_ConsultaReferencias
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MantenedorConsolidados_ConsultaReferencias));
			this.treeReferencias = new System.Windows.Forms.TreeView();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.SuspendLayout();
			// 
			// treeReferencias
			// 
			this.treeReferencias.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
									| System.Windows.Forms.AnchorStyles.Left)
									| System.Windows.Forms.AnchorStyles.Right)));
			this.treeReferencias.Location = new System.Drawing.Point(12, 12);
			this.treeReferencias.Name = "treeReferencias";
			this.treeReferencias.Size = new System.Drawing.Size(219, 298);
			this.treeReferencias.TabIndex = 0;
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "rsc_16_Folder.png");
			this.imageList1.Images.SetKeyName(1, "rsc_16_ConsolidadoBook.png");
			this.imageList1.Images.SetKeyName(2, "rsc-16-Empresa.png");
			this.imageList1.Images.SetKeyName(3, "rsc_16_Root.png");
			// 
			// MantenedorConsolidados_ConsultaReferencias
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(243, 322);
			this.Controls.Add(this.treeReferencias);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Name = "MantenedorConsolidados_ConsultaReferencias";
			this.Text = "Consulta Referencias";
			this.Load += new System.EventHandler(this.MantenedorConsolidados_ConsultaReferencias_Load);
			this.Shown += new System.EventHandler(this.MantenedorConsolidados_ConsultaReferencias_Shown);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TreeView treeReferencias;
		private System.Windows.Forms.ImageList imageList1;
	}
}