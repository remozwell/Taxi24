using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taxi24RestAPI.Models
{
    public class Coordenadas
    {
        public Coordenadas(float latitud, float longitud)
        {
            this.Latitud = latitud;
            this.Longitud = longitud;
        }
        public float Latitud { get; set; }
        public float Longitud { get; set; }
    }
}
