using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using NewConsolidado.Controladores.ControladorNegocio;
using NewConsolidado.Controladores.Clases;
using NewConsolidado.Modelos.TransporteDatos;

namespace NewConsolidado.Vistas.Formularios
{
	public partial class ConsultaCuentasContables : Form
	{
		private MyLog4Net hLog = new MyLog4Net("ConsultaCuentasContables.Form");

		private string hIdCuenta = "";
		private string hsGlosa = "";
		private string hsTipo = "";

		public string IdCuenta
		{
			get { return hIdCuenta; }
			set { hIdCuenta = value; }
		}
		public string sGlosa
		{
			get { return hsGlosa; }
			set { hsGlosa = value; }
		}
		public string sTipo
		{
			get { return hsTipo; }
			set { hsTipo = value; }
		}
		//
		//
		//
		public ConsultaCuentasContables()
		{
			InitializeComponent();

			this.Text = "Consulta de Cuentas Contables";
			//
			ConfiguraBotones();
			//
			CargaCuentasContables();
		}
		private void buttonAceptar_Click(object sender, EventArgs e)
		{
			AceptarCuenta();
		}
		private void gridCuentas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			AceptarCuenta();
		}
		private void buttonSalir_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}
		//------------------------------------------------------------------------------------------------------------------
		// Metodos privados
		//------------------------------------------------------------------------------------------------------------------
		private void CargaCuentasContables()
		{
			BOMaestroCuentas oBO = new BOMaestroCuentas();
			List<DTOMaestroCuentas> lDTO = new List<DTOMaestroCuentas>();
			lDTO = oBO.ConsultaMaestroCuentas();

			foreach (DTOMaestroCuentas oDTO in lDTO)
			{
				gridCuentas.Rows.Add();
				gridCuentas.Rows[gridCuentas.Rows.Count - 1].Cells["colIdCuenta"].Value = oDTO.idCuenta.ToString();
				gridCuentas.Rows[gridCuentas.Rows.Count - 1].Cells["colDescripcion"].Value = oDTO.Descripcion.ToString();
				gridCuentas.Rows[gridCuentas.Rows.Count - 1].Cells["colTipo"].Value = oDTO.Tipo.ToString();
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
			//
			buttonSalir.Image = global::NewConsolidado.Properties.Resources.rsc_24_SalirForm;
			buttonSalir.Size = new System.Drawing.Size(CFG.buttonAncho, CFG.buttonAlto);
			buttonSalir.Text = "Salir";
			buttonSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			buttonSalir.UseVisualStyleBackColor = true;
			this.CancelButton = buttonSalir;
		}
		private void AceptarCuenta()
		{
			hIdCuenta = gridCuentas.Rows[gridCuentas.CurrentCell.RowIndex].Cells["colIdCuenta"].Value.ToString();
			hsGlosa = gridCuentas.Rows[gridCuentas.CurrentCell.RowIndex].Cells["colDescripcion"].Value.ToString();
			hsTipo = gridCuentas.Rows[gridCuentas.CurrentCell.RowIndex].Cells["colTipo"].Value.ToString();
			//
			this.DialogResult = DialogResult.OK;
			this.Close();

		}

		private void ConsultaCuentasContables_Load(object sender, EventArgs e)
		{

		}
	}
}
