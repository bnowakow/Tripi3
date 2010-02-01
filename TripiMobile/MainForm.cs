using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Msdn.UIFramework;
using Tripi.gps;

namespace Tripi
{
    public partial class MainForm : UIForm
    {
        public MainForm()
        {
            InitializeComponent();
            this.Height = 32;
        }

        private void FormLoad(object sender, EventArgs e)
        {
            this.MenuBar.LeftMenu = "Exit";
            this.MenuBar.LeftMenuClicked += new EventHandler(ExitApplication);
            labelUserValue.Text = User.Login;
        }

        private void ExitApplication(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void GpsButtonClick(object sender, EventArgs e)
        {
            GpsForm gpsForm = new GpsForm();
            gpsForm.ShowDialog();
        }

        private void NewTripButtonClick(object sender, EventArgs e)
        {
            NewTripForm newTripForm = new NewTripForm();
            newTripForm.ShowDialog();
        }

        private void ContinueTripClick(object sender, EventArgs e)
        {
            ContinueTripForm continueTripForm = new ContinueTripForm();
            continueTripForm.ShowDialog();
        }

        private void ViewTripsClick(object sender, EventArgs e)
        {
            TripSpotsForm spotForm = new TripSpotsForm();
            spotForm.ShowDialog();
        }

        private void OnClosing(object sender, CancelEventArgs e)
        {
            GPSListener.GetInstance.CloseGPS();
        }
    }
}