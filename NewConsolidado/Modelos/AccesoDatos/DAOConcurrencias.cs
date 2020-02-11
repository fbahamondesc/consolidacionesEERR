using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using NewConsolidado.Controladores.Clases;
using NewConsolidado.Modelos.TransporteDatos;

namespace NewConsolidado.Modelos.AccesoDatos
{
	class DAOConcurrencias
	{
		private MyLog4Net hLog = new MyLog4Net("DAOConcurrencias.class");

		public DTOConcurrencias ConsultaConcurrencias(
			string sCodigo
			)
		{
			try
			{
				string sSql = "";
				sSql += "Select ";
				sSql += "  KeyConcurrencia";
				sSql += ", ValueConcurrencia";
				sSql += " From EERR_Tbl_Concurrencias";
				sSql += " Where 1=1";
				if (sCodigo != "")
				{
					sSql += " And KeyConcurrencia = '" + sCodigo + "'";
				}
				//hLog.Debug("Query de lectura de Concurrencias {" + sSql + "}");
				//
				DataSet dsContenedor = new DataSet();
				Conexion oCon = new Conexion();
				dsContenedor = oCon.CargarRecordConDatos(sSql);
				//
				DTOConcurrencias oDTO = new DTOConcurrencias();
				foreach (DataRow registro in dsContenedor.Tables[sSql].Rows)
				{
					oDTO.KeyConcurrencia = registro["KeyConcurrencia"].ToString();
					oDTO.ValueConcurrencia = int.Parse(registro["ValueConcurrencia"].ToString());
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
		public void CreaConcurrencia(DTOConcurrencias oDTO)
		{
			string sSql = "";
			ArrayList aSql = new ArrayList();

			try
			{
				sSql = " Insert into EERR_Tbl_Concurrencias ( ";
				sSql += "  KeyConcurrencia";
				sSql += ", ValueConcurrencia";
				sSql += " ) Values ( ";
				sSql += " '" + oDTO.KeyConcurrencia + "'";
				sSql += ",'" + oDTO.ValueConcurrencia + "'";
				sSql += ")";
				aSql.Add(sSql);
				//hLog.Debug("Crear Concurrencia {" + sSql + "}");
				Conexion oCon = new Conexion();
				oCon.EjecucionComandosSql(aSql);
			}
			catch (Exception ex)
			{
				string sMensaje = "Error al insertar Concurrencia {" + ex.Source + "}{" + ex.Message + "}";
				hLog.Fatal(sMensaje);
				throw new SystemException(sMensaje);
			}
		}
		public void EliminaConcurrencia(DTOConcurrencias oDTO)
		{
			string sSql = "";
			ArrayList aSql = new ArrayList();

			try
			{
				sSql += "Delete from EERR_Tbl_Concurrencias";
				sSql += " Where KeyConcurrencia = '" + oDTO.KeyConcurrencia + "'";
				aSql.Add(sSql);
				//hLog.Debug("Eliminar Concurrencia {" + sSql + "}");
				Conexion oCon = new Conexion();
				oCon.EjecucionComandosSql(aSql);
			}
			catch (Exception ex)
			{
				string sMensaje = "Error al Eliminar Concurrencia {" + ex.Source + "}{" + ex.Message + "}";
				hLog.Fatal(sMensaje);
				throw new SystemException(sMensaje);
			}
		}
		public void LiberaConcurrencia()
		{
			string sSql = "";
			ArrayList aSql = new ArrayList();

			try
			{
				sSql += "Delete from EERR_Tbl_Concurrencias";
				sSql += " Where KeyConcurrencia <> 'Dynamics'";
				aSql.Add(sSql);
				//hLog.Debug("Eliminar Concurrencia {" + sSql + "}");
				Conexion oCon = new Conexion();
				oCon.EjecucionComandosSql(aSql);
			}
			catch (Exception ex)
			{
				string sMensaje = "Error al Eliminar Concurrencia {" + ex.Source + "}{" + ex.Message + "}";
				hLog.Fatal(sMensaje);
				throw new SystemException(sMensaje);
			}
		}
	}
}
