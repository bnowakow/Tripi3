using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrafficLibrary
{
    public class RadialEstimationStrategy : EstimationStrategy
    {
        public EstimationPoint RunEstimation(double latitude, double longitude, DateTime date, List<RawPoint> rawPoints)
        {
            var pointsSortedByDistance = rawPoints.OrderBy(point => point.GetDistanceFromPoint(longitude, latitude)).Take(5);
            double avgSpeed = pointsSortedByDistance.Average(point => point.Speed);
            double avgLatitude = pointsSortedByDistance.Average(point => point.Latitude);
            double avgLongitude = pointsSortedByDistance.Average(point => point.Longitude);

            return new EstimationPoint(date, avgLatitude, avgLongitude, avgSpeed);
        }
    }
}
