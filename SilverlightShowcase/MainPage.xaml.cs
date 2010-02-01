﻿using System;
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
        private string remoteAddress = "http://10.211.55.3:8765/main";
        //private string remoteAddress = "http://joannar.ds.pg.gda.pl:8765/main";
        private TripServiceClient tripiWcfService = null;
        private ObservableCollection<Trip> trips;
        private Trip trip;
        private String username = "";
        private IDictionary<String, String> parameters = null;
		private IDictionary<String, String> pushpinsDescriptions = new Dictionary<String, String>();
        private bool editing = false;

        public MainPage()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);
        }

        public MainPage(IDictionary<string, string> p)
            : this()
        {
            this.parameters = p;
        }

        public void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
			if (this.parameters.ContainsKey("userName"))
            {
                username = this.parameters["userName"];
            }

            trips = new ObservableCollection<Trip>();
            TripGrid.ItemsSource = trips;
            TripGrid.SelectionChanged += new SelectionChangedEventHandler(TripGrid_SelectionChanged);

            DescriptionStack.MouseEnter += new MouseEventHandler(DescriptionStack_MouseEnter);
            DescriptionStack.MouseLeave += new MouseEventHandler(DescriptionStack_MouseLeave);

            TripDescriptionTextEditButton.Click += new RoutedEventHandler(TripDescriptionTextEditButton_Click);
            TripDescriptionTextSaveButton.Click += new RoutedEventHandler(TripDescriptionTextSaveButton_Click);

            EndpointAddress endpoint = new EndpointAddress(remoteAddress);
            tripiWcfService = new TripServiceClient(new BasicHttpBinding(), endpoint);
            tripiWcfService.GetPositionNodesForTripCompleted += new EventHandler<GetPositionNodesForTripCompletedEventArgs>(tripiWcfService_GetPositionNodesForTripCompleted);
            tripiWcfService.GetAllTripsCompleted += new EventHandler<GetAllTripsCompletedEventArgs>(tripiWcfService_GetAllTripsCompleted);
            tripiWcfService.GetAllTripsAsync();
        }

        void TripDescriptionTextSaveButton_Click(object sender, RoutedEventArgs e)
        {
            editing = false;
            TripDescriptionTextEditor.Visibility = Visibility.Collapsed;
            TripDescriptionText.Visibility = Visibility.Visible;
            DescriptionStack_MouseEnter(null, null);

            tripiWcfService.UpdateTripDescriptionCompleted += new EventHandler<System.ComponentModel.AsyncCompletedEventArgs>(tripiWcfService_UpdateTripDescriptionCompleted);
            trip.TripDescription = TripDescriptionTextEditor.Text;
            tripiWcfService.UpdateTripDescriptionAsync(trip.ID, trip.TripDescription);
        }

        void TripDescriptionTextEditButton_Click(object sender, RoutedEventArgs e)
        {
            editing = true;
            TripDescriptionTextEditor.Text = TripDescriptionText.Text;
            TripDescriptionTextEditor.Visibility = Visibility.Visible;
            TripDescriptionText.Visibility = Visibility.Collapsed;
            DescriptionStack_MouseEnter(null, null);
        }

        void tripiWcfService_UpdateTripDescriptionCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            TripDescriptionText.Text = trip.TripDescription;
        }

        void DescriptionStack_MouseLeave(object sender, MouseEventArgs e)
        {
            TripDescriptionTextEditButton.Visibility = Visibility.Collapsed;
            TripDescriptionTextSaveButton.Visibility = Visibility.Collapsed;
        }

        void DescriptionStack_MouseEnter(object sender, MouseEventArgs e)
        {
            if (trip == null || username == null)
            {
                return;
            }
            if (trip.Username.Equals(username))
            {
                if (!editing)
                {
                    TripDescriptionTextSaveButton.Visibility = Visibility.Collapsed;
                    TripDescriptionTextEditButton.Visibility = Visibility.Visible;
                }
                else
                {
                    TripDescriptionTextSaveButton.Visibility = Visibility.Visible;
                    TripDescriptionTextEditButton.Visibility = Visibility.Collapsed;
                }
            }
        }


        void TripGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = (DataGrid)sender;
            trip = (Trip)dg.SelectedItem;
            TripDescriptionText.Text = trip.TripDescription;
            tripiWcfService.GetPositionNodesForTripAsync(trip.ID);


            editing = false;
            TripDescriptionTextEditor.Visibility = Visibility.Collapsed;
            TripDescriptionText.Visibility = Visibility.Visible;
            DescriptionStack_MouseLeave(null, null);
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
            PositionNode[] positionArray = (PositionNode[])e.Result;
            List<PositionNode> positionList = positionArray.ToList();
            drawPolyline(positionList);
        }


        private void drawPolyline(List<PositionNode> list)
        {
			Infobox.Visibility = Visibility.Collapsed;
            MapLayer.Children.Clear();
			PinLayer.Children.Clear();
            if (list.Count == 0)
            {
                MapStatusText.Text = "Trip does not have any points";
                MapStatus.Visibility = Visibility.Visible;
                return;
            }
            MapStatus.Visibility = Visibility.Collapsed;

            MapPolyline mapPolyline = new MapPolyline();
            //mapPolyline.Fill = new SolidColorBrush(Colors.Red);
            mapPolyline.Stroke = new SolidColorBrush(Colors.Yellow);
            mapPolyline.StrokeThickness = 8;
            mapPolyline.Opacity = 0.7;
            mapPolyline.Locations = new LocationCollection();


            pushpinsDescriptions.Clear();
			IList<Location> locations = new List<Location>();
            foreach (PositionNode positionNode in list)
            {
                Location location = new Location(positionNode.Latitude, positionNode.Longitude);
				locations.Add(location);
                mapPolyline.Locations.Add(location);


                if (positionNode.Description != null && !positionNode.Description.Equals(""))
                {
					Pushpin pushpin = new Pushpin();
                    pushpin.Location = location;
					pushpin.Name = positionNode.OrdinalNumber.ToString();
					pushpinsDescriptions.Add(pushpin.Name, positionNode.Description);
					pushpin.MouseLeftButtonUp += new MouseButtonEventHandler(pushpin_MouseLeftButtonUp);
                    PinLayer.Children.Add(pushpin);
                }
            }
            MapLayer.Children.Add(mapPolyline);

			SetBestMapView(locations, Map, 50);
        }

		void pushpin_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		{
			Pushpin pushpin = (Pushpin) sender;
			InfoboxDescription.Text = pushpinsDescriptions[pushpin.Name];
			Infobox.Visibility = Visibility.Visible;
		}

        private void CloseInfobox_Click(object sender, RoutedEventArgs e)
        {
            Infobox.Visibility = Visibility.Collapsed;
        }

		public void SetBestMapView(IList<Location> locations, Map map, int buffer)
		{
			Location center = new Location();
			double zoomLevel = 0;

			double maxLat = -85;
			double minLat = 85;
			double maxLon = -180;
			double minLon = 180;

			//calculate bounding rectangle
			for (int i = 0; i < locations.Count; i++)
			{
				if (locations[i].Latitude > maxLat)
				{
					maxLat = locations[i].Latitude;
				}

				if (locations[i].Latitude < minLat)
				{
					minLat = locations[i].Latitude;
				}

				if (locations[i].Longitude > maxLon)
				{
					maxLon = locations[i].Longitude;
				}

				if (locations[i].Longitude < minLon)
				{
					minLon = locations[i].Longitude;
				}
			}

			center.Latitude = (maxLat + minLat) / 2;
			center.Longitude = (maxLon + minLon) / 2;

			double zoom1 = 0, zoom2 = 0;

			//Determine the best zoom level based on the map scale and bounding coordinate information
			if (maxLon != minLon && maxLat != minLat)
			{
				//best zoom level based on map width
				zoom1 = Math.Log(360.0 / 256.0 * (map.ActualWidth - 2 * buffer) / (maxLon - minLon)) / Math.Log(2);
				//best zoom level based on map height
				zoom2 = Math.Log(180.0 / 256.0 * (map.ActualHeight - 2 * buffer) / (maxLat - minLat)) / Math.Log(2);
			}

			//use the most zoomed out of the two zoom levels
			zoomLevel = (zoom1 < zoom2) ? zoom1 : zoom2;

			map.Center = center;
			map.ZoomLevel = zoomLevel;			
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

			foreach (Location location in tmp)
			{
				PositionNode pn = new PositionNode();
				pn.Latitude = location.Latitude;
				pn.Longitude = location.Longitude;
				pn.TripID = 2;
				tripiWcfService.AddPositionNodeAsync(pn);
			}
			
			//drawPolyline(tmp);
        }
        #endregion
    }
}
