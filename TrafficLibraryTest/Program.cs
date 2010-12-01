using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrafficLibrary;

namespace TrafficLibraryTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Estimation estimation = new Estimation(new RadialEstimationStrategy(), "001.xml");
            EstimationPoint point = estimation.CalculateEstimationPoint(18.59360, 54.38022, DateTime.Parse("2010-11-22 16:38:35"));
        }
    }
}
