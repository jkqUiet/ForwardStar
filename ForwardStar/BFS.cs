using Priority_Queue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace IOA_Zadanie
{
    internal class BFS
    {
        public BFS()
        {
        }
        public int calculate(int idStartNode, int idEndNode, ForwardStar star,ref int deqCount,ref float dist)
        {
            bool[] visited = new bool[star.Nodes.Count];
           
            for (int i = 0; i < visited.Count() - 1; i++) visited[i] = false;
            SimplePriorityQueue<int> v = new Priority_Queue.SimplePriorityQueue<int>();
            v.Enqueue(idStartNode, hFunction(idStartNode, idEndNode, star));
            while (v.Count > 0)
            {
                
                int iVNode = v.Dequeue();               
                deqCount++;
                           
                foreach (var n in getSusedia(iVNode, star))
                {
                    if (!visited[n])
                    {
                        if (n == idEndNode)
                        {
                            dist += hFunction(iVNode, idEndNode, star);
                            return n;
                        }
                        else
                        {
                            visited[n] = true;
                            v.Enqueue(n, hFunction(n, idEndNode, star));
                            
                        }
                    }
                }
                dist += hFunction(iVNode, v.First, star);
            }
            return -1;
        }
        private List<int> getSusedia(int stred, ForwardStar star)
        {
            List<int> susedia = new List<int>(star.Nodes.Count-1);
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

        private float hFunction(int idStartNode, int idEndNode, ForwardStar star)
        { 
            return (float)calcEuclidianDistance(star.Nodes[idStartNode], star.Nodes[idEndNode]);
        }
    }
}
