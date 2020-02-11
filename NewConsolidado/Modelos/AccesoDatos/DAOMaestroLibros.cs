using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;


using NewConsolidado.Controladores.Clases;
using NewConsolidado.Modelos.TransporteDatos;

namespace NewConsolidado.Modelos.AccesoDatos
{
	class DAOMaestroLibros
	{
		private MyLog4Net hLog = new MyLog4Net("DAOMaestroLibros.class");

		public List<DTOMaestroLibros> ConsultaMaestroLibros()
		{
			try
			{
				List<DTOMaestroLibros> lstMaestro = new List<DTOMaestroLibros>();
				string sSql = "Select IdLibro, Libro";
				sSql += " From EERR_Tbl_Maestro_Libros";
				sSql += " Where 1=1";
				hLog.Debug("Query de lectura de Maestro de Libros {" + sSql + "}");

				DataSet dsContenedor = new DataSet();

				Conexion oCon = new Conexion();
				dsContenedor = oCon.CargarRecordConDatos(sSql);

				foreach (DataRow registro in dsContenedor.Tables[sSql].Rows)
				{
					DTOMaestroLibros DTO = new DTOMaestroLibros();
					DTO.IdLibro = int.Parse(registro["IdLibro"].ToString());
					DTO.Libro = registro["Libro"].ToString();
					lstMaestro.Add(DTO);
				}

				return lstMaestro;
			}
			catch (Exception ex)
			{
				string sMensaje = "Error al leer los datos de la tabla {" + ex.Source + "}{" + ex.Message + "}";
				hLog.Fatal(sMensaje);
				throw new SystemException(sMensaje);
			}
		}	

	}
}
