using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NewConsolidado.Controladores.Clases;
using NewConsolidado.Modelos.AccesoDatos;
using NewConsolidado.Modelos.TransporteDatos;

namespace NewConsolidado.Controladores.ControladorNegocio
{
	class BOAsociacionGrupo
	{
		private MyLog4Net hLog = new MyLog4Net("BOAsociacionGrupo.class");

		public BOAsociacionGrupo()
		{
		}

		public List<DTOAsociacionGrupos> ConsultaAsociacion(
			)
		{
			try
			{
				return ConsultaAsociacion("", "", "", "");
			}
			catch (Exception ex)
			{
				hLog.Fatal(ex.Message);
				throw new SystemException(ex.Message);
			}
		}
		public List<DTOAsociacionGrupos> ConsultaAsociacion(
			string sidRegistro
			)
		{
			try
			{
				return ConsultaAsociacion(sidRegistro, "", "", "");
			}
			catch (Exception ex)
			{
				hLog.Fatal(ex.Message);
				throw new SystemException(ex.Message);
			}
		}
		public List<DTOAsociacionGrupos> ConsultaAsociacion(
			string sIdGrupo
			, string sIdConcepto
			, string sIdCuenta
			)
		{
			try
			{
				return ConsultaAsociacion("", sIdGrupo, sIdConcepto, sIdCuenta);
			}
			catch (Exception ex)
			{
				hLog.Fatal(ex.Message);
				throw new SystemException(ex.Message);
			}
		}
		public List<DTOAsociacionGrupos> ConsultaAsociacion(
			string sIdRegistro
			, string sIdGrupo
			, string sIdConcepto
			, string sIdCuenta
			)
		{
			try
			{
				List<DTOAsociacionGrupos> lLista = new List<DTOAsociacionGrupos>();
				DAOAsociacionGrupo oDAO = new DAOAsociacionGrupo();
				//
				hLog.Debug("Consultamos Asociaciones de Grupo/Concepto/Cuenta");
				lLista = oDAO.ConsultaAsociacion(sIdRegistro, sIdGrupo, sIdConcepto, sIdCuenta);
				return lLista;
			}
			catch (Exception ex)
			{
				hLog.Fatal(ex.Message);
				throw new SystemException(ex.Message);
			}
		}
		public void GrabarAjustes(
			List<DTOAsociacionGrupos> lAsocia
			, int iAccion
			)
		{
			try
			{
				DAOAsociacionGrupo oDAO = new DAOAsociacionGrupo();

				switch (iAccion)
				{
					case (int)CFG.ToolAcciones.Nuevo:
						{
							oDAO.CrearAsociacion(lAsocia);
							break;
						}
					case (int)CFG.ToolAcciones.Editar:
						{
							oDAO.EditarAsociacion(lAsocia);
							break;
						}
					case (int)CFG.ToolAcciones.Eliminar:
						{
							oDAO.EliminarAsociacion(lAsocia);
							break;
						}
					default:
						{
							hLog.Fatal("Mala clasificacion al {GrabarAjustes}");
							throw new SystemException("Mala clasificacion al {GrabarAjustes}");
							
						}
				}
			}
			catch (Exception ex)
			{
				hLog.Fatal(ex.Message);
				throw new SystemException(ex.Message);
			}
		}
		public void CrearAsociacion(
			List<DTOAsociacionGrupos> lAsocia
			)
		{
			try
			{
				DAOAsociacionGrupo oDAO = new DAOAsociacionGrupo();
				oDAO.CrearAsociacion(lAsocia);
			}
			catch (Exception ex)
			{
				hLog.Fatal(ex.Message);
				throw new SystemException(ex.Message);
			}
		}
		public void EditarAsociacion(
			List<DTOAsociacionGrupos> lAsocia
			)
		{
			try
			{
				DAOAsociacionGrupo oDAO = new DAOAsociacionGrupo();
				oDAO.EditarAsociacion(lAsocia);
			}
			catch (Exception ex)
			{
				hLog.Fatal(ex.Message);
				throw new SystemException(ex.Message);
			}
		}
		public void EliminarAsociacion(
			List<DTOAsociacionGrupos> lAsocia
			)
		{
			try
			{
				DAOAsociacionGrupo oDAO = new DAOAsociacionGrupo();
				oDAO.EliminarAsociacion(lAsocia);
			}
			catch (Exception ex)
			{
				hLog.Fatal(ex.Message);
				throw new SystemException(ex.Message);
			}
		}
	}
}
