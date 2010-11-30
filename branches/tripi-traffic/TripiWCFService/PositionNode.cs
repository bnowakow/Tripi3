using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Xml.Linq;
using System.Globalization;

namespace TripiWCF.Service
{
    /// <summary>
    /// Data object holding data from GPS (latitude/longitude/speed), ID of parent trip, creation time and optional description (might be null).
    /// </summary>
    [DataContract]
    public class PositionNode
    {
        #region DataMembers
        [DataMember]
        public int OrdinalNumber { get; set; }
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
        [DataMember]
        public string Description { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Shortened constructor used somewhere in demo code.
        /// </summary>
        /// <param name="lat">Latitude.</param>
        /// <param name="lon">Longitude.</param>
        /// <param name="tripID">Parent trip ID.</param>
        /// <param name="num">Ordinal number.</param>
        public PositionNode(double lat, double lon, int tripID, int num)
            : this(lat, lon, tripID, 3.14, DateTime.Now, null, num)
        {
        }

        /// <summary>
        /// Full constructor, fills all of the fields.
        /// </summary>
        /// <param name="lat">Latitude of GPS reading.</param>
        /// <param name="lon">Longitude of GPS reading.</param>
        /// <param name="tripID">Parent trip ID.</param>
        /// <param name="speed">Speed measured by GPS module.</param>
        /// <param name="creationTime">Time of the GPS reading.</param>
        /// <param name="description">Short optional description of interesting point.</param>
        /// <param name="ordinalNumber">Ordinal number of the point (on a trip) - usually provided by TripService.</param>
        public PositionNode(double lat, double lon, int tripID, double speed, DateTime creationTime, string description, int ordinalNumber)
        {
            Latitude = lat;
            Longitude = lon;
            TripID = tripID;
            Speed = speed;
            CreationTime = creationTime;
            Description = description;
            OrdinalNumber = ordinalNumber;
        }

        /// <summary>
        /// Constructor parsing an XElement from a serialized database. Doesn't really tolerate any errors in XML.
        /// </summary>
        /// <param name="element">XElement which will be torn apart for data.</param>
        public PositionNode(XElement element)
            : this(double.Parse(element.Attribute("latitude").Value),
            double.Parse(element.Attribute("longitude").Value),
            int.Parse(element.Attribute("tripid").Value),
            double.Parse(element.Attribute("speed").Value),
            //DateTime.ParseExact(element.Attribute("time").Value, CultureInfo.CurrentCulture.DateTimeFormat.GetAllDateTimePatterns(), CultureInfo.CurrentCulture, DateTimeStyles.None),
            DateTime.ParseExact(element.Attribute("time").Value, "yyyyMMddHHmmss", CultureInfo.CurrentCulture),
            element.Attribute("description") != null ? element.Attribute("description").Value : null,
            int.Parse(element.Attribute("number").Value))
        //DateTime.ParseExact(element.Attribute("time").Value, "yyyy/MM/ddTHH:mm:ss.fffffzzz", CultureInfo.InvariantCulture))
        //DateTime.FromBinary(long.Parse(element.Attribute("time").Value)))
        {
            /*Latitude = double.Parse(element.Attribute("latitude").Value);
            Longitude = double.Parse(element.Attribute("longitude").Value);
            TripID = int.Parse(element.Attribute("tripid").Value);
            Speed = double.Parse(element.Attribute("speed").Value);
            string strą = element.Attribute("time").Value;
            long lą = long.Parse(strą);
            CreationTime = DateTime.FromBinary(lą);*/
        }
        #endregion

        #region To XElement
        /// <summary>
        /// Method which creates an XML element, holding data for XML-backed database.
        /// </summary>
        /// <returns>Ready XElement, which can be passed to XElement-munching constructor of PositionNode.</returns>
        public XElement ToXElement()
        {
            XElement temp = new XElement("Position");
            temp.SetAttributeValue("number", OrdinalNumber);
            temp.SetAttributeValue("latitude", Latitude);
            temp.SetAttributeValue("longitude", Longitude);
            temp.SetAttributeValue("tripid", TripID);
            temp.SetAttributeValue("speed", Speed);
            //temp.SetAttributeValue("time", CreationTime);
            //temp.SetAttributeValue("time", CreationTime.ToBinary());
            temp.SetAttributeValue("time", CreationTime.ToString("yyyyMMddHHmmss"));
            temp.SetAttributeValue("description", Description);
            return temp;
        }
        #endregion
    }
}
