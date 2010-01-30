using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace TripiWCF.Service
{
    [DataContract]
    public class Trip
    {
        #region DataMembers
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public string TripName { get; set; }
        #endregion

        #region Constructor
        public Trip(string username, int id, string tripName)
        {
            Username = username;
            ID = id;
            TripName = tripName;
        }
        #endregion
    }
}
