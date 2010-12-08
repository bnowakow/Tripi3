using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TrafficLibrary;

namespace TrafficWCFServer
{
    public partial class FormHousing : Form
    {
        public FormHousing()
        {
            InitializeComponent();
        }

        private void FormHousing_Load(object sender, EventArgs e)
        {
            TrafficService singleton = new TrafficService();

            ServiceServerHelper.StartServiceHost<ITrafficService, ICrossDomainPolicyResponder, TrafficService>(singleton, "Eiskonfekt.svc", "");
            //ServiceServerHelper.StartServiceHost<ICrossDomainPolicyResponder, TrafficService>(singleton, "");

            textBoxLog.AppendText("Servin' has start'd...\r\n");
        }

                                                                             
    }
}
