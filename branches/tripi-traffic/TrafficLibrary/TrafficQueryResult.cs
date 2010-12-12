using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace TrafficLibrary
{
    [DataContract]
    public class TrafficQueryResult
    {
        protected int queryId;
        protected EstimationPoint point;

        public TrafficQueryResult(int queryId, EstimationPoint point)
        {
            this.QueryId = queryId;
            this.Point = point;
        }

        [DataMember]
        public EstimationPoint Point
        {
            get { return point; }
            private set { point = value; }
        }

        [DataMember]
        public int QueryId
        {
            get { return queryId; }
            private set { queryId = value; }
        }
    }
}
