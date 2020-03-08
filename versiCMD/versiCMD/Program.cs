using System;

namespace versiCMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            City c = new City("Bandung", 2000);
            City c2 = new City("Jakarta", 4000, 3);
            c.printCity();
            c2.printCity();
        }
    }
}
