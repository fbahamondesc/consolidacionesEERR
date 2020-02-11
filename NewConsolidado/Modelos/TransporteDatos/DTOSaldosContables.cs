namespace NewConsolidado.Modelos.TransporteDatos
{
	class DTOSaldosContables
	{
		private int hIdRegistro = 0;
		private string hIdCompania = "";
		private string hIdCuenta = "";
		private string hPeriodo = "";
		private int hOrigen = 0;
		private string hLibro = "";
		private decimal hDebito = 0;
		private decimal hCredito = 0;
		private string hNombreCompania = "";
		private string hDescripcionCuenta = "";
		private string hTipoCuenta = "";

		public int IdRegistro
		{
			get { return hIdRegistro; }
			set { hIdRegistro = value; }
		}
		public string IdCompania
		{
			get { return hIdCompania; }
			set { hIdCompania = value; }
		}
		public string IdCuenta
		{
			get { return hIdCuenta; }
			set { hIdCuenta = value; }
		}
		public string Periodo
		{
			get { return hPeriodo; }
			set { hPeriodo = value; }
		}
		public int Origen
		{
			get { return hOrigen; }
			set { hOrigen = value; }
		}
		public string Libro
		{
			get { return hLibro; }
			set { hLibro = value; }
		}
		public decimal Debito
		{
			get { return hDebito; }
			set { hDebito = value; }
		}
		public decimal Credito
		{
			get { return hCredito; }
			set { hCredito = value; }
		}
		public string NombreCompania
		{
			get { return hNombreCompania; }
			set { hNombreCompania = value; }
		}
		public string DescripcionCuenta
		{
			get { return hDescripcionCuenta; }
			set { hDescripcionCuenta = value; }
		}
		public string TipoCuenta
		{
			get { return hTipoCuenta; }
			set { hTipoCuenta = value; }
		}
	}
}
