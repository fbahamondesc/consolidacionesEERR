using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

using NewConsolidado.Controladores.Clases;
using NewConsolidado.Modelos.TransporteDatos;

namespace NewConsolidado.Modelos.AccesoDatos
{
	class DAOConceptos
	{
		private MyLog4Net hLog = new MyLog4Net("DAOConceptos.class");

		public List<DTOConceptos> ConsultaConceptos(
			int iIdConcepto,
			string sCodigo
			)
		{
			try
			{
				string sSql = "";
				sSql += "Select ";
				sSql += "  IdConcepto";
				sSql += ", Codigo";
				sSql += ", Descripcion";
				sSql += ", Tipo";
				sSql += ", Orden";
                sSql += ", FlagSumaESF";
				sSql += " From EERR_Tbl_Maestro_Conceptos";
				sSql += " Where 1=1";
				if (iIdConcepto > -1)
				{
					sSql += " And IdConcepto = " + iIdConcepto;
				}
				if (sCodigo != "")
				{
					sSql += " And Codigo = '" + sCodigo + "'";
				}
				hLog.Debug("Query de lectura de Conceptos {" + sSql + "}");
				List<DTOConceptos> lDTO = new List<DTOConceptos>();
				//
				DataSet dsContenedor = new DataSet();
				Conexion oCon = new Conexion();
				dsContenedor = oCon.CargarRecordConDatos(sSql);
				//
				foreach (DataRow registro in dsContenedor.Tables[sSql].Rows)
				{
					DTOConceptos DTO = new DTOConceptos();
					DTO.IdConcepto = int.Parse(registro["idConcepto"].ToString());
					DTO.Codigo = registro["Codigo"].ToString();
					DTO.Descripcion = registro["Descripcion"].ToString();
					DTO.Tipo = int.Parse(registro["Tipo"].ToString());
					DTO.Orden = int.Parse(registro["Orden"].ToString());
                    DTO.FlagSumaESF = int.Parse(registro["FlagSumaESF"].ToString());
					lDTO.Add(DTO);
				}

				return lDTO;
			}
			catch (Exception ex)
			{
                string sMensaje = "\n[DAOConceptos][ConsultaConceptos] {" + ex.Message + "}";
				hLog.Fatal(sMensaje);
				throw new SystemException(sMensaje);
			}
		}
		public void CrearConcepto(DTOConceptos oDTO)
		{
			string sSql = "";
			ArrayList aSql = new ArrayList();

			try
			{
				sSql = " Insert into EERR_Tbl_Maestro_Conceptos ( ";
				sSql += "  Codigo";
				sSql += ", Descripcion";
				sSql += ", Tipo";
				sSql += ", Orden";
                sSql += ", FlagSumaESF";
				sSql += " ) Values ( ";
				sSql += " '" + oDTO.Codigo + "'";
				sSql += ",'" + oDTO.Descripcion + "'";
				sSql += ", " + oDTO.Tipo;
				sSql += ", " + oDTO.Orden;
                sSql += ", " + oDTO.FlagSumaESF;
				sSql += ")";
				aSql.Add(sSql);
				hLog.Debug("Crear concepto {" + sSql + "}");

				Conexion oCon = new Conexion();
				oCon.EjecucionComandosSql(aSql);

			}
			catch (Exception ex)
			{
                string sMensaje = "\n[DAOConceptos][CrearConcepto] {" + ex.Message + "}";
				hLog.Fatal(sMensaje);
				throw new SystemException(sMensaje);
			}
		}
		public void EditarConcepto(DTOConceptos oDTO)
		{
			string sSql = "";
			ArrayList aSql = new ArrayList();

			try
			{
				sSql = "Update EERR_Tbl_Maestro_Conceptos Set";
				sSql += "  Descripcion = '" + oDTO.Descripcion + "'";
				sSql += ", Tipo = " + oDTO.Tipo;
				sSql += ", Orden = " + oDTO.Orden;
                sSql += ", FlagSumaESF = " + oDTO.FlagSumaESF;
				sSql += " Where Codigo = '" + oDTO.Codigo + "'";
				hLog.Debug("Editar concepto {" + sSql + "}");
				aSql.Add(sSql);

				Conexion oCon = new Conexion();
				oCon.EjecucionComandosSql(aSql);
			}
			catch (Exception ex)
			{
                string sMensaje = "\n[DAOConceptos][EditarConcepto] {" + ex.Source + "}{" + ex.Message + "}";
				hLog.Fatal(sMensaje);
				throw new SystemException(sMensaje);
			}
		}
		public void EliminarConcepto(DTOConceptos oDTO)
		{
			string sSql = "";
			ArrayList aSql = new ArrayList();

			try
			{
				sSql += "Delete from EERR_Tbl_Maestro_Conceptos";
				sSql += " Where Codigo = '" + oDTO.Codigo + "'";
				aSql.Add(sSql);
				hLog.Debug("Eliminar concepto {" + sSql + "}");
				Conexion oCon = new Conexion();
				oCon.EjecucionComandosSql(aSql);
			}
			catch (Exception ex)
			{
                string sMensaje = "\n[DAOConceptos][EliminarConcepto] {" + ex.Source + "}{" + ex.Message + "}";
				hLog.Fatal(sMensaje);
				throw new SystemException(sMensaje);
			}
		}
	}
}
