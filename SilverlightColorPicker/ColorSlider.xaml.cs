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
        public Slider ValueSlider { get { return valueSlider; } }
        public Slider MaximumSlider { get { return maximumSlider; } }
        
        public Color Color { get; set; }

        public event RoutedPropertyChangedEventHandler<double> SliderValueChanged { add { Slider.ValueChanged += value; } remove { Slider.ValueChanged -= value; } }
        public event MouseButtonEventHandler SliderClick { add { Slider.MouseLeftButtonDown += value; } remove { Slider.MouseLeftButtonDown -= value; } }

        public ColorSlider()
        {
            InitializeComponent();
        }        
    }
}
