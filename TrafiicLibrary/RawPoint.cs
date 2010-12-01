using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrafficLibrary
{
    public class RawPoint
    {
        private DateTime date;
        private double latitude;
        private double longitude;
        private double speed;
        private String id; 

        public RawPoint(DateTime date, double latitude, double longitude, double speed)
        {
            this.date = date;
            this.latitude = latitude;
            this.longitude = longitude;
            this.speed = speed;
        }

        public DateTime Date
        {
            get { return date; }
            private set { date = value; }
        }

        public double Latitude
        {
            get { return latitude; }
            private set { latitude = value; }
        }

        public double Longitude
        {
            get { return longitude; }
            private set { longitude = value; }
        }

        public double Speed
        {
            get { return speed; }
            private set { speed = value; }
        }

        public String Id
        {
            get { return id; }
            private set { id = value; }
        }
    }
}
