using System;

using NewConsolidado.Controladores.Clases;
using NewConsolidado.Modelos.AccesoDatos;

namespace NewConsolidado.Controladores.ControladorNegocio
{
	class BOEjecutar
	{
		private MyLog4Net hLog = new MyLog4Net("BOEjecutar.class");

		public void EjecutaCarga()
		{
		    try
		    {
					hLog.Debug("lanzamos el procedimiento almacenado EERR_Sp_Carga_Datos_Dynamics");

					DAOEjecutar oDAO = new DAOEjecutar();
					oDAO.EjecutaCarga();
		    }
		    catch (Exception ex)
		    {
		        hLog.Fatal(ex.Message);
		        throw new SystemException(ex.Message);
		    }
		}
	}
}
