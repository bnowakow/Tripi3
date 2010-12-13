using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.Generic;
using Microsoft.Maps.MapControl;
using TripiTrafficMap.Util.Interface;
using TripiTrafficMap.TrafficServiceReference;

namespace TripiTrafficMap.Util
{
    public class MapStartPositionAdjuster : IMapStartPositionAdjuster
    {
        protected Map map;
        protected int pixelBorder;

        public MapStartPositionAdjuster(Map map, int pixelBorder = 10)
        {
            this.map = map;
            this.pixelBorder = pixelBorder;
        }

        public void SetMapCenterPointAndZoomLevel(IList<EstimationPoint> locations)
        {
            this.SetMapCenterPointAndZoomLevel(locations, this.map, this.pixelBorder);
        }

        /// <summary>
        /// Adjusts map zoom level and map center to show all defined points at the same time preserving constant margin around them.
        /// </summary>
        /// <param name="locations">List of points which should be visible at the same time</param>
        /// <param name="map">Map which will be customized</param>
        /// <param name="pixelBorder">Margin in pixels around points</param>
        public void SetMapCenterPointAndZoomLevel(IList<EstimationPoint> locations, Map map, int pixelBorder)
        {
            Location center = new Location();
            double zoomLevel = 0.0;
            
            double maxLat = -85.0;
            double minLat = 85.0;
            double maxLon = -180.0;
            double minLon = 180.0;

           

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
            
            center.Latitude = (maxLat + minLat) / 2.0;
            center.Longitude = (maxLon + minLon) / 2.0;
            
            double zoom1 = 0.0, zoom2 = 0.0;

            //Determine the best zoom level based on the map scale and bounding coordinate information
            if (maxLon != minLon && maxLat != minLat)
            {
                //best zoom level based on map width
                zoom1 = Math.Log(360.0 / 256.0 * (map.ViewportSize.Width - 2.0 * pixelBorder) / (maxLon - minLon)) / Math.Log(2.0);
                //best zoom level based on map height
                zoom2 = Math.Log(180.0 / 256.0 * (map.ViewportSize.Height - 2.0 * pixelBorder) / (maxLat - minLat)) / Math.Log(2.0);
            }
            
            //use the most zoomed out of the two zoom levels
            zoomLevel = (zoom1 < zoom2) ? zoom1 : zoom2;
            
            map.Center = center;
            map.ZoomLevel = zoomLevel;
        }
    }
}
