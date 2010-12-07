using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

using TrafficLibrary;

namespace TrafficParser
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            Console.WriteLine(@"Enter directory (<Enter> assumes ""..\..\..\Install\iPhone Gps data\raw"")");
            string folder = Console.ReadLine();
            if (folder.Length == 0) folder = @"..\..\..\Install\iPhone Gps data\raw";

            List<RawPoint> all = new List<RawPoint>();
            foreach (string filename in Directory.GetFiles(folder, "*.txt"))
            {
                Console.WriteLine(filename);
                List<RawPoint> rp = RawPoint.Parsed(filename);
                all.AddRange(rp);
                rp.Serialize(Path.GetFileName(filename).Replace(".txt", ".xml"));
            }

            all.Serialize("_all.xml");

            Console.WriteLine("Press zany key 2 continue...");
            Console.ReadLine();
        }
    }
}
