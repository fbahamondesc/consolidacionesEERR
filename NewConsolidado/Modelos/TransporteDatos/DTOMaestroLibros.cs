namespace NewConsolidado.Modelos.TransporteDatos
{
	class DTOMaestroLibros
	{
		private int hIdLibro = 0;
		private string hLibro = "";


		public int IdLibro
		{
			get { return hIdLibro; }
			set { hIdLibro = value; }
		}
		public string Libro
		{
			get { return hLibro; }
			set { hLibro = value; }
		}
	}
}
