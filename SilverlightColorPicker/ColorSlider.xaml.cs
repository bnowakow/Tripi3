using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace ColorPicker
{
    public partial class ColorSlider : UserControl
    {
        public ColorSlider()
        {
            InitializeComponent();
        }
        //// http://blogs.silverlight.net/blogs/msnow/archive/2008/08/26/silverlight-tip-of-the-day-32-how-to-declare-a-custom-user-control-from-a-xaml-page.aspx
        //http://weblogs.asp.net/scottgu/pages/silverlight-tutorial-part-6-using-user-controls-to-implement-master-detail-scenarios.aspx
        // http://paulyanez.com/interactive/index.php/2009/12/scaling-objects-with-a-slider-control-in-silverlight/
        private void ClickSelectedMouseDown(object sender, MouseButtonEventArgs e)
        {
            //SliderThumb.SetValue(Canvas.LeftProperty, e.);
        }

        private void SliderThumb_MouseMove(object sender, MouseEventArgs e)
        {
            
        }
    }
}
