namespace NewConsolidado.Modelos.TransporteDatos
{
	class DTOConsolidadosAsociacionGrupo
	{
		private int hIdConsolidado = 0;
		private int hIdRegistro = 0;
		private string hIdGrupo = "";
		private string hDescripcionGrupo = "";
		private string hIdConcepto = "";
		private string hDescripcionConcepto = "";
		private string hIdCuenta = "";
		private string hDescripcionCuenta = "";

		public int IdConsolidado
		{
			get { return hIdConsolidado; }
			set { hIdConsolidado = value; }
		}
		public int IdRegistro
		{
			get { return hIdRegistro; }
			set { hIdRegistro = value; }
		}
		public string IdGrupo
		{
			get { return hIdGrupo; }
			set { hIdGrupo = value; }
		}
		public string DescripcionGrupo
		{
			get { return hDescripcionGrupo; }
			set { hDescripcionGrupo = value; }
		}
		public string IdConcepto
		{
			get { return hIdConcepto; }
			set { hIdConcepto = value; }
		}
		public string DescripcionConcepto
		{
			get { return hDescripcionConcepto; }
			set { hDescripcionConcepto = value; }
		}
		public string IdCuenta
		{
			get { return hIdCuenta; }
			set { hIdCuenta = value; }
		}
		public string DescripcionCuenta
		{
			get { return hDescripcionCuenta; }
			set { hDescripcionCuenta = value; }
		}
	}
}
