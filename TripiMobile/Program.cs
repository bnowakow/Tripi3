using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Tripi
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [MTAThread]
        static void Main()
        {
            ServiceManager.SendPosition();

         //   Application.Run(new LoginForm());
        }
    }
}