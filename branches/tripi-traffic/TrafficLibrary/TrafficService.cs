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

        public override TrafficQueryResult GetEstimationPoint(TrafficQuery query)
        {
            HttpRequestMessageProperty request = System.ServiceModel.OperationContext.Current.IncomingMessageProperties["httpRequest"] as HttpRequestMessageProperty;
            OnLog("{0}: ({1};{2}) @ {3}".F(request.Method, query.Latitude, query.Longitude, query.Date));

            Estimation estimation = new Estimation(new RadialEstimationStrategy(), rawPointFile);
            EstimationPoint point = estimation.CalculateEstimationPoint(query.Latitude, query.Longitude, query.Date);
            OnLog(point.ToString());

            TrafficQueryResult result = new TrafficQueryResult(query.QueryId, point);
            return result;
        }
    }
}
