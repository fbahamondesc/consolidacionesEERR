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
	public partial class MantenedorConsolidados_ConsultaComparativos : Form
	{
		private MyLog4Net hLog = new MyLog4Net("MantenedorConsolidados_ConsultaComparativos.Form");
		private int hiCodigoRegistro = -1;
		private TreeNode hoNodo = new TreeNode();

		public MantenedorConsolidados_ConsultaComparativos()
		{
			InitializeComponent();
			ConfiguracionFormulario();
		}

		private void MantenedorConsolidados_ConsultaComparativos_Load(object sender, EventArgs e)
		{
		}
		private void MantenedorConsolidados_ConsultaComparativos_Shown(object sender, EventArgs e)
		{
			CargaArbolReferenciado();
		}

		//------------------------------------------------------------------------------------------------------------------
		//		Accesos
		//------------------------------------------------------------------------------------------------------------------
		public int CodigoRegistro
		{
			get { return hiCodigoRegistro; }
			set { hiCodigoRegistro = value; }
		}

		//------------------------------------------------------------------------------------------------------------------
		// Metodos privados
		//------------------------------------------------------------------------------------------------------------------

		private void ConfiguracionFormulario()
		{

		}
		private void CargaArbolReferenciado()
		{
			this.Cursor = Cursors.WaitCursor;
			this.Refresh();
			try
			{

				hLog.Debug("rescatamos todos los nodos que estan comparados para crear sus estructuras");

				// Nodo raiz
				treeComparativos.Nodes.Clear();
				treeComparativos.ShowNodeToolTips = true;
				treeComparativos.ImageList = imageList1;
				//treeReferencias.ImageIndex = (int)CFG.TipoIconoArbol.Root;
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
				nuevoNodo.ImageIndex = (int)CFG.TipoIconoArbol.Root;
				treeComparativos.Nodes.Add(nuevoNodo);
				hoNodo = treeComparativos.Nodes[0];

				BOConsolidados oBO = new BOConsolidados();
				List<DTOConsolidados> lDTO = new List<DTOConsolidados>();
				lDTO = oBO.EstructurasComparativo(hiCodigoRegistro);
				foreach (DTOConsolidados oDTO in lDTO)
				{
					hoNodo = treeComparativos.Nodes[0];
					hLog.Debug("Recorremos los nodos referenciados {" + oDTO.IdRegistro.ToString() + "}{" + oDTO.Descripcion + "}");
					if (oDTO.IdPadre != 0)
					{
						CargaArbolInverso(oDTO.IdPadre);
					}
					hLog.Debug("Creamos el nodo {" + oDTO.Descripcion + "}");
					nuevoNodo = new TreeNode();
					nuevoNodo.Text = oDTO.Codigo.ToString().Trim() + " - " + oDTO.Descripcion.ToString().Trim();
					nuevoNodo.Tag = oDTO;
					nuevoNodo.ImageIndex = oDTO.TipoNodo;
					nuevoNodo.SelectedImageIndex = oDTO.TipoNodo;
					hoNodo.Nodes.Add(nuevoNodo);
				}
			}
			catch (Exception Ex)
			{
				hLog.msgFatal(Ex.Message);
			}
			this.Cursor = Cursors.Default;
		}

		private void CargaArbolInverso(int iIdRegistro)
		{
			BOConsolidados oBO = new BOConsolidados();
			DTOConsolidados oDTO = new DTOConsolidados();
			oDTO = oBO.ConsultaConsolidado(iIdRegistro);

			hLog.Debug("buscamos el padre {" + oDTO.IdPadre + "}{" + oDTO.Descripcion + "}");
			if (oDTO.IdPadre != 0)
			{
				CargaArbolInverso(oDTO.IdPadre);
			}
			TreeNode nuevoNodo = new TreeNode();
			if (oDTO.TipoNodo == (int)CFG.TipoConsolidado.Consolidado)
			{
				nuevoNodo.Text = oDTO.Codigo.ToString().Trim() + " - " + oDTO.Descripcion.ToString().Trim();
			}
			else
			{
				nuevoNodo.Text = oDTO.Codigo.ToString();
			}
			nuevoNodo.Tag = oDTO;
			nuevoNodo.ImageIndex = oDTO.TipoNodo;
			nuevoNodo.SelectedImageIndex = oDTO.TipoNodo;
			hoNodo.Nodes.Add(nuevoNodo);
			hoNodo = nuevoNodo;
		}
	}
}
