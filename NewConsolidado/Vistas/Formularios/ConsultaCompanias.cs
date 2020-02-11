using System.Windows.Forms;
using System.Collections.Generic;

using NewConsolidado.Controladores.ControladorNegocio;
using NewConsolidado.Controladores.Clases;
using NewConsolidado.Modelos.TransporteDatos;

namespace NewConsolidado.Vistas.Formularios
{
	public partial class ConsultaCompanias : Form
	{
		private MyLog4Net hLog = new MyLog4Net("ConsultaCompanias.Form");

		private string hIdCompania = "";
		private string hNombre = "";
		private int hiOrigen = -1;

		public ConsultaCompanias()
		{
			InitializeComponent();
			//
			ConfiguraBotones();
		}
		private void ConsultaCompanias_Load(object sender, System.EventArgs e)
		{
			CargaCompanias();
		}
		private void gridCompania_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			BotonAceptarCompania();
		}
		private void buttonAceptar_Click(object sender, System.EventArgs e)
		{
			BotonAceptarCompania();
		}
		private void buttonSalir_Click(object sender, System.EventArgs e)
		{
			BotonSalir();
		}
		public string IdCompania
		{
			get { return hIdCompania; }
			//set { hIdCompania = value; }
		}
		public string Nombre
		{
			get { return hNombre; }
			//set { hNombre = value; }
		}
		public int Origen
		{
			get { return hiOrigen; }
			set { hiOrigen = value; }
		}
		//--------------------------------------------------------------------------------------------------------------
		//
		//
		private void CargaCompanias()
		{
			List<DTOCompanias> lDTO = new List<DTOCompanias>();
			BOCompanias BOC = new BOCompanias();

			if (hiOrigen == -1)
			{
				lDTO = BOC.ConsultaCompanias();
			}
			else
			{
				lDTO = BOC.ConsultaCompanias(hiOrigen);
			}
			foreach (DTOCompanias DTO in lDTO)
			{
				gridCompanias.Rows.Add();
				gridCompanias.Rows[gridCompanias.Rows.Count - 1].Cells["colCodigo"].Value = DTO.IdCompania;
				gridCompanias.Rows[gridCompanias.Rows.Count - 1].Cells["colNombre"].Value = DTO.Nombre;
			}
		}

		private void ConfiguraBotones()
		{
			buttonAceptar.Image = NewConsolidado.Properties.Resources.rsc_24_Grabar;
			buttonAceptar.Size = new System.Drawing.Size(CFG.buttonAncho, CFG.buttonAlto);
			buttonAceptar.Text = "Aceptar";
			buttonAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			buttonAceptar.UseVisualStyleBackColor = true;
			this.AcceptButton = buttonAceptar;

			buttonSalir.Image = global::NewConsolidado.Properties.Resources.rsc_24_SalirForm;
			buttonSalir.Size = new System.Drawing.Size(CFG.buttonAncho, CFG.buttonAlto);
			buttonSalir.Text = "Salir";
			buttonSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			buttonSalir.UseVisualStyleBackColor = true;
			this.CancelButton = buttonSalir;

		}
		private void BotonSalir()
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}
		private void BotonAceptarCompania()
		{

			hIdCompania = (string)gridCompanias.Rows[gridCompanias.CurrentCell.RowIndex].Cells["colCodigo"].Value;
			hNombre = (string)gridCompanias.Rows[gridCompanias.CurrentCell.RowIndex].Cells["colNombre"].Value;

			hLog.Debug("se escoje empresa {" + hIdCompania + "} {" + hNombre +"}");

			this.DialogResult = DialogResult.OK;
			this.Close();
		}
	}
}
