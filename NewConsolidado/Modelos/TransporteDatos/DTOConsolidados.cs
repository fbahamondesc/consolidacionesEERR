using System;
using System.Globalization;

using NewConsolidado.Controladores.Clases;

namespace NewConsolidado.Modelos.TransporteDatos
{
	class DTOConsolidados
	{
		private int hIdRegistro = 0;
		private int hIdPadre = 0;
		private string hCodigo = "";
		private string hDescripcion = "";
		private string hObservaciones = "";
		private string hPeriodoInicio = "";
		private string hPeriodoTermino = "";
		private DateTime hFechaCreacion = DateTime.ParseExact("00010101", "yyyyMMdd", CultureInfo.InvariantCulture);
		private DateTime hFechaModificacion = DateTime.ParseExact("99990101", "yyyyMMdd", CultureInfo.InvariantCulture);
		private Decimal hPorcentajeParticipacion = 0;
		private int hIndicadorMatriz = (int)CFG.IndicadorMatriz.No ;
		private int hTipoNodo = (int)CFG.TipoConsolidado.Agrupador;
		private int hEstado = (int)CFG.EstadoConsolidado.Activo;
		private string hOwner = "";
		private int hBloqueo = (int)CFG.BloqueoConsolidado.Abierto;
		private int hReferenciaConsolidado = (int)CFG.Referenciado.No;
		private int hCodigoReferenciado = 0;
		private int hiOrden = 0;
		private string hIdCodigo = "";
		private string hIdCodigoPadre = "";
		private int hiIdComparativo = 0;
		private string hsPeriodoComparativo = "";
		private string hsPeriodoInforme = "";
        private int hiIdComparativoERF = 0;
        private string hsPeriodoComparativoERF = "";
        private string hsPeriodoInformeERF = "";

		public int IdRegistro
		{
			get { return hIdRegistro; }
			set { hIdRegistro = value; }
		}
		public int IdPadre
		{
			get { return hIdPadre; }
			set { hIdPadre = value; }
		}
		public string Codigo
		{
			get { return hCodigo; }
			set { hCodigo = value; }
		}
		public string Descripcion
		{
			get { return hDescripcion; }
			set { hDescripcion = value; }
		}
		public string Observaciones
		{
			get { return hObservaciones; }
			set { hObservaciones = value; }
		}
		public string PeriodoInicio
		{
			get { return hPeriodoInicio; }
			set { hPeriodoInicio = value; } 
		}
		public string PeriodoTermino
		{
			get { return hPeriodoTermino; }
			set { hPeriodoTermino = value; }
		}
		public DateTime FechaCreacion
		{
			get { return hFechaCreacion; }
			set { hFechaCreacion = value; }
		}
		public DateTime FechaModificacion
		{
			get { return hFechaModificacion; }
			set { hFechaModificacion = value; }
		}
		public Decimal PorcentajeParticipacion
		{
			get { return hPorcentajeParticipacion; }
			set { hPorcentajeParticipacion = value; }
		}
		public int IndicadorMatriz
		{
			get { return hIndicadorMatriz; }
			set { hIndicadorMatriz = value; }
		}
		public int TipoNodo
		{
			get { return hTipoNodo; }
			set { hTipoNodo = value; }
		}
		public int Estado
		{
			get { return hEstado; }
			set { hEstado = value; }
		}	
		public string Owner
		{
			get { return hOwner; }
			set { hOwner = value; }
		}		
		public int Bloqueo
		{
			get { return hBloqueo; }
			set { hBloqueo = value; }
		}
		public int RefenciaConsolidado
		{
			get { return hReferenciaConsolidado;}
			set { hReferenciaConsolidado = value; }
		}
		public int CodigoReferenciado
		{
			get { return hCodigoReferenciado; }
			set { hCodigoReferenciado = value; }
		}
		public string IdCodigo
		{
			get { return hIdCodigo; }
			set { hIdCodigo = value; }
		}
		public string IdCodigoPadre
		{
			get { return hIdCodigoPadre; }
			set { hIdCodigoPadre = value; }
		}
		public int Orden
		{
			get { return hiOrden; }
			set { hiOrden = value; }
		}
		public int idComparativo
		{
			get { return hiIdComparativo; }
			set { hiIdComparativo = value;}
		}
		public string PeriodoComparativo
		{
			get { return hsPeriodoComparativo; }
			set { hsPeriodoComparativo = value; }
		}
		public string PeriodoInforme
		{
			get { return hsPeriodoInforme; }
			set { hsPeriodoInforme = value; }
		}
        public int idComparativoERF
        {
            get { return hiIdComparativoERF; }
            set { hiIdComparativoERF = value; }
        }
        public string PeriodoComparativoERF
        {
            get { return hsPeriodoComparativoERF; }
            set { hsPeriodoComparativoERF = value; }
        }
        public string PeriodoInformeERF
        {
            get { return hsPeriodoInformeERF; }
            set { hsPeriodoInformeERF = value; }
        }
    }
}
