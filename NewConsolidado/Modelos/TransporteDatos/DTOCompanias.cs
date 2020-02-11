namespace NewConsolidado.Modelos.TransporteDatos
{
	class DTOCompanias
	{
		private string hIdCompania = "";
		private string hNombre = "";
		private string hRUT= "";
		private string hBaseDatos = "";
		private string hCuentaEjercicio = "";
		private string hCuentaAcumulado = "";
		private int hOrigen = 0;
		private int hVigencia = 0;

		public string IdCompania
		{
			get { return hIdCompania; }
			set { hIdCompania = value; }
		}
		public string Nombre
		{
			get { return hNombre; }
			set { hNombre = value; }
		}

		public string RUT
		{
			get { return hRUT; }
			set { hRUT = value; }
		}

		public string BaseDatos
		{
			get { return hBaseDatos; }
			set { hBaseDatos = value; }
		}

		public string CuentaEjercicio
		{
			get { return hCuentaEjercicio; }
			set { hCuentaEjercicio = value; }
		}

		public string CuentaAcumulado
		{
			get { return hCuentaAcumulado; }
			set { hCuentaAcumulado = value; }
		}

		public int Origen
		{
			get { return hOrigen; }
			set { hOrigen = value; }
		}

		public int Vigencia
		{
			get { return hVigencia; }
			set { hVigencia = value; }
		}
		public string Combo
		{
			get
			{
				if (hIdCompania != "")
				{
					return "(" + hIdCompania.Trim() + ") " + hNombre;
				}
				else
				{
					return " " + hNombre;
				}

			}
			//set { hDescripcion = value; }
		}
	}
}
