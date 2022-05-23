using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaAerolinea.Clases
{
    public class CompraConsulta
    {
        public int IDVuelo { get; set; }
        public string Aerolinea { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }
        public string FechaHoraSalida { get; set; }
        public string FechaHoraLlegada { get; set; }
        public int AsientosComprados { get; set; }
        public int Costo { get; set; }

    }
}
