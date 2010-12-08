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
        //private const string urlAddress = "http://192.168.1.105:1337/";
        private const string urlAddress = "http://127.0.0.1:1337/";

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

        public static ServiceHost StartServiceHost<TInterface1, TInterface2, TImplementation>(TImplementation singleton, string addressPart1, string addressPart2)
            where TImplementation : TInterface1, TInterface2
        {
            Uri urw = new Uri(urlAddress), urw1 = new Uri(urlAddress + addressPart1), urw2 = new Uri(urlAddress + addressPart2);
            ServiceMetadataBehavior beh1 = new ServiceMetadataBehavior()
            {
                HttpGetEnabled = true,
                HttpGetUrl = urw
            };
            /*System.ServiceModel.Description.XmlSerializerOperationBehavior beh2 = new XmlSerializerOperationBehavior()
            {
                HttpGetEnabled = true,
                HttpGetUrl = urw2
            };*/
            ServiceHost sh = new ServiceHost(singleton, urw2);
            sh.Description.Behaviors.Add(beh1);
            //sh.Description.Behaviors.Add(beh2);
            sh.AddServiceEndpoint(typeof(TInterface1), new BasicHttpBinding(), urw1);
            sh.AddServiceEndpoint(typeof(TInterface2), new WebHttpBinding(), urw2);
            sh.Open();
            return sh;
        }
    }
}
