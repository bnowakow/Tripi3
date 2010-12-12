using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using TrafficLibrary;

namespace TrafficDebugVisualizer.WCF
{
    partial class TrafficServiceClient
    {
        public TrafficServiceClient(Uri ip)
            : this(new BasicHttpBinding(), new EndpointAddress(ip))
        {
        }

        public TrafficLibrary.EstimationPoint GetEstimationPoint(string lat, string lon, string tiem)
        {
            TrafficQuery query = new TrafficQuery(0, double.Parse(lat), double.Parse(lon), DateTime.Parse(tiem));
            TrafficQueryResult result = GetEstimationPoint(query);
            EstimationPoint ep = result.Point;
            return new TrafficLibrary.EstimationPoint(ep.Date, ep.Latitude, ep.Longitude, ep.Speed);
        }
    }
}
