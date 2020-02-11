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
	class DAOConfiguraciones
	{
		private MyLog4Net hLog = new MyLog4Net("DAOConfiguraciones.class");

		public DTOConfiguraciones ConsultaConfiguraciones(
			string sKeyConfiguracion
			)
		{
			try
			{
				string sSql = "";
				sSql += " Select ";
				sSql += "  IdConfiguracion";
				sSql += ", KeyConfiguracion";
				sSql += ", ValorConfiguracion";
				sSql += " From EERR_Tbl_Configuraciones";
				sSql += " Where 1=1";
				if (sKeyConfiguracion != "")
				{
					sSql += " And KeyConfiguracion = '" + sKeyConfiguracion + "'";
				}
				hLog.Debug("Query de lectura de Configuraciones {" + sSql + "}");
				//List<DTOConfiguraciones> lDTO = new List<DTOConfiguraciones>();
				//
				DataSet dsContenedor = new DataSet();
				Conexion oCon = new Conexion();
				dsContenedor = oCon.CargarRecordConDatos(sSql);
				//
				DTOConfiguraciones oDTO = new DTOConfiguraciones();
				foreach (DataRow registro in dsContenedor.Tables[sSql].Rows)
				{
					oDTO.IdConfiguraciones = int.Parse(registro["IdConfiguracion"].ToString());
					oDTO.KeyConfiguracion = registro["KeyConfiguracion"].ToString();
					oDTO.ValorConfiguracion = registro["ValorConfiguracion"].ToString();
					//lDTO.Add(oDTO);
				}

				return oDTO;
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
