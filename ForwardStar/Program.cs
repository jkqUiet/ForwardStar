namespace IOA_Zadanie
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            //ApplicationConfiguration.Initialize();
            //Application.Run(new Form1());
            Reader r = new Reader();
            ForwardStar star = new ForwardStar();
            r.openFile("vrcholy.txt");
            string line = "";
            char delimeter = ',';
            while ((line = r.read()) != null)
            {
                string[] parameters = line.Split(delimeter);
                star.addNode(new Node(int.Parse(parameters[0]), int.Parse(parameters[1]), int.Parse(parameters[2])));
            }
            r.closeFile();
            r.openFile("hrany.txt");
            while ((line = r.read()) != null)
            {
                string[] parameters = line.Split(delimeter);
                star.addEdge(int.Parse(parameters[0]), int.Parse(parameters[1]));
                star.addEdge(int.Parse(parameters[1]), int.Parse(parameters[0]));

            }
            BFS bf = new BFS();
            float dist = 0;
            int deq = 0;
            bf.calculate(1, 7, star, ref deq, ref dist);
            //Console.WriteLine(deq);
            //Console.WriteLine(dist);

            float dist1 = 0;
            int deq1 = 0;

            
            Dikstra d = new Dikstra();
            d.calculate(1, 7, star, ref deq1, ref dist1);
            //Console.WriteLine(d.calculate(1, 7, star, ref deq, ref dist));
            //Console.WriteLine(deq);
            //Console.WriteLine(dist);

            Console.WriteLine("BFS mal pocet vyberov : " + deq);
            Console.WriteLine("BFS vysla dlzka : " + dist);

            Console.WriteLine();
            Console.WriteLine("Dikstra mal pocet vyberov : " + deq1);
            Console.WriteLine("Dikstra vypocital dlzku : " + dist1);
            Console.WriteLine();
            Console.WriteLine("Vyhodnotenie");
            Console.WriteLine();
            if (deq < deq1) Console.WriteLine("BFS bol lepsi");
            else Console.WriteLine("Dikstra bol lepsi");
            if (deq == deq1) Console.WriteLine("Obidva vysli rovnako narocne.");



            /*  List<Edge> edges = star.Edges;
              foreach (Edge e in edges)
              {
                  System.Diagnostics.Debug.WriteLine(e.NodeStart + " " + e.NodeEnd + " " + e.Distance);
              }

              foreach (Node n in star.Nodes.Values)
              {
                  if (n.StartEdge == -1) continue;
                  Edge v = star.Edges[star.Nodes[n.NodeId].StartEdge];
              System.Diagnostics.Debug.WriteLine("Vypisujem hrany z vrchola " + n.NodeId);
                  do
                  {
                      System.Diagnostics.Debug.WriteLine(v.NodeStart + " " + v.NodeEnd + " " + v.Distance);                  
                  } while ((v = star.getNextEdge(v)) != null);      
             // }
              System.Diagnostics.Debug.WriteLine("");
              star.drawNodes();*/
        }   
    }
}