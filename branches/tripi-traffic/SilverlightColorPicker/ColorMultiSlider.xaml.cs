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
using ColorPickerControl.Converter;

namespace ColorPickerControl
{
    public partial class ColorMultiSlider : UserControl
    {

        public int SliderNumber { get { return sliderNumber; } set { if (value > 0 && value < 10) { sliderNumber = value; UpdateSliderNumber(); } } }
        protected int sliderNumber;

        protected IList<ColorSlider> sliders;
        protected double minimumSliderMargin = 10.0;
        protected double minimumSliderMarginWidth;
        protected SliderThumbPaddingConverter sliderThumbPaddingConverter = new SliderThumbPaddingConverter();

        public ColorMultiSlider()
        {
            InitializeComponent();
            ColorSlider slider = new ColorSlider();
            slider.Value = minimumSliderMargin;
            minimumSliderMarginWidth = (double)sliderThumbPaddingConverter.Convert(slider);
            sliders = new List<ColorSlider>();
            slider.Value = 0;
            slider.Width = minimumSliderMarginWidth;
            sliders.Add(slider);
            SliderNumber = 4;
        }

        protected void UpdateSliderNumber() 
        {
            for (int i = sliders.Count; i < SliderNumber; i++)
            {
                ColorSlider slider = new ColorSlider();
                slider.Value = sliders[i - 1].Value + minimumSliderMargin;
                slider.Minimum = slider.Value;
                slider.SliderWidth -= slider.Value / minimumSliderMargin * minimumSliderMarginWidth; 
                slider.Width = minimumSliderMarginWidth;
                sliders.Add(slider);
            }

            LayoutRoot.Children.Clear();
            for (int i = 0; i < SliderNumber    ; i++)
            {
                LayoutRoot.Children.Add(sliders[i]);
            }
        }
    }
}
