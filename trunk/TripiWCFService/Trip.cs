using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Xml.Linq;

namespace TripiWCF.Service
{
    /// <summary>
    /// Data object, which holds information about trip: who created it, short description and ID, which relates to PositionNodes.
    /// </summary>
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
        [DataMember]
        public string TripDescription { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Standard constructor, filling all fields of Trip.
        /// </summary>
        /// <param name="username">User who created trip.</param>
        /// <param name="id">Trip ID - something similar to primary key here...</param>
        /// <param name="tripName">User-given trip name.</param>
        /// <param name="tripDescription">Short description of the trip.</param>
        public Trip(string username, int id, string tripName, string tripDescription)
        {
            Username = username;
            ID = id;
            TripName = tripName;
            TripDescription = tripDescription;
        }

        /// <summary>
        /// Constructor taking an XElement from XML file, will throw exceptions on missing on unparse'able attributes.
        /// </summary>
        /// <param name="element">XElement to parse.</param>
        public Trip(XElement element)
            : this(element.Attribute("username").Value,
            int.Parse(element.Attribute("id").Value),
            element.Attribute("tripname").Value,
            element.Attribute("tripdesc").Value)
        {
        }
        #endregion

        #region To XElement
        /// <summary>
        /// Method which creates an XML element, holding data for XML-backed database.
        /// </summary>
        /// <returns>Ready XElement, which can be passed to XElement-munching constructor of Trip.</returns>
        public XElement ToXElement()
        {
            XElement temp = new XElement("Trip");
            temp.SetAttributeValue("username", Username);
            temp.SetAttributeValue("id", ID);
            temp.SetAttributeValue("tripname", TripName);
            temp.SetAttributeValue("tripdesc", TripDescription);
            return temp;
        }
        #endregion
    }
}
