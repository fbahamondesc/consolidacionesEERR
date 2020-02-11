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
	class DAOAsociacionGrupo
	{
		private MyLog4Net hLog = new MyLog4Net("DAOAsociacionGrupo.class");

		public List<DTOAsociacionGrupos> ConsultaAsociacion(
			string sIdRegistro
			, string sIdGrupo
			, string sIdConcepto
			, string sCuenta
			)
		{
			try
			{
				string sSql = "";

				sSql += "Select";
				sSql += "		  GCC.idRegistro";
				sSql += "		, GCC.IdGrupo";
				sSql += "		, MG.Descripcion DescripcionGrupo";
				sSql += "		, GCC.IdConcepto";
				sSql += "		, MCO.Descripcion DescripcionConcepto";
				sSql += "		, GCC.IdCuenta";
				sSql += "		, MCU.descripcion DescripcionCuenta";
				sSql += "	From EERR_TbT_Grupo_Concepto_Cuenta GCC";
				sSql += "		,EERR_Tbl_Maestro_Grupos MG";
				sSql += "		,EERR_Tbl_Maestro_Conceptos MCO";
				sSql += "		,EERR_Tbl_Maestro_Cuentas MCU";
				sSql += "	Where 1=1";
				sSql += "	And GCC.IdGrupo = MG.Codigo";
				sSql += "	And GCC.IdConcepto = MCO.Codigo";
				sSql += "	And GCC.IdCuenta = MCU.IdCuenta";
				if (sIdRegistro.Trim() != "")
				{
					sSql += " And GCC.IdRegistro = '" + sIdRegistro + "'";
				}
				if (sIdGrupo.Trim() != "")
				{
					sSql += " And GCC.IdGrupo = '" + sIdGrupo + "'";
				}
				if (sIdConcepto.Trim() != "")
				{
					sSql += " And GCC.IdConcepto = '" + sIdConcepto + "'";
				}
				if (sCuenta != "")
				{
					sSql += " And GCC.IdCuenta = '" + sCuenta + "'";
				}
				sSql += " 	Order by GCC.IdGrupo, MG.Orden, MCO.Orden";

				hLog.Debug("Query de lectura de Asociacio Grupo/Concepto/Cuenta {" + sSql + "}");
				List<DTOAsociacionGrupos> lDTO = new List<DTOAsociacionGrupos>();
				//
				DataSet dsContenedor = new DataSet();
				Conexion oCon = new Conexion();
				dsContenedor = oCon.CargarRecordConDatos(sSql);
				//
				foreach (DataRow registro in dsContenedor.Tables[sSql].Rows)
				{
					DTOAsociacionGrupos oDTO = new DTOAsociacionGrupos();
					oDTO.IdRegistro = int.Parse(registro["idRegistro"].ToString());
					oDTO.IdGrupo = registro["idGrupo"].ToString();
					oDTO.IdConcepto = registro["idConcepto"].ToString();
					oDTO.IdCuenta = registro["idCuenta"].ToString();
					oDTO.DescripcionGrupo = registro["DescripcionGrupo"].ToString();
					oDTO.DescripcionConcepto = registro["DescripcionConcepto"].ToString();
					oDTO.DescripcionCuenta = registro["DescripcionCuenta"].ToString();
					lDTO.Add(oDTO);
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

		public void CrearAsociacion(
			List<DTOAsociacionGrupos> lAsocia
			)
		{
			try
			{
				string sSql = "";
				ArrayList aSql = new ArrayList();
				foreach (DTOAsociacionGrupos oDTO in lAsocia)
				{
					sSql = "";
					sSql += "Insert into eerr_tbt_grupo_concepto_cuenta (";
					sSql += "  idGrupo";
					sSql += " ,idConcepto";
					sSql += " ,idCuenta";
					sSql += ") values (";
					sSql += "  '" + oDTO.IdGrupo.ToString() + "'";
					sSql += ", '" + oDTO.IdConcepto.ToString() + "'";
					sSql += ", '" + oDTO.IdCuenta.ToString() + "'";
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
		public void EditarAsociacion(
			List<DTOAsociacionGrupos> lAsocia
			)
		{
			try
			{
				ArrayList aSql = new ArrayList();
				foreach (DTOAsociacionGrupos oDTO in lAsocia)
				{
					string sSql = "";
					sSql += "Update eerr_tbt_grupo_concepto_cuenta set";
					sSql += "  idGrupo = '" + oDTO.IdGrupo.ToString() + "'";
					sSql += " ,idConcepto = '" + oDTO.IdConcepto.ToString() + "'";
					sSql += " ,idCuenta = '" + oDTO.IdCuenta.ToString() + "'";
					sSql += " Where idRegistro = " + oDTO.IdRegistro;
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
		public void EliminarAsociacion(
			List<DTOAsociacionGrupos> lAsocia
			)
		{
			try
			{
				ArrayList aSql = new ArrayList();
				foreach (DTOAsociacionGrupos oDTO in lAsocia)
				{
					string sSql = "";
					sSql += "Delete from eerr_tbt_grupo_concepto_cuenta";
					sSql += " Where idRegistro = " + oDTO.IdRegistro;
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
	}
}
