using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using NewConsolidado.Controladores.Clases;
using NewConsolidado.Controladores.ControladorNegocio;
using NewConsolidado.Modelos.TransporteDatos;

namespace NewConsolidado.Vistas.Formularios
{
    public partial class MantenedorConsolidados_ConsultaConfiguraciones : Form
    {
        private MyLog4Net hLog = new MyLog4Net("MantenedorConsolidados_ConsultaConfiguraciones.Form");

        private int hiIdConsolidado = 0;
        private int hiIdComparativo = 0;
        private int hiTipoConfiguracion = 0;
        private string hsPeriodo = "";
        private string hsPeriodoComparativo = "";

        public MantenedorConsolidados_ConsultaConfiguraciones()
        {
            InitializeComponent();
            InicializaFormulario();
        
        }

        private void MantenedorConsolidados_ConsultaConfiguraciones_Load(object sender, EventArgs e)
        {
            ConfiguracionFormulario();
        }

        private void buttonSalir_Click(object sender, EventArgs e)
        {
            BotonSalir();
        }

        private void buttonGrabar_Click(object sender, EventArgs e)
        {
            BotonAceptar();
        }

        private void buttonPorDefecto_Click(object sender, EventArgs e)
        {
            BotonPorDefecto();
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            BotonEliminar();
        }
        //------------------------------------------------------------------------------------------------------------------
        // Accesos publicos
        //------------------------------------------------------------------------------------------------------------------
        public int IdConsolidado
        {
            get { return hiIdConsolidado; }
            set { hiIdConsolidado = value; }
        }

        public int IdComparativo
        {
            get { return hiIdComparativo; }
            set { hiIdComparativo = value; }
        }

        public int TipoConfiguracion
        {
            get { return hiTipoConfiguracion; }
            set { hiTipoConfiguracion = value; }
        }

        public string Periodo
        {
            get { return hsPeriodo; }
        }

        public string PeriodoComparativo
        {
            get { return hsPeriodoComparativo; }
        }
        //------------------------------------------------------------------------------------------------------------------
        // Metodos privados
        //------------------------------------------------------------------------------------------------------------------
        private void InicializaFormulario()
        {
            buttonGrabar.Image = NewConsolidado.Properties.Resources.rsc_24_Grabar;
            buttonGrabar.Size = new System.Drawing.Size(CFG.buttonAncho, CFG.buttonAlto);
            buttonGrabar.Text = "Aceptar";
            buttonGrabar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            buttonGrabar.UseVisualStyleBackColor = true;
            //
            buttonSalir.Image = global::NewConsolidado.Properties.Resources.rsc_24_SalirForm;
            buttonSalir.Size = new System.Drawing.Size(CFG.buttonAncho, CFG.buttonAlto);
            buttonSalir.Text = "Salir";
            buttonSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            buttonSalir.UseVisualStyleBackColor = true;

            gridPeriodosConfigurados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void ConfiguracionFormulario()
        {
            try
            {
                BOConfiguracionComparativos oBO = new BOConfiguracionComparativos();
                List<DTOConfiguracionComparativos> lDTO = oBO.ConsultaComparativos(hiIdConsolidado, hiTipoConfiguracion, "");

                gridPeriodosConfigurados.Rows.Clear();
                foreach (DTOConfiguracionComparativos oDTO in lDTO)
                {
                    gridPeriodosConfigurados.Rows.Add();
                    gridPeriodosConfigurados.Rows[gridPeriodosConfigurados.Rows.Count - 1].Cells["colDefecto"].Value = (oDTO.PorDefecto == (int)CFG.SiNo.Si ? "*" : "");
                    gridPeriodosConfigurados.Rows[gridPeriodosConfigurados.Rows.Count - 1].Cells["colPeriodo"].Value = oDTO.Periodo;
                    gridPeriodosConfigurados.Rows[gridPeriodosConfigurados.Rows.Count - 1].Cells["colCodConsolidado"].Value = oDTO.CodigoComparativo;
                    gridPeriodosConfigurados.Rows[gridPeriodosConfigurados.Rows.Count - 1].Cells["colPeriodoComparativo"].Value = oDTO.PeriodoComparativo;
                    gridPeriodosConfigurados.Rows[gridPeriodosConfigurados.Rows.Count - 1].Cells["colIdComparativo"].Value = oDTO.IdComparativo;

                    if (oDTO.PorDefecto == (int)CFG.SiNo.Si)
                    {
                        gridPeriodosConfigurados.Rows[gridPeriodosConfigurados.Rows.Count - 1].Selected = true;
                    }
                }
                

            }
            catch (Exception ex)
            {
                hLog.msgFatal(ex.Message);
            }
        }

        private void BotonPorDefecto()
        {
            try
            {
                if (gridPeriodosConfigurados.Rows.Count > 0)
                {
                    if (gridPeriodosConfigurados.SelectedRows.Count > 0)
                    {
                        string sPeriodo = (string)gridPeriodosConfigurados.Rows[gridPeriodosConfigurados.CurrentCell.RowIndex].Cells["colPeriodo"].Value;

                        BOConfiguracionComparativos oBO = new BOConfiguracionComparativos();
                        oBO.ActualizaPorDefecto(hiIdConsolidado, hiTipoConfiguracion, sPeriodo);

                        ConfiguracionFormulario();
                    }
                    else
                    {
                        hLog.msgError("Debe seleccionar un registro para ");
                    }
                }
            }
            catch (Exception ex)
            {
                hLog.msgFatal(ex.Message);
            }
        }

        private void BotonEliminar()
        {
            try
            {
                if (gridPeriodosConfigurados.Rows.Count > 0)
                {
                    if (gridPeriodosConfigurados.SelectedRows.Count > 0)
                    {
                        string sPeriodo = (string)gridPeriodosConfigurados.Rows[gridPeriodosConfigurados.CurrentCell.RowIndex].Cells["colPeriodo"].Value;

                        BOConfiguracionComparativos oBO = new BOConfiguracionComparativos();
                        oBO.EliminaConfiguracion(hiIdConsolidado, hiTipoConfiguracion, sPeriodo);

                        ConfiguracionFormulario();
                    }
                }
            }
            catch (Exception ex)
            {
                hLog.msgFatal(ex.Message);
            }
        }

        private void BotonAceptar()
        {
            if (gridPeriodosConfigurados.Rows.Count > 0)
            {
                if (gridPeriodosConfigurados.SelectedRows.Count > 0)
                {
                    hiIdComparativo = (int)gridPeriodosConfigurados.Rows[gridPeriodosConfigurados.CurrentCell.RowIndex].Cells["colIdComparativo"].Value;
                    hsPeriodo = (string)gridPeriodosConfigurados.Rows[gridPeriodosConfigurados.CurrentCell.RowIndex].Cells["colPeriodo"].Value;
                    hsPeriodoComparativo = (string)gridPeriodosConfigurados.Rows[gridPeriodosConfigurados.CurrentCell.RowIndex].Cells["colPeriodoComparativo"].Value;
                }
            }
            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        private void BotonSalir()
        {
            this.DialogResult = DialogResult.Abort;
            this.Close();
        }
    }
}
