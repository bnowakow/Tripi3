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
    public abstract class TripService : ITripService, ICrossDomainPolicyResponder
    {
        #region ITripService implementation
        public abstract string LoginUser(string username, string password);

        public abstract int CreateNewTrip(string username, string tripName, string tripDescription);

        public abstract List<Trip> GetTripsForUser(string username);

        public abstract List<Trip> GetAllTrips();

        public abstract List<PositionNode> GetPositionNodesForTrip(int tripID);

        public abstract int AddPositionNode(PositionNode node);

        public virtual void AddManyPositionNodes(IEnumerable<PositionNode> nodes)
        {
            foreach (PositionNode noed in nodes) AddPositionNode(noed);
        }

        public abstract void UpdateTripDescription(int tripID, string tripDescription);

        public abstract void UpdatePositionNodeDescription(int tripID, int nodeNumber, string nodeDescription);
        #endregion

        #region Events
        public static event Action<int, int> DatabaseInsert;
        public static event Action<string> DatabaseQuery;

        protected virtual void OnDatabaseInsert(int tripCount, int positionNodeCount)
        {
            if (DatabaseInsert != null) DatabaseInsert(tripCount, positionNodeCount);
        }

        protected virtual void OnDatabaseQuery(string queryInfo)
        {
            if (DatabaseQuery != null) DatabaseQuery(queryInfo);
        }
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
                                <allow-http-request-headers-from domain=""*"" headers=""SOAPAction"" />
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
