using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace TrafficLibrary
{
    [DataContract]
    public class EstimationPoint
    {
        protected DateTime date;
        protected double latitude;
        protected double longitude;
        protected double speed;

        public EstimationPoint(DateTime date, double latitude, double longitude, double speed)
        {
            this.date = date;
            this.latitude = latitude;
            this.longitude = longitude;
            this.speed = speed;
        }

        [DataMember]
        public DateTime Date
        {
            get { return date; }
            private set { date = value; }
        }

        [DataMember]
        public double Latitude
        {
            get { return latitude; }
            private set { latitude = value; }
        }

        [DataMember]
        public double Longitude
        {
            get { return longitude; }
            private set { longitude = value; }
        }

        [DataMember]
        public double Speed
        {
            get { return speed; }
            private set { speed = value; }
        } 
    }
}
