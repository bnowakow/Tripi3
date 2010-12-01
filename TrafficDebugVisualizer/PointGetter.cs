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

        public Func<string, List<TrafficLibrary.EstimationPoint>> PointGetterMethod;

        private void buttonGetPoints_Click(object sender, EventArgs e)
        {
            if (PointGetterMethod != null)
            {
                listBoxPoints.Items.Clear();
                listBoxPoints.Items.AddRange(PointGetterMethod(Command).Cast<object>().ToArray());
            }
        }
    }
}
