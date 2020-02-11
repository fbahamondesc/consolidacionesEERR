using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;

using NewConsolidado.Controladores.Clases;
using NewConsolidado.Modelos.TransporteDatos;

namespace NewConsolidado.Modelos.AccesoDatos
{
	class DAOConsolidados
	{
		private MyLog4Net hLog = new MyLog4Net("DAOConsolidados.class");

		public List<DTOConsolidados> ConsultaConsolidados(
			int idRegistro
			, int idPadre
			, string sCodigoConsolidado
			, string sIdCodigo
			, int iCodigoReferenciado
			, int iIdComparativo
			)
		{
			try
			{
				List<DTOConsolidados> lstConsolidados = new List<DTOConsolidados>();
				string sSql = "";
				sSql += "Select ";
				sSql += "  IdRegistro";
				sSql += ", isNull(IdPadre, 0) IdPadre";
				sSql += ", Codigo";
				sSql += ", Descripcion";
				sSql += ", Observaciones";
				sSql += ", PeriodoInicio";
				sSql += ", PeriodoTermino";
				sSql += ", Convert(varchar, FechaCreacion, 112) FechaCreacion";
				sSql += ", Convert(varchar, FechaModificacion, 112) FechaModificacion";
				sSql += ", PorcentajeParticipacion";
				sSql += ", IndicadorMatriz";
				sSql += ", TipoNodo";
				sSql += ", Estado";
				sSql += ", Duenio";
				sSql += ", Bloqueo";
				sSql += ", ReferenciaConsolidado";
				sSql += ", CodigoReferenciado";
				sSql += ", IdCodigo";
				sSql += ", Orden ";
				sSql += ", IdComparativo";
				sSql += ", PeriodoComparativo";
				sSql += ", PeriodoInforme";
                sSql += ", IdComparativoERF";
                sSql += ", PeriodoComparativoERF";
                sSql += ", PeriodoInformeERF";
                sSql += " From EERR_Tbl_Consolidados";
				sSql += " Where 1=1";
				if (idRegistro > -1)
				{
					sSql += " And idRegistro = " + idRegistro;
				}
				if (idPadre > -1)
				{
					sSql += " And IdPadre = " + idPadre;
				}
				if (sCodigoConsolidado != "")
				{
					sSql += " And Codigo = '" + sCodigoConsolidado + "'";
				}
				if (sIdCodigo != "")
				{
					sSql += " And IdCodigo = '" + sIdCodigo + "'";
				}
				if (iCodigoReferenciado > -1)
				{
					sSql += " And CodigoReferenciado = " + iCodigoReferenciado.ToString();
				}
				if (iIdComparativo > -1)
				{
					sSql += " And IdComparativo = " + iIdComparativo.ToString();
				}

				sSql += " Order by Codigo";

				hLog.Debug("Query de lectura de Consolidados {" + sSql + "}");

				DataSet dsContenedor = new DataSet();

				Conexion oCon = new Conexion();
				dsContenedor = oCon.CargarRecordConDatos(sSql);

				foreach (DataRow registro in dsContenedor.Tables[sSql].Rows)
				{
					DTOConsolidados dtoConsolidado = new DTOConsolidados();
					dtoConsolidado.IdRegistro = int.Parse(registro["IdRegistro"].ToString());
					if (registro["IdPadre"].ToString() != "")
					{ dtoConsolidado.IdPadre = int.Parse(registro["IdPadre"].ToString()); }
					dtoConsolidado.Codigo = registro["Codigo"].ToString();
					dtoConsolidado.Descripcion = registro["Descripcion"].ToString();
					dtoConsolidado.Observaciones = registro["Observaciones"].ToString();
					dtoConsolidado.PeriodoInicio = registro["PeriodoInicio"].ToString();
					dtoConsolidado.PeriodoTermino = registro["PeriodoTermino"].ToString();
					if (registro["FechaCreacion"].ToString().Trim() != "")
					{ dtoConsolidado.FechaCreacion = DateTime.ParseExact(registro["FechaCreacion"].ToString(), "yyyyMMdd", CultureInfo.InvariantCulture); }
					if (registro["FechaModificacion"].ToString().Trim() != "")
					{ dtoConsolidado.FechaModificacion = DateTime.ParseExact(registro["FechaModificacion"].ToString(), "yyyyMMdd", CultureInfo.InvariantCulture); }
					if (registro["PorcentajeParticipacion"].ToString().Trim() != "")
					{ dtoConsolidado.PorcentajeParticipacion = Decimal.Parse(registro["PorcentajeParticipacion"].ToString().Replace(".", ",")); }
					if (registro["IndicadorMatriz"].ToString().Trim() != "")
					{ dtoConsolidado.IndicadorMatriz = Convert.ToInt32(registro["IndicadorMatriz"].ToString()); }
					if (registro["TipoNodo"].ToString().Trim() != "")
					{ dtoConsolidado.TipoNodo = Convert.ToInt32(registro["TipoNodo"].ToString()); }
					if (registro["Estado"].ToString().Trim() != "")
					{ dtoConsolidado.Estado = Convert.ToInt32(registro["Estado"].ToString()); }
					dtoConsolidado.Owner = registro["Duenio"].ToString();
					if (registro["Bloqueo"].ToString().Trim() != "")
					{ dtoConsolidado.Bloqueo = Convert.ToInt32(registro["Bloqueo"].ToString()); }
					if (registro["ReferenciaConsolidado"].ToString().Trim() != "")
					{ dtoConsolidado.RefenciaConsolidado = Convert.ToInt32(registro["ReferenciaConsolidado"].ToString()); }
					if (registro["CodigoReferenciado"].ToString().Trim() != "")
					{ dtoConsolidado.CodigoReferenciado = Convert.ToInt32(registro["CodigoReferenciado"].ToString()); }
					if (registro["IdCodigo"].ToString().Trim() != "")
					{ dtoConsolidado.IdCodigo = registro["IdCodigo"].ToString(); }
					if (registro["Orden"].ToString().Trim() != "")
					{ dtoConsolidado.Orden = int.Parse(registro["Orden"].ToString()); }
					if (registro["IdComparativo"].ToString().Trim() != "")
					{ dtoConsolidado.idComparativo = int.Parse(registro["IdComparativo"].ToString()); }
					if (registro["PeriodoComparativo"].ToString().Trim() != "")
					{ dtoConsolidado.PeriodoComparativo = registro["PeriodoComparativo"].ToString(); }
					if (registro["PeriodoInforme"].ToString().Trim() != "")
					{ dtoConsolidado.PeriodoInforme = registro["PeriodoInforme"].ToString(); }
                    if (registro["IdComparativoERF"].ToString().Trim() != "")
                    { dtoConsolidado.idComparativoERF = int.Parse(registro["IdComparativoERF"].ToString()); }
                    if (registro["PeriodoComparativoERF"].ToString().Trim() != "")
                    { dtoConsolidado.PeriodoComparativoERF = registro["PeriodoComparativoERF"].ToString(); }
                    if (registro["PeriodoInformeERF"].ToString().Trim() != "")
                    { dtoConsolidado.PeriodoInformeERF = registro["PeriodoInformeERF"].ToString(); }
                    lstConsolidados.Add(dtoConsolidado);
				}

				return lstConsolidados;
			}
			catch (Exception ex)
			{
				string sMensaje = "Error al leer los datos de la tabla {" + ex.Source + "}{" + ex.Message + "}";
				hLog.Fatal(sMensaje);
				throw new SystemException(sMensaje);
			}
		}

        public List<DTOConsolidados> ConsultaConsolidadosTipo(int iTipo)
        {
            try
            {
                List<DTOConsolidados> lstConsolidados = new List<DTOConsolidados>();
                string sSql = "";
                sSql += "Select";
                sSql += "  Codigo";
                //sSql += ", idRegistro";
                sSql += ", Descripcion";
                sSql += " From EERR_Tbl_Consolidados";
                sSql += " Where TipoNodo = " + iTipo.ToString();
                sSql += " Group by Codigo, Descripcion";

                hLog.Debug("Query de lectura de Consolidados filtrados por tipo {" + sSql + "}");

                DataSet dsContenedor = new DataSet();
                Conexion oCon = new Conexion();
                dsContenedor = oCon.CargarRecordConDatos(sSql);

                foreach (DataRow registro in dsContenedor.Tables[sSql].Rows)
                {
                    DTOConsolidados dtoConsolidado = new DTOConsolidados();
                    //dtoConsolidado.IdRegistro = int.Parse(registro["idRegistro"].ToString());
                    dtoConsolidado.Codigo = registro["Codigo"].ToString();
                    dtoConsolidado.Descripcion = registro["Descripcion"].ToString();
                    lstConsolidados.Add(dtoConsolidado);
                }

                return lstConsolidados;
            }
            catch (Exception ex)
            {
                string sMensaje = "Error al leer los datos de la tabla {" + ex.Source + "}{" + ex.Message + "}";
                hLog.Fatal(sMensaje);
                throw new SystemException(sMensaje);
            }

        }

        public List<DTOConsolidados> ConsultaConsolidadosTodosTipo(int iTipo)
        {
            try
            {
                List<DTOConsolidados> lstConsolidados = new List<DTOConsolidados>();
                string sSql = "";
                sSql += "Select";
                sSql += "  Codigo";
                sSql += ", idRegistro";
                sSql += ", Descripcion";
                sSql += " From EERR_Tbl_Consolidados";
                sSql += " Where TipoNodo = " + iTipo.ToString();
                //sSql += " Group by Codigo, Descripcion";

                hLog.Debug("Query de lectura de Consolidados filtrados por tipo {" + sSql + "}");

                DataSet dsContenedor = new DataSet();
                Conexion oCon = new Conexion();
                dsContenedor = oCon.CargarRecordConDatos(sSql);

                foreach (DataRow registro in dsContenedor.Tables[sSql].Rows)
                {
                    DTOConsolidados dtoConsolidado = new DTOConsolidados();
                    dtoConsolidado.IdRegistro = int.Parse(registro["idRegistro"].ToString());
                    dtoConsolidado.Codigo = registro["Codigo"].ToString();
                    dtoConsolidado.Descripcion = registro["Descripcion"].ToString();
                    lstConsolidados.Add(dtoConsolidado);
                }

                return lstConsolidados;
            }
            catch (Exception ex)
            {
                string sMensaje = "Error al leer los datos de la tabla {" + ex.Source + "}{" + ex.Message + "}";
                hLog.Fatal(sMensaje);
                throw new SystemException(sMensaje);
            }
        }

        public List<DTOConsolidados> ConsultaPorCodigoDescripcion(string sCodigo, string sDescripcion)
        {
            try
            {
                List<DTOConsolidados> lstConsolidados = new List<DTOConsolidados>();
                string sSql = "";
                sSql += "Select";
                sSql += "  Codigo";
                sSql += ", idRegistro";
                sSql += ", Descripcion";
                sSql += " From EERR_Tbl_Consolidados";
                sSql += " Where 1 = 1";
                sSql += " And codigo = '" + sCodigo.ToString() + "'";
                sSql += " And ltrim(rtrim(descripcion)) = '" + sDescripcion.ToString().Trim() + "'";

                hLog.Debug("Query de lectura de Consolidados filtrados por tipo {" + sSql + "}");

                DataSet dsContenedor = new DataSet();
                Conexion oCon = new Conexion();
                dsContenedor = oCon.CargarRecordConDatos(sSql);

                foreach (DataRow registro in dsContenedor.Tables[sSql].Rows)
                {
                    DTOConsolidados dtoConsolidado = new DTOConsolidados();
                    dtoConsolidado.IdRegistro = int.Parse(registro["idRegistro"].ToString());
                    //dtoConsolidado.Codigo = registro["Codigo"].ToString();
                    //dtoConsolidado.Descripcion = registro["Descripcion"].ToString();
                    lstConsolidados.Add(dtoConsolidado);
                }

                return lstConsolidados;
            }
            catch (Exception ex)
            {
                string sMensaje = "Error al leer los datos de la tabla {" + ex.Source + "}{" + ex.Message + "}";
                hLog.Fatal(sMensaje);
                throw new SystemException(sMensaje);
            }
        }

        public void CrearConsolidado(DTOConsolidados oDTO)
		{
			try
			{
				string sSql = "";
				sSql += "Insert into EERR_Tbl_Consolidados (";
				sSql += "  IdPadre";
				sSql += ", Codigo";
				sSql += ", Descripcion";
				sSql += ", Observaciones";
				sSql += ", PeriodoInicio";
				sSql += ", PeriodoTermino";
				sSql += ", FechaCreacion";
				sSql += ", FechaModificacion";
				sSql += ", PorcentajeParticipacion";
				sSql += ", IndicadorMatriz";
				sSql += ", TipoNodo";
				sSql += ", Estado";
				sSql += ", Duenio";
				sSql += ", Bloqueo";
				sSql += ", ReferenciaConsolidado";
				sSql += ", CodigoReferenciado";
				sSql += ", IdCodigo";
				sSql += ", Orden";
				sSql += ", IdComparativo";
				sSql += ", PeriodoComparativo";
				sSql += ", PeriodoInforme";
                sSql += ", IdComparativoERF";
                sSql += ", PeriodoComparativoERF";
                sSql += ", PeriodoInformeERF";
                sSql += ") values (";
				sSql += "   " + oDTO.IdPadre.ToString().Trim();
				sSql += ", '" + oDTO.Codigo.ToString().Trim() + "'";
				sSql += ", '" + oDTO.Descripcion.ToString().Trim() + "'";
				sSql += ", '" + oDTO.Observaciones.ToString().Trim() + "'";
				sSql += ", '" + oDTO.PeriodoInicio.ToString().Trim() + "'";
				sSql += ", '" + oDTO.PeriodoTermino.ToString().Trim() + "'";
				sSql += ", convert( datetime, '" + oDTO.FechaCreacion.ToString("yyyyMMdd") + "', 112 )";
				sSql += ", convert( datetime, '" + oDTO.FechaModificacion.ToString("yyyyMMdd") + "', 112 )";
				sSql += ",  " + oDTO.PorcentajeParticipacion.ToString().Replace(",",".");
				sSql += ",  " + oDTO.IndicadorMatriz.ToString().Trim();
				sSql += ",  " + oDTO.TipoNodo.ToString().Trim();
				sSql += ",  " + oDTO.Estado.ToString().Trim();
				sSql += ", '" + oDTO.Owner.ToString().Trim() + "'";
				sSql += ",  " + oDTO.Bloqueo.ToString().Trim();
				sSql += ",  " + oDTO.RefenciaConsolidado.ToString().Trim();
				sSql += ",  " + oDTO.CodigoReferenciado.ToString().Trim();
				sSql += ", '" + oDTO.IdCodigo.ToString().Trim() + "'";
				sSql += ",  " + oDTO.Orden.ToString().Trim();
				sSql += ",  " + oDTO.idComparativo.ToString().Trim();
				sSql += ", '" + oDTO.PeriodoComparativo.ToString().Trim() + "'";
				sSql += ", '" + oDTO.PeriodoInforme.ToString().Trim() + "'";
                sSql += ",  " + oDTO.idComparativoERF.ToString().Trim();
                sSql += ", '" + oDTO.PeriodoComparativoERF.ToString().Trim() + "'";
                sSql += ", '" + oDTO.PeriodoInformeERF.ToString().Trim() + "'";
                sSql += ")";
				ArrayList aSql = new ArrayList();
				aSql.Add(sSql);

				hLog.Debug("insert de Consolidados {" + sSql + "}");

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
		public void EditarConsolidado(DTOConsolidados oDTO)
		{
			try
			{
				string sSql = "";
				sSql += "Update EERR_Tbl_Consolidados Set ";
				sSql += "  IdPadre = " + oDTO.IdPadre.ToString().Trim();
				sSql += ", Codigo = '" + oDTO.Codigo.ToString().Trim() + "'";
				sSql += ", Descripcion = '" + oDTO.Descripcion.ToString().Trim() + "'";
				sSql += ", Observaciones = '" + oDTO.Observaciones.ToString().Trim() + "'";
				sSql += ", PeriodoInicio = '" + oDTO.PeriodoInicio.ToString().Trim() + "'";
				sSql += ", PeriodoTermino = '" + oDTO.PeriodoTermino.ToString().Trim() + "'";
				sSql += ", FechaModificacion = convert( datetime, '" + oDTO.FechaModificacion.ToString("yyyyMMdd") + "', 112 )";
				sSql += ", PorcentajeParticipacion = " + oDTO.PorcentajeParticipacion.ToString().Replace(",", ".");
				sSql += ", IndicadorMatriz = " + oDTO.IndicadorMatriz.ToString().Trim();
				sSql += ", TipoNodo = " + oDTO.TipoNodo.ToString().Trim();
				sSql += ", Estado = " + oDTO.Estado.ToString().Trim();
				sSql += ", Duenio = '" + oDTO.Owner.ToString().Trim() + "'";
				sSql += ", Bloqueo = " + oDTO.Bloqueo.ToString().Trim();
				sSql += ", ReferenciaConsolidado = " + oDTO.RefenciaConsolidado.ToString().Trim();
				sSql += ", CodigoReferenciado = " + oDTO.CodigoReferenciado.ToString().Trim();
				sSql += ", IdCodigo = '" + oDTO.IdCodigo.ToString() + "'";
				sSql += ", Orden = " + oDTO.Orden.ToString().Trim();
				sSql += ", IdComparativo = " + oDTO.idComparativo.ToString().Trim();
				sSql += ", PeriodoComparativo = '" + oDTO.PeriodoComparativo.ToString().Trim() + "'";
				sSql += ", PeriodoInforme = '" + oDTO.PeriodoInforme.ToString().Trim() + "'";
                sSql += ", IdComparativoERF = " + oDTO.idComparativoERF.ToString().Trim();
                sSql += ", PeriodoComparativoERF = '" + oDTO.PeriodoComparativoERF.ToString().Trim() + "'";
                sSql += ", PeriodoInformeERF = '" + oDTO.PeriodoInformeERF.ToString().Trim() + "'";
                sSql += " Where IdRegistro = " + oDTO.IdRegistro.ToString();

				ArrayList aSql = new ArrayList();
				aSql.Add(sSql);

				hLog.Debug("update de Consolidados {" + sSql + "}");

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
		public void EditarNodosReferenciados(DTOConsolidados oDTO)
		{
			try
			{
				string sSql = "";
				sSql += "Update EERR_Tbl_Consolidados Set ";
				sSql += " Codigo = '" + oDTO.Codigo + "'";
				sSql += " ,Descripcion = '" + oDTO.Descripcion + "'";
				sSql += " ,Observaciones = '" + oDTO.Observaciones + "'";
				sSql += " ,PeriodoInicio = '" + oDTO.PeriodoInicio + "'";
				sSql += " ,PeriodoTermino = '" + oDTO.PeriodoTermino + "'";
				sSql += " ,FechaModificacion = convert( datetime, '" + oDTO.FechaModificacion.ToString("yyyyMMdd") + "', 112 )";
				sSql += " ,Estado = " + oDTO.Estado.ToString();
				sSql += " ,Bloqueo = " + oDTO.Bloqueo.ToString();
				sSql += " where 1=1";
				sSql += " and CodigoReferenciado = " + oDTO.IdRegistro.ToString();

				ArrayList aSql = new ArrayList();
				aSql.Add(sSql);

				hLog.Debug("insert de Consolidados {" + sSql + "}");


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

		public void EliminarConsolidado(DTOConsolidados oDTO)
		{
			try
			{
                ArrayList aSql = new ArrayList();
				string sSql = "";

                sSql += "Delete From EERR_Tbl_Consolidados";
				sSql += " Where IdRegistro = " + oDTO.IdRegistro.ToString();
				aSql.Add(sSql);

                sSql += "Delete From EERR_TbT_Consolidado_Grupo_Concepto_Cuenta";
                sSql += " Where idConsolidado = " + oDTO.IdRegistro.ToString();
                aSql.Add(sSql);

                sSql += "Delete From EERR_Tbl_Ajustes";
                sSql += " Where idConsolidado = " + oDTO.IdRegistro.ToString();
                aSql.Add(sSql);

                sSql += "Delete From EERR_Tbl_Ajustes_Cabecera";
                sSql += " Where idConsolidado = " + oDTO.IdRegistro.ToString();
                aSql.Add(sSql);

				hLog.Debug("delete de Consolidados {" + sSql + "}");

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

		public void CreacionGrupoConceptoCuenta( int iIdConsolidado)
		{
			try
			{
				string sSql = "";
				sSql += "Insert Into EERR_Tbt_Consolidado_Grupo_Concepto_Cuenta";
				sSql += " Select " + iIdConsolidado.ToString() + ", idGrupo, idConcepto, idCuenta";
				sSql += " From EERR_Tbt_Grupo_Concepto_Cuenta";

				ArrayList aSql = new ArrayList();
				aSql.Add(sSql);

				hLog.Debug("insert de Consolidado_Grupo_Concepto_Cuenta {" + sSql + "}");

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
