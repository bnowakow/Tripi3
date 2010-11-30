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
    public partial class PointForm : UIForm
    {
        public PointForm()
        {
            InitializeComponent();
        }

        private void SaveClick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BackClick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void FormLoad(object sender, EventArgs e)
        {
            this.MenuBar.LeftMenu = "Back";
            this.MenuBar.LeftMenuClicked += new EventHandler(BackClick);

            this.MenuBar.RightMenu = "SIP";
            this.MenuBar.RightMenuClicked += new EventHandler(ToogleSIP);
        }

        private void ToogleSIP(object sender, EventArgs e)
        {
            inputPanel.Enabled = !inputPanel.Enabled;
        }

        public string Description
        {
            get { return tBoxDescription.Text; }
        }
    }
}