using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Xml.Linq;

namespace TripiWCF.Service
{
    [DataContract]
    public class PositionNode
    {
        #region DataMembers
        [DataMember]
        public double Latitude { get; set; }
        [DataMember]
        public double Longitude { get; set; }
        [DataMember]
        public double Speed { get; set; }
        [DataMember]
        public int TripID { get; set; }
        [DataMember]
        public DateTime CreationTime { get; set; }
        #endregion

        #region Constructor
        public PositionNode(double lat, double lon, int tripID)
            : this(lat, lon, tripID, 3.14, DateTime.Now)
        {
        }

        public PositionNode(double lat, double lon, int tripID, double speed, DateTime creationTime)
        {
            Latitude = lat;
            Longitude = lon;
            TripID = tripID;
            Speed = speed;
            CreationTime = creationTime;
        }

        public PositionNode(XElement element)
            : this(double.Parse(element.Attribute("latitude").Value),
            double.Parse(element.Attribute("longitude").Value),
            int.Parse(element.Attribute("tripid").Value),
            double.Parse(element.Attribute("speed").Value),
            DateTime.Parse(element.Attribute("time").Value))
        {
        }
        #endregion
    }
}
