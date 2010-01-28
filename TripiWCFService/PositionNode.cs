using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ServiceModel;

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
        public int TripID { get; set; }
        [DataMember]
        public DateTime CreationTime { get; set; }
        #endregion

        #region Constructor
        public PositionNode(double lat, double lon, int tripID)
        {
            Latitude = lat;
            Longitude = lon;
            TripID = tripID;
            CreationTime = DateTime.Now;
        }
        #endregion
    }
}
