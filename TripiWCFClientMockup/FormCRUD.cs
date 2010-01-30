using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TripiWCF.ClientMockup
{
    public partial class FormCRUD : Form
    {
        private Proxy.TripServiceClient TripiProxyFoxyJazzyClient;
        private Random Tanarri = new Random();

        public FormCRUD()
        {
            InitializeComponent();
        }

        private void FormCRUD_Load(object sender, EventArgs e)
        {
            Proxy.Trip temp = new TripiWCF.ClientMockup.Proxy.Trip();
            temp.ID = -1;
            temp.Username = Environment.UserName;
            temp.TripName = Environment.MachineName;
            propertyGridTrip.SelectedObject = temp;
        }

        #region Handling buttons
        private void buttonConnect_Click(object sender, EventArgs e)
        {
            TripiProxyFoxyJazzyClient = new TripiWCF.ClientMockup.Proxy.TripServiceClient("TripiTestClient");

            buttonCreateAsProphesized.Enabled = true;
            buttonCreateRandomNode.Enabled = true;
            buttonCreateTrip.Enabled = true;
            buttonGetNodes.Enabled = true;
            buttonGetTrips.Enabled = true;
        }

        private void buttonCreateTrip_Click(object sender, EventArgs e)
        {
            Proxy.Trip temp = propertyGridTrip.SelectedObject as Proxy.Trip;
            int newTripID = TripiProxyFoxyJazzyClient.CreateNewTrip(temp.Username, temp.TripName);
            temp.ID = newTripID;
            propertyGridTrip.SelectedObject = temp;
        }

        private void buttonGetTrips_Click(object sender, EventArgs e)
        {
            Proxy.Trip temp = propertyGridTrip.SelectedObject as Proxy.Trip;
            listBoxTrips.Items.Clear();
            listBoxTrips.Items.AddRange(TripiProxyFoxyJazzyClient.GetTripsForUser(temp.Username));
        }

        private void buttonGetNodes_Click(object sender, EventArgs e)
        {
            Proxy.Trip temp = propertyGridTrip.SelectedObject as Proxy.Trip;
            listBoxPositions.Items.Clear();
            listBoxPositions.Items.AddRange(TripiProxyFoxyJazzyClient.GetPositionNodesForTrip(temp.ID));
        }

        private void buttonCreateRandomNode_Click(object sender, EventArgs e)
        {
            Proxy.Trip temp = propertyGridTrip.SelectedObject as Proxy.Trip;
            Proxy.PositionNode noed = new TripiWCF.ClientMockup.Proxy.PositionNode
            {
                CreationTime = DateTime.Now,
                Latitude = Tanarri.NextDouble() * 9001,
                Longitude = Tanarri.NextDouble() * 9001,
                TripID = temp.ID
            };
            TripiProxyFoxyJazzyClient.AddPositionNode(noed);
        }

        private void buttonCreateAsProphesized_Click(object sender, EventArgs e)
        {
            Proxy.PositionNode noed = propertyGridPosition.SelectedObject as Proxy.PositionNode;
            if (noed != null) TripiProxyFoxyJazzyClient.AddPositionNode(noed);
        }
        #endregion

        private void listBoxTrips_SelectedIndexChanged(object sender, EventArgs e)
        {
            propertyGridTrip.SelectedObject = listBoxTrips.SelectedItem;
        }

        private void listBoxPositions_SelectedIndexChanged(object sender, EventArgs e)
        {
            propertyGridPosition.SelectedObject = listBoxPositions.SelectedItem;
        }
    }
}
