using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.IO;
using System.ServiceModel.Web;
using System.Xml.Linq;

namespace TripiWCF.Service
{
    public class TripServiceXml : TripService, ITripService, ICrossDomainPolicyResponder
    {
        #region Private fields
        private static Dictionary<string, string> Users = new Dictionary<string, string>()
        {
            {"Aha", "test"},
            {"Asia", "test"},
            {"Staro", "ble"},
            {"echudzin", "best"}
        };

        private const string DirectoryPrefix = @".\XmlData\";

        private const string TripsFile = DirectoryPrefix + @"UserTrips.xml";

        private static string NodesFile(int tripID)
        {
            return DirectoryPrefix + String.Format(@"Trip{0}.xml", tripID);
        }
        #endregion

        #region Constructor
        public TripServiceXml()
        {
            if (!Directory.Exists(DirectoryPrefix)) Directory.CreateDirectory(DirectoryPrefix);
        }
        #endregion

        #region Xml file helpz0rs
        private static XElement AssureFileExists(string xmlFileName, string rootNodeName)
        {
            if (File.Exists(xmlFileName)) return XElement.Load(xmlFileName, LoadOptions.None);
            else return new XElement(rootNodeName);
        }

        private IEnumerable<XElement> TryLoadElements(string xmlFileName)
        {
            try
            {
                return XElement.Load(xmlFileName, LoadOptions.None).Elements();
            }
            catch (FileNotFoundException exc)
            {
                OnDatabaseQuery("Xml file not created yet: " + exc.FileName);
            }
            catch (System.Xml.XmlException exc)
            {
                OnDatabaseQuery("Error in xml: " + exc.Message);
            }
            catch (DirectoryNotFoundException)
            {
                OnDatabaseQuery("Data directory not created yet!");
            }
            return new List<XElement>();
        }
        #endregion

        #region ITripService - security
        public override string LoginUser(string username, string password)
        {
            OnDatabaseQuery("Login attempt: " + username);
            if (Users.ContainsKey(username) && Users[username] == password) return "luz";
            return "";
        }
        #endregion

        #region ITripService - trips
        public override int CreateNewTrip(string username, string tripName, string tripDescription)
        {
            XElement traps = AssureFileExists(TripsFile, "Trips");
            Trip temp = new Trip(username, TripCount(traps), tripName, tripDescription);
            traps.Add(temp.ToXElement());
            traps.Save(TripsFile);

            OnDatabaseInsert(TripCount(traps), -1);
            return temp.ID;
        }

        public override List<Trip> GetAllTrips()
        {
            List<Trip> tripsFound = new List<Trip>();

            OnDatabaseQuery("Query all trips!");
            foreach (XElement element in TryLoadElements(TripsFile)) tripsFound.Add(new Trip(element));
            
            return tripsFound;
        }

        public override List<Trip> GetTripsForUser(string username)
        {
            List<Trip> tripsFound = new List<Trip>();

            OnDatabaseQuery("Query user: " + username);
            foreach (XElement element in TryLoadElements(TripsFile).Where((XElement elem) => elem.Attribute("username").Value == username)) tripsFound.Add(new Trip(element));

            return tripsFound;
        }

        public override void UpdateTripDescription(int tripID, string tripDescription)
        {
            Func<XElement, bool> idFunc = node => node.Attribute("id").Value.Equals(tripID.ToString());

            XElement trips = AssureFileExists(TripsFile, "Trips");
            IEnumerable<XElement> result = trips.Elements().Where(idFunc);
            if (result.Count() > 0)
            {
                XElement node = result.First();
                node.SetAttributeValue("tripdesc", tripDescription);
            }
            trips.Save(TripsFile);
        }
        #endregion

        #region ITripService - nodes
        public override int AddPositionNode(PositionNode node)
        {
            XElement nodes = AssureFileExists(NodesFile(node.TripID), "Nodes");

            node.OrdinalNumber = PositionNodeCount(nodes);
            nodes.Add(node.ToXElement());
            nodes.Save(NodesFile(node.TripID));

            OnDatabaseInsert(-1, PositionNodeCount(nodes));

            return node.OrdinalNumber;
        }

        public override void AddManyPositionNodes(IEnumerable<PositionNode> nodes)
        {
            XElement nodeXML = AssureFileExists(NodesFile(nodes.First().TripID), "Nodes");

            foreach (PositionNode node in nodes)
            {
                node.OrdinalNumber = PositionNodeCount(nodeXML);
                nodeXML.Add(node.ToXElement());
                nodeXML.Save(NodesFile(node.TripID));
            }

            OnDatabaseInsert(-1, PositionNodeCount(nodeXML));
        }

        public override List<PositionNode> GetPositionNodesForTrip(int tripID)
        {
            List<PositionNode> nodes = new List<PositionNode>();

            OnDatabaseQuery("Query trip: " + tripID);
            foreach (XElement element in TryLoadElements(NodesFile(tripID))) nodes.Add(new PositionNode(element));

            return nodes;
        }

        public override void UpdatePositionNodeDescription(int tripID, int nodeNumber, string nodeDescription)
        {
            Func<XElement, bool> nodeNumberFunc = node => node.Attribute("number").Value.Equals(nodeNumber.ToString());

            XElement positions = AssureFileExists(NodesFile(tripID), "Nodes");
            IEnumerable<XElement> result = positions.Elements().Where(nodeNumberFunc);
            if (result.Count() > 0)
            {
                XElement node = result.First();
                node.SetAttributeValue("description", nodeDescription);
            }
            positions.Save(NodesFile(tripID));
        }
        #endregion

        #region Counts
        public int TripCount(XElement tripRoot)
        {
            return tripRoot.Elements().Count();
        }

        public int PositionNodeCount(XElement positionNodeRoot)
        {
            return positionNodeRoot.Elements().Count();
        }
        #endregion
    }
}
