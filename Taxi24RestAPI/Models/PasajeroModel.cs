using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taxi24RestAPI.Models
{
    public class PasajeroModel
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public double UbicacionLatitud { get; set; }
        public double UbicacionLongitud { get; set; }
    }
}
