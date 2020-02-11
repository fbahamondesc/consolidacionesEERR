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
	class DAOConfiguracionAjustesAutomaticos
	{
		private MyLog4Net hLog = new MyLog4Net("DAOAjustes.class");

		public List<DTOConfiguracionAjustesAutomaticos> ConsultaConfiguracionAjustesAutomaticos(
			string sIdCompania
			, string sCuentaOrigen
			)
		{
			try
			{
				string sSql = "Select ";
				sSql += "   CA.idCompania";
				sSql += " , CO.Nombre";
				sSql += " , CA.CuentaOrigen";
				sSql += " , CA.CuentaDestino";
				sSql += " , CA.CuentaDestinoNC";
				sSql += " , CA.Glosa";
				sSql += " , CA.ContraCuenta";
				sSql += " , CA.NgCuentaDestino";
				sSql += " , CA.NgCuentaDestinoNC";
				sSql += " , CA.NgContraCuenta";
				sSql += " From EERR_TbT_Conf_Ajuste_Resultado_x_Inversion CA, EERR_Tbl_Companias CO";
				sSql += " Where 1=1";
				sSql += " And CA.idCompania = CO.IdCompania";
				if (sIdCompania != "")
				{
					sSql += " And CA.idCompania = '" + sIdCompania + "'";
				}
				if (sCuentaOrigen != "")
				{
					sSql += " And CA.CuentaOrigen = '" + sCuentaOrigen + "'";
				}
				sSql += " Order by CA.idCompania, CA.CuentaOrigen";
				hLog.Debug("Query de lectura de configuracion de ajustes automaticos {" + sSql + "}");
				List<DTOConfiguracionAjustesAutomaticos> lDTO = new List<DTOConfiguracionAjustesAutomaticos>();
				//
				DataSet dsContenedor = new DataSet();
				Conexion oCon = new Conexion();
				dsContenedor = oCon.CargarRecordConDatos(sSql);
				//
				foreach (DataRow registro in dsContenedor.Tables[sSql].Rows)
				{
					DTOConfiguracionAjustesAutomaticos DTO = new DTOConfiguracionAjustesAutomaticos();
					DTO.idCompania = registro["idCompania"].ToString();
					DTO.Nombre = registro["Nombre"].ToString();
					DTO.CuentaOrigen = registro["CuentaOrigen"].ToString();
					DTO.Glosa = registro["Glosa"].ToString();
					DTO.CuentaDestino = registro["CuentaDestino"].ToString();
					DTO.CuentaDestinoNC = registro["CuentaDestinoNC"].ToString();
					DTO.ContraCuenta = registro["ContraCuenta"].ToString();
					DTO.NgCuentaDestino = registro["NgCuentaDestino"].ToString();
					DTO.NgCuentaDestinoNC = registro["NgCuentaDestinoNC"].ToString();
					DTO.NgContraCuenta = registro["NgContraCuenta"].ToString();
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
		public List<DTOConfiguracionAjustesAutomaticos> ConsultaCuentasOrigen()
		{
			try
			{
				string sSql = "";
				sSql += "Select CuentaOrigen ";
				sSql += " From EERR_TbT_Conf_Ajuste_Resultado_x_Inversion";
				sSql += " Group by CuentaOrigen";
				hLog.Debug("Query de lectura de cuentas de origen {" + sSql + "}");

				List<DTOConfiguracionAjustesAutomaticos> lDTO = new List<DTOConfiguracionAjustesAutomaticos>();
				//
				DataSet dsContenedor = new DataSet();
				Conexion oCon = new Conexion();
				dsContenedor = oCon.CargarRecordConDatos(sSql);
				//
				foreach (DataRow registro in dsContenedor.Tables[sSql].Rows)
				{
					DTOConfiguracionAjustesAutomaticos DTO = new DTOConfiguracionAjustesAutomaticos();
					DTO.CuentaOrigen = registro["CuentaOrigen"].ToString();
					DTO.Glosa = registro["CuentaOrigen"].ToString();
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
		public void Crear(
			List<DTOConfiguracionAjustesAutomaticos> lDTO
			)
		{
			try
			{				
				ArrayList aSql = new ArrayList();
				foreach (DTOConfiguracionAjustesAutomaticos oDTO in lDTO)
				{
					string sSql = "";
				    sSql += "Insert into EERR_TbT_Conf_Ajuste_Resultado_x_Inversion (";
				    sSql += "  idCompania";
				    sSql += ", CuentaOrigen";
				    sSql += ", CuentaDestino";
				    sSql += ", CuentaDestinoNC";
				    sSql += ", Glosa";
				    sSql += ", ContraCuenta";
				    sSql += ", NgCuentaDestino";
				    sSql += ", NgCuentaDestinoNC";
				    sSql += ", NgContraCuenta";
				    sSql += ") values (";
				    sSql += "  '" + oDTO.idCompania.ToString() + "'";
				    sSql += ", '" + oDTO.CuentaOrigen.ToString() + "'";
				    sSql += ", '" + oDTO.CuentaDestino.ToString() + "'";
				    sSql += ", '" + oDTO.CuentaDestinoNC.ToString() + "'";
				    sSql += ", '" + oDTO.Glosa.ToString() + "'";
				    sSql += ", '" + oDTO.ContraCuenta.ToString() + "'";
				    sSql += ", '" + oDTO.NgCuentaDestino.ToString() + "'";
				    sSql += ", '" + oDTO.NgCuentaDestinoNC.ToString() + "'";
				    sSql += ", '" + oDTO.NgContraCuenta.ToString() + "'";
				    sSql += ")";
				    aSql.Add(sSql);
					hLog.Debug("Creamos  {" + sSql + "}");
				}
				Conexion oCon = new Conexion();
				oCon.EjecucionComandosSql(aSql);
			}
			catch (Exception ex)
			{
				string sMensaje = "Error al crear los datos de la tabla {" + ex.Source + "}{" + ex.Message + "}";
				hLog.Fatal(sMensaje);
				throw new SystemException(sMensaje);
			}
		}
		public void Editar(
			List<DTOConfiguracionAjustesAutomaticos> lDTO
			)
		{
			try
			{
				ArrayList aSql = new ArrayList();
				foreach (DTOConfiguracionAjustesAutomaticos oDTO in lDTO)
				{
				    string sSql = "";
				    sSql += "Update EERR_TbT_Conf_Ajuste_Resultado_x_Inversion set";
					sSql += "  Glosa = '" + oDTO.Glosa.ToString() + "'";
					sSql += ", CuentaDestino = '" + oDTO.CuentaDestino.ToString() + "'";
				    sSql += ", CuentaDestinoNC = '" + oDTO.CuentaDestinoNC.ToString() + "'";
				    sSql += ", ContraCuenta = '" + oDTO.ContraCuenta.ToString() + "'";
				    sSql += ", NgCuentaDestino = '" + oDTO.NgCuentaDestino.ToString() + "'";
				    sSql += ", NgCuentaDestinoNC = '" + oDTO.NgCuentaDestinoNC.ToString() + "'";
				    sSql += ", NgContraCuenta = '" + oDTO.NgContraCuenta.ToString() + "'";
				    sSql += " Where idCompania = '" + oDTO.idCompania.ToString() + "'";
					sSql += " And CuentaOrigen = '" + oDTO.CuentaOrigen.ToString() + "'";
					aSql.Add(sSql);
				    hLog.Debug("Actualizamos  {" + sSql + "}");

				}
				Conexion oCon = new Conexion();
				oCon.EjecucionComandosSql(aSql);
			}
			catch (Exception ex)
			{
				string sMensaje = "Error al editar los datos de la tabla {" + ex.Source + "}{" + ex.Message + "}";
				hLog.Fatal(sMensaje);
				throw new SystemException(sMensaje);
			}
		}
		public void Eliminar(
			List<DTOConfiguracionAjustesAutomaticos> lDTO
			)
		{
			try
			{
				ArrayList aSql = new ArrayList();
				foreach (DTOConfiguracionAjustesAutomaticos oDTO in lDTO)
				{
				    string sSql = "";
				    sSql += "Delete from EERR_TbT_Conf_Ajuste_Resultado_x_Inversion";
				    sSql += " Where idCompania = '" + oDTO.idCompania.ToString() + "'";
					sSql += " And CuentaOrigen = '" + oDTO.CuentaOrigen.ToString() + "'";
					aSql.Add(sSql);
				    hLog.Debug("Eliminamos {" + sSql + "}");
				}
				Conexion oCon = new Conexion();
				oCon.EjecucionComandosSql(aSql);
			}
			catch (Exception ex)
			{
				string sMensaje = "Error al eliminar los datos de la tabla {" + ex.Source + "}{" + ex.Message + "}";
				hLog.Fatal(sMensaje);
				throw new SystemException(sMensaje);
			}
		}
	}
}
