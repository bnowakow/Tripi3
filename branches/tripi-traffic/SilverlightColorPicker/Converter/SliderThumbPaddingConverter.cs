using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Data;

namespace ColorPickerControl.Converter
{
    public class SliderThumbPaddingConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            double sliderValue = (double)value; //slider.Value
            // TODO get them from WTF hell? ;x 
            // or do multibinding...argh
            double sliderMaximum = 100;
            double sliderWidth = 230 * 0.95;
            double padding = sliderValue / sliderMaximum * sliderWidth;
            return padding + 2; // Slider.Canvas.left
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //return 50;
            throw new NotImplementedException();
        }
    }
}
