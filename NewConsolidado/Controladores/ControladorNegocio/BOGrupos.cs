using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NewConsolidado.Controladores.Clases;
using NewConsolidado.Modelos.AccesoDatos;
using NewConsolidado.Modelos.TransporteDatos;


namespace NewConsolidado.Controladores.ControladorNegocio
{
	class BOGrupos
	{
		private MyLog4Net hLog = new MyLog4Net("BOGrupos.class");

		public BOGrupos()
		{
		}

		public List<DTOGrupos> ConsultaGrupos()
		{
			try
			{
				return ConsultaGrupos(-1, "");
			}
			catch (Exception ex)
			{
				hLog.Fatal(ex.Message);
				throw new SystemException(ex.Message);
			}
		}
		public List<DTOGrupos> ConsultaGrupos(
			int iIDGrupo
			, string sCodigo
			)
		{
			try
			{
				List<DTOGrupos> lDTO = new List<DTOGrupos>();
				DAOGrupos oDAO = new DAOGrupos();
				hLog.Debug("Consultamos los conceptos");
				lDTO = oDAO.ConsultaGrupos(iIDGrupo, "");
				return lDTO;
			}
			catch (Exception ex)
			{
				hLog.Fatal(ex.Message);
				throw new SystemException(ex.Message);
			}
		}
		public void GrabarGrupo(
			int iAccion
			,DTOGrupos oDTO

			)
		{
			try
			{
				DAOGrupos oDAO = new DAOGrupos();
				switch (iAccion)
				{
					case (int)CFG.ToolAcciones.Nuevo:
						{
							oDAO.CrearGrupo(oDTO);
							break;
						}
					case (int)CFG.ToolAcciones.Editar:
						{
							oDAO.EditarGrupo(oDTO);
							break;
						}
					case (int)CFG.ToolAcciones.Eliminar:
						{
							oDAO.EliminarGrupo(oDTO);
							break;
						}
					default:
						{
							hLog.Fatal("Mala clasificacion al {GrabarGrupo}");
							throw new SystemException("Mala clasificacion al {GrabarGrupo}");
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
