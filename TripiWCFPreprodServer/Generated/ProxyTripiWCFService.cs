﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3082
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TripiWCF.ClientMockup.Proxy
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Trip", Namespace="http://schemas.datacontract.org/2004/07/TripiWCF.Service")]
    public partial class Trip : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private int IDField;
        
        private string UsernameField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ID
        {
            get
            {
                return this.IDField;
            }
            set
            {
                this.IDField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Username
        {
            get
            {
                return this.UsernameField;
            }
            set
            {
                this.UsernameField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="PositionNode", Namespace="http://schemas.datacontract.org/2004/07/TripiWCF.Service")]
    public partial class PositionNode : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private System.DateTime CreationTimeField;
        
        private double LatitudeField;
        
        private double LongitudeField;
        
        private int TripIDField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime CreationTime
        {
            get
            {
                return this.CreationTimeField;
            }
            set
            {
                this.CreationTimeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double Latitude
        {
            get
            {
                return this.LatitudeField;
            }
            set
            {
                this.LatitudeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double Longitude
        {
            get
            {
                return this.LongitudeField;
            }
            set
            {
                this.LongitudeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int TripID
        {
            get
            {
                return this.TripIDField;
            }
            set
            {
                this.TripIDField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="TripiWCF.ClientMockup.Proxy.ITripService")]
    public interface ITripService
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITripService/CreateNewTrip", ReplyAction="http://tempuri.org/ITripService/CreateNewTripResponse")]
        int CreateNewTrip(string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITripService/GetTripsForUser", ReplyAction="http://tempuri.org/ITripService/GetTripsForUserResponse")]
        TripiWCF.ClientMockup.Proxy.Trip[] GetTripsForUser(string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITripService/GetPositionNodesForTrip", ReplyAction="http://tempuri.org/ITripService/GetPositionNodesForTripResponse")]
        TripiWCF.ClientMockup.Proxy.PositionNode[] GetPositionNodesForTrip(int tripID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITripService/AddPositionNode", ReplyAction="http://tempuri.org/ITripService/AddPositionNodeResponse")]
        void AddPositionNode(TripiWCF.ClientMockup.Proxy.PositionNode node);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public interface ITripServiceChannel : TripiWCF.ClientMockup.Proxy.ITripService, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public partial class TripServiceClient : System.ServiceModel.ClientBase<TripiWCF.ClientMockup.Proxy.ITripService>, TripiWCF.ClientMockup.Proxy.ITripService
    {
        
        public TripServiceClient()
        {
        }
        
        public TripServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName)
        {
        }
        
        public TripServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress)
        {
        }
        
        public TripServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress)
        {
        }
        
        public TripServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public int CreateNewTrip(string username)
        {
            return base.Channel.CreateNewTrip(username);
        }
        
        public TripiWCF.ClientMockup.Proxy.Trip[] GetTripsForUser(string username)
        {
            return base.Channel.GetTripsForUser(username);
        }
        
        public TripiWCF.ClientMockup.Proxy.PositionNode[] GetPositionNodesForTrip(int tripID)
        {
            return base.Channel.GetPositionNodesForTrip(tripID);
        }
        
        public void AddPositionNode(TripiWCF.ClientMockup.Proxy.PositionNode node)
        {
            base.Channel.AddPositionNode(node);
        }
    }
}