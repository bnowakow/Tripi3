using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrafficLibrary
{
    public class RadialEstimationStrategy : EstimationStrategy
    {
        private const int TIME_DIFFERENCE = 15;
        private const int POINTS_FOR_AVARAGE = 5;

        public EstimationPoint RunEstimation(double latitude, double longitude, DateTime date, List<RawPoint> rawPoints)
        {
            if (rawPoints == null || rawPoints.Count() == 0)
                throw new NullReferenceException("The list of RawPoint is empty");

            IEnumerable<RawPoint> points = null;
            int factor = 1;
            while (points == null)
            {
                points = rawPoints
                    .Where(point => point.Date.CheckTimeDifference(date, factor * TIME_DIFFERENCE))
                    .OrderBy(point => point.GetDistanceFromPoint(longitude, latitude)).Take(POINTS_FOR_AVARAGE);
                factor = factor << 1;
            }

            double avgSpeed = points.Average(point => point.Speed);
            double avgLatitude = points.Average(point => point.Latitude);
            double avgLongitude = points.Average(point => point.Longitude);

            return new EstimationPoint(date, avgLatitude, avgLongitude, avgSpeed);
        }
    }
}
