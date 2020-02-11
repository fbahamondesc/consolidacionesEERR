using System;
using System.Collections.Generic;
using System.Windows.Forms;

using NewConsolidado.Controladores.Clases;
using NewConsolidado.Controladores.ControladorNegocio;
using NewConsolidado.Modelos.TransporteDatos;
using NewConsolidado.Vistas.Reportes.ERF;
using NewConsolidado.Vistas.Reportes.ESF;
using NewConsolidado.Vistas.Reportes.ERFSuperintendencia;
using NewConsolidado.Vistas.Reportes.ESFSuperintendencia;

namespace NewConsolidado.Vistas.Formularios
{
    public partial class MenuReportes : Form
    {
        private MyLog4Net hLog = new MyLog4Net("MenuReportes.Form");
        private int hiIdConsolidado = 0;
        private int hiIdComparativo = 0;
        private string hsPeriodoComparativo = "";
        private string hsPeriodo = "";
        /// <summary>        
        /// hiReporte = Numero del reporte enviado        
        /// </summary>
        private int hiReporte = 0; 
        /// <summary>
        /// hiSet = Tipo de reporte enviado
        /// </summary>
        private int hiSet = 0;

        public MenuReportes()
        {
            InitializeComponent();
            ConfigurarEntorno();
        }

        private void MenuReportes_Load(object sender, EventArgs e)
        {
            this.Width = 408;
            this.Height = 408;
            CargaConsolidado();
        }

        private void buttonBuscaConsolidadoComparar_Click(object sender, EventArgs e)
        {
            BuscaConsolidadosComparar();
        }

        private void bttnVisualizar_Click(object sender, EventArgs e)
        {
            VisualizaReporte();
        }

        private void listReportes_DoubleClick(object sender, EventArgs e)
        {
            VisualizaReporte();
        }

        private void buttonSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            BotonLimpiarCampos();
        }
        private void MenuReportes_Shown(object sender, EventArgs e)
        {
            textPeriodoVisualizar.SelectAll();
            textPeriodoVisualizar.Focus();
        }

        private void textPeriodoVisualizar_TextChanged(object sender, EventArgs e)
        {
            TextoPeriodoVisualizar();
        }
        private void buttonSincronizar_Click(object sender, EventArgs e)
        {
            SincronizarODBC();
        }

        //------------------------------------------------------------------------------------------------------------------
        // Accesos publicos
        //------------------------------------------------------------------------------------------------------------------

        public int idConsolidado
        {
            get { return hiIdConsolidado; }
            set { hiIdConsolidado = value; }
        }

        public string Periodo
        {
            get { return hsPeriodo; }
            set { hsPeriodo = value; }
        }

        public int idComparativo
        {
            get { return hiIdComparativo; }
            set { hiIdComparativo = value; }
        }

        public string PeriodoComparativo
        {
            get { return hsPeriodoComparativo; }
            set { hsPeriodoComparativo = value; }
        }

        public int Reporte
        {
            get { return hiReporte; }
            set { hiReporte = value; }
        }

        public int SetRep
        {
            get { return hiSet; }
            set { hiSet = value; }
        }
        //------------------------------------------------------------------------------------------------------------------
        // Metodos privados
        //------------------------------------------------------------------------------------------------------------------
        private void ConfigurarEntorno()
        {
            buttonBuscaConsolidadoComparar.Image = global::NewConsolidado.Properties.Resources.rsc_16_Buscar;
            buttonBuscaConsolidadoComparar.Size = new System.Drawing.Size(70, 24);
            buttonBuscaConsolidadoComparar.Text = "Buscar";
            buttonBuscaConsolidadoComparar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            buttonBuscaConsolidadoComparar.UseVisualStyleBackColor = true;

            buttonLimpiar.Image = global::NewConsolidado.Properties.Resources.rsc_16_ClearLeft;
            //
            laDescripcionConsolidado.Text = "";
            laDescripcionConsolidadoComparar.Text = "";
            //
            textCodigoConsolidado.TabIndex = 0;
            textPeriodoVisualizar.TabIndex = 2;
            //
            textCodigoConsolidadoComparar.TabIndex = 3;
            buttonBuscaConsolidadoComparar.TabIndex = 4;
            textPeriodoVisualizarComparar.TabIndex = 5;
            //
            //listReportes.TabIndex = 7;
            //comboReportes.TabIndex = 9;
            buttonVisualizar.TabIndex = 8;
            //
            textCodigoConsolidado.MaxLength = 18;
            textCodigoConsolidadoComparar.MaxLength = 18;
            //
            textCodigoConsolidado.Focus();
        }

        private void CargaConsolidado()
        {
            switch (hiReporte)
            {
                case (int)CFG.Reporte.esf:
                    {
                        this.Text = "Reporte Estado Situación Financiera";
                        break;
                    }
                case (int)CFG.Reporte.esfSuper:
                    {
                        this.Text = "Reporte Estado Situación Financiera para Superintendencia";
                        //buttonSincronizar.Enabled = false;
                        break;
                    }
                case (int)CFG.Reporte.erf:
                    {
                        this.Text = "Reporte Estado Resultado por Función";
                        break;
                    }
                case (int)CFG.Reporte.erfSuper:
                    {
                        this.Text = "Reporte Estado Resultado por Función para Superintendencia";
                        //buttonSincronizar.Enabled = false;
                        break;
                    }
                default:
                    {
                        hLog.Fatal("Mala clasificacion al {CargaConsolidado}");
                        throw new SystemException("Mala clasificacion al {CargaConsolidado}");

                    }
            }

            BOConsolidados oBO = new BOConsolidados();
            DTOConsolidados oDTO = new DTOConsolidados();
            BOConfiguracionComparativos oBOC = new BOConfiguracionComparativos();
            DTOConfiguracionComparativos oDTOC = new DTOConfiguracionComparativos();

            oDTO = oBO.ConsultaConsolidado(hiIdConsolidado);
            textCodigoConsolidado.Text = oDTO.Codigo;
            laDescripcionConsolidado.Text = oDTO.Descripcion;
            textPeriodoInicio.Text = oDTO.PeriodoInicio;
            textPeriodoTermino.Text = oDTO.PeriodoTermino;
            //
            switch (hiSet)
            {
                case (int)CFG.TipoConfImpresion.ESF:
                    {
                        oDTOC = oBOC.ObtienePorDefecto(hiIdConsolidado, (int)CFG.TipoConfImpresion.ESF);
                        if (oDTOC != null)
                        {
                            textPeriodoVisualizar.Text = oDTOC.Periodo;
                            textPeriodoVisualizarComparar.Text = oDTOC.PeriodoComparativo;

                            DTOConsolidados oDTOCO = new DTOConsolidados();
                            oDTOCO = oBO.ConsultaConsolidado(oDTOC.IdComparativo);
                            hiIdComparativo = oDTOC.IdComparativo;

                            textCodigoConsolidadoComparar.Text = oDTOCO.Codigo;
                            laDescripcionConsolidadoComparar.Text = oDTOCO.Descripcion;
                            textPeriodoInicioComparar.Text = oDTOCO.PeriodoInicio;
                            textPeriodoTerminoComparar.Text = oDTOCO.PeriodoTermino;
                        }
                        break;
                    }
                case (int)CFG.TipoConfImpresion.ERF:
                    {
                        oDTOC = oBOC.ObtienePorDefecto(hiIdConsolidado, (int)CFG.TipoConfImpresion.ERF);
                        if (oDTOC != null)
                        {
                            textPeriodoVisualizar.Text = oDTOC.Periodo;
                            textPeriodoVisualizarComparar.Text = oDTOC.PeriodoComparativo;

                            DTOConsolidados oDTOCO = new DTOConsolidados();
                            oDTOCO = oBO.ConsultaConsolidado(oDTOC.IdComparativo);
                            hiIdComparativo = oDTOC.IdComparativo;

                            textCodigoConsolidadoComparar.Text = oDTOCO.Codigo;
                            laDescripcionConsolidadoComparar.Text = oDTOCO.Descripcion;
                            textPeriodoInicioComparar.Text = oDTOCO.PeriodoInicio;
                            textPeriodoTerminoComparar.Text = oDTOCO.PeriodoTermino;
                        }

                        break;
                    }
                default:
                    {
                        break;
                    }
            }

            textPeriodoVisualizar.SelectAll();
            textPeriodoVisualizar.Focus();
        }

        private void VisualizaReporte()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                if (ValidarCampos())
                {
                    //
                    // cargamos los datos en variables de paso
                    //
                    int iIdConsolidado = hiIdConsolidado;
                    string sPeriodo = textPeriodoVisualizar.Text.Trim();
                    int iIdConsolidadoComparar = hiIdComparativo == 0 ? hiIdConsolidado : hiIdComparativo;
                    string sPeriodoComparar = "";
                    if (hiIdComparativo != 0)
                    {
                        sPeriodoComparar = textPeriodoVisualizarComparar.Text;
                    }
                    else
                    {
                        if (hiReporte == (int)CFG.Reporte.esf || hiReporte == (int)CFG.Reporte.esfSuper)
                        {
                            int iPaso = int.Parse(textPeriodoVisualizar.Text) - 100;
                            sPeriodoComparar = iPaso.ToString().Substring(0, 4) + "12";
                        }
                        else
                        {
                            int iPaso = int.Parse(textPeriodoVisualizar.Text) - 100;
                            sPeriodoComparar = iPaso.ToString();
                        }
                    }
                    //
                    //
                    string sLibros = NewConsolidado.Properties.Settings.Default.usrLibrosReporte;
                    //
                    string sTexto = "Valores a Enviar ";
                    sTexto += " idConsolidado {" + iIdConsolidado.ToString() + "}";
                    sTexto += " Periodo {" + sPeriodo + "}";
                    sTexto += " idCoinsolidadoComparar {" + iIdConsolidadoComparar.ToString() + "}";
                    sTexto += " PeriodoComparar {" + sPeriodoComparar + "}";
                    sTexto += " Libros {" + NewConsolidado.Properties.Settings.Default.usrLibrosReporte + "}";
                    hLog.Debug(sTexto);
                    //
                    switch (hiReporte)
                    {
                        case (int)CFG.Reporte.esf:
                            {
                                EstadoSituacion oRptESF = new EstadoSituacion();
                                oRptESF.IdConsolidado = iIdConsolidado;
                                oRptESF.Periodo = sPeriodo;
                                oRptESF.IdConsolidadoComparar = iIdConsolidadoComparar;
                                oRptESF.PeriodoComparar = sPeriodoComparar;
                                oRptESF.Libro = sLibros;
                                oRptESF.StartPosition = FormStartPosition.CenterParent;
                                oRptESF.WindowState = FormWindowState.Maximized;

                                oRptESF.ShowDialog(this);
                                break;
                            }
                        case (int)CFG.Reporte.esfSuper:
                            {
                                EstadoSituacionSuper oRptESF = new EstadoSituacionSuper();
                                oRptESF.IdConsolidado = iIdConsolidado;
                                oRptESF.Periodo = sPeriodo;
                                oRptESF.IdConsolidadoComparar = iIdConsolidadoComparar;
                                oRptESF.PeriodoComparar = sPeriodoComparar;
                                oRptESF.Libro = sLibros;
                                oRptESF.StartPosition = FormStartPosition.CenterParent;
                                oRptESF.WindowState = FormWindowState.Maximized;

                                oRptESF.ShowDialog(this);
                                break;
                            }
                        case (int)CFG.Reporte.erf:
                            {
                                EstadoResultado oRptERF = new EstadoResultado();
                                oRptERF.IdConsolidado = iIdConsolidado;
                                oRptERF.Periodo = sPeriodo;
                                oRptERF.IdConsolidadoComparar = iIdConsolidadoComparar;
                                oRptERF.PeriodoComparar = sPeriodoComparar;
                                oRptERF.Libro = sLibros;
                                oRptERF.StartPosition = FormStartPosition.CenterParent;
                                oRptERF.WindowState = FormWindowState.Maximized;

                                oRptERF.ShowDialog(this);
                                break;
                            }
                        case (int)CFG.Reporte.erfSuper:
                            {
                                EstadoResultadoSuper oRptERF = new EstadoResultadoSuper();
                                oRptERF.IdConsolidado = iIdConsolidado;
                                oRptERF.Periodo = sPeriodo;
                                oRptERF.IdConsolidadoComparar = iIdConsolidadoComparar;
                                oRptERF.PeriodoComparar = sPeriodoComparar;
                                oRptERF.Libro = sLibros;
                                oRptERF.StartPosition = FormStartPosition.CenterParent;
                                oRptERF.WindowState = FormWindowState.Maximized;

                                oRptERF.ShowDialog(this);
                                break;
                            }
                        default:
                            {
                                hLog.Fatal("Mala clasificacion al {VisualizaReporte}");
                                throw new SystemException("Mala clasificacion al {VisualizaReporte}");

                            }
                    }
                    this.Cursor = Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                hLog.msgFatal(ex.Message);
            }
            this.Cursor = Cursors.Default;
        }

        private Boolean ValidarCampos()
        {
            if (textPeriodoVisualizar.Text == "")
            {
                hLog.msgError("Debe seleccionar un periodo de visualización");
                textPeriodoVisualizar.SelectAll();
                textPeriodoVisualizar.Focus();
                return false;
            }
            //
            int iPI = int.Parse(textPeriodoInicio.Text);
            int iPV = 0;
            //
            if (!int.TryParse(textPeriodoVisualizar.Text, out iPV))
            {
                hLog.msgError("Debe seleccionar un periodo valido de visualización");
                textPeriodoVisualizar.SelectAll();
                textPeriodoVisualizar.Focus();
                return false;
            }
            if (textPeriodoTermino.Text == "")
            {
                if (!(iPV >= iPI))
                {
                    hLog.msgError("El periodo de visualización debe ser mayor o Igual al de Inicio");
                    textPeriodoVisualizar.SelectAll();
                    textPeriodoVisualizar.Focus();
                    return false;
                }
            }
            else
            {
                int iPT = int.Parse(textPeriodoTermino.Text);
                if (!(iPV >= iPI && iPV <= iPT))
                {
                    hLog.msgError("El periodo de visualización debe estar dentro el periodo");
                    textPeriodoVisualizar.SelectAll();
                    textPeriodoVisualizar.Focus();
                    return false;
                }
            }
            // Validar si es que selecciona otro consolidado
            if (hiIdComparativo > 0)
            {
                if (textPeriodoVisualizarComparar.Text == "")
                {
                    hLog.msgError("Debe seleccionar un periodo de visualización");
                    textPeriodoVisualizarComparar.SelectAll();
                    textPeriodoVisualizarComparar.Focus();
                    return false;
                }
                //
                int iPIC = int.Parse(textPeriodoInicioComparar.Text);
                int iPVC = 0;
                //
                if (!int.TryParse(textPeriodoVisualizarComparar.Text, out iPVC))
                {
                    hLog.msgError("Debe seleccionar un periodo valido de visualización");
                    textPeriodoVisualizarComparar.SelectAll();
                    textPeriodoVisualizarComparar.Focus();
                    return false;
                }
                if (textPeriodoTerminoComparar.Text == "")
                {
                    if (!(iPVC >= iPIC))
                    {
                        hLog.msgError("El periodo de visualización debe ser mayor o Igual al de Inicio");
                        textPeriodoVisualizarComparar.SelectAll();
                        textPeriodoVisualizarComparar.Focus();
                        return false;
                    }
                }
                else
                {
                    int iPTC = int.Parse(textPeriodoTerminoComparar.Text);
                    if (!(iPVC >= iPIC && iPVC <= iPTC))
                    {
                        hLog.msgError("El periodo de visualización debe estar dentro el periodo");
                        textPeriodoVisualizarComparar.SelectAll();
                        textPeriodoVisualizarComparar.Focus();
                        return false;
                    }
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(textPeriodoVisualizarComparar.Text))
                {
                    hLog.msgError("Debe seleccionar un consolidado para comparar si desea ingresar periodo a visualizar");
                    textPeriodoVisualizarComparar.SelectAll();
                    textPeriodoVisualizarComparar.Focus();
                    return false;
                }
            }
            return true;
        }

        private void BuscaConsolidadosComparar()
        {
            try
            {
                MantenedorConsolidados_ConsultaArbolConsolidados oForm = new MantenedorConsolidados_ConsultaArbolConsolidados();
                oForm.StartPosition = FormStartPosition.CenterParent;
                oForm.ShowIcon = false;
                oForm.ShowInTaskbar = false;
                if (oForm.ShowDialog(this) == DialogResult.OK)
                {
                    hiIdComparativo = oForm.CodigoRegistro;
                    //
                    BOConsolidados oBO = new BOConsolidados();
                    DTOConsolidados oDTO = new DTOConsolidados();
                    //
                    oDTO = oBO.ConsultaConsolidado(hiIdComparativo);
                    textCodigoConsolidadoComparar.Text = oDTO.Codigo;
                    laDescripcionConsolidadoComparar.Text = oDTO.Descripcion;
                    textPeriodoInicioComparar.Text = oDTO.PeriodoInicio;
                    textPeriodoTerminoComparar.Text = oDTO.PeriodoTermino;
                    textPeriodoVisualizarComparar.Text = "";
                }
            }
            catch (Exception ex)
            {
                hLog.msgFatal("Error al ejecutar la accion " + Environment.NewLine + ex.Message);
            }
        }

        private void BotonLimpiarCampos()
        {
            hiIdComparativo = 0;
            textCodigoConsolidadoComparar.Text = "";
            laDescripcionConsolidadoComparar.Text = "";
            textPeriodoInicioComparar.Text = "";
            textPeriodoTerminoComparar.Text = "";
            textPeriodoVisualizarComparar.Text = "";
        }

        private void TextoPeriodoVisualizar()
        {
            try
            {
                if (textPeriodoVisualizar.Text.Length == 6)
                {
                    BOConfiguracionComparativos oBO = new BOConfiguracionComparativos();
                    List<DTOConfiguracionComparativos> lDTOC = new List<DTOConfiguracionComparativos>();
                    lDTOC = oBO.ConsultaComparativos(hiIdConsolidado, hiSet, textPeriodoVisualizar.Text);
                    if (lDTOC.Count > 0)
                    {
                        BOConsolidados oBOC = new BOConsolidados();
                        DTOConsolidados oDTOC = new DTOConsolidados();
                        oDTOC = oBOC.ConsultaConsolidado(lDTOC[0].IdComparativo);
                        textCodigoConsolidadoComparar.Text = oDTOC.Codigo;
                        laDescripcionConsolidadoComparar.Text = oDTOC.Descripcion;
                        textPeriodoInicioComparar.Text = oDTOC.PeriodoInicio;
                        textPeriodoTerminoComparar.Text = oDTOC.PeriodoTermino;
                        textPeriodoVisualizarComparar.Text = lDTOC[0].PeriodoComparativo;
                        hiIdComparativo = lDTOC[0].IdComparativo;
                        hsPeriodoComparativo = lDTOC[0].PeriodoComparativo;
                    }
                }
                else
                {
                    BotonLimpiarCampos();
                    hsPeriodoComparativo = "";
                }
            }
            catch (Exception ex)
            {
                hLog.msgFatal("Error al ejecutar la accion " + Environment.NewLine + ex.Message);
            }
        }

        private void SincronizarODBC()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                if (textPeriodoVisualizar.Text.Length == 6)
                {

                    string sLibros = NewConsolidado.Properties.Settings.Default.usrLibrosReporte;
                    BOSincronizacionODBC oBO = new BOSincronizacionODBC();
                    oBO.SincronizarODBC(hiSet, hiIdConsolidado, textPeriodoVisualizar.Text, sLibros, Globales.UsuarioActivo);
                }
                else
                {
                    hLog.msgError("Deb ingresar un periodo para la sincronización");
                    textPeriodoVisualizar.SelectAll();
                    textPeriodoVisualizar.Focus();
                }
            }
            catch (Exception ex)
            {
                hLog.msgFatal("Error al ejecutar la accion " + Environment.NewLine + ex.Message);
            }
            this.Cursor = Cursors.Default;
        }
    }
}
