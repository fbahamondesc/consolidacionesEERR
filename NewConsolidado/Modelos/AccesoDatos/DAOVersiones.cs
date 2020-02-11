using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

using NewConsolidado.Modelos.TransporteDatos;
using NewConsolidado.Controladores.Clases;

namespace NewConsolidado.Modelos.AccesoDatos
{
	class DAOVersiones
	{
		private MyLog4Net hLog = new MyLog4Net("DAOVersiones.class");

		public DTOVersiones ConsultaUltimaVersion()
		{
			try
			{
				string sSql = "";
				sSql += "  Select id, numero, estado_version from EERR_Tbl_versiones ";
				sSql += "where id = (select max(id) from EERR_Tbl_versiones )";
				hLog.Debug("Query de lectura de mayor version {" + sSql + "}");
				//
				DataSet dsContenedor = new DataSet();
				Conexion oCon = new Conexion();
				dsContenedor = oCon.CargarRecordConDatos(sSql);
				//
				DTOVersiones oDTO = new DTOVersiones();
				foreach (DataRow registro in dsContenedor.Tables[sSql].Rows)
				{
					oDTO.Id = int.Parse(registro["id"].ToString());
					oDTO.Numero = registro["numero"].ToString();
					oDTO.Estado = int.Parse(registro["estado_version"].ToString());
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
		public DTOVersiones ConsultaVersion(string sVersion)
		{
			try
			{
				string sSql = "";
				sSql += "  Select id, numero, estado_version from EERR_Tbl_versiones ";
				sSql += "where 1=1";
				if (sVersion != "")
				{
					sSql += " And numero = '" + sVersion + "'";
				}
				hLog.Debug("Query de lectura de mayor version {" + sSql + "}");
				//
				DataSet dsContenedor = new DataSet();
				Conexion oCon = new Conexion();
				dsContenedor = oCon.CargarRecordConDatos(sSql);
				//
				DTOVersiones oDTO = new DTOVersiones();
				foreach (DataRow registro in dsContenedor.Tables[sSql].Rows)
				{
					oDTO.Id = int.Parse(registro["id"].ToString());
					oDTO.Numero = registro["numero"].ToString();
					oDTO.Estado = int.Parse(registro["estado_version"].ToString());
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
