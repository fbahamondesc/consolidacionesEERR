namespace NewConsolidado.Vistas.Formularios
{
    partial class MantenedorAsociacionGruposConceptosCuentas_CopiarPlantilla
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ButtonAplicarTodos = new System.Windows.Forms.Button();
            this.ButtonCancelar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gridSeleccion = new System.Windows.Forms.DataGridView();
            this.colIdConsolidado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSeleccion = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colCodigoConsolidado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescripcionConsolidado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ButtonAplicaSeleccionar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSeleccion)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ButtonAplicarTodos);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(582, 75);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // ButtonAplicarTodos
            // 
            this.ButtonAplicarTodos.Location = new System.Drawing.Point(19, 19);
            this.ButtonAplicarTodos.Name = "ButtonAplicarTodos";
            this.ButtonAplicarTodos.Size = new System.Drawing.Size(542, 36);
            this.ButtonAplicarTodos.TabIndex = 0;
            this.ButtonAplicarTodos.Text = "Aplicar plantilla a todos los Consolidados";
            this.ButtonAplicarTodos.UseVisualStyleBackColor = true;
            this.ButtonAplicarTodos.Click += new System.EventHandler(this.ButtonAplicarTodos_Click);
            // 
            // ButtonCancelar
            // 
            this.ButtonCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ButtonCancelar.Location = new System.Drawing.Point(520, 461);
            this.ButtonCancelar.Name = "ButtonCancelar";
            this.ButtonCancelar.Size = new System.Drawing.Size(75, 23);
            this.ButtonCancelar.TabIndex = 1;
            this.ButtonCancelar.Text = "Cancelar";
            this.ButtonCancelar.UseVisualStyleBackColor = true;
            this.ButtonCancelar.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gridSeleccion);
            this.groupBox2.Controls.Add(this.ButtonAplicaSeleccionar);
            this.groupBox2.Location = new System.Drawing.Point(13, 94);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(582, 348);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Selección múltiple";
            // 
            // gridSeleccion
            // 
            this.gridSeleccion.AllowUserToAddRows = false;
            this.gridSeleccion.AllowUserToDeleteRows = false;
            this.gridSeleccion.AllowUserToResizeRows = false;
            this.gridSeleccion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridSeleccion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdConsolidado,
            this.colSeleccion,
            this.colCodigoConsolidado,
            this.colDescripcionConsolidado});
            this.gridSeleccion.Location = new System.Drawing.Point(19, 74);
            this.gridSeleccion.MultiSelect = false;
            this.gridSeleccion.Name = "gridSeleccion";
            this.gridSeleccion.RowHeadersVisible = false;
            this.gridSeleccion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridSeleccion.Size = new System.Drawing.Size(542, 256);
            this.gridSeleccion.TabIndex = 2;
            // 
            // colIdConsolidado
            // 
            this.colIdConsolidado.HeaderText = "Id";
            this.colIdConsolidado.Name = "colIdConsolidado";
            this.colIdConsolidado.Visible = false;
            // 
            // colSeleccion
            // 
            this.colSeleccion.HeaderText = "Sel";
            this.colSeleccion.Name = "colSeleccion";
            this.colSeleccion.Width = 40;
            // 
            // colCodigoConsolidado
            // 
            this.colCodigoConsolidado.HeaderText = "Código";
            this.colCodigoConsolidado.Name = "colCodigoConsolidado";
            this.colCodigoConsolidado.Width = 120;
            // 
            // colDescripcionConsolidado
            // 
            this.colDescripcionConsolidado.HeaderText = "Descripcion Consolidado";
            this.colDescripcionConsolidado.Name = "colDescripcionConsolidado";
            this.colDescripcionConsolidado.Width = 350;
            // 
            // ButtonAplicaSeleccionar
            // 
            this.ButtonAplicaSeleccionar.Location = new System.Drawing.Point(19, 22);
            this.ButtonAplicaSeleccionar.Name = "ButtonAplicaSeleccionar";
            this.ButtonAplicaSeleccionar.Size = new System.Drawing.Size(542, 36);
            this.ButtonAplicaSeleccionar.TabIndex = 1;
            this.ButtonAplicaSeleccionar.Text = "Aplicar plantilla a Consolidados selecionados";
            this.ButtonAplicaSeleccionar.UseVisualStyleBackColor = true;
            this.ButtonAplicaSeleccionar.Click += new System.EventHandler(this.ButtonAplicaSeleccionar_Click);
            // 
            // MantenedorAsociacionGruposConceptosCuentas_CopiarPlantilla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.ButtonCancelar;
            this.ClientSize = new System.Drawing.Size(603, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.ButtonCancelar);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MantenedorAsociacionGruposConceptosCuentas_CopiarPlantilla";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "MantenedorAsociacionGruposConceptosCuentas_CopiarPlantilla";
            this.Load += new System.EventHandler(this.MantenedorAsociacionGruposConceptosCuentas_CopiarPlantilla_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridSeleccion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button ButtonAplicarTodos;
        private System.Windows.Forms.Button ButtonCancelar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button ButtonAplicaSeleccionar;
        private System.Windows.Forms.DataGridView gridSeleccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdConsolidado;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSeleccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigoConsolidado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescripcionConsolidado;
    }
}