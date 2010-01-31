using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TripiWCF.ClientMockup.Proxy
{
    public partial class Trip
    {
        public override string ToString()
        {
            return string.Format("{0} : {1} ({2})", ID, TripName, Username);
        }
    }

    public partial class PositionNode
    {
        public override string ToString()
        {
            return string.Format("{0}: ({1,6:G};{2,6:G}) ({3} omgs/year) @ {4}", TripID, Latitude, Longitude, Speed, CreationTime.ToLongTimeString());
        }
    }
}
