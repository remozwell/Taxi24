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
        public float UbicacionLatitud { get; set; }
        public float UbicacionLongitud { get; set; }
    }
}
