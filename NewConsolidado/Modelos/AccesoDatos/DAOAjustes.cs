using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

using NewConsolidado.Controladores.Clases;
using NewConsolidado.Modelos.TransporteDatos;

namespace NewConsolidado.Modelos.AccesoDatos
{
	class DAOAjustes
	{
		private MyLog4Net hLog = new MyLog4Net("DAOAjustes.class");

		public List<DTOAjustes> ConsultaAjustesConsolidado(
			int iConsolidado
			, string sPeriodo
			, string sCorrelativo
			)
		{
			try
			{
				string sSql = "";
				sSql += " Select ";
				sSql += "  A.idRegistro";
				sSql += ", A.idConsolidado";
				sSql += ", A.PeriodoAfectado";
				sSql += ", A.CorrelativoAsiento";
				sSql += ", A.idCuenta";
				sSql += ", A.PeriodoVista";
				sSql += ", A.TipoTransaccion";
				sSql += ", A.Debito";
				sSql += ", A.Credito";
				sSql += ", A.Descripcion";
				sSql += ", C.Descripcion DescripcionCuenta";
				sSql += ", D.Descripcion DescripcionCabecera"; 
				sSql += " From EERR_Tbl_Ajustes A, EERR_Tbl_Maestro_Cuentas C, EERR_TBL_Ajustes_Cabecera D";
				sSql += " Where 1=1";
				sSql += " And A.IdCuenta = C.IdCuenta";
				sSql += " And D.IdConsolidado = A.IdConsolidado";
				sSql += " And D.PeriodoAfectado = A.PeriodoAfectado";
				sSql += " And D.CorrelativoAsiento = A.CorrelativoAsiento";
				if (iConsolidado > -1)
				{
					sSql += " And A.idConsolidado = " + iConsolidado;
				}
				if (sPeriodo != "")
				{
					sSql += " And A.PeriodoAfectado = '" + sPeriodo + "'";
				}
				if(sCorrelativo.Trim() != "")
				{
					sSql += " And A.CorrelativoAsiento = " + sCorrelativo;
				}
				sSql += " Order by A.IdRegistro";
				hLog.Debug( "Query de lectura de Ajustes {" + sSql + "}" );
				List<DTOAjustes> lDTO = new List<DTOAjustes>();
				//
				DataSet dsContenedor = new DataSet();
				Conexion oCon = new Conexion();
				dsContenedor = oCon.CargarRecordConDatos(sSql);
				//
				foreach (DataRow registro in dsContenedor.Tables[sSql].Rows)
				{
					DTOAjustes oDTO = new DTOAjustes();
					oDTO.IdRegistro = int.Parse(registro["idRegistro"].ToString());
					oDTO.IdConsolidado = int.Parse(registro["idConsolidado"].ToString());
					oDTO.PeriodoAfectado = registro["PeriodoAfectado"].ToString();
					oDTO.CorrelativoAsiento = int.Parse(registro["CorrelativoAsiento"].ToString());
					oDTO.IdCuenta = registro["idCuenta"].ToString();
					oDTO.PeriodoVista = registro["PeriodoVista"].ToString();
					oDTO.TipoTransaccion = int.Parse(registro["TipoTransaccion"].ToString());
					oDTO.Debito = decimal.Parse(registro["Debito"].ToString());
					oDTO.Credito = decimal.Parse(registro["Credito"].ToString());
					oDTO.Descripcion = registro["Descripcion"].ToString();
					oDTO.DescripcionCuenta = registro["DescripcionCuenta"].ToString();
					oDTO.DescripcionCabecera = registro["DescripcionCabecera"].ToString();
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

		public List<DTOAjustes> ConsultaAsientosPorConsolidado(
			int iConsolidado
			, string sPeriodo
			)
		{
			try
			{
				string sSql = "";
				sSql += "Select";
				sSql += "  AC.idConsolidado";
				sSql += ", AC.PeriodoAfectado";
				sSql += ", AC.CorrelativoAsiento";
				sSql += ", AC.PeriodoVista";
				sSql += ", AC.TipoTransaccion";
				sSql += ", Isnull(";
				sSql += "			( Select Sum(A.Debito) From EERR_Tbl_Ajustes A";
				sSql += "				Where 1=1";
				sSql += "				And A.IdConsolidado = AC.IdConsolidado";
				sSql += "				And A.CorrelativoAsiento = AC.CorrelativoAsiento";
				sSql += "				And A.PeriodoAfectado = AC.PeriodoAfectado";
				sSql += "			)";
				sSql += "			, 0) Debito";
				sSql += ", Isnull(";
				sSql += "			( Select Sum(A.Credito) From EERR_Tbl_Ajustes A";
				sSql += "				Where 1=1";
				sSql += "				And A.IdConsolidado = AC.IdConsolidado";
				sSql += "				And A.CorrelativoAsiento = AC.CorrelativoAsiento";
				sSql += "				And A.PeriodoAfectado = AC.PeriodoAfectado";
				sSql += "				), 0) Credito";
				sSql += ", AC.Descripcion";
				sSql += "	From EERR_Tbl_Ajustes_Cabecera AC";
				sSql += "	Where 1=1";
				if (iConsolidado > -1)
				{
					sSql += " And AC.idConsolidado = " + iConsolidado;
				}
				if (sPeriodo != "")
				{
					sSql += " And AC.PeriodoAfectado = '" + sPeriodo + "'";
				}
				sSql += "      Order by CorrelativoAsiento";
				//
				hLog.Debug("Query de lectura de Companias {" + sSql + "}");
				List<DTOAjustes> lDTO = new List<DTOAjustes>();
				//
				DataSet dsContenedor = new DataSet();
				Conexion oCon = new Conexion();
				dsContenedor = oCon.CargarRecordConDatos(sSql);
				//
				foreach (DataRow registro in dsContenedor.Tables[sSql].Rows)
				{
					DTOAjustes DTO = new DTOAjustes();
					//DTO.IdRegistro = int.Parse(registro["idRegistro"].ToString());
					DTO.IdConsolidado = int.Parse(registro["idConsolidado"].ToString());
					DTO.PeriodoAfectado = registro["PeriodoAfectado"].ToString();
					DTO.CorrelativoAsiento = int.Parse(registro["CorrelativoAsiento"].ToString());
					//DTO.IdCuenta = int.Parse(registro["idCuenta"].ToString());
					DTO.PeriodoVista = registro["PeriodoVista"].ToString();
					DTO.TipoTransaccion = int.Parse(registro["TipoTransaccion"].ToString());
					DTO.Debito = decimal.Parse(registro["Debito"].ToString());
					DTO.Credito = decimal.Parse(registro["Credito"].ToString());
					DTO.Descripcion = registro["Descripcion"].ToString();

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

		public List<DTOAjustes> ConsultaCabeceraAsientos(
			int iConsolidado
			, string sPeriodo
			, string sCorrelativo
			)
		{
			try
			{
				string sSql = "";
				sSql += "Select";
				sSql += "  AC.idregistro";
				sSql += ", AC.idConsolidado";
				sSql += ", AC.PeriodoAfectado";
				sSql += ", AC.CorrelativoAsiento";
				sSql += ", AC.Descripcion";
				sSql += "	From EERR_Tbl_Ajustes_Cabecera AC";
				sSql += "	Where 1=1";
				if (iConsolidado > -1)
				{
					sSql += " And AC.idConsolidado = " + iConsolidado;
				}
				if (sPeriodo != "")
				{
					sSql += " And AC.PeriodoAfectado = '" + sPeriodo + "'";
				}
				if (sCorrelativo.Trim() != "")
				{
					sSql += " And AC.CorrelativoAsiento = " + sCorrelativo;
				}
				sSql += "      Order by CorrelativoAsiento";
				//
				hLog.Debug("Query de lectura de Companias {" + sSql + "}");
				List<DTOAjustes> lDTO = new List<DTOAjustes>();
				//
				DataSet dsContenedor = new DataSet();
				Conexion oCon = new Conexion();
				dsContenedor = oCon.CargarRecordConDatos(sSql);
				//
				foreach (DataRow registro in dsContenedor.Tables[sSql].Rows)
				{
					DTOAjustes DTO = new DTOAjustes();
					DTO.IdRegistro = int.Parse(registro["idRegistro"].ToString());
					DTO.IdConsolidado = int.Parse(registro["idConsolidado"].ToString());
					DTO.PeriodoAfectado = registro["PeriodoAfectado"].ToString();
					DTO.CorrelativoAsiento = int.Parse(registro["CorrelativoAsiento"].ToString());
					DTO.Descripcion = registro["Descripcion"].ToString();

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

		public int UltimoAsiento(
			int iConsolidado
			, string sPeriodo
			)
		{
			try
			{
				int iRetorno = 0;
				string sSql = "Select";
				sSql += " Max(correlativoasiento)+1 correlativoasiento";
				sSql += " From EERR_Tbl_Ajustes_cabecera";
				sSql += " Where 1=1 ";
				if(iConsolidado > -1)
				{
					sSql += " And idConsolidado = " + iConsolidado;
				}
				if(sPeriodo != "")
				{
					sSql += " And PeriodoAfectado = '" + sPeriodo + "'";
				}
				//
				hLog.Debug( "Query de lectura de maximo correlativo de asiento {" + sSql + "}" );
				List<DTOAjustes> lDTO = new List<DTOAjustes>();
				//
				DataSet dsContenedor = new DataSet();
				Conexion oCon = new Conexion();
				dsContenedor = oCon.CargarRecordConDatos( sSql );

				foreach(DataRow registro in dsContenedor.Tables[sSql].Rows)
				{
					int.TryParse(registro["CorrelativoAsiento"].ToString(), out iRetorno);
					if (iRetorno == 0) { ++iRetorno; } 
					//iRetorno = int.Parse( registro["CorrelativoAsiento"].ToString() );
				}
				return iRetorno;
			}
			catch (Exception ex)
			{
				string sMensaje = "Error al leer los datos de la tabla {" + ex.Source + "}{" + ex.Message + "}";
				hLog.Fatal(sMensaje);
				throw new SystemException(sMensaje);
			}
		}
		public DTOAjustes ConsultaCuadratura(
			int iConsolidado
			, string sPeriodo
			)
		{
			try
			{

				string sSql = " Select        IdConsolidado";
				if(sPeriodo != "")
				{
					sSql += " , PeriodoAfectado";
				}
				sSql += "       ,Sum(Debito) Debito";
				sSql += "       ,Sum(Credito) Credito";
				sSql += " From EERR_Tbl_Ajustes";
				sSql += " Where 1 = 1";
				if(iConsolidado > -1)
				{
					sSql += " And idConsolidado = " + iConsolidado;
				}
				if(sPeriodo != "")
				{
					sSql += " And PeriodoAfectado = '" + sPeriodo + "'";
				}
				sSql += " Group by IdConsolidado";
				if(sPeriodo != "")
				{
					sSql += " ,PeriodoAfectado";
				}
				//
				hLog.Debug( "Query de lectura de cuadratura de Ajustes del consolidado  {" + sSql + "}" );
				//
				DataSet dsContenedor = new DataSet();
				Conexion oCon = new Conexion();
				dsContenedor = oCon.CargarRecordConDatos( sSql );
				//
				DTOAjustes DTO = new DTOAjustes();
				foreach(DataRow registro in dsContenedor.Tables[sSql].Rows)
				{
					DTO.Debito = decimal.Parse( registro["Debito"].ToString() );
					DTO.Credito = decimal.Parse( registro["Credito"].ToString() );
				}
				return DTO;
			}
			catch (Exception ex)
			{
				string sMensaje = "Error al leer los datos de la tabla {" + ex.Source + "}{" + ex.Message + "}";
				hLog.Fatal(sMensaje);
				throw new SystemException(sMensaje);
			}
		}
		public void CrearAjustes(
			List<DTOAjustes> lAjustes
			)
		{
			try
			{
				string sSql = "";
				ArrayList aSql = new ArrayList();
				foreach (DTOAjustes oDTO in lAjustes)
				{
					sSql = "";
					sSql += "Insert into EERR_Tbl_Ajustes (";
					sSql += "  IdConsolidado";
					sSql += ", PeriodoAfectado";
					sSql += ", CorrelativoAsiento";
					sSql += ", IdCuenta";
					sSql += ", PeriodoVista";
					sSql += ", TipoTransaccion";
					sSql += ", Debito";
					sSql += ", Credito";
					sSql += ", Descripcion";
					sSql += ") values (";
					sSql += oDTO.IdConsolidado.ToString();
					sSql += ", '" + oDTO.PeriodoAfectado + "'";
					sSql += ", " + oDTO.CorrelativoAsiento.ToString();
					sSql += ", '" + oDTO.IdCuenta.ToString() + "'";
					sSql += ", '" + oDTO.PeriodoVista + "'";
					sSql += ", " + oDTO.TipoTransaccion.ToString();
					sSql += ", " + oDTO.Debito.ToString();
					sSql += ", " + oDTO.Credito.ToString();
					sSql += ", '" + oDTO.Descripcion + "'";
					sSql += ")";
					aSql.Add(sSql);
				}

				List<DTOAjustes> oLista = new List<DTOAjustes>();
				oLista = ConsultaCabeceraAsientos(lAjustes[0].IdConsolidado, lAjustes[0].PeriodoAfectado, lAjustes[0].CorrelativoAsiento.ToString());
				if (oLista.Count <= 0)
				{
					sSql = "";
					sSql += "Insert into EERR_Tbl_Ajustes_Cabecera (";
					sSql += "  IdConsolidado";
					sSql += ", PeriodoAfectado";
					sSql += ", CorrelativoAsiento";
					sSql += ", PeriodoVista";
					sSql += ", TipoTransaccion";
					sSql += ", Descripcion";
					sSql += ") values (";
					sSql += lAjustes[0].IdConsolidado.ToString();
					sSql += ", '" + lAjustes[0].PeriodoAfectado + "'";
					sSql += ", " + lAjustes[0].CorrelativoAsiento.ToString();
					sSql += ", '" + lAjustes[0].PeriodoVista + "'";
					sSql += ", " + lAjustes[0].TipoTransaccion.ToString();
					sSql += ", '" + lAjustes[0].DescripcionCabecera + "'";
					sSql += ")";
					aSql.Add(sSql);
					hLog.Debug("Creamos la cabecera para el asiento {" + sSql + "}");
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

        public void EditarRegAjustes(
            List<DTOAjustes> lAjustes
            )
        {
            try
            {
                string sSql = "";
                ArrayList aSql = new ArrayList();
                foreach (DTOAjustes oDTO in lAjustes)
                {
                    sSql = "";
                    sSql += "Insert into EERR_Tbl_Ajustes (";
                    sSql += "  IdConsolidado";
                    sSql += ", PeriodoAfectado";
                    sSql += ", CorrelativoAsiento";
                    sSql += ", IdCuenta";
                    sSql += ", PeriodoVista";
                    sSql += ", TipoTransaccion";
                    sSql += ", Debito";
                    sSql += ", Credito";
                    sSql += ", Descripcion";
                    sSql += ") values (";
                    sSql += oDTO.IdConsolidado.ToString();
                    sSql += ", '" + oDTO.PeriodoAfectado + "'";
                    sSql += ", " + oDTO.CorrelativoAsiento.ToString();
                    sSql += ", '" + oDTO.IdCuenta.ToString() + "'";
                    sSql += ", '" + oDTO.PeriodoVista + "'";
                    sSql += ", " + oDTO.TipoTransaccion.ToString();
                    sSql += ", " + oDTO.Debito.ToString();
                    sSql += ", " + oDTO.Credito.ToString();
                    sSql += ", '" + oDTO.Descripcion + "'";
                    sSql += ")";
                    aSql.Add(sSql);
                }

                if (lAjustes.Count > 0)
                {
                    sSql = "";
                    sSql += "Update EERR_Tbl_Ajustes_Cabecera Set";
                    sSql += " Descripcion = '" + lAjustes[0].DescripcionCabecera +"'";
                    sSql += " Where 1=1";
                    sSql += " And idConsolidado = " + lAjustes[0].IdConsolidado.ToString();
                    sSql += " And CorrelativoAsiento = " + lAjustes[0].CorrelativoAsiento.ToString();
                    aSql.Add(sSql);
                }
                Conexion oCon = new Conexion();
                oCon.EjecucionComandosSql(aSql);
            }
            catch (Exception ex)
            {
                string sMensaje = "Error al cargar los datos de la tabla {" + ex.Source + "}{" + ex.Message + "}";
                hLog.Fatal(sMensaje);
                throw new SystemException(sMensaje);
            }
        }

		public void EditarAjustes(
			List<DTOAjustes> lAjustes
			)
		{
			try
			{
				ArrayList aSql = new ArrayList();
				foreach (DTOAjustes oDTO in lAjustes)
				{
					string sSql = "";
					sSql += "Update EERR_Tbl_Ajustes set";
					sSql += "  IdConsolidado = "+oDTO.IdConsolidado.ToString();
					sSql += ", PeriodoAfectado = '" + oDTO.PeriodoAfectado + "'";
					sSql += ", CorrelativoAsiento = "+ oDTO.CorrelativoAsiento.ToString();
					sSql += ", IdCuenta = '" + oDTO.IdCuenta.ToString() + "'";
					sSql += ", PeriodoVista = '" + oDTO.PeriodoVista + "'";
					sSql += ", TipoTransaccion = "+oDTO.TipoTransaccion.ToString();
					sSql += ", Debito = "+ oDTO.Debito.ToString();;
					sSql += ", Credito = "+ oDTO.Credito.ToString();;
					sSql += ", Descripcion = '" + oDTO.Descripcion + "'";
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
		public void EliminarAjustes(
			List<DTOAjustes> lAjustes
			)
		{
			try
			{
				ArrayList aSql = new ArrayList();
				foreach (DTOAjustes oDTO in lAjustes)
				{
					string sSql = "";
					sSql += "Delete from EERR_Tbl_Ajustes";
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
		public void AnularAsiento(
			int iConsolidado
			, int iCorrelativo
			, string sPeriodo
			)
		{
			try
			{
				ArrayList aSql = new ArrayList();
				//Cambiar estado a la cabecera
				string sSql = "";
				sSql += "Update EERR_Tbl_Ajustes_Cabecera Set";
				sSql += " TipoTransaccion = " + Convert.ToString((int)CFG.TipoAjuste.Anulado);
				sSql += " Where idConsolidado = " + iConsolidado;
				sSql += " And CorrelativoAsiento = " + iCorrelativo;
				sSql += " And PeriodoAfectado = '" + sPeriodo + "'";
				aSql.Add(sSql);
				hLog.Debug("Actualizamos la cabecera {" + sSql + "}");
				//
				// Eliminar los asientos
				sSql = "";
				sSql += "Delete from EERR_Tbl_Ajustes";
				sSql += " Where idConsolidado = " + iConsolidado;
				sSql += " And CorrelativoAsiento = " + iCorrelativo;
				sSql += " And PeriodoAfectado = '" + sPeriodo + "'";
				aSql.Add(sSql);
				hLog.Debug("Eliminamos los asientos {" + sSql + "}");
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
		public void EjecutaAjustesAutomaticos(
			int iIdConsolidado
			, string sLibros
			, string sPeriodo
			)
		{
			try
			{
				//TODO: crear otro metodo en la clase conexion para este procedimiento para poder ver los Subllamados 
				string sTexto = "lanzamos el procedimiento almacenado EERR_Sp_Ajustes_Automaticos ";
				sTexto += "{" + iIdConsolidado.ToString() + "}";
				sTexto += "{" + sLibros + "}";
				sTexto += "{" + sPeriodo + "}";
				hLog.Debug(sTexto);

				ArrayList aSql = new ArrayList();
				string sSql = "";
				sSql += "execute EERR_Sp_Ajustes_Automaticos ";
				sSql += iIdConsolidado.ToString();
				sSql += ", '" + sPeriodo + "'";
				sSql += ", '" + sLibros + "'";
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
        public void CopiarAjustes(
            int idConsolidadoOriginal
            , int idConsolidadoNuevo
            )
        {
            try
            {
                string sSql = "";
                ArrayList aSql = new ArrayList();
                    sSql = "";
                    sSql += "Insert into EERR_Tbl_Ajustes (";
                    sSql += "  IdConsolidado";
                    sSql += ", PeriodoAfectado";
                    sSql += ", CorrelativoAsiento";
                    sSql += ", IdCuenta";
                    sSql += ", PeriodoVista";
                    sSql += ", TipoTransaccion";
                    sSql += ", Debito";
                    sSql += ", Credito";
                    sSql += ", Descripcion";
                    sSql += ") Select ";
                    sSql += idConsolidadoNuevo.ToString();
                    sSql += ", PeriodoAfectado";
                    sSql += ", CorrelativoAsiento";
                    sSql += ", IdCuenta";
                    sSql += ", PeriodoVista";
                    sSql += ", TipoTransaccion";
                    sSql += ", Debito";
                    sSql += ", Credito";
                    sSql += ", Descripcion";
                    sSql += " From EERR_Tbl_Ajustes ";
                    sSql += " Where idConsolidado = " + idConsolidadoOriginal.ToString();
                    aSql.Add(sSql);

                    sSql = "";
                    sSql += "Insert into EERR_Tbl_Ajustes_Cabecera (";
                    sSql += "  IdConsolidado";
                    sSql += ", PeriodoAfectado";
                    sSql += ", CorrelativoAsiento";
                    sSql += ", PeriodoVista";
                    sSql += ", TipoTransaccion";
                    sSql += ", Descripcion";
                    sSql += ") Select ";
                    sSql += idConsolidadoNuevo.ToString();
                    sSql += ", PeriodoAfectado";
                    sSql += ", CorrelativoAsiento";
                    sSql += ", PeriodoVista";
                    sSql += ", TipoTransaccion";
                    sSql += ", Descripcion";
                    sSql += " From EERR_Tbl_Ajustes_Cabecera ";
                    sSql += " Where idConsolidado = " + idConsolidadoOriginal.ToString();
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
	}
}
