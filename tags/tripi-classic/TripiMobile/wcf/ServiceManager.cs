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
    /// <summary>
    /// Class responsible for sending gps data to the wcf service
    /// </summary>
    class ServiceManager
    {
        /// <summary>
        /// Event fires when user location changes
        /// </summary>
        public event Action OnLocationSend = null;

        #region PRIVATE_FIELDS
        private static int NOT_SPECIFIED = -1;
        private static string DEFAULT_TRIP_DESCRIPTION = "Trip started on {0}";
        
        private TripServiceClient service = null;
        private SendScheduler scheduler = null;
        private PositionNode lastPositionNode = null;
        private Trip[] userTrips = null;

        private int currentTripId = NOT_SPECIFIED; 
        private int sendFrequency = 10000;
        private bool tripRunning = false;
        #endregion

        /// <summary>
        /// ServiceManager constructor
        /// </summary>
        public ServiceManager()
        {
            EndpointAddress endpoint = new EndpointAddress(MobileConfiguration.WCFAddress);
            service = new TripServiceClient(new BasicHttpBinding(), endpoint);
            scheduler = new SendScheduler();
        }

        /// <summary>
        /// Continue the trip that has been started before
        /// </summary>
        /// <param name="trip">The trip to be continued</param>
        public void ContinueTrip(Trip trip)
        {
            currentTripId = trip.ID;
            RunTrip();
        }

        /// <summary>
        /// Run a new trip
        /// </summary>
        /// <param name="tripName">The name of the trip</param>
        /// <returns>The id of the new trip</returns>
        public int RunNewTrip(string tripName)
        {
            string description = string.Format(DEFAULT_TRIP_DESCRIPTION, DateTime.Now);
            currentTripId = service.CreateNewTrip(User.Login, tripName, description);
            RunTrip();
            return currentTripId;
        }

        /// <summary>
        /// Runs or continues a trip
        /// </summary>
        private void RunTrip()
        {
            scheduler.Start(sendFrequency, SendPosition);
            tripRunning = true;
            userTrips = null;
        }

        /// <summary>
        /// Sends a position according to the current gps information
        /// </summary>
        /// <param name="position">The current gps position</param>
        private void SendPosition(GpsPosition position)
        {
            if (!tripRunning && currentTripId != -1)
                return;

            PositionNode node = position.GetPositionNode();
            node.TripIDSpecified = true;
            node.TripID = currentTripId;

            int nodeId = service.AddPositionNode(node);
            node.OrdinalNumber = nodeId;
            lastPositionNode = node;

            if (OnLocationSend != null)
                OnLocationSend();
        }
        
        /// <summary>
        /// Stops the current trip and closes the gps connection
        /// </summary>
        public void StopTrip()
        {
            tripRunning = false;
            scheduler.Dispose();         
        }
        
        /// <summary>
        /// Updates a specified position node description
        /// </summary>
        /// <param name="node"></param>
        public void UpdatePositionNode(int tripId, int nodeNumber, string description)
        {
            service.UpdatePositionNodeDescription(tripId, nodeNumber, description);
        }

        /// <summary>
        /// Gets the list of position nodes for a specified trip
        /// </summary>
        /// <param name="tripId">The id of the trip</param>
        /// <returns>List of position node for the trpi</returns>
        public PositionNode[] GetPositionNodesForTrip(int tripId)
        {
            return service.GetPositionNodesForTrip(tripId);
        }

        /// <summary>
        /// Logs user to the service
        /// </summary>
        /// <param name="name">User's name</param>
        /// <param name="password">User's password</param>
        /// <returns>True if the user credentials are valid</returns>
        public bool LoginUser(string name, string password)
        {
            string result = service.LoginUser(name, password);
            return result != String.Empty;
        }

        #region PROPERTIES

        /// <summary>
        /// Checks whether the trip is running
        /// </summary>
        public bool IsTripRunning
        {
            get { return tripRunning; }
        }

        /// <summary>
        /// Sets the frequency of sending a gsp data to the wcf service
        /// </summary>
        public int SendFrequencyInSeconds
        {
            set { sendFrequency = value * 1000; }
        }

        /// <summary>
        /// Gets the list of user trips
        /// </summary>
        public Trip[] UserTrips
        {
            get
            {
                if (userTrips == null)
                    userTrips = service.GetTripsForUser(User.Login);
                return userTrips;
            }
        }

        /// <summary>
        /// Gets the last note send to the service
        /// </summary>
        public PositionNode LastPositionNode
        {
            get { return lastPositionNode; }
        }

        #endregion

        /// <summary>
        /// Class used to receive the gps data and send it further when the timer ticks
        /// </summary>
        private class SendScheduler : IDisposable
        {
            private Action<GpsPosition> OnTimeElapsed = null;
            private Timer timer = null;
            private GpsPosition currentPosition = null;
            private bool positionChanged = false;
            private static readonly object padlock = new object();

            public SendScheduler() { }

            /// <summary>
            /// Establishes the gps connection and start the timer
            /// </summary>
            /// <param name="frequency"></param>
            /// <param name="positionDelegate"></param>
            public void Start(int frequency, Action<GpsPosition> positionDelegate)
            {  
                this.OnTimeElapsed = positionDelegate;

                GPSListener gpsListener = GPSListener.GetInstance;
                gpsListener.OnLocationChanged += new Action<GpsPosition>(ReceivePositionFromGps);
                gpsListener.OpenGPS();

                timer = new Timer(new TimerCallback(TimerMethod), null, 0, frequency);
            }

            /// <summary>
            /// Method fired by the timer, sends the gps data further if it has changed
            /// </summary>
            /// <param name="stateInfo"></param>
            private void TimerMethod(Object stateInfo)
            {
                if (OnTimeElapsed != null)
                {
                    lock (padlock)
                    {
                        if (currentPosition != null && positionChanged)
                        {
                            OnTimeElapsed(this.currentPosition);
                            positionChanged = false;
                        }
                    }
                }
            }

            /// <summary>
            /// Receives the data from gps
            /// </summary>
            /// <param name="position"></param>
            public void ReceivePositionFromGps(GpsPosition position)
            {
                lock (padlock)
                {
                    this.currentPosition = position;
                    positionChanged = true;
                }
            }

            #region IDisposable Members

            /// <summary>
            /// Disposes the timer and closes the gps connection
            /// </summary>
            public void Dispose()
            {   
                timer.Dispose();
                
                GPSListener gpsListener = GPSListener.GetInstance;
                gpsListener.OnLocationChanged -= new Action<GpsPosition>(ReceivePositionFromGps);
                gpsListener.CloseGPS();
            }

            #endregion
        }
    }
}
