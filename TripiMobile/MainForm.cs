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
    public partial class MainForm : UIForm
    {
        public MainForm()
        {
            InitializeComponent();
            this.Height = 32;
        }

        private void onFormLoad(object sender, EventArgs e)
        {
            this.MenuBar.Visible = false;

           // this.TitleBar.Fill = newraz LinearGradient(Color.PowderBlue, Color.Navy);
            //this.TitleBar.Text = this.Text;

            //weatherLabel.Text = WebServiceManager.GetWeather("Warszawa", "poland");
        }

        private void ExitApplication(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MapButtonClick(object sender, EventArgs e)
        {
            MapForm map = new MapForm();
            map.ShowDialog();
        }

        private void WeatherButtonClick(object sender, EventArgs e)
        {
            WeatherForm weather = new WeatherForm();
            weather.ShowDialog();
        }
    }
}