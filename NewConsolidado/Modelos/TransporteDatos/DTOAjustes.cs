namespace NewConsolidado.Modelos.TransporteDatos
{
	class DTOAjustes
	{
		private int hIdRegistro = 0;
		private int hIdConsolidado = 0;
		private string hPeriodoAfectado = "";
		private int hCorrelativoAsiento = 0;
		private string hIdCuenta = "";
		private string hPeriodoVista = "";
		private int hTipoTransaccion = 0;
		private decimal hDebito = 0;
		private decimal hCredito = 0;
		private string hDescripcion = "";
		private int hAccion = 0;
		private string sDescripcionCuenta = "";
		private string sDescripcionCabecera = "";

		public int IdRegistro
		{
			get { return hIdRegistro; }
			set { hIdRegistro = value; }
		}
		public int IdConsolidado
		{
			get { return hIdConsolidado; }
			set { hIdConsolidado = value; }
		}
		public string PeriodoAfectado
		{
			get { return hPeriodoAfectado; }
			set { hPeriodoAfectado = value; }
		}
		public int CorrelativoAsiento
		{
			get { return hCorrelativoAsiento; }
			set { hCorrelativoAsiento = value; }
		}
		public string IdCuenta
		{
			get { return hIdCuenta; }
			set { hIdCuenta = value; }
		}
		public string PeriodoVista
		{
			get { return hPeriodoVista; }
			set { hPeriodoVista = value; }
		}
		public int TipoTransaccion
		{
			get { return hTipoTransaccion; }
			set { hTipoTransaccion = value; }
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
		public string Descripcion
		{
			get { return hDescripcion; }
			set { hDescripcion = value; }
		}
		public int Accion
		{
			get { return hAccion; }
			set { hAccion = value; }
		}
		public string DescripcionCuenta
		{
			get { return sDescripcionCuenta; }
			set { sDescripcionCuenta = value; }
		}
		public string DescripcionCabecera
		{
			get { return sDescripcionCabecera; }
			set { sDescripcionCabecera = value; }
		}
	}
}
