using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

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
            EstimationPoint ep = GetEstimationPoint(double.Parse(lat), double.Parse(lon), DateTime.Parse(tiem));
            return new TrafficLibrary.EstimationPoint(ep.Date, ep.Latitude, ep.Longitude, ep.Speed);
        }
    }
}
