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
            return string.Format("{0} : {1} ({2}){3}", ID, TripName, Username, TripDescription != null ? " - " + TripDescription : "");
        }
    }

    public partial class PositionNode
    {
        public override string ToString()
        {
            return string.Format("{0}/{1}: ({2:G};{3:G}) ({4} omgs/year) @ {5}{6}",
                TripID, OrdinalNumber, Latitude, Longitude, Speed, CreationTime.ToLongTimeString(), Description != null ?  " (" + Description + ")" : Description);
        }
    }
}
