using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;


using NewConsolidado.Controladores.Clases;
using NewConsolidado.Modelos.AccesoDatos;
using NewConsolidado.Modelos.TransporteDatos;

namespace NewConsolidado.Controladores.ControladorNegocio
{
	class BOMaestroLibros
	{
		private MyLog4Net hLog = new MyLog4Net("BOMaestroLibros.class");

		public string[] ConsultaMaestroLibros()
		{
			try
			{
				DAOMaestroLibros oDAO = new DAOMaestroLibros();
				List<DTOMaestroLibros> lDTO = new List<DTOMaestroLibros>();
				string sLista = "";
				string sSep = "";
				lDTO = oDAO.ConsultaMaestroLibros();
				foreach (DTOMaestroLibros oDTO in lDTO)
				{
					sLista += sSep + oDTO.Libro;
					sSep = ",";
				}
				return sLista.Split(',');
			}
			catch (Exception ex)
			{
				hLog.Fatal(ex.Message);
				throw new SystemException(ex.Message);
			}
		}

	}
}
