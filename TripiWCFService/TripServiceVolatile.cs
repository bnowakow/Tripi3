using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.IO;
using System.ServiceModel.Web;

namespace TripiWCF.Service
{
    public class TripServiceVolatile : TripService, ITripService, ICrossDomainPolicyResponder
    {
        #region Private fields
        private static List<Trip> Trips = new List<Trip>();
        private static List<PositionNode> Nodes = new List<PositionNode>();
        private static Dictionary<string, string> Users = new Dictionary<string, string>()
        {
            {"Aha", "test"},
            {"Asia", "test"},
            {"Staro", "ble"},
            {"echudzin", "best"}
        };
        #endregion

        #region Constructor
        public TripServiceVolatile()
        {
            //Trips = new List<Trip>();
            //Nodes = new List<PositionNode>();
        }
        #endregion

        #region ITripService implementation
        public override string LoginUser(string username, string password)
        {
            OnDatabaseQuery("Login attempt: " + username);
            if (Users.ContainsKey(username) && Users[username] == password) return "luz";
            return "";
        }

        public override List<Trip> GetAllTrips()
        {
            OnDatabaseQuery("Query all trips!");

            return Trips;
        }

        public override int CreateNewTrip(string username, string tripName)
        {
            Trip temp = new Trip(username, TripCount, tripName);
            Trips.Add(temp);

            OnDatabaseInsert(TripCount, PositionNodeCount);
            return temp.ID;
        }

        public override List<Trip> GetTripsForUser(string username)
        {
            IEnumerable<Trip> UserTrips = Trips.Where((Trip t) => t.Username == username);

            OnDatabaseQuery("Query user: " + username);
            return UserTrips.ToList();
        }

        public override List<PositionNode> GetPositionNodesForTrip(int tripID)
        {
            IEnumerable<PositionNode> TripNodes = Nodes.Where((PositionNode n) => n.TripID == tripID);

            OnDatabaseQuery("Query trip: " + tripID);
            return TripNodes.ToList();
        }

        public override void AddPositionNode(PositionNode node)
        {
            Nodes.Add(node);
            OnDatabaseInsert(TripCount, PositionNodeCount);
        }
        #endregion

        #region Counts
        public int TripCount
        {
            get
            {
                return Trips.Count;
            }
        }

        public int PositionNodeCount
        {
            get
            {
                return Nodes.Count;
            }
        }
        #endregion
    }
}
