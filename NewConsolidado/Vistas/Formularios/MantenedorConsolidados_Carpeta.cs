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
	public partial class MantenedorConsolidados_Carpeta : Form
	{
		private MyLog4Net hLog = new MyLog4Net("MantenedorConsolidados_Carpeta.Form");
		private int hiAccion = (int)CFG.ToolAcciones.Nada ;
		private int hiCodigoRegistro = -1;
		private int hiCodigoPadre = -1;
		private string hsDescripcionPadre = "";
		private string hsIdCodigo = "";
		private DTOConsolidados hoDTO = new DTOConsolidados();
	
		public MantenedorConsolidados_Carpeta()
		{
			InitializeComponent();

			ConfigurarFormulario();
		}
		private void MantenedorConsolidados_Carpeta_Load(object sender, EventArgs e)
		{
			CargaDatosFormulario();
		}
		private void buttonGrabar_Click(object sender, EventArgs e)
		{
			GrabarRegistro();
		}

		private void buttonSalir_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		//------------------------------------------------------------------------------------------------------------------
		//		Accesos
		//------------------------------------------------------------------------------------------------------------------
		public int Accion
		{
			get { return hiAccion;}
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
		public string DescripcionPadre
		{
			get { return hsDescripcionPadre; }
			set { hsDescripcionPadre = value; }
		}
		public string IdCodigo
		{
			get { return hsIdCodigo; }
			set { hsIdCodigo = value; }
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
			this.AcceptButton = buttonGrabar;
			this.CancelButton = buttonSalir;

		}
		private void CargaDatosFormulario()
		{
			textDescripcion.MaxLength = 18;

			textDescripcionPadre.Text = hsDescripcionPadre;
			if (hiAccion == (int)CFG.ToolAcciones.Editar)
			{

				BOConsolidados oBO = new BOConsolidados();
				hoDTO = oBO.ConsultaConsolidado(hiCodigoRegistro);
				if (hoDTO != null)
				{
					textDescripcion.Text = hoDTO.Codigo;
					textObservaciones.Text = hoDTO.Observaciones;
					this.Text = "Editar Carpeta [" + hoDTO.Codigo.ToString() + "]";

				}
				else
				{
					hLog.Fatal("Error al obtener los datos del nodo agrupador");
				}
			}
			else
			{
				this.Text = "Nueva Carpeta";
			}
		}
		private void GrabarRegistro()
		{
			try
			{
				if (ValidacionCampos())
				{
					hoDTO.Codigo = textDescripcion.Text;
					hoDTO.Descripcion = textDescripcion.Text;
					hoDTO.Observaciones = textObservaciones.Text;
					if (hiAccion == (int)CFG.ToolAcciones.Nuevo)
					{
						hoDTO.IdCodigo = DateTime.Now.Ticks.ToString();
						hoDTO.IdPadre = hiCodigoPadre;
						hoDTO.TipoNodo = (int)CFG.TipoConsolidado.Agrupador;
						hoDTO.IndicadorMatriz = (int)CFG.IndicadorMatriz.No;
						hoDTO.Owner = Globales.UsuarioActivo;
						hoDTO.FechaCreacion = DateTime.Now;
						hoDTO.FechaModificacion = DateTime.Now;
					}
					else
					{
						hoDTO.IdRegistro = this.hiCodigoRegistro;
						hoDTO.FechaModificacion = DateTime.Now;
					}
					//
					BOConsolidados oBO = new BOConsolidados();
					oBO.GrabarDatosConsolidado(hiAccion, hoDTO);
					//					
					this.IdCodigo = hoDTO.IdCodigo;
					this.DialogResult = DialogResult.OK;
					this.Close();
				}
			}
			catch (Exception ex)
			{
				hLog.msgError(ex.Message);
			}
		}
		private Boolean ValidacionCampos()
		{
			if (textDescripcion.Text.Trim() == "")
			{
				hLog.msgError("Debe ingresar una descripcion para la carpeta");
				textDescripcion.SelectAll();
				textDescripcion.Focus();
				return false;
			}

			return true;
		}
	}
}
