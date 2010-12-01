using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrafficLibrary
{
    public class Estimation
    {
        private readonly double distanceTreshold = 0.0001;
        private EstimationStrategy strategy = null;

        public Estimation(EstimationStrategy strategy)
        {
            this.strategy = strategy;
        }

        public EstimationPoint CalculateEstimationPoint(double latitude, double longitude, DateTime date)
        {
            List<RawPoint> rawPoints = LoadRawPoints();
            EstimationPoint result = strategy.RunEstimation(latitude, longitude, date, rawPoints);
            return result;
        }

        private List<RawPoint> LoadRawPoints()
        {
            return StaticUtils.Deserialize<List<RawPoint>>("001.xml");
        }
    }
}