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
            LoadTripListBox();
        }

        private void LoadTripListBox()
        {
            ServiceManager service = new ServiceManager();
            Trip[] trips = service.GetUserTrips();
            if (trips != null && trips.Length > 0)
            {
                lBoxTrips.DataSource = trips;
                lBoxTrips.DisplayMember = "TripName";
                lBoxTrips.ValueMember = "ID";
            }
            else
            {
                lBoxTrips.Enabled = false;
                bttnOk.Enabled = false;
            }
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