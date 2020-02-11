using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NewConsolidado.Controladores.Clases;
using NewConsolidado.Modelos.AccesoDatos;
using NewConsolidado.Modelos.TransporteDatos;

namespace NewConsolidado.Controladores.ControladorNegocio
{
    class BOConsolidadosAsociacionGrupo
    {
        private MyLog4Net hLog = new MyLog4Net("BOConsolidadosAsociacionGrupo.class");

        public BOConsolidadosAsociacionGrupo()
        { }

        public List<DTOConsolidadosAsociacionGrupo> ConsultaAsociacion(
            string sIdConsolidado
            )
        {
            try
            {
                return ConsultaAsociacion(sIdConsolidado, "", "", "", "");
            }
            catch (Exception ex)
            {
                hLog.Fatal(ex.Message);
                throw new SystemException(ex.Message);
            }
        }

        public List<DTOConsolidadosAsociacionGrupo> ConsultaAsociacion(
            string sIdConsolidado
            , string sidRegistro
            )
        {
            try
            {
                return ConsultaAsociacion(sIdConsolidado, sidRegistro, "", "", "");
            }
            catch (Exception ex)
            {
                hLog.Fatal(ex.Message);
                throw new SystemException(ex.Message);
            }
        }

        public List<DTOConsolidadosAsociacionGrupo> ConsultaAsociacion(
            string sIdConsolidado
            , string sIdGrupo
            , string sIdConcepto
            , string sIdCuenta
            )
        {
            try
            {
                return ConsultaAsociacion(sIdConsolidado, "", sIdGrupo, sIdConcepto, sIdCuenta);
            }
            catch (Exception ex)
            {
                hLog.Fatal(ex.Message);
                throw new SystemException(ex.Message);
            }
        }

        public List<DTOConsolidadosAsociacionGrupo> ConsultaAsociacion(
            string sIdConsolidado
            , string sIdRegistro
            , string sIdGrupo
            , string sIdConcepto
            , string sIdCuenta
            )
        {
            try
            {
                List<DTOConsolidadosAsociacionGrupo> lLista = new List<DTOConsolidadosAsociacionGrupo>();
                DAOConsolidadosAsociacionGrupo oDAO = new DAOConsolidadosAsociacionGrupo();
                //
                hLog.Debug("Consultamos Asociaciones de Grupo/Concepto/Cuenta");
                lLista = oDAO.ConsultaAsociacion(sIdConsolidado, sIdRegistro, sIdGrupo, sIdConcepto, sIdCuenta);
                return lLista;
            }
            catch (Exception ex)
            {
                hLog.Fatal(ex.Message);
                throw new SystemException(ex.Message);
            }
        }

        public void GrabarAjustes(
            List<DTOConsolidadosAsociacionGrupo> lAsocia
            , int iAccion
            )
        {
            try
            {
                DAOConsolidadosAsociacionGrupo oDAO = new DAOConsolidadosAsociacionGrupo();

                switch (iAccion)
                {
                    case (int)CFG.ToolAcciones.Nuevo:
                        {
                            oDAO.CrearAsociacion(lAsocia);
                            break;
                        }
                    case (int)CFG.ToolAcciones.Editar:
                        {
                            oDAO.EditarAsociacion(lAsocia);
                            break;
                        }
                    case (int)CFG.ToolAcciones.Eliminar:
                        {
                            oDAO.EliminarAsociacion(lAsocia);
                            break;
                        }
                    default:
                        {
                            hLog.Fatal("Mala clasificacion al {GrabarAjustes}");
                            throw new SystemException("Mala clasificacion al {GrabarAjustes}");

                        }
                }
            }
            catch (Exception ex)
            {
                hLog.Fatal(ex.Message);
                throw new SystemException(ex.Message);
            }
        }

        public void CrearAsociacion(
            List<DTOConsolidadosAsociacionGrupo> lAsocia
            )
        {
            try
            {
                DAOConsolidadosAsociacionGrupo oDAO = new DAOConsolidadosAsociacionGrupo();
                oDAO.CrearAsociacion(lAsocia);
            }
            catch (Exception ex)
            {
                hLog.Fatal(ex.Message);
                throw new SystemException(ex.Message);
            }
        }

        public void EditarAsociacion(
            List<DTOConsolidadosAsociacionGrupo> lAsocia
            )
        {
            try
            {
                DAOConsolidadosAsociacionGrupo oDAO = new DAOConsolidadosAsociacionGrupo();
                oDAO.EditarAsociacion(lAsocia);
            }
            catch (Exception ex)
            {
                hLog.Fatal(ex.Message);
                throw new SystemException(ex.Message);
            }
        }

        public void EliminarAsociacion(
            List<DTOConsolidadosAsociacionGrupo> lAsocia
            )
        {
            try
            {
                DAOConsolidadosAsociacionGrupo oDAO = new DAOConsolidadosAsociacionGrupo();
                oDAO.EliminarAsociacion(lAsocia);
            }
            catch (Exception ex)
            {
                hLog.Fatal(ex.Message);
                throw new SystemException(ex.Message);
            }
        }

        public void AplicarPlantilla(
            string sIdConsolidado
            )
        {
            try
            {
                //Eliminacion de todos los registros
                List<DTOConsolidadosAsociacionGrupo> lDTO = new List<DTOConsolidadosAsociacionGrupo>();
                lDTO = ConsultaAsociacion(sIdConsolidado);
                EliminarAsociacion(lDTO);

                //Aplicar la plantilla
                DAOConsolidadosAsociacionGrupo oDAO = new DAOConsolidadosAsociacionGrupo();
                oDAO.AplicarPlantilla(sIdConsolidado);
            }
            catch (Exception ex)
            {
                hLog.Fatal(ex.Message);
                throw new SystemException(ex.Message);
            }
        }

        public void AplicarPlantillaTodos()
        {
            try
            {
                BOConsolidados oBOC = new BOConsolidados();
                List<DTOConsolidados> lDTO = oBOC.ConsultaConsolidados((int)CFG.TipoConsolidado.Consolidado, "", "");

                DAOConsolidadosAsociacionGrupo oDAO = new DAOConsolidadosAsociacionGrupo();
                oDAO.AplicarPlantilla(lDTO);
            }
            catch (Exception ex)
            {
                hLog.Fatal(ex.Message);
                throw new SystemException(ex.Message);
            }
        }

        public void AplicaPlantillaSeleccionadas(string sCodigos)
        {
            try
            {
                BOConsolidados oBOC = new BOConsolidados();
                List<DTOConsolidados> lDTO = new List<DTOConsolidados>();
                string[] aCodigos = sCodigos.Split('¨');
                foreach (string sLinea in aCodigos)
                {
                    string[] aLinea = sLinea.Split('^');
                    List<DTOConsolidados> lResp = oBOC.ConsultaConsolidados(aLinea[0], aLinea[1]);
                    foreach (DTOConsolidados oDTO in lResp)
                    {
                        lDTO.Add(oDTO);
                    }
                }

                DAOConsolidadosAsociacionGrupo oDAO = new DAOConsolidadosAsociacionGrupo();
                oDAO.AplicarPlantilla(lDTO);

            }
            catch (Exception ex)
            {
                hLog.Fatal(ex.Message);
                throw new SystemException(ex.Message);
            }
        }
    }
}