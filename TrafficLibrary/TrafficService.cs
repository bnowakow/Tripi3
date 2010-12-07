using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrafficLibrary
{
    public class TrafficService : TrafficServiceBase
    {
        private const string rawPointFile = "_all.xml";

        public override EstimationPoint GetEstimationPoint(double latitude, double longitude, DateTime date)
        {
            Estimation estimation = new Estimation(new RadialEstimationStrategy(), rawPointFile);
            EstimationPoint point = estimation.CalculateEstimationPoint(latitude, longitude, date);
            return point;
        }
    }
}
