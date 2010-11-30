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
    public partial class TripSpotsForm : UIForm
    {
        private ServiceManager service = null;

        public TripSpotsForm()
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
            service = new ServiceManager();
            Trip[] trips = service.UserTrips;
            if (trips != null && trips.Length > 0)
                DisplayTripList(trips);
            else
            {
                lBoxTrips.Enabled = false;
                lBoxSpots.Enabled = false;
            }
        }

        private void DisplayTripList(Trip[] trips)
        {
            lBoxTrips.DataSource = trips;
            lBoxTrips.DisplayMember = "TripName";
            lBoxTrips.ValueMember = "ID";
        }

        private void DisplayTripSpots(PositionNode[] spots)
        {
            lBoxSpots.DataSource = spots;
            lBoxSpots.DisplayMember = "Description";
            lBoxSpots.ValueMember = "OrdinalNumber";
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

        private void OnTripChanged(object sender, EventArgs e)
        {
            if (lBoxTrips.SelectedItem != null)
            {
                Trip selectedTrip = (Trip)lBoxTrips.SelectedItem;
                PositionNode[] nodes = service.GetPositionNodesForTrip(selectedTrip.ID);
                PositionNode[] spots = nodes.Where(
                    node => node.Description != null && 
                        node.Description.Trim() != string.Empty).ToArray();

                if (spots.Length > 0)
                {
                    lBoxSpots.Enabled = true;
                    DisplayTripSpots(spots);
                }
                else
                {
                    lBoxSpots.Enabled = false;
                    lBoxSpots.DataSource = null;
                }
            }
        }
    }
}