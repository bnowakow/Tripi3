using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using System.Reflection;
using System.ServiceModel;
using GPSMobile;
using Tripi.gps;
using System.Threading;

namespace Tripi.wcf
{
    class ServiceManager
    {
        private const int NOT_SPECIFIED = -1;
        private EndpointAddress endpoint = null;
        private TripServiceClient service = null;
        private SendScheduler scheduler = null;
        private int currentTripId = NOT_SPECIFIED;
        private string userName;

        //private string remoteAddress = "http://10.211.55.3:8765/main";
        private string remoteAddress = "http://joannar.ds.pg.gda.pl:8765/main";

        public ServiceManager(string name)
        {
            this.userName = name;
            endpoint = new EndpointAddress(remoteAddress);
            service = new TripServiceClient(new BasicHttpBinding(), endpoint);
            scheduler = new SendScheduler();
        }

        public bool RunNewTrip(string tripName)
        {
            currentTripId = service.CreateNewTrip(userName, tripName);
            tripRunning = true;

            GPSListener gpsListener = GPSListener.GetInstance;
            gpsListener.OnLocationChanged += new Action<GpsPosition>(scheduler.ReceivePositionFromGps);
            gpsListener.OpenGPS();
            scheduler.Start(sendFrequency, SendPosition);

            userTrips = null;
            return true;
        }

        private void SendPosition(GpsPosition position)
        {
            if (!tripRunning && currentTripId != -1)
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

            node.SpeedSpecified = position.SpeedValid;
            if (position.SpeedValid)
                node.Speed = position.Speed;

            node.TripIDSpecified = true;
            node.TripID = currentTripId;

            service.AddPositionNode(node);
        }

        public void StopTrip()
        {
            tripRunning = false;
            GPSListener gpsListener = GPSListener.GetInstance;
            gpsListener.OnLocationChanged -= new Action<GpsPosition>(SendPosition);
            scheduler.Dispose();
            gpsListener.CloseGPS();
        }

        public PositionNode[] GetPositionNodesForTrip(int tripId)
        {
            return service.GetPositionNodesForTrip(tripId);
        }

        #region PROPERTIES

        private bool tripRunning = false;
        public bool IsTripRunning
        {
            get { return tripRunning; }
        }

        private int sendFrequency = 10000;
        public int SendFrequencyInSeconds
        {
            set { sendFrequency = value * 1000; }
        }

        private Trip[] userTrips = null;
        public Trip[] UserTrips
        {
            get
            {
                if (userTrips == null)
                    userTrips = service.GetTripsForUser(userName);
                return userTrips;
            }
        }

        #endregion

        private class SendScheduler : IDisposable
        {
            private Action<GpsPosition> OnTimeElapsed = null;
            private Timer timer = null;
            private GpsPosition position = null;
            private static readonly object padlock = new object();

            public SendScheduler() { }

            public void Start(int frequency, Action<GpsPosition> positionDelegate)
            {
                this.OnTimeElapsed = positionDelegate;
                timer = new Timer(new TimerCallback(TimerMethod), null, frequency, frequency);
            }

            private void TimerMethod(Object stateInfo)
            {
                if (OnTimeElapsed != null)
                {
                    lock (padlock)
                    {
                        OnTimeElapsed(this.position);
                    }
                }
            }

            public void ReceivePositionFromGps(GpsPosition position)
            {
                lock (padlock)
                {
                    this.position = position;
                }
            }

            #region IDisposable Members

            public void Dispose()
            {
                timer.Dispose();
            }

            #endregion
        }
    }
}
