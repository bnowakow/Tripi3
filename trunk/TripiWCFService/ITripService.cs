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
        #region Security, lol
        [OperationContract]
        string LoginUser(string username, string password);
        #endregion

        #region Trip handling
        [OperationContract]
        int CreateNewTrip(string username, string tripName, string tripDescription);

        [OperationContract]
        List<Trip> GetAllTrips();

        [OperationContract]
        List<Trip> GetTripsForUser(string username);

        [OperationContract]
        void UpdateTripDescription(int tripID, string tripDescription);
        #endregion

        #region PositionNode handling
        [OperationContract]
        int AddPositionNode(PositionNode node);

        [OperationContract]
        void AddManyPositionNodes(IEnumerable<PositionNode> nodes);

        [OperationContract]
        List<PositionNode> GetPositionNodesForTrip(int tripID);

        [OperationContract]
        void UpdatePositionNodeDescription(int tripID, int nodeNumber, string nodeDescription);
        #endregion
    }
}
