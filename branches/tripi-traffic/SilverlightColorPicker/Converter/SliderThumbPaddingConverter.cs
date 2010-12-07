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
    public class SliderThumbPaddingConverter : IMultiValueConverter /*, IValueConverter */
    {
        public double Convert(ColorSlider colorSlider)
        {
            return (double)this.Convert(new object[] { colorSlider.Value, colorSlider.MaximumValue, colorSlider.Minimum, colorSlider.SliderWidth, colorSlider.Maximum }, null, null, null);
        }

        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int bindingArgumentsNumber = 5;
            if (values == null || values.Length < bindingArgumentsNumber)
            {
                return null;
            }
            for (int i = 0; i < bindingArgumentsNumber; i++)
            {
                if (values[i] == null)
                {
                    return null;
                }
            }
            if ((double)values[1] == 0)
            {
                return null;
            }
            double value = (double)values[0];
            double maximum = (double)values[1];
            double minumum = (double)values[2];
            double width = (double)values[3];
            double padding = (value - minumum) / (maximum - minumum) * (width);
            return padding;
        }

        object[] IMultiValueConverter.ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        /*
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
            throw new NotImplementedException();
        }
         * */
    }
}
