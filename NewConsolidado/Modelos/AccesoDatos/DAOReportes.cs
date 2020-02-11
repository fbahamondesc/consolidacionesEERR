using System;
using System.Collections.Generic;
using System.Data;

using NewConsolidado.Controladores.Clases;
using NewConsolidado.Modelos.TransporteDatos;

namespace NewConsolidado.Modelos.AccesoDatos
{
	class DAOReportes
	{
		private MyLog4Net hLog = new MyLog4Net("DAOReportes.class");

		public DataSet EjecutaProcedimientoReporteERF(
			int hIdConsolidado
			, string hPeriodo
			, int hIdConsolidadoComparar
			, string hPeriodoComparar
			, string hLibro
			)
		{
			try
			{
				return EjecutaProcedimientoReporte("EERR_Sp_Reporte_ERF_Genera", hIdConsolidado, hPeriodo, hIdConsolidadoComparar, hPeriodoComparar, hLibro);
			}
			catch (Exception ex)
			{
				hLog.Fatal(ex.Message);
				throw new SystemException(ex.Message);
			}
		}
		public DataSet EjecutaProcedimientoReporteERFSuper(
			int hIdConsolidado
			, string hPeriodo
			, int hIdConsolidadoComparar
			, string hPeriodoComparar
			, string hLibro
			)
		{
			try
			{
				return EjecutaProcedimientoReporte("EERR_Sp_Reporte_ERFSuper_Genera", hIdConsolidado, hPeriodo, hIdConsolidadoComparar, hPeriodoComparar, hLibro);
			}
			catch (Exception ex)
			{
				hLog.Fatal(ex.Message);
				throw new SystemException(ex.Message);
			}
		}
		public DataSet EjecutaProcedimientoReporteESF(
			int hIdConsolidado
			, string hPeriodo
			, int hIdConsolidadoComparar
			, string hPeriodoComparar
			, string hLibro
			)
		{
			try
			{
				return EjecutaProcedimientoReporte("EERR_Sp_Reporte_ESF_Genera", hIdConsolidado, hPeriodo, hIdConsolidadoComparar, hPeriodoComparar, hLibro);
			}
			catch (Exception ex)
			{
				hLog.Fatal(ex.Message);
				throw new SystemException(ex.Message);
			}
		}
		public DataSet EjecutaProcedimientoReporteESFSuper(
			int hIdConsolidado
			, string hPeriodo
			, int hIdConsolidadoComparar
			, string hPeriodoComparar
			, string hLibro
			)
		{
			try
			{
				return EjecutaProcedimientoReporte("EERR_Sp_Reporte_ESFSuper_Genera", hIdConsolidado, hPeriodo, hIdConsolidadoComparar, hPeriodoComparar, hLibro);
			}
			catch (Exception ex)
			{
				hLog.Fatal(ex.Message);
				throw new SystemException(ex.Message);
			}
		}
		private DataSet EjecutaProcedimientoReporte(
			string sProcedimiento
			, int hIdConsolidado
			, string hPeriodo
			, int hIdConsolidadoComparar
			, string hPeriodoComparar
			, string hLibro
			)
		{
			try
			{
				string sTexto = "Ejecutamos procedimiento almacenado reporte con parametros";
				sTexto += " Procedimiento {" + sProcedimiento + "}";
				sTexto += " IdConsolidado {" + hIdConsolidado + "}";
				sTexto += " Periodo {" + hPeriodo +"}";
				sTexto += " IdConsolidadoComparar {" + hIdConsolidadoComparar + "}";
				sTexto += " PeriodoComparar {"+ hPeriodoComparar + "}";
				sTexto += " Libro {" + hLibro + "}";
				hLog.Debug(sTexto);

				DataSet dsContenedor = new DataSet();
				List<DTOReporteERF> lDTO = new List<DTOReporteERF>();

				Conexion oCon = new Conexion();
				dsContenedor = oCon.EjecucionProcedimientoReportes(sProcedimiento, hIdConsolidado, hPeriodo, hIdConsolidadoComparar, hPeriodoComparar, hLibro);
				if (dsContenedor.Tables.Count > 0)
				{
					hLog.Debug("Total de registros {" + dsContenedor.Tables[0].Rows.Count.ToString() + "}");
				}
				return dsContenedor;
			}
			catch (Exception ex)
			{
				string sMensaje = "Error al leer los datos de la tabla {" + ex.Source + "}{" + ex.Message + "}";
				hLog.Fatal(sMensaje);
				throw new SystemException(sMensaje);
			}
		}
	}
}
