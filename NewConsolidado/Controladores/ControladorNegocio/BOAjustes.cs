using System;
using System.Collections.Generic; 

using NewConsolidado.Controladores.Clases;
using NewConsolidado.Modelos.AccesoDatos;
using NewConsolidado.Modelos.TransporteDatos;

namespace NewConsolidado.Controladores.ControladorNegocio
{
	class BOAjustes
	{
		private MyLog4Net hLog = new MyLog4Net("BOAjustes.class");

		public BOAjustes()
		{
		}

		public List<DTOAjustes> ConsultaAjustesConsolidado(
			int iConsolidado
			, string sPeriodo
			, string sCorrelativo
			)
		{
			try
			{
				List<DTOAjustes> lLista = new List<DTOAjustes>();
				DAOAjustes oDAO = new DAOAjustes();
				//
				hLog.Debug("Consultamos los ajustes del consolidado con periodo");
				lLista = oDAO.ConsultaAjustesConsolidado(iConsolidado, sPeriodo, sCorrelativo);
				return lLista;
			}
			catch (Exception ex)
			{
				hLog.Fatal(ex.Message);
				throw new SystemException(ex.Message);
			}
		}

		public List<DTOAjustes> ConsultaAsientosPorConsolidado(
			int iConsolidado
			, string sPeriodo
			)
		{
			try
			{
				List<DTOAjustes> lLista = new List<DTOAjustes>();
				DAOAjustes oDAO = new DAOAjustes();
				//
				hLog.Debug("Consultamos los ajustes del consolidado con periodo");
				lLista = oDAO.ConsultaAsientosPorConsolidado(iConsolidado, sPeriodo);
				return lLista;
			}
			catch (Exception ex)
			{
				hLog.Fatal(ex.Message);
				throw new SystemException(ex.Message);
			}
		}
		public int UltimoAsiento(
			int intConsolidado
			, string sPeriodo
			)
		{
			try
			{
				if (intConsolidado <= 0)
				{
					hLog.Fatal("El codigo de consolidado no es valido para obtener el ultimo numero de asiento {" + intConsolidado.ToString()+"]");
					throw new SystemException("El codigo de consolidado no es valido para obtener el ultimo numero de asiento ");
				}
				if (sPeriodo == "")
				{
					hLog.Fatal("El peroido afectado no es valido para obtener el ultimo numero de asiento {" + sPeriodo + "]");
					throw new SystemException("El peroido afectado no es valido para obtener el ultimo numero de asiento");
				}
				int iRetorno = 0;
				DAOAjustes oDAO = new DAOAjustes();
				//
				hLog.Debug("Consultamos el max() de correlativo de ajuste asociado al consolidado {" + intConsolidado.ToString() + "} y periodo {" + sPeriodo.ToString() + "}");
				iRetorno = oDAO.UltimoAsiento(intConsolidado, sPeriodo);
				return iRetorno;
			}
			catch (Exception ex)
			{
				hLog.Fatal(ex.Message);
				throw new SystemException(ex.Message);
			}
		}
		public DTOAjustes ConsultaCuadraturaConsolidado(
			int iConsolidado
			, string sPeriodo
			)
		{
			try
			{
				DAOAjustes oDAO = new DAOAjustes();
				DTOAjustes oDTO = new DTOAjustes();
				//
				hLog.Debug("Consultamos la cuadratura del consolidado {" + iConsolidado.ToString() + "} y periodo {" + sPeriodo.ToString() + "}");
				oDTO = oDAO.ConsultaCuadratura(iConsolidado, sPeriodo);
				return oDTO;
			}
			catch (Exception ex)
			{
				hLog.Fatal(ex.Message);
				throw new SystemException(ex.Message);
			}
		}
		public void GrabarAjustes(
			List<DTOAjustes> lAjustes
			, int iAccion
			)
		{
			try
			{

				DAOAjustes oDAO = new DAOAjustes();
				switch (iAccion)
				{
					case (int)CFG.ToolAcciones.Nuevo:
						{
							oDAO.CrearAjustes(lAjustes);
							break;
						}
					case (int)CFG.ToolAcciones.Editar:
						{
							List<DTOAjustes> lNuevo = new List<DTOAjustes>();
							List<DTOAjustes> lEditar = new List<DTOAjustes>();
							List<DTOAjustes> lEliminar = new List<DTOAjustes>();
							foreach (DTOAjustes oDTO in lAjustes)
							{
								switch (oDTO.Accion)
								{
									case (int)CFG.ToolAcciones.Nuevo:
										{
											lNuevo.Add(oDTO);
											break;
										}
									case (int)CFG.ToolAcciones.Editar:
										{
											lEditar.Add(oDTO);
											break;
										}
									case (int)CFG.ToolAcciones.Eliminar:
										{
											//Le cambiamos el tipo de transaccion por anulado para borrar logicamente el registro
											//para despues mostralo en negrecido
											//oDTO.TipoTransaccion = (int)CFG.TipoAjuste.Anulado;
											lEditar.Add(oDTO);
											lEliminar.Add(oDTO);
											break;
										}
									default:
										{
											hLog.Fatal("Mala clasificacion al {GrabarAjustes2}");
											throw new SystemException("Mala clasificacion al {GrabarAjustes}");
											
										}
								}
							}
							if (lNuevo.Count > 0)
							{
								oDAO.CrearAjustes(lNuevo);
							}
							if (lEditar.Count > 0)
							{
                                oDAO.EditarRegAjustes(lEditar);
							}
							if (lEliminar.Count > 0)
							{
								oDAO.EliminarAjustes(lEliminar);
							}
							break;
						}
					case (int)CFG.ToolAcciones.Eliminar:
						{
							oDAO.EliminarAjustes(lAjustes);
							break;
						}
					default:
						{
							hLog.Fatal("Mala clasificacion al {GrabarAjustes1}");
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
		public void AnularAsiento(
			int iConsolidado
			, int iCorrelativoAsiento
			, string sPeriodo
			)
		{
			try
			{
				DAOAjustes oDAO = new DAOAjustes();
				//
				string sTexto = "Anulamos el asiento {" + iConsolidado.ToString() + "}";
				sTexto += " y asiento {" + iCorrelativoAsiento.ToString() + "}";
				sTexto += " y Periodo {" + sPeriodo + "}";
				hLog.Debug(sTexto);
				oDAO.AnularAsiento(iConsolidado, iCorrelativoAsiento, sPeriodo);
			}
			catch (Exception ex)
			{
				hLog.Fatal(ex.Message);
				throw new SystemException(ex.Message);
			}
		}

		public void EjecutaAjutesAutomaticos(
			int iIdConsolidado
			, string sPeriodo
			)
		{
			try
			{
				string sLibros = NewConsolidado.Properties.Settings.Default.usrLibrosReporte;
				DAOAjustes oDAO = new DAOAjustes();
				oDAO.EjecutaAjustesAutomaticos(iIdConsolidado, sLibros, sPeriodo);
			}
			catch (Exception ex)
			{
				hLog.Fatal(ex.Message);
				throw new SystemException(ex.Message);
			}
		}

        public void Copiarajustes(
            int idConsolidadoOriginal
            , int idConsolidadoNuevo
            )
        {
            try
            {
                DAOAjustes oDAO = new DAOAjustes();
                oDAO.CopiarAjustes( idConsolidadoOriginal, idConsolidadoNuevo);
            }
            catch (Exception ex)
            {
                hLog.Fatal(ex.Message);
                throw new SystemException(ex.Message);
            }
        }
    }
}
