
namespace NewConsolidado.Modelos.TransporteDatos
{
    class DTOConfiguracionComparativos
    {
        private int hIdConsolidado = 0;
        private int hTipo = 0;
        private string hPeriodo = "";
        private int hIdComparativo = 0;
        private string hPeriodoComparativo = "";
        private string hsCodigoComparativo = "";
        private int hiPorDefecto = 0;

        public int IdConsolidado
        {
            get { return hIdConsolidado; }
            set { hIdConsolidado = value; }
        }

        public int Tipo
        {
            get { return hTipo; }
            set { hTipo = value; }
        }

        public string Periodo
        {
            get { return hPeriodo; }
            set { hPeriodo = value; }
        }

        public int IdComparativo
        {
            get { return hIdComparativo; }
            set { hIdComparativo = value; }
        }

        public string PeriodoComparativo
        {
            get { return hPeriodoComparativo; }
            set { hPeriodoComparativo = value; }
        }

        public string CodigoComparativo
        {
            get { return hsCodigoComparativo; }
            set { hsCodigoComparativo = value; }
        }

        public int PorDefecto
        {
            get { return hiPorDefecto; }
            set { hiPorDefecto = value; }
        }
    }
}
