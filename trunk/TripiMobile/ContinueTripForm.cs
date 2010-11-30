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

namespace Tripi
{
    public partial class ContinueTripForm : UIForm
    {
        public ContinueTripForm()
        {
            InitializeComponent();
        }

        private void FormLoad(object sender, EventArgs e)
        {
            this.MenuBar.LeftMenu = "Back";
            this.MenuBar.LeftMenuClicked += new EventHandler(BackButtonClick);
            GetTripList();
        }

        private void GetTripList()
        {
            ServiceManager service = new ServiceManager();
            Trip[] trips = service.UserTrips;
            if (trips != null && trips.Length > 0)
                DisplayTripList(trips);
            else
                DisableButtons();
        }

        private void DisplayTripList(Trip[] trips)
        {
            lBoxTrips.DataSource = trips;
            lBoxTrips.DisplayMember = "TripName";
            lBoxTrips.ValueMember = "ID";
        }

        private void DisableButtons()
        {
            lBoxTrips.Enabled = false;
            bttnOk.Enabled = false;
        }

        private void BackButtonClick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void OKClick(object sender, EventArgs e)
        {
            Trip trip = lBoxTrips.SelectedItem as Trip;
            if (trip != null)
            {
                TripForm tripForm = new TripForm(TripMode.CONTINUE, trip);
                tripForm.ShowDialog();
                this.Close();
            }
        }
    }
}