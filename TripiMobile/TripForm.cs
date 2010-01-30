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
using Tripi.wcf;

namespace Tripi
{
    public partial class TripForm : UIForm
    {
        private ServiceManager service = null;
        private TripMode mode;
        Trip trip = null;

        public TripForm(TripMode mode, Trip trip)
        {
            InitializeComponent();
            this.mode = mode;
            this.trip = trip;

            service = new ServiceManager();
            service.SendFrequencyInSeconds = 10;
        }

        private void FormLoad(object sender, EventArgs e)
        {
            this.MenuBar.LeftMenu = "Back";
            this.MenuBar.LeftMenuClicked += new EventHandler(BackButtonClick);
            this.labelTripName.Text = trip.TripName;
        }

        private void BackButtonClick(object sender, EventArgs e)
        {
            if (service.IsTripRunning)
                StopButtonClick(this, EventArgs.Empty);

            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void StartButtonClick(object sender, EventArgs e)
        {
            if(TripMode.NEW.Equals(mode))
                service.RunNewTrip(trip.TripName);
            else
                service.ContinueTrip(trip);
        }

        private void StopButtonClick(object sender, EventArgs e)
        {
            service.StopTrip();
        }
    }

    public enum TripMode
    {
        NEW, CONTINUE
    }
}