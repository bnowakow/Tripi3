using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrafficLibrary
{
    public class Estimation
    {
        private readonly double distanceTreshold = 0.0001;

        public EstimationPoint CalculateEstimationPoint(double latitude, double longitude, DateTime date)
        {
            List<RawPoint> rawPoints = LoadRawPoints();

            var pointsSortedByDistance = rawPoints.OrderBy(point => point.GetDistanceFromPoint(longitude, latitude)).Take(5);
            double avgSpeed = pointsSortedByDistance.Average(point => point.Speed);
            double avgLatitude = pointsSortedByDistance.Average(point => point.Latitude);
            double avgLongitude = pointsSortedByDistance.Average(point => point.Longitude);

            return new EstimationPoint(date, avgLatitude, avgLongitude, avgSpeed);
        }

        private List<RawPoint> LoadRawPoints()
        {
            return StaticUtils.Deserialize<List<RawPoint>>("001.xml");
        }
    }
}