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

namespace TripiTrafficMap.Tracks
{
    public delegate void QueryTrackVelocityGroupDelegate(IEnumerable<TrackVelocityGroup> trackVelocityGroups);

    public class TrackVelocityGroupManager
    {
        protected IList<Track> trackList;
        protected IList<DateTime> timeList;

        protected IList<TrackVelocityGroup> trackVelocityGroupList;

        public event QueryTrackVelocityGroupDelegate OnVelocityGroupQueryCompleted;

        public TrackVelocityGroupManager(IList<Track> trackList, IList<DateTime> timeList)
        {
            this.trackList = trackList;
            this.timeList = timeList;
            trackVelocityGroupList = new List<TrackVelocityGroup>();
        }

        public void AddVelocityGroupQuery(double pointsPadding) {
            foreach (Track track in trackList)
            {
                foreach (DateTime time in timeList)
                {
                    TrackVelocity trackVelocity = new TrackVelocity(track.GetPoints(pointsPadding), time, pointsPadding, track.Name);
                    trackVelocity.QueryTrackVelocityCompleted += new QueryTrackVelocityDelegate(trackVelocity_QueryTrackVelocityCompleted);
                    trackVelocity.QueryTrackVelocity();
                }
            }
        }

        void trackVelocity_QueryTrackVelocityCompleted(TrackVelocityGroup trackVelocityGroup)
        {
            trackVelocityGroupList.Add(trackVelocityGroup);
            var trafficGroupLeftQuery = from t in trackVelocityGroupList
                                        where t.PointsPadding == trackVelocityGroup.PointsPadding
                                        where t.Name == trackVelocityGroup.Name
                                        select t;
            int count = trafficGroupLeftQuery.Count();
            if (count == timeList.Count)
            {
                if (OnVelocityGroupQueryCompleted != null)
                {
                    OnVelocityGroupQueryCompleted(trafficGroupLeftQuery);
                }
            }
        }

        
    }
}
