using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using NewConsolidado.Controladores.Clases;
using NewConsolidado.Modelos.AccesoDatos;
using NewConsolidado.Modelos.TransporteDatos;


namespace NewConsolidado.Controladores.ControladorNegocio
{
	class BOReportes
	{
		private MyLog4Net hLog = new MyLog4Net("BOReportes.class");

		public BOReportes()
		{
		}

		public DataSet EjecutaReporteERF(
			int hIdConsolidado
			, string hPeriodo
			, int hIdConsolidadoComparar
			, string hPeriodoComparar
			, string hLibro
			)
		{
			try
			{
				hLog.Debug("Llamado a ejecucion de procedimiento almacenado para ERF");
				DAOReportes oDAO = new DAOReportes();
				return oDAO.EjecutaProcedimientoReporteERF(hIdConsolidado, hPeriodo, hIdConsolidadoComparar, hPeriodoComparar, hLibro);
			}
			catch (Exception ex)
			{
				hLog.Fatal(ex.Message);
				throw new SystemException(ex.Message);
			}
		}

		public DataSet EjecutaReporteESF(
			int hIdConsolidado
			, string hPeriodo
			, int hIdConsolidadoComparar
			, string hPeriodoComparar
			, string hLibro
			)
		{
			try
			{
				hLog.Debug("Llamado a ejecucion de procedimiento almacenado para ESF");
				DAOReportes oDAO = new DAOReportes();
				return oDAO.EjecutaProcedimientoReporteESF(hIdConsolidado, hPeriodo, hIdConsolidadoComparar, hPeriodoComparar, hLibro);
			}
			catch (Exception ex)
			{
				hLog.Fatal(ex.Message);
				throw new SystemException(ex.Message);
			}
		}
		public DataSet EjecutaReporteERFSuper(
			int hIdConsolidado
			, string hPeriodo
			, int hIdConsolidadoComparar
			, string hPeriodoComparar
			, string hLibro
			)
		{
			try
			{
				hLog.Debug("Llamado a ejecucion de procedimiento almacenado para ERF Super");
				DAOReportes oDAO = new DAOReportes();
				return oDAO.EjecutaProcedimientoReporteERFSuper(hIdConsolidado, hPeriodo, hIdConsolidadoComparar, hPeriodoComparar, hLibro);
			}
			catch (Exception ex)
			{
				hLog.Fatal(ex.Message);
				throw new SystemException(ex.Message);
			}
		}
		public DataSet EjecutaReporteESFSuper(
			int hIdConsolidado
			, string hPeriodo
			, int hIdConsolidadoComparar
			, string hPeriodoComparar
			, string hLibro
			)
		{
			try
			{
				hLog.Debug("Llamado a ejecucion de procedimiento almacenado para ESF Super");
				DAOReportes oDAO = new DAOReportes();
				return oDAO.EjecutaProcedimientoReporteESFSuper(hIdConsolidado, hPeriodo, hIdConsolidadoComparar, hPeriodoComparar, hLibro);
			}
			catch (Exception ex)
			{
				hLog.Fatal(ex.Message);
				throw new SystemException(ex.Message);
			}
		}
	}
}
