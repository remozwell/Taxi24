using System;
namespace Taxi24RestAPI.Models
{
    public class FacturaModel
    {
        public FacturaModel()
        {
        }

        public int ID { get; set; }
        public int viajeID { get; set; }
        public double Costo { get; set; }
        public TimeSpan duracionViaje { get; set; }
        public double distanciaRecorridaKM { get; set; }


        public ViajeModel viaje { get; set; }
    }
}
