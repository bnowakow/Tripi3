using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using GPSMobile;

namespace Tripi.gps
{                            
    /// <summary>
    /// Listener class for the location change of the user. Gets the data from the gps.
    /// The class implements singleton pattern
    /// </summary>
    public class GPSListener
    {
        private static GPSListener instance = null;
        private static readonly object padlock = new object();

        /// <summary>
        /// Event fires when user location changes
        /// </summary>
        public event Action<GpsPosition> OnLocationChanged = null;
        
        /// <summary>
        /// The Gps object from which the location information is received
        /// </summary>
        private Gps gps = new Gps();

        private GPSListener() { }

        public static GPSListener GetInstance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null) instance = new GPSListener();
                    return instance;
                }
            }
        }
    
        /// <summary>
        /// Open a GPS connection
        /// </summary>
        public void OpenGPS()
        {
            if (gps.Opened)
                return;

            gps.Open();
            gps.LocationChanged += new LocationChangedEventHandler(GpsLocationChanged);
        }

        /// <summary>
        /// Method fired when user location changes
        /// </summary>
        private void GpsLocationChanged(object sender, LocationChangedEventArgs args)
        {
            GpsPosition position = args.Position;
            if (position != null && OnLocationChanged != null)
            {
                OnLocationChanged(args.Position);
            }
        }

        /// <summary>
        /// Close a GPS connection
        /// The connection is closed only if there are no other object subscribed to the event
        /// </summary>
        public void CloseGPS()
        {
            if (gps.Opened && OnLocationChanged == null)
            {
                gps.Close();
            }
        }
    }
}
