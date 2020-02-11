using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NewConsolidado.Controladores.Clases;
using NewConsolidado.Modelos.AccesoDatos;
using NewConsolidado.Modelos.TransporteDatos;

namespace NewConsolidado.Controladores.ControladorNegocio
{
    class BOConfiguracionComparativos
    {
        private MyLog4Net hLog = new MyLog4Net("BOConfiguracionComparativos.class");

        public List<DTOConfiguracionComparativos> ConsultaComparativos
            (
            int iIdConsolidado
            , int iTipo
            , string sPeriodo
            )
        {
            try
            {
                DAOConfiguracionComparativos oDAO = new DAOConfiguracionComparativos();

                return oDAO.ConsultaConfiguracionComparativo(iIdConsolidado, iTipo, sPeriodo);
            }
            catch (Exception ex)
            {
                hLog.Fatal(ex.Message);
                throw new SystemException(ex.Message);
            }
        }

        public DTOConfiguracionComparativos ObtienePorDefecto
            (
            int iIdConsolidado
            , int iTipo
            )
        {
            try
            {
                DAOConfiguracionComparativos oDAO = new DAOConfiguracionComparativos();
                List<DTOConfiguracionComparativos> lDTO = new List<DTOConfiguracionComparativos>();
                DTOConfiguracionComparativos oDTO = new DTOConfiguracionComparativos();

                lDTO = oDAO.ConsultaConfiguracionComparativo(iIdConsolidado, iTipo, "");

                foreach (DTOConfiguracionComparativos pDTO in lDTO)
                {
                    if (pDTO.PorDefecto == (int)CFG.SiNo.Si)
                    {
                        oDTO = pDTO;
                    }
                }

                return oDTO;
            }
            catch (Exception ex)
            {
                hLog.Fatal(ex.Message);
                throw new SystemException(ex.Message);
            }
        }

        public void ActualizaPorDefecto
            (
            int iIdConsolidado
            , int iTipo
            , string sPeriodo
            )
        {
            try
            {
                DAOConfiguracionComparativos oDAO = new DAOConfiguracionComparativos();
                oDAO.ActualizaPorDefecto(iIdConsolidado, iTipo, sPeriodo);
            }
            catch (Exception ex)
            {
                hLog.Fatal(ex.Message);
                throw new SystemException(ex.Message);
            }
        }

        public void EliminaConfiguracion
            (
            int iIdConsolidado
            , int iTipo
            , string sPeriodo
            )
        {
            try
            {
                DAOConfiguracionComparativos oDAO = new DAOConfiguracionComparativos();
                oDAO.EliminaConfiguracion(iIdConsolidado, iTipo, sPeriodo);
            }
            catch (Exception ex)
            {
                hLog.Fatal(ex.Message);
                throw new SystemException(ex.Message);
            }
        }

        public void AceptarPeriodo
            (
            int iIdConsolidado
            , int iTipo
            , string sPeriodo
            , int iIdComparativo
            , string sPeriodoComparativo
            )
        {
            DAOConfiguracionComparativos oDAO = new DAOConfiguracionComparativos();
            BOConfiguracionComparativos oBOC = new BOConfiguracionComparativos();
            List<DTOConfiguracionComparativos> lConf = new List<DTOConfiguracionComparativos>();
            lConf = oBOC.ConsultaComparativos(iIdConsolidado, iTipo, sPeriodo);
            if (lConf.Count > 0)
            {
                oDAO.EliminaConfiguracion(iIdConsolidado, iTipo, sPeriodo);

            }
            oDAO.CrearConfiguracion(iIdConsolidado, iTipo, sPeriodo, iIdComparativo, sPeriodoComparativo);
            oBOC.ActualizaPorDefecto(iIdConsolidado, iTipo, sPeriodo);
        }
    }
}
