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
	class DAOConsolidadosAsociacionGrupo
	{
		private MyLog4Net hLog = new MyLog4Net("DAOConsolidadosAsociacionGrupo.class");

		public List<DTOConsolidadosAsociacionGrupo> ConsultaAsociacion(
			string sIdConsolidado
			, string sIdRegistro
			, string sIdGrupo
			, string sIdConcepto
			, string sCuenta
			)
		{
			try
			{
				string sSql = "";

				sSql += "Select";
				sSql += "		  GCC.idConsolidado";
				sSql += "		, GCC.idRegistro";
				sSql += "		, GCC.IdGrupo";
				sSql += "		, MG.Descripcion DescripcionGrupo";
				sSql += "		, GCC.IdConcepto";
				sSql += "		, MCO.Descripcion DescripcionConcepto";
				sSql += "		, GCC.IdCuenta";
				sSql += "		, MCU.descripcion DescripcionCuenta";
				sSql += "	From EERR_TbT_Consolidado_Grupo_Concepto_Cuenta GCC";
				sSql += "		,EERR_Tbl_Maestro_Grupos MG";
				sSql += "		,EERR_Tbl_Maestro_Conceptos MCO";
				sSql += "		,EERR_Tbl_Maestro_Cuentas MCU";
				sSql += "	Where 1=1";
				sSql += "	And GCC.IdGrupo = MG.Codigo";
				sSql += "	And GCC.IdConcepto = MCO.Codigo";
				sSql += "	And GCC.IdCuenta = MCU.IdCuenta";
				if (sIdConsolidado.Trim() != "")
				{
					sSql += " And GCC.IdConsolidado = " + sIdConsolidado ;
				}
				if (sIdRegistro.Trim() != "")
				{
					sSql += " And GCC.IdRegistro = " + sIdRegistro ;
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
				sSql += " 	Order by GCC.IdGrupo,GCC.IdConcepto, GCC.IdCuenta";

				hLog.Debug("Query de lectura de Asociacio Grupo/Concepto/Cuenta {" + sSql + "}");
				List<DTOConsolidadosAsociacionGrupo> lDTO = new List<DTOConsolidadosAsociacionGrupo>();
				//
				DataSet dsContenedor = new DataSet();
				Conexion oCon = new Conexion();
				dsContenedor = oCon.CargarRecordConDatos(sSql);
				//
				foreach (DataRow registro in dsContenedor.Tables[sSql].Rows)
				{
					DTOConsolidadosAsociacionGrupo oDTO = new DTOConsolidadosAsociacionGrupo();
					oDTO.IdConsolidado = int.Parse(registro["idConsolidado"].ToString());
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
			List<DTOConsolidadosAsociacionGrupo> lAsocia
			)
		{
			try
			{
				string sSql = "";
				ArrayList aSql = new ArrayList();
				foreach (DTOConsolidadosAsociacionGrupo oDTO in lAsocia)
				{
					sSql = "";
					sSql += "Insert into EERR_TbT_Consolidado_Grupo_Concepto_Cuenta (";
					sSql += "   idConsolidado";
					sSql += " , idGrupo";
					sSql += " , idConcepto";
					sSql += " , idCuenta";
					sSql += ") values (";
					sSql += "" + oDTO.IdConsolidado.ToString();
					sSql += ", '" + oDTO.IdGrupo.ToString() + "'";
					sSql += ", '" + oDTO.IdConcepto.ToString() + "'";
					sSql += ", '" + oDTO.IdCuenta.ToString() + "'";
					sSql += ")";
					aSql.Add(sSql);
					//
					hLog.Debug("envia insert {" + sSql + "}");
				}
				Conexion oCon = new Conexion();
				oCon.EjecucionComandosSql(aSql);
			}
			catch (Exception ex)
			{
				string sMensaje = "Error al insertar los datos de la tabla {" + ex.Source + "}{" + ex.Message + "}";
				hLog.Fatal(sMensaje);
				throw new SystemException(sMensaje);
			}
		}
		public void EditarAsociacion(
			List<DTOConsolidadosAsociacionGrupo> lAsocia
			)
		{
			try
			{
				ArrayList aSql = new ArrayList();
				foreach (DTOConsolidadosAsociacionGrupo oDTO in lAsocia)
				{
					string sSql = "";
					sSql += "Update EERR_TbT_Consolidado_Grupo_Concepto_Cuenta set";
					sSql += "  idGrupo = '" + oDTO.IdGrupo.ToString() + "'";
					sSql += " ,idConcepto = '" + oDTO.IdConcepto.ToString() + "'";
					sSql += " ,idCuenta = '" + oDTO.IdCuenta.ToString() + "'";
					sSql += " Where idRegistro = " + oDTO.IdRegistro;
					aSql.Add(sSql);
					//
					hLog.Debug("envia el update {" + sSql + "}");
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
		public void EliminarAsociacion(
			List<DTOConsolidadosAsociacionGrupo> lAsocia
			)
		{
			try
			{
				ArrayList aSql = new ArrayList();
				foreach (DTOConsolidadosAsociacionGrupo oDTO in lAsocia)
				{
					string sSql = "";
					sSql += "Delete from EERR_TbT_Consolidado_Grupo_Concepto_Cuenta";
					sSql += " Where idRegistro = " + oDTO.IdRegistro;
					aSql.Add(sSql);
					//
					hLog.Debug("envia delete {" + sSql + "}");
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
		public void AplicarPlantilla(
			string sIdConsolidado
			)
		{
			try
			{
				ArrayList aSql = new ArrayList();
				string sSql = "";
				sSql += "Insert Into EERR_TbT_Consolidado_Grupo_Concepto_Cuenta";
				sSql += " Select '" + sIdConsolidado.ToString() + "', idGrupo, idConcepto, idCuenta";
				sSql += " From EERR_TbT_Grupo_Concepto_Cuenta";
				sSql += " Where 1=1";
				sSql += " Order By IdGrupo, idconcepto, idcuenta";
				aSql.Add(sSql);
				//
				hLog.Debug("envia Aplica plantilla {" + sSql + "}");
				Conexion oCon = new Conexion();
				oCon.EjecucionComandosSql(aSql);
			}
			catch (Exception ex)
			{
				string sMensaje = "Error al insertar los datos de la tabla {" + ex.Source + "}{" + ex.Message + "}";
				hLog.Fatal(sMensaje);
				throw new SystemException(sMensaje);
			}
		}


        public void AplicarPlantilla(
            List<DTOConsolidados> lCodigos
            )
        {
            try
            {
                ArrayList aSql = new ArrayList();
                string sSql = "";

                foreach (DTOConsolidados oDTO in lCodigos)
                {
                    //Elimina registros del consolidado
                    sSql = "";
                    sSql += " Delete From EERR_TbT_Consolidado_Grupo_Concepto_Cuenta ";
                    sSql += " Where idConsolidado = " + oDTO.IdRegistro.ToString();
                    aSql.Add(sSql);
                    hLog.Debug("Elimina asociacion consolidado {" + sSql + "}");

                    //Agrega Plantilla al consolidado
                    sSql = "";
                    sSql += " Insert Into EERR_TbT_Consolidado_Grupo_Concepto_Cuenta";
                    sSql += "   Select '" + oDTO.IdRegistro.ToString() + "', idGrupo, idConcepto, idCuenta";
                    sSql += "   From EERR_TbT_Grupo_Concepto_Cuenta";
                    sSql += "   Where 1 = 1";
                    sSql += "   Order By IdGrupo, idconcepto, idcuenta";
                    aSql.Add(sSql);                
                    hLog.Debug("Crea asociacion plantilla {" + sSql + "}");
                }

                Conexion oCon = new Conexion();
                oCon.EjecucionComandosSql(aSql);            
            }
            catch (Exception ex)
            {
                string sMensaje = "Error al insertar los datos de la tabla {" + ex.Source + "}{" + ex.Message + "}";
                hLog.Fatal(sMensaje);
                throw new SystemException(sMensaje);
            }
        }
	}
}
