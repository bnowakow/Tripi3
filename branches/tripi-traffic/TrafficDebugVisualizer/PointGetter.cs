using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TrafficDebugVisualizer
{
    public partial class PointGetter : UserControl
    {
        public PointGetter()
        {
            InitializeComponent();

            PointBuffer = new List<TrafficLibrary.EstimationPoint>();
        }

        public string GroupBoxTitle
        {
            get
            {
                return groupBoxSettings.Text;
            }

            set
            {
                groupBoxSettings.Text = value + " - settings";
                groupBoxPoints.Text = value + " - points";
            }
        }

        public string Command
        {
            get
            {
                return textBoxCommand.Text;
            }

            set
            {
                textBoxCommand.Text = value;
            }
        }

        public bool ShouldBeDrawn
        {
            get
            {
                return checkBoxShow.Checked;
            }
        }

        public Func<string, List<TrafficLibrary.EstimationPoint>> PointGetterMethod;

        public List<TrafficLibrary.EstimationPoint> PointBuffer { get; private set; }
        private void buttonGetPoints_Click(object sender, EventArgs e)
        {
            if (PointGetterMethod != null)
            {
                listBoxPoints.Items.Clear();
                PointBuffer = PointGetterMethod(Command);
                listBoxPoints.Items.AddRange(PointBuffer.Cast<object>().ToArray());

                OnPointsWanted();
            }
        }

        public event Action<List<TrafficLibrary.EstimationPoint>, bool> PointsWanted;

        private void OnPointsWanted()
        {
            if (PointsWanted != null) PointsWanted(PointBuffer, checkBoxShow.Checked);
        }

        private void checkBoxShow_CheckedChanged(object sender, EventArgs e)
        {
            OnPointsWanted();
        }
    }
}
