using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Msdn.UIFramework;
using System.IO;

namespace Tripi
{
    public partial class MainForm : UIForm
    {
        public MainForm()
        {
            InitializeComponent();
            this.Height = 32;
        }

        private void FormLoad(object sender, EventArgs e)
        {
            this.MenuBar.Visible = false;
        }

        private void ExitApplication(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MapButtonClick(object sender, EventArgs e)
        {
            GpsForm map = new GpsForm();
            map.ShowDialog();
        }

        private void WeatherButtonClick(object sender, EventArgs e)
        {
            WeatherForm weather = new WeatherForm();
            weather.ShowDialog();
        }
    }
}