using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NewConsolidado.Controladores.Clases;
using NewConsolidado.Modelos.AccesoDatos;
using NewConsolidado.Modelos.TransporteDatos;

namespace NewConsolidado.Controladores.ControladorNegocio
{
	class BOSaldosContables
	{
		private MyLog4Net hLog = new MyLog4Net("BOSaldosContables.class");

		public BOSaldosContables()
		{
		}

		public List<DTOSaldosContables> ConsultaAjustesConsolidado(
			string sIdCompania
			, string sCuenta
			, string sPeriodo
			)
		{
			try
			{
				return ConsultaAjustesConsolidado(sIdCompania, sCuenta, sPeriodo, -1, "");
			}
			catch (Exception ex)
			{
				hLog.Fatal(ex.Message);
				throw new SystemException(ex.Message);
			}
		}

		public List<DTOSaldosContables> ConsultaAjustesConsolidado(
			string sIdCompania
			, string sCuenta
			, string sPeriodo
			, int iOrigen
			, string sLibro
			)
		{
			try
			{
				List<DTOSaldosContables> lLista = new List<DTOSaldosContables>();
				DAOSaldosContables oDAO = new DAOSaldosContables();
				//
				hLog.Debug("Consultamos los Saldos Contables");
				lLista = oDAO.ConsultaSaldosContables(sIdCompania, sCuenta, sPeriodo, iOrigen, sLibro);
				return lLista;
			}
			catch (Exception ex)
			{
				hLog.Fatal(ex.Message);
				throw new SystemException(ex.Message);
			}
		}
		public void GrabarSaldos(
			List<DTOSaldosContables> lSaldos
			, int iAccion
			)
		{
			try
			{
				DAOSaldosContables oDAO = new DAOSaldosContables();
				switch (iAccion)
				{
					case (int)CFG.ToolAcciones.Nuevo:
						{
							oDAO.CrearSaldos(lSaldos);
							break;
						}
					case (int)CFG.ToolAcciones.Editar:
						{
							oDAO.EditarSaldos(lSaldos);
							break;
						}
					case (int)CFG.ToolAcciones.Eliminar:
						{
							oDAO.EliminarSaldos(lSaldos);
							break;
						}
					default:
						{
							hLog.Fatal("Mala clasificacion al {GrabarSaldos}");
							throw new SystemException("Mala clasificacion al {GrabarSaldos}");
						}
				}
			}
			catch (Exception ex)
			{
				hLog.Fatal(ex.Message);
				throw new SystemException(ex.Message);
			}
		}
		public DTOSaldosContables ConsultaSaldosAcumulados(
			string sIdCompania
			, string sPeriodo
			, string sIdCuenta
			)
		{
			try
			{
				DAOSaldosContables oDAO = new DAOSaldosContables();
				return oDAO.ConsultaSaldosAcumulados(sIdCompania, sPeriodo, sIdCuenta);
			}
			catch (Exception ex)
			{
				hLog.Fatal(ex.Message);
				throw new SystemException(ex.Message);
			}
		}
	}
}
