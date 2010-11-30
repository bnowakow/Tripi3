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
    public partial class NewTripForm : UIForm
    {
        public NewTripForm()
        {
            InitializeComponent();
        }

        private void FormLoad(object sender, EventArgs e)
        {
            this.MenuBar.LeftMenu = "Back";
            this.MenuBar.LeftMenuClicked += new EventHandler(BackButtonClick);

            this.MenuBar.RightMenu = "SIP";
            this.MenuBar.RightMenuClicked += new EventHandler(ToogleSIP);
        }

        private void BackButtonClick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void OKClick(object sender, EventArgs e)
        {
            Trip trip = new Trip() { TripName = tBoxName.Text };
            TripForm tripForm = new TripForm(TripMode.NEW, trip);
            tripForm.ShowDialog();
            this.Close();
        }

        private void ToogleSIP(object sender, EventArgs e)
        {
            inputPanel.Enabled = !inputPanel.Enabled;
        }
    }
}