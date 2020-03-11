using System;
using System.Collections;
using System.Collections.Generic;

namespace versiCMD
{
    class Program
    {
        static void Main(string[] args)
        {
            /*            fileDirectory.populationFile = @"C:\Users\Aufa Fadhlurohman\StimaTB2\versiCMD\versiCMD\config\populationConfig.txt";
                        fileDirectory.relationFile = @"C:\Users\Aufa Fadhlurohman\StimaTB2\versiCMD\versiCMD\config\relationConfig.txt";
                        Console.WriteLine("Hello World!");
                        Config set = new Config();
                        MyGraph prosesGraph = new MyGraph(set);
                        foreach (City kota in prosesGraph.nodes)
                        {
                            kota.printCity();
                        }*/
            MyGraph G = new MyGraph();
            
            City A = new City("A", 1000);
            A.Status = 3;
            A.hariTerinfeksi = 0;
            City B = new City("B", 5000);
            City C = new City("C", 1000);
            City D = new City("D", 1000);
            List < City > L = new List<City>();
            L.Add(A);
            L.Add(B);
            L.Add(C);
            L.Add(D);

            G.nodes = L;

            PairOfCity a = new PairOfCity(A, B, (float) 0.2);
            PairOfCity b = new PairOfCity(A, C, (float)0.05);
            PairOfCity c = new PairOfCity(B, A, (float)0.5);
            PairOfCity d = new PairOfCity(B, D, (float)0.75);
            PairOfCity e = new PairOfCity(C, A, (float)0.1);
            PairOfCity f = new PairOfCity(C, B, (float)0.1);
            PairOfCity g = new PairOfCity(D, A, (float)0.5);
            PairOfCity h = new PairOfCity(D, C, (float)0.1);
            List < PairOfCity > P= new List<PairOfCity>();
            P.Add(a);
            P.Add(b);
            P.Add(c);
            P.Add(d);
            P.Add(e);
            P.Add(f);
            P.Add(g);
            P.Add(h);

            G.edges = P;

            Queue<PairOfCity> Q = new Queue<PairOfCity>();
            Q.Enqueue(a);
            Q.Enqueue(b);

            G.antrian = Q;
            a.hitungSAB(0,1000);
            G.run(10);;
/*            Console.WriteLine(Q.Count);
            //Console.WriteLine(a.hitungSAB(0, 1000));

            Queue<int> qt = new Queue<int>();
            qt.Enqueue(1);
            qt.Enqueue(2);
            qt.Enqueue(3);
            int s = qt.Dequeue();
            Console.WriteLine(qt.Count);
            foreach (Object obj in qt)
            {
                Console.WriteLine(obj);
            }

            //G.run(1000);
            foreach (PairOfCity aCity in Q)
            {
                aCity.CityA.printCity();
                aCity.CityB.printCity();
            }*/
            foreach(City aCity in G.nodes)
            {
                aCity.printCity();
            }
        }
    }
}

