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

namespace ColorPickerControl
{
    public partial class ColorSlider : UserControl
    {
        public double Value { get { return Slider.Value; } set { Slider.Value = value; }}
        public double Minimum { get { return Slider.Minimum; } set { Slider.Minimum = value; } }
        public double Maximum { get { return Slider.Maximum; } set { Slider.Maximum = value; } }
        public double MaximumValue { get { return MaximumSlider.Maximum; } }
        public double MaximumWidth { get { return MaximumSlider.Width; } }
        public double SliderWidth { get { return Slider.Width; } set { Slider.Width = value; } }

        public Slider ValueSlider { get { return valueSlider; } }
        public Slider MaximumSlider { get { return maximumSlider; } }
        //public SolidColorBrush SliderThumbColor { get { SolidColorBrush col = null; try { col = (SolidColorBrush)this.Resources["sliderThumbColor"]; } catch { } return col; } }
        public Color Color { get; set; }
        public event RoutedPropertyChangedEventHandler<double> SliderValueChanged { add { Slider.ValueChanged += value; } remove { Slider.ValueChanged -= value; } }
        public event MouseButtonEventHandler SliderClick { add { Slider.MouseLeftButtonDown += value; } remove { Slider.MouseLeftButtonDown -= value; } } 

        public ColorSlider()
        {
            InitializeComponent();
        }

        // http://blogs.silverlight.net/blogs/msnow/archive/2008/08/26/silverlight-tip-of-the-day-32-how-to-declare-a-custom-user-control-from-a-xaml-page.aspx
        // http://weblogs.asp.net/scottgu/pages/silverlight-tutorial-part-6-using-user-controls-to-implement-master-detail-scenarios.aspx
        // http://paulyanez.com/interactive/index.php/2009/12/scaling-objects-with-a-slider-control-in-silverlight/

        // http://www.dotnetspark.com/kb/1844-customize-slider-control-silverlight-application.aspx
        
    }
}
