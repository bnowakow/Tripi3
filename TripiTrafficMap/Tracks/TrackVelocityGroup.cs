using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.Generic;
using TripiTrafficMap.TrafficServiceReference;

namespace TripiTrafficMap.Tracks
{
    public class TrackVelocityGroup
    {
        public IList<EstimationPoint> TrackPointList { get { return trackPointList; } }
        protected IList<EstimationPoint> trackPointList;
        public DateTime Time { get { return time; } }
        protected DateTime time;
        public double PointsPadding { get { return pointsPadding; } }
        protected double pointsPadding;

        public TrackVelocityGroup(IList<EstimationPoint> trackPointList, DateTime time, double pointsPadding)
        {
            this.trackPointList = trackPointList;
            this.time = time;
            this.pointsPadding = pointsPadding;
        }
    }
}
