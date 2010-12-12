using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrafficDebugVisualizer.WCF
{
    public partial class TrafficQuery
    {
        public TrafficQuery(int queryId, double latitude, double longitude, DateTime date)
        {
            this.QueryId = queryId;
            this.Latitude = latitude;
            this.Longitude = longitude;
            this.Date = date;
        }
    }
}
