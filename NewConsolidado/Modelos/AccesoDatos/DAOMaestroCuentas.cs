using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

using NewConsolidado.Controladores.Clases;
using NewConsolidado.Modelos.TransporteDatos;

namespace NewConsolidado.Modelos.AccesoDatos
{
	class DAOMaestroCuentas
	{
		private MyLog4Net hLog = new MyLog4Net("DAOMaestroCuentas.class");

		public List<DTOMaestroCuentas> ConsultaMaestroCuentas(
			string sIdCuenta
			)
		{
			try
			{
				List<DTOMaestroCuentas> lstMaestro = new List<DTOMaestroCuentas>();
				string sSql = "";
				sSql += "Select ";
				sSql += "  IdCuenta";
				sSql += ", Descripcion";
				sSql += ", Tipo";
				sSql += ", Orden";
				sSql += ", FlagImprime";
				sSql += ", FlagIngresoManual";
				sSql += ", FlagSoloAjuste";
				sSql += ", FlagPatrimonio";
				sSql += " From EERR_Tbl_Maestro_Cuentas";
				sSql += " Where 1=1";
				if (sIdCuenta != "")
				{
					sSql += " And IdCuenta = '" + sIdCuenta + "'";
				}
				hLog.Debug("Query de lectura de Maestro de Cuentas {" + sSql + "}");

				DataSet dsContenedor = new DataSet();

				Conexion oCon = new Conexion();
				dsContenedor = oCon.CargarRecordConDatos(sSql);

				foreach (DataRow registro in dsContenedor.Tables[sSql].Rows)
				{
					DTOMaestroCuentas oDTO = new DTOMaestroCuentas();
					oDTO.idCuenta = registro["IdCuenta"].ToString().Trim();
					oDTO.Descripcion= registro["Descripcion"].ToString();
					oDTO.Tipo = registro["Tipo"].ToString();
					oDTO.Orden = int.Parse(registro["Orden"].ToString());
					oDTO.Imprime = int.Parse(registro["FlagImprime"].ToString());
					oDTO.IngresoManual = int.Parse(registro["FlagIngresoManual"].ToString());
					oDTO.SoloAjuste = int.Parse(registro["FlagSoloAjuste"].ToString());
					oDTO.Patrimonio = int.Parse(registro["FlagPatrimonio"].ToString());
					lstMaestro.Add(oDTO);
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
		public void CrearCuenta(DTOMaestroCuentas oDTO)
		{
			string sSql = "";
			ArrayList aSql = new ArrayList();

			try
			{
				sSql = " Insert into EERR_Tbl_Maestro_Cuentas ( ";
				sSql += "  IdCuenta";
				sSql += ", Descripcion";
				sSql += ", Tipo";
				sSql += ", Orden";
				sSql += ", FlagImprime";
				sSql += ", FlagIngresoManual";
				sSql += ", FlagSoloAjuste";
				sSql += ", FlagPatrimonio";
				sSql += " ) Values ( ";
				sSql += " '" + oDTO.idCuenta + "'";
				sSql += ",'" + oDTO.Descripcion + "'";
				sSql += ", '" + oDTO.Tipo + "'";
				sSql += ", " + oDTO.Orden.ToString();
				sSql += ", " + oDTO.Imprime.ToString();
				sSql += ", " + oDTO.IngresoManual.ToString();
				sSql += ", " + oDTO.SoloAjuste.ToString();
				sSql += ", " + oDTO.Patrimonio.ToString();
				sSql += ")";
				aSql.Add(sSql);
				hLog.Debug("Crear Maestro_Cuentas {" + sSql + "}");

				Conexion oCon = new Conexion();
				oCon.EjecucionComandosSql(aSql);

			}
			catch (Exception ex)
			{
				string sMensaje = "Error al crear los datos de la tabla {" + ex.Message + "}";
				hLog.Fatal(sMensaje);
				throw new SystemException(sMensaje);
			}
		}
		public void EditarCuenta(DTOMaestroCuentas oDTO)
		{
			string sSql = "";
			ArrayList aSql = new ArrayList();

			try
			{
				sSql = "Update EERR_Tbl_Maestro_Cuentas Set";
				sSql += "  Descripcion = '" + oDTO.Descripcion + "'";
				sSql += ", Tipo = '" + oDTO.Tipo + "'";
				sSql += ", Orden = " + oDTO.Orden.ToString();
				sSql += ", FlagImprime = " + oDTO.Imprime.ToString();
				sSql += ", FlagIngresoManual = " + oDTO.IngresoManual.ToString();
				sSql += ", FlagSoloAjuste = " + oDTO.SoloAjuste.ToString();
				sSql += ", FlagPatrimonio = " + oDTO.Patrimonio.ToString();
				sSql += " Where IdCuenta = '" + oDTO.idCuenta.ToString() + "'";
				hLog.Debug("Editar Maestro_Cuentas {" + sSql + "}");
				aSql.Add(sSql);

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
		public void EliminarCuenta(DTOMaestroCuentas oDTO)
		{
			string sSql = "";
			ArrayList aSql = new ArrayList();

			try
			{
				sSql += "Delete from EERR_Tbl_Maestro_Cuentas";
				sSql += " Where IdCuenta = '" + oDTO.idCuenta.ToString() + "'";
				aSql.Add(sSql);
				hLog.Debug("Eliminar Maestro_Cuentas {" + sSql + "}");
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
