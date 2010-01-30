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
using System.ServiceModel;

namespace SilverlightShowcase
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);
        }

        private string remoteAddress = "http://10.211.55.3:8765/main";
        private EndpointAddress endpoint = null;
        private TripServiceClient service = null;

        public void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            endpoint = new EndpointAddress(remoteAddress);
            service = new TripServiceClient(new BasicHttpBinding(), endpoint);
            service.GetPositionNodesForTripCompleted += new EventHandler<GetPositionNodesForTripCompletedEventArgs>(service_GetPositionNodesForTripCompleted);
            service.GetPositionNodesForTripAsync(0);

        }

        void service_GetPositionNodesForTripCompleted(object sender, GetPositionNodesForTripCompletedEventArgs e)
        {
            List<Location> polyline = new List<Location>();
            foreach (var point in e.Result)
            {
                polyline.Add(new Location(point.Latitude, point.Longitude));   
            }
            drawPolyline(polyline);
        }

        private void drawPolyline(List<Location> list)
        {
            MapPolyline mapPolyline = new MapPolyline();
            mapPolyline.Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Red);
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
