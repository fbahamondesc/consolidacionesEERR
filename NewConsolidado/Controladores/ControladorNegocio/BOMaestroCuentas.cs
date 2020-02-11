using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NewConsolidado.Controladores.Clases;
using NewConsolidado.Modelos.AccesoDatos;
using NewConsolidado.Modelos.TransporteDatos;

namespace NewConsolidado.Controladores.ControladorNegocio
{
	class BOMaestroCuentas
	{
		private MyLog4Net hLog = new MyLog4Net("BOMaestroCuentas.class");

		public BOMaestroCuentas()
		{
		}

		public List<DTOMaestroCuentas> ConsultaMaestroCuentas()
		{
			try
			{
				return ConsultaMaestroCuentas("");
			}
			catch (Exception ex)
			{
				hLog.Fatal(ex.Message);
				throw new SystemException(ex.Message);
			}
		}
		public List<DTOMaestroCuentas> ConsultaMaestroCuentas(
			string idCuenta
			)
		{
			try
			{
				List<DTOMaestroCuentas> oDto = new List<DTOMaestroCuentas>();
				DAOMaestroCuentas oDao = new DAOMaestroCuentas();
				oDto = oDao.ConsultaMaestroCuentas(idCuenta);

				return oDto;
			}
			catch (Exception ex)
			{
				hLog.Fatal(ex.Message);
				throw new SystemException(ex.Message);
			}
		}
		public DTOMaestroCuentas ConsultaMaestroCuentasCodigo(
			string idCuenta
			)
		{
			try
			{
				List<DTOMaestroCuentas> lDto = new List<DTOMaestroCuentas>();
				DTOMaestroCuentas oDto = new DTOMaestroCuentas();
				DAOMaestroCuentas oDao = new DAOMaestroCuentas();
				lDto = oDao.ConsultaMaestroCuentas(idCuenta);
				if (lDto != null)
				{
					if (lDto.Count == 1)
					{
						oDto = lDto[0];
					}
				}

				return oDto;
			}
			catch (Exception ex)
			{
				hLog.Fatal(ex.Message);
				throw new SystemException(ex.Message);
			}
		}
		public void GrabarCuenta(
			int hiAccion
			, DTOMaestroCuentas oDTO
			)
		{
			try
			{
				DAOMaestroCuentas oDAO = new DAOMaestroCuentas();
				switch (hiAccion)
				{
					case (int)CFG.ToolAcciones.Nuevo:
						{
							oDAO.CrearCuenta(oDTO);
							break;
						}
					case (int)CFG.ToolAcciones.Editar:
						{
							oDAO.EditarCuenta(oDTO);
							break;
						}
					case (int)CFG.ToolAcciones.Eliminar:
						{
							oDAO.EliminarCuenta(oDTO);
							break;
						}
					default:
						{
							hLog.Fatal("Mala clasificacion al {GrabarCuenta}");
							throw new SystemException("Mala clasificacion al {GrabarCuenta}");
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
