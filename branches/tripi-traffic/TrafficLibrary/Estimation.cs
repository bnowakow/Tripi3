using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrafficLibrary
{
    public class Estimation
    {
        public EstimationPoint CalculateEstimationPoint(double latitude, double longitude, DateTime date)
        {
            

            return new EstimationPoint(DateTime.Now, 0.0, 0.0, 100);
        }

        private List<RawPoint> LoadRawPoints()
        {
            return new List<RawPoint>();
        }
    }
}
