using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taxi24RestAPI.Bussiness;
using GeoCoordinatePortable;

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

        public DateTime FechaInicioViaje { get; set; }
        public DateTime? FechaFinViaje { get; set; }

        public ConductorModel Conductor {get;set;}
        public PasajeroModel Pasajero {get;set;}

        public double getDistanciaRecorrida()
        {
            GeoCoordinate p1 = new GeoCoordinate(UbicacionInicialLatitud, UbicacionInicialLongitud);
            GeoCoordinate p2 = new GeoCoordinate(UbicacionFinalLatitud, UbicacionFinalLongitud);
            return DistanciaGeograficaHelper.GetKmDistance(p1, p2);

        }

        public TimeSpan? getMinutosViaje()
        {
            if(FechaFinViaje == null)
            {
                return null;
            }

            var tiempo = this.FechaFinViaje - this.FechaInicioViaje;
            return tiempo;
        }
    }
}
