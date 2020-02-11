using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

using NewConsolidado.Controladores.Clases;

namespace NewConsolidado.Vistas.Formularios
{
	public partial class AcercaDe : Form
	{
		private MyLog4Net hLog = new MyLog4Net("AcercaDe.Form");

		public AcercaDe()
		{
			InitializeComponent();

			this.Text = "Acerca de New Consolidado";

			laProducto.Text = Application.ProductName.ToString();//   System.Reflection.Assembly.GetEntryAssembly().GetName().Name;
			laCompañia.Text = Application.CompanyName.ToString();
			laDerechos.Text = "";
			laVersion.Text = Application.ProductVersion;
			laDescripcionAplicacion.Text = Application.ExecutablePath.ToString();


			laCultureName.Text = System.Globalization.CultureInfo.CurrentCulture.NativeName +  " " + System.Globalization.CultureInfo.CurrentCulture.Name;
			laCurrencySymbol.Text = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol;
			string sSep = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator;
			laSeparator.Text = sSep + (sSep == "," ? "(Coma)" : (sSep == "." ? "(Punto)" : "(otro)"));
			//labelConexion.Text = NewConsolidado.Properties.Settings.Default.usrStringConexion;

		}

		private void AcercaDe_Load(object sender, EventArgs e)
		{

		}

	}
}
