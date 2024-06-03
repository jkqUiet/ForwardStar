using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOA_Zadanie
{
    internal class ForwardStar
    {

        IDictionary<int, Node> nodes;
        List<Edge> edges;
        //List<Node> nodes;

        internal List<Edge> Edges { get => edges; set => edges = value; }
        internal IDictionary<int, Node> Nodes { get => nodes; set => nodes = value; }

        //internal List<Node> Nodes { get => nodes; set => nodes = value; }
        public ForwardStar()
        {
            Edges = new List<Edge>();
            //Nodes = new List<Node>();
            Nodes = new Dictionary<int, Node>();
        }
        public void addNode(Node node)
        {
            Nodes.Add(node.NodeId, node);
            //Nodes.Add(node);
        }
        public void drawNodes()
        {
            for (int i = 9; i >= 0; i--)
            {
                for (int j = 0; j < 10; j++)
                {
                    int id = -1;
                    foreach(Node node in nodes.Values)
                    {
                        if (node.XPos/10 == j && node.YPos/10 == i)
                        {
                            id = node.NodeId;
                            break;
                        }   
                    }
                    if (id == -1)
                    { System.Diagnostics.Debug.Write("  "); }
                    else
                    {
                        System.Diagnostics.Debug.Write(id + " ");
                    }

                }
                System.Diagnostics.Debug.WriteLine("");
            }
        }
        private double calcEuclidianDistance(Node n1, Node n2) 
        {
            return Math.Sqrt(Math.Pow((n1.XPos - n2.XPos),2) + Math.Pow(n1.YPos - n2.YPos,2));
        }
        private void updateNode(Node varNode)
        {
            if (varNode.StartEdge == -1)
            {
                varNode.StartEdge = edges.Count - 1;
            }
            if (varNode.EndEdge != -1)
            {
                edges[varNode.EndEdge].NextEdge = edges.Count - 1;
            }
            varNode.EndEdge = edges.Count - 1;
        }

        public void addEdge(int start, int end)
        {
            Node vStartNode = Nodes[start];
            Node vEndNode = Nodes[end];
            //Node vStartNode = Nodes.Find(x => x.NodeId == start);
            //Node vEndNode = Nodes.Find(x => x.NodeId == end);
            if (vStartNode == null && vEndNode == null)
            {
                Console.WriteLine("Missing Node!!!");
                return;
            }
            Edge vEdge = new Edge(start, end, calcEuclidianDistance(vStartNode, vEndNode));
            Edges.Add(vEdge);
            updateNode(vStartNode);
           // Edge vEdge2 = new Edge(end, start, calcEuclidianDistance(vStartNode, vEndNode));
           // Edges.Add(vEdge2);
           // updateNode(vEndNode);
       
        }

        public Edge getNextEdge(Edge edge)
        {
            if (edge.NextEdge == -1) return null;
            return edges[edge.NextEdge];
        }
    }
}
