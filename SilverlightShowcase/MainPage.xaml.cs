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
	/// <summary>
	/// Silverlight Control containing all trips list, chosen trip description and maps showing trip points.
	/// Control enables to edit trip description, view interesting points and view all trips.
	/// </summary>
    public partial class MainPage : UserControl
    {
		/// <summary>
		/// Address for WCF tripi endpoint with server listening
		/// </summary>
        private string remoteAddress = "http://10.211.55.3:8765/main";
        //private string remoteAddress = "http://joannar.ds.pg.gda.pl:8765/main";
        
		/// <summary>
		/// Silverlight WCF proxy
		/// </summary>
		private TripServiceClient tripiWcfService = null;

		/// <summary>
		/// All trips loaded from server which are displayed in grid
		/// </summary>
        private ObservableCollection<Trip> trips;

		/// <summary>
		/// Currently selected trip which is displayed on map
		/// </summary>
        private Trip trip;

		/// <summary>
		/// Logged user username given by asp in param tag
		/// </summary>
        private String username = "";

		/// <summary>
		/// Parameters from asp given by tag
		/// </summary>
        private IDictionary<String, String> parameters = null;

		/// <summary>
		/// Descriptions of all interesting points represented by pinpoints on map
		/// </summary>
		private IDictionary<String, String> pushpinsDescriptions = new Dictionary<String, String>();
        
		/// <summary>
		/// Is description viewed or edited
		/// </summary>
		private bool descriptionEditing = false;

        public MainPage()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);
        }

		/// <summary>
		/// Additional constructor used when passing parameters from asp tag
		/// </summary>
		/// <param name="p"></param>
        public MainPage(IDictionary<string, string> p)
            : this()
        {
            this.parameters = p;
        }

		/// <summary>
		/// Prepares SilverlightShowcase. Connects to WCF, assign event handler methods.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        public void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
			if (this.parameters.ContainsKey("userName"))
            {
				// User is logged, username provided in asp params
                username = this.parameters["userName"];
            }

            trips = new ObservableCollection<Trip>();
            TripGrid.ItemsSource = trips;
            TripGrid.SelectionChanged += new SelectionChangedEventHandler(TripGrid_SelectionChanged);

            DescriptionStack.MouseEnter += new MouseEventHandler(DescriptionStack_MouseEnter);
            DescriptionStack.MouseLeave += new MouseEventHandler(DescriptionStack_MouseLeave);

            TripDescriptionTextEditButton.Click += new RoutedEventHandler(TripDescriptionTextEditButton_Click);
            TripDescriptionTextSaveButton.Click += new RoutedEventHandler(TripDescriptionTextSaveButton_Click);

			// Create WCF endpoint
            EndpointAddress endpoint = new EndpointAddress(remoteAddress);
			// Create Silverlight WCF proxy
            tripiWcfService = new TripServiceClient(new BasicHttpBinding(), endpoint);
            tripiWcfService.GetPositionNodesForTripCompleted += new EventHandler<GetPositionNodesForTripCompletedEventArgs>(tripiWcfService_GetPositionNodesForTripCompleted);
            tripiWcfService.GetAllTripsCompleted += new EventHandler<GetAllTripsCompletedEventArgs>(tripiWcfService_GetAllTripsCompleted);
            tripiWcfService.GetAllTripsAsync();
        }

		/// <summary>
		/// Saves modyfied trip description after edit, toggles description TextBlock (edit and view) and Buttons (edit, save) visibility.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        void TripDescriptionTextSaveButton_Click(object sender, RoutedEventArgs e)
        {
            descriptionEditing = false;
            TripDescriptionTextEditor.Visibility = Visibility.Collapsed;
            TripDescriptionText.Visibility = Visibility.Visible;
            DescriptionStack_MouseEnter(null, null);

            tripiWcfService.UpdateTripDescriptionCompleted += new EventHandler<System.ComponentModel.AsyncCompletedEventArgs>(tripiWcfService_UpdateTripDescriptionCompleted);
            trip.TripDescription = TripDescriptionTextEditor.Text;
            tripiWcfService.UpdateTripDescriptionAsync(trip.ID, trip.TripDescription);
        }

		/// <summary>
		/// Displays TextBlock to edit trip description, toggles description TextBlock (edit and view) and Buttons (edit, save) visibility.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        void TripDescriptionTextEditButton_Click(object sender, RoutedEventArgs e)
        {
            descriptionEditing = true;
            TripDescriptionTextEditor.Text = TripDescriptionText.Text;
            TripDescriptionTextEditor.Visibility = Visibility.Visible;
            TripDescriptionText.Visibility = Visibility.Collapsed;
            DescriptionStack_MouseEnter(null, null);
        }

		/// <summary>
		/// Callback from WCF function after description update is finished on server.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        void tripiWcfService_UpdateTripDescriptionCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            TripDescriptionText.Text = trip.TripDescription;
        }

		/// <summary>
		/// Toggles description Buttons (edit, save) visibility. 
		/// Hides Buttons when mouse isn't focused on description TextBlock.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        void DescriptionStack_MouseLeave(object sender, MouseEventArgs e)
        {
            TripDescriptionTextEditButton.Visibility = Visibility.Collapsed;
            TripDescriptionTextSaveButton.Visibility = Visibility.Collapsed;
        }

		/// <summary>
		/// Toggles description Buttons (edit, save) visibility when mouse is focused on description TextBlock. 
		/// Displays Buttons only if trip owner equals to logged user. 
		/// Depending on description state (view or edit) toggles Buttons visibility.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        void DescriptionStack_MouseEnter(object sender, MouseEventArgs e)
        {
            if (trip == null || username == null)
            {
                return;
            }
            if (trip.Username.Equals(username))
            {
				// User is owner of the trip
                if (!descriptionEditing)
                {
					// Trip description is in view state
                    TripDescriptionTextSaveButton.Visibility = Visibility.Collapsed;
                    TripDescriptionTextEditButton.Visibility = Visibility.Visible;
                }
                else
                {
					// Trip description is in edit state
                    TripDescriptionTextSaveButton.Visibility = Visibility.Visible;
                    TripDescriptionTextEditButton.Visibility = Visibility.Collapsed;
                }
            }
        }

		/// <summary>
		/// Event hander method for changed trip by changing selection in grid.
		/// Toggles description TextBlock (edit and view) and Buttons (edit, save) visibility.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        void TripGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = (DataGrid)sender;
            trip = (Trip)dg.SelectedItem;
            TripDescriptionText.Text = trip.TripDescription;
            tripiWcfService.GetPositionNodesForTripAsync(trip.ID);


            descriptionEditing = false;
            TripDescriptionTextEditor.Visibility = Visibility.Collapsed;
            TripDescriptionText.Visibility = Visibility.Visible;
            DescriptionStack_MouseLeave(null, null);
        }

		/// <summary>
		/// Callback from WCF function after all trips are downloaded from server.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        void tripiWcfService_GetAllTripsCompleted(object sender, GetAllTripsCompletedEventArgs e)
        {
            foreach (Trip trip in e.Result)
            {
                trips.Add(trip);
            }
            TripGrid.ColumnWidth = DataGridLength.Auto;
        }

		/// <summary>
		/// Callback from WCF function after all points from tip are downloaded from server.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        void tripiWcfService_GetPositionNodesForTripCompleted(object sender, GetPositionNodesForTripCompletedEventArgs e)
        {
            PositionNode[] positionArray = (PositionNode[])e.Result;
            List<PositionNode> positionList = positionArray.ToList();
            drawPolyline(positionList);
        }

		/// <summary>
		/// Draws polyline on map from given point list.
		/// </summary>
		/// <param name="list">List of points which will be drawed on map as a polyline</param>
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
				// Add point to polyline
                Location location = new Location(positionNode.Latitude, positionNode.Longitude);
				locations.Add(location);
                mapPolyline.Locations.Add(location);


                if (positionNode.Description != null && !positionNode.Description.Equals(""))
                {
					// Point is Interesting point and has description
					// Create pushpin with TextBlock containing its description
					Pushpin pushpin = new Pushpin();
                    pushpin.Location = location;
					pushpin.Name = positionNode.OrdinalNumber.ToString();
					pushpinsDescriptions.Add(pushpin.Name, positionNode.Description);
					pushpin.MouseLeftButtonUp += new MouseButtonEventHandler(pushpin_MouseLeftButtonUp);
                    PinLayer.Children.Add(pushpin);
                }
            }
            MapLayer.Children.Add(mapPolyline);

			// Zoom and set center to view whole polyline with 50px margin around
			SetBestMapView(locations, Map, 50);
        }

		/// <summary>
		/// Views TextBlock containing Interesting point description after its pushpin was clicked.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void pushpin_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		{
			Pushpin pushpin = (Pushpin) sender;
			InfoboxDescription.Text = pushpinsDescriptions[pushpin.Name];
			Infobox.Visibility = Visibility.Visible;
		}

		/// <summary>
		/// Hides TextBlock containing Interesting point description after its close sign was clicked.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void CloseInfobox_Click(object sender, RoutedEventArgs e)
        {
            Infobox.Visibility = Visibility.Collapsed;
        }

		/// <summary>
		/// Adjusts map zoom level and map center to show all defined points at the same time preserving constant margin around them.
		/// </summary>
		/// <param name="locations">List of points which should be visible at the same time</param>
		/// <param name="map">Map which will be customized</param>
		/// <param name="buffer">Margin in pixels around points</param>
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
    }
}
