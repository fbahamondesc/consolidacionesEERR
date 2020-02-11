using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using NewConsolidado.Controladores.Clases;
using NewConsolidado.Modelos.TransporteDatos;
using NewConsolidado.Controladores.ControladorNegocio;

namespace NewConsolidado.Vistas.Formularios
{
	public partial class ActualizarCodigo : Form
	{
		private MyLog4Net hLog = new MyLog4Net("ActualizarCodigo.Form");

		public ActualizarCodigo()
		{
			InitializeComponent();
		}

		private void buttonActualizar_Click(object sender, EventArgs e)
		{
			if (Globales.UsuarioActivo == @"ICAFAL\ccarrascom")
			{
				this.Cursor = Cursors.WaitCursor;

				List<DTOConsolidados> lDto = new List<DTOConsolidados>();
				BOConsolidados oBO = new BOConsolidados();
				lDto = oBO.ConsultaConsolidados();

				foreach (DTOConsolidados oDTO in lDto)
				{
					oDTO.IdCodigo = DateTime.Now.Ticks.ToString();
					hLog.Debug(oDTO.IdRegistro + "{" + oDTO.IdCodigo + "} " + oDTO.Descripcion);

					oBO.GrabarDatosConsolidado((int)CFG.ToolAcciones.Editar, oDTO);
				}
			}
			this.Cursor = Cursors.Default;
		}
	}
}
