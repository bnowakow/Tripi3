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
    public delegate void MultiSliderValueChangedDelegate(IList<ColorSlider> Sliders);
    public delegate void MultiSliderClickedDelegate(ColorSlider slider);

    public partial class ColorMultiSlider : UserControl
    {
        public int SliderNumber { get { return sliderNumber; } set { if (value > 0 && value < 10) { sliderNumber = value; UpdateSliderNumber(); } } }
        protected int sliderNumber;

        public IList<ColorSlider> Sliders { get { return sliders; } }
        protected IList<ColorSlider> sliders;
        public int ActiveSlider { get { return activeSlider; } }
        protected int activeSlider = 0;
        protected double miniumSliderMargin = 4.0;
        protected double initialSliderMargin;
        public event MultiSliderValueChangedDelegate OnValueChanged;
        public event MultiSliderClickedDelegate OnClicked;

        protected IList<Color> defaultSlidersColor;
        protected IList<double> defaultSlidersMargin;

        public ColorMultiSlider()
        {
            InitializeComponent();
            int sliderNumber = 6;
            ColorSlider slider = new ColorSlider();
            initialSliderMargin = slider.MaximumSlider.Maximum / (sliderNumber - 1);
            defaultSlidersColor = new List<Color>();
            defaultSlidersColor.Add(Color.FromArgb(254, 0, 0, 0));
            defaultSlidersColor.Add(Color.FromArgb(254, 254, 0, 0));
            defaultSlidersColor.Add(Color.FromArgb(254, 230, 157, 7));
            defaultSlidersColor.Add(Color.FromArgb(254, 252, 254, 0));
            defaultSlidersColor.Add(Color.FromArgb(254, 123, 187, 24));
            defaultSlidersColor.Add(Color.FromArgb(254, 15, 121, 230));
            defaultSlidersMargin = new List<double>();
            defaultSlidersMargin.Add(10);
            defaultSlidersMargin.Add(10);
            defaultSlidersMargin.Add(10);
            defaultSlidersMargin.Add(15);
            defaultSlidersMargin.Add(15);
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
            if (i != activeSlider)
            {
                Slider_Click(slider, null);
            }
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
                    if ((e.NewValue + miniumSliderMargin < sliders[i + 1].ValueSlider.Value))
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
                    if ((e.NewValue - miniumSliderMargin > sliders[i - 1].ValueSlider.Value))
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
            if (OnValueChanged != null)
            {
                OnValueChanged(Sliders);
            }
        }

        protected void UpdateSliderNumber()
        {
            double previousValue = defaultSlidersMargin.Count > 0 ? -defaultSlidersMargin[0] : - initialSliderMargin;
            for (int i = 0; i < SliderNumber; i++)
            {
                ColorSlider slider = new ColorSlider();
                slider.Slider.Tag = i;
                byte colorValue = (byte)(i * 255 / SliderNumber);
                slider.Color = i < defaultSlidersColor.Count ? defaultSlidersColor[i] : Color.FromArgb(255, (byte)(255 - colorValue), (byte)Math.Log10(colorValue), colorValue);
                double margin = i < defaultSlidersMargin.Count ? defaultSlidersMargin[i] : initialSliderMargin;
                double value = previousValue + margin;
                slider.ValueSlider.Maximum = value + margin - miniumSliderMargin + 1;
                slider.ValueSlider.Minimum = value - 1;
                if (i == SliderNumber - 1)
                {
                    // last one
                    value = slider.ValueSlider.Maximum = slider.ValueSlider.Minimum = slider.MaximumSlider.Maximum - 1;
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
            if (OnClicked != null)
            {
                OnClicked(sliders[i]);
            }
        }

        public void SetColor(Color color)
        {
            sliders[activeSlider].Color = color;
        }
    }
}

