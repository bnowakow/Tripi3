using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Tripi.WeatherService;
using System.Xml.Linq;
using System.Reflection;
using System.ServiceModel;
using GPSMobile;
using Tripi.gps;

namespace Tripi.wcf
{
    class ServiceManager
    { 
        private EndpointAddress endpoint = null;
        private TripiSilverlightWCFServiceClient service = null;
        private int currentTrip = -1;
        private Trip[] userTrips = null;
        private bool tripRunning = false;
        private string userName;
       
        //private string remoteAddress = "http://10.211.55.3:1234/TripiSilverlightWCFService.svc";
        private string remoteAddress = "http://joannar.ds.pg.gda.pl:1234/TripiSilverlightWCFService.svc";

        public ServiceManager(string name)
        {
            this.userName = name;
            endpoint = new EndpointAddress(remoteAddress);     
            service = new TripiSilverlightWCFServiceClient(new BasicHttpBinding(), endpoint);
        }

        public Trip[] UserTrips
        {
            get
            {
                if (userTrips == null)
                    userTrips = service.GetTripsForUser(userName);
                return userTrips;
            }
        }

        public bool IsTripRunning
        {
            get { return tripRunning; }
        }

        public bool RunNewTrip(string tripName)
        {
            currentTrip = service.CreateNewTrip(userName);
            tripRunning = true;
            GPSListener gpsListener = GPSListener.GetInstance;
            gpsListener.OnLocationChanged += new Action<GpsPosition>(SendPosition);
            gpsListener.OpenGPS();
            userTrips = null;
            return true;
        }

        private void SendPosition(GpsPosition position)
        {
            if(!tripRunning && currentTrip != -1)
                return;

            PositionNode node = new PositionNode();
            
            node.CreationTimeSpecified = position.TimeValid;
            if (position.TimeValid)
                node.CreationTime = position.Time;
            
            node.LatitudeSpecified = position.LatitudeValid;
            if (position.LatitudeValid)
                node.Latitude = position.Latitude;

            node.LongitudeSpecified = position.LongitudeValid;
            if (position.LongitudeValid)
                node.Longitude = position.Longitude;

            node.TripIDSpecified = true;
            node.TripID = currentTrip;

            service.AddPositionNode(node);
        }

        public void StopTrip()
        {
            tripRunning = false;
            GPSListener gpsListener = GPSListener.GetInstance;
            gpsListener.OnLocationChanged -= new Action<GpsPosition>(SendPosition);
            gpsListener.CloseGPS();
        }

        public PositionNode[] GetPositionNodesForTrip(int tripId)
        {
            return service.GetPositionNodesForTrip(tripId);
        }
    }
}
