using System;

namespace versiCMD
{
    class Program
    {
        static void Main(string[] args)
        {
            fileDirectory.populationFile = @"C:\Users\Aufa Fadhlurohman\StimaTB2\versiCMD\versiCMD\config\populationConfig.txt";
            fileDirectory.relationFile = @"C:\Users\Aufa Fadhlurohman\StimaTB2\versiCMD\versiCMD\config\relationConfig.txt";
            Console.WriteLine("Hello World!");
            Config set = new Config();
            MyGraph prosesGraph = new MyGraph(set);
            foreach (City kota in prosesGraph.nodes)
            {
                kota.printCity();
            }
        }
    }
}

