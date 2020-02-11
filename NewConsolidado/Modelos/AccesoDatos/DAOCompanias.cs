using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using NewConsolidado.Controladores.Clases;
using NewConsolidado.Modelos.TransporteDatos;

namespace NewConsolidado.Modelos.AccesoDatos
{
	class DAOCompanias
	{
		private MyLog4Net hLog = new MyLog4Net("DAOCompanias.class");

		public List<DTOCompanias> ConsultaCompañias(
			string sCodigo
			, string sTipo
			)
		{
			try
			{
				List<DTOCompanias> lstCompanias = new List<DTOCompanias>();

				string sSql = "Select idCompania";
				sSql += "      ,Nombre";
				sSql += "      ,RUT";
				sSql += "      ,BaseDatos";
				sSql += "      ,CuentaEjercicio";
				sSql += "      ,CuentaAcumulado";
				sSql += "      ,Origen";
				sSql += "      ,Vigencia";
				sSql += " From EERR_Tbl_Companias";
				sSql += " Where 1=1";
				if (sCodigo !="")
				{
					sSql += " And idCompania = '" + sCodigo +"'";
				}
				if (sTipo != "")
				{
					sSql += " And origen = " + sTipo;
				}

				hLog.Debug("Query de lectura de Companias {" + sSql + "}");

				DataSet dsContenedor = new DataSet();

				Conexion oCon = new Conexion();
				dsContenedor = oCon.CargarRecordConDatos(sSql);

				foreach (DataRow registro in dsContenedor.Tables[sSql].Rows)
				{
					DTOCompanias DTO = new DTOCompanias();
					DTO.IdCompania = registro["idCompania"].ToString();
					DTO.Nombre= registro["Nombre"].ToString();
					DTO.RUT = registro["RUT"].ToString();
					DTO.BaseDatos = registro["BaseDatos"].ToString();
					DTO.CuentaEjercicio = registro["CuentaEjercicio"].ToString();
					DTO.CuentaAcumulado = registro["CuentaAcumulado"].ToString();
					DTO.Origen = Convert.ToInt32(registro["Origen"].ToString());
					DTO.Vigencia = Convert.ToInt32(registro["Vigencia"].ToString());
					lstCompanias.Add(DTO);
				}

				return lstCompanias;
			}
			catch (Exception ex)
			{
				string sMensaje = "Error al leer los datos de la tabla {" + ex.Source + "}{" + ex.Message + "}";
				hLog.Fatal(sMensaje);
				throw new SystemException(sMensaje);
			}
		}

		public void CrearCompania(
			DTOCompanias oDTO
			)
		{
			string sSql = "";
			ArrayList aSql = new ArrayList();

			try
			{
				sSql = " Insert into EERR_Tbl_Companias ( ";
				sSql += "  idcompania";
				sSql += ", Nombre";
				sSql += ", RUT";
				sSql += ", BaseDatos";
				sSql += ", CuentaEjercicio";
				sSql += ", CuentaAcumulado";
				sSql += ", Origen";
				sSql += ", Vigencia";
				sSql += " ) Values ( ";
				sSql += " '" + oDTO.IdCompania + "'";
				sSql += ",'" + oDTO.Nombre + "'";
				sSql += ",'" + oDTO.RUT + "'";
				sSql += ",'" + oDTO.BaseDatos + "'";
				sSql += ",'" + oDTO.CuentaEjercicio + "'";
				sSql += ",'" + oDTO.CuentaAcumulado + "'";
				sSql += ", " + oDTO.Origen.ToString();
				sSql += ", " + oDTO.Vigencia.ToString();
				sSql += ")";
				aSql.Add(sSql);
				hLog.Debug("Creamos la cabecera para el asiento {" + sSql + "}");

				Conexion oCon = new Conexion();
				oCon.EjecucionComandosSql(aSql);

			}
			catch (Exception ex)
			{
				string sMensaje = "Error al leer los datos de la tabla {" + ex.Source + "}{" + ex.Message + "}";
				hLog.Fatal(sMensaje);
				throw new SystemException(sMensaje);
			}
		}

		public void EditarCompania(
			DTOCompanias oDTO
			)
		{
			string sSql = "";
			ArrayList aSql = new ArrayList();

			try
			{
				sSql = "update EERR_Tbl_Companias Set";
				sSql += "  Nombre = '" + oDTO.Nombre + "'";
				sSql += ", Rut = '" + oDTO.RUT + "'";
				sSql += ", BaseDatos = '" + oDTO.BaseDatos + "'";
				sSql += ", CuentaEjercicio = '" + oDTO.CuentaEjercicio + "'";
				sSql += ", CuentaAcumulado = '" + oDTO.CuentaAcumulado + "'";
				sSql += ", Origen = " + oDTO.Origen.ToString();
				sSql += ", Vigencia = " + oDTO.Vigencia.ToString();
				sSql += " Where idCompania = '" + oDTO.IdCompania + "'";
				aSql.Add(sSql);

				Conexion oCon = new Conexion();
				oCon.EjecucionComandosSql(aSql);
			}
			catch (Exception ex)
			{
				string sMensaje = "Error al leer los datos de la tabla {" + ex.Source + "}{" + ex.Message + "}";
				hLog.Fatal(sMensaje);
				throw new SystemException(sMensaje);
			}
		}
		public void EliminarCompania(
			DTOCompanias oDTO
			)
		{
			try
			{
				ArrayList aSql = new ArrayList();
				string sSql = "";
				sSql += "Delete from EERR_Tbl_Companias";
				sSql += " Where idCompania = '" + oDTO.IdCompania + "'";
				aSql.Add(sSql);
				Conexion oCon = new Conexion();
				oCon.EjecucionComandosSql(aSql);
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
