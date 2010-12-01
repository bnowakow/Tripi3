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

        public RawPoint()
            : base(DateTime.Now, 0, 0, 0)
        {
        }

        public RawPoint(String id, DateTime date, double latitude, double longitude, double speed)
            : base(date, latitude, longitude, speed)
        {
            this.id = id;
        }

        public RawPoint(string[] gpsInputFragments)
            : this(gpsInputFragments[0], DateTime.Parse(gpsInputFragments[1]), double.Parse(gpsInputFragments[2]), double.Parse(gpsInputFragments[3]), double.Parse(gpsInputFragments[7].Replace(" km/h", "")))
        {
        }

        public RawPoint(string rawGpsInput)
            : this(rawGpsInput.Split('@'))
            /*: this(Regex.Matches(rawGpsInput, @"([0-9]+)@([^@]+)@([0-9\.]+)@([0-9\.]+)@([NS] [0-9\.]+)&deg;@([EW] [0-9\.]+)&deg;@([0-9]+) m@([0-9]+) km/h@([0-9]+)&deg;")
                .Cast<Match>().Select(m => m.Value).ToArray())*/
        {
            //@"([^@]+)@([^@]+)@([^@]+)@([^@]+)@([^@]+)@([^@]+)@([^@]+)@([^@]+)@([^@]+)"
            //@"^([0-9]+)@([^@]+)@([0-9\.]+)@([0-9\.]+)@([NS] [0-9\.]+)&deg;@([EW] [0-9\.]+)&deg;@([0-9]+) m@([0-9]+) km/h@([0-9]+)&deg;$"
            //MatchCollection mc = Regex.Matches(rawGpsInput, @"^([0-9]+)@([^@]+)@([0-9\.]+)@([0-9\.]+)@([NS] [0-9\.]+)&deg;@([EW] [0-9\.]+)&deg;@([0-9]+) m@([0-9]+) km/h@([0-9]+)&deg;$");
            //string[] fragments = mc.Cast<Match>().Select(m => m.Value).ToArray();
        }

        public String Id
        {
            get { return id; }
            set { id = value; }
        }

        public static List<RawPoint> Parsed(string filename)
        {
            return System.IO.File.ReadAllText(filename).Split('|').Select(entry => new RawPoint(entry)).ToList();
        }
    }
}
