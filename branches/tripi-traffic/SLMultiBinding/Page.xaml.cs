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
using System.Windows.Data;

namespace SLMultiBinding
{
  public partial class StartPage : UserControl
  {
    Person person;
      

    public StartPage()
    {
      InitializeComponent();

     
      person = new Person()
      {
        Surname = "Rastelli",
        Forename = "Enrico",
        Age = 34
      };
            
      this.DataContext = person;
    }

  }
}
