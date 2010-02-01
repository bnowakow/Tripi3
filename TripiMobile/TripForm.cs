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
using System.Threading;

using TTimer = System.Threading.Timer;

namespace Tripi
{
    public partial class TripForm : UIForm
    {
        private ServiceManager service = null;
        private TripMode mode;
        Trip trip = null;
        private int defaultFrequency = 3;

        public TripForm(TripMode mode, Trip trip)
        {
            InitializeComponent();
            this.mode = mode;
            this.trip = trip;

            service = new ServiceManager();
            nudFrequency.Value = defaultFrequency;
        }

        private void FormLoad(object sender, EventArgs e)
        {
            this.MenuBar.LeftMenu = "Back";
            this.MenuBar.LeftMenuClicked += new EventHandler(BackButtonClick);
            this.labelTripName.Text = trip.TripName;
            service.OnLocationSend += new Action(OnLocationSendToService);
        }

        private void OnLocationSendToService()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(OnLocationSendToService));
                return;
            }
            bttnAddPoint.Enabled = true;
            picBoxSignal.Visible = true;
            Thread thread = new Thread(new ThreadStart(TimerMethod));
            thread.Start();
        }

        private void TimerMethod()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(TimerMethod));
                return;
            }
            Thread.Sleep(500);
            picBoxSignal.Visible = false;
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
            service.SendFrequencyInSeconds = (int)nudFrequency.Value;
            if (TripMode.NEW.Equals(mode))
                service.RunNewTrip(trip.TripName);
            else
                service.ContinueTrip(trip);
            setButtons(true);
        }

        private void StopButtonClick(object sender, EventArgs e)
        {
            service.StopTrip();
            mode = TripMode.CONTINUE;
            setButtons(false);
        }

        private void setButtons(bool start)
        {
            bttnStart.Enabled = !start;
            nudFrequency.Enabled = !start;
            bttnAddPoint.Visible = start;
            bttnStop.Enabled = start;
        }

        private void AddInterestingSpotClick(object sender, EventArgs e)
        {
            PointForm pointForm = new PointForm();
            DialogResult result = pointForm.ShowDialog();
            string description = pointForm.Description;
            if (result == DialogResult.OK && description != string.Empty)
            {
                service.NextNodeDescription = pointForm.Description;
                bttnAddPoint.Enabled = false;
            }
        }
    }

    public enum TripMode
    {
        NEW, CONTINUE
    }
}