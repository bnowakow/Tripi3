using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace TrafficLibrary
{
    [DataContract]
    public class TrafficQuery
    {
        private IList<RawPoint> points;
        private IList<DateTime> dates;
        private int queryId;
        protected double pointsPadding;
        protected String name;

        public TrafficQuery(int queryId, IList<RawPoint> points, IList<DateTime> dates, double pointsPadding, String name)
        {
            this.QueryId = queryId;
            this.Points = points;
            this.Dates = dates;
            this.PointsPadding = pointsPadding;
            this.Name = name;
        }

        [DataMember]
        public IList<RawPoint> Points
        {
            get { return points; }
            private set { points = value; }
        }

        [DataMember]
        public IList<DateTime> Dates
        {
            get { return dates; }
            private set { dates = value; }
        }

        [DataMember]
        public double PointsPadding { 
            get { return pointsPadding; }
            private set { pointsPadding = value; }
        }


        [DataMember]
        public String Name { 
            get { return name; }
            private set { name = value; }
        }

        [DataMember]
        public int QueryId
        {
            get { return queryId; }
            private set { queryId = value; }
        }
    }
}
