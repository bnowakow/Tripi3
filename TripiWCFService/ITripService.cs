using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace TripiWCF.Service
{
    [ServiceContract]
    public interface ITripService
    {
        [OperationContract]
        int CreateNewTrip(string username, string tripName);

        [OperationContract]
        List<Trip> GetTripsForUser(string username);

        [OperationContract]
        List<PositionNode> GetPositionNodesForTrip(int tripID);

        [OperationContract]
        void AddPositionNode(PositionNode node);
    }
}
