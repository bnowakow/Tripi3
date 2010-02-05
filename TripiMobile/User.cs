using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Tripi
{
    /// <summary>
    /// Class representing the current user
    /// </summary>
    static class User
    {
        private static string login;
        public static String Login
        {
            get { return login; }
            set { login = value; }
        }
    }
}
