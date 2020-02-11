using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewConsolidado.Modelos.TransporteDatos
{
	class DTOVersiones
	{
		private int hId = 0;
		private string sNumero = "";
		private int hEstado = 0;

		public int Id
		{
			get { return hId; }
			set { hId = value; }
		}

		public string Numero
		{
			get { return sNumero; }
			set { sNumero = value; }
		}
		public int Estado
		{
			get { return hEstado; }
			set { hEstado = value; }
		}
	}
}
