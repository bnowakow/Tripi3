using System;
using System.Collections;
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
using Microsoft.Maps.MapControl;

namespace SilverlightShowcase
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);
        }

        public void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            TripiSilverlightWCFService.TripiSilverlightWCFServiceClient tripiSilverlightWCFServiceClient = new SilverlightShowcase.TripiSilverlightWCFService.TripiSilverlightWCFServiceClient();
            tripiSilverlightWCFServiceClient.GetPositionNodesForTripCompleted += new EventHandler<SilverlightShowcase.TripiSilverlightWCFService.GetPositionNodesForTripCompletedEventArgs>(tripiSilverlightWCFServiceClient_GetPositionNodesForTripCompleted);
            tripiSilverlightWCFServiceClient.GetPositionNodesForTripAsync(0);

            List<Location> polyline = new List<Location>();
            polyline.Add(new Location(3.0, 5.0));
            polyline.Add(new Location(-3.0, 5.0));
            polyline.Add(new Location(3.0, -5.0));
            polyline.Add(new Location(-3.0, -5.0));
            drawPolyline(polyline);
        }

        void tripiSilverlightWCFServiceClient_GetPositionNodesForTripCompleted(object sender, SilverlightShowcase.TripiSilverlightWCFService.GetPositionNodesForTripCompletedEventArgs e)
        {
            txtName.Text = e.Result.ToString();
        }

        private void drawPolyline(List<Location> list)
        {
            MapPolyline mapPolyline = new MapPolyline();
            mapPolyline.Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.White);
            mapPolyline.StrokeThickness = 5;
            mapPolyline.Opacity = 0.7;
            mapPolyline.Locations = new LocationCollection();
            foreach (Location location in list)
            {
                mapPolyline.Locations.Add(location);
            }
            Map.Children.Add(mapPolyline);

        }
    }
}
