using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Maps.MapControl;
using System.Collections.Generic;
using TripiTrafficMap.TrafficServiceReference;
using System.ServiceModel;
using System.Linq;

namespace TripiTrafficMap.Tracks
{
    public delegate void QueryTrackVelocityDelegate(TrackVelocityGroup trackVelocityGroup);

    public class TrackVelocity
    {
        protected TrafficServiceClient trafficServiceClient;
        protected IList<Location> points;
        protected IList<TrafficQueryResult> queryList;
        public DateTime Time { get { return time; } }
        protected DateTime time;
        public double PointsPadding { get { return pointsPadding; } }
        protected double pointsPadding;

        public event QueryTrackVelocityDelegate QueryTrackVelocityCompleted;

        public TrackVelocity(IList<Location> points, DateTime time, double pointsPadding)
        {
            this.points = points;
            this.time = time;
            this.pointsPadding = pointsPadding;
            EndpointAddress endpoint = new EndpointAddress("http://127.0.0.1:1337/Eiskonfekt.svc");
            trafficServiceClient = new TrafficServiceClient(new BasicHttpBinding(), endpoint);
            trafficServiceClient.GetEstimationPointCompleted += new EventHandler<GetEstimationPointCompletedEventArgs>(trafficServiceClient_GetEstimationPointCompleted);
            queryList = new List<TrafficQueryResult>();
        }

        public void QueryTrackVelocity()
        {
            int i = 0;
            foreach (Location point in points)
            {
                var query = from q in queryList
                            select q.QueryId;
                TrafficQuery trafficQuery = new TrafficQuery();
                trafficQuery.QueryId = i++;//query.Min();
                trafficQuery.Latitude = point.Latitude;
                trafficQuery.Longitude = point.Longitude;
                trafficQuery.Date = time;
                TrafficQueryResult trafficQueryResult = new TrafficQueryResult();
                trafficQueryResult.QueryId = trafficQuery.QueryId;
                queryList.Add(trafficQueryResult);
                trafficServiceClient.GetEstimationPointAsync(trafficQuery);
            }
        }

        protected void trafficServiceClient_GetEstimationPointCompleted(object sender, GetEstimationPointCompletedEventArgs e)
        {
            var trafficQueryResultQuery = from q in queryList
                        where q.QueryId == e.Result.QueryId
                        select q;
            var trafficQueryResult = trafficQueryResultQuery.First();
            trafficQueryResult.Point = e.Result.Point;
            var pointsLeftQuery = from q in queryList
                                  where q.Point == null
                                  select q;
            var pointsLeft = pointsLeftQuery.Count();
            if (pointsLeft == 0 && QueryTrackVelocityCompleted != null)
            {
                IList<EstimationPoint> velocityPoints = new List<EstimationPoint>();
                foreach (TrafficQueryResult queryResult in queryList)
                {
                    velocityPoints.Add(queryResult.Point);
                }
                if (QueryTrackVelocityCompleted != null)
                {
                    QueryTrackVelocityCompleted(new TrackVelocityGroup(velocityPoints, time, pointsPadding));
                }
            }
        }

    }
}
