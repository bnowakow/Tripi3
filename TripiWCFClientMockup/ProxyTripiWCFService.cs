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
        
        private string TripDescriptionField;
        
        private string TripNameField;
        
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
        public string TripDescription
        {
            get
            {
                return this.TripDescriptionField;
            }
            set
            {
                this.TripDescriptionField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TripName
        {
            get
            {
                return this.TripNameField;
            }
            set
            {
                this.TripNameField = value;
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
        
        private string DescriptionField;
        
        private double LatitudeField;
        
        private double LongitudeField;
        
        private double SpeedField;
        
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
        public string Description
        {
            get
            {
                return this.DescriptionField;
            }
            set
            {
                this.DescriptionField = value;
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
        public double Speed
        {
            get
            {
                return this.SpeedField;
            }
            set
            {
                this.SpeedField = value;
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
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITripService/LoginUser", ReplyAction="http://tempuri.org/ITripService/LoginUserResponse")]
        string LoginUser(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITripService/CreateNewTrip", ReplyAction="http://tempuri.org/ITripService/CreateNewTripResponse")]
        int CreateNewTrip(string username, string tripName, string tripDescription);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITripService/GetAllTrips", ReplyAction="http://tempuri.org/ITripService/GetAllTripsResponse")]
        TripiWCF.ClientMockup.Proxy.Trip[] GetAllTrips();
        
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
        
        public string LoginUser(string username, string password)
        {
            return base.Channel.LoginUser(username, password);
        }
        
        public int CreateNewTrip(string username, string tripName, string tripDescription)
        {
            return base.Channel.CreateNewTrip(username, tripName, tripDescription);
        }
        
        public TripiWCF.ClientMockup.Proxy.Trip[] GetAllTrips()
        {
            return base.Channel.GetAllTrips();
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
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="TripiWCF.ClientMockup.Proxy.ICrossDomainPolicyResponder")]
    public interface ICrossDomainPolicyResponder
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICrossDomainPolicyResponder/GetFlashPolicy", ReplyAction="http://tempuri.org/ICrossDomainPolicyResponder/GetFlashPolicyResponse")]
        System.IO.Stream GetFlashPolicy();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public interface ICrossDomainPolicyResponderChannel : TripiWCF.ClientMockup.Proxy.ICrossDomainPolicyResponder, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public partial class CrossDomainPolicyResponderClient : System.ServiceModel.ClientBase<TripiWCF.ClientMockup.Proxy.ICrossDomainPolicyResponder>, TripiWCF.ClientMockup.Proxy.ICrossDomainPolicyResponder
    {
        
        public CrossDomainPolicyResponderClient()
        {
        }
        
        public CrossDomainPolicyResponderClient(string endpointConfigurationName) : 
                base(endpointConfigurationName)
        {
        }
        
        public CrossDomainPolicyResponderClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress)
        {
        }
        
        public CrossDomainPolicyResponderClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress)
        {
        }
        
        public CrossDomainPolicyResponderClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public System.IO.Stream GetFlashPolicy()
        {
            return base.Channel.GetFlashPolicy();
        }
    }
}
