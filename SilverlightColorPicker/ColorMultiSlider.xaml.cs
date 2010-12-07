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
        protected double miniumSliderMargin = 4.0;
        protected double initialSliderMargin;
        protected double initialSliderMarginWidth;
        protected SliderThumbPaddingConverter sliderThumbPaddingConverter = new SliderThumbPaddingConverter();
        protected SliderWidthConverter sliderWidthConverter = new SliderWidthConverter();

        public ColorMultiSlider()
        {
            InitializeComponent();
            int sliderNumber = 4;
            ColorSlider slider = new ColorSlider();
            initialSliderMargin = slider.MaximumValue / sliderNumber;
            slider.Value = initialSliderMargin;
            slider.SliderWidth = slider.MaximumWidth;
            initialSliderMarginWidth = sliderThumbPaddingConverter.Convert(slider);
            sliders = new List<ColorSlider>();
            slider = new ColorSlider();
            slider.Value = 0;
            slider.Minimum = 0;
            slider.Width = initialSliderMarginWidth;
            slider.Maximum = initialSliderMargin - miniumSliderMargin + 1;
            slider.SliderWidth = sliderWidthConverter.Convert(slider);
            slider.SliderValueChanged += new RoutedPropertyChangedEventHandler<double>(Slider_ValueChanged);
            sliders.Add(slider);
            SliderNumber = sliderNumber;
        }

        public int findSliderListPosition(Slider slider)
        {
            for (int i = 0; i < sliders.Count; i++)
            {
                if (slider.Minimum == sliders[i].Minimum &&
                    slider.Maximum == sliders[i].Maximum)
                {
                    return i;
                }
            }
            return 0;
        }

        void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider slider = (Slider)sender;
            ColorSlider colorSlider = new ColorSlider();
            int i = findSliderListPosition(slider);
            if (e.NewValue + miniumSliderMargin > sliders[i + 1].Value)
            {
                sliders[i].Value = e.OldValue;
                return;
            }
            if (colorSlider.MaximumValue != slider.Maximum &&
                e.NewValue == slider.Maximum)
            {
                if (e.NewValue + miniumSliderMargin < sliders[i + 1].Value)
                {
                    sliders[i].Maximum = e.NewValue + 1;
                    sliders[i].Value = e.NewValue;
                    sliders[i + 1].Minimum = e.NewValue + miniumSliderMargin;
                }
            }
        }

        protected void UpdateSliderNumber() 
        {
            for (int i = sliders.Count; i < SliderNumber; i++)
            {
                ColorSlider slider = new ColorSlider();
                slider.Value = sliders[i - 1].Value + initialSliderMargin;
                slider.Minimum = slider.Value;
                slider.Width = initialSliderMarginWidth;
                if (i == SliderNumber - 1)
                {
                    // last one
                    slider.Maximum = slider.MaximumValue;
                }
                else
                {
                    slider.Maximum = slider.Value + initialSliderMargin - miniumSliderMargin + 1;
                }
                slider.SliderValueChanged += new RoutedPropertyChangedEventHandler<double>(Slider_ValueChanged);
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
