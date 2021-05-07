using System;
namespace Taxi24RestAPI.Bussiness
{
    public class PriceGenerator
    {
        private readonly double CostoKm;
        private readonly double CostoMinuto;
        private readonly double CostoBase;
        public PriceGenerator(double cBase, double costoKM, double costoMinuto)
        {
            CostoBase = cBase;
            CostoKm = costoKM;
            CostoMinuto = costoMinuto;
        }

        public double GetPrecioViaje(double distanciaKM, TimeSpan tiempoViaje)
        {
            double costoDistanciaFinal = distanciaKM * CostoKm;
            double costoTiempoFinal = tiempoViaje.TotalMinutes * CostoMinuto;

            return costoDistanciaFinal + costoTiempoFinal + CostoBase;


        }
    }
}
