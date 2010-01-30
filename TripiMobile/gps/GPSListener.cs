using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using GPSMobile;

namespace Tripi.gps
{
    public class GPSListener
    {
        private static GPSListener instance = null;
        private static readonly object padlock = new object();
        public event Action<GpsPosition> OnLocationChanged = null;
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

        public void OpenGPS()
        {
            if (gps.Opened)
                return;

            gps.Open();
            gps.LocationChanged += new LocationChangedEventHandler(GpsLocationChanged);
        }

        private void GpsLocationChanged(object sender, LocationChangedEventArgs args)
        {
            GpsPosition position = args.Position;
            if (position != null && OnLocationChanged != null)
            {
                OnLocationChanged(args.Position);
            }
        }

        public void CloseGPS()
        {
            if (gps.Opened && OnLocationChanged == null)
            {
                gps.Close();
            }
        }
    }
}
