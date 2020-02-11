using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using NewConsolidado.Controladores.Clases;
using NewConsolidado.Controladores.ControladorNegocio;
using NewConsolidado.Modelos.TransporteDatos;

namespace NewConsolidado.Vistas.Formularios
{
	public partial class MantenedorConsolidados : Form
	{
		private MyLog4Net hLog = new MyLog4Net("MantenedorConsolidados.Form");
		// Objeto de Transporte del arbol
		private List<DTOConsolidados> hlConsolidados = new List<DTOConsolidados>();
		// Guarda el valor de la seleccion del arbol
		private int hiIdRegistro = 0;
        private int hiRegistroCopia = 0;
        private int hiAccion = (int)CFG.ToolAcciones.Nada;
		private int iCopyPaste = (int)CFG.CopyPaste.Nada;
		private TreeNode oCopyNodo = new TreeNode();
		private List<DTOConsolidados> hloDTOCopy = new List<DTOConsolidados>();


		public MantenedorConsolidados()
		{
			InitializeComponent();
			ConfiguracionFormulario();
		}
		private void mntConsolidados_Load(object sender, EventArgs e)
		{
			CargaFormulario();
		}
		private void MantenedorConsolidados_Shown(object sender, EventArgs e)
		{
			CargarArbolConsolidados();
		}
		private void treeConsolidados_AfterSelect(object sender, TreeViewEventArgs e)
		{
			SeleccionaNodo((TreeNode)e.Node);
		}
		private void toolNuevoConsolidado_Click(object sender, EventArgs e)
		{
			//NuevoNodoConsolidado();
		}
		private void toolEditar_Click(object sender, EventArgs e)
		{
			EditarNodoSeleccionado();
		}
		private void toolEliminar_Click(object sender, EventArgs e)
		{
			EliminarNodo();
		}
		private void textConsolidadoCodigo_DragDrop(object sender, DragEventArgs e)
		{
			hLog.Debug("Metodo {textConsolidadoCodigo_DragDrop}");
		}
		private void treeConsolidados_ItemDrag(object sender, ItemDragEventArgs e)
		{
			TreeNode Tree = (TreeNode)e.Item;
			hLog.Debug("Metodo {treeConsolidados_ItemDrag}{" + Tree.Text + "}");

			DoDragDrop(e.Item, DragDropEffects.Move);
		}
		private void treeConsolidados_DragEnter(object sender, DragEventArgs e)
		{
			hLog.Debug("Metodo treeConsolidados_DragEnter");
			e.Effect = DragDropEffects.Move;
		}
		private void treeConsolidados_DragDrop(object sender, DragEventArgs e)
		{
			hLog.Debug("Metodo treeConsolidados_DragDrop");
			// Retrieve the client coordinates of the drop location.
			Point targetPoint = treeConsolidados.PointToClient(new Point(e.X, e.Y));
			// Retrieve the node at the drop location.
			TreeNode targetNode = treeConsolidados.GetNodeAt(targetPoint);
			// Retrieve the node that was dragged.
			TreeNode draggedNode = (TreeNode)e.Data.GetData(typeof(TreeNode));

			ValidaDragAndDrop(targetNode, draggedNode);
		}
		private void textConsolidadoCodigo_DragOver(object sender, DragEventArgs e)
		{
			hLog.Debug("Metodo {textConsolidadoCodigo_DragOver}");

			e.Effect = DragDropEffects.Copy;
		}
		private void toolSalir_Click(object sender, EventArgs e)
		{
			this.Close();
		}
		private void buttonExpandir_Click(object sender, EventArgs e)
		{
			ExpandirArbol();
		}
		private void buttonContraer_Click(object sender, EventArgs e)
		{
			ContraerArbol();
		}
		private void MantenedorConsolidados_FormClosed(object sender, FormClosedEventArgs e)
		{
			if (NewConsolidado.Properties.Settings.Default.usrRecorarPosicionFormularios)
			{
				NewConsolidado.Properties.Settings.Default.frmMantenedorConsolidado = this.Location;
				NewConsolidado.Properties.Settings.Default.frmMantenedorConsolidadoEstado = this.WindowState;
				NewConsolidado.Properties.Settings.Default.frmMantenedorConsolidadoAlto = this.Height;
				NewConsolidado.Properties.Settings.Default.frmMantenedorConsolidadoAncho = this.Width;
			}
		}
		private void MantenedorConsolidados_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (NewConsolidado.Properties.Settings.Default.usrPreguntaFormulariosSalir)
			{
				DialogResult oDlg = MessageBox.Show("Quieres salir de mantenedor de consolidados?", NewConsolidado.Properties.Settings.Default.appTituloAplicacion, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (oDlg == DialogResult.No)
				{
					e.Cancel = true;
				}
			}
		}
		private void toolStripMenuItemERF_Click(object sender, EventArgs e)
		{
			LlamaFormularioReporte((int)CFG.Reporte.erf);
		}
		private void toolStripMenuItemERFSuper_Click(object sender, EventArgs e)
		{
			LlamaFormularioReporte((int)CFG.Reporte.erfSuper);
		}
		private void toolStripMenuItemESFSuper_Click(object sender, EventArgs e)
		{
			LlamaFormularioReporte((int)CFG.Reporte.esfSuper);
		}
		private void toolStripMenuItemESF_Click(object sender, EventArgs e)
		{
			LlamaFormularioReporte((int)CFG.Reporte.esf);
		}
		private void treeConsolidados_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			HabilitacionMenuContextual(e);
		}
		private void asociacionGrupoConceptoCuentaToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LlamaMantenedorAsociacionConsolidadoGrupo();
		}
		private void agregarCarpetaToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AgregarCarpeta();
		}
		private void editarNodoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			EditarNodoSeleccionado();
		}
		private void agregarEmpesaToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AgregarEmpresa();
		}
		private void agregarConsolidadoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AgregarConsolidado();
		}
		private void carpetaToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AgregarCarpeta();
		}
		private void empresaToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AgregarEmpresa();
		}
		private void consolidadoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AgregarConsolidado();
		}
		private void eliminarNodoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			EliminarNodo();
		}
		private void cortarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CortarPegarNodo();
		}
		private void pegarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			PegarNodo();
		}
		private void configuraciónToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LlamaConfiguracionReporte((int)CFG.TipoConfImpresion.ESF);
		}
        private void configuraciónComparativoEstadoResultadoFinancieroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LlamaConfiguracionReporte((int)CFG.TipoConfImpresion.ERF);
        }
		private void esfToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LlamaFormularioReporte((int)CFG.Reporte.esf);
		}
		private void esfSuperToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LlamaFormularioReporte((int)CFG.Reporte.esfSuper);
		}
		private void erfToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LlamaFormularioReporte((int)CFG.Reporte.erf);
		}
		private void erfsuperToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LlamaFormularioReporte((int)CFG.Reporte.erfSuper);
		}
		private void configuraciónToolStripMenuItem1_Click(object sender, EventArgs e)
		{
            LlamaConfiguracionReporte((int)CFG.TipoConfImpresion.ESF);
		}
        private void configuraciónComparacionEstadoResultadoFinancieroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LlamaConfiguracionReporte((int)CFG.TipoConfImpresion.ERF);
        }
		private void copiarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CopiarEstructuraNodo();
		}
		private void buttonRecargar_Click(object sender, EventArgs e)
		{
			BotonRefrescarArbol();
		}
		private void ajustesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			EjecutaLlamadaFormularioAjustes();
		}
        private void buttonCambiarUsuario_Click(object sender, EventArgs e)
        {
            BotonCambiarUsuarioDuenio();
        }

		//------------------------------------------------------------------------------------------------------------------
		// Metodos privados
		//------------------------------------------------------------------------------------------------------------------
		private void ConfiguracionFormulario()
		{
			this.Text = "Mantención de Consolidados";

			ConfiguraToolbar();
			tabControlConsolidado.TabPages.Remove(tabPageCon);
			tabControlConsolidado.TabPages.Remove(tabPageEmp);
			tabControlConsolidado.TabPages.Remove(tabPageCar);

			treeConsolidados.ContextMenuStrip = contextMenuConsolidado;
			treeConsolidados.HideSelection = false;
			treeConsolidados.FullRowSelect = true;
			treeConsolidados.ShowNodeToolTips = true;
			treeConsolidados.ImageList = imageList1;

			labelIdRegistro.Visible = NewConsolidado.Properties.Settings.Default.usrMuestraCamposOcultos;
			labelReferenciado.Visible = NewConsolidado.Properties.Settings.Default.usrMuestraCamposOcultos;

            textDueño.Enabled = Globales.iTipoUsuario == (int)CFG.Usuario.Administrador ? true : false;
            buttonCambiarUsuario.Visible = Globales.iTipoUsuario == (int)CFG.Usuario.Administrador ? true : false;

			MisFunciones.ConfiguraToolBar(toolBarra);

		}
		private void CargaFormulario()
		{
			if (NewConsolidado.Properties.Settings.Default.usrRecorarPosicionFormularios)
			{
				this.Location = NewConsolidado.Properties.Settings.Default.frmMantenedorConsolidado;
				this.WindowState = NewConsolidado.Properties.Settings.Default.frmMantenedorConsolidadoEstado;
				this.Height = NewConsolidado.Properties.Settings.Default.frmMantenedorConsolidadoAlto;
				this.Width = NewConsolidado.Properties.Settings.Default.frmMantenedorConsolidadoAncho;
			}
		}
		private void CargarArbolConsolidados()
		{
			this.Cursor = Cursors.WaitCursor;
			try
			{
				this.Refresh();

				hLog.Debug("Cargamos el arbol y cargamos el nodo raiz");
				BOConsolidados oConsolidado = new BOConsolidados();
				hlConsolidados = oConsolidado.ConsultaConsolidados();

				// Nodo raiz
				treeConsolidados.Nodes.Clear();
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
				this.Refresh();
				//
				CargarArbolConsolidadosHijos(nuevoNodo);
				// Expandimos en arbol para que se vean todos los nodos
				nuevoNodo.Expand();
				// Dejamos posicionado el foco en el primer elemento del arbol
				treeConsolidados.Nodes[0].Checked = true;
				treeConsolidados.SelectedNode = treeConsolidados.Nodes[0];
				treeConsolidados.SelectedNode.EnsureVisible();
				treeConsolidados.Select();
				SeleccionaNodo(treeConsolidados.SelectedNode);
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
			if (DTONodo.CodigoReferenciado == 0)
			{
				DTORecorre = BuscaConsolidadoList(DTONodo.IdRegistro);
			}
			else
			{
				DTORecorre = BuscaConsolidadoList(DTONodo.CodigoReferenciado);
			}
			foreach (DTOConsolidados oDTO in DTORecorre)
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
		private void SeleccionaNodo(TreeNode e)
		{
			hLog.Debug("Entro en  metodo {SeleccionaNodo}");

			try
			{
				this.Cursor = Cursors.WaitCursor;
				//
				laRuta.Text = treeConsolidados.SelectedNode.FullPath;
				// Si selecciono un nodo y esta activo una accion la cancela
				if (hiAccion > (int)CFG.ToolAcciones.Nada)
				{
					//EstadoBotonera(true);
					hiAccion = (int)CFG.ToolAcciones.Nada;
				}
				//
				gridViewNivel.Rows.Clear();
				//
				// Comenzamos a pintar los objetos del formulario
				DTOConsolidados oDTO = new DTOConsolidados();
				oDTO = (DTOConsolidados)e.Tag;
				// Guardamos el numero de registro del nodo seleccionado
				hiIdRegistro = oDTO.IdRegistro;
				//
				labelIdRegistro.Text = oDTO.IdRegistro.ToString();
				labelReferenciado.Text = oDTO.CodigoReferenciado.ToString();
				// Cargamos los datos de registro
				laViewFechaModificacion.Text = MisFunciones.DespliegaFechaFormato(oDTO.FechaModificacion);
				laViewFechaCreacion.Text = MisFunciones.DespliegaFechaFormato(oDTO.FechaCreacion);
				laViewDuenio.Text = oDTO.Owner;
                textDueño.Text = oDTO.Owner;
				//
				groupCarpeta.Hide();
				groupConsolidado.Hide();
				groupEmpresa.Hide();
				switch (oDTO.TipoNodo)
				{
					case (int)CFG.TipoConsolidado.Agrupador:
						{
							groupCarpeta.Parent = tabDetalle;
							groupCarpeta.Show();

							labelCarpetaCodigo.Text = oDTO.Codigo;
							labelCarpetaDescripcion.Text = oDTO.Descripcion;
							labelCarpetaObservaciones.Text = oDTO.Observaciones;

							break;
						}
					case (int)CFG.TipoConsolidado.Consolidado:
						{
							groupConsolidado.Parent = tabDetalle;
							groupConsolidado.Show();

							labelConsolidadoCodigo.Text = oDTO.Codigo;
							labelConsolidadoDescripcion.Text = oDTO.Descripcion;
							labelConsolidadoObservaciones.Text = oDTO.Observaciones;
							labelConsolidadoPeriodoInicio.Text = oDTO.PeriodoInicio;
							labelConsolidadoPeriodoTermino.Text = oDTO.PeriodoTermino;
							labelConsolidadoParticipacion.Text = oDTO.PorcentajeParticipacion.ToString(CFG.sFormatDisplayDecimal);
							labelConsolidadoEstado.Text = CFG.aEstadoConsolidado[oDTO.Estado];
							labelConsolidadoSeguridad.Text = CFG.aBloqueoConsolidado[oDTO.Bloqueo];

							break;
						}
					case (int)CFG.TipoConsolidado.Empresa:
						{
							groupEmpresa.Parent = tabDetalle;
							groupEmpresa.Show();

							labelEmpresaCodigo.Text = oDTO.Codigo;
							labelEmpresaDescripcion.Text = oDTO.Descripcion;
							labelEmpresaObservaciones.Text = oDTO.Observaciones;
							labelEmpresaParticipacion.Text = oDTO.PorcentajeParticipacion.ToString(CFG.sFormatDisplayDecimal);
							labelEmpresaMatriz.Text = CFG.aIndicadorMatriz[oDTO.IndicadorMatriz];

							break;
						}
					default:
						{
							hLog.Fatal("Mala clasificacion al {SeleccionNodo}");
							throw new SystemException("Mala clasificacion al {SeleccionNodo}");

						}
				}
				this.Refresh();
				//
				if (oDTO.CodigoReferenciado != 0)
				{
					CargaListaNodosConsolidado(oDTO.CodigoReferenciado);
				}
				else
				{
					CargaListaNodosConsolidado(oDTO.IdRegistro);
				}
				//
				this.Cursor = Cursors.Default;

			}
			catch (Exception Ex)
			{
				hLog.msgError(Ex.Message);
			}
		}

		private void ConfiguraToolbar()
		{

		}

		private List<DTOConsolidados> BuscaConsolidadoList(int iIdRegistro)
		{
			List<DTOConsolidados> lDTO = new List<DTOConsolidados>();
			lDTO = hlConsolidados.FindAll(delegate(DTOConsolidados lst)
			{ return lst.IdPadre == iIdRegistro; });
			return lDTO;
		}

		private void CargaListaNodosConsolidado(int iID)
		{
			if (iID > 0)
			{
				gridViewNivel.Rows.Clear();

				BOConsolidados oBO = new BOConsolidados();
				List<DTOConsolidados> lDTO = new List<DTOConsolidados>();
				lDTO = oBO.ConsultaConsolidados(iID);
				foreach (DTOConsolidados oDTO in lDTO)
				{
					gridViewNivel.Rows.Add();
					gridViewNivel.Rows[gridViewNivel.Rows.Count - 1].Cells["colCodigo"].Value = oDTO.Codigo;
					gridViewNivel.Rows[gridViewNivel.Rows.Count - 1].Cells["colDescripcion"].Value = oDTO.Descripcion;
					gridViewNivel.Rows[gridViewNivel.Rows.Count - 1].Cells["colParticipacion"].Value = oDTO.PorcentajeParticipacion.ToString(CFG.sFormatDisplayDecimal);
					switch (oDTO.TipoNodo)
					{
						case (int)CFG.TipoConsolidado.Agrupador:
							{
								gridViewNivel.Rows[gridViewNivel.Rows.Count - 1].Cells["ColTipo"].Value = "";
								break;
							}
						case (int)CFG.TipoConsolidado.Consolidado:
							{
								DTOConsolidados oDTOP = new DTOConsolidados();
								oDTOP = oBO.ConsultaConsolidado(oDTO.IdPadre);
								if (oDTOP.TipoNodo == (int)CFG.TipoConsolidado.Agrupador)
								{
									gridViewNivel.Rows[gridViewNivel.Rows.Count - 1].Cells["ColTipo"].Value = "";
								}
								else
								{
									gridViewNivel.Rows[gridViewNivel.Rows.Count - 1].Cells["ColTipo"].Value = CFG.aIndicadorMatriz[oDTO.IndicadorMatriz];
								}
								break;
							}
						case (int)CFG.TipoConsolidado.Empresa:
							{
								gridViewNivel.Rows[gridViewNivel.Rows.Count - 1].Cells["ColTipo"].Value = CFG.aIndicadorMatriz[oDTO.IndicadorMatriz];
								break;
							}
						default:
							{
								hLog.Fatal("Mala clasificacion al {CargaListaNodosConsolidado}");
								throw new SystemException("Mala clasificacion al {CargaListaNodosConsolidado}");

							}
					}
					this.Refresh();
				}
			}
		}

		private void ExpandirArbol()
		{
			treeConsolidados.ExpandAll();
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

		private void LlamaFormularioReporte(int iReporte)
		{
			DTOConsolidados oDTO = new DTOConsolidados();
			oDTO = (DTOConsolidados)treeConsolidados.SelectedNode.Tag;
			//
			DTOConcurrencias oCon = new DTOConcurrencias();
			BOConcurrencias oBo = new BOConcurrencias();
			oCon = oBo.ConsultaConcurrencias(oDTO.IdCodigo);
            if (oCon.ValueConcurrencia == (int)CFG.Concurrencia.SinConcurrencia)
            {
                switch (iReporte)
                {
                    case (int)CFG.Reporte.erf:
                    case (int)CFG.Reporte.erfSuper:
                        {
                            MenuReportes oForm = new MenuReportes();
                            oForm.WindowState = FormWindowState.Normal;
                            oForm.StartPosition = FormStartPosition.CenterParent;
                            oForm.ShowIcon = false;
                            oForm.ShowInTaskbar = false;
                            oForm.Reporte = iReporte;
                            oForm.SetRep = (int)CFG.TipoConfImpresion.ERF;
                            oForm.idConsolidado = oDTO.IdRegistro;
                            oForm.idComparativo = oDTO.idComparativoERF;
                            oForm.Periodo = oDTO.PeriodoInformeERF;
                            oForm.PeriodoComparativo = oDTO.PeriodoComparativoERF;
                            oForm.ShowDialog(this);
                            break;
                        }
                    case (int)CFG.Reporte.esf:
                    case (int)CFG.Reporte.esfSuper:
                        {
                            MenuReportes oForm = new MenuReportes();
                            oForm.WindowState = FormWindowState.Normal;
                            oForm.StartPosition = FormStartPosition.CenterParent;
                            oForm.ShowIcon = false;
                            oForm.ShowInTaskbar = false;
                            oForm.Reporte = iReporte;
                            oForm.SetRep = (int)CFG.TipoConfImpresion.ESF;
                            oForm.idConsolidado = oDTO.IdRegistro;
                            oForm.idComparativo = oDTO.idComparativo;
                            oForm.Periodo = oDTO.PeriodoInforme;
                            oForm.PeriodoComparativo = oDTO.PeriodoComparativo;
                            oForm.ShowDialog(this);
                            break;
                        }
                    default:
                        { hLog.msgError("Selecion parametro Erroneo"); break; }
                }
            }
            else
            {
                hLog.msgAlerta("No se puede ejecutar la accion por que un usuario esta editando el consolidado");
            }
		}

		private void LlamaMantenedorAsociacionConsolidadoGrupo()
		{
			DTOConsolidados oDTO = new DTOConsolidados();
			oDTO = (DTOConsolidados)treeConsolidados.SelectedNode.Tag;
			MantenedorConsolidados_AsociacionGrupos oForm = new MantenedorConsolidados_AsociacionGrupos();
			oForm.idConsolidado = oDTO.IdRegistro;
			oForm.Descripcion = oDTO.Descripcion;
			oForm.ShowIcon = false;
			oForm.ShowInTaskbar = false;
			oForm.ShowDialog(this);
		}

		private void HabilitacionMenuContextual(TreeNodeMouseClickEventArgs e)
		{
			hLog.Debug("entre a {HabilitacionMenuContextual}");
			//
			if (e.Button == MouseButtons.Right)
			{
				treeConsolidados.SelectedNode = e.Node;
			}
			//
			if (e.Node.Level > 0)
			{
				DTOConsolidados oDTO = new DTOConsolidados();
				DTOConsolidados oDTOPadre = new DTOConsolidados();
				oDTO = (DTOConsolidados)e.Node.Tag;
				oDTOPadre = (DTOConsolidados)e.Node.Parent.Tag;
				switch (oDTO.TipoNodo)
				{
					case (int)CFG.TipoConsolidado.Agrupador:
						{
							agregarCarpetaToolStripMenuItem.Enabled = true;
							agregarEmpesaToolStripMenuItem.Enabled = false;
							agregarConsolidadoToolStripMenuItem.Enabled = true;
							editarNodoToolStripMenuItem.Enabled = true;
							editarNodoToolStripMenuItem.Text = "Editar Carpeta";
							eliminarNodoToolStripMenuItem.Enabled = true;
							cortarToolStripMenuItem.Enabled = true;
							copiarToolStripMenuItem.Enabled = true;
							pegarToolStripMenuItem.Enabled = true;
							imprimirToolStripMenuItem.Enabled = false;
							ajustesToolStripMenuItem.Enabled = false;
							asociacionGrupoConceptoCuentaToolStripMenuItem.Enabled = true;
							toolImprimir.Enabled = false;

							carpetaToolStripMenuItem.Enabled = true;
							empresaToolStripMenuItem.Enabled = false;
							consolidadoToolStripMenuItem.Enabled = true;
							toolEditar.Enabled = true;
							break;
						}
					case (int)CFG.TipoConsolidado.Consolidado:
						{
							//Analizar nivel del consolidado
							if (oDTOPadre.TipoNodo == (int)CFG.TipoConsolidado.Agrupador)
							{
								// Configuracion de opciones del menu
								agregarCarpetaToolStripMenuItem.Enabled = false;
								agregarEmpesaToolStripMenuItem.Enabled = true;
								agregarConsolidadoToolStripMenuItem.Enabled = true;
								editarNodoToolStripMenuItem.Enabled = true;
								editarNodoToolStripMenuItem.Text = "Editar Consolidado";
								eliminarNodoToolStripMenuItem.Enabled = true;
								cortarToolStripMenuItem.Enabled = true;
								copiarToolStripMenuItem.Enabled = true;
								pegarToolStripMenuItem.Enabled = true;
								imprimirToolStripMenuItem.Enabled = true;
								ajustesToolStripMenuItem.Enabled = true;
								asociacionGrupoConceptoCuentaToolStripMenuItem.Enabled = true;
								toolImprimir.Enabled = true;

								carpetaToolStripMenuItem.Enabled = false;
								empresaToolStripMenuItem.Enabled = true;
								consolidadoToolStripMenuItem.Enabled = true;
								toolEditar.Enabled = true;
							}
							else
							{
								agregarCarpetaToolStripMenuItem.Enabled = false;
								agregarEmpesaToolStripMenuItem.Enabled = false;
								agregarConsolidadoToolStripMenuItem.Enabled = false;
								editarNodoToolStripMenuItem.Enabled = true;
								editarNodoToolStripMenuItem.Text = "Editar Consolidado";
								eliminarNodoToolStripMenuItem.Enabled = true;
								cortarToolStripMenuItem.Enabled = true;
								copiarToolStripMenuItem.Enabled = true;
								pegarToolStripMenuItem.Enabled = true;
								imprimirToolStripMenuItem.Enabled = false;
								ajustesToolStripMenuItem.Enabled = true;
								asociacionGrupoConceptoCuentaToolStripMenuItem.Enabled = true;
								toolImprimir.Enabled = false;

								carpetaToolStripMenuItem.Enabled = false;
								empresaToolStripMenuItem.Enabled = false;
								consolidadoToolStripMenuItem.Enabled = false;
								toolEditar.Enabled = true;
							}
							break;
						}
					case (int)CFG.TipoConsolidado.Empresa:
						{
							if (oDTOPadre.CodigoReferenciado > 0)
							{
								// Configuracion de opciones del menu
								agregarCarpetaToolStripMenuItem.Enabled = false;
								agregarEmpesaToolStripMenuItem.Enabled = false;
								agregarConsolidadoToolStripMenuItem.Enabled = false;
								editarNodoToolStripMenuItem.Enabled = false;
								editarNodoToolStripMenuItem.Text = "Editar Empresa";
								eliminarNodoToolStripMenuItem.Enabled = false;
								cortarToolStripMenuItem.Enabled = false;
								copiarToolStripMenuItem.Enabled = true;
								pegarToolStripMenuItem.Enabled = false;
								imprimirToolStripMenuItem.Enabled = false;
								ajustesToolStripMenuItem.Enabled = false;
								asociacionGrupoConceptoCuentaToolStripMenuItem.Enabled = false;
								toolImprimir.Enabled = false;

								carpetaToolStripMenuItem.Enabled = false;
								empresaToolStripMenuItem.Enabled = false;
								consolidadoToolStripMenuItem.Enabled = false;
								toolEditar.Enabled = false;
							}
							else
							{
								// Configuracion de opciones del menu
								agregarCarpetaToolStripMenuItem.Enabled = false;
								agregarEmpesaToolStripMenuItem.Enabled = false;
								agregarConsolidadoToolStripMenuItem.Enabled = false;
								editarNodoToolStripMenuItem.Enabled = true;
								editarNodoToolStripMenuItem.Text = "Editar Empresa";
								eliminarNodoToolStripMenuItem.Enabled = true;
								cortarToolStripMenuItem.Enabled = true;
								copiarToolStripMenuItem.Enabled = true;
								pegarToolStripMenuItem.Enabled = false;
								imprimirToolStripMenuItem.Enabled = false;
								ajustesToolStripMenuItem.Enabled = false;
								asociacionGrupoConceptoCuentaToolStripMenuItem.Enabled = false;
								toolImprimir.Enabled = false;

								carpetaToolStripMenuItem.Enabled = false;
								empresaToolStripMenuItem.Enabled = false;
								consolidadoToolStripMenuItem.Enabled = false;
								toolEditar.Enabled = true;
							}
							break;
						}
					default:
						{
							hLog.Fatal("Mala clasificacion al {HabilitacionMenuContextual}");
							throw new SystemException("Mala clasificacion al {HabilitacionMenuContextual}");

						}
				}
			}
			else
			{
				// Configuracion de opciones del menu
				// menu Raiz
				agregarCarpetaToolStripMenuItem.Enabled = true;
				editarNodoToolStripMenuItem.Enabled = false;
				agregarEmpesaToolStripMenuItem.Enabled = false;
				agregarConsolidadoToolStripMenuItem.Enabled = false;
				editarNodoToolStripMenuItem.Enabled = false;
				eliminarNodoToolStripMenuItem.Enabled = false;
				cortarToolStripMenuItem.Enabled = false;
				copiarToolStripMenuItem.Enabled = false;
				pegarToolStripMenuItem.Enabled = false;
				imprimirToolStripMenuItem.Enabled = false;
				ajustesToolStripMenuItem.Enabled = false;
				asociacionGrupoConceptoCuentaToolStripMenuItem.Enabled = false;
				toolImprimir.Enabled = false;

				carpetaToolStripMenuItem.Enabled = true;
				empresaToolStripMenuItem.Enabled = false;
				consolidadoToolStripMenuItem.Enabled = false;
				toolEditar.Enabled = false;
			}
		}

		private TreeNode AgregaNuevoNodo(DTOConsolidados oDTO, TreeNode oNodoPadre)
		{
			hLog.Debug("metodo { AgregaNuevoNodo } { " + oDTO.Descripcion + " }");
			string sM = ""; string sR = "";
			//
			TreeNode nuevoNodo = new TreeNode();
			nuevoNodo.ForeColor = Color.Black;
			nuevoNodo.NodeFont = new Font("Helvetica", 9, FontStyle.Regular);
			//nuevoNodo.NodeFont = new Font("San Serif", 9, FontStyle.Regular);

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

		private void AgregarCarpeta()
		{
			DTOConsolidados oDTO = new DTOConsolidados();
			oDTO = (DTOConsolidados)treeConsolidados.SelectedNode.Tag;
			// llamamos al formulario
			MantenedorConsolidados_Carpeta oForm = new MantenedorConsolidados_Carpeta();
			oForm.StartPosition = FormStartPosition.CenterParent;
			oForm.Accion = (int)CFG.ToolAcciones.Nuevo;
			oForm.CodigoPadre = oDTO.IdRegistro;
			oForm.DescripcionPadre = oDTO.Descripcion;
			oForm.ShowIcon = false;
			oForm.ShowInTaskbar = false;
			if (oForm.ShowDialog(this) == DialogResult.OK)
			{
				string sIC = oForm.IdCodigo;
				BOConsolidados oBO = new BOConsolidados();
				oDTO = oBO.ConsultaConsolidado(sIC);
				// Agregamos el nodo
				AgregaNuevoNodo(oDTO, treeConsolidados.SelectedNode);
			}
		}

		private void AgregarConsolidado()
		{
			DTOConsolidados oDTO = new DTOConsolidados();
			oDTO = (DTOConsolidados)treeConsolidados.SelectedNode.Tag;

			MantenedorConsolidados_Consolidados oForm = new MantenedorConsolidados_Consolidados() { Accion = (int)CFG.ToolAcciones.Nuevo };
			oForm.StartPosition = FormStartPosition.CenterParent;
			oForm.CodigoPadre = oDTO.IdRegistro;
			oForm.DescripcionPadre = oDTO.Codigo;
			oForm.TipoPadre = oDTO.TipoNodo;
			oForm.ShowIcon = false;
			oForm.ShowInTaskbar = false;
			if (oForm.ShowDialog(this) == DialogResult.OK)
			{
				string sIC = oForm.IdCodigo;
				BOConsolidados oBO = new BOConsolidados();
				oDTO = oBO.ConsultaConsolidado(sIC);
				// Agregamos el nodo
				TreeNode oNode = new TreeNode();
				oNode = AgregaNuevoNodo(oDTO, treeConsolidados.SelectedNode);
				if (oDTO.CodigoReferenciado > 0)
				{
					CargarArbolConsolidadosHijos(oNode);
				}
			}
		}

		private void AgregarEmpresa()
		{
			DTOConsolidados oDTO = new DTOConsolidados();
			oDTO = (DTOConsolidados)treeConsolidados.SelectedNode.Tag;
			// llamamos al formulario
			MantenedorConsolidados_Empresas oForm = new MantenedorConsolidados_Empresas() { Accion = (int)CFG.ToolAcciones.Nuevo };
			oForm.StartPosition = FormStartPosition.CenterParent;
			oForm.CodigoPadre = oDTO.IdRegistro;
			oForm.DescripcionPadre = oDTO.Codigo;
			oForm.ShowIcon = false;
			oForm.ShowInTaskbar = false;
			if (oForm.ShowDialog(this) == DialogResult.OK)
			{
				string sIC = oForm.IdCodigo;
				BOConsolidados oBO = new BOConsolidados();
				oDTO = oBO.ConsultaConsolidado(sIC);
				// Agregamos el nodo
				AgregaNuevoNodo(oDTO, treeConsolidados.SelectedNode);
			}
		}

		private void EditarNodoSeleccionado()
		{
			if (treeConsolidados.SelectedNode.Level == 0)
			{
				hLog.msgError("No puede editar el nodo raiz del arbol, este es solo una representacion visual");
			}
			else
			{
				BOConsolidados oBO = new BOConsolidados();
				DTOConsolidados oDTO = new DTOConsolidados();
				oDTO = (DTOConsolidados)treeConsolidados.SelectedNode.Tag;
				if (oDTO.Owner == Globales.UsuarioActivo
					|| Globales.iTipoUsuario == (int)CFG.Usuario.Administrador)
				{
					switch (oDTO.TipoNodo)
					{
						case (int)CFG.TipoConsolidado.Agrupador:
							{
								hLog.Debug("Editar agrupador");
								MantenedorConsolidados_Carpeta oForm = new MantenedorConsolidados_Carpeta();
								oForm.Accion = (int)CFG.ToolAcciones.Editar;
								oForm.CodigoRegistro = oDTO.IdRegistro;
								oForm.DescripcionPadre = treeConsolidados.SelectedNode.Parent.Text;
								oForm.StartPosition = FormStartPosition.CenterParent;
								oForm.ShowIcon = false;
								oForm.ShowInTaskbar = false;
								if (oForm.ShowDialog(this) == DialogResult.OK)
								{
									oDTO = oBO.ConsultaConsolidado(oDTO.IdRegistro);
									treeConsolidados.SelectedNode.Tag = oDTO;
									treeConsolidados.SelectedNode.Text = oDTO.Codigo;
								}
								break;
							}
						case (int)CFG.TipoConsolidado.Consolidado:
							{
								hLog.Debug("Editar Consolidado");
								MantenedorConsolidados_Consolidados oForm = new MantenedorConsolidados_Consolidados();
								oForm.Accion = (int)CFG.ToolAcciones.Editar;
								oForm.CodigoRegistro = oDTO.IdRegistro;
								oForm.DescripcionPadre = treeConsolidados.SelectedNode.Parent.Text;
								DTOConsolidados oDTOP = new DTOConsolidados();
								oDTOP = (DTOConsolidados)treeConsolidados.SelectedNode.Parent.Tag;
								oForm.TipoPadre = oDTOP.TipoNodo;
								oForm.StartPosition = FormStartPosition.CenterParent;
								oForm.ShowIcon = false;
								oForm.ShowInTaskbar = false;
								if (oForm.ShowDialog(this) == DialogResult.OK)
								{
									TreeNode oNodePadre = new TreeNode();
									oNodePadre = treeConsolidados.SelectedNode.Parent;
									//Removemos el nodo por cualquier cambio que haya ocurrido
									treeConsolidados.SelectedNode.Remove();
									// Agregamos el nodo nuevo
									string sIC = oForm.IdCodigo;
									oDTO = oBO.ConsultaConsolidado(sIC);
									// Agregamos el nodo
									TreeNode oNode = new TreeNode();
									oNode = AgregaNuevoNodo(oDTO, oNodePadre);
									if (oDTO.CodigoReferenciado > 0)
									{
										CargarArbolConsolidadosHijos(oNode);
									}
								}
								break;
							}
						case (int)CFG.TipoConsolidado.Empresa:
							{
								hLog.Debug("Editar Empresa");
								MantenedorConsolidados_Empresas oForm = new MantenedorConsolidados_Empresas();
								oForm.Accion = (int)CFG.ToolAcciones.Editar;
								oForm.CodigoRegistro = oDTO.IdRegistro;
								oForm.DescripcionPadre = treeConsolidados.SelectedNode.Parent.Text;
								oForm.StartPosition = FormStartPosition.CenterParent;
								oForm.ShowIcon = false;
								oForm.ShowInTaskbar = false;
								if (oForm.ShowDialog(this) == DialogResult.OK)
								{
									oDTO = oBO.ConsultaConsolidado(oDTO.IdRegistro);
									treeConsolidados.SelectedNode.Tag = oDTO;
									string sM = "";
									if (oDTO.IndicadorMatriz == (int)CFG.IndicadorMatriz.Si)
									{
										treeConsolidados.SelectedNode.ForeColor = Color.IndianRed;
										treeConsolidados.SelectedNode.NodeFont = new Font("Helvetica", 9, FontStyle.Bold);
										sM = "* ";
									}
									else
									{
										treeConsolidados.SelectedNode.ForeColor = Color.Black;
										treeConsolidados.SelectedNode.NodeFont = new Font("San Serif", 9, FontStyle.Regular);
									}

									treeConsolidados.SelectedNode.Text = sM + oDTO.Codigo;
								}
								break;
							}
						default:
							{
								hLog.msgFatal("Mala clasificacion al {EditarNodoSeleccionado}");
								throw new SystemException("Mala clasificacion al {EditarNodoSeleccionado}");
							}
					}
				}
				else
				{
					hLog.msgAlerta("No tiene las credenciales para editar el nodo");
				}
			}
		}

		private void EliminarNodo()
		{
			try
			{
				hLog.Info("Metodo {EliminarNodo}");
				hiAccion = (int)CFG.ToolAcciones.Eliminar;
				if (treeConsolidados.SelectedNode.Level == 0)
				{
					hLog.msgError("No puede Eliminar el nodo raiz del arbol, este es solo una representacion visual");
				}
				else
				{
					//extraigo valores del nodo para evaluacion
					DTOConsolidados oDTO = new DTOConsolidados();
					oDTO = (DTOConsolidados)treeConsolidados.SelectedNode.Tag;
                    BOConsolidados oBO = new BOConsolidados();

                    //Revisar si tiene referencias en otro consolidados
                    if (oBO.EsRefereciado(oDTO.IdRegistro))
                    {
                        hLog.msgError("El consolidado esta siendo referenciado");
                        return;
                    }

                    //Revisar si tiene referencias como comparativos
                    if (oBO.EsComparativo(oDTO.IdRegistro))
                    {
                        hLog.msgError("El consolidado esta siendo utilizado como comparativo");
                        return;
                    }

                    if (NewConsolidado.Properties.Settings.Default.usrPreguntaEliminar)
                    {
                        DialogResult oDlg = MessageBox.Show("Desea eliminar el nodo seleccionado y su estrucura?", NewConsolidado.Properties.Settings.Default.appTituloAplicacion, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (oDlg == DialogResult.Yes)
                        {
                            this.Cursor = Cursors.WaitCursor;
                            oBO.EliminarEstructura(oDTO.IdRegistro);
                            treeConsolidados.SelectedNode.Remove();
                            this.Cursor = Cursors.Default;
                        }
                    }
                    else
                    {
                        this.Cursor = Cursors.WaitCursor;
                        oBO.EliminarEstructura(oDTO.IdRegistro);
                        treeConsolidados.SelectedNode.Remove();
                        this.Cursor = Cursors.Default;
                    }
				}
				hiAccion = (int)CFG.ToolAcciones.Nada;
			}
			catch (Exception Ex)
			{
				hLog.msgFatal("Error detectado \n{" + Ex.Message + "}");
			}
		}

		private void EliminarNodoRecursivo(TreeNode oNodo)
		{
			DTOConsolidados oDTO = new DTOConsolidados();
			oDTO = (DTOConsolidados)oNodo.Tag;
			hLog.Debug("Metodo {EliminarNodoRecursivo} {" + oDTO.Descripcion + "} idRegsitro{" + oDTO.IdRegistro.ToString() + "}");
			// preguntamos si es referenciado para deterner la busqueda al interior
			if (oDTO.CodigoReferenciado == 0)
			{
				foreach (TreeNode oNodoHijo in oNodo.Nodes)
				{
					// Bajamos un nivel
					EliminarNodoRecursivo(oNodoHijo);
				}
			}
			// eliminamos el nodo en el que estamos parados
			BOConsolidados oBo = new BOConsolidados();
			oBo.GrabarDatosConsolidado((int)CFG.ToolAcciones.Eliminar, oDTO);
		}

		private void CortarPegarNodo()
		{
			iCopyPaste = (int)CFG.CopyPaste.Cortar;

			DTOConsolidados oDTO = new DTOConsolidados();
			oDTO = (DTOConsolidados)treeConsolidados.SelectedNode.Tag;
			//
			//iCopyCodigo = oDTO.IdRegistro;
			oCopyNodo = treeConsolidados.SelectedNode;

			hloDTOCopy.Clear();
			hloDTOCopy.Add(oDTO);
		}

		private void PegarNodo()
		{
			this.Cursor = Cursors.WaitCursor;
			try
			{
				if (hloDTOCopy.Count > 0)
				{
					BOConsolidados oBO = new BOConsolidados();
					DTOConsolidados oDTOPadre = new DTOConsolidados();
					oDTOPadre = (DTOConsolidados)treeConsolidados.SelectedNode.Tag;

					//DTOConsolidados oDTO = new DTOConsolidados();
					//oDTO = (DTOConsolidados)oCopyNodo.Tag;
                    switch (iCopyPaste)
                    {
                        case (int)CFG.CopyPaste.Cortar:
                            {
                                if (ValidaMovimientoNodo(hloDTOCopy[0], oDTOPadre))
                                {
                                    //Grabamos el cambio
                                    hloDTOCopy[0].IdPadre = oDTOPadre.IdRegistro;
                                    oBO.GrabarDatosConsolidado((int)CFG.ToolAcciones.Editar, hloDTOCopy[0]);
                                    //Movemos el nodo
                                    oCopyNodo.Remove();
                                    treeConsolidados.SelectedNode.Nodes.Add(oCopyNodo);
                                    oCopyNodo.Tag = hloDTOCopy[0];
                                }
                                break;
                            }
                        case (int)CFG.CopyPaste.Copiar:
                            {
                                if (ValidaMovimientoNodo(hloDTOCopy[0], oDTOPadre))
                                {
                                    hLog.Debug("Pegamos el nodo o estructura almacenada en memoria");
                                    //DTOConsolidados oDTOC = (DTOConsolidados)treeConsolidados.SelectedNode.Tag;
                                    oBO.PegarEstructuraNodos(hloDTOCopy, oDTOPadre.IdRegistro);
                                    // Obtengo el nuevo valor idregsitro
                                    DTOConsolidados oD2 = new DTOConsolidados();
                                    oD2 = oBO.ConsultaConsolidado( hloDTOCopy[0].IdCodigo );

                                    List<DTOAjustes> lAjustes = new List<DTOAjustes>();
                                    BOAjustes oBOAj = new BOAjustes();
                                    lAjustes = oBOAj.ConsultaAsientosPorConsolidado(hiRegistroCopia, "");
                                    if (lAjustes.Count > 0)
                                    {
                                        DialogResult oDlg = MessageBox.Show("Quieres copiar los ajustes manuales y automaticos desde el consolidado original?", NewConsolidado.Properties.Settings.Default.appTituloAplicacion, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                        if (oDlg == DialogResult.Yes)
                                        {
                                            oBOAj.Copiarajustes(hiRegistroCopia, oD2.IdRegistro);
                                        }
                                    }

                                    //
                                    hLog.Debug("Pintamos el trozo de arbol que sea necesario");
                                    hlConsolidados = oBO.ConsultaConsolidados();
                                    treeConsolidados.SelectedNode.Nodes.Clear();
                                    CargarArbolConsolidadosHijos(treeConsolidados.SelectedNode);
                                    hloDTOCopy.Clear();
                                }
                                break;
                            }
                        default:
                            {
                                hLog.Fatal("Mala clasificacion al {PegarNodo}");
                                throw new SystemException("Mala clasificacion al {PegarNodo}");

                            }
                    }
					hloDTOCopy.Clear();
				}
			}
			catch (Exception Ex)
			{
				hLog.Fatal(Ex.Message);

			}
			this.Cursor = Cursors.Default;
		}

        private void LlamaConfiguracionReporte(int iSet)
        {
            hLog.Debug("Llama formulario de configuracion de reportes para el consolidado con el valor {" + iSet.ToString() + "}");
            DTOConsolidados oDTO = new DTOConsolidados();
            oDTO = (DTOConsolidados)treeConsolidados.SelectedNode.Tag;

            if (oDTO.Owner == Globales.UsuarioActivo || Globales.iTipoUsuario == (int)CFG.Usuario.Administrador)
            {
                MantenedorConsolidados_ConfiguracionImprimir oForm = new MantenedorConsolidados_ConfiguracionImprimir(iSet);
                oForm.StartPosition = FormStartPosition.CenterParent;
                //oForm.IdComparativo = oDTO.idComparativo;
                oForm.IdConsolidado = oDTO.IdRegistro;
                oForm.ShowIcon = false;
                oForm.ShowInTaskbar = false;
                if (oForm.ShowDialog(this) == DialogResult.OK)
                {
                    BOConsolidados oBO = new BOConsolidados();
                    oDTO = oBO.ConsultaConsolidado(oDTO.IdRegistro);
                    treeConsolidados.SelectedNode.Tag = oDTO;
                }
            }
            else
            {
                hLog.msgAlerta("No posee las credenciales para configurar el consolidado");
            }
        }
		private void CopiarEstructuraNodo()
		{
			this.Cursor = Cursors.WaitCursor;
			if (treeConsolidados.Nodes.Count > 0)
			{
				hLog.Debug("copiamos el nodo o estructura seleccionada");
				iCopyPaste = (int)CFG.CopyPaste.Copiar;

				BOConsolidados oBO = new BOConsolidados();
				DTOConsolidados oDTO = (DTOConsolidados)treeConsolidados.SelectedNode.Tag;
                hiRegistroCopia = oDTO.IdRegistro;
				hloDTOCopy.Clear();
				hloDTOCopy = oBO.CopiarEstructuraNodo(oDTO.IdRegistro);
			}
			this.Cursor = Cursors.Default;
		}
		private void BotonRefrescarArbol()
		{
			hLog.Debug("Refrescamos el arbol completo");
			BOConsolidados oBO = new BOConsolidados();
			hlConsolidados = oBO.ConsultaConsolidados();
			CargarArbolConsolidados();
		}
		private Boolean ValidaMovimientoNodo(DTOConsolidados oDTOMover, DTOConsolidados oDTODestino)
		{
			#region Validaciones basicas por tipo de objeto
			if (oDTODestino.TipoNodo == (int)CFG.TipoConsolidado.Empresa)
			{
				hLog.msgError("Accion no permitida");
				return false;
			}
			if (oDTODestino.TipoNodo == (int)CFG.TipoConsolidado.Agrupador)
			{
				if (oDTOMover.TipoNodo == (int)CFG.TipoConsolidado.Empresa)
				{
					hLog.msgError("Accion no permitida");
					return false;
				}
			}
			if (oDTODestino.TipoNodo == (int)CFG.TipoConsolidado.Consolidado)
			{
				if (oDTOMover.TipoNodo == (int)CFG.TipoConsolidado.Agrupador)
				{
					hLog.msgError("Accion no permitida");
					return false;
				}
			}
			#endregion

			if (oDTOMover.Owner == Globales.UsuarioActivo || Globales.iTipoUsuario == (int)CFG.Usuario.Administrador)
			{
                if (oDTODestino.Owner == Globales.UsuarioActivo || Globales.iTipoUsuario == (int)CFG.Usuario.Administrador)
                {

                }
                else
                {
                        hLog.msgError("Accion no permitida, no es dueño del nodo/estructura destino");
                        return false;

                }
			}
			else
			{
				hLog.msgError("Accion no permitida, no es dueño del nodo/estructura a mover");
				return false;
			}

			//----------
			return true;
		}
		private void EjecutaLlamadaFormularioAjustes()
		{
			try
			{
				DTOConsolidados oDTO = new DTOConsolidados();
				oDTO = (DTOConsolidados)treeConsolidados.SelectedNode.Tag;
				if (oDTO.Bloqueo == (int)CFG.BloqueoConsolidado.Abierto || Globales.iTipoUsuario == (int)CFG.Usuario.Administrador)
				{
					if (oDTO.Owner == Globales.UsuarioActivo || Globales.iTipoUsuario == (int)CFG.Usuario.Administrador)
					{
						DTOConcurrencias oCon = new DTOConcurrencias();
						BOConcurrencias oBO = new BOConcurrencias();
						oCon = oBO.ConsultaConcurrencias(oDTO.IdCodigo);
						if (oCon.ValueConcurrencia == (int)CFG.Concurrencia.SinConcurrencia || Globales.iTipoUsuario == (int)CFG.Usuario.Administrador)
						{
							oBO.CrearConcurrencias(oDTO.IdCodigo);

							IngresoAjustesManuales oForm = new IngresoAjustesManuales();
							oForm.StartPosition = FormStartPosition.CenterParent;
							oForm.IdConsolidado = oDTO.IdRegistro;
							oForm.IdCodigo = oDTO.Codigo;
							oForm.DescripcionConsolidado = oDTO.Descripcion;
							oForm.ShowIcon = false;
							oForm.ShowInTaskbar = false;
							oForm.ShowDialog(this);

							oBO.EliminaConcurrencias(oDTO.IdCodigo);
						}
						else
						{
							hLog.msgAlerta("No se puede ejecutar la accion por que un usuario esta editando el consolidado");
						}
					}
					else
					{
						hLog.msgAlerta("No posee las credenciales para ingresar ajustes");
					}
				}
				else
				{
					hLog.msgAlerta("No puede agregar ajustes por que el consolidado esta bloqueado");
				}
			}
			catch (Exception ex)
			{
				hLog.msgFatal(ex.Message);
			}
		}
		private void ValidaDragAndDrop(TreeNode targetNode, TreeNode draggedNode)
		{
			// Confirm that the node at the drop location is not 
			// the dragged node and that target node isn't null
			// (for example if you drag outside the control)
			if (!draggedNode.Equals(targetNode) && targetNode != null)
			{
				try
				{
					BOConsolidados oBO = new BOConsolidados();
					DTOConsolidados oDTO = new DTOConsolidados();
					DTOConsolidados oDTOP = new DTOConsolidados();
					oDTOP = (DTOConsolidados)targetNode.Tag;
					oDTO = (DTOConsolidados)draggedNode.Tag;
					//
					DialogResult oDlg = MessageBox.Show("Esta seguro de mover el " +
						 Environment.NewLine + "nodo/estructura { " + oDTO.Descripcion + " } " +
						 Environment.NewLine + "al " +
						 Environment.NewLine + "nodo/estructura { " + oDTOP.Descripcion + " }", NewConsolidado.Properties.Settings.Default.appTituloAplicacion, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
					if (oDlg == DialogResult.Yes)
					{
						if (ValidaMovimientoNodo(oDTO, oDTOP))
						{

							// Remove the node from its current 
							// location and add it to the node at the drop location.
							draggedNode.Remove();
							targetNode.Nodes.Add(draggedNode);
							// Expand the node at the location 
							// to show the dropped node.
							targetNode.Expand();

							oDTO.IdPadre = oDTOP.IdRegistro;
							draggedNode.Tag = oDTO;
							oBO.GrabarDatosConsolidado((int)CFG.ToolAcciones.Editar, oDTO);
						}
					}
				}
				catch (Exception Ex)
				{
					hLog.msgFatal(Ex.Message);
				}
			}
		}
        private void BotonCambiarUsuarioDuenio()
        {
            try
			{
				DTOConsolidados oDTO = new DTOConsolidados();
                oDTO = (DTOConsolidados)treeConsolidados.SelectedNode.Tag;
                BOConsolidados oBO = new BOConsolidados();
                oBO.CambiaUsuarioEstructura(oDTO.IdRegistro, textDueño.Text);

                BotonRefrescarArbol();

                hLog.msgInfo("Usuario dueño cambiado satisfactoriamente");
            }
            catch (Exception ex)
            {
                hLog.msgFatal(ex.Message);
            }
        }
	}
}
