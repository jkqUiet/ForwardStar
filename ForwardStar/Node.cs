using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOA_Zadanie
{
    internal class Node
    {
        int nodeId;
        int xPos;
        int yPos;
        int startEdge;
        int endEdge;
        public Node(int nId, int xP, int yP)
        {
            NodeId = nId;
            XPos = xP;
            YPos = yP;
            StartEdge = -1;
            EndEdge = -1;
        }

        public int NodeId { get => nodeId; set => nodeId = value; }
        public int XPos { get => xPos; set => xPos = value; }
        public int YPos { get => yPos; set => yPos = value; }
        public int StartEdge { get => startEdge; set => startEdge = value; }
        public int EndEdge { get => endEdge; set => endEdge = value; }
    }
}
