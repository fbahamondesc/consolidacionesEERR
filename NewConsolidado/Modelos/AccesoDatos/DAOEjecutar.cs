using System;

using NewConsolidado.Controladores.Clases;

namespace NewConsolidado.Modelos.AccesoDatos
{
    class DAOEjecutar
    {
        private MyLog4Net hLog = new MyLog4Net("DAOEjecutar.class");

        public void EjecutaCarga()
        {
            try
            {
                hLog.Debug("lanzamos el procedimiento almacenado EERR_Sp_Carga_Datos_Dynamics");

                Conexion oCon = new Conexion();
                oCon.EjecutaCargaDatosDynamics();
            }
            catch (Exception ex)
            {
                throw new SystemException(Environment.NewLine + "[DAOEjecutar.EjecutaCarga]" + ex.Message);
            }
        }

        public void EjecutarSincronizarODBC_ERF(
            int iIdConsoidado
            , string sPeriodo
            , string sLibros
            , string sUsuario
            )
        {
            try
            {
                hLog.Debug("lanzamos el procedimiento almacenado EERR_Sp_Reporte_ERF_TMP_Genera");

                Conexion oCon = new Conexion();
                oCon.EjecutaCargaDatosDynamics_ERF(iIdConsoidado, sPeriodo, sLibros, sUsuario);
            }
            catch (Exception ex)
            {
                throw new SystemException(Environment.NewLine + "[DAOEjecutar.EjecutarSincronizarODBC_ERF]" + ex.Message);
            }
        }

        public void EjecutarSincronizarODBC_ESF(
            int iIdConsoidado
            , string sPeriodo
            , string sLibros
            , string sUsuario
            )
        {
            try
            {
                hLog.Debug("lanzamos el procedimiento almacenado EERR_Sp_Reporte_ESF_TMP_Genera");

                Conexion oCon = new Conexion();
                oCon.EjecutaCargaDatosDynamics_ESF(iIdConsoidado, sPeriodo, sLibros, sUsuario);
            }
            catch (Exception ex)
            {
                throw new SystemException(Environment.NewLine + "[DAOEjecutar.EjecutarSincronizarODBC_ESF]" + ex.Message);
            }
        }
    }
}