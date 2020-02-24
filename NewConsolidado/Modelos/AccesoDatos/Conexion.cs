using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

using NewConsolidado.Controladores.Clases;

namespace NewConsolidado.Modelos.AccesoDatos
{
    class Conexion
    {
        private MyLog4Net hLog = new MyLog4Net("Conexion.class");
        private string connectionString = "";

        public Conexion()
        {
            if (Globales.ConexionSSPI)
            {
                connectionString += "Data Source=" + NewConsolidado.Properties.Settings.Default.strConnSource;
                connectionString += ";Initial Catalog=" + NewConsolidado.Properties.Settings.Default.strConnCatalog;
                connectionString += ";Integrated Security=SSPI";
            }
            else
            {
                connectionString = "data source = " + NewConsolidado.Properties.Settings.Default.strConnSource;
                connectionString += "; initial catalog = " + NewConsolidado.Properties.Settings.Default.strConnCatalog;
                //connectionString += "; user id = " + NewConsolidado.Properties.Settings.Default.strConnUser;
                //connectionString += "; password = " + NewConsolidado.Properties.Settings.Default.strConnPassword;
                connectionString += ";Integrated Security=SSPI";
            }
            //hLog.Debug("Conexion de datos : [" + connectionString + "]");
        }

        /// <summary>
        /// Metodo que conecta a la BD y Carga de Datos
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public DataSet CargarRecordConDatos(string strSql)
        {
            try
            {
                hLog.Info("CargarRecordConDatos ,sql{" + strSql + "}");
                // Crea la conexion
                SqlConnection bdConexion = new SqlConnection(connectionString);

                //Crear un objeto DataAdapter y proporcionar el string de Consulta. 
                bdConexion.Open();

                //Crear un nuevo objeto DataSet para alojar los registros. 
                SqlDataAdapter MyDataAdapter = new SqlDataAdapter(strSql, bdConexion);

                // Creo el contendor de los datos ( recordset )
                DataSet dsContenedor = new DataSet();

                //Rellenar el DataSet con las filas devueltas. 
                MyDataAdapter.Fill(dsContenedor, strSql);

                // Cierro la conexion
                bdConexion.Close();

                // Retorno el DataSet
                return dsContenedor;
            }
            catch (Exception ex)
            {
                throw new SystemException(Environment.NewLine + "[Conexion.CargarRecordConDatos]" + ex.Message);
            }
        }
        /// <summary>
        /// Metodo que permite ejecutar comando sin retorno de datos ni parametros
        /// </summary>
        /// <param name="aQuery"></param>
        public void EjecucionComandosSql(ArrayList aQuery)
        {
            //hLog.Info("EjecucionComandosSql, {" + aQuery.ToString() + "}");
            SqlConnection conConexion = new SqlConnection(connectionString);
            // Creo la variable de manejo SQL
            SqlCommand cmmCommand = new SqlCommand();
            // Creo el objeto de transaccion
            SqlTransaction trnTransaccion = null;

            try
            {
                // Asigno la conexion a utilizar
                cmmCommand.Connection = conConexion;
                // Hago la apertura de la conexion11
                cmmCommand.Connection.Open();
                // Se asigna el objeto de Transacciones 
                trnTransaccion = cmmCommand.Connection.BeginTransaction(IsolationLevel.ReadCommitted, "Transaccion");
                // Asigno al comando la transaccion
                cmmCommand.Transaction = trnTransaccion;
                // Creo el comando de tipo texto
                cmmCommand.CommandType = CommandType.Text;

                foreach (string sSql in aQuery)
                {
                    hLog.Debug("ejecuto el sql {" + sSql + "}");
                    // Asigno la query a ejecutar
                    cmmCommand.CommandText = sSql;
                    cmmCommand.CommandTimeout = 0;
                    // ejecuta query sin devolucion 
                    cmmCommand.ExecuteNonQuery();
                }
                trnTransaccion.Commit();
                // Cierro la conexion y libero el recurso
                cmmCommand.Connection.Close();
                conConexion.Close();
            }
            catch (Exception ex)
            {
                throw new SystemException(Environment.NewLine + "[Conexion.EjecucionComandosSql]" + ex.Message);
            }
        }
        /// <summary>
        /// Metodo para ejecutar procedimientos almacenados especificos para esta aplicacion
        /// </summary>
        /// <param name="aQuery"></param>
        public DataSet EjecucionProcedimientoReportes(string sProcedimiento, int hIdConsolidado, string hPeriodo, int hIdConsolidadoComparar, string hPeriodoComparar, string hLibros)
        {
            SqlConnection conConexion = new SqlConnection(connectionString);
            // Creo el comando al procedimiento
            SqlCommand cmmCommand = new SqlCommand();
            //Le asignamos la conexion.
            cmmCommand.Connection = conConexion;
            cmmCommand.CommandTimeout = 0;
            //especificamos que el comando es un stored procedure
            cmmCommand.CommandType = CommandType.StoredProcedure;
            //y escribimos el nombre del stored procedure a invocar
            cmmCommand.CommandText = sProcedimiento;
            try
            {
                //Parametro de retorno del procedimiento
                //SqlParameter oRetVal = cmmCommand.Parameters.Add("RetVal", SqlDbType.Int);
                //oRetVal.Direction = ParameterDirection.ReturnValue;
                SqlParameter oRetorno = new SqlParameter();
                oRetorno.ParameterName = "RetVal";
                oRetorno.SqlDbType = SqlDbType.Int;
                oRetorno.Value = 0;
                oRetorno.Direction = ParameterDirection.ReturnValue;
                cmmCommand.Parameters.Add(oRetorno);

                //Parametro de Ingreso
                SqlParameter IdConsolidado = cmmCommand.Parameters.Add("@iIdConsolidado", SqlDbType.Int);
                IdConsolidado.Direction = ParameterDirection.Input;
                //
                SqlParameter Periodo = cmmCommand.Parameters.Add("@sPeriodo", SqlDbType.VarChar, 8);
                Periodo.Direction = ParameterDirection.Input;
                //
                SqlParameter IdConsolidadoComparar = cmmCommand.Parameters.Add("@iIdConsolidadoComparar", SqlDbType.Int);
                IdConsolidadoComparar.Direction = ParameterDirection.Input;
                //
                SqlParameter PeriodoComparar = cmmCommand.Parameters.Add("@sPeriodoComparar", SqlDbType.VarChar, 8);
                PeriodoComparar.Direction = ParameterDirection.Input;
                //
                SqlParameter Libros = cmmCommand.Parameters.Add("@sLibros", SqlDbType.VarChar, 100);
                Libros.Direction = ParameterDirection.Input;
                //
                //SqlParameter NumTitles = cmmCommand.Parameters.Add("@numtitlesout", SqlDbType.VarChar, 11);
                //NumTitles.Direction = ParameterDirection.Output;

                IdConsolidado.Value = hIdConsolidado;
                Periodo.Value = hPeriodo;
                IdConsolidadoComparar.Value = hIdConsolidadoComparar;
                PeriodoComparar.Value = hPeriodoComparar;
                Libros.Value = hLibros;

                conConexion.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmmCommand);
                DataSet ds = new DataSet();
                da.Fill(ds);
                conConexion.Close();
                hLog.Debug(Convert.ToString(oRetorno.Value));
                if ((int)oRetorno.Value == 1)
                {
                    throw new SystemException(Environment.NewLine + "[Conexion.EjecucionProcedimientoReportes] Error enviado desde el procedimiento");
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw new SystemException(Environment.NewLine + "[Conexion.EjecucionProcedimientoReportes]" + ex.Message);
            }
        }
        /// <summary>
        /// Procedimiento especifico para cargar los datos de Dynamics desde la aplicacion
        /// </summary>
        /// <returns></returns>
        public void EjecutaCargaDatosDynamics()
        {
            try
            {
                // Conexion para el procedimiento
                SqlConnection conConexion = new SqlConnection(connectionString);
                SqlCommand cmmCommand = new SqlCommand();
                // Procedimiento a ejecutar
                cmmCommand.Connection = conConexion;
                cmmCommand.CommandType = CommandType.StoredProcedure;
                cmmCommand.CommandText = "EERR_sp_Carga_Datos_Dynamics";
                cmmCommand.CommandTimeout = 0;
                //Valor de retorno del procedimento
                SqlParameter oRetorno = new SqlParameter();
                oRetorno.ParameterName = "iRetVal";
                oRetorno.SqlDbType = SqlDbType.Int;
                oRetorno.Direction = ParameterDirection.ReturnValue;
                cmmCommand.Parameters.Add(oRetorno);
                // Abrimos la conexion
                conConexion.Open();
                cmmCommand.ExecuteNonQuery();
                if ((int)oRetorno.Value == 1)
                {
                    throw new SystemException(Environment.NewLine + "[Conexion.EjecutaCargaDatosDynamics] Error enviado desde el procedimiento");
                }

            }
            catch (Exception ex)
            {
                throw new SystemException(Environment.NewLine + "[Conexion.EjecutaCargaDatosDynamics]" + ex.Message);
            }
        }

        public DataSet EjecutaCargaDatosDynamics_ERF(int iIdConsolidado, string sPeriodo, string sLibros, string sUsuario)
        {
            SqlConnection conConexion = new SqlConnection(connectionString);
            // Creo el comando al procedimiento
            SqlCommand cmmCommand = new SqlCommand();
            //Le asignamos la conexion.
            cmmCommand.Connection = conConexion;
            cmmCommand.CommandTimeout = 0;
            //especificamos que el comando es un stored procedure
            cmmCommand.CommandType = CommandType.StoredProcedure;
            //y escribimos el nombre del stored procedure a invocar
            cmmCommand.CommandText = "EERR_Sp_Reporte_ERF_TMP_Genera";
            try
            {
                //Parametro de retorno del procedimiento
                //SqlParameter oRetVal = cmmCommand.Parameters.Add("RetVal", SqlDbType.Int);
                //oRetVal.Direction = ParameterDirection.ReturnValue;
                SqlParameter oRetorno = new SqlParameter();
                oRetorno.ParameterName = "RetVal";
                oRetorno.SqlDbType = SqlDbType.Int;
                oRetorno.Value = 0;
                oRetorno.Direction = ParameterDirection.ReturnValue;
                cmmCommand.Parameters.Add(oRetorno);

                //Parametro de Ingreso
                SqlParameter IdConsolidado = cmmCommand.Parameters.Add("@iIdConsolidado", SqlDbType.Int);
                IdConsolidado.Direction = ParameterDirection.Input;
                //
                SqlParameter Periodo = cmmCommand.Parameters.Add("@sPeriodo", SqlDbType.VarChar, 8);
                Periodo.Direction = ParameterDirection.Input;
                //
                SqlParameter Libros = cmmCommand.Parameters.Add("@sLibros", SqlDbType.VarChar, 100);
                Libros.Direction = ParameterDirection.Input;
                //
                SqlParameter Usuario = cmmCommand.Parameters.Add("@sUsuario", SqlDbType.VarChar, 200);
                Usuario.Direction = ParameterDirection.Input;

                IdConsolidado.Value = iIdConsolidado;
                Periodo.Value = sPeriodo;
                Libros.Value = sLibros;
                Usuario.Value = sUsuario;

                conConexion.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmmCommand);
                DataSet ds = new DataSet();
                da.Fill(ds);
                conConexion.Close();
                hLog.Debug(Convert.ToString(oRetorno.Value));
                if ((int)oRetorno.Value == 1)
                {
                    throw new SystemException(Environment.NewLine + "[Conexion.EjecutaCargaDatosDynamics_ERF] Error enviado desde el procedimiento");
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw new SystemException(Environment.NewLine + "[Conexion.EjecutaCargaDatosDynamics_ERF]" + ex.Message);
            }
        }

        public DataSet EjecutaCargaDatosDynamics_ESF(int iIdConsolidado, string sPeriodo, string sLibros, string sUsuario)
        {
            SqlConnection conConexion = new SqlConnection(connectionString);
            // Creo el comando al procedimiento
            SqlCommand cmmCommand = new SqlCommand();
            //Le asignamos la conexion.
            cmmCommand.Connection = conConexion;
            cmmCommand.CommandTimeout = 0;
            //especificamos que el comando es un stored procedure
            cmmCommand.CommandType = CommandType.StoredProcedure;
            //y escribimos el nombre del stored procedure a invocar
            cmmCommand.CommandText = "EERR_Sp_Reporte_ESF_TMP_Genera";
            try
            {
                //Parametro de retorno del procedimiento
                //SqlParameter oRetVal = cmmCommand.Parameters.Add("RetVal", SqlDbType.Int);
                //oRetVal.Direction = ParameterDirection.ReturnValue;
                SqlParameter oRetorno = new SqlParameter();
                oRetorno.ParameterName = "RetVal";
                oRetorno.SqlDbType = SqlDbType.Int;
                oRetorno.Value = 0;
                oRetorno.Direction = ParameterDirection.ReturnValue;
                cmmCommand.Parameters.Add(oRetorno);

                //Parametro de Ingreso
                SqlParameter IdConsolidado = cmmCommand.Parameters.Add("@iIdConsolidado", SqlDbType.Int);
                IdConsolidado.Direction = ParameterDirection.Input;
                //
                SqlParameter Periodo = cmmCommand.Parameters.Add("@sPeriodo", SqlDbType.VarChar, 8);
                Periodo.Direction = ParameterDirection.Input;
                //
                SqlParameter Libros = cmmCommand.Parameters.Add("@sLibros", SqlDbType.VarChar, 100);
                Libros.Direction = ParameterDirection.Input;
                //
                SqlParameter Usuario = cmmCommand.Parameters.Add("@sUsuario", SqlDbType.VarChar, 200);
                Usuario.Direction = ParameterDirection.Input;

                IdConsolidado.Value = iIdConsolidado;
                Periodo.Value = sPeriodo;
                Libros.Value = sLibros;
                Usuario.Value = sUsuario;

                conConexion.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmmCommand);
                DataSet ds = new DataSet();
                da.Fill(ds);
                conConexion.Close();
                hLog.Debug(Convert.ToString(oRetorno.Value));
                if ((int)oRetorno.Value == 1)
                {
                    throw new SystemException(Environment.NewLine + "[Conexion.EjecutaCargaDatosDynamics_ESF] Error enviado desde el procedimiento");
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw new SystemException(Environment.NewLine + "[Conexion.EjecutaCargaDatosDynamics_ESF]" + ex.Message);
            }
        }
    }
}