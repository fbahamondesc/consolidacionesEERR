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

namespace NewConsolidado.Vistas.Reportes.ERF
{
	public partial class EstadoResultado : Form
	{
		private MyLog4Net hLog = new MyLog4Net("EstadoResultado.Form");

		private int hIdConsolidado = 0;
		private string hPeriodo = "";
		private int hIdConsolidadoComparar = 0;
		private string hPeriodoComparar = "";
		private string hLibro = "";

		public int IdConsolidado
		{
			get { return hIdConsolidado; }
			set { hIdConsolidado = value; }
		}
		public string Periodo
		{
			get { return hPeriodo; }
			set { hPeriodo = value; }
		}
		public int IdConsolidadoComparar
		{
			get { return hIdConsolidadoComparar; }
			set { hIdConsolidadoComparar = value; }
		}
		public string PeriodoComparar
		{
			get { return hPeriodoComparar; }
			set { hPeriodoComparar = value; }
		}
		public string Libro
		{
			get { return hLibro; }
			set { hLibro = value; }
		}
		//------------------------------------------------------------------------------------------------------------------
		// 
		//------------------------------------------------------------------------------------------------------------------
		public EstadoResultado()
		{
			InitializeComponent();
			//
            this.Text = "Estado de Resultado por Función - ERF";
			//
		}
		private void EstadoResultado_Shown(object sender, EventArgs e)
		{
			CalculoDatos();
		}
		//------------------------------------------------------------------------------------------------------------------
		// Metodos privados
		//------------------------------------------------------------------------------------------------------------------
		private void CalculoDatos()
		{
			this.Cursor = Cursors.WaitCursor;
			try
			{
				dtsEstadoResultado dstEstado = new dtsEstadoResultado();
				DataSet dsResultado = new DataSet();
				List<DTOReporteERF> lDTO = new List<DTOReporteERF>();
				BOReportes oRep = new BOReportes();

				hLog.Debug("idConsolidado {" + hIdConsolidado.ToString() + "} periodo {" + hPeriodo.ToString() + "} idConsolidadoComparar {" + hIdConsolidadoComparar.ToString() + "} PeriodoComparar {" + hPeriodoComparar.ToString() + "} Libros {" + hLibro.ToString() + "}");

				dsResultado = oRep.EjecutaReporteERF(hIdConsolidado, hPeriodo, hIdConsolidadoComparar, hPeriodoComparar, hLibro);
				if (dsResultado.Tables.Count > 0)
				{
					dstEstado.Tables[0].Merge(dsResultado.Tables[0]);
					hLog.Debug("Cantidad de registros a enviar al Reporte {" + dsResultado.Tables[0].Rows.Count + "}");

					// Creacion del reporte y la carga del dataset
					rptEstadoResultado oRpt = new rptEstadoResultado();
					oRpt.SetDataSource(dstEstado);
					crystalReportViewer1.ReportSource = oRpt;
				}
				else
				{
					hLog.msgAlerta("No existen datos para mostrar en el informe");
				}
			}
			catch (Exception ex)
			{
				hLog.msgFatal(ex.Message);
			}
			this.Cursor = Cursors.Default;
		}
	}
}
