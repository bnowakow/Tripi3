using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace SLMultiBinding
{
  public class TitleConverter : IMultiValueConverter
  {
    #region IMultiValueConverter Members

    public object Convert(object[] values, Type targetType,
      object parameter, System.Globalization.CultureInfo culture)
    {
      string forename = values[0] as string;
      string surname = values[1] as string;

      return string.Format("{0}, {1}", surname, forename);
    }

    public object[] ConvertBack(object value, Type[] targetTypes,
      object parameter, System.Globalization.CultureInfo culture)
    {
      string source = value as string;
      var pos = source.IndexOf(", ");

      string forename = source.Substring(pos + 2);
      string surname = source.Substring(0, pos);

      return new object[] { forename, surname };
    }

    #endregion
  }

}
