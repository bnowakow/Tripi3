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
            OnLog("query {0}: ({1}:{2}) #{3}".F(request.Method, query.Name, query.PointsPadding, query.Points.Count));

            Estimation estimation = new Estimation(new RadialEstimationStrategy(), rawPointFile);
            TrafficQueryResult result = new TrafficQueryResult(query.QueryId, new List<EstimationTrack>());
            foreach (DateTime date in query.Dates)
            {
                EstimationTrack estimationTrack = new EstimationTrack(new List<EstimationPoint>(), date, query.PointsPadding, query.Name);
                foreach (RawPoint point in query.Points)
                {
                    EstimationPoint estimationPoint = estimation.CalculateEstimationPoint(point.Latitude, point.Longitude, date);
                    estimationTrack.PointList.Add(estimationPoint);
                }
                result.Tracks.Add(estimationTrack);
            }
            OnLog("response: #" + result.Tracks.Count);

            return result;
        }
    }
}
