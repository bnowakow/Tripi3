using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Text.RegularExpressions;

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

        public RawPoint(string[] gpsInputFragments)
            : this(gpsInputFragments[1], DateTime.Parse(gpsInputFragments[2]), double.Parse(gpsInputFragments[3]), double.Parse(gpsInputFragments[4]), double.Parse(gpsInputFragments[8]))
        {
        }

        public RawPoint(string rawGpsInput)
            : this(Regex.Matches(rawGpsInput, @"([0-9]+)@([^@]+)@([0-9\.]+)@([0-9\.]+)@([NS] [0-9\.]+)&deg;@([EW] [0-9\.]+)&deg;@([0-9]+) m@([0-9]+) km/h@([0-9]+)&deg;")
                .Cast<Match>().Select(m => m.Value).ToArray())
        {
        }

        public String Id
        {
            get { return id; }
            private set { id = value; }
        }

        public static RawPoint[] Parsed(string filename)
        {
            return System.IO.File.ReadAllText(filename).Split('|').Select(entry => new RawPoint(entry)).ToArray();
        }
    }
}
