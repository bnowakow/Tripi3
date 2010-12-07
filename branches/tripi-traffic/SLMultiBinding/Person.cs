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
using System.ComponentModel;

namespace SLMultiBinding
{
  public class Person : INotifyPropertyChanged
  {
    private int age;

    private string forename;

    private string surname;

    public string Surname
    {
      get { return surname; }
      set { surname = value; OnPropertyChanged("Surname"); }
    }

    public string Forename
    {
      get { return forename; }
      set { forename = value; OnPropertyChanged("Forename"); }
    }

    public int Age
    {
      get { return age; }
      set { age = value; OnPropertyChanged("Age"); }
    }

    #region INotifyPropertyChanged Members

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged(string name)
    {
      if (PropertyChanged != null)
      {
        PropertyChanged(this, new PropertyChangedEventArgs(name));
      }
    }

    #endregion
  }
}
