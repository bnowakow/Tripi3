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
        protected SliderThumbPaddingConverter sliderThumbPaddingConverter = new SliderThumbPaddingConverter();
        protected SliderWidthConverter sliderWidthConverter = new SliderWidthConverter();

        public ColorMultiSlider()
        {
            InitializeComponent();
            int sliderNumber = 4;
            ColorSlider slider = new ColorSlider();
            initialSliderMargin = slider.MaximumValue / sliderNumber;
            sliders = new List<ColorSlider>();
            SliderNumber = sliderNumber;
        }

        public int findSliderListPosition(Slider slider)
        {
            return (int)slider.Tag;
            /*for (int i = 0; i < sliders.Count; i++)
            {
                if (value == sliders[i].ValueSlider.Value)
                {
                    return i;
                }
            }
            return -1;*/
        }

        void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider slider = (Slider)sender;
            ColorSlider colorSlider = new ColorSlider();
            int i = findSliderListPosition(slider);
            /*if (i == -1)
            {
                return;
            }*/
            if (i + 1 < sliders.Count)
            {
                if (e.NewValue + miniumSliderMargin > sliders[i + 1].ValueSlider.Value)
                {
                    sliders[i].ValueSlider.Value = slider.Value = e.OldValue;
                    return;
                }
                //colorSlider.MaximumValue != slider.Maximum &&
                if (
                    e.NewValue >= sliders[i].ValueSlider.Maximum - 1)
                {
                    if ((e.NewValue + miniumSliderMargin < sliders[i + 1].Value))
                    {
                        sliders[i].ValueSlider.Maximum = e.NewValue + 1;
                        sliders[i].ValueSlider.Value = slider.Value = e.NewValue;
                        sliders[i + 1].ValueSlider.Minimum = e.NewValue + miniumSliderMargin;
                    }
                }
            }

            // maybe != ....
            if (slider.Value < sliders[i].ValueSlider.Minimum ||
                slider.Value > sliders[i].ValueSlider.Maximum)
            {
                //slider.Value = sliders[i].ValueSlider.Value;
            }
        }

        protected void UpdateSliderNumber()
        {
            double previousValue = -initialSliderMargin;
            for (int i = 0; i < SliderNumber; i++)
            {
                ColorSlider slider = new ColorSlider();
                slider.Slider.Tag = i;
                //slider.ValueSlider.Background = new SolidColorBrush(Color.FromArgb(0, 120, 120, 120));
                double value = previousValue + initialSliderMargin;
                previousValue = value;
                if (i == SliderNumber - 1)
                {
                    // last one
                    slider.ValueSlider.Maximum = slider.MaximumValue;
                }
                else
                {
                    slider.ValueSlider.Maximum = value + initialSliderMargin - miniumSliderMargin + 1;
                }
                slider.ValueSlider.Minimum = value;
                slider.ValueSlider.Value = value;

                slider.SliderValueChanged += new RoutedPropertyChangedEventHandler<double>(Slider_ValueChanged);
                sliders.Add(slider);
            }

            LayoutRoot.Children.Clear();
            for (int i = 0; i < SliderNumber; i++)
            {
                LayoutRoot.Children.Add(sliders[i]);
            }
        }
    }
}

