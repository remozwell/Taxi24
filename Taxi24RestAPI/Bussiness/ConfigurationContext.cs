using System;
namespace Taxi24RestAPI.Data
{
    public class ConfigurationContext
    {
        public readonly double RadioKilometroDefault;
        public readonly int CantidadConductoresDefault;

        public ConfigurationContext(double KMDefault, int conductoresDefault)
        {
            RadioKilometroDefault = KMDefault;
            CantidadConductoresDefault = conductoresDefault;
        }
    }
}
