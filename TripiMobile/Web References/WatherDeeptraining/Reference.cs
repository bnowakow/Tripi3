﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.4927
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.CompactFramework.Design.Data, Version 2.0.50727.4927.
// 
namespace Tripi.WatherDeeptraining {
    using System.Diagnostics;
    using System.Web.Services;
    using System.ComponentModel;
    using System.Web.Services.Protocols;
    using System;
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="WeatherSoap", Namespace="http://litwinconsulting.com/webservices/")]
    public partial class Weather : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        /// <remarks/>
        public Weather() {
            this.Url = "http://www.deeptraining.com/webservices/weather.asmx";
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://litwinconsulting.com/webservices/GetWeather", RequestNamespace="http://litwinconsulting.com/webservices/", ResponseNamespace="http://litwinconsulting.com/webservices/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string GetWeather(string City) {
            object[] results = this.Invoke("GetWeather", new object[] {
                        City});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetWeather(string City, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetWeather", new object[] {
                        City}, callback, asyncState);
        }
        
        /// <remarks/>
        public string EndGetWeather(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }
    }
}
