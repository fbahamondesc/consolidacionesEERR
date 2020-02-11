using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.IO;

using NewConsolidado.Properties;

namespace NewConsolidado.Controladores.Clases
{
	public class MyLog4Net
	{
		private string _sNombreClase;

		public enum DestinoMensaje
		{
			Ninguno = 0,
			Consola = 1,
			Archivo = 2
		}

		public enum NivelLog
		{
			Ninguno = 0,
			Debug,
			Info,
			Alerta,
			Error,
			Fatal
		}

		public static string[] aDestinoMensaje = { "Ninguno", "Consola", "Archivo" };
		public static string[] aNivelLog = { "Ninguno", "Debug", "Info", "Alerta", "Error", "Fatal" };

		/// <summary>
		/// Metodo constructor de la clase MyLog4Net
		/// </summary>
		/// <param name="sNombreClase"></param>
		public MyLog4Net(string sNombreClase)
		{
			_sNombreClase = sNombreClase;

			Info("iniciación de clase");
		}

		//---------------------------------------------------------------------------------------------------------------------
		//	Metodos usados para grabar en el archivo de log autogenerado
		//---------------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Metodo que sirve para garbar una linea de informacion en el archivo de traza de la aplicacion
		/// </summary>
		/// <param name="sMensaje"></param>        
		public void Debug(string sMensaje)
		{
			EscribreMensaje((int)NivelLog.Debug, sMensaje);
		}
		/// <summary>
		/// Metodo que sirve para garbar una linea de informacion en el archivo de traza de la aplicacion
		/// </summary>
		/// <param name="sMensaje"></param>        
		public void Info(string sMensaje)
		{
			EscribreMensaje((int)NivelLog.Info, sMensaje);
		}
		/// <summary>
		/// Metodo que sirve para grabar una linea de alert en el archivo de traza de la aplicacion
		/// </summary>
		/// <param name="sMensaje"></param>
		public void Alerta(string sMensaje)
		{
			EscribreMensaje((int)NivelLog.Alerta, sMensaje);
		}
		/// <summary>
		/// Metodo que sirve para grabar una linea de error en el archivo de traza de la aplicacion
		/// </summary>
		/// <param name="sMensaje"></param>
		public void Error(string sMensaje)
		{
			EscribreMensaje((int)NivelLog.Error, sMensaje);
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sMensaje"></param>
		public void Fatal(string sMensaje)
		{
			EscribreMensaje((int)NivelLog.Fatal, sMensaje);
		}

		/// <summary>
		/// Metodo privado que escribe el mensaje enviado
		/// </summary>
		/// <param name="sTipo"></param>
		/// <param name="sMensaje"></param>
		private void EscribreMensaje(int iAccion, string sMensaje)
		{
			string sLinea = "[" + DateTime.Parse(DateTime.Now.ToString()) + "]";
			sLinea += "[" + aNivelLog[iAccion] + "]";
			sLinea += "[" + _sNombreClase + "]";
			sLinea += "[" + sMensaje + "]";
			sLinea += "\n";

			try
			{
				if (iAccion >= NewConsolidado.Properties.Settings.Default.myLog4NetNivel)
				{
					// TODO: crear rutina para escribir el archivo plano de log
					switch (NewConsolidado.Properties.Settings.Default.myLog4NetDestino)
					{
						case (int)DestinoMensaje.Ninguno:
							{ break; }
						case (int)DestinoMensaje.Consola:
							{
								Console.Write(sLinea);
								break;
							}
						case (int)DestinoMensaje.Archivo:
							{
								string sFecha = DateTime.Now.Year.ToString("0000") + DateTime.Now.Month.ToString("00") + DateTime.Now.Day.ToString("00");
                                string oFile = NewConsolidado.Properties.Settings.Default.usrRutaArchivosLog + @"\MyLog4net_" + sFecha + @".log";
								System.IO.StreamWriter sw = new System.IO.StreamWriter(oFile, true);
								sw.WriteLine(sLinea);
								sw.Close();
								break;
							}
						default:
							{
								//hLog.Fatal("Mala clasificacion al {EscribreMensaje}");
								throw new SystemException("Mala clasificacion al {EscribreMensaje}");
								
							}
					}
				}
			}
			catch
			{
				Console.Write("Error al escribir myLog4Net");
			}
		}
		//---------------------------------------------------------------------------------------------------------------------
		//	Metodos usados para desplegar Ventanas de Mensajes
		//---------------------------------------------------------------------------------------------------------------------
		//
		//
		public void msgInfo(string sMensaje)
		{
			EscribreMensaje((int)NivelLog.Info, sMensaje);
			MessageBox.Show(sMensaje, Settings.Default.appTituloAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		public void msgAlerta(string sMensaje)
		{
			EscribreMensaje((int)NivelLog.Alerta, sMensaje);
			MessageBox.Show(sMensaje, Settings.Default.appTituloAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Warning);
		}

		public void msgError(string sMensaje)
		{
			EscribreMensaje((int)NivelLog.Error, sMensaje);
			MessageBox.Show(sMensaje, Settings.Default.appTituloAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		public void msgFatal(string sMensaje)
		{
			EscribreMensaje((int)NivelLog.Fatal, sMensaje);
			MessageBox.Show(sMensaje, Settings.Default.appTituloAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Stop);
		}
	}
}
