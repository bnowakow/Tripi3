using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Tripi.WeatherService;
using Tripi.TripiWCFRemote;

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
            TripiSilverlightWCFService service = new TripiSilverlightWCFService();
            service.Url = "http://joannar.ds.pg.gda.pl:1234/TripiSilverlightWCFService.svc";
            
            int tripId;
            bool tripIdeSpecified;
            service.CreateNewTrip("Asia", out tripId, out tripIdeSpecified);

            PositionNode node = new PositionNode();
            node.Latitude = 10.0;
            node.Longitude = 20.0;
            node.LatitudeSpecified = true;
            node.LongitudeSpecified = true;
            node.TripID = tripId;
            node.TripIDSpecified = true;

            service.AddPositionNode(node);

            service.GetPositionNodesForTrip(tripId, true);

            return "";
        }
    }
}
