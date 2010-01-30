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
    public partial class TripForm : UIForm
    {
        private ServiceManager service = null;

        public TripForm()
        {
            InitializeComponent();
            service = new ServiceManager(User.Login);
        }

        private void FormLoad(object sender, EventArgs e)
        {
            this.MenuBar.LeftMenu = "Back";
            this.MenuBar.LeftMenuClicked += new EventHandler(BackButtonClick);
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
            service.RunNewTrip(tboxName.Text);
        }

        private void StopButtonClick(object sender, EventArgs e)
        {
            service.StopTrip();
        }
    }
}