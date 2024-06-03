using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Priority_Queue;

namespace IOA_Zadanie

{
    internal class Dikstra
    {
        private int inf = Int32.MaxValue;
        public Dikstra()
        {
        }
        private List<int> getSusedia(int stred, ForwardStar star)
        {
            List<int> susedia = new List<int>(star.Nodes.Count - 1);
            int counter = 0;
            //Node v = star.Nodes[stred];
            Edge v = star.Edges[star.Nodes[stred].StartEdge];
            do
            {
                susedia.Add(v.NodeEnd);
                counter++;
            } while ((v = star.getNextEdge(v)) != null);
            return susedia;
        }
        private double calcEuclidianDistance(Node n1, Node n2)
        {
            return Math.Sqrt(Math.Pow((n1.XPos - n2.XPos), 2) + Math.Pow(n1.YPos - n2.YPos, 2));
        }
        public int calculate(int idStartNode, int idEndNode, ForwardStar star, ref int deqCount, ref float dist)
        {
            Dictionary<int, double> distances = new Dictionary<int, double>();
            Dictionary<int, int> previous = new Dictionary<int, int>();
            foreach (Node n in star.Nodes.Values)
            {
                distances.Add(n.NodeId, 0);
                previous.Add(n.NodeId, -1);
            }
            SimplePriorityQueue<int> v = new SimplePriorityQueue<int>();
            foreach (Node n in star.Nodes.Values)
            {
                if (n.NodeId != idStartNode)
                {
                    distances[n.NodeId] = inf;
                }
                v.Enqueue(n.NodeId, (float)distances[n.NodeId]);
            }
            while (v.Count > 0)
            {
                deqCount++;
                int u = v.Dequeue();
                foreach (var i in getSusedia(u, star))
                {
                    double alt = distances[u] + calcEuclidianDistance(star.Nodes[u], star.Nodes[i]);
                    if (alt < distances[i])
                    {
                        distances[i] = alt;
                        previous[i] = u;
                        v.UpdatePriority(i, (float)alt);
                    }
                }
            }
            dist = (float)distances[idEndNode];

            return 0;

        }

    }
}


