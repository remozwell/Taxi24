using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeoCoordinatePortable;
using Taxi24RestAPI.Models;

namespace Taxi24RestAPI.Bussiness
{
    public static class DistanciaGeograficaHelper
    {
        public const float RadioTierra = 6378.0F;

        public static double GetKmDistance(GeoCoordinate point1, GeoCoordinate point2)
        {
            double distance = 0;
            double Lat = (point2.Latitude - point1.Latitude) * (Math.PI / 180);
            double Lon = (point2.Longitude - point1.Longitude) * (Math.PI / 180);
            double a = Math.Sin(Lat / 2) * Math.Sin(Lat / 2) + Math.Cos(point1.Latitude * (Math.PI / 180)) * Math.Cos(point2.Latitude * (Math.PI / 180)) * Math.Sin(Lon / 2) * Math.Sin(Lon / 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            distance = RadioTierra * c;
            return distance / 1000; 
        }

        public static RangeCoordenadaModel GetSquareRadiusCoordenate(GeoCoordinate puntoInicial,  double DistanciaKm)
        {

            var distanciaAprox = (DistanciaKm / RadioTierra) * (180 / Math.PI);

            var maxLatitude = puntoInicial.Latitude + distanciaAprox;
            var maxLongitude = puntoInicial.Longitude + distanciaAprox;
            var max = new GeoCoordinate(maxLatitude,maxLongitude);


            var minLatitude = puntoInicial.Latitude - distanciaAprox;
            var minLongitude = puntoInicial.Longitude - distanciaAprox;
            var min = new GeoCoordinate(maxLatitude, maxLongitude);

            return new RangeCoordenadaModel(min, max);
        }

    }
}
