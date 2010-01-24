using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Tripi
{
    public partial class MapForm : Form
    {
        private static string htmPath = @"http://www.stevetrefethen.com/files/googlemap.htm";
       
        public MapForm()
        {
            InitializeComponent();
        }

        private void BackButtonClick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void OnLoad(object sender, EventArgs e)
        {
           //browser.Navigate(new Uri(htmPath));  
        }
    }
}