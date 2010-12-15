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
            inbox = new Queue<string>();
        }

        private void FormHousing_Load(object sender, EventArgs e)
        {
            TrafficService singleton = new TrafficService();
            singleton.Log += LogToBox;

            //ServiceServerHelper.StartServiceHost<ITrafficService, ICrossDomainPolicyResponder, TrafficService>(singleton, "Eiskonfekt.svc", "");
            
            ServiceServerHelper.StartServiceHost<ITrafficService, TrafficService>(singleton, "Eiskonfekt.svc");
            ServiceServerHelper.StartWebServiceHost<ICrossDomainPolicyResponder, TrafficService>(singleton, "");

            LogToBox("Servin' has start'd...\r\n");
        }

        private Queue<string> inbox;
        private int totalMessages = 0;
        private void LogToBox(string message)
        {
            totalMessages++;
            if (inbox.Count >= 20) inbox.Dequeue();
            inbox.Enqueue(message);

            if (textBoxLog.InvokeRequired) textBoxLog.Invoke((Action)FillWithText);
            else FillWithText();
        }

        private void FillWithText()
        {
            textBoxLog.Text = "messages: {0} visible / {1} total\r\n\r\n{2}".F(inbox.Count, totalMessages, String.Join("\r\n", inbox.ToArray()));
        }
    }
}
