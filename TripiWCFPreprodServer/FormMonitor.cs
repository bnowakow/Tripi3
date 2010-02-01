using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace TripiWCF.PreprodServer
{
    public partial class FormMonitor : Form
    {
        private System.ServiceModel.ServiceHost TripiHost;

        public FormMonitor()
        {
            InitializeComponent();

            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");

            Log("Forma serwera PreProd projektu Tripi utworzona.");
        }

        private void FormMonitor_Load(object sender, EventArgs e)
        {
            //TripiHost = new System.ServiceModel.ServiceHost(typeof(TripiWCF.Service.TripServiceVolatile));
            TripiHost = new System.ServiceModel.ServiceHost(typeof(TripiWCF.Service.TripServiceXml));
            //TripiHost = new System.ServiceModel.ServiceHost(new TripiWCF.Service.TripService());
            TripiHost.Open();

            Log("Rozpoczęto hostowanie usługi TripiWCF.");

            //TripiWCF.Service.TripService receiver = (TripiWCF.Service.TripService) TripiHost.SingletonInstance;
            TripiWCF.Service.TripService.DatabaseInsert += RefreshLabels;
            TripiWCF.Service.TripService.DatabaseQuery += Log;

            Log("Obsługa zdarzeń podłączona.");
        }

        private void FormMonitor_FormClosed(object sender, FormClosedEventArgs e)
        {
            TripiHost.Close();
        }

        private void RefreshLabels(int trips, int nodes)
        {
            labelTrips.Text = "Wycieczki: " + trips;
            labelNodes.Text = "Pozycje: " + nodes;
        }

        private void Log(string msg)
        {
            textBoxLawg.AppendText(msg + "\r\n");
        }
    }
}
