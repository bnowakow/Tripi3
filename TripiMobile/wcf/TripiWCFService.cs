﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3082
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------



[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
public interface ITripService
{
    
    string LoginUser(string username, string password);
    
    int CreateNewTrip(string username, string tripName, string tripDescription);
    
    Trip[] GetAllTrips();
    
    Trip[] GetTripsForUser(string username);
    
    void UpdateTripDescription(int tripID, string tripDescription);
    
    int AddPositionNode(PositionNode node);
    
    void AddManyPositionNodes(PositionNode[] nodes);
    
    PositionNode[] GetPositionNodesForTrip(int tripID);
    
    void UpdatePositionNodeDescription(int tripID, int nodeNumber, string nodeDescription);
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.Xml.Serialization.XmlRootAttribute(ElementName="LoginUser", Namespace="http://tempuri.org/")]
public partial class LoginUserRequest
{
    
    [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Namespace="http://tempuri.org/", Order=0)]
    public string username;
    
    [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Namespace="http://tempuri.org/", Order=1)]
    public string password;
    
    public LoginUserRequest()
    {
    }
    
    public LoginUserRequest(string username, string password)
    {
        this.username = username;
        this.password = password;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.Xml.Serialization.XmlRootAttribute(ElementName="LoginUserResponse", Namespace="http://tempuri.org/")]
public partial class LoginUserResponse
{
    
    [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Namespace="http://tempuri.org/", Order=0)]
    public string LoginUserResult;
    
    public LoginUserResponse()
    {
    }
    
    public LoginUserResponse(string LoginUserResult)
    {
        this.LoginUserResult = LoginUserResult;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.Xml.Serialization.XmlRootAttribute(ElementName="CreateNewTrip", Namespace="http://tempuri.org/")]
public partial class CreateNewTripRequest
{
    
    [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Namespace="http://tempuri.org/", Order=0)]
    public string username;
    
    [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Namespace="http://tempuri.org/", Order=1)]
    public string tripName;
    
    [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Namespace="http://tempuri.org/", Order=2)]
    public string tripDescription;
    
    public CreateNewTripRequest()
    {
    }
    
    public CreateNewTripRequest(string username, string tripName, string tripDescription)
    {
        this.username = username;
        this.tripName = tripName;
        this.tripDescription = tripDescription;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.Xml.Serialization.XmlRootAttribute(ElementName="CreateNewTripResponse", Namespace="http://tempuri.org/")]
public partial class CreateNewTripResponse
{
    
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://tempuri.org/", Order=0)]
    public int CreateNewTripResult;
    
    public CreateNewTripResponse()
    {
    }
    
    public CreateNewTripResponse(int CreateNewTripResult)
    {
        this.CreateNewTripResult = CreateNewTripResult;
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("NetCFSvcUtil", "3.5.0.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.datacontract.org/2004/07/TripiWCF.Service")]
public partial class Trip
{
    
    private int idField;
    
    private bool idFieldSpecified;
    
    private string tripDescriptionField;
    
    private string tripNameField;
    
    private string usernameField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order=0)]
    public int ID
    {
        get
        {
            return this.idField;
        }
        set
        {
            this.idField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool IDSpecified
    {
        get
        {
            return this.idFieldSpecified;
        }
        set
        {
            this.idFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=1)]
    public string TripDescription
    {
        get
        {
            return this.tripDescriptionField;
        }
        set
        {
            this.tripDescriptionField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=2)]
    public string TripName
    {
        get
        {
            return this.tripNameField;
        }
        set
        {
            this.tripNameField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=3)]
    public string Username
    {
        get
        {
            return this.usernameField;
        }
        set
        {
            this.usernameField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("NetCFSvcUtil", "3.5.0.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.datacontract.org/2004/07/TripiWCF.Service")]
public partial class PositionNode
{
    
    private System.DateTime creationTimeField;
    
    private bool creationTimeFieldSpecified;
    
    private string descriptionField;
    
    private double latitudeField;
    
    private bool latitudeFieldSpecified;
    
    private double longitudeField;
    
    private bool longitudeFieldSpecified;
    
    private int ordinalNumberField;
    
    private bool ordinalNumberFieldSpecified;
    
    private double speedField;
    
    private bool speedFieldSpecified;
    
    private int tripIDField;
    
    private bool tripIDFieldSpecified;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order=0)]
    public System.DateTime CreationTime
    {
        get
        {
            return this.creationTimeField;
        }
        set
        {
            this.creationTimeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool CreationTimeSpecified
    {
        get
        {
            return this.creationTimeFieldSpecified;
        }
        set
        {
            this.creationTimeFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=1)]
    public string Description
    {
        get
        {
            return this.descriptionField;
        }
        set
        {
            this.descriptionField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order=2)]
    public double Latitude
    {
        get
        {
            return this.latitudeField;
        }
        set
        {
            this.latitudeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool LatitudeSpecified
    {
        get
        {
            return this.latitudeFieldSpecified;
        }
        set
        {
            this.latitudeFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order=3)]
    public double Longitude
    {
        get
        {
            return this.longitudeField;
        }
        set
        {
            this.longitudeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool LongitudeSpecified
    {
        get
        {
            return this.longitudeFieldSpecified;
        }
        set
        {
            this.longitudeFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order=4)]
    public int OrdinalNumber
    {
        get
        {
            return this.ordinalNumberField;
        }
        set
        {
            this.ordinalNumberField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool OrdinalNumberSpecified
    {
        get
        {
            return this.ordinalNumberFieldSpecified;
        }
        set
        {
            this.ordinalNumberFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order=5)]
    public double Speed
    {
        get
        {
            return this.speedField;
        }
        set
        {
            this.speedField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool SpeedSpecified
    {
        get
        {
            return this.speedFieldSpecified;
        }
        set
        {
            this.speedFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order=6)]
    public int TripID
    {
        get
        {
            return this.tripIDField;
        }
        set
        {
            this.tripIDField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool TripIDSpecified
    {
        get
        {
            return this.tripIDFieldSpecified;
        }
        set
        {
            this.tripIDFieldSpecified = value;
        }
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.Xml.Serialization.XmlRootAttribute(ElementName="GetAllTrips", Namespace="http://tempuri.org/")]
public partial class GetAllTripsRequest
{
    
    public GetAllTripsRequest()
    {
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.Xml.Serialization.XmlRootAttribute(ElementName="GetAllTripsResponse", Namespace="http://tempuri.org/")]
public partial class GetAllTripsResponse
{
    
    [System.Xml.Serialization.XmlArrayAttribute(IsNullable=true, Namespace="http://tempuri.org/", Order=0)]
    [System.Xml.Serialization.XmlArrayItemAttribute(Namespace="http://schemas.datacontract.org/2004/07/TripiWCF.Service")]
    public Trip[] GetAllTripsResult;
    
    public GetAllTripsResponse()
    {
    }
    
    public GetAllTripsResponse(Trip[] GetAllTripsResult)
    {
        this.GetAllTripsResult = GetAllTripsResult;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.Xml.Serialization.XmlRootAttribute(ElementName="GetTripsForUser", Namespace="http://tempuri.org/")]
public partial class GetTripsForUserRequest
{
    
    [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Namespace="http://tempuri.org/", Order=0)]
    public string username;
    
    public GetTripsForUserRequest()
    {
    }
    
    public GetTripsForUserRequest(string username)
    {
        this.username = username;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.Xml.Serialization.XmlRootAttribute(ElementName="GetTripsForUserResponse", Namespace="http://tempuri.org/")]
public partial class GetTripsForUserResponse
{
    
    [System.Xml.Serialization.XmlArrayAttribute(IsNullable=true, Namespace="http://tempuri.org/", Order=0)]
    [System.Xml.Serialization.XmlArrayItemAttribute(Namespace="http://schemas.datacontract.org/2004/07/TripiWCF.Service")]
    public Trip[] GetTripsForUserResult;
    
    public GetTripsForUserResponse()
    {
    }
    
    public GetTripsForUserResponse(Trip[] GetTripsForUserResult)
    {
        this.GetTripsForUserResult = GetTripsForUserResult;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.Xml.Serialization.XmlRootAttribute(ElementName="UpdateTripDescription", Namespace="http://tempuri.org/")]
public partial class UpdateTripDescriptionRequest
{
    
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://tempuri.org/", Order=0)]
    public int tripID;
    
    [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Namespace="http://tempuri.org/", Order=1)]
    public string tripDescription;
    
    public UpdateTripDescriptionRequest()
    {
    }
    
    public UpdateTripDescriptionRequest(int tripID, string tripDescription)
    {
        this.tripID = tripID;
        this.tripDescription = tripDescription;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.Xml.Serialization.XmlRootAttribute(ElementName="UpdateTripDescriptionResponse", Namespace="http://tempuri.org/")]
public partial class UpdateTripDescriptionResponse
{
    
    public UpdateTripDescriptionResponse()
    {
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.Xml.Serialization.XmlRootAttribute(ElementName="AddPositionNode", Namespace="http://tempuri.org/")]
public partial class AddPositionNodeRequest
{
    
    [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Namespace="http://tempuri.org/", Order=0)]
    public PositionNode node;
    
    public AddPositionNodeRequest()
    {
    }
    
    public AddPositionNodeRequest(PositionNode node)
    {
        this.node = node;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.Xml.Serialization.XmlRootAttribute(ElementName="AddPositionNodeResponse", Namespace="http://tempuri.org/")]
public partial class AddPositionNodeResponse
{
    
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://tempuri.org/", Order=0)]
    public int AddPositionNodeResult;
    
    public AddPositionNodeResponse()
    {
    }
    
    public AddPositionNodeResponse(int AddPositionNodeResult)
    {
        this.AddPositionNodeResult = AddPositionNodeResult;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.Xml.Serialization.XmlRootAttribute(ElementName="AddManyPositionNodes", Namespace="http://tempuri.org/")]
public partial class AddManyPositionNodesRequest
{
    
    [System.Xml.Serialization.XmlArrayAttribute(IsNullable=true, Namespace="http://tempuri.org/", Order=0)]
    [System.Xml.Serialization.XmlArrayItemAttribute(Namespace="http://schemas.datacontract.org/2004/07/TripiWCF.Service")]
    public PositionNode[] nodes;
    
    public AddManyPositionNodesRequest()
    {
    }
    
    public AddManyPositionNodesRequest(PositionNode[] nodes)
    {
        this.nodes = nodes;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.Xml.Serialization.XmlRootAttribute(ElementName="AddManyPositionNodesResponse", Namespace="http://tempuri.org/")]
public partial class AddManyPositionNodesResponse
{
    
    public AddManyPositionNodesResponse()
    {
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.Xml.Serialization.XmlRootAttribute(ElementName="GetPositionNodesForTrip", Namespace="http://tempuri.org/")]
public partial class GetPositionNodesForTripRequest
{
    
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://tempuri.org/", Order=0)]
    public int tripID;
    
    public GetPositionNodesForTripRequest()
    {
    }
    
    public GetPositionNodesForTripRequest(int tripID)
    {
        this.tripID = tripID;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.Xml.Serialization.XmlRootAttribute(ElementName="GetPositionNodesForTripResponse", Namespace="http://tempuri.org/")]
public partial class GetPositionNodesForTripResponse
{
    
    [System.Xml.Serialization.XmlArrayAttribute(IsNullable=true, Namespace="http://tempuri.org/", Order=0)]
    [System.Xml.Serialization.XmlArrayItemAttribute(Namespace="http://schemas.datacontract.org/2004/07/TripiWCF.Service")]
    public PositionNode[] GetPositionNodesForTripResult;
    
    public GetPositionNodesForTripResponse()
    {
    }
    
    public GetPositionNodesForTripResponse(PositionNode[] GetPositionNodesForTripResult)
    {
        this.GetPositionNodesForTripResult = GetPositionNodesForTripResult;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.Xml.Serialization.XmlRootAttribute(ElementName="UpdatePositionNodeDescription", Namespace="http://tempuri.org/")]
public partial class UpdatePositionNodeDescriptionRequest
{
    
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://tempuri.org/", Order=0)]
    public int tripID;
    
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://tempuri.org/", Order=1)]
    public int nodeNumber;
    
    [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Namespace="http://tempuri.org/", Order=2)]
    public string nodeDescription;
    
    public UpdatePositionNodeDescriptionRequest()
    {
    }
    
    public UpdatePositionNodeDescriptionRequest(int tripID, int nodeNumber, string nodeDescription)
    {
        this.tripID = tripID;
        this.nodeNumber = nodeNumber;
        this.nodeDescription = nodeDescription;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.Xml.Serialization.XmlRootAttribute(ElementName="UpdatePositionNodeDescriptionResponse", Namespace="http://tempuri.org/")]
public partial class UpdatePositionNodeDescriptionResponse
{
    
    public UpdatePositionNodeDescriptionResponse()
    {
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
public partial class TripServiceClient : Microsoft.Tools.ServiceModel.CFClientBase<ITripService>, ITripService
{
    
    public TripServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(binding, remoteAddress)
    {
        addProtectionRequirements(binding);
    }
    
    private LoginUserResponse LoginUser(LoginUserRequest request)
    {
        CFInvokeInfo info = new CFInvokeInfo();
        info.Action = "http://tempuri.org/ITripService/LoginUser";
        info.RequestIsWrapped = true;
        info.ReplyAction = "http://tempuri.org/ITripService/LoginUserResponse";
        info.ResponseIsWrapped = true;
        LoginUserResponse retVal = base.Invoke<LoginUserRequest, LoginUserResponse>(info, request);
        return retVal;
    }
    
    public string LoginUser(string username, string password)
    {
        LoginUserRequest request = new LoginUserRequest(username, password);
        LoginUserResponse response = this.LoginUser(request);
        return response.LoginUserResult;
    }
    
    private CreateNewTripResponse CreateNewTrip(CreateNewTripRequest request)
    {
        CFInvokeInfo info = new CFInvokeInfo();
        info.Action = "http://tempuri.org/ITripService/CreateNewTrip";
        info.RequestIsWrapped = true;
        info.ReplyAction = "http://tempuri.org/ITripService/CreateNewTripResponse";
        info.ResponseIsWrapped = true;
        CreateNewTripResponse retVal = base.Invoke<CreateNewTripRequest, CreateNewTripResponse>(info, request);
        return retVal;
    }
    
    public int CreateNewTrip(string username, string tripName, string tripDescription)
    {
        CreateNewTripRequest request = new CreateNewTripRequest(username, tripName, tripDescription);
        CreateNewTripResponse response = this.CreateNewTrip(request);
        return response.CreateNewTripResult;
    }
    
    private GetAllTripsResponse GetAllTrips(GetAllTripsRequest request)
    {
        CFInvokeInfo info = new CFInvokeInfo();
        info.Action = "http://tempuri.org/ITripService/GetAllTrips";
        info.RequestIsWrapped = true;
        info.ReplyAction = "http://tempuri.org/ITripService/GetAllTripsResponse";
        info.ResponseIsWrapped = true;
        GetAllTripsResponse retVal = base.Invoke<GetAllTripsRequest, GetAllTripsResponse>(info, request);
        return retVal;
    }
    
    public Trip[] GetAllTrips()
    {
        GetAllTripsRequest request = new GetAllTripsRequest();
        GetAllTripsResponse response = this.GetAllTrips(request);
        return response.GetAllTripsResult;
    }
    
    private GetTripsForUserResponse GetTripsForUser(GetTripsForUserRequest request)
    {
        CFInvokeInfo info = new CFInvokeInfo();
        info.Action = "http://tempuri.org/ITripService/GetTripsForUser";
        info.RequestIsWrapped = true;
        info.ReplyAction = "http://tempuri.org/ITripService/GetTripsForUserResponse";
        info.ResponseIsWrapped = true;
        GetTripsForUserResponse retVal = base.Invoke<GetTripsForUserRequest, GetTripsForUserResponse>(info, request);
        return retVal;
    }
    
    public Trip[] GetTripsForUser(string username)
    {
        GetTripsForUserRequest request = new GetTripsForUserRequest(username);
        GetTripsForUserResponse response = this.GetTripsForUser(request);
        return response.GetTripsForUserResult;
    }
    
    private UpdateTripDescriptionResponse UpdateTripDescription(UpdateTripDescriptionRequest request)
    {
        CFInvokeInfo info = new CFInvokeInfo();
        info.Action = "http://tempuri.org/ITripService/UpdateTripDescription";
        info.RequestIsWrapped = true;
        info.ReplyAction = "http://tempuri.org/ITripService/UpdateTripDescriptionResponse";
        info.ResponseIsWrapped = true;
        UpdateTripDescriptionResponse retVal = base.Invoke<UpdateTripDescriptionRequest, UpdateTripDescriptionResponse>(info, request);
        return retVal;
    }
    
    public void UpdateTripDescription(int tripID, string tripDescription)
    {
        UpdateTripDescriptionRequest request = new UpdateTripDescriptionRequest(tripID, tripDescription);
        UpdateTripDescriptionResponse response = this.UpdateTripDescription(request);
    }
    
    private AddPositionNodeResponse AddPositionNode(AddPositionNodeRequest request)
    {
        CFInvokeInfo info = new CFInvokeInfo();
        info.Action = "http://tempuri.org/ITripService/AddPositionNode";
        info.RequestIsWrapped = true;
        info.ReplyAction = "http://tempuri.org/ITripService/AddPositionNodeResponse";
        info.ResponseIsWrapped = true;
        AddPositionNodeResponse retVal = base.Invoke<AddPositionNodeRequest, AddPositionNodeResponse>(info, request);
        return retVal;
    }
    
    public int AddPositionNode(PositionNode node)
    {
        AddPositionNodeRequest request = new AddPositionNodeRequest(node);
        AddPositionNodeResponse response = this.AddPositionNode(request);
        return response.AddPositionNodeResult;
    }
    
    private AddManyPositionNodesResponse AddManyPositionNodes(AddManyPositionNodesRequest request)
    {
        CFInvokeInfo info = new CFInvokeInfo();
        info.Action = "http://tempuri.org/ITripService/AddManyPositionNodes";
        info.RequestIsWrapped = true;
        info.ReplyAction = "http://tempuri.org/ITripService/AddManyPositionNodesResponse";
        info.ResponseIsWrapped = true;
        AddManyPositionNodesResponse retVal = base.Invoke<AddManyPositionNodesRequest, AddManyPositionNodesResponse>(info, request);
        return retVal;
    }
    
    public void AddManyPositionNodes(PositionNode[] nodes)
    {
        AddManyPositionNodesRequest request = new AddManyPositionNodesRequest(nodes);
        AddManyPositionNodesResponse response = this.AddManyPositionNodes(request);
    }
    
    private GetPositionNodesForTripResponse GetPositionNodesForTrip(GetPositionNodesForTripRequest request)
    {
        CFInvokeInfo info = new CFInvokeInfo();
        info.Action = "http://tempuri.org/ITripService/GetPositionNodesForTrip";
        info.RequestIsWrapped = true;
        info.ReplyAction = "http://tempuri.org/ITripService/GetPositionNodesForTripResponse";
        info.ResponseIsWrapped = true;
        GetPositionNodesForTripResponse retVal = base.Invoke<GetPositionNodesForTripRequest, GetPositionNodesForTripResponse>(info, request);
        return retVal;
    }
    
    public PositionNode[] GetPositionNodesForTrip(int tripID)
    {
        GetPositionNodesForTripRequest request = new GetPositionNodesForTripRequest(tripID);
        GetPositionNodesForTripResponse response = this.GetPositionNodesForTrip(request);
        return response.GetPositionNodesForTripResult;
    }
    
    private UpdatePositionNodeDescriptionResponse UpdatePositionNodeDescription(UpdatePositionNodeDescriptionRequest request)
    {
        CFInvokeInfo info = new CFInvokeInfo();
        info.Action = "http://tempuri.org/ITripService/UpdatePositionNodeDescription";
        info.RequestIsWrapped = true;
        info.ReplyAction = "http://tempuri.org/ITripService/UpdatePositionNodeDescriptionResponse";
        info.ResponseIsWrapped = true;
        UpdatePositionNodeDescriptionResponse retVal = base.Invoke<UpdatePositionNodeDescriptionRequest, UpdatePositionNodeDescriptionResponse>(info, request);
        return retVal;
    }
    
    public void UpdatePositionNodeDescription(int tripID, int nodeNumber, string nodeDescription)
    {
        UpdatePositionNodeDescriptionRequest request = new UpdatePositionNodeDescriptionRequest(tripID, nodeNumber, nodeDescription);
        UpdatePositionNodeDescriptionResponse response = this.UpdatePositionNodeDescription(request);
    }
    
    private void addProtectionRequirements(System.ServiceModel.Channels.Binding binding)
    {
        if ((IsSecureMessageBinding(binding) == false))
        {
            return;
        }
        System.ServiceModel.Security.ChannelProtectionRequirements cpr = new System.ServiceModel.Security.ChannelProtectionRequirements();
        ApplyProtection("http://tempuri.org/ITripService/LoginUser", cpr.IncomingSignatureParts, true);
        ApplyProtection("http://tempuri.org/ITripService/LoginUser", cpr.IncomingEncryptionParts, true);
        ApplyProtection("http://tempuri.org/ITripService/CreateNewTrip", cpr.IncomingSignatureParts, true);
        ApplyProtection("http://tempuri.org/ITripService/CreateNewTrip", cpr.IncomingEncryptionParts, true);
        ApplyProtection("http://tempuri.org/ITripService/GetAllTrips", cpr.IncomingSignatureParts, true);
        ApplyProtection("http://tempuri.org/ITripService/GetAllTrips", cpr.IncomingEncryptionParts, true);
        ApplyProtection("http://tempuri.org/ITripService/GetTripsForUser", cpr.IncomingSignatureParts, true);
        ApplyProtection("http://tempuri.org/ITripService/GetTripsForUser", cpr.IncomingEncryptionParts, true);
        ApplyProtection("http://tempuri.org/ITripService/UpdateTripDescription", cpr.IncomingSignatureParts, true);
        ApplyProtection("http://tempuri.org/ITripService/UpdateTripDescription", cpr.IncomingEncryptionParts, true);
        ApplyProtection("http://tempuri.org/ITripService/AddPositionNode", cpr.IncomingSignatureParts, true);
        ApplyProtection("http://tempuri.org/ITripService/AddPositionNode", cpr.IncomingEncryptionParts, true);
        ApplyProtection("http://tempuri.org/ITripService/AddManyPositionNodes", cpr.IncomingSignatureParts, true);
        ApplyProtection("http://tempuri.org/ITripService/AddManyPositionNodes", cpr.IncomingEncryptionParts, true);
        ApplyProtection("http://tempuri.org/ITripService/GetPositionNodesForTrip", cpr.IncomingSignatureParts, true);
        ApplyProtection("http://tempuri.org/ITripService/GetPositionNodesForTrip", cpr.IncomingEncryptionParts, true);
        ApplyProtection("http://tempuri.org/ITripService/UpdatePositionNodeDescription", cpr.IncomingSignatureParts, true);
        ApplyProtection("http://tempuri.org/ITripService/UpdatePositionNodeDescription", cpr.IncomingEncryptionParts, true);
        if ((binding.MessageVersion.Addressing == System.ServiceModel.Channels.AddressingVersion.None))
        {
            ApplyProtection("*", cpr.OutgoingSignatureParts, true);
            ApplyProtection("*", cpr.OutgoingEncryptionParts, true);
        }
        else
        {
            ApplyProtection("http://tempuri.org/ITripService/LoginUserResponse", cpr.OutgoingSignatureParts, true);
            ApplyProtection("http://tempuri.org/ITripService/LoginUserResponse", cpr.OutgoingEncryptionParts, true);
            ApplyProtection("http://tempuri.org/ITripService/CreateNewTripResponse", cpr.OutgoingSignatureParts, true);
            ApplyProtection("http://tempuri.org/ITripService/CreateNewTripResponse", cpr.OutgoingEncryptionParts, true);
            ApplyProtection("http://tempuri.org/ITripService/GetAllTripsResponse", cpr.OutgoingSignatureParts, true);
            ApplyProtection("http://tempuri.org/ITripService/GetAllTripsResponse", cpr.OutgoingEncryptionParts, true);
            ApplyProtection("http://tempuri.org/ITripService/GetTripsForUserResponse", cpr.OutgoingSignatureParts, true);
            ApplyProtection("http://tempuri.org/ITripService/GetTripsForUserResponse", cpr.OutgoingEncryptionParts, true);
            ApplyProtection("http://tempuri.org/ITripService/UpdateTripDescriptionResponse", cpr.OutgoingSignatureParts, true);
            ApplyProtection("http://tempuri.org/ITripService/UpdateTripDescriptionResponse", cpr.OutgoingEncryptionParts, true);
            ApplyProtection("http://tempuri.org/ITripService/AddPositionNodeResponse", cpr.OutgoingSignatureParts, true);
            ApplyProtection("http://tempuri.org/ITripService/AddPositionNodeResponse", cpr.OutgoingEncryptionParts, true);
            ApplyProtection("http://tempuri.org/ITripService/AddManyPositionNodesResponse", cpr.OutgoingSignatureParts, true);
            ApplyProtection("http://tempuri.org/ITripService/AddManyPositionNodesResponse", cpr.OutgoingEncryptionParts, true);
            ApplyProtection("http://tempuri.org/ITripService/GetPositionNodesForTripResponse", cpr.OutgoingSignatureParts, true);
            ApplyProtection("http://tempuri.org/ITripService/GetPositionNodesForTripResponse", cpr.OutgoingEncryptionParts, true);
            ApplyProtection("http://tempuri.org/ITripService/UpdatePositionNodeDescriptionResponse", cpr.OutgoingSignatureParts, true);
            ApplyProtection("http://tempuri.org/ITripService/UpdatePositionNodeDescriptionResponse", cpr.OutgoingEncryptionParts, true);
        }
        this.Parameters.Add(cpr);
    }
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
public interface ICrossDomainPolicyResponder
{
    
    System.IO.Stream GetFlashPolicy();
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.Xml.Serialization.XmlRootAttribute(ElementName="GetFlashPolicy", Namespace="http://tempuri.org/")]
public partial class GetFlashPolicyRequest
{
    
    public GetFlashPolicyRequest()
    {
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.Xml.Serialization.XmlRootAttribute(ElementName="GetFlashPolicyResponse", Namespace="http://tempuri.org/")]
public partial class GetFlashPolicyResponse
{
    
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://tempuri.org/", Order=0)]
    public System.IO.Stream GetFlashPolicyResult;
    
    public GetFlashPolicyResponse()
    {
    }
    
    public GetFlashPolicyResponse(System.IO.Stream GetFlashPolicyResult)
    {
        this.GetFlashPolicyResult = GetFlashPolicyResult;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
public partial class CrossDomainPolicyResponderClient : Microsoft.Tools.ServiceModel.CFClientBase<ICrossDomainPolicyResponder>, ICrossDomainPolicyResponder
{
    
    public CrossDomainPolicyResponderClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(binding, remoteAddress)
    {
        addProtectionRequirements(binding);
    }
    
    private GetFlashPolicyResponse GetFlashPolicy(GetFlashPolicyRequest request)
    {
        CFInvokeInfo info = new CFInvokeInfo();
        info.Action = "http://tempuri.org/ICrossDomainPolicyResponder/GetFlashPolicy";
        info.RequestIsWrapped = true;
        info.ReplyAction = "http://tempuri.org/ICrossDomainPolicyResponder/GetFlashPolicyResponse";
        info.ResponseIsWrapped = true;
        GetFlashPolicyResponse retVal = base.Invoke<GetFlashPolicyRequest, GetFlashPolicyResponse>(info, request);
        return retVal;
    }
    
    public System.IO.Stream GetFlashPolicy()
    {
        GetFlashPolicyRequest request = new GetFlashPolicyRequest();
        GetFlashPolicyResponse response = this.GetFlashPolicy(request);
        return response.GetFlashPolicyResult;
    }
    
    private void addProtectionRequirements(System.ServiceModel.Channels.Binding binding)
    {
        if ((IsSecureMessageBinding(binding) == false))
        {
            return;
        }
        System.ServiceModel.Security.ChannelProtectionRequirements cpr = new System.ServiceModel.Security.ChannelProtectionRequirements();
        ApplyProtection("http://tempuri.org/ICrossDomainPolicyResponder/GetFlashPolicy", cpr.IncomingSignatureParts, true);
        ApplyProtection("http://tempuri.org/ICrossDomainPolicyResponder/GetFlashPolicy", cpr.IncomingEncryptionParts, true);
        if ((binding.MessageVersion.Addressing == System.ServiceModel.Channels.AddressingVersion.None))
        {
            ApplyProtection("*", cpr.OutgoingSignatureParts, true);
            ApplyProtection("*", cpr.OutgoingEncryptionParts, true);
        }
        else
        {
            ApplyProtection("http://tempuri.org/ICrossDomainPolicyResponder/GetFlashPolicyResponse", cpr.OutgoingSignatureParts, true);
            ApplyProtection("http://tempuri.org/ICrossDomainPolicyResponder/GetFlashPolicyResponse", cpr.OutgoingEncryptionParts, true);
        }
        this.Parameters.Add(cpr);
    }
}
