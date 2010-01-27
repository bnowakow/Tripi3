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

namespace Tripi
{
    public partial class MainForm : UIForm
    {
        public MainForm()
        {
            InitializeComponent();
            this.Height = 32;
            addButton();
        }

        private void FormLoad(object sender, EventArgs e)
        {
            this.MenuBar.LeftMenu = "Exit";
            this.MenuBar.LeftMenuClicked += new EventHandler(ExitApplication);
        }

        private void ExitApplication(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void WeatherButtonClick(object sender, EventArgs e)
        {
            WeatherForm weather = new WeatherForm();
            weather.ShowDialog();
        }

        private void GpsButtonClick(object sender, EventArgs e)
        {
            GpsForm map = new GpsForm();
            map.ShowDialog();
        }

        private void addButton()
        {
            ImageElement button = new ImageElement()
            {
                Source = @"images\button_bg2.png",
                Top = 148,
                Left = 59,
                AlphaChannel = false,
            };
            this.Canvas.AddElement(() => button);
        }
    }
}