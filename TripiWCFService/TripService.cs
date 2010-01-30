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
    public class TripService : ITripService, ICrossDomainPolicyResponder
    {
        #region Private fields
        private static List<Trip> Trips = new List<Trip>();
        private static List<PositionNode> Nodes = new List<PositionNode>();
        private static Dictionary<string, string> Users = new Dictionary<string, string>()
        {
            {"Aha", "test"},
            {"Staro", "ble"},
            {"echudzin", "best"}
        };
        #endregion

        #region Constructor
        public TripService()
        {
            //Trips = new List<Trip>();
            //Nodes = new List<PositionNode>();
        }
        #endregion

        #region ITripService implementation
        public string LoginUser(string username, string password)
        {
            if (username == "Aha" || username == "echudzin") return "luz";
            return "";
        }

        public int CreateNewTrip(string username, string tripName)
        {
            Trip temp = new Trip(username, TripCount, tripName);
            Trips.Add(temp);

            if (OnDatabaseInsert != null) OnDatabaseInsert(TripCount, PositionNodeCount);
            return temp.ID;
        }
       
        public List<Trip> GetTripsForUser(string username)
        {
            IEnumerable<Trip> UserTrips = Trips.Where((Trip t) => t.Username == username);

            if (OnDatabaseQuery != null) OnDatabaseQuery("Query user: " + username);
            return UserTrips.ToList();
        }

        public List<PositionNode> GetPositionNodesForTrip(int tripID)
        {
            IEnumerable<PositionNode> TripNodes = Nodes.Where((PositionNode n) => n.TripID == tripID);

            if (OnDatabaseQuery != null) OnDatabaseQuery("Query trip: " + tripID);
            return TripNodes.ToList();
        }

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

        #region Making Silverlight suck less
        public Stream GetSilverlightPolicy()
        {
            string result = @"<?xml version=""1.0"" encoding=""utf-8""?>
                <access-policy>
                    <cross-domain-access>
                        <policy>
                            <allow-from>
                                <domain uri=""*""/>
                            </allow-from>
                            <grant-to>
                                <resource path=""/"" include-subpaths=""true""/>
                            </grant-to>
                        </policy>
                    </cross-domain-access>
                </access-policy>";
            return StringToStream(result);

        }

        public Stream GetFlashPolicy()
        {
            string result = @"<?xml version=""1.0""?>
                            <!DOCTYPE cross-domain-policy SYSTEM ""http://www.macromedia.com/xml/dtds/cross-domain-policy.dtd"">
                            <cross-domain-policy>
                                <allow-access-from domain=""*"" />
                                <allow-http-request-headers-from-domain=""*"" headers=""SOAPAction"" />
                            </cross-domain-policy>";
            return StringToStream(result);
        }

        private Stream StringToStream(string result)
        {
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/xml";
            return new MemoryStream(Encoding.UTF8.GetBytes(result));
        }
        #endregion
    }
}
