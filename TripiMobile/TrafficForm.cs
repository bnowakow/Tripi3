using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Msdn.UIFramework;
using Tripi.gps;
using Tripi.wcf;
using System.Threading;
using Tripi.data;
using GPSMobile;

namespace Tripi
{
    public partial class TrafficForm : UIForm
    {
        private String dataFileName = "data.txt";
        private FileManager service = null;
        private int defaultFrequency = 3;

        public TrafficForm()
        {
            InitializeComponent();
            this.Height = 32;
        }

        private void FormLoad(object sender, EventArgs e)
        {
            this.MenuBar.LeftMenu = "Exit";
            this.MenuBar.LeftMenuClicked += new EventHandler(ExitApplication);

            defaultFrequency = MobileConfiguration.DefaultSendFrequency;
            nudFrequency.Value = defaultFrequency;

            service = new FileManager();
            service.OnLocationSaved += new Action(OnLocationSaved);
        }

        private void OnLocationSaved()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(OnLocationSaved));
                return;
            }
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

        private void StartButtonClick(object sender, EventArgs e)
        {
            service.SendFrequencyInSeconds = (int)nudFrequency.Value;
            service.RunLogging(dataFileName);
            setButtons(true);
        }

        private void StopButtonClick(object sender, EventArgs e)
        {
            service.StopLogging();
            setButtons(false);
        }

        private void setButtons(bool start)
        {
            bttnStart.Enabled = !start;
            nudFrequency.Enabled = !start;
            bttnStop.Enabled = start;
        }

        private void ExitApplication(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void OnClosing(object sender, CancelEventArgs e)
        {
            if (service.IsLoggingOn)
                StopButtonClick(this, EventArgs.Empty);
            GPSListener.GetInstance.CloseGPS();
        }
    }
}