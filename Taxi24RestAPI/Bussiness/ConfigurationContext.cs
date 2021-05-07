using System;
namespace Taxi24RestAPI.Data
{
    public class ConfigurationContext
    {
        public readonly double RadioKilometroDefault;

        public ConfigurationContext(double KMDefault)
        {
            RadioKilometroDefault = KMDefault;
        }
    }
}
