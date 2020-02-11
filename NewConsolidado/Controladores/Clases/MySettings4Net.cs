using System;
using System.Configuration;
using System.Windows.Forms;


namespace NewConsolidado.Controladores.Clases
{
	static class MySettings4Net
	{
		public static string leerValorConfiguracion(string sClave, string sDefault)
		{
			try
			{
				string sResultado = ConfigurationManager.AppSettings[sClave].ToString();

				return sResultado;
			}
			catch
			{
				return sDefault;
			}
		}

		public static void guardarValorConfiguracion(string sClave, string sValor)
		{
			try
			{
				//La línea siguiente no funcionará bien en tiempo de diseño 
				//pues VC# usa el fichero xxx.vshost.config en la depuración 
				//Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None); 
				//así pues la cambiamos por:

				Configuration ficheroConfXML = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);

				//eliminamos la clave actual (si existe), si no la eliminamos 
				//los valores se irán acumulando separados por coma 
				ficheroConfXML.AppSettings.Settings.Remove(sClave);

				//asignamos el valor en la clave indicada 
				ficheroConfXML.AppSettings.Settings.Add(sClave, sValor);

				//guardamos los cambios definitivamente en el fichero de configuración 
				ficheroConfXML.Save(ConfigurationSaveMode.Modified);
			}
			catch
			{
				/* 
				     MessageBox.Show("Error al guardar valor de configuración: " + 
					 System.Environment.NewLine + System.Environment.NewLine + 
					 ex.GetType().ToString() + System.Environment.NewLine + 
					 ex.Message, "Error", 
					 MessageBoxButtons.OK, MessageBoxIcon.Error);
				 */
			}
		}

	}
}
