using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Xml;

namespace SilverlightShowcase
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);
        }

        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            SampleWeatherService.GlobalWeatherSoapClient sws = new SampleWeatherService.GlobalWeatherSoapClient();
            sws.GetWeatherCompleted += new EventHandler<SilverlightShowcase.SampleWeatherService.GetWeatherCompletedEventArgs>(sws_GetWeatherCompleted);
            sws.GetWeatherAsync("Gdansk-Rebiechowo", "Poland");
        }

        void sws_GetWeatherCompleted(object sender, SilverlightShowcase.SampleWeatherService.GetWeatherCompletedEventArgs e)
        {
            txtName.Text = e.Result.ToString();
          

        }
    }
}
