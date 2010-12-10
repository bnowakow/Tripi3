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
    public class SliderWidthConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int bindingArgumentsNumber = 4;
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
            if ((double)values[2] == 0)
            {
                return null;
            }
            double maximum = (double)values[0];
            double minimum = (double)values[1];
            double maximumValue = (double)values[2];
            double maximumWidth = (double)values[3];
            double padding = (maximum - minimum) / maximumValue * maximumWidth;
            return padding;
        }

        object[] IMultiValueConverter.ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
