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
	public partial class MantenedorConsolidados_ConsultaArbolConsolidados : Form
	{
		private MyLog4Net hLog = new MyLog4Net("MantenedorConsolidados_ConsultaArbolConsolidados.Form");
		private int hiCodigoRegistro = -1;
		private List<DTOConsolidados> hlConsolidados = new List<DTOConsolidados>();
		private string hsPeriodoComparativo = "";
		private Boolean hbCompara = false;

		public MantenedorConsolidados_ConsultaArbolConsolidados()
		{
			InitializeComponent();
			ConfiguracionFormulario();
		}

		private void MantenedorConsolidados_ConsultaArbolConsolidados_Load(object sender, EventArgs e)
		{
			CargaFormulario();
		}

		private void buttonAceptar_Click(object sender, EventArgs e)
		{
			BotonAceptar();
		}

		private void buttonSalir_Click(object sender, EventArgs e)
		{
			BotonSalir();
		}

		private void MantenedorConsolidados_ConsultaArbolConsolidados_Shown(object sender, EventArgs e)
		{
			CargarArbolConsolidados();
		}

		private void treeConsolidados_AfterSelect(object sender, TreeViewEventArgs e)
		{
			SeleccionaNodo((TreeNode)e.Node);
		}

		//------------------------------------------------------------------------------------------------------------------
		//		Accesos
		//------------------------------------------------------------------------------------------------------------------
		public int CodigoRegistro
		{
			get { return hiCodigoRegistro; }
			set { hiCodigoRegistro = value; }
		}
		public Boolean Compara
		{
			get { return hbCompara; }
			set { hbCompara = value; }
		}
		public string PeriodoComparativo
		{
			get { return hsPeriodoComparativo; }
			set { hsPeriodoComparativo = value; }
		}
		//------------------------------------------------------------------------------------------------------------------
		// Metodos privados
		//------------------------------------------------------------------------------------------------------------------

		private void ConfiguracionFormulario()
		{
			this.Text = "Consulta al Arbol de Consolidados";

			buttonAceptar.Image = NewConsolidado.Properties.Resources.rsc_24_Grabar;
			buttonAceptar.Size = new System.Drawing.Size(CFG.buttonAncho, CFG.buttonAlto);
			buttonAceptar.Text = "Aceptar";
			buttonAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			buttonAceptar.UseVisualStyleBackColor = true;
			this.AcceptButton = buttonAceptar;
			//
			buttonSalir.Image = global::NewConsolidado.Properties.Resources.rsc_24_SalirForm;
			buttonSalir.Size = new System.Drawing.Size(CFG.buttonAncho, CFG.buttonAlto);
			buttonSalir.Text = "Salir";
			buttonSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			buttonSalir.UseVisualStyleBackColor = true;
			this.CancelButton = buttonSalir;

			labelConsolidadoCodigo.Text = "";
			labelConsolidadoDescripcion.Text = "";
			labelConsolidadoObservaciones.Text = "";
			labelConsolidadoPeriodoInicio.Text = "";
			labelConsolidadoParticipacion.Text = "";
			labelConsolidadoPeriodoTermino.Text = "";
			labelConsolidadoEstado.Text = "";
			labelConsolidadoSeguridad.Text = "";

			textPeriodoComparativo.MaxLength = 6;

		}
		private void CargaFormulario()
		{
			textPeriodoComparativo.Visible = hbCompara;
			labelPeriodoComparativo.Visible = hbCompara;

			this.Refresh();
		}

		private void CargarArbolConsolidados()
		{
			this.Cursor = Cursors.WaitCursor;
			try
			{
				this.Refresh();

				BOConsolidados oConsolidado = new BOConsolidados();
				hLog.Debug("Cargamos el arbol y cargamos el nodo raiz");
				hlConsolidados = oConsolidado.ConsultaConsolidados();

				// Nodo raiz
				treeConsolidados.Nodes.Clear();
				treeConsolidados.ShowNodeToolTips = true;
				treeConsolidados.ImageList = imageList1;
				treeConsolidados.ImageIndex = (int)CFG.TipoIconoArbol.Root;
				DTOConsolidados DTONull = new DTOConsolidados();
				DTONull.Codigo = CFG.nodoConsolidadoRaiz;
				DTONull.TipoNodo = (int)CFG.TipoConsolidado.Agrupador;
				DTONull.Descripcion = CFG.nodoConsolidadoRaiz;
				DTONull.IndicadorMatriz = (int)CFG.IndicadorMatriz.No;
				DTONull.RefenciaConsolidado = (int)CFG.Referenciado.No;
				//
				TreeNode nuevoNodo = new TreeNode();
				nuevoNodo.Text = DTONull.Descripcion;
				nuevoNodo.Tag = DTONull;
				nuevoNodo.SelectedImageIndex = (int)CFG.TipoIconoArbol.Root;
				treeConsolidados.Nodes.Add(nuevoNodo);
				//
				CargarArbolConsolidadosHijos(nuevoNodo);
				// Expandimos en arbol para que se vean todos los nodos
				nuevoNodo.Expand();
				// Dejamos posicionado el foco en el primer elemento del arbol
				treeConsolidados.Nodes[0].Checked = true;
				treeConsolidados.SelectedNode = treeConsolidados.Nodes[0];
				treeConsolidados.SelectedNode.EnsureVisible();
				treeConsolidados.Select();
				// contraeccion del arbol
				ContraerArbol();
			}
			catch (Exception Ex)
			{
				hLog.msgFatal("Error detectado \n{" + Ex.Message + "}");
			}
			this.Cursor = Cursors.Default;
		}

		private void CargarArbolConsolidadosHijos(TreeNode nNodoPadre)
		{
			List<DTOConsolidados> DTORecorre = new List<DTOConsolidados>();
			//
			DTOConsolidados DTONodo = new DTOConsolidados();
			DTONodo = (DTOConsolidados)nNodoPadre.Tag;
			// Analizamos nodo
			if (DTONodo.TipoNodo == (int)CFG.TipoConsolidado.Agrupador)
			{
				DTORecorre = BuscaConsolidadoList(DTONodo.IdRegistro);
			}
			foreach (DTOConsolidados oDTO in DTORecorre)
			{
				if (oDTO.TipoNodo != (int)CFG.TipoConsolidado.Empresa)
				{
					string sTexto = "Pintamos el nodo hijo {" + oDTO.IdRegistro + "} Glosa {" + oDTO.Descripcion + "}";
					sTexto += " Hijo de {" + oDTO.IdPadre + "}";
					hLog.Debug(sTexto);
					//
					TreeNode nuevoNodo = new TreeNode();
					nuevoNodo = AgregaNuevoNodo(oDTO, nNodoPadre);
					// Bajamos otro nivel
					CargarArbolConsolidadosHijos(nuevoNodo);
				}
			}
		}

		private void ContraerArbol()
		{
			TreeNode Raiz = treeConsolidados.Nodes[0];
			foreach (TreeNode nod in Raiz.Nodes)
			{
				hLog.Debug("Contraer nodo {" + nod.Text + "}");
				nod.Collapse();
			}
		}

		private TreeNode AgregaNuevoNodo(DTOConsolidados oDTO, TreeNode oNodoPadre)
		{
			hLog.Debug("metodo { AgregaNuevoNodo } { " + oDTO.Descripcion + " }");
			string sM = ""; string sR = "";
			//
			TreeNode nuevoNodo = new TreeNode();
			nuevoNodo.ForeColor = Color.Black;
			nuevoNodo.NodeFont = new Font("San Serif", 9, FontStyle.Regular);

			if (oDTO.IndicadorMatriz == (int)CFG.IndicadorMatriz.Si)
			{
				nuevoNodo.ForeColor = Color.IndianRed;
				nuevoNodo.NodeFont = new Font("Helvetica", 9, FontStyle.Bold);
				sM = "* ";
			}
			if (oDTO.RefenciaConsolidado == (int)CFG.Referenciado.Si)
			{
				nuevoNodo.ForeColor = Color.Maroon;
				nuevoNodo.NodeFont = new Font("Helvetica", 9, FontStyle.Bold);
				sR = "+ ";
			}
			nuevoNodo.Text = sM + sR + oDTO.Codigo;
			nuevoNodo.Tag = oDTO;
			nuevoNodo.ToolTipText = oDTO.Descripcion;
			nuevoNodo.ImageIndex = oDTO.TipoNodo;
			nuevoNodo.SelectedImageIndex = oDTO.TipoNodo;
			oNodoPadre.Nodes.Add(nuevoNodo);
			//
			return nuevoNodo;
		}

		private List<DTOConsolidados> BuscaConsolidadoList(int iIdRegistro)
		{
			hLog.Debug("Cargamos el arbol y buscamos {" + iIdRegistro.ToString() + "}");

			List<DTOConsolidados> lDTO = new List<DTOConsolidados>();
			lDTO = hlConsolidados.FindAll(delegate(DTOConsolidados lst)
			{ return lst.IdPadre == iIdRegistro; });
			return lDTO;
		}

		private void BotonAceptar()
		{
			DTOConsolidados oDTO = new DTOConsolidados();
			oDTO = (DTOConsolidados)treeConsolidados.SelectedNode.Tag;
			if (oDTO.TipoNodo == (int)CFG.TipoConsolidado.Consolidado)
			{
				if (textPeriodoComparativo.Visible)
				{
					if (textPeriodoComparativo.Text.Trim() == "")
					{
						hLog.msgError("Debe ingresar el periodo de comparación");
						textPeriodoComparativo.SelectAll();
						textPeriodoComparativo.Focus();
						return;
					}
					if (textPeriodoComparativo.Text.Length < 6)
					{
						hLog.msgError("Debe ingresar un periodo valido");
						textPeriodoComparativo.SelectAll();
						textPeriodoComparativo.Focus();
						return;
					}
					else
					{
						string cadena = textPeriodoComparativo.Text.Substring(4, 2);
						if (Convert.ToInt32(cadena) < 1 || Convert.ToInt32(cadena) > 12)
						{
							hLog.msgError("Debe ingresar un periodo valido");
							textPeriodoComparativo.SelectAll();
							textPeriodoComparativo.Focus();
							return;
						}
					}
				}

				hiCodigoRegistro = oDTO.IdRegistro;
				hsPeriodoComparativo = textPeriodoComparativo.Text.Trim();
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
			else
			{
				hLog.msgError("Debe seleccionar un consolidado");
			}
		}

		private void BotonSalir()
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		private void SeleccionaNodo(TreeNode e)
		{
			this.Cursor = Cursors.WaitCursor;

			hLog.Debug("Entro en  metodo {SeleccionaNodo}");
			try
			{
				// Comenzamos a pintar los objetos del formulario
				DTOConsolidados oDTO = new DTOConsolidados();
				oDTO = (DTOConsolidados)e.Tag;

				if (oDTO.TipoNodo == (int)CFG.TipoConsolidado.Consolidado)
				{
					labelConsolidadoCodigo.Text = oDTO.Codigo;
					labelConsolidadoDescripcion.Text = oDTO.Descripcion;
					labelConsolidadoObservaciones.Text = oDTO.Observaciones;
					labelConsolidadoPeriodoInicio.Text = oDTO.PeriodoInicio;
					labelConsolidadoPeriodoTermino.Text = oDTO.PeriodoTermino;
					labelConsolidadoParticipacion.Text = oDTO.PorcentajeParticipacion.ToString(CFG.sFormatDisplayDecimal);
					labelConsolidadoEstado.Text = CFG.aEstadoConsolidado[oDTO.Estado];
					labelConsolidadoSeguridad.Text = CFG.aBloqueoConsolidado[oDTO.Bloqueo];
				}
				else
				{
					labelConsolidadoCodigo.Text = "";
					labelConsolidadoDescripcion.Text = "";
					labelConsolidadoObservaciones.Text = "";
					labelConsolidadoPeriodoInicio.Text = "";
					labelConsolidadoPeriodoTermino.Text = "";
					labelConsolidadoParticipacion.Text = "";
					labelConsolidadoEstado.Text = "";
					labelConsolidadoSeguridad.Text = "";
				}
			}
			catch (Exception Ex)
			{
				hLog.msgError(Ex.Message);
			}
			this.Cursor = Cursors.Default;
		}
	}
}
