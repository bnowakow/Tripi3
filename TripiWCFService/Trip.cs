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

        public Trip(XElement element)
            : this(element.Attribute("username").Value,
            int.Parse(element.Attribute("id").Value),
            element.Attribute("tripname").Value)
        {
        }
        #endregion

        #region To XElement
        public XElement ToXElement()
        {
            XElement temp = new XElement("Trip");
            temp.SetAttributeValue("username", Username);
            temp.SetAttributeValue("id", ID);
            temp.SetAttributeValue("tripname", TripName);
            return temp;
        }
        #endregion
    }
}
