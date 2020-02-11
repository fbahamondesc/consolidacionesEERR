using System;
using System.IO;
using System.Globalization;
using System.Drawing;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

namespace NewConsolidado.Controladores.Clases
{
	//Modulo o Clase estatica o Patron Singleton
	public partial class MisFunciones
	{
		/// <summary>
		/// Funcion que buscva la ruta del directorio de la aplicacion y lo crea
		/// </summary>
		/// <param name="sRuta"></param>
		/// <returns></returns>
		public static Boolean RevisionDirectorioApp(string sRuta)
		{
			Boolean bResultado;

			try
			{
				if (!Directory.Exists(sRuta))
				{
					Directory.CreateDirectory(sRuta); //Crea un directorio
				}
				bResultado = true;
			}
			catch 
			{
				bResultado = true;
			}
			return bResultado;
		}
		/// <summary>
		/// Retorna la fecha enviada como un string imprimible segun el formato definido en la maquina como configuracion regional
		/// </summary>
		/// <param name="dFecha">fecha</param>
		/// <returns></returns>
		public static string DespliegaFechaFormato(DateTime dFecha)
		{
			return dFecha.ToString(CFG.sFormatDisplayFecha, CultureInfo.InvariantCulture);
		}
		/// <summary>
		/// Funcion que devuelve un tipo fecha segun el string ingresado
		/// </summary>
		/// <param name="sFecha">cadena de fecha formateada como yyyyMMdd</param>
		/// <returns></returns>
		public static DateTime DevuelveFecha(string sFecha)
		{
			return DateTime.ParseExact(sFecha, "yyyyMMdd", CultureInfo.InvariantCulture);
		}
		/// <summary>
		/// Funcion para buscar caracteres especiales en una cadena
		/// </summary>
		/// <param name="strTexto">Texto ingresado</param>
		/// <param name="strCadena">Cadena de caracteres especiales</param>
		/// <returns></returns>
		public static Boolean ValidaExistenCaracteres(string strTexto, string strCadena)
		{
			Boolean bolResultado = false;

			if (strCadena.Length > 0 && strTexto.Length > 0)
			{
				for (int intI = 0; intI < strCadena.Length; intI++)
				{
					for (int intW = 0; intW < strTexto.Length; intW++)
					{
						if (strCadena.Substring(intI, 1) == strTexto.Substring(intW, 1))
						{
							bolResultado = true;
						}
					}
				}
			}
			return bolResultado;
		}
		/// <summary>
		/// Funcion que valida de forma generica los datos que debe contener el string
		/// {para Alfnumerico : enviar "a-zA-Z0-9ñÑ"}
		/// {para Numerico :  enviar "0-9"}
		/// {para carctares especiales enviar "a-zA-Z0-9ñÑ,()"}
		/// NOTA : agregar el espacio en blanco si puede ir en el string
		/// Devuelve un false si posee un caracter fuera de los señalados
		/// </summary>
		/// <param name="strTexto">texto a validar</param>
		/// <returns></returns>
		public static bool ValidaCadenaCorrecta(string strTexto, string strCadena)
		{
			string strPatron = "^[" + strCadena + "]+$";
			bool bolReturn = Regex.Match(strTexto, strPatron).Success;
			return bolReturn;
		}

		/// <summary>
		/// Implementacion para dar pausas a la aplicacion. expresada en segundos.
		/// </summary>
		/// <param name="iSegundos"></param>
		public static void AppPausa(int iSegundos)
		{
			Thread.Sleep(iSegundos * 1000);
		}


        ///// <summary>
        ///// Implementacion para retornar un valor codificado en BASE64
        ///// </summary>
        ///// <param name="encoding"></param>
        ///// <param name="text"></param>
        ///// <returns></returns>
        //public static string ToBase64(System.Text.Encoding encoding, string text)
        //{
        //    if (text == null)
        //    {
        //        return null;
        //    }

        //    byte[] textAsBytes = encoding.GetBytes(text);
        //    return Convert.ToBase64String(textAsBytes);
        //}
		/// <summary>
		/// Funcion que permite configurar las toolbar de la aplicacion con la configuracion
		/// global
		/// </summary>
		/// <param name="tb"></param>
		public static void ConfiguraToolBar(ToolStrip tb)
		{
			tb.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			tb.ImageScalingSize = new System.Drawing.Size(24, 24);
			tb.BackColor = System.Drawing.Color.DarkSeaGreen;
			tb.Padding = new System.Windows.Forms.Padding(2);
			tb.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;

			ToolStripItemDisplayStyle ds = new ToolStripItemDisplayStyle();
			switch (NewConsolidado.Properties.Settings.Default.usrDiseñoToolbar)
			{
				case (int)CFG.ToolBarDiseño.Ninguno:
					{
						ds = ToolStripItemDisplayStyle.None;
						break;
					}
				case (int)CFG.ToolBarDiseño.Texto:
					{
						ds = ToolStripItemDisplayStyle.Text;
						break;
					}
				case (int)CFG.ToolBarDiseño.Imagen:
					{
						ds = ToolStripItemDisplayStyle.Image;
						break;
					}
				case (int)CFG.ToolBarDiseño.ImagenYTexto:
					{
						ds = ToolStripItemDisplayStyle.ImageAndText;
						break;
					}
				default:
					{
						MessageBox.Show("Error en la definicion de toolbar");
						break;
					}
			}
			for (int iI = 0; iI < tb.Items.Count; iI++)
			{
				tb.Items[iI].DisplayStyle = ds;
			}
		}
		/// <summary>
		/// Funcion que define la conexion global por defecto o la cambia segun lo enviado
		/// </summary>
		/// <param name="iTipo"></param>
        //public static void ConexionGlobal(int iTipo)
        //{
        //    NewConsolidado.Properties.Settings.Default.usrStringConexion = 
        //        "Data Source=" + NewConsolidado.Properties.Settings.Default.appConSource;
        //    if (iTipo == (int)CFG.Conexion.Desarrollo)
        //    {
        //        NewConsolidado.Properties.Settings.Default.usrStringConexion += 
        //            ";Initial Catalog=" + NewConsolidado.Properties.Settings.Default.appConBD_Debug;
        //    }
        //    else
        //    {
        //        NewConsolidado.Properties.Settings.Default.usrStringConexion += 
        //                ";Initial Catalog=" + NewConsolidado.Properties.Settings.Default.appConBD_Prod;
        //    }
        //    NewConsolidado.Properties.Settings.Default.usrStringConexion += ";Integrated Security=SSPI";
        //    NewConsolidado.Properties.Settings.Default.appSelecccionBD = iTipo;
        //}

        public static bool esNumerico(string sValor)
        {
            decimal retNum;
            bool isNum = decimal.TryParse(Convert.ToString(sValor), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }

        public static string LeeArchivoConfiguracion(string sArchivo, string sSeccion, string sCadena)
        {
            string sTexto = "";
            try
            {
                if (File.Exists(sArchivo))
                {
                    XmlDocument xDoc = new XmlDocument();
                    xDoc.Load(sArchivo);
                    XmlNodeList oNodos = xDoc.SelectNodes("/icafal/" + sSeccion + "/" + sCadena);
                    sTexto = oNodos[0].InnerText;
                    return sTexto;
                }
                else
                {
                    throw new SystemException("");
                }
            }
            catch (Exception ex)
            {
                throw new SystemException("[MisFunciones]\n[Error tratando de leer las configuraciones \n{" + sArchivo + "}{" + ex.Message + "}]");
            }
        }
    }
}