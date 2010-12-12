using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Web;
using System.IO;

namespace TrafficLibrary
{
    [System.ServiceModel.ServiceBehavior(InstanceContextMode = System.ServiceModel.InstanceContextMode.Single, IncludeExceptionDetailInFaults = true)]
    public abstract class TrafficServiceBase : ITrafficService, ICrossDomainPolicyResponder
    {
        public event Action<string> Log;

        protected virtual void OnLog(string message)
        {
            if (Log != null) Log(message);
        }

        public abstract EstimationPoint GetEstimationPoint(double latitude, double longitude, DateTime date);

        #region ICrossDomainPolicyResponder Members

        public System.IO.Stream GetSilverlightPolicy()
        {
            string result = @"<?xml version=""1.0"" encoding=""utf-8""?>
                <access-policy>
                    <cross-domain-access>
                        <policy>
                            <allow-from>
                                <domain uri=""*""/>
                            </allow-from>
                            <grant-to>
                                <resource path=""/"" include-subpaths=""true""/>
                            </grant-to>
                        </policy>
                    </cross-domain-access>
                </access-policy>";
            return StringToStream(result);
        }

        public System.IO.Stream GetFlashPolicy()
        {
            string result = @"<?xml version=""1.0""?>
                            <!DOCTYPE cross-domain-policy SYSTEM ""http://www.macromedia.com/xml/dtds/cross-domain-policy.dtd"">
                            <cross-domain-policy>
                                <allow-access-from domain=""*"" />
                                <allow-http-request-headers-from domain=""*"" headers=""SOAPAction"" />
                            </cross-domain-policy>";
            return StringToStream(result);
        }

        private Stream StringToStream(string result)
        {
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/xml";
            return new MemoryStream(Encoding.UTF8.GetBytes(result));
        }

        #endregion
    }
}
