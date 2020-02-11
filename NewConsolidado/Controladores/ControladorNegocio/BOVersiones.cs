using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NewConsolidado.Controladores.Clases;
using NewConsolidado.Modelos.AccesoDatos;
using NewConsolidado.Modelos.TransporteDatos;

namespace NewConsolidado.Controladores.ControladorNegocio
{
	class BOVersiones
	{
		private MyLog4Net hLog = new MyLog4Net("BOVersiones.class");

		public DTOVersiones ConsultaUltimaVersion()
		{
			try
			{
				DAOVersiones oDAO = new DAOVersiones();
				return oDAO.ConsultaUltimaVersion();
			}
			catch (Exception ex)
			{
				hLog.Fatal(ex.Message);
				throw new SystemException(ex.Message);
			}
		}
		public Boolean EstadoVersionApp(string sVersion)
		{
			try
			{
				DTOVersiones oDTO = new DTOVersiones();
				DAOVersiones oDAO = new DAOVersiones();
				oDTO = oDAO.ConsultaVersion(sVersion);
				if (oDTO != null)
				{
					if (oDTO.Estado == (int)CFG.EstadoVersion.Vigente)
					{
						return true;
					}
					else
					{
						return false;
					}
				}
				else
				{
					return false;
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
