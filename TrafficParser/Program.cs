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
            Console.WriteLine(@"Enter directory (<Enter> assumes ""..\..\..\Install\iPhone Gps data\raw"")");
            string folder = Console.ReadLine();
            if (folder.Length == 0) folder = @"..\..\..\Install\iPhone Gps data\raw";

            foreach (string filename in Directory.GetFiles(folder, "*.txt"))
            {
                Console.WriteLine(filename);
                List<RawPoint> rp = RawPoint.Parsed(filename);
                rp.Serialize(Path.GetFileName(filename).Replace(".txt", ".xml"));
            }

            Console.WriteLine("Press zany key 2 continue...");
            Console.ReadLine();
        }
    }
}
