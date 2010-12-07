using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.IO;

namespace TrafficLibrary
{
    [ServiceContract]
    public interface ICrossDomainPolicyResponder
    {
        //[OperationContract, WebGet(UriTemplate = "/clientaccesspolicy.xml")]
        Stream GetSilverlightPolicy();

        [OperationContract, WebGet(UriTemplate = "/crossdomain.xml")]
        Stream GetFlashPolicy();
    }
}
