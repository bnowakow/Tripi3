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
using TripiTrafficMap.Util.Interface;
using TripiTrafficMap.Util;
using Microsoft.Maps.MapControl;
using System.Xml;
using System.Diagnostics;
using System.Globalization;
using System.ServiceModel;
using TrafficLibrary;

namespace TripiTrafficMap
{
    public partial class MainPage : UserControl
    {
        protected IMapStartPositionAdjuster mapStartPositionAdjuster;
        protected TrafficServiceClient trafficServiceClient;
        protected IList<Location> pointList;

        public MainPage()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);
        }

        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            //Map.Width = Application.Current.Host.Content.ActualWidth;
            mapStartPositionAdjuster = new MapStartPositionAdjuster(Map);
            EndpointAddress endpoint = new EndpointAddress("http://localhost:1337/");
            trafficServiceClient = new TrafficServiceClient(new BasicHttpBinding(), endpoint);
            trafficServiceClient.GetEstimationPointCompleted += new EventHandler<GetEstimationPointCompletedEventArgs>(trafficServiceClient_GetEstimationPointCompleted);
            drawTestPolyline();
        }

        void trafficServiceClient_GetEstimationPointCompleted(object sender, GetEstimationPointCompletedEventArgs e)
        {
            //EstimationPoint point
        }

        protected IList<Location> getSamplePositionNodeList()
        {
            IList<Location> points = new List<Location>();

            XmlReader reader = XmlReader.Create(@"TmpXml/_all.xml");
            while (true)
            {
                Location point = new Location();
                reader.ReadToFollowing("Latitude");
                reader.Read();
                if (reader.Value == "")
                {
                    break;
                }
                point.Latitude = Double.Parse(reader.Value, System.Globalization.NumberStyles.Any, new NumberFormatInfo());
                reader.ReadToFollowing("Longitude");
                reader.Read();
                point.Longitude = Double.Parse(reader.Value, System.Globalization.NumberStyles.Any, new NumberFormatInfo());
                trafficServiceClient.GetEstimationPointAsync(point.Latitude, point.Longitude, DateTime.Parse("13:37"));
                //points.Add(point);
            }
            reader.Close();

            return points;
        }

        private void drawTestPolyline()
        {
            pointList = this.getSamplePositionNodeList();

            Location prevLocation = null;
            foreach (Location location in pointList)
            {
                if (prevLocation != null)
                {
                    LinearGradientBrush linearGradientBrush = new LinearGradientBrush();
                    GradientStop gradientStart = new GradientStop();
                    GradientStop gradientStop = new GradientStop();

                    gradientStart.Offset = 0.0;
                    gradientStop.Offset = 0.5;
                    gradientStart.Color = Color.FromArgb(255, (byte)Math.Round(80 / prevLocation.Altitude * 255, 0), (byte)Math.Round(prevLocation.Altitude / 80 * 255, 0), 0);
                    gradientStop.Color = Color.FromArgb(255, (byte)Math.Round(80 / location.Altitude * 255, 0), (byte)Math.Round(location.Altitude / 80 * 255, 0), 0);

                    linearGradientBrush.StartPoint = new Point((180.0 + prevLocation.Longitude) / (Map.ViewportSize.Width / 360.0), (90.0 - prevLocation.Latitude) / (Map.ViewportSize.Height / 180.0));
                    linearGradientBrush.EndPoint = new Point((180.0 + location.Longitude) / (Map.ViewportSize.Width / 360.0), (90.0 - location.Latitude) / (Map.ViewportSize.Height / 180.0));

                    linearGradientBrush.StartPoint = new Point((180.0 + prevLocation.Longitude) / (360.0), (90.0 - prevLocation.Latitude) / (180.0));
                    linearGradientBrush.EndPoint = new Point((180.0 + location.Longitude) / (360.0), (90.0 - location.Latitude) / (180.0));

                    linearGradientBrush.StartPoint = new Point(0, 0);
                    linearGradientBrush.EndPoint = new Point(1, 0);

                    linearGradientBrush.GradientStops = new GradientStopCollection();

                    linearGradientBrush.GradientStops.Add(gradientStart);
                    linearGradientBrush.GradientStops.Add(gradientStop);

                    MapPolyline mapPolyline = new MapPolyline();
                    mapPolyline.Stroke = linearGradientBrush;
                    mapPolyline.StrokeThickness = 5;
                    mapPolyline.Opacity = 0.9;
                    mapPolyline.Locations = new LocationCollection();
                    mapPolyline.Locations.Add(prevLocation);
                    mapPolyline.Locations.Add(location);
                    Map.Children.Add(mapPolyline);
                }
                prevLocation = location;
            }

            if (pointList.Count > 0)
            {
                mapStartPositionAdjuster.SetMapCenterPointAndZoomLevel(pointList);
            }
        }

        private void ColorPicker_ColorChanged(object sender, ColorPickerControl.ColorChangedEventArgs e)
        {
            TmpTextBox.Background = e.newColor;
        }

    }
}
