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
        string LoginUser(string username, string password);

        [OperationContract]
        int CreateNewTrip(string username, string tripName, string tripDescription);

        [OperationContract]
        List<Trip> GetAllTrips();

        [OperationContract]
        List<Trip> GetTripsForUser(string username);

        [OperationContract]
        List<PositionNode> GetPositionNodesForTrip(int tripID);

        [OperationContract]
        void AddPositionNode(PositionNode node);

        [OperationContract]
        void UpdateTripDescription(int tripID, string tripDescription);

        [OperationContract]
        void UpdatePositionNodeDescription(int tripID, int nodeNumber, string nodeDescription);

    }
}
