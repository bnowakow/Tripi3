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
        public FormShow()
        {
            InitializeComponent();
        }

        private void FormShow_Load(object sender, EventArgs e)
        {
            pointGetterRaw.GroupBoxTitle = "Raw points";
            pointGetterRaw.PointGetterMethod = GetRawPoints;
            pointGetterRaw.Command = "001.xml";

            pointGetterEstimated.GroupBoxTitle = "Estimated points";
            pointGetterEstimated.PointGetterMethod = GetRawPoints;
            pointGetterEstimated.Command = "001.xml";
        }

        private List<EstimationPoint> GetRawPoints(string filename)
        {
            return StaticUtils.Deserialize<List<RawPoint>>(filename).Cast<EstimationPoint>().ToList();
        }
    }
}
