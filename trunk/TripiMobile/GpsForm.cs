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
using Tripi.gps;

namespace Tripi
{
    public partial class GpsForm : UIForm
    {
        private const string noSatellitesString = "Satellites are currently not available";

        public GpsForm()
        {
            InitializeComponent();
            InitializeGPS();
        }

        private void InitializeGPS()
        {
            GPSListener gpsListener = GPSListener.GetInstance;
            gpsListener.OnLocationChanged += new Action<GpsPosition>(GpsLocationChanged);
            gpsListener.OpenGPS();
        }

        private void GpsLocationChanged(GpsPosition position)
        {
            if (this.InvokeRequired)
            {
                Invoke(new Action<GpsPosition>(GpsLocationChanged), position);
                return;
            }

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

        private void CloseGPS()
        {
            GPSListener gpsListener = GPSListener.GetInstance;
            gpsListener.OnLocationChanged -= new Action<GpsPosition>(GpsLocationChanged);
            gpsListener.CloseGPS();
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