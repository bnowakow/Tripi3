using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace TrafficLibrary
{
    [DataContract]
    public class EstimationTrack
    {
        protected IList<EstimationPoint> pointList;
        protected DateTime time;
        protected double pointsPadding;
        protected String name;

        public EstimationTrack(IList<EstimationPoint> pointList, DateTime time, double pointsPadding, String name)
        {
            this.PointList = pointList;
            this.Time = time;
            this.PointsPadding = pointsPadding;
            this.Name = name;
        }

        [DataMember]
        public IList<EstimationPoint> PointList
        {
            get { return pointList; }
            private set { pointList = value; }
        }

        [DataMember]
        public DateTime Time
        {
            get { return time; }
            private set { time = value; }
        }

        [DataMember]
        public double PointsPadding
        {
            get { return pointsPadding; }
            private set { pointsPadding = value; }
        }

        [DataMember]
        public String Name
        {
            get { return name; }
            private set { name = value; }
        }
    }
}
