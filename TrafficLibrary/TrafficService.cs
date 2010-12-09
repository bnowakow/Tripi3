using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ServiceModel.Channels;

namespace TrafficLibrary
{
    public class TrafficService : TrafficServiceBase
    {
        private const string rawPointFile = "_all.xml";

        public override EstimationPoint GetEstimationPoint(double latitude, double longitude, DateTime date)
        {
            HttpRequestMessageProperty request = System.ServiceModel.OperationContext.Current.IncomingMessageProperties["httpRequest"] as HttpRequestMessageProperty;
            OnLog("{0}: ({1};{2}) @ {3}".F(request.Method, latitude, longitude, date));

            Estimation estimation = new Estimation(new RadialEstimationStrategy(), rawPointFile);
            EstimationPoint point = estimation.CalculateEstimationPoint(latitude, longitude, date);
            OnLog(point.ToString());
            return point;
        }
    }
}
