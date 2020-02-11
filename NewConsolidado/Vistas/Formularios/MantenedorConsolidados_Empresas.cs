using System;
using System.Collections.Generic;
using System.Windows.Forms;

using NewConsolidado.Controladores.Clases;
using NewConsolidado.Controladores.ControladorNegocio;
using NewConsolidado.Modelos.TransporteDatos;

namespace NewConsolidado.Vistas.Formularios
{
	public partial class MantenedorConsolidados_Empresas : Form
	{
		private MyLog4Net hLog = new MyLog4Net("MantenedorConsolidados_Empresas.Form");
		private int hiAccion = (int)CFG.ToolAcciones.Nada;
		private int hiCodigoRegistro = -1;
		private int hiCodigoPadre = -1;
		private string hsIdCodigo = "";
		private string hsDescripcionPadre = "";
		private DTOConsolidados hoDTO = new DTOConsolidados();

		public MantenedorConsolidados_Empresas()
		{
			InitializeComponent();
			ConfigurarFormulario();
		}
		private void MantenedorConsolidados_Empresas_Load(object sender, EventArgs e)
		{
			CargaDatosFormulario();
		}
		private void buttonBuscarEmpresa_Click(object sender, EventArgs e)
		{
			BotonBuscarEmpresa();
		}
		private void textEmpresaCodigo_KeyUp(object sender, KeyEventArgs e)
		{
			CampoTextoEmpresaCodigo();
		}
		private void buttonGrabar_Click(object sender, EventArgs e)
		{
			BotonAceptar();
		}
		private void buttonSalir_Click(object sender, EventArgs e)
		{
			BotonSalir();
		}
		//------------------------------------------------------------------------------------------------------------------
		//		Accesos
		//------------------------------------------------------------------------------------------------------------------
		public int Accion
		{
			get { return hiAccion; }
			set { hiAccion = value; }
		}
		public int CodigoRegistro
		{
			get { return hiCodigoRegistro; }
			set { hiCodigoRegistro = value; }
		}
		public int CodigoPadre
		{
			get { return hiCodigoPadre; }
			set { hiCodigoPadre = value; }
		}
		public string IdCodigo
		{
			get { return hsIdCodigo; }
			set { hsIdCodigo = value; }
		}
		public string DescripcionPadre
		{
			get { return hsDescripcionPadre; }
			set { hsDescripcionPadre = value; }
		}
		//------------------------------------------------------------------------------------------------------------------
		//		Metodos privados
		//------------------------------------------------------------------------------------------------------------------
		private void ConfigurarFormulario()
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
			//
			textEmpresaCodigo.MaxLength = 10;
			textEmpresaDescripcion.MaxLength = 100;
			textEmpesaObservaciones.MaxLength = 2000;
			textEmpresaParticipacion.MaxLength = 35;
			//
			this.AcceptButton = buttonGrabar;
			this.CancelButton = buttonSalir;

			textDescripcionPadre.TabIndex = 0;
			textEmpresaCodigo.TabIndex = 1;
			textEmpresaDescripcion.TabIndex = 2;
			textEmpesaObservaciones.TabIndex = 3;
			textEmpresaParticipacion.TabIndex = 4;
			checkEmpresaMatriz.TabIndex = 5;

			textEmpresaCodigo.Focus();
		}
		private void CargaDatosFormulario()
		{
			textDescripcionPadre.Text = hsDescripcionPadre;

			if (hiAccion == (int)CFG.ToolAcciones.Nuevo)
			{
				this.Text = "Nueva empresa";
				hLog.Debug("Nueva empresa");
			}
			else
			{
				this.Text = "Editar empresa ";
				BOConsolidados oBO = new BOConsolidados();
				hoDTO = oBO.ConsultaConsolidado(hiCodigoRegistro);
				hLog.Debug("Editar empresa {" + hoDTO.Codigo + "}");
				hiCodigoPadre = hoDTO.IdPadre;
				textEmpresaCodigo.Text = hoDTO.Codigo;
				textEmpresaDescripcion.Text = hoDTO.Descripcion;
				textEmpesaObservaciones.Text = hoDTO.Observaciones;
				textEmpresaParticipacion.Text = hoDTO.PorcentajeParticipacion.ToString(CFG.sFormatDisplayDecimal);
				checkEmpresaMatriz.Checked = (hoDTO.IndicadorMatriz == (int)CFG.IndicadorMatriz.Si ? true : false);
			}
		}
		private void BotonBuscarEmpresa()
		{
			ConsultaCompanias oForm = new ConsultaCompanias();
			oForm.StartPosition = FormStartPosition.CenterScreen;
			oForm.ShowIcon = false;
			oForm.ShowInTaskbar = false;
			if (oForm.ShowDialog(this) == DialogResult.OK)
			{
				textEmpresaCodigo.Text = oForm.IdCompania;
				textEmpresaDescripcion.Text = oForm.Nombre;
			}
		}
		private void CampoTextoEmpresaCodigo()
		{
			List<DTOCompanias> lDTO = new List<DTOCompanias>();
			BOCompanias BOC = new BOCompanias();
			lDTO = BOC.ConsultaCompanias(textEmpresaCodigo.Text);
			if (lDTO.Count > 0)
			{
				textEmpresaDescripcion.Text = lDTO[0].Nombre;
			}
			else
			{
				textEmpresaDescripcion.Text = "";
			}
		}
		private void BotonAceptar()
		{
			if (ValidarDatos())
			{
				hoDTO.Codigo = textEmpresaCodigo.Text;
				hoDTO.Descripcion = textEmpresaDescripcion.Text;
				hoDTO.Observaciones = textEmpesaObservaciones.Text;
				hoDTO.PorcentajeParticipacion = decimal.Parse(textEmpresaParticipacion.Text);
				hoDTO.IndicadorMatriz = (checkEmpresaMatriz.Checked ? (int)CFG.IndicadorMatriz.Si : (int)CFG.IndicadorMatriz.No);
				if (hiAccion == (int)CFG.ToolAcciones.Nuevo)
				{
					hoDTO.IdCodigo = DateTime.Now.Ticks.ToString();
					hoDTO.IdPadre = hiCodigoPadre;
					hoDTO.TipoNodo = (int)CFG.TipoConsolidado.Empresa;
					hoDTO.Owner = Globales.UsuarioActivo;
					hoDTO.FechaCreacion = DateTime.Now;
					hoDTO.FechaModificacion = DateTime.Now;
				}
				else
				{
					hoDTO.IdRegistro = this.hiCodigoRegistro;
					hoDTO.FechaModificacion = DateTime.Now;
				}
				// Grabamos los datos
				BOConsolidados oBo = new BOConsolidados();
				oBo.GrabarDatosConsolidado(hiAccion, hoDTO);
				// Asginamos el valor de la empresa nueva para poder tomarlo en la ventana de mantenedor
				this.IdCodigo = hoDTO.IdCodigo;
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
		}
		private Boolean ValidarDatos()
		{
			if (textEmpresaCodigo.Text == "")
			{
				hLog.msgError("Debe ingresar un codigo de empresa valido");
				textEmpresaCodigo.SelectAll();
				textEmpresaCodigo.Focus();
				return false;
			}
			if (textEmpresaDescripcion.Text == "")
			{
				hLog.msgError("Debe ingresar un codigo de empresa valido");
				textEmpresaCodigo.SelectAll();
				textEmpresaCodigo.Focus();
				return false;
			}
			if (textEmpresaParticipacion.Text == "")
			{
				hLog.msgError("Debe ingresar un porcentaje de participacion para la empresa");
				textEmpresaParticipacion.SelectAll();
				textEmpresaParticipacion.Focus();
				return false;
			}
			decimal dParticipa;
			string sSep = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator;
			textEmpresaParticipacion.Text = textEmpresaParticipacion.Text.Replace(".", sSep);
			if (!decimal.TryParse(textEmpresaParticipacion.Text.ToString(), out dParticipa))
			{
				hLog.msgError("Debe ingresar solo numeros en el porcentaje de participación para la Empresa");
				textEmpresaParticipacion.SelectAll();
				textEmpresaParticipacion.Focus();
				return false;
			}
			if (dParticipa <= 0 || dParticipa > 100)
			{
				hLog.msgError("Debe ingresar un porcentaje de participación valido para la empresa");
				textEmpresaParticipacion.SelectAll();
				textEmpresaParticipacion.Focus();
				return false;
			}
			if (checkEmpresaMatriz.CheckState == CheckState.Checked)
			{
				if (ValidaExisteMatriz())
				{
					hLog.msgError("Solo puede existir una matriz en el consolidado");
					checkEmpresaMatriz.ThreeState = true;
					checkEmpresaMatriz.CheckState = CheckState.Indeterminate;
					checkEmpresaMatriz.Focus();
					return false;
				}
			}
			if (checkEmpresaMatriz.CheckState != CheckState.Checked)
			{
				if (!ValidaExisteMatriz())
				{
					hLog.msgError("Debe seleccionar alguna de las empresas como matriz para el consolidado");
					//checkEmpresaMatriz.ThreeState = true;
					//checkEmpresaMatriz.CheckState = CheckState.Indeterminate;
					//checkEmpresaMatriz.Focus();
					//return false;
				}
			}
			return true;
		}
		private Boolean ValidaExisteMatriz()
		{
			bool bIndicador = false;
			List<DTOConsolidados> lDTO = new List<DTOConsolidados>();
			BOConsolidados oBO = new BOConsolidados();
			lDTO = oBO.ConsultaConsolidados(hiCodigoPadre);
			foreach( DTOConsolidados oDTO in lDTO )
			{
				if (oDTO.IndicadorMatriz == (int)CFG.IndicadorMatriz.Si && oDTO.IdRegistro != hiCodigoRegistro)
				{
					bIndicador = true;
				}
			}
			return bIndicador;
		}
		private void BotonSalir()
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}
	}
}
