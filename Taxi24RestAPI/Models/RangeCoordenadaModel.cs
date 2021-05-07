using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeoCoordinatePortable;

namespace Taxi24RestAPI.Models
{
    public class RangeCoordenadaModel
    {
        public RangeCoordenadaModel(GeoCoordinate _min, GeoCoordinate _max)
        {
            this.min = _min;
            this.max = _max;
        }
        public GeoCoordinate min { get; set; }
        public GeoCoordinate max { get; set; }
    }
}
