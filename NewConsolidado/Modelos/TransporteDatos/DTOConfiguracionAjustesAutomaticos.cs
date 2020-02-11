namespace NewConsolidado.Modelos.TransporteDatos
{
	class DTOConfiguracionAjustesAutomaticos
	{

		private string hidCompania = "";
		private string hNombre = "";
		private string hGlosa = "";
		private string hCuentaOrigen = "";
		private string hCuentaDestino = "";
		private string hCuentaDestinoNC = "";
		private string hContraCuenta = "";
		private string hNgCuentaDestino = "";
		private string hNgCuentaDestinoNC = "";
		private string hNgContraCuenta = "";

		public string idCompania
		{
			get { return hidCompania;}
			set { hidCompania = value;}
		}
		public string Nombre
		{
			get { return hNombre; }
			set { hNombre = value; }
		}
		public string CuentaOrigen
		{
			get { return hCuentaOrigen;}
			set { hCuentaOrigen = value;}
		}
		public string Glosa
		{
			get { return hGlosa; }
			set { hGlosa = value; }
		}
		public string CuentaDestino
		{
			get { return hCuentaDestino;}
			set { hCuentaDestino = value;}
		}
		public string CuentaDestinoNC
		{
			get { return hCuentaDestinoNC ;}
			set { hCuentaDestinoNC = value;}
		}
		public string ContraCuenta
		{
			get { return hContraCuenta; }
			set { hContraCuenta = value; }
		}
		public string NgCuentaDestino
		{
			get { return hNgCuentaDestino; }
			set { hNgCuentaDestino = value; }
		}
		public string NgCuentaDestinoNC
		{
			get { return hNgCuentaDestinoNC; }
			set { hNgCuentaDestinoNC = value; }
		}
		public string NgContraCuenta
		{
			get { return hNgContraCuenta; }
			set { hNgContraCuenta = value; }
		}
	}
}
