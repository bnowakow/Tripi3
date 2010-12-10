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
    }
}
