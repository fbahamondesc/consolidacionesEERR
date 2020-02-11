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
    public partial class MantenedorAsociacionGruposConceptosCuentas_CopiarPlantilla : Form
    {
        private MyLog4Net hLog = new MyLog4Net("MantenedorAsociacionGruposConceptosCuentas_CopiarPlantilla.Form");

        public MantenedorAsociacionGruposConceptosCuentas_CopiarPlantilla()
        {
            InitializeComponent();
            ConfiguracionFormulario();

        }

        private void MantenedorAsociacionGruposConceptosCuentas_CopiarPlantilla_Load(object sender, EventArgs e)
        {
            CargaFormulario();
        }

        private void ButtonAplicarTodos_Click(object sender, EventArgs e)
        {
            AplicarTodos();
        }

        private void ButtonAplicaSeleccionar_Click(object sender, EventArgs e)
        {
            AplicarSeleccion();
        }

        //----------------------------------------------------------------------------------------------------------------
        //						Metodos Privados
        //----------------------------------------------------------------------------------------------------------------

        private void ConfiguracionFormulario()
        {
            ButtonAplicarTodos.Height = CFG.buttonAlto;

            ButtonCancelar.Image = global::NewConsolidado.Properties.Resources.rsc_24_SalirForm;
            ButtonCancelar.Image = global::NewConsolidado.Properties.Resources.rsc_24_SalirForm;
            ButtonCancelar.Size = new System.Drawing.Size(CFG.buttonAncho, CFG.buttonAlto);
            ButtonCancelar.Text = "Salir";
            ButtonCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ButtonCancelar.UseVisualStyleBackColor = true;

        }

        private void CargaFormulario()
        {
            try
            {
                BOConsolidados oBO = new BOConsolidados();
                List<DTOConsolidados> lDTO = new List<DTOConsolidados>();
                lDTO = oBO.ConsultaConsolidados((int)CFG.TipoConsolidado.Consolidado, "");

                foreach (DTOConsolidados oDTO in lDTO)
                {
                    gridSeleccion.Rows.Add();
                    //gridSeleccion.Rows[gridSeleccion.Rows.Count - 1].Cells["colIdConsolidado"].Value = oDTO.IdRegistro.ToString();
                    gridSeleccion.Rows[gridSeleccion.Rows.Count - 1].Cells["colCodigoConsolidado"].Value = oDTO.Codigo.ToString();
                    gridSeleccion.Rows[gridSeleccion.Rows.Count - 1].Cells["colDescripcionConsolidado"].Value = oDTO.Descripcion.ToString();
                }
            }
            catch (Exception Ex)
            {
                hLog.msgFatal("Error : \n" + Ex.Message);
            }
        }

        private void AplicarTodos()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                BOConsolidadosAsociacionGrupo oBO = new BOConsolidadosAsociacionGrupo();
                oBO.AplicarPlantillaTodos();


                hLog.msgInfo("Proceso terminado con exito");
                this.Close();
            }
            catch (Exception Ex)
            {
                hLog.msgFatal("Error : \n" + Ex.Message);
            }
            this.Cursor = Cursors.Default;
        }

        private void AplicarSeleccion()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                string sCodigos = "";
                string sSep = "";

                if (gridSeleccion.Rows.Count > 0)
                {
                    for (int iI = 0; iI < gridSeleccion.Rows.Count; iI++)
                    {
                        if (gridSeleccion.Rows[iI].Cells["colSeleccion"].Value != null)
                        {
                            sCodigos += sSep + gridSeleccion.Rows[iI].Cells["colCodigoConsolidado"].Value + "^" + gridSeleccion.Rows[iI].Cells["colDescripcionConsolidado"].Value;
                            sSep = "¨";
                        }
                    }

                    if (!string.IsNullOrEmpty(sCodigos))
                    {
                        BOConsolidadosAsociacionGrupo oBO = new BOConsolidadosAsociacionGrupo();
                        oBO.AplicaPlantillaSeleccionadas(sCodigos);

                        hLog.msgInfo("Proceso terminado con exito");

                        this.Close();
                    }
                    else
                    {
                        hLog.msgError("Debe seleccionar al menos un consolidado para realizar el proceso");
                    }
                }
            }
            catch (Exception Ex)
            {
                hLog.msgFatal("Error : \n" + Ex.Message);
            }
            this.Cursor = Cursors.Default;
        }
    }
}
