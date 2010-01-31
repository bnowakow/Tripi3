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
using System.Collections.ObjectModel;
using TripiWCF.Service;

namespace SilverlightShowcase
{
    public partial class MainPage : UserControl
    {
        //private string remoteAddress = "http://10.211.55.3:8765/main";
        private string remoteAddress = "http://joannar.ds.pg.gda.pl:8765/main";
        private TripServiceClient tripiWcfService = null;
        private ObservableCollection<Trip> trips;

        public MainPage()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);
        }

        public void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            trips = new ObservableCollection<Trip>();
            TripGrid.ItemsSource = trips;
            TripGrid.SelectionChanged += new SelectionChangedEventHandler(TripGrid_SelectionChanged);

            EndpointAddress endpoint = new EndpointAddress(remoteAddress);
            tripiWcfService = new TripServiceClient(new BasicHttpBinding(), endpoint);
            tripiWcfService.GetPositionNodesForTripCompleted += new EventHandler<GetPositionNodesForTripCompletedEventArgs>(tripiWcfService_GetPositionNodesForTripCompleted);
            tripiWcfService.GetAllTripsCompleted += new EventHandler<GetAllTripsCompletedEventArgs>(tripiWcfService_GetAllTripsCompleted);

            tripiWcfService.GetAllTripsAsync();
        }

        void TripGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = (DataGrid)sender;
            Trip trip = (Trip)dg.SelectedItem;
            tripiWcfService.GetPositionNodesForTripAsync(trip.ID);
        }

        void tripiWcfService_GetAllTripsCompleted(object sender, GetAllTripsCompletedEventArgs e)
        {
            foreach (Trip trip in e.Result)
            {
                trips.Add(trip);
            }
            TripGrid.ColumnWidth = DataGridLength.Auto;
        }

        void tripiWcfService_GetPositionNodesForTripCompleted(object sender, GetPositionNodesForTripCompletedEventArgs e)
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
            MapLayer.Children.Clear();
            if (list.Count == 0)
            {
                MapStatusText.Text = "Wycieczka nie posiada punktów";
                MapStatus.Visibility = Visibility.Visible;
                return;
            }
            MapStatus.Visibility = Visibility.Collapsed;

            MapPolyline mapPolyline = new MapPolyline();
            mapPolyline.Fill = new SolidColorBrush(Colors.Red);
            mapPolyline.Stroke = new SolidColorBrush(Colors.Yellow);
            mapPolyline.StrokeThickness = 8;
            mapPolyline.Opacity = 0.7;
            mapPolyline.Locations = new LocationCollection();


            Location center = new Location();
            foreach (Location location in list)
            {
                center.Latitude += location.Latitude / list.Count;
                center.Longitude += location.Longitude / list.Count;
                mapPolyline.Locations.Add(location);
            }
            MapLayer.Children.Add(mapPolyline);

            Map.Center = center;
            Map.ZoomLevel = 12;
        }

        #region drawMaratonSierpniowy
        public void drawMaratonSierpniowy()
        {
            List<Location> tmp = new List<Location>();
            tmp.Add(new Location(54.36262680, 18.64116440));
            tmp.Add(new Location(54.36188890, 18.64238260));
            tmp.Add(new Location(54.36138260, 18.64289760));
            tmp.Add(new Location(54.35966960, 18.64435670));
            tmp.Add(new Location(54.35809420, 18.64615910));
            tmp.Add(new Location(54.35810980, 18.64656460));
            tmp.Add(new Location(54.35817860, 18.64688110));
            tmp.Add(new Location(54.35978220, 18.64802370));
            tmp.Add(new Location(54.36008850, 18.64802910));
            tmp.Add(new Location(54.36111060, 18.64696150));
            tmp.Add(new Location(54.36150450, 18.64655390));
            tmp.Add(new Location(54.36179200, 18.64614080));
            tmp.Add(new Location(54.36209830, 18.64545410));
            tmp.Add(new Location(54.36258280, 18.64456370));
            tmp.Add(new Location(54.36322980, 18.64411840));
            tmp.Add(new Location(54.36381430, 18.64366780));
            tmp.Add(new Location(54.36454250, 18.64281490));
            tmp.Add(new Location(54.36565520, 18.64142010));
            tmp.Add(new Location(54.36683030, 18.63989660));
            tmp.Add(new Location(54.36845540, 18.63796010));
            tmp.Add(new Location(54.36966790, 18.63642050));
            tmp.Add(new Location(54.37109920, 18.63460730));
            tmp.Add(new Location(54.37245540, 18.63297110));
            tmp.Add(new Location(54.37346470, 18.63148520));
            tmp.Add(new Location(54.37442710, 18.63013340));
            tmp.Add(new Location(54.37491770, 18.62990810));
            tmp.Add(new Location(54.37544580, 18.62988120));
            tmp.Add(new Location(54.37599260, 18.63016020));
            tmp.Add(new Location(54.37638940, 18.63049820));
            tmp.Add(new Location(54.37718930, 18.63119550));
            tmp.Add(new Location(54.37777350, 18.63173200));
            tmp.Add(new Location(54.37838900, 18.63258490));
            tmp.Add(new Location(54.37926390, 18.63386700));
            tmp.Add(new Location(54.38052300, 18.63574460));
            tmp.Add(new Location(54.38116970, 18.63665650));
            tmp.Add(new Location(54.38175390, 18.63748800));
            tmp.Add(new Location(54.38266920, 18.63882370));
            tmp.Add(new Location(54.38373770, 18.64041700));
            tmp.Add(new Location(54.38417190, 18.64109820));
            tmp.Add(new Location(54.38452490, 18.64184930));
            tmp.Add(new Location(54.38512160, 18.64330840));
            tmp.Add(new Location(54.38589630, 18.64511080));
            tmp.Add(new Location(54.38643050, 18.64637150));
            tmp.Add(new Location(54.38698960, 18.64761060));
            tmp.Add(new Location(54.38806420, 18.65015870));
            tmp.Add(new Location(54.38857640, 18.65138720));
            tmp.Add(new Location(54.38902620, 18.65250840));
            tmp.Add(new Location(54.38945420, 18.65355980));
            tmp.Add(new Location(54.38964470, 18.65390850));
            tmp.Add(new Location(54.38994770, 18.65446640));
            tmp.Add(new Location(54.39035370, 18.65502960));
            tmp.Add(new Location(54.39101590, 18.65594160));
            tmp.Add(new Location(54.39151880, 18.65662820));
            tmp.Add(new Location(54.39211530, 18.65737920));
            tmp.Add(new Location(54.39272750, 18.65828050));
            tmp.Add(new Location(54.39316790, 18.65890810));
            tmp.Add(new Location(54.39388620, 18.65997560));
            tmp.Add(new Location(54.39443590, 18.66073740));
            tmp.Add(new Location(54.39501680, 18.66146160));
            tmp.Add(new Location(54.39574450, 18.66245400));
            tmp.Add(new Location(54.39639410, 18.66334980));
            tmp.Add(new Location(54.39730910, 18.66460510));
            tmp.Add(new Location(54.39815230, 18.66571560));
            tmp.Add(new Location(54.39846150, 18.66534540));
            tmp.Add(new Location(54.39908920, 18.66425640));
            tmp.Add(new Location(54.39965750, 18.66320500));
            tmp.Add(new Location(54.40041950, 18.66151520));
            tmp.Add(new Location(54.40108780, 18.65992730));
            tmp.Add(new Location(54.40187470, 18.65813560));
            tmp.Add(new Location(54.40272400, 18.65617230));
            tmp.Add(new Location(54.40336100, 18.65469170));
            tmp.Add(new Location(54.40418220, 18.65286780));
            tmp.Add(new Location(54.40404480, 18.65177660));
            tmp.Add(new Location(54.40387000, 18.65034960));
            tmp.Add(new Location(54.40390120, 18.64948060));
            tmp.Add(new Location(54.40407600, 18.64856860));
            tmp.Add(new Location(54.40437580, 18.64786050));
            tmp.Add(new Location(54.40515640, 18.64674470));
            tmp.Add(new Location(54.40562470, 18.64602590));
            tmp.Add(new Location(54.40616800, 18.64415910));
            tmp.Add(new Location(54.40717960, 18.64035040));
            tmp.Add(new Location(54.40721710, 18.63957790));
            tmp.Add(new Location(54.40701730, 18.63835480));
            tmp.Add(new Location(54.40663640, 18.63771110));
            tmp.Add(new Location(54.40605560, 18.63669180));
            tmp.Add(new Location(54.40531250, 18.63557600));
            tmp.Add(new Location(54.40428840, 18.63406330));
            tmp.Add(new Location(54.40305810, 18.63208910));
            tmp.Add(new Location(54.40182160, 18.63027600));
            tmp.Add(new Location(54.40018530, 18.62759380));
            tmp.Add(new Location(54.39990420, 18.62702510));
            tmp.Add(new Location(54.40264590, 18.62216940));
            tmp.Add(new Location(54.40544360, 18.61890790));
            tmp.Add(new Location(54.40764170, 18.61513130));
            tmp.Add(new Location(54.40824120, 18.61083980));
            tmp.Add(new Location(54.41023930, 18.60620490));
            tmp.Add(new Location(54.41083870, 18.60397330));
            tmp.Add(new Location(54.41283670, 18.60242840));
            tmp.Add(new Location(54.41453490, 18.60054010));
            tmp.Add(new Location(54.41413530, 18.59745020));
            tmp.Add(new Location(54.41613310, 18.59642020));
            tmp.Add(new Location(54.41763140, 18.59401700));
            tmp.Add(new Location(54.41633290, 18.58697890));
            tmp.Add(new Location(54.41323630, 18.58732220));
            tmp.Add(new Location(54.40744190, 18.58886710));
            tmp.Add(new Location(54.40484410, 18.59006880));
            tmp.Add(new Location(54.40244610, 18.59161370));
            tmp.Add(new Location(54.39994800, 18.59255790));
            tmp.Add(new Location(54.39834910, 18.59478950));
            tmp.Add(new Location(54.39425170, 18.60139840));
            tmp.Add(new Location(54.39115330, 18.60654830));
            tmp.Add(new Location(54.38920430, 18.60835070));
            tmp.Add(new Location(54.38285670, 18.61478800));
            tmp.Add(new Location(54.38295670, 18.61624710));
            tmp.Add(new Location(54.38305660, 18.62174030));
            tmp.Add(new Location(54.38045730, 18.62174030));
            tmp.Add(new Location(54.37735800, 18.62319940));
            tmp.Add(new Location(54.37565820, 18.62371440));
            tmp.Add(new Location(54.37465830, 18.62397190));
            tmp.Add(new Location(54.37335850, 18.62525930));
            tmp.Add(new Location(54.37235850, 18.62440100));
            tmp.Add(new Location(54.37112110, 18.62692410));
            tmp.Add(new Location(54.36757100, 18.63280350));
            tmp.Add(new Location(54.36343300, 18.63986310));
            tmp.Add(new Location(54.36318140, 18.64094720));
            drawPolyline(tmp);
        }
        #endregion
    }
}
