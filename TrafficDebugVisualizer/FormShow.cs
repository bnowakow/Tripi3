using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using TrafficLibrary;

namespace TrafficDebugVisualizer
{
    public partial class FormShow : Form
    {
        #region Constructor, initialization, loading
        public FormShow()
        {
            InitializeComponent();

            groupBoxPiniatas.Paint += new PaintEventHandler(groupBoxPiniatas_Paint);
        }

        private void FormShow_Load(object sender, EventArgs e)
        {
            pointGetterRaw.GroupBoxTitle = "Raw points";
            pointGetterRaw.PointGetterMethod = GetRawPoints;
            pointGetterRaw.Command = "001.xml";
            pointGetterRaw.PointsWanted += new Action<List<EstimationPoint>, bool>(pointGetterAny_PointsWanted);

            pointGetterEstimated.GroupBoxTitle = "Estimated points";
            pointGetterEstimated.PointGetterMethod = GetEstimatedPoints;
            pointGetterEstimated.Command = "54.36 18.50 13:37";
            pointGetterEstimated.PointsWanted += new Action<List<EstimationPoint>, bool>(pointGetterAny_PointsWanted);
        }

        private List<EstimationPoint> GetRawPoints(string filename)
        {
            return StaticUtils.Deserialize<List<RawPoint>>(filename).Cast<EstimationPoint>().ToList();
        }

        private List<EstimationPoint> GetEstimatedPoints(string latLonTime)
        {
            string[] splat = latLonTime.Split(' ');
            Estimation ester = new Estimation(new RadialEstimationStrategy(), pointGetterRaw.PointBuffer.Cast<RawPoint>().ToList());

            return new List<EstimationPoint>() { ester.CalculateEstimationPoint(double.Parse(splat[0]), double.Parse(splat[1]), DateTime.Parse(splat[2])) };
        }
        #endregion

        #region Redrawing (hooks and stuff)
        private Pen WhitePen = new Pen(Color.White, 3);
        void groupBoxPiniatas_Paint(object sender, PaintEventArgs e)
        {
            if (pointGetterRaw.ShouldBeDrawn) DrawPoints(e.Graphics, pointGetterRaw.PointBuffer, Pens.Black);
            if (pointGetterEstimated.ShouldBeDrawn) DrawPoints(e.Graphics, pointGetterEstimated.PointBuffer, WhitePen);
        }

        void DrawPoints(Graphics canvas, List<EstimationPoint> points, Pen circle)
        {
            foreach (EstimationPoint ep in points)
            {
                canvas.FillEllipse(new SolidBrush(Color.FromArgb(Clr(ep.Speed), 0, 255 - Clr(ep.Speed))), ConvertLat(ep.Latitude), ConvertLon(ep.Longitude), 16, 16);
                if (circle != null) canvas.DrawEllipse(circle, ConvertLat(ep.Latitude), ConvertLon(ep.Longitude), 16, 16);
                //canvas.DrawEllipse(Pens.Black, ConvertLat(ep.Latitude), ConvertLon(ep.Longitude), 16, 16);
            }
        }

        void pointGetterAny_PointsWanted(List<EstimationPoint> points, bool refresh)
        {
            groupBoxPiniatas.Invalidate();
        }
        #endregion

        #region Drawing - conversions
        private int Clr(double speed)
        {
            int clr = 5 * (int)speed;
            return clr > 255 ? 255 : clr;
        }

        private const float FakeScale = 6000;
        private float ConvertLat(double lat)
        {
            return (float)((lat - 54.36) * FakeScale);
        }

        private float ConvertLon(double lon)
        {
            return (float)((lon - 18.5) * FakeScale);
        }
        #endregion
    }
}
