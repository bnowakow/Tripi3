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
using System.Xml;
using System.Collections.Generic;
using Microsoft.Maps.MapControl;
using System.Globalization;

namespace TripiTrafficMap.Tracks
{
    public class Track
    {
        protected IList<Location> points;
        public String Name { get { return name; } }
        protected String name;

        public Track(String gpxFilename)
        {
            name = gpxFilename;
            XmlReader reader = XmlReader.Create(@"Tracks/" + name);
            points = new List<Location>();
            while (reader.ReadToFollowing("trkpt"))
            {
                Location point = new Location();
                point.Longitude = Double.Parse(reader.GetAttribute("lon"), System.Globalization.NumberStyles.Any, new NumberFormatInfo());
                point.Latitude = Double.Parse(reader.GetAttribute("lat"), System.Globalization.NumberStyles.Any, new NumberFormatInfo());
                points.Add(point);
            }
            reader.Close();
        }

        public IList<Location> GetPoints(double pointsPadding) {
            if (points.Count == 0)
            {
                return null;
            }
            IList<Location> pointsWithPadding = new List<Location>();
            pointsWithPadding.Add(points[0]);
            for (int i = 1; i < points.Count; )
            {
                Location currentPoint = points[i];
                Location currentPointWithPadding = pointsWithPadding[pointsWithPadding.Count - 1];
                double latDiff = currentPoint.Latitude - currentPointWithPadding.Latitude;
                double lonDiff = currentPoint.Longitude - currentPointWithPadding.Longitude;
                double latAbsDiff = Math.Abs(latDiff);
                double lonAbsDiff = Math.Abs(lonDiff);
                if (latAbsDiff < pointsPadding &&
                    lonAbsDiff < pointsPadding)
                {
                    i++;
                    continue;
                }
                double coef;
                if (latAbsDiff > lonAbsDiff)
                {
                    coef = pointsPadding / latAbsDiff;
                }
                else
                {
                    coef = pointsPadding / lonAbsDiff;
                }
                Location point = new Location();
                point.Latitude = currentPointWithPadding.Latitude + coef * latDiff;
                point.Longitude = currentPointWithPadding.Longitude + coef * lonDiff;
                pointsWithPadding.Add(point);
            }
            return pointsWithPadding;
        }
    }
}
