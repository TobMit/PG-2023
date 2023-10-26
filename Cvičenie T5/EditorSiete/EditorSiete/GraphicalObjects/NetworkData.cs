using System.Runtime.Serialization;
namespace EditorSiete.GraphicalObjects
{

    [DataContract(Name = "NetworkData")]
    public class NetworkData
    {
        [DataMember()]
        private List<NetworkNode> nodes;
        [DataMember()]
        private List<NetworkEdge> edges;

        public List<NetworkEdge> Edges
        {
            get { return edges; }
            private set { }
        }

        public List<NetworkNode> Nodes
        {
            get { return nodes; }
            private set { } 
        }
        public NetworkData()
        {
            nodes = new List<NetworkNode>();
            edges = new List<NetworkEdge>();
        }
    }
}
