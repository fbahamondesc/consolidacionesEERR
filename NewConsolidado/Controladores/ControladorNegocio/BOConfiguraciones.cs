using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NewConsolidado.Controladores.Clases;
using NewConsolidado.Modelos.AccesoDatos;
using NewConsolidado.Modelos.TransporteDatos;

namespace NewConsolidado.Controladores.ControladorNegocio
{
	class BOConfiguraciones
	{
		private MyLog4Net hLog = new MyLog4Net("BOConfiguraciones.class");

		public DTOConfiguraciones ConsultaConfiguraciones(
			string sKeyConfiguracion
			)
		{
			try
			{
				DTOConfiguraciones oDTO = new DTOConfiguraciones();
				DAOConfiguraciones oDAO = new DAOConfiguraciones();
				hLog.Debug("Consultamos las configuraciones");
				return oDTO = oDAO.ConsultaConfiguraciones(sKeyConfiguracion);
			}
			catch (Exception ex)
			{
				hLog.Fatal(ex.Message);
				throw new SystemException(ex.Message);
			}
		}
	}
}
