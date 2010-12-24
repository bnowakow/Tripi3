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
        
        //protected List<EstimationPoint> pointList;

        protected TrackVelocityGroupManager trackVelocityGroupManager;
        protected List<EstimationTrack> trackVelocityGroupList;
        protected List<Track> trackList;

        public MainPage()
        {
            InitializeComponent();
            trackList = new List<Track>();
            String[] trackFilenames = new String[] { "ZaspaPolitechnika.gpx", "SlowackiegoTmp.gpx" };
            for (int i = 0; i < trackFilenames.Length; i++)
            {
                trackList.Add(new Track(trackFilenames[i]));
            }
            List<DateTime> timeList = new List<DateTime>();
            for (int i = (int)hourSlider.Minimum; i <= (int)hourSlider.Maximum; i++) 
            {
               timeList.Add(DateTime.Parse(i + ":00"));
            }
            trackVelocityGroupList = new List<EstimationTrack>();
            trackVelocityGroupManager = new TrackVelocityGroupManager(trackList, timeList);
            trackVelocityGroupManager.OnVelocityGroupQueryCompleted += new QueryTrackVelocityGroupDelegate(trackVelocityGroupManager_OnVelocityGroupQueryCompleted);
            hourSliderPreviousValue = (int)hourSlider.Value;
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);
        }

        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            mapStartPositionAdjuster = new MapStartPositionAdjuster(Map);

            // TODO tmp
            QueryTracksSpeed();
            Map.LayoutUpdated += new EventHandler(Map_LayoutUpdated);
            velocityColorPicker.OnColorChange += new ColorPickerControl.VelocityColorPickerColorChangeDelegate(velocityColorPicker_OnColorChange);
        }

        void velocityColorPicker_OnColorChange()
        {
            UpdateVelocityPolyline();
        }

        void Map_LayoutUpdated(object sender, EventArgs e)
        {
            Map_OnZoomUpdate();
        }

        protected double previousZoomLevel;
        void Map_OnZoomUpdateCheck()
        {
            if (Math.Abs(previousZoomLevel - Map.ZoomLevel) > 2)
            {
                previousZoomLevel = Map.ZoomLevel;
                Map_OnZoomUpdate();
            }
        }

        protected void Map_OnZoomUpdate()
        {
            return;
            QueryTracksSpeed();
        }

        protected double GetPointsPadding()
        {
            //return 0.01;
            //return 0.001;
            return 0.0007; // max working
            
            //return 0.0001;
            // 25 - 0.0001;
            // 12 - 0.01
            double zoom = Map.ZoomLevel < 12 ? 12 : Map.ZoomLevel;
            double zoomRef1 = 12, zoomRef2 = 25, pointPaddingRef1 = 0.01, pointPaddingRef2 = 0.0008;
            return (pointPaddingRef2 - pointPaddingRef1) * (zoom - zoomRef1) / (zoomRef2 - zoomRef1) + pointPaddingRef1;
        }

        protected DateTime time = DateTime.Parse("15:00");
            // TODO WTF shoudl work ;x
            //DateTime.Parse((int)hourSlider.Value + ":00");
        protected void QueryTracksSpeed()
        {
            if (trackVelocityGroupManager == null)
            {
                return;
            }
            // TODO based on zoom level count padding
            double pointsPadding = GetPointsPadding();
            // TODO chekc if points already exists
            if (GetTracks(pointsPadding, DateTime.Parse((int)hourSlider.Value + ":00")).Count() == 0)
            {
                trackVelocityGroupManager.AddVelocityGroupQuery(pointsPadding);
            }
        }

        void trackVelocityGroupManager_OnVelocityGroupQueryCompleted(IEnumerable<EstimationTrack> trackVelocityGroups)
        {
            // TODO chekc if points already exists
            foreach (EstimationTrack trackVelocityGroup in trackVelocityGroups)
            {
                trackVelocityGroupList.Add(trackVelocityGroup);
            }
            UpdateVelocityPolyline();
        }

        private IEnumerable<EstimationTrack> GetTracks(double pointsPadding, DateTime time)
        {
            var tracksQuery = from t in trackVelocityGroupList
                              where t.PointsPadding == pointsPadding
                              where t.Time == time
                              select t;
            return tracksQuery;
        }

        private void UpdateVelocityPolyline()
        {
            if (Map == null)
            {
                return;
            }
            lock (Map)
            {
                Map.Children.Clear();
                var pointListQuery = from l in GetTracks(GetPointsPadding(), DateTime.Parse((int)hourSlider.Value + ":00"))
                                     select l.PointList;
                List<EstimationPoint> allPoints = new List<EstimationPoint>();
                foreach (IEnumerable<EstimationPoint> pointList in pointListQuery)
                {
                    EstimationPoint prevLocation = null;
                    foreach (EstimationPoint location in pointList)
                    {
                        if (!mapPositionInitialized)
                        {
                            allPoints.Add(location);
                        }
                        if (prevLocation != null)
                        {
                            LinearGradientBrush linearGradientBrush = new LinearGradientBrush();
                            GradientStop gradientStart = new GradientStop();
                            GradientStop gradientStop = new GradientStop();

                            gradientStart.Offset = 0.0;
                            gradientStop.Offset = 0.5;

                            gradientStart.Color = velocityColorPicker.getColor(prevLocation.Speed);
                            gradientStop.Color = velocityColorPicker.getColor(location.Speed);

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
                }

                var tracksReceivedQuery = from t in trackVelocityGroupList
                                          select t.Name;
                if (allPoints.Count > 0 && !mapPositionInitialized && tracksReceivedQuery.Distinct().Count() == trackList.Count)
                {
                    mapPositionInitialized = true;
                    mapStartPositionAdjuster.SetMapCenterPointAndZoomLevel(allPoints);
                }
            }
        }
        // TODO fix initial map start position
        protected bool mapPositionInitialized = false;

        private void updateVelocityPolylineButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateVelocityPolyline();
        }

        // TODO WTF shoudl work ;x
        //DateTime.Parse((int)hourSlider.Value + ":00");
        int hourSliderPreviousValue;
        private void hourSlider_ValueChangedCheck(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider slider = (Slider)sender;
            if ((int)slider.Value != hourSliderPreviousValue)
            {
                hourSliderPreviousValue = (int)slider.Value;
                hourSlider_ValueChanged(slider);
            }
        }

        protected void hourSlider_ValueChanged(Slider slider)
        {
            // TODO get time from slider
            time = DateTime.Parse((int)slider.Value + ":00");
            UpdateVelocityPolyline();
        }

    }
}
