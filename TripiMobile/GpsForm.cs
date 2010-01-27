using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GPSMobile;
using Msdn.UIFramework;

namespace Tripi
{
    public partial class GpsForm : UIForm
    {
        private Gps gps = new Gps();
        private const string noSatellitesString = "Satellites are currently not available";

        public GpsForm()
        {
            InitializeComponent();
            InitializeGPS();
        }

        private void InitializeGPS()
        {
            gps.Open();
            gps.LocationChanged += new LocationChangedEventHandler(GpsLocationChanged);
        }

        private void CloseGPS()
        {
            if (gps.Opened)
            {
                gps.Close();
            }
        }

        private void GpsLocationChanged(object sender, LocationChangedEventArgs args)
        {
            if (this.InvokeRequired)
            {
                Invoke(new LocationChangedEventHandler(GpsLocationChanged), sender, args);
                return;
            }

            GpsPosition position = args.Position;
            if (position != null)
            {
                tboxLatitude.Text = position.LatitudeValid ?
                    position.LatitudeInDegreesMinutesSeconds.ToString() : "";

                tboxLongitude.Text = position.LongitudeValid ?
                    position.LongitudeInDegreesMinutesSeconds.ToString() : "";

                tboxSpeed.Text = position.SpeedValid ?
                    position.Speed.ToString() : "";

                if (!position.SatellitesInSolutionValid ||
                    !position.SatellitesInViewValid ||
                    !position.SatelliteCountValid || position.SatelliteCount == 0)
                {
                    labelSatellite.Text = noSatellitesString;
                }
                else
                {
                    labelSatellite.Text = "";
                }
            }
        }

        private void BackButtonClick(object sender, EventArgs e)
        {
            CloseGPS();
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void FormLoad(object sender, EventArgs e)
        {
            this.MenuBar.LeftMenu = "Back";
            this.MenuBar.LeftMenuClicked += new EventHandler(BackButtonClick);
        }
    }
}