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

        public IList<ColorSlider> Sliders { get { return Sliders; } }
        protected IList<ColorSlider> sliders;
        public int ActiveSlider { get { return activeSlider; } }
        protected int activeSlider;
        protected double miniumSliderMargin = 4.0;
        protected double initialSliderMargin;

        public ColorMultiSlider()
        {
            InitializeComponent();
            int sliderNumber = 6;
            ColorSlider slider = new ColorSlider();
            initialSliderMargin = slider.MaximumValue / (sliderNumber - 1);
            sliders = new List<ColorSlider>();
            SliderNumber = sliderNumber;
        }

        public int FindSliderListPosition(Slider slider)
        {
            return (int)slider.Tag;
        }

        void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider slider = (Slider)sender;
            int i = FindSliderListPosition(slider);
            ColorSlider colorSlider = new ColorSlider();
            if (sliders[i].ValueSlider.Minimum == sliders[i].ValueSlider.Maximum)
            {
                sliders[i].ValueSlider.Value = slider.Value = sliders[i].ValueSlider.Minimum;
                return;
            }
            if (i + 1 < sliders.Count && e.NewValue > e.OldValue)
            {
                if (e.NewValue + miniumSliderMargin > sliders[i + 1].ValueSlider.Value)
                {
                    sliders[i].ValueSlider.Value = slider.Value = e.OldValue;
                    return;
                }
                if (e.NewValue >= sliders[i].ValueSlider.Maximum - 1)
                {
                    if ((e.NewValue + miniumSliderMargin < sliders[i + 1].Value))
                    {
                        sliders[i].ValueSlider.Maximum = e.NewValue + 1;
                        sliders[i].ValueSlider.Value = slider.Value = e.NewValue;
                        if (i + 1 != sliders.Count - 1)
                        {
                            sliders[i + 1].ValueSlider.Minimum = e.NewValue + miniumSliderMargin;
                        }
                    }
                }
            }
            if (i > 0 && e.NewValue < e.OldValue)
            {
                if (e.NewValue - miniumSliderMargin < sliders[i - 1].ValueSlider.Value)
                {
                    sliders[i].ValueSlider.Value = slider.Value = e.OldValue;
                    return;
                }
                if (e.NewValue <= sliders[i].ValueSlider.Minimum + 1)
                {
                    if ((e.NewValue - miniumSliderMargin > sliders[i - 1].Value))
                    {
                        sliders[i].ValueSlider.Minimum = e.NewValue - 1;
                        sliders[i].ValueSlider.Value = slider.Value = e.NewValue;
                        if (i - 1 != 0)
                        {
                            sliders[i - 1].ValueSlider.Maximum = e.NewValue - miniumSliderMargin;
                        }
                    }
                }
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
                slider.ValueSlider.Maximum = value + initialSliderMargin - miniumSliderMargin + 1;
                slider.ValueSlider.Minimum = value - 1;
                if (i == SliderNumber - 1)
                {
                    // last one
                    value = slider.ValueSlider.Maximum = slider.ValueSlider.Minimum  = slider.MaximumSlider.Maximum - 1;                    
                }
                if (i == 0)
                {
                    // first one
                    value = slider.ValueSlider.Minimum = slider.ValueSlider.Maximum = slider.MaximumSlider.Minimum + 1;                    
                }
                slider.ValueSlider.Value = previousValue = value;
                slider.SliderValueChanged += new RoutedPropertyChangedEventHandler<double>(Slider_ValueChanged);
                slider.SliderClick += new MouseButtonEventHandler(Slider_Click);
                sliders.Add(slider);
            }

            LayoutRoot.Children.Clear();
            for (int i = 0; i < sliders.Count; i++)
            {
                LayoutRoot.Children.Add(sliders[i]);
            }
        }

        void Slider_Click(object sender, MouseButtonEventArgs e)
        {
            Slider slider = (Slider)sender;
            int i = FindSliderListPosition(slider);
            activeSlider = i;
        }

        public void SetColor(SolidColorBrush color) 
        {
            sliders[activeSlider].Color = color;
        }
    }
}

