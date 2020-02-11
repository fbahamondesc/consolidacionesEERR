namespace NewConsolidado.Modelos.TransporteDatos
{
	class DTOMaestroCuentas
	{
		private string hidCuenta = "";
		private string hDescripcion = "";
		private string hTipo = "";
		private int hOrden = 0;
		private int hImprime = 0;
		private int hIngresoManual = 0;
		private int hSoloAjuste = 0;
		private int hPatrimonio = 0;

		public string idCuenta
		{
			get { return hidCuenta; }
			set { hidCuenta = value; }
		}
		public string Descripcion
		{
			get { return hDescripcion; }
			set { hDescripcion = value; }
		}
		public string Tipo
		{
			get { return hTipo; }
			set { hTipo = value; }
		}
		public int Orden
		{
			get { return hOrden; }
			set { hOrden = value; }
		}
		public int Imprime
		{
			get { return hImprime; }
			set { hImprime = value; }
		}
		public int IngresoManual
		{
			get { return hIngresoManual; }
			set { hIngresoManual = value; }
		}
		public string Combo
		{
			get {
				if (hidCuenta != "")
				{
					return "(" + hidCuenta.Trim() + ") " + hDescripcion;
				}
				else
				{
					return " " + hDescripcion;
				}
				
			}
			//set { hDescripcion = value; }
		}
		public int SoloAjuste
		{
			get { return hSoloAjuste; }
			set { hSoloAjuste = value; }
		}
		public int Patrimonio
		{
			get { return hPatrimonio; }
			set { hPatrimonio = value; }
		}
	}
}
