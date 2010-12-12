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
using Tripi.data;

namespace Tripi
{
    /// <summary>
    /// Class responsible for writing gps data to file
    /// </summary>
    public class FileManager : DataManager
    {
        /// <summary>
        /// Event fires when user location changes
        /// </summary>
        public event Action OnLocationSaved = null;

        #region PRIVATE_FIELDS
        private static int NOT_SPECIFIED = -1;
        private String fileName = "data.txt";
        private SendScheduler scheduler = null;
        private PositionNode lastPositionNode = null;
        private int sendFrequency = 10000;
        private bool timeRunning = false;
        #endregion

        /// <summary>
        /// FileManager constructor
        /// </summary>
        public FileManager()
        {
            scheduler = new SendScheduler();
        }

        /// <summary>
        /// Start logging the gps positions
        /// </summary>
        public void RunLogging(string fileName)
        {
            this.fileName = fileName;
            scheduler.Start(sendFrequency, LogPosition);
            timeRunning = true;
        }

        /// <summary>
        /// Stops the logging
        /// </summary>
        public void StopLogging()
        {
            timeRunning = false;
            scheduler.Dispose();
        }

        /// <summary>
        /// Sends a position according to the current gps information
        /// </summary>
        /// <param name="position">The current gps position</param>
        private void LogPosition(GpsPosition position)
        {
            if (!timeRunning)
                return;

            PositionNode node = position.GetPositionNode();
            lastPositionNode = node;

            Console.WriteLine(node.Latitude + " : " + node.Longitude + " : " + node.Speed);

            if (OnLocationSaved != null)
                OnLocationSaved();
        }

        #region PROPERTIES

        /// <summary>
        /// Checks whether the trip is running
        /// </summary>
        public bool IsLoggingOn
        {
            get { return timeRunning; }
        }

        /// <summary>
        /// Sets the frequency of sending a gsp data to the wcf service
        /// </summary>
        public int SendFrequencyInSeconds
        {
            set { sendFrequency = value * 1000; }
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
