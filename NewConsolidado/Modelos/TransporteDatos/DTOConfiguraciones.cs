
namespace NewConsolidado.Modelos.TransporteDatos
{
	class DTOConfiguraciones
	{
		private int hIdConfiguraciones = 0;
		private string hKeyConfiguracion = "";
		private string hValorConfiguracion = "";

		public int IdConfiguraciones
		{
			get { return hIdConfiguraciones; }
			set { hIdConfiguraciones = value; }
		}
		public string KeyConfiguracion
		{
			get { return hKeyConfiguracion; }
			set { hKeyConfiguracion = value; }
		}
		public string ValorConfiguracion
		{
			get { return hValorConfiguracion; }
			set { hValorConfiguracion = value; }
		}
	}
}
