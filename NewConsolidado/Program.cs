using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using NewConsolidado.Controladores.Clases;
using NewConsolidado.Vistas.Formularios;

namespace NewConsolidado
{
	static class Program
	{
		/// <summary>
		/// Punto de entrada principal para la aplicación.
		/// </summary>
		[STAThread]
        static void Main(string[] Args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			try
			{
				Splash Sp = new Splash();
				Sp.ShowIcon = false;
				Sp.ShowInTaskbar = false;
				if (Sp.ShowDialog() == DialogResult.OK)
				{
                    //MDI oMdi = new MDI();
                    //if ( oMdi.IsMdiContainer )
                    //{
                    //    Application.Run(oMdi);
                    //}
                    Application.Run(new MDI(Args));
				}
			}
			catch (Exception ex)
			{
				MyLog4Net hlog = new MyLog4Net("App");
				hlog.Fatal("Salida de la app por error " + ex.Message);
				Application.Exit();
			}
		}
	}
}
