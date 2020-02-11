namespace NewConsolidado.Modelos.TransporteDatos
{
	class DTOConceptos
	{
		private int hIdConcepto;
		private string hCodigo;
		private string hDescripcion;
		private int hTipo = 0;
		private int hOrden = 0;
        private int hSumaESF = 0;

		public int IdConcepto
		{
			get { return hIdConcepto; }
			set { hIdConcepto = value; }
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
		public int Tipo
		{
			get { return hTipo; }
			set { hTipo = value; }
		}
		public int Orden
		{
			get { return hOrden; }
			set { hOrden = value; }
		}
		public string Combo
		{
			get {
				if (hCodigo != "")
				{
					return "(" + hCodigo.Trim() + ") " + hDescripcion;
				}
				else
				{
					return " " + hDescripcion;
				}
				
			}
			//set { hDescripcion = value; }
		}

        public int FlagSumaESF
        {
            get { return hSumaESF; }
            set { hSumaESF = value; }
        }
	}
}
