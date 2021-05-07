using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taxi24RestAPI.Models
{
    public class ViajeModel
    {
        public int ID { get; set; }
        public int IDConductor { get; set; }
        public int IDPasajero { get; set; }
        public float UbicacionInicialLatitud { get; set; }
        public float UbicacionInicialLongitud { get; set; }
        public float UbicacionFinalLatitud { get; set; }
        public float UbicacionFinalLongitud { get; set; }
        public char EstatusViaje { get; set; }

        public ConductorModel Conductor {get;set;}
        public PasajeroModel Pasajero {get;set;}

        public float distanciaRecorrida()
        {
            return 0;
        }
    }
}
