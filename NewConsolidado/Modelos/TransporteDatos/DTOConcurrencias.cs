
namespace NewConsolidado.Modelos.TransporteDatos
{
	class DTOConcurrencias
	{
		private string hsKeyConcurrencia = "";
		private int hiValueConcurrencia = 0;

		public string KeyConcurrencia
		{
			get { return hsKeyConcurrencia; }
			set { hsKeyConcurrencia = value; }
		}
		public int ValueConcurrencia
		{
			get { return hiValueConcurrencia; }
			set { hiValueConcurrencia = value; }
		}
	}
}
