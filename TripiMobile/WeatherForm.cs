using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Msdn.UIFramework;

namespace Tripi
{
    public partial class WeatherForm : UIForm
    {
        public WeatherForm()
        {
            InitializeComponent();
        }

        private void BackButtonClick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void FormLoad(object sender, EventArgs e)
        {
            this.MenuBar.LeftMenu = "Back";
            this.MenuBar.LeftMenuClicked += new EventHandler(BackButtonClick);
            weatherDescription.Text = "";//ServiceManager.GetWeather("Warszawa", "Poland");
        }
    }
}