using System;
using System.Collections.Generic;

using NewConsolidado.Controladores.Clases;
using NewConsolidado.Modelos.AccesoDatos;
using NewConsolidado.Modelos.TransporteDatos;


namespace NewConsolidado.Controladores.ControladorNegocio
{
	class BOCompanias
	{
		private MyLog4Net hLog = new MyLog4Net("BOCompanias.class");

		public BOCompanias()
		{
		}

		public List<DTOCompanias> ConsultaCompanias()
		{
			try
			{
				return ConsultaCompanias("", "");
			}
			catch (Exception ex)
			{
				hLog.Fatal(ex.Message);
				throw new SystemException(ex.Message);
			}
		}
		public List<DTOCompanias> ConsultaCompanias(
			int iOrigen
			)
		{
			try
			{
				return ConsultaCompanias("", iOrigen.ToString());
			}
			catch (Exception ex)
			{
				hLog.Fatal(ex.Message);
				throw new SystemException(ex.Message);
			}
		}
		public List<DTOCompanias> ConsultaCompanias(
			string sCompania
			)
		{
			try
			{
				return ConsultaCompanias(sCompania, "");
			}
			catch (Exception ex)
			{
				hLog.Fatal(ex.Message);
				throw new SystemException(ex.Message);
			}
		}
		public List<DTOCompanias> ConsultaCompanias(
			string sCompania
			, int iOrigen
			)
		{
			try
			{
				return ConsultaCompanias(sCompania, iOrigen.ToString());
			}
			catch (Exception ex)
			{
				hLog.Fatal(ex.Message);
				throw new SystemException(ex.Message);
			}
		}
		private List<DTOCompanias> ConsultaCompanias(
			string sCodigo
			, string sTipo
			)
		{
			try
			{
				List<DTOCompanias> oDto = new List<DTOCompanias>();
				DAOCompanias oDao = new DAOCompanias();
				oDto = oDao.ConsultaCompañias(sCodigo, sTipo);

				return oDto;
			}
			catch (Exception ex)
			{
				hLog.Fatal(ex.Message);
				throw new SystemException(ex.Message);
			}
		}
		public void GrabarCompania(
			int hiAccion
			, DTOCompanias oDTO
			)
		{
			try
			{
				DAOCompanias oDAO = new DAOCompanias();
				switch (hiAccion)
				{
					case (int)CFG.ToolAcciones.Nuevo:
						{
							oDAO.CrearCompania(oDTO);
							break;
						}
					case (int)CFG.ToolAcciones.Editar:
						{
							oDAO.EditarCompania(oDTO);
							break;
						}
					case (int)CFG.ToolAcciones.Eliminar:
						{
							oDAO.EliminarCompania(oDTO);
							break;
						}
					default:
						{
							hLog.Fatal("Mala clasificacion al {GrabarCompania}");
							throw new SystemException("Mala clasificacion al {GrabarCompania}");
							
						}
				}
			}
			catch (Exception ex)
			{
				hLog.Fatal(ex.Message);
				throw new SystemException(ex.Message);
			}
		}
	}
}
