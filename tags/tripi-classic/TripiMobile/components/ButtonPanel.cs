using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Tripi.components
{
    public partial class ButtonPanel : UserControl
    {
        public ButtonPanel()
        {
            InitializeComponent();
        }

        public override String Text
        {
            get { return textLabel.Text; }
            set { textLabel.Text = value; }
        }

        private void OnGotFocus(object sender, EventArgs e)
        {
            this.BackColor = Color.Blue;
        }

        private void OnLostFocus(object sender, EventArgs e)
        {
            this.BackColor = Color.LightGray;
        }

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            this.BackColor = Color.Yellow;
        }

        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            this.BackColor = Color.Red;
        }
    }
}
