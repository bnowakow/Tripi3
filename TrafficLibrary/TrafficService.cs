using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrafficLibrary
{
    class TrafficService : TrafficServiceBase
    {
        public override EstimationPoint GetEstimationPoint(double latitude, double longitude, DateTime date)
        {
            Estimation estimation = new Estimation(new RadialEstimationStrategy(), "001.xml");
            EstimationPoint point = estimation.CalculateEstimationPoint(latitude, longitude, date);
            return point;
        }
    }
}
