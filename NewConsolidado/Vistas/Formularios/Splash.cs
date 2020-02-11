using System;
using System.Threading;
using System.Windows.Forms;


namespace NewConsolidado.Vistas.Formularios
{
	public partial class Splash : Form
	{
		public Splash()
		{
			InitializeComponent();

			this.StartPosition = FormStartPosition.CenterScreen;
			timer1.Enabled = true;
			timer1.Interval = 2000;
			laCompañia.Text = Application.CompanyName.ToString();
			laVersion.Text = Application.ProductVersion;
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
			timer1.Stop();
			this.Close();
		}

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Splash_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void Splash_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
