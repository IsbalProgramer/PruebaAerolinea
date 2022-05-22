using Java.Sql;
using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaAerolinea.Clases
{
    public class Vuelo
    {
        public int IDAerolinea { get; set; }
        public int IDOrigen { get; set; }
        public int IdDestino { get; set; }
        public String FechaSalida { get; set; }
        public String HoraSalida { get; set; }
        public String FechaLlegada { get; set; }
        public String HoraLlegada { get; set; }
        public int Asiento { get; set; }
        public int CostoAsiento { get; set; }
    }
}
