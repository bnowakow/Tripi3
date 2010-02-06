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
    /// <summary>
    /// Windows Form which presents basic information about what happens to our self-hosted WCF service.
    /// </summary>
    public partial class FormMonitor : Form
    {
        private System.ServiceModel.ServiceHost TripiHost;

        public FormMonitor()
        {
            InitializeComponent();

            // we change locale to en-US to assure that our parsing and unparsing behaves consistently (dots as decimal separators etc.)
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");

            Log("Forma serwera PreProd projektu Tripi utworzona.");
        }

        private void FormMonitor_Load(object sender, EventArgs e)
        {
            //TripiHost = new System.ServiceModel.ServiceHost(typeof(TripiWCF.Service.TripServiceVolatile));
            TripiHost = new System.ServiceModel.ServiceHost(typeof(TripiWCF.Service.TripServiceXml));

            TripiHost.Open();

            Log("Rozpoczęto hostowanie usługi TripiWCF.");

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
            if (trips >= 0) labelTrips.Text = "Wycieczki: " + trips;
            if (nodes >= 0) labelNodes.Text = "Pozycje: " + nodes;
        }

        private void Log(string msg)
        {
            textBoxLawg.AppendText(msg + "\r\n");
        }
    }
}
