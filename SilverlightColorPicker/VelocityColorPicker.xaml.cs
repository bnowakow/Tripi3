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
    public partial class VelocityColorPicker : UserControl
    {
        public VelocityColorPicker()
        {
            InitializeComponent();
            colorMultiSlider.OnValueChanged += new MultiSliderValueChangedDelegate(colorMultiSlider_OnValueChanged);
        }

        void colorMultiSlider_OnValueChanged(IList<ColorSlider> sliders)
        {
            LinearGradientBrush gradient = new LinearGradientBrush(); 
            gradient.StartPoint = new Point(0, 0); gradient.EndPoint = new Point(1, 0);
            for (int i = 0; i < sliders.Count; i++)
            {
                GradientStop gradientStop = new GradientStop();
                gradientStop.Color = sliders[i].Color;
                gradientStop.Offset = sliders[i].ValueSlider.Value / (sliders[i].MaximumSlider.Maximum - 1);
                gradient.GradientStops.Add(gradientStop);
            }
            gradientBorder.Background = gradient;
        }
    }
}
