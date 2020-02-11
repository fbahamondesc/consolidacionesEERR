using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NewConsolidado.Controladores.Clases;
using NewConsolidado.Modelos.AccesoDatos;
using NewConsolidado.Modelos.TransporteDatos;

namespace NewConsolidado.Controladores.ControladorNegocio
{
    class BOSincronizacionODBC
    {
        private MyLog4Net hLog = new MyLog4Net("BOConceptos.class");

        public void SincronizarODBC(
            int iTipo
            , int iIdConsolidado
            , string sPeriodo
            , string sLibros
            , string sUsuario)
        {
            try
            {
                DAOEjecutar oDAO = new DAOEjecutar();
                switch (iTipo)
                {
                    case (int)CFG.TipoConfImpresion.ESF:
                        {
                            oDAO.EjecutarSincronizarODBC_ESF(iIdConsolidado, sPeriodo, sLibros, sUsuario);
                            break;
                        }
                    case (int)CFG.TipoConfImpresion.ERF:
                        {
                            oDAO.EjecutarSincronizarODBC_ERF(iIdConsolidado, sPeriodo, sLibros, sUsuario);
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                throw new SystemException(Environment.NewLine + "[BOConceptos.SincronizarODBC]" + ex.Message);
            }
        }
    }
}
