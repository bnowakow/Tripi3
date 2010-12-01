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
            set { date = value; }
        }

        [DataMember]
        public double Latitude
        {
            get { return latitude; }
            set { latitude = value; }
        }

        [DataMember]
        public double Longitude
        {
            get { return longitude; }
            set { longitude = value; }
        }

        [DataMember]
        public double Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        public override string ToString()
        {
            return "({0};{1}) {2} km/h".F(latitude, longitude, speed);
        }
    }
}
