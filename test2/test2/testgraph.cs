using System;
using Microsoft.Msagl;
namespace test2
{
    class GLEETester
    {
        static void Main(string[] args)
        {
            double w = 10;
            double h = 10;
            MsaglGraph graph = new MsaglGraph();
            Node a = new Node("a", new Ellipse(w, h, new Point()));
            Node b = new Node("b", CurveFactory.CreateBox(w, h, new Point()));
            graph.AddNode(a); graph.AddNode(b);
            Edge e = new Edge(a, b);
            graph.AddEdge(e);
            graph.CalculateLayout();
        }
    }
}