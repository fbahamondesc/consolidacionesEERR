using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using NewConsolidado.Controladores.Clases;
using NewConsolidado.Modelos.TransporteDatos;
using NewConsolidado.Controladores.ControladorNegocio;

namespace NewConsolidado.Vistas.Formularios
{
    public partial class MantenedorConsolidados_ConfiguracionImprimir : Form
    {
        private MyLog4Net hLog = new MyLog4Net("MantenedorConsolidados_ConfiguracionImprimir.Form");

        private int hiIdConsolidado = 0;
        private int hiIdComparativo = 0;
        private int hiSet = (int)CFG.TipoConfImpresion.nada; // Define tipo de la configuracion

        public MantenedorConsolidados_ConfiguracionImprimir(int iSet)
        {
            InitializeComponent();
            hiSet = iSet;
            ConfiguracionFormulario();
        }

        private void MantenedorConsolidados_ConfiguracionImprimir_Load(object sender, EventArgs e)
        {
            CargarFormulario();
        }

        private void buttonGrabar_Click(object sender, EventArgs e)
        {
            BotonAceptar();
        }

        private void buttonSalir_Click(object sender, EventArgs e)
        {
            BotonSalir();
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            BotonLimpiar();
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            BotonBuscar();
        }
        private void MantenedorConsolidados_ConfiguracionImprimir_Shown(object sender, EventArgs e)
        {
            textPeriodoDefecto.SelectAll();
            textPeriodoDefecto.Focus();
        }

        private void buttonBuscarConfiguracion_Click(object sender, EventArgs e)
        {
            BotonBuscarConfiguracionPeriodos();
        }

        private void buttonLimpiarPeriodo_Click(object sender, EventArgs e)
        {
            BotonLimpiarPeridoConsolidado();
        }

        private void textPeriodoDefecto_TextChanged(object sender, EventArgs e)
        {
            TextoPeriodoDefecto();
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

        //------------------------------------------------------------------------------------------------------------------
        // Metodos privados
        //------------------------------------------------------------------------------------------------------------------
        private void ConfiguracionFormulario()
        {
            switch (hiSet)
            {
                case (int)CFG.TipoConfImpresion.ESF:
                    {
                        this.Text = "Configuración Comparativo Estado Situación Financiera";
                        break;
                    }
                case (int)CFG.TipoConfImpresion.ERF:
                    {
                        this.Text = "Configuración Comparativo Estado Resultado por Función";
                        break;
                    }
                default:
                    {
                        hLog.msgError("Parametro mal seleccionado"); break;
                    }
            }

            textPeriodoDefecto.MaxLength = 6;
            textPeriodoComparativo.MaxLength = 6;

            buttonGrabar.TabIndex = 0;
            buttonSalir.TabIndex = 1;
            textPeriodoDefecto.TabIndex = 2;
            buttonLimpiar.TabIndex = 3;
            buttonBuscar.TabIndex = 4;
            textPeriodoComparativo.TabIndex = 5;

            buttonLimpiar.Image = NewConsolidado.Properties.Resources.rsc_16_ClearLeft;
            buttonBuscar.Image = NewConsolidado.Properties.Resources.rsc_16_Buscar;
            buttonBuscarConfiguracion.Image = NewConsolidado.Properties.Resources.rsc_16_Buscar;
            buttonLimpiarPeriodo.Image = NewConsolidado.Properties.Resources.rsc_16_ClearLeft;

            buttonGrabar.Image = NewConsolidado.Properties.Resources.rsc_24_Grabar;
            buttonGrabar.Size = new System.Drawing.Size(CFG.buttonAncho, CFG.buttonAlto);
            buttonGrabar.Text = "Aceptar";
            buttonGrabar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            buttonGrabar.UseVisualStyleBackColor = true;

            buttonSalir.Image = global::NewConsolidado.Properties.Resources.rsc_24_SalirForm;
            buttonSalir.Size = new System.Drawing.Size(CFG.buttonAncho, CFG.buttonAlto);
            buttonSalir.Text = "Salir";
            buttonSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            buttonSalir.UseVisualStyleBackColor = true;

        }

        private void CargarFormulario()
        {
            try
            {
                BOConsolidados oBO = new BOConsolidados();
                DTOConsolidados oDTO = new DTOConsolidados();
                BOConfiguracionComparativos oBOC = new BOConfiguracionComparativos();
                DTOConfiguracionComparativos oDTOC = new DTOConfiguracionComparativos();

                oDTO = oBO.ConsultaConsolidado(hiIdConsolidado);
                textInicio.Text = oDTO.PeriodoInicio;
                textTermino.Text = oDTO.PeriodoTermino;
                //
                switch (hiSet)
                {
                    case (int)CFG.TipoConfImpresion.ESF:
                        {
                            oDTOC = oBOC.ObtienePorDefecto(hiIdConsolidado, (int)CFG.TipoConfImpresion.ESF);
                            if (oDTOC != null)
                            {
                                textPeriodoDefecto.Text = oDTOC.Periodo;
                                textPeriodoComparativo.Text = oDTOC.PeriodoComparativo;

                                DTOConsolidados oDTOCO = new DTOConsolidados();
                                oDTOCO = oBO.ConsultaConsolidado(oDTOC.IdComparativo);
                                hiIdComparativo = oDTOC.IdComparativo;

                                textCodigoComparativo.Text = oDTOCO.Codigo;
                                textDescripcionComparativo.Text = oDTOCO.Descripcion;
                                textPeriodoInicio.Text = oDTOCO.PeriodoInicio;
                                textPeriodoTermino.Text = oDTOCO.PeriodoTermino;
                            }
                            break;
                        }
                    case (int)CFG.TipoConfImpresion.ERF:
                        {
                            oDTOC = oBOC.ObtienePorDefecto(hiIdConsolidado, (int)CFG.TipoConfImpresion.ERF);
                            if (oDTOC != null)
                            {
                                textPeriodoDefecto.Text = oDTOC.Periodo;
                                textPeriodoComparativo.Text = oDTOC.PeriodoComparativo;

                                DTOConsolidados oDTOCO = new DTOConsolidados();
                                oDTOCO = oBO.ConsultaConsolidado(oDTOC.IdComparativo);
                                hiIdComparativo = oDTOC.IdComparativo;

                                textCodigoComparativo.Text = oDTOCO.Codigo;
                                textDescripcionComparativo.Text = oDTOCO.Descripcion;
                                textPeriodoInicio.Text = oDTOCO.PeriodoInicio;
                                textPeriodoTermino.Text = oDTOCO.PeriodoTermino;
                            }

                            break;
                        }
                    default:
                        {
                            break;
                        }
                }

                textPeriodoDefecto.SelectAll();
                textPeriodoDefecto.Focus();
            }
            catch (Exception ex)
            {
                hLog.msgError(ex.Message);
            }
        }

        private void BotonSalir()
        {
            this.DialogResult = DialogResult.Abort;
            this.Close();
        }

        private void BotonAceptar()
        {
            if (ValidarCampos())
            {
                try
                {
                    BOConfiguracionComparativos oBO = new BOConfiguracionComparativos();
                    oBO.AceptarPeriodo(hiIdConsolidado, hiSet, textPeriodoDefecto.Text, hiIdComparativo, textPeriodoComparativo.Text);

                    this.DialogResult = DialogResult.OK;
                    this.Close();

                }
                catch (Exception ex)
                {
                    hLog.msgError(ex.Message);
                }
            }
        }

        private Boolean ValidarCampos()
        {
            if (textPeriodoDefecto.Text == "")
            {
                hLog.msgError("Debe seleccionar un periodo de visualización");
                textPeriodoDefecto.SelectAll();
                textPeriodoDefecto.Focus();
                return false;
            }
            ////
            //int iPI = int.Parse(textInicio.Text);
            //int iPV = 0;
            ////
            //if (!int.TryParse(textPeriodoDefecto.Text, out iPV))
            //{
            //    hLog.msgError("Debe seleccionar un periodo valido de visualización");
            //    textPeriodoDefecto.SelectAll();
            //    textPeriodoDefecto.Focus();
            //    return false;
            //}
            if (!MisFunciones.esNumerico(textInicio.Text))
            {
                hLog.msgError("Debe seleccionar un periodo valido de visualización");
                textPeriodoDefecto.SelectAll();
                textPeriodoDefecto.Focus();
                return false;
            }

            if (textPeriodoDefecto.Text.Trim().Length == 6)
            {
                string cadena = textPeriodoDefecto.Text.Substring(4, 2);
                if (Convert.ToInt32(cadena) < 1 || Convert.ToInt32(cadena) > 12)
                {
                    hLog.msgError("Debe seleccionar un periodo valido de visualización");
                    textPeriodoDefecto.SelectAll();
                    textPeriodoDefecto.Focus();
                    return false;
                }
            }
            else
            {
                hLog.msgError("Debe seleccionar un periodo valido de visualización");
                textPeriodoDefecto.SelectAll();
                textPeriodoDefecto.Focus();
                return false;
            }
            if (textTermino.Text == "")
            {
                int iPV = int.Parse(textPeriodoDefecto.Text);
                int iPI = int.Parse(textInicio.Text);
                if (!(iPV >= iPI))
                {
                    hLog.msgError("El periodo de visualización debe ser mayor o Igual al de Inicio");
                    textPeriodoDefecto.SelectAll();
                    textPeriodoDefecto.Focus();
                    return false;
                }
            }
            else
            {
                int iPV = int.Parse(textPeriodoDefecto.Text);
                int iPI = int.Parse(textInicio.Text);
                int iPT = int.Parse(textTermino.Text);
                if (!(iPV >= iPI && iPV <= iPT))
                {
                    hLog.msgError("El periodo de visualización debe estar dentro el periodo");
                    textPeriodoDefecto.SelectAll();
                    textPeriodoDefecto.Focus();
                    return false;
                }
            }
            if (textCodigoComparativo.Text.Trim() != "")
            {
                if (textPeriodoComparativo.Text == "")
                {
                    hLog.msgError("Debe seleccionar un periodo de visualización");
                    textPeriodoComparativo.SelectAll();
                    textPeriodoComparativo.Focus();
                    return false;
                }
                if (textPeriodoComparativo.Text.Trim().Length == 6)
                {
                    string cadena = textPeriodoComparativo.Text.Substring(4, 2);
                    if (Convert.ToInt32(cadena) < 1 || Convert.ToInt32(cadena) > 12)
                    {
                        hLog.msgError("Debe seleccionar un periodo valido de visualización");
                        textPeriodoComparativo.SelectAll();
                        textPeriodoComparativo.Focus();
                        return false;
                    }
                }
                else
                {
                    hLog.msgError("Debe seleccionar un periodo valido de visualización");
                    textPeriodoDefecto.SelectAll();
                    textPeriodoDefecto.Focus();
                    return false;
                }

                ////
                //int iPIC = int.Parse(textPeriodoInicio.Text);
                //int iPVC = 0;
                ////
                //if (!int.TryParse(textPeriodoComparativo.Text, out iPVC))
                //{
                //    hLog.msgError("Debe seleccionar un periodo valido de visualización");
                //    textPeriodoComparativo.SelectAll();
                //    textPeriodoComparativo.Focus();
                //    return false;
                //}

                if (!MisFunciones.esNumerico(textPeriodoInicio.Text))
                {
                    hLog.msgError("Debe seleccionar un periodo valido de visualización");
                    textPeriodoComparativo.SelectAll();
                    textPeriodoComparativo.Focus();
                    return false;
                }

                if (textPeriodoTermino.Text == "")
                {
                    int iPIC = int.Parse(textPeriodoInicio.Text);
                    int iPVC = int.Parse(textPeriodoComparativo.Text);
                    if (!(iPVC >= iPIC))
                    {
                        hLog.msgError("El periodo de visualización debe ser mayor o Igual al de Inicio");
                        textPeriodoComparativo.SelectAll();
                        textPeriodoComparativo.Focus();
                        return false;
                    }
                }
                else
                {
                    int iPIC = int.Parse(textPeriodoInicio.Text);
                    int iPVC = int.Parse(textPeriodoComparativo.Text);
                    int iPTC = int.Parse(textPeriodoTermino.Text);
                    if (!(iPVC >= iPIC && iPVC <= iPTC))
                    {
                        hLog.msgError("El periodo de visualización debe estar dentro el periodo");
                        textPeriodoComparativo.SelectAll();
                        textPeriodoComparativo.Focus();
                        return false;
                    }
                }
            }
            return true;
        }

        public void BotonLimpiar()
        {
            hiIdComparativo = 0;
            textPeriodoInicio.Text = "";
            textPeriodoTermino.Text = "";
            textDescripcionComparativo.Text = "";
            textCodigoComparativo.Text = "";
            textPeriodoComparativo.Text = "";
        }

        public void BotonBuscar()
        {
            try
            {
                if (string.IsNullOrEmpty(textPeriodoDefecto.Text.Trim()))
                {
                    hLog.msgError("Debe seleccionar un periodo por defecto para el consolidado antes de seleccionar el comparativo");
                    textPeriodoDefecto.Text = "    ";
                    textPeriodoDefecto.SelectAll();
                    textPeriodoDefecto.Focus();
                }
                else
                {
                    string sPerComp = "";

                    textCodigoComparativo.Text = "";
                    textDescripcionComparativo.Text = "";
                    textPeriodoInicio.Text = "";
                    textPeriodoTermino.Text = "";
                    textPeriodoComparativo.Text = "";

                    MantenedorConsolidados_ConsultaArbolConsolidados oForm = new MantenedorConsolidados_ConsultaArbolConsolidados();
                    oForm.StartPosition = FormStartPosition.CenterParent;
                    oForm.ShowIcon = false;
                    oForm.ShowInTaskbar = false;
                    if (oForm.ShowDialog(this) == DialogResult.OK)
                    {
                        BOConsolidados oBO = new BOConsolidados();
                        DTOConsolidados oDTO = new DTOConsolidados();
                        oDTO = oBO.ConsultaConsolidado(oForm.CodigoRegistro);

                        string sPaso = "";
                        int iValor = 0;
                        int iIni = 0;
                        int iTer = 0;

                        switch (hiSet)
                        {
                            case (int)CFG.TipoConfImpresion.ERF:
                                {
                                    sPaso = textPeriodoDefecto.Text;
                                    iValor = int.Parse(sPaso) - 100;
                                    iIni = int.Parse(oDTO.PeriodoInicio);
                                    if (string.IsNullOrEmpty(oDTO.PeriodoTermino))
                                    {
                                        iTer = int.Parse(DateTime.Now.Year.ToString("D4") + DateTime.Now.Month.ToString("D2"));
                                    }
                                    else
                                    {
                                        iTer = int.Parse(oDTO.PeriodoTermino);
                                    }

                                    // Comparamos el valor calculado para saber si esta en el rengo correcto
                                    if (iValor >= iIni && iValor <= iTer)
                                    {
                                        sPerComp = iValor.ToString();

                                        hiIdComparativo = oForm.CodigoRegistro;
                                        textCodigoComparativo.Text = oDTO.Codigo;
                                        textDescripcionComparativo.Text = oDTO.Descripcion;
                                        textPeriodoInicio.Text = oDTO.PeriodoInicio;
                                        textPeriodoTermino.Text = oDTO.PeriodoTermino;
                                        textPeriodoComparativo.Text = sPerComp;
                                    }
                                    else
                                    {
                                        hLog.msgError("No es posible usar el consolidado seleccionado por no contar con el periodo del año anterior");
                                    }
                                    break;
                                }
                            case (int)CFG.TipoConfImpresion.ESF:
                                {
                                    sPaso = textPeriodoDefecto.Text.Substring(0, 4) + "12";
                                    iValor = int.Parse(sPaso) - 100;
                                    iIni = int.Parse(oDTO.PeriodoInicio);
                                    if (string.IsNullOrEmpty(oDTO.PeriodoTermino))
                                    {
                                        iTer = int.Parse(DateTime.Now.Year.ToString("D4") + DateTime.Now.Month.ToString("D2"));
                                    }
                                    else
                                    {
                                        iTer = int.Parse(oDTO.PeriodoTermino);
                                    }

                                    // Comparamos el valor calculado para saber si esta en el rengo correcto
                                    if (iValor >= iIni && iValor <= iTer)
                                    {
                                        sPerComp = iValor.ToString();

                                        hiIdComparativo = oForm.CodigoRegistro;
                                        textCodigoComparativo.Text = oDTO.Codigo;
                                        textDescripcionComparativo.Text = oDTO.Descripcion;
                                        textPeriodoInicio.Text = oDTO.PeriodoInicio;
                                        textPeriodoTermino.Text = oDTO.PeriodoTermino;
                                        textPeriodoComparativo.Text = sPerComp;
                                    }
                                    else
                                    {
                                        hLog.msgError("No es posible usar el consolidado seleccionado por no contar con el periodo de Diciembre del año anterior");
                                    }
                                    break;
                                }
                            default:
                                {
                                    sPerComp = "";
                                    break;
                                }
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                hLog.msgFatal(Ex.Message);
            }
        }
        private void BotonBuscarConfiguracionPeriodos()
        {
            try
            {
                MantenedorConsolidados_ConsultaConfiguraciones oForm = new MantenedorConsolidados_ConsultaConfiguraciones();
                oForm.StartPosition = FormStartPosition.CenterParent;
                oForm.ShowIcon = false;
                oForm.ShowInTaskbar = false;
                oForm.IdConsolidado = hiIdConsolidado;
                oForm.TipoConfiguracion = hiSet;
                if (oForm.ShowDialog(this) == DialogResult.OK)
                {
                    // periodo seleccionado
                    hiIdComparativo = oForm.IdComparativo;
                    textPeriodoDefecto.Text = oForm.Periodo;

                    BOConsolidados oBO = new BOConsolidados();
                    DTOConsolidados oDTOC = new DTOConsolidados();
                    oDTOC = oBO.ConsultaConsolidado(hiIdComparativo);
                    textCodigoComparativo.Text = oDTOC.Codigo;
                    textDescripcionComparativo.Text = oDTOC.Descripcion;
                    textPeriodoInicio.Text = oDTOC.PeriodoInicio;
                    textPeriodoTermino.Text = oDTOC.PeriodoTermino;
                    textPeriodoComparativo.Text = oForm.PeriodoComparativo;
                }
            }
            catch (Exception Ex)
            {
                hLog.msgFatal(Ex.Message);
            }
        }

        private void BotonLimpiarPeridoConsolidado()
        {
            textPeriodoDefecto.Text = "";

            textCodigoComparativo.Text = "";
            textDescripcionComparativo.Text = "";
            textPeriodoInicio.Text = "";
            textPeriodoTermino.Text = "";
            textPeriodoComparativo.Text = "";
        }

        private void TextoPeriodoDefecto()
        {
            if (textPeriodoDefecto.Text.Length == 6)
            {
                BOConfiguracionComparativos oBO = new BOConfiguracionComparativos();
                List<DTOConfiguracionComparativos> lDTOC = new List<DTOConfiguracionComparativos>();
                lDTOC = oBO.ConsultaComparativos(hiIdConsolidado, hiSet, textPeriodoDefecto.Text);
                if (lDTOC.Count > 0)
                {
                    BOConsolidados oBOC = new BOConsolidados();
                    DTOConsolidados oDTOC = new DTOConsolidados();
                    oDTOC = oBOC.ConsultaConsolidado(lDTOC[0].IdComparativo);
                    textCodigoComparativo.Text = oDTOC.Codigo;
                    textDescripcionComparativo.Text = oDTOC.Descripcion;
                    textPeriodoInicio.Text = oDTOC.PeriodoInicio;
                    textPeriodoTermino.Text = oDTOC.PeriodoTermino;

                    hiIdComparativo = lDTOC[0].IdComparativo;
                    textPeriodoComparativo.Text = lDTOC[0].PeriodoComparativo;
                }
            }
            else
            {
                hiIdComparativo = 0;
                textCodigoComparativo.Text = "";
                textDescripcionComparativo.Text = "";
                textPeriodoInicio.Text = "";
                textPeriodoTermino.Text = "";
                textPeriodoComparativo.Text = "";
            }
        }
    }
}