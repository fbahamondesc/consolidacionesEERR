using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NewConsolidado.Controladores.Clases;
using NewConsolidado.Modelos.AccesoDatos;
using NewConsolidado.Modelos.TransporteDatos;

namespace NewConsolidado.Controladores.ControladorNegocio
{
	class BOConfiguracionAjustesAutomaticos
	{

		private MyLog4Net hLog = new MyLog4Net("BOConfiguracionAjustesAutomaticos.class");

		public List<DTOConfiguracionAjustesAutomaticos> ConsultaConfiguracionAjustesAutomaticos()
		{
			try
			{
				return ConsultaConfiguracionAjustesAutomaticos("","");
			}
			catch (Exception ex)
			{
				hLog.Fatal(ex.Message);
				throw new SystemException(ex.Message);
			}
		}
		public List<DTOConfiguracionAjustesAutomaticos> ConsultaConfiguracionAjustesAutomaticos(
			string sIdCompania
			)
		{
			try
			{
				return ConsultaConfiguracionAjustesAutomaticos(sIdCompania, "");
			}
			catch (Exception ex)
			{
				hLog.Fatal(ex.Message);
				throw new SystemException(ex.Message);
			}
		}
		public List<DTOConfiguracionAjustesAutomaticos> ConsultaConfiguracionAjustesAutomaticos(
			string sIdCompania
			, string sCuentaOrigen
			)
		{
			try
			{
				DAOConfiguracionAjustesAutomaticos oDAO = new DAOConfiguracionAjustesAutomaticos();
				return oDAO.ConsultaConfiguracionAjustesAutomaticos(sIdCompania, sCuentaOrigen);
			}
			catch (Exception ex)
			{
				hLog.Fatal(ex.Message);
				throw new SystemException(ex.Message);
			}
		}
		public List<DTOConfiguracionAjustesAutomaticos> ConsultaCuentasOrigen()
		{
			try
			{
				DAOConfiguracionAjustesAutomaticos oDAO = new DAOConfiguracionAjustesAutomaticos();
				return oDAO.ConsultaCuentasOrigen();
			}
			catch (Exception ex)
			{
				hLog.Fatal(ex.Message);
				throw new SystemException(ex.Message);
			}
		}
		public void GrabarRegistro(
			List<DTOConfiguracionAjustesAutomaticos> lDTO
			, int iAccion
			)
		{
			try
			{
				List<DTOConfiguracionAjustesAutomaticos> lBusca = new List<DTOConfiguracionAjustesAutomaticos>();
				DAOConfiguracionAjustesAutomaticos oDAO = new DAOConfiguracionAjustesAutomaticos();
				switch (iAccion)
				{
					case (int)CFG.ToolAcciones.Nuevo:
						{
							lBusca = oDAO.ConsultaConfiguracionAjustesAutomaticos(lDTO[0].idCompania.ToString(), lDTO[0].CuentaOrigen.ToString());
							if (lBusca.Count == 0)
							{
								oDAO.Crear(lDTO);
							}
							else
							{
								string sTexto = "Ya existe un registro para compañia y cuenta de origen";
								hLog.Fatal(sTexto);
								throw new SystemException(sTexto);
							}
							break;
						}
					case (int)CFG.ToolAcciones.Editar:
						{
							lBusca = oDAO.ConsultaConfiguracionAjustesAutomaticos(lDTO[0].idCompania.ToString(), lDTO[0].CuentaOrigen.ToString());
							if (lBusca.Count == 1)
							{
								oDAO.Editar(lDTO);
							}
							else
							{
								string sTexto = "No existe registro para compañia y cuenta de origen";
								hLog.Fatal(sTexto);
								throw new SystemException(sTexto);
							}
							break;
						}
					case (int)CFG.ToolAcciones.Eliminar:
						{
							lBusca = oDAO.ConsultaConfiguracionAjustesAutomaticos(lDTO[0].idCompania.ToString(), lDTO[0].CuentaOrigen.ToString());
							if (lBusca.Count == 1)
							{
								oDAO.Eliminar(lDTO);
							}
							else
							{
								string sTexto = "No existe registro para compañia y cuenta de origen";
								hLog.Fatal(sTexto);
								throw new SystemException(sTexto);
							}
							break;
						}
					default:
						{
							hLog.Fatal("Mala clasificacion al {GrabarRegistro}");
							throw new SystemException("Mala clasificacion al {GrabarRegistro}");
							
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
