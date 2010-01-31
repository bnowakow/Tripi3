using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.IO;
using System.ServiceModel.Web;
using System.Xml.Linq;

namespace TripiWCF.Service
{
    public class TripServiceXml : TripService, ITripService, ICrossDomainPolicyResponder
    {
        #region Private fields
        private static Dictionary<string, string> Users = new Dictionary<string, string>()
        {
            {"Aha", "test"},
            {"Asia", "test"},
            {"Staro", "ble"},
            {"echudzin", "best"}
        };
        #endregion

        #region Constructor
        public TripServiceXml()
        {
        }
        #endregion

        #region ITripService implementation
        public override string LoginUser(string username, string password)
        {
            OnDatabaseQuery("Login attempt: " + username);
            if (Users.ContainsKey(username) && Users[username] == password) return "luz";
            return "";
        }

        public override int CreateNewTrip(string username, string tripName)
        {
            Trip temp = new Trip(username, TripCount, tripName);
            //Trips.Add(temp);

            OnDatabaseInsert(TripCount, PositionNodeCount);
            return temp.ID;
        }

        public override List<Trip> GetAllTrips()
        {
            List<Trip> tripsFound = new List<Trip>();

            try
            {
                XElement traps = XElement.Load(@".\UserTrips.xml", LoadOptions.None);
                foreach (XElement element in traps.Elements()) tripsFound.Add(new Trip(element));
            }
            catch (FileNotFoundException)
            {
                OnDatabaseQuery("No trips created yet!");
            }

            OnDatabaseQuery("Query all trips!");
            return tripsFound;
        }

        public override List<Trip> GetTripsForUser(string username)
        {
            List<Trip> tripsFound = new List<Trip>();
            if (!File.Exists(@".\UserTrips.xml")) File.Create(@".\UserTrips.xml");

            try
            {
                XElement traps = XElement.Load(@".\UserTrips.xml", LoadOptions.None);
                foreach (XElement element in traps.Elements().Where((XElement elem) => elem.Attribute("username").Value == username))
                {
                    tripsFound.Add(new Trip(element));
                }
            }
            catch (FileNotFoundException)
            {
                OnDatabaseQuery("No trips created yet!");
            }

            OnDatabaseQuery("Query user: " + username);
            return tripsFound;
        }

        public override List<PositionNode> GetPositionNodesForTrip(int tripID)
        {
            //IEnumerable<PositionNode> TripNodes = Nodes.Where((PositionNode n) => n.TripID == tripID);

            OnDatabaseQuery("Query trip: " + tripID);
            return null;
        }

        public override void AddPositionNode(PositionNode node)
        {
            //Nodes.Add(node);
            OnDatabaseInsert(TripCount, PositionNodeCount);
        }
        #endregion

        #region Counts
        public int TripCount
        {
            get
            {
                //return Trips.Count;
                return -1;
            }
        }

        public int PositionNodeCount
        {
            get
            {
                //return Nodes.Count;
                return -1;
            }
        }
        #endregion
    }
}
