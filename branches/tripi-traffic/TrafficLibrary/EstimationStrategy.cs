using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrafficLibrary
{
    public interface EstimationStrategy
    {
        EstimationPoint RunEstimation(double latitude, double longitude, DateTime date, List<RawPoint> rawPoints);    
    }
}
