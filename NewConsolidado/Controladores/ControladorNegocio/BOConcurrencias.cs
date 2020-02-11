using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NewConsolidado.Controladores.Clases;
using NewConsolidado.Modelos.AccesoDatos;
using NewConsolidado.Modelos.TransporteDatos;


namespace NewConsolidado.Controladores.ControladorNegocio
{
	class BOConcurrencias
	{
		private MyLog4Net hLog = new MyLog4Net("BOConcurrencias.class");
		/// <summary>
		/// Consulta si se ejecuta la carga de datos desde dynamics
		/// </summary>
		/// <returns></returns>
		public DTOConcurrencias ConsultaConcurrenciasDynamics()
		{
			try
			{
				return ConsultaConcurrencias("Dynamics");
			}
			catch (Exception ex)
			{
				hLog.Fatal(ex.Message);
				throw new SystemException(ex.Message);
			}
		}
		/// <summary>
		/// Consulta por un codigo de consolidado que este siendo usado por otro usuario
		/// </summary>
		/// <param name="sCodigo">idCodigo de consolidado</param>
		/// <returns></returns>
		public DTOConcurrencias ConsultaConcurrencias(
			string sCodigo
			)
		{
			try
			{
				DTOConcurrencias oDTO = new DTOConcurrencias();
				DAOConcurrencias oDAO = new DAOConcurrencias();
				//hLog.Debug("Consultamos los concurrencias");
				oDTO = oDAO.ConsultaConcurrencias(sCodigo);
				return oDTO;
			}
			catch (Exception ex)
			{
				hLog.Fatal(ex.Message);
				throw new SystemException(ex.Message);
			}
		}
		/// <summary>
		/// Pemrite crear un registro de marca de uso de un consolidado
		/// </summary>
		/// <param name="sCodigo"></param>
		public void CrearConcurrencias(
			string sCodigo
			)
		{
			try
			{
				DTOConcurrencias oDTO = new DTOConcurrencias();
				oDTO.KeyConcurrencia = sCodigo;
				oDTO.ValueConcurrencia = 1;

				DAOConcurrencias oDAO = new DAOConcurrencias();
				oDAO.CreaConcurrencia(oDTO);

			}
			catch (Exception ex)
			{
				hLog.Fatal(ex.Message);
				throw new SystemException(ex.Message);
			}
		}
		/// <summary>
		/// Permite eliminar la marca de uso de un consolidado
		/// </summary>
		/// <param name="sCodigo"></param>
		public void EliminaConcurrencias(
			string sCodigo
			)
		{
			try
			{
				DTOConcurrencias oDTO = new DTOConcurrencias();
				oDTO.KeyConcurrencia = sCodigo;
				oDTO.ValueConcurrencia = 0;

				DAOConcurrencias oDAO = new DAOConcurrencias();
				oDAO.EliminaConcurrencia(oDTO);

			}
			catch (Exception ex)
			{
				hLog.Fatal(ex.Message);
				throw new SystemException(ex.Message);
			}
		}
		/// <summary>
		/// para uso de administrador, permite liberar todas las concurrencias de consolidados tomadas
		/// </summary>
		public void LiberaConcurrencia()
		{
			try
			{
				DAOConcurrencias oDAO = new DAOConcurrencias();
				oDAO.LiberaConcurrencia();
			}
			catch (Exception ex)
			{
				hLog.Fatal(ex.Message);
				throw new SystemException(ex.Message);
			}
		}
	}
}
