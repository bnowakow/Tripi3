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
using TripiTrafficMap.TrafficServiceReference;
using TripiTrafficMap.Tracks;

namespace TripiTrafficMap
{
    public partial class MainPage : UserControl
    {
        protected IMapStartPositionAdjuster mapStartPositionAdjuster;
        protected TrafficServiceClient trafficServiceClient;
        protected IList<EstimationPoint> pointList;
        protected IList<Track> trackList;

        public MainPage()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);
        }

        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            mapStartPositionAdjuster = new MapStartPositionAdjuster(Map);
            
            trackList = new List<Track>();
            String[] trackFilenames = new String[] { "ZaspaPolitechnika.gpx" };
            for (int i = 0; i < trackFilenames.Length; i++)
            {
                trackList.Add(new Track(trackFilenames[i]));
            }
            QueryTracksSpeed();
            //drawTestPolyline();
        }

        protected void QueryTracksSpeed()
        {
            // TODO based on zoom level count padding
            double pointsPadding = 0.001;
            DateTime time = DateTime.Parse("13:37");
            foreach (Track track in trackList) 
            {
                TrackVelocity trackVelocity = new TrackVelocity(track.getPoints(pointsPadding), time);
                trackVelocity.QueryTrackVelocityCompleted += new QueryTrackVelocityDelegate(trackVelocity_QueryTrackVelocityCompleted);
                trackVelocity.QueryTrackVelocity();
            }
        }

        void trackVelocity_QueryTrackVelocityCompleted(IList<EstimationPoint> velocityPoints)
        {
            pointList = velocityPoints;
            drawTestPolyline();
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
                reader.ReadToFollowing("Speed");
                reader.Read();
                point.Altitude = Double.Parse(reader.Value, System.Globalization.NumberStyles.Any, new NumberFormatInfo());
                //trafficServiceClient.GetEstimationPointAsync(point.Latitude, point.Longitude, DateTime.Parse("13:37"));
                points.Add(point);
            }
            reader.Close();

            return points;
        }

        private void drawTestPolyline()
        {
            //pointList = this.getSamplePositionNodeList();
            //pointList = trackList[0].getPoints(0.0001);

            EstimationPoint prevLocation = null;
            foreach (EstimationPoint location in pointList)
            {
                if (prevLocation != null)
                {
                    LinearGradientBrush linearGradientBrush = new LinearGradientBrush();
                    GradientStop gradientStart = new GradientStop();
                    GradientStop gradientStop = new GradientStop();

                    gradientStart.Offset = 0.0;
                    gradientStop.Offset = 0.5;
                    gradientStart.Color = Color.FromArgb(255, (byte)Math.Round(80 / prevLocation.Speed * 255, 0), (byte)Math.Round(prevLocation.Speed / 80 * 255, 0), 0);
                    gradientStop.Color = Color.FromArgb(255, (byte)Math.Round(80 / location.Speed * 255, 0), (byte)Math.Round(location.Speed / 80 * 255, 0), 0);

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
                    mapPolyline.Locations.Add(new Location(prevLocation.Latitude, prevLocation.Longitude));
                    mapPolyline.Locations.Add(new Location(location.Latitude, location.Longitude));
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
