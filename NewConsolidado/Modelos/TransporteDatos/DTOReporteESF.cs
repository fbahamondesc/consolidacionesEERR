namespace NewConsolidado.Modelos.TransporteDatos
{
	class DTOReporteESF
	{
		private int hidConsolidado = 0;
		private string hDescripcionConsolidado = "";
		private string hidCompania = "";
		private string hDescripcionCompania = "";
		private string hidGrupo = "";
		private string hDescripcionGrupo = "";
		private int hOrdenGrupo = 0;
		private string hidConcepto = "";
		private string hDescripcionConcepto = "";
		private int hOrdenConcepto = 0;
		private string hidCuenta = "";
		private string hDescripcionCuenta = "";
		private int hOrdenCuenta = 0;
		private string hidPeriodo = "";
		private decimal hValor = 0;

		public int idConsolidado
		{
			get { return hidConsolidado; }
			set { hidConsolidado = value; }
		}
		public string DescripcionConsolidado
		{
			get { return hDescripcionConsolidado; }
			set { hDescripcionConsolidado = value; }
		}
		public string idCompania
		{
			get { return hidCompania; }
			set { hidCompania = value; }
		}
		public string DescripcionCompania
		{
			get { return hDescripcionCompania; }
			set { hDescripcionCompania = value; }
		}
		public string idGrupo
		{
			get { return hidGrupo; }
			set { hidGrupo = value; }
		}
		public string DescripcionGrupo
		{
			get { return hDescripcionGrupo; }
			set { hDescripcionGrupo = value; }
		}
		public int OrdenGrupo
		{
			get { return hOrdenGrupo; }
			set { hOrdenGrupo = value; }
		}
		public string idConcepto
		{
			get { return hidConcepto; }
			set { hidConcepto = value; }
		}
		public string DescripcionConcepto
		{
			get { return hDescripcionConcepto; }
			set { hDescripcionConcepto = value; }
		}
		public int OrdenConcepto
		{
			get { return hOrdenConcepto; }
			set { hOrdenConcepto = value; }
		}
		public string idCuenta
		{
			get { return hidCuenta; }
			set { hidCuenta = value; }
		}
		public string DescripcionCuenta
		{
			get { return hDescripcionCuenta; }
			set { hDescripcionCuenta = value; }
		}
		public int OrdenCuenta
		{
			get { return hOrdenCuenta; }
			set { hOrdenCuenta = value; }
		}
		public string idPeriodo
		{
			get { return hidPeriodo; }
			set { hidPeriodo = value; }
		}
		public decimal Valor
		{
			get { return hValor; }
			set { hValor = value; }
		}
	}
}
