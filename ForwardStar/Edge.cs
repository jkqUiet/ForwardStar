using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOA_Zadanie
{
    internal class Edge
    {
        private int nodeStart;
        private int nodeEnd;
        private double distance;
        private int nextEdge;
        public Edge(int nodeS, int nodeE, double dist)
        {
            NodeStart = nodeS;
            NodeEnd = nodeE;   
            Distance = dist;
            NextEdge = -1;
        }

        public int NodeEnd { get => nodeEnd; set => nodeEnd = value; }
        public int NodeStart { get => nodeStart; set => nodeStart = value; }
        public double Distance { get => distance; set => distance = value; }
        public int NextEdge { get => nextEdge; set => nextEdge = value; }
    }
}
