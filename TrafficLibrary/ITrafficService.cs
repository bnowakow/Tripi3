using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace TrafficLibrary
{
    [ServiceContract]
    public interface ITrafficService
    {
        [OperationContract]
        EstimationPoint GetEstimationPoint(double latitude, double longitude, DateTime date);
    }
}
