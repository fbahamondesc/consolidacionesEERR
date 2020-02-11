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
	class DAOSaldosContables
	{
		private MyLog4Net hLog = new MyLog4Net("DAOSaldosContables.class");

		public List<DTOSaldosContables> ConsultaSaldosContables(
			string sIdCompania
			, string sCuenta
			, string sPeriodo
			, int iOrigen
			, string sLibro
			)
		{
			try
			{
				string sSql = "Select SC.IdCompania";
				sSql += "      , SC.IdRegistro";
				sSql += "      , SC.IdCuenta";
				sSql += "      , SC.Periodo";
				sSql += "      , SC.Origen";
				sSql += "      , SC.Libro";
				sSql += "      , SC.Debito";
				sSql += "      , SC.Credito";
				sSql += "      , CO.Nombre NombreCompania";
				sSql += "      , MC.Descripcion DescripcionCuenta";
				sSql += "      , MC.Tipo TipoCuenta";
				sSql += " From  EERR_Tbl_Saldos_Contables SC, EERR_Tbl_Companias CO, EERR_Tbl_Maestro_Cuentas MC";
				sSql += " Where 1=1";
				sSql += " And SC.IdCompania = CO.IdCompania";
				sSql += " And SC.IdCuenta = MC.IdCuenta";
				if (sIdCompania != "")
				{
					sSql += " And SC.IdCompania = '" + sIdCompania +"'";
				}
				if (sCuenta != "")
				{
					sSql += " And SC.IdCuenta = '" + sCuenta + "'";
				}
				if (sPeriodo != "")
				{
					sSql += " And SC.Periodo = '" + sPeriodo + "'";
				}
				if (iOrigen > -1)
				{
					sSql += " And SC.Origen = " +iOrigen;
				}
				if (sLibro != "")
				{
					sSql += " And SC.Libro = '" + sLibro + "'";
				}
				hLog.Debug("Query de lectura de Saldos Contables {" + sSql + "}");
				List<DTOSaldosContables> lDTO = new List<DTOSaldosContables>();
				//
				DataSet dsContenedor = new DataSet();
				Conexion oCon = new Conexion();
				dsContenedor = oCon.CargarRecordConDatos(sSql);
				//
				foreach (DataRow registro in dsContenedor.Tables[sSql].Rows)
				{
					DTOSaldosContables DTO = new DTOSaldosContables();
					DTO.IdRegistro = int.Parse(registro["IdRegistro"].ToString());
					DTO.IdCompania = registro["IdCompania"].ToString();
					DTO.IdCuenta = registro["IdCuenta"].ToString();
					DTO.Periodo = registro["Periodo"].ToString();
					DTO.Origen = int.Parse(registro["Origen"].ToString());
					DTO.Libro = registro["Libro"].ToString();
					DTO.Debito = decimal.Parse(registro["Debito"].ToString());
					DTO.Credito = decimal.Parse(registro["Credito"].ToString());
					DTO.NombreCompania = registro["NombreCompania"].ToString();
					DTO.DescripcionCuenta = registro["DescripcionCuenta"].ToString();
					DTO.TipoCuenta = registro["TipoCuenta"].ToString();
					lDTO.Add(DTO);
				}

				return lDTO;
			}
			catch (Exception ex)
			{
				string sMensaje = "Error al leer los datos de la tabla {" + ex.Source + "}{" + ex.Message + "}";
				hLog.Fatal(sMensaje);
				throw new SystemException(sMensaje);
			}
		}
		public void CrearSaldos(
			List<DTOSaldosContables> lSaldos
			)
		{
			try
			{
				string sSql = "";
				ArrayList aSql = new ArrayList();
				foreach (DTOSaldosContables oDTO in lSaldos)
				{
					sSql = "";
					sSql += "Insert into EERR_Tbl_Saldos_Contables (";
					sSql += " IdCompania";
					sSql += " ,IdCuenta";
					sSql += " ,Periodo";
					sSql += " ,Origen";
					sSql += " ,Libro";
					sSql += " ,Debito";
					sSql += " ,Credito";
					sSql += ") values (";
					sSql += "  '" + oDTO.IdCompania.ToString().Trim()+"'";
					sSql += ", '" + oDTO.IdCuenta.ToString().Trim() + "'";
					sSql += ", '" + oDTO.Periodo.ToString().Trim()+"'";
					sSql += ", '" + oDTO.Origen.ToString().Trim() + "'";
					sSql += ", '" + oDTO.Libro.ToString().Trim() + "'";
					sSql += ", " + oDTO.Debito.ToString().Trim();
					sSql += ", " + oDTO.Credito.ToString().Trim();
					sSql += ")";
					aSql.Add(sSql);
				}
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
		public void EditarSaldos(
			List<DTOSaldosContables> lSaldos
			)
		{
			try
			{
				ArrayList aSql = new ArrayList();
				foreach (DTOSaldosContables oDTO in lSaldos)
				{
					string sSql = "";
					sSql += "Update EERR_Tbl_Saldos_Contables Set";
					sSql += "  Debito = " + oDTO.Debito.ToString();
					sSql += " ,Credito = " + oDTO.Credito.ToString();
					sSql += " Where 1=1";
					sSql += " And IdRegistro = " + oDTO.IdRegistro.ToString();
					aSql.Add(sSql);
				}
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
		public void EliminarSaldos(
			List<DTOSaldosContables> lSaldos
			)
		{
			try
			{
				ArrayList aSql = new ArrayList();
				foreach (DTOSaldosContables oDTO in lSaldos)
				{
					string sSql = "";
					sSql += "Delete from EERR_Tbl_Saldos_Contables";
					sSql += " Where 1=1";
					sSql += " And IdRegistro = " + oDTO.IdRegistro.ToString();
					aSql.Add(sSql);
				}
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
		public DTOSaldosContables ConsultaSaldosAcumulados(
			string sIdCompania
			, string sPeriodo
			, string sIdCuenta
			)
		{

			try
			{
				string sSql = "";
				sSql += "Select Sum(Debito) Debito, Sum(Credito) Credito";
				sSql += "	From EERR_Tbl_Saldos_Contables";
				sSql += "	Where 1 = 1";
				if (sIdCompania != "")
				{
					sSql += " And idCompania = '" + sIdCompania + "'";
				}
				if (sPeriodo != "")
				{
					sSql += " And Periodo = '" + sPeriodo + "'";
				}
				if (sIdCuenta != "")
				{
					sSql += " And idCuenta = '" + sIdCuenta + "'";
				}
				sSql += "	Group by Periodo";
				hLog.Debug("Query de lectura de Saldos Contables {" + sSql + "}");
				DTOSaldosContables oDTO = new DTOSaldosContables();
				//
				DataSet dsContenedor = new DataSet();
				Conexion oCon = new Conexion();
				dsContenedor = oCon.CargarRecordConDatos(sSql);
				//
				foreach (DataRow registro in dsContenedor.Tables[sSql].Rows)
				{
					oDTO.Debito = decimal.Parse(registro["Debito"].ToString());
					oDTO.Credito = decimal.Parse(registro["Credito"].ToString());
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
