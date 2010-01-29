using System;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Collections.Generic;
using System.Text;

namespace Tripi
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class TripiSilverlightWCFService : TripiWCF.Service.ITripService
    {
        private TripiWCF.Service.TripService tripService;

        public TripiSilverlightWCFService()
        {
            tripService = new TripiWCF.Service.TripService();
        }

        #region ITripService Members

        [OperationContract]
        public int CreateNewTrip(string username)
        {
            return tripService.CreateNewTrip(username);
        }

        [OperationContract]
        public List<TripiWCF.Service.Trip> GetTripsForUser(string username)
        {
            return tripService.GetTripsForUser(username);
        }

        [OperationContract]
        public List<TripiWCF.Service.PositionNode> GetPositionNodesForTrip(int tripID)
        {
            return tripService.GetPositionNodesForTrip(tripID);
        }

        [OperationContract]
        public void AddPositionNode(TripiWCF.Service.PositionNode node)
        {
            tripService.AddPositionNode(node);
        }

        #endregion
    }
}
