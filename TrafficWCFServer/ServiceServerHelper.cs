using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ServiceModel;
using System.ServiceModel.Description;

namespace TrafficWCFServer
{
    public static class ServiceServerHelper
    {
        private const string urlAddress = "http://192.168.1.105:1337/";

        public static ServiceHost StartServiceHost<TInterface, TImplementation>(string addressPart)
            where TImplementation : TInterface
        {
            Uri urw = new Uri(urlAddress + addressPart);
            ServiceMetadataBehavior beh = new ServiceMetadataBehavior()
            {
                HttpGetEnabled = true,
                HttpGetUrl = urw
            };
            ServiceHost sh = new ServiceHost(typeof(TImplementation), urw);
            sh.Description.Behaviors.Add(beh);
            sh.AddServiceEndpoint(typeof(TInterface), new BasicHttpBinding(), urw);
            sh.Open();
            return sh;
        }

        public static ServiceHost StartServiceHost<TInterface, TImplementation>(TImplementation singleton, string addressPart)
            where TImplementation : TInterface
        {
            Uri urw = new Uri(urlAddress + addressPart);
            ServiceMetadataBehavior beh = new ServiceMetadataBehavior()
            {
                HttpGetEnabled = true,
                HttpGetUrl = urw
            };
            ServiceHost sh = new ServiceHost(singleton, urw);
            sh.Description.Behaviors.Add(beh);
            sh.AddServiceEndpoint(typeof(TInterface), new BasicHttpBinding(), urw);
            sh.Open();
            return sh;
        }
    }
}
