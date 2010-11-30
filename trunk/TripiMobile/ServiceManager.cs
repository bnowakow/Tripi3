using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Tripi.WeatherService;
using System.Xml.Linq;
using System.Reflection;
using System.ServiceModel;

namespace Tripi
{
    class ServiceManager
    {
        public static String GetWeather(String city, String country)
        {
            using (GlobalWeather weather = new GlobalWeather())
            {
                return weather.GetWeather(city, country);
            }
        }

        public static String SendPosition()
        {
            String remoteAddress = "http://10.211.55.3:1234/TripiSilverlightWCFService.svc";
            //remoteAddress = "http://joannar.ds.pg.gda.pl:1234/TripiSilverlightWCFService.svc";
            EndpointAddress endpoint = new EndpointAddress(remoteAddress);
            TripiSilverlightWCFServiceClient service = new TripiSilverlightWCFServiceClient(new BasicHttpBinding(), endpoint);

            int tripId = service.CreateNewTrip("Asia");

            PositionNode node = new PositionNode();
            node.Latitude = 10.0;
            node.Longitude = 20.0;
            node.LatitudeSpecified = true;
            node.LongitudeSpecified = true;
            node.TripID = tripId;
            node.TripIDSpecified = true;

            service.AddPositionNode(node);

            PositionNode[] returnArray = service.GetPositionNodesForTrip(tripId);

            return "";
        }
    }
}
