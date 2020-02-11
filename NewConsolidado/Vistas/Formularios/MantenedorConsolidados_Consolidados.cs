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
	public partial class MantenedorConsolidados_Consolidados : Form
	{
		private MyLog4Net hLog = new MyLog4Net("MantenedorConsolidados_Consolidados.Form");
		private int hiAccion = (int)CFG.ToolAcciones.Nada;
		private int hiCodigoRegistro = -1;
		private string hsIdCodigo = "";
		private string hsDescripcionPadre = "";
		private int hiCodigoPadre = -1;
		private int hiTipoPadre = -1;
		private int hiCodigoReferencia = 0;

		private DTOConsolidados hoDTO = new DTOConsolidados();

		public MantenedorConsolidados_Consolidados()
		{
			InitializeComponent();
			ConfiguracionFormulario();
		}
		private void MantenedorConsolidados_Consolidados_Load(object sender, EventArgs e)
		{
			CargaDatosFormulario();
		}
		private void buttonGrabar_Click(object sender, EventArgs e)
		{
			BotonAceptar();
		}
		private void buttonSalir_Click(object sender, EventArgs e)
		{
			this.Close();
		}
		private void buttonBuscar_Click(object sender, EventArgs e)
		{
			ConsultaArbolConsoliados();
		}
		private void textConsolidadoCodigo_KeyPress(object sender, KeyPressEventArgs e)
		{

		}
		private void textConsolidadoCodigo_KeyUp(object sender, KeyEventArgs e)
		{
		}
		private void textConsolidadoCodigo_KeyDown(object sender, KeyEventArgs e)
		{

		}

		private void textConsolidadoCodigo_TextChanged(object sender, EventArgs e)
		{
			PresionaTeclaCodigo(textConsolidadoCodigo.Text);
		}

		private void buttonLimpiar_Click(object sender, EventArgs e)
		{
			BotonLimpiar();
		}
		private void buttonReferencias_Click_1(object sender, EventArgs e)
		{
			BotonMuestraReferencias();
		}
		private void button1_Click(object sender, EventArgs e)
		{
			BotonMuestraComparativos();
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
		public int TipoPadre
		{
			get { return hiTipoPadre; }
			set { hiTipoPadre = value; }
		}
		//------------------------------------------------------------------------------------------------------------------
		//		Metodos privados
		//------------------------------------------------------------------------------------------------------------------
		private void ConfiguracionFormulario()
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
			buttonLimpiar.Image = global::NewConsolidado.Properties.Resources.rsc_16_ClearLeft;
			//
			this.AcceptButton = buttonGrabar;
			this.CancelButton = buttonSalir;

			textDescripcionPadre.TabIndex = 0;
			textConsolidadoCodigo.TabIndex = 1;
			textConsolidadoDescripcion.TabIndex = 2;
			textConsolidadoObservaciones.TabIndex = 3;
			textConsolidadoPeriodoInicio.TabIndex = 4;
			textConsolidadoPeriodoTermino.TabIndex = 5;
			textConsolidadoParticipacion.TabIndex = 6;
			radioConsolidadoActivo.TabIndex = 7;
			radioConsolidadoInactivo.TabIndex = 8;
			radioConsolidadoAbierto.TabIndex = 9;
			radioConsolidadoBloqueado.TabIndex = 10;

			textConsolidadoCodigo.MaxLength = 18;
			textConsolidadoDescripcion.MaxLength = 100;
			textConsolidadoObservaciones.MaxLength = 2000;
			textConsolidadoPeriodoInicio.MaxLength = 6;
			textConsolidadoPeriodoTermino.MaxLength = 6;
			textConsolidadoParticipacion.MaxLength = 35;

			radioConsolidadoActivo.Checked = true;
			radioConsolidadoAbierto.Checked = true;

			labelMensajeReferencia.Visible = false;
			buttonReferencias.Visible = false;
			buttonComparativos.Visible = false;

			this.Height = 325;


			textConsolidadoCodigo.Focus();

		}
		private void CargaDatosFormulario()
		{
			BOConsolidados oBO = new BOConsolidados();
			string sPaso = "";

			textDescripcionPadre.Text = hsDescripcionPadre;

			if (hiTipoPadre == (int)CFG.TipoConsolidado.Agrupador)
			{
				textConsolidadoParticipacion.Enabled = false;
				textConsolidadoParticipacion.BackColor = Color.WhiteSmoke;
				buttonBuscar.Enabled = false;
			}

			if (hiAccion == (int)CFG.ToolAcciones.Nuevo)
			{
				this.Text = "Nuevo Consolidado";
				hLog.Debug("Nueva consolidado");
			}
			else
			{
				this.Text = "Editar Consolidado ";
				//
				hoDTO = oBO.ConsultaConsolidado(hiCodigoRegistro);
				hLog.Debug("Editar Consolidado {" + hoDTO.Codigo + "}");
				hiCodigoPadre = hoDTO.IdPadre;
				hiCodigoReferencia = hoDTO.CodigoReferenciado;
				//
				textConsolidadoCodigo.Text = hoDTO.Codigo;
				textConsolidadoDescripcion.Text = hoDTO.Descripcion;
				textConsolidadoObservaciones.Text = hoDTO.Observaciones;
				textConsolidadoPeriodoInicio.Text = hoDTO.PeriodoInicio;
				textConsolidadoPeriodoTermino.Text = hoDTO.PeriodoTermino;
				if (hiTipoPadre == (int)CFG.TipoConsolidado.Consolidado)
				{
					textConsolidadoParticipacion.Text = hoDTO.PorcentajeParticipacion.ToString(CFG.sFormatDisplayDecimal);
				}
				radioConsolidadoActivo.Checked = (hoDTO.Estado == (int)CFG.EstadoConsolidado.Activo) ? true : false;
                radioConsolidadoInactivo.Checked = (hoDTO.Estado == (int)CFG.EstadoConsolidado.Activo) ? false : true;

                radioConsolidadoAbierto.Checked = (hoDTO.Bloqueo == (int)CFG.BloqueoConsolidado.Abierto ? true : false);
                radioConsolidadoBloqueado.Checked = (hoDTO.Bloqueo == (int)CFG.BloqueoConsolidado.Abierto ? false : true);

				//
				if (hoDTO.CodigoReferenciado > 0)
				{
					buttonBuscar.Enabled = false;
					buttonLimpiar.Enabled = false;
					cambiaObjetos(false);
				}
				labelMensajeReferencia.Text = "";
				// Verificamos si es referenciado en otros nodos
				if (oBO.EsRefereciado(hoDTO.IdRegistro))
				{
					labelMensajeReferencia.Text = "Este Consolidado se utiliza como referencia en otras consolidaciones";
					sPaso = " " + Environment.NewLine;
					labelMensajeReferencia.Visible = true;
					buttonReferencias.Visible = true;
					this.Height = 462;
				}
				// Verificamos si es Comparativo en otros nodos
				if (oBO.EsComparativo(hoDTO.IdRegistro))
				{
					labelMensajeReferencia.Text += sPaso + "Este Consolidado se utiliza como comparativo en otras consolidaciones";
					labelMensajeReferencia.Visible = true;
					buttonComparativos.Visible = true;
					this.Height = 462;
				}

				textConsolidadoCodigo.SelectAll();
				textConsolidadoCodigo.Focus();
			}
		}
		private void BotonAceptar()
		{
			if (ValidarDatos())
			{
				hoDTO.Codigo = textConsolidadoCodigo.Text;
				hoDTO.Descripcion = textConsolidadoDescripcion.Text;
				hoDTO.Observaciones = textConsolidadoObservaciones.Text;
				hoDTO.PeriodoInicio = textConsolidadoPeriodoInicio.Text;
				hoDTO.PeriodoTermino = textConsolidadoPeriodoTermino.Text;
				hoDTO.Estado = (radioConsolidadoActivo.Checked ? (int)CFG.EstadoConsolidado.Activo : (int)CFG.EstadoConsolidado.Inactivo);
				hoDTO.Bloqueo = (radioConsolidadoBloqueado.Checked ? (int)CFG.BloqueoConsolidado.Bloqueado : (int)CFG.BloqueoConsolidado.Abierto);
				hoDTO.RefenciaConsolidado = hiCodigoReferencia > 0 ? (int)CFG.Referenciado.Si : (int)CFG.Referenciado.No;
				hoDTO.CodigoReferenciado = hiCodigoReferencia;
				if (hiTipoPadre == (int)CFG.TipoConsolidado.Consolidado)
				{
					hoDTO.PorcentajeParticipacion = decimal.Parse(textConsolidadoParticipacion.Text);
				}
				hoDTO.IndicadorMatriz = (int)CFG.IndicadorMatriz.No;
				if (hiAccion == (int)CFG.ToolAcciones.Nuevo)
				{
					hoDTO.IdCodigo = DateTime.Now.Ticks.ToString();
					hoDTO.IdPadre = hiCodigoPadre;
					hoDTO.TipoNodo = (int)CFG.TipoConsolidado.Consolidado;
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

			if (textConsolidadoCodigo.Text == "")
			{
				hLog.msgError("Debe ingresar un codigo para el consolidado");
				textConsolidadoCodigo.SelectAll();
				textConsolidadoCodigo.Focus();
				return false;
			}
			if (textConsolidadoDescripcion.Text == "")
			{
				hLog.msgError("Debe ingresar una descripcion para el consolidado");
				textConsolidadoDescripcion.SelectAll();
				textConsolidadoDescripcion.Focus();
				return false;
			}
			if (textConsolidadoPeriodoInicio.Text == "")
			{
				hLog.msgError("Debe ingresar el Periodo de inicio para el consolidado");
				textConsolidadoPeriodoInicio.SelectAll();
				textConsolidadoPeriodoInicio.Focus();
				return false;
			}
			if (textConsolidadoPeriodoInicio.Text != "")
			{
				if (textConsolidadoPeriodoInicio.Text.Length == 6)
				{
					string cadena = textConsolidadoPeriodoInicio.Text.Substring(4, 2);
					if (Convert.ToInt32(cadena) < 1 || Convert.ToInt32(cadena) > 12)
					{
						hLog.msgError("Debe ingresar un periodo valido");
						textConsolidadoPeriodoInicio.SelectAll();
						textConsolidadoPeriodoInicio.Focus();
						return false;
					}
				}
				else
				{
					hLog.msgError("Debe ingresar un periodo valido");
					textConsolidadoPeriodoInicio.SelectAll();
					textConsolidadoPeriodoInicio.Focus();
					return false;
				}
			}
			if (textConsolidadoPeriodoTermino.Text != "")
			{
				if (textConsolidadoPeriodoTermino.Text.Length == 6)
				{
					string cadena = textConsolidadoPeriodoTermino.Text.Substring(4, 2);
					if (Convert.ToInt32(cadena) < 1 || Convert.ToInt32(cadena) > 12)
					{
						hLog.msgError("Debe ingresar un periodo valido");
						textConsolidadoPeriodoTermino.SelectAll();
						textConsolidadoPeriodoTermino.Focus();
						return false;
					}
				}
				else
				{
					hLog.msgError("Debe ingresar un periodo valido");
					textConsolidadoPeriodoTermino.SelectAll();
					textConsolidadoPeriodoTermino.Focus();
					return false;
				}
			}
			if (textConsolidadoPeriodoInicio.Text != "" && textConsolidadoPeriodoTermino.Text != "")
			{
				if (Convert.ToInt32(textConsolidadoPeriodoInicio.Text) > Convert.ToInt32(textConsolidadoPeriodoTermino.Text))
				{
					hLog.msgError("Debe ingresar un periodo de termino valido");
					textConsolidadoPeriodoTermino.SelectAll();
					textConsolidadoPeriodoTermino.Focus();
					return false;
				}
			}
			if (hiTipoPadre == (int)CFG.TipoConsolidado.Consolidado)
			{
				if (textConsolidadoParticipacion.Text == "")
				{
					hLog.msgError("Debe ingresar el porcentaje de participación para el consolidado");
					textConsolidadoParticipacion.SelectAll();
					textConsolidadoParticipacion.Focus();
					return false;
				}
				decimal dParticipa = 0;
				string sSep = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator;
				textConsolidadoParticipacion.Text = textConsolidadoParticipacion.Text.Replace(".", sSep);
				if (!decimal.TryParse(textConsolidadoParticipacion.Text.ToString(), out dParticipa))
				{
					hLog.msgError("Debe ingresar solo numeros en el porcentaje de participación para el Consolidado");
					textConsolidadoParticipacion.SelectAll();
					textConsolidadoParticipacion.Focus();
					return false;
				}
				if (!(dParticipa >= 0  && dParticipa <= 100))
				{
					hLog.msgError("Debe ingresar un porcentaje de participación valido para el Consolidado");
					textConsolidadoParticipacion.SelectAll();
					textConsolidadoParticipacion.Focus();
					return false;
				}
			}

			return true;
		}

		private void ConsultaArbolConsoliados()
		{
			MantenedorConsolidados_ConsultaArbolConsolidados oForm = new MantenedorConsolidados_ConsultaArbolConsolidados();
			oForm.StartPosition = FormStartPosition.CenterParent;
			oForm.ShowIcon = false;
			oForm.ShowInTaskbar = false;
			if (oForm.ShowDialog(this) == DialogResult.OK)
			{
				hiCodigoReferencia  = oForm.CodigoRegistro;
				//MessageBox.Show("hola" + hiCodigoReferencia.ToString() );
				BOConsolidados oBO = new BOConsolidados();
				DTOConsolidados oDTO = new DTOConsolidados();
				//
				oDTO = oBO.ConsultaConsolidado(hiCodigoReferencia);
				//				
				//hiCodigoPadre = oDTO.IdPadre;
				textConsolidadoCodigo.Text = oDTO.Codigo;
				textConsolidadoDescripcion.Text = oDTO.Descripcion;
				textConsolidadoObservaciones.Text = oDTO.Observaciones;
				textConsolidadoPeriodoInicio.Text = oDTO.PeriodoInicio;
				textConsolidadoPeriodoTermino.Text = oDTO.PeriodoTermino;
				radioConsolidadoActivo.Checked = oDTO.Estado == (int)CFG.EstadoConsolidado.Activo ? true:false;
				radioConsolidadoBloqueado.Checked = oDTO.Bloqueo == (int)CFG.BloqueoConsolidado.Bloqueado ? true:false;
				//textConsolidadoParticipacion.Text = hoDTO.PorcentajeParticipacion.ToString();

				cambiaObjetos(false);
			}
		}

		private void PresionaTeclaCodigo(string sTexto)
		{

		}

		private void cambiaObjetos(Boolean bEstado)
		{
			textConsolidadoCodigo.Enabled = bEstado;
			textConsolidadoDescripcion.Enabled = bEstado;
			textConsolidadoObservaciones.Enabled = bEstado;
			textConsolidadoPeriodoInicio.Enabled = bEstado;
			textConsolidadoPeriodoTermino.Enabled = bEstado;
			radioConsolidadoActivo.Enabled = bEstado;
			radioConsolidadoInactivo.Enabled = bEstado;
			radioConsolidadoBloqueado.Enabled = bEstado;
			radioConsolidadoAbierto.Enabled = bEstado;
			if (hiTipoPadre == (int)CFG.TipoConsolidado.Agrupador)
			{
				textConsolidadoParticipacion.Enabled = bEstado;
			}
		}

		private void BotonLimpiar()
		{
			cambiaObjetos(true);

			hiCodigoReferencia = 0;
			textConsolidadoCodigo.Text = "";
			textConsolidadoDescripcion.Text = "";
			textConsolidadoObservaciones.Text = "";
			textConsolidadoPeriodoInicio.Text = "";
			textConsolidadoPeriodoTermino.Text = "";
			radioConsolidadoActivo.Checked= true;
			//radioConsolidadoInactivo.Enabled = bEstado;
			//radioConsolidadoBloqueado.Enabled = bEstado;
			radioConsolidadoAbierto.Checked = true;
			textConsolidadoParticipacion.Text = "";
			//if (hiTipoPadre == (int)CFG.TipoConsolidado.Agrupador)
			//{
			//  textConsolidadoParticipacion.Enabled = bEstado;
			//}
		}
		private void BotonMuestraReferencias()
		{
			this.Cursor = Cursors.WaitCursor;
			hLog.Debug("Levanta ventana con arbol de referencias del consolidado");
			MantenedorConsolidados_ConsultaReferencias oForm = new MantenedorConsolidados_ConsultaReferencias();
			oForm.CodigoRegistro = hiCodigoRegistro;
			oForm.StartPosition = FormStartPosition.CenterParent;
			oForm.ShowIcon = false;
			oForm.ShowInTaskbar = false;
			oForm.ShowDialog(this);
			this.Cursor = Cursors.Default;
		}
		private void BotonMuestraComparativos()
		{
			this.Cursor = Cursors.WaitCursor;
			hLog.Debug("Levanta ventana con arbol de referencias del consolidado");
			MantenedorConsolidados_ConsultaComparativos oForm = new MantenedorConsolidados_ConsultaComparativos();
			oForm.CodigoRegistro = hiCodigoRegistro;
			oForm.StartPosition = FormStartPosition.CenterParent;
			oForm.ShowIcon = false;
			oForm.ShowInTaskbar = false;
			oForm.ShowDialog(this);
			this.Cursor = Cursors.Default;
		}		
	}
}
