using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using DeadCity.Mobile.MovementProviders;
using System.IO.Ports;
using System.Threading;
using System.IO;

namespace DeadCity.Mobile.MovementProviders
{
    public class OmniaMovementProvider : IMovementProvider
    {
        private SerialPort DataSource;
        private double Lon, Lat, OldLon, OldLat;
        private StreamWriter Qrita = new StreamWriter("zlo.txt", true);

        public OmniaMovementProvider(int comPortNumber)
        {
            DataSource = new SerialPort("COM" + comPortNumber.ToString(), 9600);
            DataSource.DiscardNull = true;
            DataSource.DataReceived += new SerialDataReceivedEventHandler(DataSource_DataReceived);
            DataSource.Open();

            Lon = OldLon = 18.0;
            Lat = OldLat = 54.0;
            Qrita.WriteLine("starting session...");
        }

        void DataSource_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (e.EventType == SerialData.Eof) return;
            //GaemHelper.DebugString = "Data mngfl";
            string allData = DataSource.ReadExisting();
            //GaemHelper.DebugString = "Data rddn";
            //DataSource.DiscardInBuffer();
            IEnumerable<string> sentences = allData.Split('\n').Select(sen => sen.Trim());

            // I ZOSTAŁO IM ZLINQWANE
            foreach (string ggah in sentences.Where(s => s.Contains("GGA"))) AcceptGGA(ggah);
        }

        ~OmniaMovementProvider()
        {
            Qrita.Close();
        }

        public void CheckingThreadExisting()
        {
            while (true)
            {
                string allData = DataSource.ReadExisting();
                DataSource.DiscardInBuffer();
                IEnumerable<string> sentences = allData.Split('\n').Select(sen => sen.Trim());

                // I ZOSTAŁO IM ZLINQWANE
                foreach (string ggah in sentences.Where(s => s.Contains("GGA"))) AcceptGGA(ggah);

                System.Threading.Thread.Sleep(500);
            }
        }

        public void CheckingThreadLine()
        {
            Dictionary<string, int> sentenceAge = new Dictionary<string, int>();

            while (true)
            {
                try
                {
                    string allData = DataSource.ReadLine();
                    foreach (string k in sentenceAge.Keys) sentenceAge[k]++;
                    string sentenceType = allData.Substring(3, 3);
                    sentenceAge[sentenceType] = 0;

                    if (allData.Contains("GGA")) AcceptGGA(allData);
                }
                catch (TimeoutException)
                {
                }

                System.Threading.Thread.Sleep(100);
            }
        }

        private string Ages(Dictionary<string, int> ageDic)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string k in ageDic.Keys)
            {
                sb.Append(k);
                sb.Append(":");
                sb.Append(ageDic[k]);
                sb.Append(" ");
            }

            return sb.ToString();
        }

        private void AcceptGGA(string sentence)
        {
            Qrita.WriteLine("GGA FOUND! " + sentence);

            int LonInt, LatInt;
            string[] Fragments = sentence.Split(',');
            //cudo ponizej wynika z typu danych w sentencji GGA
            //wyglada to tak, ze pierwsze dwie niezerowe cyfry to stopnie
            //a wszystkie dalsze to minuty
            if (!(Fragments[2].Equals("") || Fragments[4].Equals("")))
            {
                Lon = Double.Parse(Fragments[2]) / 100;
                Lat = Double.Parse(Fragments[4]) / 100;
                LatInt = (int)Lat;
                LonInt = (int)Lon;
                Lat -= LatInt;
                Lon -= LonInt;
                Lat /= 60;
                Lon /= 60;
                Lat += LatInt;
                Lon += LonInt;
                Qrita.WriteLine("{0} {1}", Lon, Lat);
            }
        }

        #region IMovementProvider Members
        /*void IMovementProvider.AffectPosition(ref System.Drawing.Point pos)
        {
            Qrita.WriteLine("Deltas: {0} {1}", (300000.0 * (Lon - OldLon)), (300000.0 * (Lat - OldLat)));
            Qrita.WriteLine("Positions: {0} {1} {2} {3}", Lat, Lon, OldLat, OldLon);
            pos.X += (int)(300000.0 * (Lon - OldLon));
            pos.Y += (int)(300000.0 * (Lat - OldLat));
            OldLon = Lon;
            OldLat = Lat;
        }*/
        void IMovementProvider.AffectPosition(ref PointyD pos)
        {
            Qrita.WriteLine("Deltas: {0} {1}", (300000.0 * (Lon - OldLon)), (300000.0 * (Lat - OldLat)));
            Qrita.WriteLine("Positions: {0} {1} {2} {3}", Lat, Lon, OldLat, OldLon);
            pos.X += (int)(300000.0 * (Lon - OldLon));
            pos.Y += (int)(300000.0 * (Lat - OldLat));
            OldLon = Lon;
            OldLat = Lat;
        }
        #endregion
    }
}
