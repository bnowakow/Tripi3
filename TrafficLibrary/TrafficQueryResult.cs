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
        protected IList<EstimationTrack> tracks;

        public TrafficQueryResult(int queryId, IList<EstimationTrack> tracks)
        {
            this.QueryId = queryId;
            this.Tracks = tracks;
        }

        [DataMember]
        public IList<EstimationTrack> Tracks
        {
            get { return tracks; }
            private set { tracks = value; }
        }

        [DataMember]
        public int QueryId
        {
            get { return queryId; }
            private set { queryId = value; }
        }
    }
}
