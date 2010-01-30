using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Tripi
{
    class User
    {
        private static string login;
        public static String Login
        {
            get { return login; }
            set { login = value; }
        }
    }
}
