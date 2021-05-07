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
        public double UbicacionInicialLatitud { get; set; }
        public double UbicacionInicialLongitud { get; set; }
        public double UbicacionFinalLatitud { get; set; }
        public double UbicacionFinalLongitud { get; set; }
        public char EstatusViaje { get; set; }

        public ConductorModel Conductor {get;set;}
        public PasajeroModel Pasajero {get;set;}

        public double distanciaRecorrida()
        {
            return 0;
        }
    }
}
