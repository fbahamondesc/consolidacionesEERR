using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NewConsolidado.Controladores.Clases;
using NewConsolidado.Modelos.AccesoDatos;
using NewConsolidado.Modelos.TransporteDatos;

namespace NewConsolidado.Controladores.ControladorNegocio
{
	class BOConceptos
	{
		private MyLog4Net hLog = new MyLog4Net("BOConceptos.class");

		public BOConceptos()
		{
		}

		public List<DTOConceptos> ConsultaConceptos()
		{
			try
			{
				return ConsultaConceptos(-1, "");
			}
			catch (Exception ex)
			{
				hLog.Fatal(ex.Message);
                throw new SystemException("\n[BOConceptos][ConsultaConceptos]" + ex.Message);
			}
		}
		public List<DTOConceptos> ConsultaConceptos(
			int iIDConceptos
			, string sCodigo
			)
		{
			try
			{
				List<DTOConceptos> lDTO = new List<DTOConceptos>();
				DAOConceptos oDAO = new DAOConceptos();
				hLog.Debug("Consultamos los conceptos");
				lDTO = oDAO.ConsultaConceptos(iIDConceptos, "");
				return lDTO;
			}
			catch (Exception ex)
			{
				hLog.Fatal(ex.Message);
                throw new SystemException("\n[BOConceptos][ConsultaConceptos]" + ex.Message);
			}
		}
		public void GrabarConcepto(
			int iAccion
			, DTOConceptos oDTO
			)
		{
			try
			{
				DAOConceptos oDAO = new DAOConceptos();
				switch (iAccion)
				{
					case (int)CFG.ToolAcciones.Nuevo:
						{
							oDAO.CrearConcepto(oDTO);
							break;
						}
					case (int)CFG.ToolAcciones.Editar:
						{
							oDAO.EditarConcepto(oDTO);
							break;
						}
					case (int)CFG.ToolAcciones.Eliminar:
						{
							oDAO.EliminarConcepto(oDTO);
							break;
						}
					default:
						{
							hLog.Fatal("Mala clasificacion al {GrabarConcepto}");
							throw new SystemException("Mala clasificacion al {GrabarConcepto}");
						}
				}
			}
			catch (Exception ex)
			{
				hLog.Fatal(ex.Message);
                throw new SystemException("\n[BOConceptos][GrabarConcepto]" + ex.Message);
			}

		}
	}
}
