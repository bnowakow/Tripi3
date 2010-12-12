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
        private double latitude;
        private double longitude;
        private DateTime date;
        private int queryId;

        public TrafficQuery(int queryId, double latitude, double longitude, DateTime date)
        {
            this.QueryId = queryId;
            this.Latitude = latitude;
            this.Longitude = longitude;
            this.Date = date;
        }
        
        [DataMember]
        public double Latitude
        {
            get { return latitude; }
            private set { latitude = value; }
        }

        [DataMember]
        public double Longitude
        {
            get { return longitude; }
            private  set { longitude = value; }
        }

        [DataMember]
        public DateTime Date
        {
            get { return date; }
            private set { date = value; }
        }

        [DataMember]
        public int QueryId
        {
            get { return queryId; }
            private set { queryId = value; }
        }
    }
}
