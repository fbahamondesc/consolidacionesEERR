namespace NewConsolidado.Vistas.Formularios
{
	partial class MantenedorConsolidados_ConsultaArbolConsolidados
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MantenedorConsolidados_ConsultaArbolConsolidados));
			this.treeConsolidados = new System.Windows.Forms.TreeView();
			this.buttonAceptar = new System.Windows.Forms.Button();
			this.buttonSalir = new System.Windows.Forms.Button();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.groupConsolidado = new System.Windows.Forms.GroupBox();
			this.labelConsolidadoSeguridad = new System.Windows.Forms.Label();
			this.label42 = new System.Windows.Forms.Label();
			this.labelConsolidadoEstado = new System.Windows.Forms.Label();
			this.label44 = new System.Windows.Forms.Label();
			this.labelConsolidadoParticipacion = new System.Windows.Forms.Label();
			this.labelConsolidadoPeriodoTermino = new System.Windows.Forms.Label();
			this.labelConsolidadoPeriodoInicio = new System.Windows.Forms.Label();
			this.labelConsolidadoObservaciones = new System.Windows.Forms.Label();
			this.labelConsolidadoDescripcion = new System.Windows.Forms.Label();
			this.labelConsolidadoCodigo = new System.Windows.Forms.Label();
			this.label53 = new System.Windows.Forms.Label();
			this.label54 = new System.Windows.Forms.Label();
			this.label55 = new System.Windows.Forms.Label();
			this.label56 = new System.Windows.Forms.Label();
			this.label57 = new System.Windows.Forms.Label();
			this.label58 = new System.Windows.Forms.Label();
			this.labelPeriodoComparativo = new System.Windows.Forms.Label();
			this.textPeriodoComparativo = new System.Windows.Forms.TextBox();
			this.groupConsolidado.SuspendLayout();
			this.SuspendLayout();
			// 
			// treeConsolidados
			// 
			this.treeConsolidados.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
									| System.Windows.Forms.AnchorStyles.Left)));
			this.treeConsolidados.Location = new System.Drawing.Point(12, 12);
			this.treeConsolidados.Name = "treeConsolidados";
			this.treeConsolidados.Size = new System.Drawing.Size(364, 304);
			this.treeConsolidados.TabIndex = 0;
			this.treeConsolidados.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeConsolidados_AfterSelect);
			// 
			// buttonAceptar
			// 
			this.buttonAceptar.Location = new System.Drawing.Point(412, 12);
			this.buttonAceptar.Name = "buttonAceptar";
			this.buttonAceptar.Size = new System.Drawing.Size(104, 36);
			this.buttonAceptar.TabIndex = 1;
			this.buttonAceptar.Text = "Aceptar";
			this.buttonAceptar.UseVisualStyleBackColor = true;
			this.buttonAceptar.Click += new System.EventHandler(this.buttonAceptar_Click);
			// 
			// buttonSalir
			// 
			this.buttonSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonSalir.Location = new System.Drawing.Point(412, 54);
			this.buttonSalir.Name = "buttonSalir";
			this.buttonSalir.Size = new System.Drawing.Size(104, 36);
			this.buttonSalir.TabIndex = 2;
			this.buttonSalir.Text = "Cancelar";
			this.buttonSalir.UseVisualStyleBackColor = true;
			this.buttonSalir.Click += new System.EventHandler(this.buttonSalir_Click);
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
			// groupConsolidado
			// 
			this.groupConsolidado.Controls.Add(this.labelConsolidadoSeguridad);
			this.groupConsolidado.Controls.Add(this.label42);
			this.groupConsolidado.Controls.Add(this.labelConsolidadoEstado);
			this.groupConsolidado.Controls.Add(this.label44);
			this.groupConsolidado.Controls.Add(this.labelConsolidadoParticipacion);
			this.groupConsolidado.Controls.Add(this.labelConsolidadoPeriodoTermino);
			this.groupConsolidado.Controls.Add(this.labelConsolidadoPeriodoInicio);
			this.groupConsolidado.Controls.Add(this.labelConsolidadoObservaciones);
			this.groupConsolidado.Controls.Add(this.labelConsolidadoDescripcion);
			this.groupConsolidado.Controls.Add(this.labelConsolidadoCodigo);
			this.groupConsolidado.Controls.Add(this.label53);
			this.groupConsolidado.Controls.Add(this.label54);
			this.groupConsolidado.Controls.Add(this.label55);
			this.groupConsolidado.Controls.Add(this.label56);
			this.groupConsolidado.Controls.Add(this.label57);
			this.groupConsolidado.Controls.Add(this.label58);
			this.groupConsolidado.Location = new System.Drawing.Point(12, 322);
			this.groupConsolidado.Name = "groupConsolidado";
			this.groupConsolidado.Size = new System.Drawing.Size(504, 172);
			this.groupConsolidado.TabIndex = 4;
			this.groupConsolidado.TabStop = false;
			this.groupConsolidado.Text = "Datos del Consolidado";
			// 
			// labelConsolidadoSeguridad
			// 
			this.labelConsolidadoSeguridad.AutoSize = true;
			this.labelConsolidadoSeguridad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelConsolidadoSeguridad.Location = new System.Drawing.Point(432, 142);
			this.labelConsolidadoSeguridad.Name = "labelConsolidadoSeguridad";
			this.labelConsolidadoSeguridad.Size = new System.Drawing.Size(48, 13);
			this.labelConsolidadoSeguridad.TabIndex = 120;
			this.labelConsolidadoSeguridad.Text = "label41";
			// 
			// label42
			// 
			this.label42.AutoSize = true;
			this.label42.Location = new System.Drawing.Point(372, 142);
			this.label42.Name = "label42";
			this.label42.Size = new System.Drawing.Size(55, 13);
			this.label42.TabIndex = 119;
			this.label42.Text = "Seguridad";
			// 
			// labelConsolidadoEstado
			// 
			this.labelConsolidadoEstado.AutoSize = true;
			this.labelConsolidadoEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelConsolidadoEstado.Location = new System.Drawing.Point(297, 142);
			this.labelConsolidadoEstado.Name = "labelConsolidadoEstado";
			this.labelConsolidadoEstado.Size = new System.Drawing.Size(48, 13);
			this.labelConsolidadoEstado.TabIndex = 118;
			this.labelConsolidadoEstado.Text = "label43";
			// 
			// label44
			// 
			this.label44.AutoSize = true;
			this.label44.Location = new System.Drawing.Point(237, 142);
			this.label44.Name = "label44";
			this.label44.Size = new System.Drawing.Size(40, 13);
			this.label44.TabIndex = 117;
			this.label44.Text = "Estado";
			// 
			// labelConsolidadoParticipacion
			// 
			this.labelConsolidadoParticipacion.AutoSize = true;
			this.labelConsolidadoParticipacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelConsolidadoParticipacion.Location = new System.Drawing.Point(106, 142);
			this.labelConsolidadoParticipacion.Name = "labelConsolidadoParticipacion";
			this.labelConsolidadoParticipacion.Size = new System.Drawing.Size(48, 13);
			this.labelConsolidadoParticipacion.TabIndex = 116;
			this.labelConsolidadoParticipacion.Text = "label45";
			// 
			// labelConsolidadoPeriodoTermino
			// 
			this.labelConsolidadoPeriodoTermino.AutoSize = true;
			this.labelConsolidadoPeriodoTermino.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelConsolidadoPeriodoTermino.Location = new System.Drawing.Point(340, 118);
			this.labelConsolidadoPeriodoTermino.Name = "labelConsolidadoPeriodoTermino";
			this.labelConsolidadoPeriodoTermino.Size = new System.Drawing.Size(48, 13);
			this.labelConsolidadoPeriodoTermino.TabIndex = 115;
			this.labelConsolidadoPeriodoTermino.Text = "label46";
			// 
			// labelConsolidadoPeriodoInicio
			// 
			this.labelConsolidadoPeriodoInicio.AutoSize = true;
			this.labelConsolidadoPeriodoInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelConsolidadoPeriodoInicio.Location = new System.Drawing.Point(106, 118);
			this.labelConsolidadoPeriodoInicio.Name = "labelConsolidadoPeriodoInicio";
			this.labelConsolidadoPeriodoInicio.Size = new System.Drawing.Size(48, 13);
			this.labelConsolidadoPeriodoInicio.TabIndex = 114;
			this.labelConsolidadoPeriodoInicio.Text = "label47";
			// 
			// labelConsolidadoObservaciones
			// 
			this.labelConsolidadoObservaciones.BackColor = System.Drawing.SystemColors.Control;
			this.labelConsolidadoObservaciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.labelConsolidadoObservaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelConsolidadoObservaciones.Location = new System.Drawing.Point(106, 69);
			this.labelConsolidadoObservaciones.Name = "labelConsolidadoObservaciones";
			this.labelConsolidadoObservaciones.Padding = new System.Windows.Forms.Padding(3);
			this.labelConsolidadoObservaciones.Size = new System.Drawing.Size(374, 40);
			this.labelConsolidadoObservaciones.TabIndex = 113;
			this.labelConsolidadoObservaciones.Text = "label48";
			// 
			// labelConsolidadoDescripcion
			// 
			this.labelConsolidadoDescripcion.AutoSize = true;
			this.labelConsolidadoDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelConsolidadoDescripcion.Location = new System.Drawing.Point(106, 43);
			this.labelConsolidadoDescripcion.Name = "labelConsolidadoDescripcion";
			this.labelConsolidadoDescripcion.Size = new System.Drawing.Size(48, 13);
			this.labelConsolidadoDescripcion.TabIndex = 112;
			this.labelConsolidadoDescripcion.Text = "label49";
			// 
			// labelConsolidadoCodigo
			// 
			this.labelConsolidadoCodigo.AutoSize = true;
			this.labelConsolidadoCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelConsolidadoCodigo.Location = new System.Drawing.Point(106, 21);
			this.labelConsolidadoCodigo.Name = "labelConsolidadoCodigo";
			this.labelConsolidadoCodigo.Size = new System.Drawing.Size(48, 13);
			this.labelConsolidadoCodigo.TabIndex = 110;
			this.labelConsolidadoCodigo.Text = "label51";
			// 
			// label53
			// 
			this.label53.AutoSize = true;
			this.label53.Location = new System.Drawing.Point(17, 20);
			this.label53.Name = "label53";
			this.label53.Size = new System.Drawing.Size(40, 13);
			this.label53.TabIndex = 108;
			this.label53.Text = "Código";
			// 
			// label54
			// 
			this.label54.AutoSize = true;
			this.label54.Location = new System.Drawing.Point(17, 142);
			this.label54.Name = "label54";
			this.label54.Size = new System.Drawing.Size(79, 13);
			this.label54.TabIndex = 107;
			this.label54.Text = "% Participación";
			// 
			// label55
			// 
			this.label55.AutoSize = true;
			this.label55.Location = new System.Drawing.Point(237, 118);
			this.label55.Name = "label55";
			this.label55.Size = new System.Drawing.Size(84, 13);
			this.label55.TabIndex = 106;
			this.label55.Text = "Periodo Termino";
			// 
			// label56
			// 
			this.label56.AutoSize = true;
			this.label56.Location = new System.Drawing.Point(17, 118);
			this.label56.Name = "label56";
			this.label56.Size = new System.Drawing.Size(71, 13);
			this.label56.TabIndex = 105;
			this.label56.Text = "Periodo Inicio";
			// 
			// label57
			// 
			this.label57.AutoSize = true;
			this.label57.Location = new System.Drawing.Point(17, 69);
			this.label57.Name = "label57";
			this.label57.Size = new System.Drawing.Size(78, 13);
			this.label57.TabIndex = 104;
			this.label57.Text = "Observaciones";
			// 
			// label58
			// 
			this.label58.AutoSize = true;
			this.label58.Location = new System.Drawing.Point(17, 43);
			this.label58.Name = "label58";
			this.label58.Size = new System.Drawing.Size(63, 13);
			this.label58.TabIndex = 103;
			this.label58.Text = "Descripción";
			// 
			// labelPeriodoComparativo
			// 
			this.labelPeriodoComparativo.AutoSize = true;
			this.labelPeriodoComparativo.Location = new System.Drawing.Point(411, 136);
			this.labelPeriodoComparativo.Name = "labelPeriodoComparativo";
			this.labelPeriodoComparativo.Size = new System.Drawing.Size(105, 13);
			this.labelPeriodoComparativo.TabIndex = 5;
			this.labelPeriodoComparativo.Text = "Periodo Comparativo";
			// 
			// textPeriodoComparativo
			// 
			this.textPeriodoComparativo.Location = new System.Drawing.Point(412, 153);
			this.textPeriodoComparativo.Name = "textPeriodoComparativo";
			this.textPeriodoComparativo.Size = new System.Drawing.Size(100, 20);
			this.textPeriodoComparativo.TabIndex = 6;
			// 
			// MantenedorConsolidados_ConsultaArbolConsolidados
			// 
			this.AcceptButton = this.buttonAceptar;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonSalir;
			this.ClientSize = new System.Drawing.Size(528, 506);
			this.Controls.Add(this.textPeriodoComparativo);
			this.Controls.Add(this.labelPeriodoComparativo);
			this.Controls.Add(this.groupConsolidado);
			this.Controls.Add(this.buttonSalir);
			this.Controls.Add(this.buttonAceptar);
			this.Controls.Add(this.treeConsolidados);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "MantenedorConsolidados_ConsultaArbolConsolidados";
			this.Text = "MantenedorConsolidados_ConsultaArbolConsolidados";
			this.Load += new System.EventHandler(this.MantenedorConsolidados_ConsultaArbolConsolidados_Load);
			this.Shown += new System.EventHandler(this.MantenedorConsolidados_ConsultaArbolConsolidados_Shown);
			this.groupConsolidado.ResumeLayout(false);
			this.groupConsolidado.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TreeView treeConsolidados;
		private System.Windows.Forms.Button buttonAceptar;
		private System.Windows.Forms.Button buttonSalir;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.GroupBox groupConsolidado;
		private System.Windows.Forms.Label labelConsolidadoSeguridad;
		private System.Windows.Forms.Label label42;
		private System.Windows.Forms.Label labelConsolidadoEstado;
		private System.Windows.Forms.Label label44;
		private System.Windows.Forms.Label labelConsolidadoParticipacion;
		private System.Windows.Forms.Label labelConsolidadoPeriodoTermino;
		private System.Windows.Forms.Label labelConsolidadoPeriodoInicio;
		private System.Windows.Forms.Label labelConsolidadoObservaciones;
		private System.Windows.Forms.Label labelConsolidadoDescripcion;
		private System.Windows.Forms.Label labelConsolidadoCodigo;
		private System.Windows.Forms.Label label53;
		private System.Windows.Forms.Label label54;
		private System.Windows.Forms.Label label55;
		private System.Windows.Forms.Label label56;
		private System.Windows.Forms.Label label57;
		private System.Windows.Forms.Label label58;
		private System.Windows.Forms.Label labelPeriodoComparativo;
		private System.Windows.Forms.TextBox textPeriodoComparativo;
	}
}