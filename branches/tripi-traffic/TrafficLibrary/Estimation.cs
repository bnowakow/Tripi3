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
        private List<RawPoint> rawPoints = null;

        public Estimation(EstimationStrategy strategy, string pointFileName) : this(strategy, LoadRawPoints(pointFileName)) { }

        public Estimation(EstimationStrategy strategy, List<RawPoint> rawPoints)
        {
            this.strategy = strategy;
            this.rawPoints = rawPoints;
        }

        public EstimationPoint CalculateEstimationPoint(double latitude, double longitude, DateTime date)
        {
            return strategy.RunEstimation(latitude, longitude, date, rawPoints);
        }

        private static List<RawPoint> LoadRawPoints(String fileName)
        {
            return StaticUtils.Deserialize<List<RawPoint>>(fileName);
        }
    }
}