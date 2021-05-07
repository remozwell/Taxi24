using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taxi24RestAPI.Models;

namespace Taxi24RestAPI.Bussiness
{
    public static class DistanciaGeograficaHelper
    {
        public const float RadioTierraKm = 6378.0F;

        public static double GetKmDistance(Coordenadas point1, Coordenadas point2)
        {
            double distance = 0;
            double Lat = (point2.Latitud - point1.Latitud) * (Math.PI / 180);
            double Lon = (point2.Longitud - point1.Longitud) * (Math.PI / 180);
            double a = Math.Sin(Lat / 2) * Math.Sin(Lat / 2) + Math.Cos(point1.Latitud * (Math.PI / 180)) * Math.Cos(point2.Latitud * (Math.PI / 180)) * Math.Sin(Lon / 2) * Math.Sin(Lon / 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            distance = RadioTierraKm * c;
            return distance / 1000; 
        }

    }
}
