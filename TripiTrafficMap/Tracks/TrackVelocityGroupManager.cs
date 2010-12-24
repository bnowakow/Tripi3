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
using System.Collections.Generic;
using Microsoft.Maps.MapControl;
using System.Linq;
using TripiTrafficMap.TrafficServiceReference;
using System.ServiceModel;
using System.Collections;
using System.Collections.ObjectModel;

namespace TripiTrafficMap.Tracks
{
    public delegate void QueryTrackVelocityGroupDelegate(IEnumerable<EstimationTrack> trackVelocityGroups);

    public class TrackVelocityGroupManager
    {
        protected List<Track> trackList;
        protected List<DateTime> timeList;

        protected List<EstimationTrack> trackVelocityGroupList;
        protected TrafficServiceClient trafficServiceClient;
        protected int i = 0;

        public event QueryTrackVelocityGroupDelegate OnVelocityGroupQueryCompleted;

        public TrackVelocityGroupManager(List<Track> trackList, List<DateTime> timeList)
        {
            this.trackList = trackList;
            this.timeList = timeList;
            trackVelocityGroupList = new List<EstimationTrack>();
            EndpointAddress endpoint = new EndpointAddress("http://127.0.0.1:1337/Eiskonfekt.svc");
            BasicHttpBinding binding = new BasicHttpBinding();
            binding.MaxReceivedMessageSize = 2147483647;
            binding.MaxBufferSize = 2147483647;
            trafficServiceClient = new TrafficServiceClient(binding, endpoint);
            trafficServiceClient.GetEstimationPointCompleted += new EventHandler<GetEstimationPointCompletedEventArgs>(trafficServiceClient_GetEstimationPointCompleted);
        }

        public void AddVelocityGroupQuery(double pointsPadding)
        {
            foreach (Track track in trackList)
            {
                TrafficQuery trafficQuery = new TrafficQuery();
                trafficQuery.QueryId = i++;
                trafficQuery.Points = track.GetPoints(pointsPadding);
                trafficQuery.Dates = timeList;
                trafficQuery.PointsPadding = pointsPadding;
                trafficQuery.Name = track.Name;
                trafficServiceClient.GetEstimationPointAsync(trafficQuery);
            }
        }

        void trafficServiceClient_GetEstimationPointCompleted(object sender, GetEstimationPointCompletedEventArgs e)
        {
            foreach (EstimationTrack estimationTrack in e.Result.Tracks)
            {
                var selectedTrack = from t in trackList
                                    where t.Name == estimationTrack.Name
                                    select t;
                int i = 0;
                var originalPoints = selectedTrack.First().GetPoints(estimationTrack.PointsPadding);
                foreach (EstimationPoint estimationPoint in estimationTrack.PointList)
                {
                    estimationPoint.Latitude = originalPoints[i].Latitude;
                    estimationPoint.Longitude = originalPoints[i].Longitude;
                    i++;
                }
            }

            if (OnVelocityGroupQueryCompleted != null)
            {
                OnVelocityGroupQueryCompleted(e.Result.Tracks);
            }
        }
    }
}
