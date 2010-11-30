using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;
using System.IO;
using System.Reflection;
using System.Xml;

namespace Tripi
{
    /// <summary>
    /// Class used for retriving values of keys in app.config file
    /// </summary>
    static class MobileConfiguration
    {
        /// <summary>
        /// Collection of key-value pairs from app.config file
        /// </summary>
        public static NameValueCollection Settings;

        /// <summary>
        /// Loads the mobile configuration
        /// </summary>
        static MobileConfiguration()
        {
            string appPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
            string configFile = Path.Combine(appPath, "app.config");

            if (!File.Exists(configFile))
            {
                throw new FileNotFoundException(string.Format("Application configuration file '{0}' not found.", configFile));
            }

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(configFile);
            XmlNodeList nodeList = xmlDocument.GetElementsByTagName("appSettings");
            Settings = new NameValueCollection();

            foreach (XmlNode node in nodeList)
            {
                foreach (XmlNode key in node.ChildNodes)
                {
                    Settings.Add(key.Attributes["key"].Value, key.Attributes["value"].Value);
                }
            }
        }

        /// <summary>
        /// Gets the address of the wcf service
        /// </summary>
        public static string WCFAddress
        {
            get { return Settings["WCServiceAddress"]; }
        }

        /// <summary>
        /// Gets the default send frequency
        /// </summary>
        public static int DefaultSendFrequency
        {
            get
            {
                try
                {
                    return Convert.ToInt32(Settings["DefaultSendFrequency"]);
                }
                catch
                {
                    return 3000;
                }
            }
        }
    }
}
