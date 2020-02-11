using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

using NewConsolidado.Controladores.Clases;
using NewConsolidado.Modelos.TransporteDatos;

namespace NewConsolidado.Modelos.AccesoDatos
{
	class DAOGrupos
	{
		private MyLog4Net hLog = new MyLog4Net("DAOGrupos.class");

		public List<DTOGrupos> ConsultaGrupos(
			int iIdGrupo
			, string sCodigo
			)
		{
			try
			{
				string sSql = "";
				sSql += "Select ";
				sSql += "  IdGrupo";
				sSql += ", Codigo";
				sSql += ", Descripcion";
				sSql += ", Tipo";
				sSql += ", Orden";
				sSql += " From EERR_Tbl_Maestro_Grupos";
				sSql += " Where 1=1";
				if (iIdGrupo > -1)
				{
					sSql += " And IdGrupo = " + iIdGrupo;
				}
				if (sCodigo != "")
				{
					sSql += " And Codigo = '" + sCodigo + "'";
				}
				sSql += " Order by Codigo, Orden";
				hLog.Debug("Query de lectura de Grupos {" + sSql + "}");
				List<DTOGrupos> lDTO = new List<DTOGrupos>();
				//
				DataSet dsContenedor = new DataSet();
				Conexion oCon = new Conexion();
				dsContenedor = oCon.CargarRecordConDatos(sSql);
				//
				foreach (DataRow registro in dsContenedor.Tables[sSql].Rows)
				{
					DTOGrupos DTO = new DTOGrupos();
					DTO.IdGrupo = int.Parse(registro["idGrupo"].ToString());
					DTO.Codigo = registro["Codigo"].ToString();
					DTO.Descripcion = registro["Descripcion"].ToString();
					DTO.Tipo = int.Parse(registro["Tipo"].ToString());
					DTO.Orden = int.Parse(registro["Orden"].ToString());
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

		public void CrearGrupo(DTOGrupos oDTO)
		{
			string sSql = "";
			ArrayList aSql = new ArrayList();

			try
			{
				sSql = " Insert into EERR_Tbl_Maestro_Grupos ( ";
				sSql += "  Codigo";
				sSql += ", Descripcion";
				sSql += ", Tipo";
				sSql += ", Orden";
				sSql += " ) Values ( ";
				sSql += " '" + oDTO.Codigo + "'";
				sSql += ",'" + oDTO.Descripcion+ "'";
				sSql += ", " + oDTO.Tipo;
				sSql += ", " + oDTO.Orden;
				sSql += ")";
				aSql.Add(sSql);
				hLog.Debug("Crear grupo {" + sSql + "}");

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

		public void EditarGrupo(DTOGrupos oDTO)
		{
			string sSql = "";
			ArrayList aSql = new ArrayList();

			try
			{
				sSql = "Update EERR_Tbl_Maestro_Grupos Set";
				sSql += "  Descripcion = '" + oDTO.Descripcion + "'";
				sSql += ", Tipo = " + oDTO.Tipo;
				sSql += ", Orden = " + oDTO.Orden;
				sSql += " Where Codigo = '" + oDTO.Codigo + "'";
				hLog.Debug("Editar grupo {" + sSql + "}");
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
		public void EliminarGrupo(DTOGrupos oDTO)
		{
			string sSql = "";
			ArrayList aSql = new ArrayList();

			try
			{
				sSql += "Delete from EERR_Tbl_Maestro_Grupos";
				sSql += " Where Codigo = '" + oDTO.Codigo + "'";
				aSql.Add(sSql);
				hLog.Debug("Eliminar grupo {" + sSql + "}");
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
