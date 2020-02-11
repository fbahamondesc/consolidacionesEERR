namespace NewConsolidado.Vistas.Formularios
{
    partial class MantenedorConsolidados_ConsultaConfiguraciones
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
            this.buttonGrabar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonEliminar = new System.Windows.Forms.Button();
            this.gridPeriodosConfigurados = new System.Windows.Forms.DataGridView();
            this.buttonPorDefecto = new System.Windows.Forms.Button();
            this.colDefecto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPeriodo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCodConsolidado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPeriodoComparativo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colidComparativo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPeriodosConfigurados)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonSalir
            // 
            this.buttonSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonSalir.Location = new System.Drawing.Point(256, 258);
            this.buttonSalir.Name = "buttonSalir";
            this.buttonSalir.Size = new System.Drawing.Size(104, 36);
            this.buttonSalir.TabIndex = 89;
            this.buttonSalir.Text = "Cancelar";
            this.buttonSalir.UseVisualStyleBackColor = true;
            this.buttonSalir.Click += new System.EventHandler(this.buttonSalir_Click);
            // 
            // buttonGrabar
            // 
            this.buttonGrabar.Location = new System.Drawing.Point(146, 258);
            this.buttonGrabar.Name = "buttonGrabar";
            this.buttonGrabar.Size = new System.Drawing.Size(104, 36);
            this.buttonGrabar.TabIndex = 88;
            this.buttonGrabar.Text = "Aceptar";
            this.buttonGrabar.UseVisualStyleBackColor = true;
            this.buttonGrabar.Click += new System.EventHandler(this.buttonGrabar_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.buttonPorDefecto);
            this.panel1.Controls.Add(this.buttonEliminar);
            this.panel1.Controls.Add(this.gridPeriodosConfigurados);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(348, 240);
            this.panel1.TabIndex = 93;
            // 
            // buttonEliminar
            // 
            this.buttonEliminar.Location = new System.Drawing.Point(87, 206);
            this.buttonEliminar.Name = "buttonEliminar";
            this.buttonEliminar.Size = new System.Drawing.Size(75, 23);
            this.buttonEliminar.TabIndex = 95;
            this.buttonEliminar.Text = "Eliminar";
            this.buttonEliminar.UseVisualStyleBackColor = true;
            this.buttonEliminar.Click += new System.EventHandler(this.buttonEliminar_Click);
            // 
            // gridPeriodosConfigurados
            // 
            this.gridPeriodosConfigurados.AllowUserToAddRows = false;
            this.gridPeriodosConfigurados.AllowUserToDeleteRows = false;
            this.gridPeriodosConfigurados.AllowUserToResizeRows = false;
            this.gridPeriodosConfigurados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridPeriodosConfigurados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDefecto,
            this.colPeriodo,
            this.colCodConsolidado,
            this.colPeriodoComparativo,
            this.colidComparativo});
            this.gridPeriodosConfigurados.Location = new System.Drawing.Point(6, 7);
            this.gridPeriodosConfigurados.MultiSelect = false;
            this.gridPeriodosConfigurados.Name = "gridPeriodosConfigurados";
            this.gridPeriodosConfigurados.ReadOnly = true;
            this.gridPeriodosConfigurados.RowHeadersVisible = false;
            this.gridPeriodosConfigurados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridPeriodosConfigurados.Size = new System.Drawing.Size(333, 193);
            this.gridPeriodosConfigurados.TabIndex = 96;
            // 
            // buttonPorDefecto
            // 
            this.buttonPorDefecto.Location = new System.Drawing.Point(6, 206);
            this.buttonPorDefecto.Name = "buttonPorDefecto";
            this.buttonPorDefecto.Size = new System.Drawing.Size(75, 23);
            this.buttonPorDefecto.TabIndex = 98;
            this.buttonPorDefecto.Text = "Por Defecto";
            this.buttonPorDefecto.UseVisualStyleBackColor = true;
            this.buttonPorDefecto.Click += new System.EventHandler(this.buttonPorDefecto_Click);
            // 
            // colDefecto
            // 
            this.colDefecto.HeaderText = "*";
            this.colDefecto.Name = "colDefecto";
            this.colDefecto.ReadOnly = true;
            this.colDefecto.Width = 25;
            // 
            // colPeriodo
            // 
            this.colPeriodo.HeaderText = "Periodo";
            this.colPeriodo.Name = "colPeriodo";
            this.colPeriodo.ReadOnly = true;
            this.colPeriodo.Width = 80;
            // 
            // colCodConsolidado
            // 
            this.colCodConsolidado.HeaderText = "Cod Consolidado";
            this.colCodConsolidado.Name = "colCodConsolidado";
            this.colCodConsolidado.ReadOnly = true;
            this.colCodConsolidado.Width = 120;
            // 
            // colPeriodoComparativo
            // 
            this.colPeriodoComparativo.HeaderText = "Periodo C.";
            this.colPeriodoComparativo.Name = "colPeriodoComparativo";
            this.colPeriodoComparativo.ReadOnly = true;
            this.colPeriodoComparativo.Width = 80;
            // 
            // colidComparativo
            // 
            this.colidComparativo.HeaderText = "comparativo";
            this.colidComparativo.Name = "colidComparativo";
            this.colidComparativo.ReadOnly = true;
            this.colidComparativo.Visible = false;
            // 
            // MantenedorConsolidados_ConsultaConfiguraciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 303);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonSalir);
            this.Controls.Add(this.buttonGrabar);
            this.Name = "MantenedorConsolidados_ConsultaConfiguraciones";
            this.Text = "MantenedorConsolidados_ConsultaConfiguraciones";
            this.Load += new System.EventHandler(this.MantenedorConsolidados_ConsultaConfiguraciones_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridPeriodosConfigurados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonSalir;
        private System.Windows.Forms.Button buttonGrabar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonPorDefecto;
        private System.Windows.Forms.Button buttonEliminar;
        private System.Windows.Forms.DataGridView gridPeriodosConfigurados;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDefecto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPeriodo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodConsolidado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPeriodoComparativo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colidComparativo;
    }
}