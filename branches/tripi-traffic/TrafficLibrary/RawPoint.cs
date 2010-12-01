using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrafficLibrary
{
    public class RawPoint : EstimationPoint
    {
        protected String id; 

        public RawPoint(String id, DateTime date, double latitude, double longitude, double speed) 
            : base(date, latitude, longitude, speed)
        {
            this.id = id;
        }

        public String Id
        {
            get { return id; }
            private set { id = value; }
        }
    }
}
