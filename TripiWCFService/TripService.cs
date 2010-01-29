using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace TripiWCF.Service
{
    public class TripService : ITripService
    {
        #region Private fields
        protected static List<Trip> Trips = new List<Trip>();
        protected static List<PositionNode> Nodes = new List<PositionNode>();
        #endregion

        #region Constructor
        public TripService()
        {
            //Trips = new List<Trip>();
            //Nodes = new List<PositionNode>();
        }
        #endregion

        #region ITripService implementation
        //[OperationContract]
        public int CreateNewTrip(string username)
        {
            Trip temp = new Trip(username, TripCount);
            Trips.Add(temp);

            if (OnDatabaseInsert != null) OnDatabaseInsert(TripCount, PositionNodeCount);
            return temp.ID;
        }
       
        //[OperationContract]
        public List<Trip> GetTripsForUser(string username)
        {
            IEnumerable<Trip> UserTrips = Trips.Where((Trip t) => t.Username == username);

            if (OnDatabaseQuery != null) OnDatabaseQuery("Query user: " + username);
            return UserTrips.ToList();
        }

        //[OperationContract]
        public List<PositionNode> GetPositionNodesForTrip(int tripID)
        {
            IEnumerable<PositionNode> TripNodes = Nodes.Where((PositionNode n) => n.TripID == tripID);

            if (OnDatabaseQuery != null) OnDatabaseQuery("Query trip: " + tripID);
            return TripNodes.ToList();
        }

        //[OperationContract]
        public void AddPositionNode(PositionNode node)
        {
            Nodes.Add(node);
            if (OnDatabaseInsert != null) OnDatabaseInsert(TripCount, PositionNodeCount);
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

        #region Events
        public static event Action<int, int> OnDatabaseInsert;
        public static event Action<string> OnDatabaseQuery;
        #endregion
    }
}
