using System.Drawing;

namespace NewConsolidado.Controladores.Clases
{
	/// <summary>
	/// Clase que guarda variables globales de entorno y de uso volatil
	/// </summary>
    public class Globales
    {
        private static int hiTipoUsuario = (int)CFG.Usuario.Usuario;
        private static string hsUsuarioActivo = "";
        /// <summary>
        /// Tipo de usuario que esta usando la aplicacion
        /// </summary>
        public static int iTipoUsuario
        {
            get { return hiTipoUsuario; }
            set { hiTipoUsuario = value; }
        }
        public static string UsuarioActivo
        {
            get { return hsUsuarioActivo; }
            set { hsUsuarioActivo = value; }
        }

        public static bool ConexionSSPI { get; set; }
    }

	/// <summary>
	/// Clase define las configuraciones estaticas (singeton)
	/// </summary>
	public static class CFG
	{
		public enum TipoConsolidado
		{
			Agrupador = 0,
			Consolidado,
			Empresa
		}
		public enum IndicadorMatriz
		{
			No = 0,
			Si
		}
		public enum BloqueoConsolidado
		{
			Abierto = 0,
			Bloqueado
		}
		public enum EstadoConsolidado
		{
			Inactivo = 0,
			Activo
		}
		public enum ToolAcciones
		{
			Nada = 0,
			Nuevo,
			Editar,
			Eliminar
		}
		public enum ToolBarDiseño
		{
			Ninguno = 0,
			Texto,
			Imagen,
			ImagenYTexto
		}
		public enum Referenciado
		{
			No = 0,
			Si
		}
		public enum TipoAjuste
		{
			Automatico = 0,
			Manual,
			Anulado
		}
		public enum MostrarCamposOcultos
		{
			Ocultar = 0,
			Mostrar
		}
		public enum Importar
		{
			Agrupador = 0,
			PeriodoAfectado,
			PeriodoVisualizar,
			Cuenta,
			Debito,
			Credito,
			Descripcion,
			DescripcionAjuste
		}
		public enum ImportarLinea
		{
			Bueno = 0,
			Malo
		}
		public enum TipoGrupo
		{
			Activo = 0,
			Pasivo,
			Resultado
		}
		public enum TipoConcepto
		{
			Activo = 0,
			Pasivo,
			Resultado
		}
		public enum Patrimonio
		{
			No = 0,
			Si = 1
		}
		public enum OrigenCompania
		{
			Dynamics = 0,
			Manual
		}
		public enum EstadoCompania
		{
			Vigente = 0,
			Inactivo = 1
		}
		public enum CuentaImprime
		{
			No = 0,
			Si
		}
		public enum CuentaManual
		{
			Automatico = 0,
			Manual
		}
		public enum OrigenSaldo
		{
			Dynamics = 0,
			Manual
		}
		public enum FlagImprime
		{
			No = 0,
			Si
		}
		public enum EstadoVersion
		{
			NoVigente = 0,
			Vigente
		}
		public enum TipoIconoArbol
		{
			Agrupador = 0,
			Consolidado,
			Empresa,
			Root
		}
		public enum CopyPaste
		{
			Nada = 0,
			Cortar,
			Copiar,
			Pegar
		}
		public enum SiNo
		{
			No = 0,
			Si
		}
		public enum Reporte
		{
			esf = 0,
			esfSuper,
			erf,
			erfSuper
		}
		public enum Conexion
		{
			Produccion = 0,
			Desarrollo
		}
		public enum Usuario
		{
			Usuario = 0,
			Administrador
		}
		public enum Concurrencia
		{
			SinConcurrencia = 0,
			ConConcurrencia			
		}
        /// <summary>
        /// TipoConfImpresion : Especifica el tipo de reporte a configurar
        /// <para>nada : 0 </para>
        /// <para>ESF : 1</para>
        /// <para>ERF : 2</para>
        /// </summary>
        public enum TipoConfImpresion
        {
            nada = 0,
            ESF,
            ERF
        }

		public static string nodoConsolidadoRaiz = "Arbol de Consolidados";
		public static string[] aTipoConsolidado = { "Agrupador", "Consolidado", "Empresa" };
		public static string[] aToolBarDiseño = { "Ninguno", "Texto", "Imagen", "ImagenYTexto" };
		public static string[] aEstadoConsolidado = { "Inactivo", "Activo" };
		public static string[] aBloqueoConsolidado = { "Abierto", "Bloqueado" };
		public static string[] aIndicadorMatriz = { "Filial", "Matriz" };
		public static string[] aReferenciado = { "", "Referenciado" };
		public static string[] aTipoCuentas = { "3I", "1A", "3E", "2L" };
		public static string[] aTipoAsiento = { "Automatico", "Manual", "Anulado" };
		public static string[] aMuestraCamposOcultos = { "Ocultar Campos", "Mostrar Campos" };
		public static string[] aTipoConcepto = { "Activo", "Pasivo", "Resultado" };
		public static string[] aOrigenEmpresa = { "Dynamics", "Manual" };
		public static string[] aEstadoCompania = { "Vigente", "Inactivo" };
		public static string[] aCuentaImprime = { "Imprimible", "No" };
		public static string[] aCuentaManual = { "Automatico", "Manual" };
		public static string[] aOrigenSaldo = { "Dynamics", "Manual" };
		public static string[] aToolAcciones = { "Nada", "Nuevo", "Editar", "Eliminar" };
        public static string[] aReportes = { "ESF - Estado de Situación Financiera", "ESF - Para Superintendencia", "ERF - Estado de Resultado por Función", "ERF - Para Superintendencia" };
		public static string[] aTipoGrupo = { "Activo", "Pasivo", "Resultado" };
		public static string[] aBool = { "No", "Si" };
		public static string[] aImportarCol = { "A", "B", "C", "D", "E", "F", "G", "H" };
		public static string[] aExcel = { "Agrupador", "Periodo Afectado", "Periodo Visualizar", "Cuenta", "Debito", "Credito", "Descripcion Linea", "Descripcion Ajuste" };
		public static string[] aExcelSaldos = { "Compania", "Periodo", "Cuenta", "Monto" };
		public static string[] aConexion = { "Produccion", "Desarrollo" };
		public static string[] aUsuario = { "Usuario", "Administrador"};
        public static string[] aFlagSumaESF = { "Sumar", "No Sumar"};

		public static Image[] aImportarImg = { Properties.Resources.rsc_16_Bueno, Properties.Resources.rsc_16_Malo };

		public static int buttonAlto = 36;
		public static int buttonAncho = 104;

		public static string sFormatDisplayFecha = "dd/MM/yyyy";
		public static string sFormatDisplayDecimal = "#0.##############";
		public static string sFormatDisplayNumber = "#,##0";
	}
}
