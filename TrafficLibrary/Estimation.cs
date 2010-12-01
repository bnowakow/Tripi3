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

            var pointsSortedByDistance =
                from point in rawPoints
                orderby point.GetDistanceFromPoint(longitude, latitude)
                select point;

            return pointsSortedByDistance.First() as EstimationPoint;
        }

        private List<RawPoint> LoadRawPoints()
        {
            return new List<RawPoint>();
        }
    }
}