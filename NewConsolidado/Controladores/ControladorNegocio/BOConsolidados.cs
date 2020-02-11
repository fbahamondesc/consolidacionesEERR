using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NewConsolidado.Controladores.Clases;
using NewConsolidado.Modelos.AccesoDatos;
using NewConsolidado.Modelos.TransporteDatos;

namespace NewConsolidado.Controladores.ControladorNegocio
{
	class BOConsolidados
	{

		private MyLog4Net hLog = new MyLog4Net("BOConsolidados.class");

		private List<DTOConsolidados> lDTOCopia = new List<DTOConsolidados>();


		/// <summary>
		/// Metodo inicio de la clase
		/// </summary>
		public BOConsolidados()
		{
		}

		/// <summary>
		/// Consulta todos los nodos de la tabla de consolidados
		/// </summary>
		/// <returns></returns>
		public List<DTOConsolidados> ConsultaConsolidados()
		{
			try
			{
				List<DTOConsolidados> lDto = new List<DTOConsolidados>();
				DAOConsolidados oDao = new DAOConsolidados();
				lDto = oDao.ConsultaConsolidados(-1, -1, "", "", -1, -1);
				return lDto;
			}
			catch (Exception ex)
			{
				hLog.Fatal(ex.Message);
				throw new SystemException(ex.Message);
			}
		}

		/// <summary>
		/// Consulta todos los nodos de la tabla consolidados que son hijos del codigo especificado
		/// </summary>
		/// <param name="idPadre">Codigo del padre</param>
		/// <returns></returns>
		public List<DTOConsolidados> ConsultaConsolidados(
			int idPadre
			)
		{
			try
			{
				List<DTOConsolidados> lDto = new List<DTOConsolidados>();
				DAOConsolidados oDao = new DAOConsolidados();
				lDto = oDao.ConsultaConsolidados(-1, idPadre, "", "", -1, -1);

				return lDto;
			}
			catch (Exception ex)
			{
				hLog.Fatal(ex.Message);
				throw new SystemException(ex.Message);
			}
		}

        public List<DTOConsolidados> ConsultaConsolidados(
            int iTipo, string sP
            )
        {
            try
            {
                List<DTOConsolidados> lDto = new List<DTOConsolidados>();
                DAOConsolidados oDao = new DAOConsolidados();
                lDto = oDao.ConsultaConsolidadosTipo(iTipo);

                return lDto;
            }
            catch (Exception ex)
            {
                hLog.Fatal(ex.Message);
                throw new SystemException(ex.Message);
            }
        }

        public List<DTOConsolidados> ConsultaConsolidados(
            int iTipo, string s1, string s2
            )
        {
            try
            {
                List<DTOConsolidados> lDto = new List<DTOConsolidados>();
                DAOConsolidados oDao = new DAOConsolidados();
                lDto = oDao.ConsultaConsolidadosTodosTipo(iTipo);

                return lDto;
            }
            catch (Exception ex)
            {
                hLog.Fatal(ex.Message);
                throw new SystemException(ex.Message);
            }
        }



        public List<DTOConsolidados> ConsultaConsolidados(
                    string sCodigo, string sDescripcion
                    )
        {
            try
            {
                List<DTOConsolidados> lDto = new List<DTOConsolidados>();
                DAOConsolidados oDao = new DAOConsolidados();
                lDto = oDao.ConsultaPorCodigoDescripcion(sCodigo, sDescripcion);

                return lDto;
            }
            catch (Exception ex)
            {
                hLog.Fatal(ex.Message);
                throw new SystemException(ex.Message);
            }
        }

		public void GrabarDatosConsolidado(
			int iAccion
			, DTOConsolidados oDTO
			)
		{
			try
			{
				DAOConsolidados oDao = new DAOConsolidados();
				switch (iAccion)
				{
					case (int)CFG.ToolAcciones.Nuevo:
						{
							//Grabamos los datos
							oDao.CrearConsolidado(oDTO);
							if (oDTO.TipoNodo == (int)CFG.TipoConsolidado.Consolidado && oDTO.CodigoReferenciado == 0)
							{
								DTOConsolidados oDTOC = new DTOConsolidados();
								oDTOC = ConsultaConsolidado(oDTO.IdCodigo);
								// cramos la tabla de asociacion de grupos/concepto/cuenta
								oDao.CreacionGrupoConceptoCuenta(oDTOC.IdRegistro);
							}
							break;
						}
					case (int)CFG.ToolAcciones.Editar:
						{
							oDao.EditarConsolidado(oDTO);
							// Actualizamos la descripcion de todos los demas nodos que esten referenciando este nodo
							oDao.EditarNodosReferenciados(oDTO);
							break;
						}
					case (int)CFG.ToolAcciones.Eliminar:
						{
							oDao.EliminarConsolidado(oDTO);
							break;
						}
					default:
						{
							hLog.Fatal("Mala clasificacion al {GrabarDatosConsolidado}");
							throw new SystemException("Mala clasificacion al {GrabarDatosConsolidado}");
							
						}
				}
			}
			catch (Exception ex)
			{
				hLog.Fatal(ex.Message);
				throw new SystemException(ex.Message);
			}
		}

		/// <summary>
		/// Consulta el nodo de la tabla de consolidado con el codigo de registro (de texto) especificado
		/// </summary>
		/// <param name="sIdCodigo"></param>
		/// <returns></returns>
		public DTOConsolidados ConsultaConsolidado(
			string sIdCodigo
			)
		{
			try
			{
				List<DTOConsolidados> lDto = new List<DTOConsolidados>();
				DTOConsolidados oDTO = new DTOConsolidados();
				DAOConsolidados oDao = new DAOConsolidados();
				lDto = oDao.ConsultaConsolidados(-1, -1, "", sIdCodigo, -1, -1);
				if (lDto != null)
				{
					if (lDto.Count > 0)
					{
						oDTO = lDto[0];
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

        /// <summary>
        /// Consulta el nodo de la tabla de consolidado con el codigo de registro epecificado
        /// </summary>
        /// <param name="idRegistro"></param>
        /// <returns></returns>
        public DTOConsolidados ConsultaConsolidado(
            int idRegistro
            )
        {
            try
            {
                List<DTOConsolidados> lDto = new List<DTOConsolidados>();
                DTOConsolidados oDTO = new DTOConsolidados();
                DAOConsolidados oDao = new DAOConsolidados();
                lDto = oDao.ConsultaConsolidados(idRegistro, -1, "", "", -1, -1);
                if (lDto != null)
                {
                    if (lDto.Count > 0)
                    {
                        oDTO = lDto[0];
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

		/// <summary>
		/// Metodo que permite copiar una estructura de nodos definida por el codigo de origen
		/// </summary>
		/// <param name="iCodigo">Codigo de origen de la copia</param>
		/// <returns></returns>
		public List<DTOConsolidados> CopiarEstructuraNodo(int iCodigo)
		{
			try
			{
				lDTOCopia.Clear();

				DTOConsolidados oDTO = new DTOConsolidados();
				oDTO = ConsultaConsolidado(iCodigo);
				hLog.Debug("Copiamos el codigo inicial {" + oDTO.Descripcion + "}");

				string sTick = CopiarEstruturaDatos(oDTO, "");
				hLog.Debug("Comienza el recursivo");
				CopiarEstructuraNodoRecursivamente(iCodigo, sTick);

				return lDTOCopia;
			}
			catch (Exception ex)
			{
				hLog.Fatal(ex.Message);
				throw new SystemException(ex.Message);
			}
		}
		private void CopiarEstructuraNodoRecursivamente(int iSemilla, string sTickPadre)
		{
			try
			{
				List<DTOConsolidados> lDTO = new List<DTOConsolidados>();
				hLog.Debug("buscamos el padre {" + iSemilla.ToString() + "}");
				lDTO = ConsultaConsolidados(iSemilla);
				foreach (DTOConsolidados oDTO in lDTO)
				{
					hLog.Debug("Copiamos el Hijo {" + oDTO.Descripcion + "}");
					string sTick = CopiarEstruturaDatos(oDTO, sTickPadre);
					hLog.Debug("Recursivamente vemos si tiene Hijos");
					CopiarEstructuraNodoRecursivamente(oDTO.IdRegistro, sTick);
				}
			}
			catch (Exception ex)
			{
				hLog.Fatal(ex.Message);
				throw new SystemException(ex.Message);
			}
		}
		private string CopiarEstruturaDatos(DTOConsolidados oDTO, string sTickPadre)
		{
			try
			{
				DTOConsolidados oDTOCopia = new DTOConsolidados();
				oDTOCopia.IdRegistro = 0;
				oDTOCopia.IdPadre = 0;
				oDTOCopia.Codigo = oDTO.Codigo;
				oDTOCopia.Descripcion = oDTO.Descripcion;
				oDTOCopia.Observaciones = oDTO.Observaciones;
				oDTOCopia.PeriodoInicio = oDTO.PeriodoInicio;
				oDTOCopia.PeriodoTermino = oDTO.PeriodoTermino;
				oDTOCopia.FechaCreacion = DateTime.Now;
				oDTOCopia.FechaModificacion = DateTime.Now;
				oDTOCopia.PorcentajeParticipacion = oDTO.PorcentajeParticipacion;
				oDTOCopia.IndicadorMatriz = oDTO.IndicadorMatriz;
				oDTOCopia.TipoNodo = oDTO.TipoNodo;
				oDTOCopia.Estado = oDTO.Estado;
				oDTOCopia.Owner = oDTO.Owner;
				oDTOCopia.Bloqueo = oDTO.Bloqueo;
				oDTOCopia.RefenciaConsolidado = oDTO.RefenciaConsolidado;
				oDTOCopia.CodigoReferenciado = oDTO.CodigoReferenciado;
				oDTOCopia.IdCodigo = DateTime.Now.Ticks.ToString();
				oDTOCopia.IdCodigoPadre = sTickPadre;
				oDTOCopia.Orden = oDTO.Orden;
				oDTOCopia.idComparativo = oDTO.idComparativo;
				oDTOCopia.PeriodoComparativo = oDTO.PeriodoComparativo;
				oDTOCopia.PeriodoInforme = oDTO.PeriodoInforme;
				lDTOCopia.Add(oDTOCopia);

				return oDTOCopia.IdCodigo;
			}
			catch (Exception ex)
			{
				hLog.Fatal(ex.Message);
				throw new SystemException(ex.Message);
			}

		}
		/// <summary>
		/// Metodo que toma el set de nodos copiados y los crea fisicamente en la tabla
		/// </summary>
		/// <param name="lDTO"></param>
		public void PegarEstructuraNodos(List<DTOConsolidados> lDTO, int iRegistro)
		{
			try
			{
				lDTOCopia.Clear();
				lDTOCopia = lDTO;

				DTOConsolidados oDTO = new DTOConsolidados();
				oDTO = lDTO.Find(delegate(DTOConsolidados lst)
				{ return lst.IdCodigoPadre == ""; });

				oDTO.IdPadre = iRegistro;
				oDTO.Descripcion = "(Copia) " + oDTO.Descripcion;
				GrabarDatosConsolidado((int)CFG.ToolAcciones.Nuevo, oDTO);
				//
				PegarEstructuraNodosRecursivo(oDTO.IdCodigo);
			}
			catch (Exception ex)
			{
				hLog.Fatal(ex.Message);
				throw new SystemException(ex.Message);
			}

		}
		private void PegarEstructuraNodosRecursivo(string sIdCodigo)
		{
			try
			{
				List<DTOConsolidados> lDTO = new List<DTOConsolidados>();
				lDTO = lDTOCopia.FindAll(delegate(DTOConsolidados lst)
				{ return lst.IdCodigoPadre == sIdCodigo; });

				foreach (DTOConsolidados oDTO in lDTO)
				{
					DTOConsolidados oD = ConsultaConsolidado(sIdCodigo);
					oDTO.IdPadre = oD.IdRegistro;
					GrabarDatosConsolidado((int)CFG.ToolAcciones.Nuevo, oDTO);
					PegarEstructuraNodosRecursivo(oDTO.IdCodigo);
				}
			}
			catch (Exception ex)
			{
				hLog.Fatal(ex.Message);
				throw new SystemException(ex.Message);
			}
		}

		/// <summary>
		/// Busca si el codigo enviado (consolidado) esta referenciado en otro consolidado)
		/// </summary>
		/// <param name="iIdRegsitro"></param>
		/// <returns></returns>
		public Boolean EsRefereciado(int iIdRegistro)
		{
			try
			{
				List<DTOConsolidados> lDto = new List<DTOConsolidados>();
				DAOConsolidados oDao = new DAOConsolidados();
				lDto = oDao.ConsultaConsolidados(-1, -1, "", "", iIdRegistro, -1);
				if (lDto.Count > 0)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			catch (Exception ex)
			{
				hLog.Fatal(ex.Message);
				throw new SystemException(ex.Message);
			}
		}
		/// <summary>
		/// Funcion que devuelve las lista de nodos que estan referenciando el consolidado
		/// </summary>
		/// <param name="iIdRegsitro"></param>
		/// <returns></returns>
		public List<DTOConsolidados> EstructurasRefereciado(int iIdRegsitro)
		{
			try
			{
				List<DTOConsolidados> lDto = new List<DTOConsolidados>();
				DAOConsolidados oDao = new DAOConsolidados();
				return oDao.ConsultaConsolidados(-1, -1, "", "", iIdRegsitro, -1);
			}
			catch (Exception ex)
			{
				hLog.Fatal(ex.Message);
				throw new SystemException(ex.Message);
			}
		}
		/// <summary>
		/// Funcion que indica si el consolidado esta siendo utilizado para comparar otro consolidado
		/// </summary>
		/// <param name="iIdRegsitro"></param>
		/// <returns></returns>
		public Boolean EsComparativo(int iIdComparativo)
		{
			try
			{
				List<DTOConsolidados> lDto = new List<DTOConsolidados>();
				DAOConsolidados oDao = new DAOConsolidados();
				lDto = oDao.ConsultaConsolidados(-1, -1, "", "", -1, iIdComparativo);
				if (lDto.Count > 0)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			catch (Exception ex)
			{
				hLog.Fatal(ex.Message);
				throw new SystemException(ex.Message);
			}
		}
		/// <summary>
		/// Funcion que devuelve los consolidados donde esta definido como comparativo
		/// </summary>
		/// <param name="iIdRegsitro"></param>
		/// <returns></returns>
		public List<DTOConsolidados> EstructurasComparativo(int iIdComparativo)
		{
			try
			{
				List<DTOConsolidados> lDto = new List<DTOConsolidados>();
				DAOConsolidados oDao = new DAOConsolidados();
				return oDao.ConsultaConsolidados(-1, -1, "", "", -1, iIdComparativo);
			}
			catch (Exception ex)
			{
				hLog.Fatal(ex.Message);
				throw new SystemException(ex.Message);
			}
		}

        /// <summary>
        /// Metodo que permite cambiar el usuario de una estructra definida con el usuario enviado
        /// </summary>
        public void CambiaUsuarioEstructura(int iCodigo, string sUsuario)
        {
            try
            {
                List<DTOConsolidados> lDTO = new List<DTOConsolidados>();
                lDTO = ConsultaConsolidados(iCodigo);

                foreach (DTOConsolidados oD in lDTO)
                {
                    CambiaUsuarioEstructura(oD.IdRegistro, sUsuario);
                }

                DTOConsolidados oDTO = new DTOConsolidados();
                oDTO = ConsultaConsolidado(iCodigo);
                oDTO.Owner = sUsuario;
                //
                GrabarDatosConsolidado((int)CFG.ToolAcciones.Editar, oDTO); 

            }
            catch (Exception ex)
            {
                hLog.Fatal(ex.Message);
                throw new SystemException(ex.Message);
            }
        }
        /// <summary>
        /// Metodo que permite eliminar un nodo y toda su estructura
        /// </summary>
        /// <param name="iCodigo"></param>
        public void EliminarEstructura(int iCodigo)
        {
            try
            {
                List<DTOConsolidados> lDTO = new List<DTOConsolidados>();
                lDTO = ConsultaConsolidados(iCodigo);

                foreach (DTOConsolidados oD in lDTO)
                {
                    EliminarEstructura(oD.IdRegistro);
                }

                DTOConsolidados oDTO = new DTOConsolidados();
                oDTO = ConsultaConsolidado(iCodigo);
                GrabarDatosConsolidado((int)CFG.ToolAcciones.Eliminar, oDTO);

            }
            catch (Exception ex)
            {
                hLog.Fatal(ex.Message);
                throw new SystemException(ex.Message);
            }
        }    
    }
}
