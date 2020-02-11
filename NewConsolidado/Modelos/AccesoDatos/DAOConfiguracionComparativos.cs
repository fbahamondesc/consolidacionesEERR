using System;
using System.Collections.Generic;
using System.Data;
using System.Collections;

using NewConsolidado.Controladores.Clases;
using NewConsolidado.Modelos.TransporteDatos;

namespace NewConsolidado.Modelos.AccesoDatos
{
    class DAOConfiguracionComparativos
    {
        private MyLog4Net hLog = new MyLog4Net("DAOConfiguracionComparativos.class");

        public List<DTOConfiguracionComparativos> ConsultaConfiguracionComparativo(
            int iIdConsolidado
            , int iTipo
            , string sPeriodo
            )
        {
            try
            {
                string sSql = "";

                sSql += " Select ";
                sSql += "		  TCC.IdConsolidado";
                sSql += "		, TCC.Tipo";
                sSql += "		, TCC.Periodo";
                sSql += "		, TCC.IdComparativo";
                sSql += "		, TCC.PeriodoComparativo";
                sSql += "		, (select TC.Codigo from EERR_Tbl_Consolidados TC where TC.IdRegistro = TCC.IdComparativo) as CodigoComparativo";
                sSql += "		, TCC.PorDefecto";
                sSql += " From ";
                sSql += "		EERR_Tbl_Configuracion_Comparativos TCC";
                //sSql += "		, EERR_Tbl_Consolidados TC";
                sSql += " Where	1 = 1";
                //sSql += "		And TC.IdRegistro = TCC.IdComparativo";

                if (iIdConsolidado > 0)
                {
                    sSql += " And TCC.IdConsolidado = " + iIdConsolidado;
                }
                if (iTipo > 0)
                {
                    sSql += " And TCC.Tipo = '" + iTipo + "'";
                }
                if (!string.IsNullOrEmpty(sPeriodo))
                {
                    sSql += " And TCC.Periodo = '" + sPeriodo + "'";
                }

                sSql += " order by TCC.Periodo";
                hLog.Debug("Query de lectura de configuracion de comparativos {" + sSql + "}");
                //
                DataSet dsContenedor = new DataSet();
                Conexion oCon = new Conexion();
                dsContenedor = oCon.CargarRecordConDatos(sSql);
                //
                List<DTOConfiguracionComparativos> lDTO = new List<DTOConfiguracionComparativos>();
                foreach (DataRow registro in dsContenedor.Tables[sSql].Rows)
                {
                    DTOConfiguracionComparativos oDTO = new DTOConfiguracionComparativos();
                    oDTO.IdConsolidado = int.Parse(registro["IdConsolidado"].ToString());
                    oDTO.Tipo = int.Parse(registro["Tipo"].ToString());
                    oDTO.Periodo = registro["Periodo"].ToString();
                    oDTO.IdComparativo = int.Parse(registro["IdComparativo"].ToString());
                    oDTO.PeriodoComparativo = registro["PeriodoComparativo"].ToString();
                    oDTO.CodigoComparativo = registro["CodigoComparativo"].ToString();
                    if (!string.IsNullOrEmpty(registro["PorDefecto"].ToString()))
                    {
                        oDTO.PorDefecto = int.Parse(registro["PorDefecto"].ToString());
                    }
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

        public void ActualizaPorDefecto
            (
            int iIdConsolidado
            , int iTipo
            , string sPeriodo
            )
        {
            string sSql = "";
            ArrayList aSql = new ArrayList();

            try
            {
                sSql = " Update EERR_Tbl_Configuracion_Comparativos Set ";
                sSql += " PorDefecto = " + (int)CFG.SiNo.No;
                sSql += " Where IdConsolidado = " + iIdConsolidado;
                sSql += " And Tipo = " + iTipo;
                aSql.Add(sSql);

                sSql = " Update EERR_Tbl_Configuracion_Comparativos Set ";
                sSql += " PorDefecto = " + (int)CFG.SiNo.Si;
                sSql += " Where IdConsolidado = " + iIdConsolidado;
                sSql += " And Tipo = " + iTipo;
                sSql += " And Periodo = '" + sPeriodo + "'";
                aSql.Add(sSql);

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

        public void EliminaConfiguracion
            (
            int iIdConsolidado
            , int iTipo
            , string sPeriodo
            )
        {
            string sSql = "";
            ArrayList aSql = new ArrayList();

            try
            {
                sSql = " Delete EERR_Tbl_Configuracion_Comparativos ";
                sSql += " Where IdConsolidado = " + iIdConsolidado;
                sSql += " And Tipo = " + iTipo;
                sSql += " And Periodo = '" + sPeriodo + "'";
                aSql.Add(sSql);

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

        public void CrearConfiguracion
            (
            int iIdConsolidado
            , int iTipo
            , string sPeriodo
            , int iIdComparativo
            , string sPeriodoComparativo
            )
        {
            string sSql = "";
            ArrayList aSql = new ArrayList();
            try
            {
                sSql = " Insert Into EERR_Tbl_Configuracion_Comparativos ";
                sSql += " ( ";
                sSql += "  idConsolidado";
                sSql += ", Tipo";
                sSql += ", Periodo";
                sSql += ", idComparativo";
                sSql += ", PeriodoComparativo";
                sSql += ", pordefecto";
                sSql += " )";
                sSql += " Values ";
                sSql += " ( ";
                sSql += "   " + iIdConsolidado.ToString();
                sSql += ",  " + iTipo.ToString();
                sSql += ", '" + sPeriodo + "'";
                sSql += ",  " + iIdComparativo.ToString();
                sSql += ", '" + sPeriodoComparativo + "'";
                sSql += ",  " + (int)CFG.SiNo.Si;
                sSql += " )";
                aSql.Add(sSql);

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
    }
}
