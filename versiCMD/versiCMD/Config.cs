using System;
using System.IO;
using System.Collections.Generic;

namespace versiCMD
{
    static class fileDirectory
    {
        public static string populationFile;
        public static string relationFile;
    }

    public class Config
    {
        private readonly string strFilename1;
        private readonly string strFilename2;

        public Config()
        {
            strFilename1 = fileDirectory.populationFile;
            strFilename2 = fileDirectory.relationFile;
        }

        public int JumlahKota()
        {
            StreamReader contentFile = new StreamReader(strFilename1);
            contentFile.BaseStream.Seek(0, SeekOrigin.Begin);
            string contentLine = contentFile.ReadLine();
            string[] kataArray = contentLine.Split(' ');
            contentFile.Close();
            return Convert.ToInt32(kataArray[0]);
        }

        public string KotaSumber()
        {
            StreamReader contentFile = new StreamReader(strFilename1);
            contentFile.BaseStream.Seek(0, SeekOrigin.Begin);
            string contentLine = contentFile.ReadLine();
            string[] kataArray = contentLine.Split(' ');
            contentFile.Close();
            return kataArray[1];
        }

        public List<City> BacaKonfigurasiKota()
        {
            StreamReader contentFile = new StreamReader(strFilename1);
            contentFile.BaseStream.Seek(0, SeekOrigin.Begin);
            string contentLine = contentFile.ReadLine();
            string[] kataArray = contentLine.Split(' ');

            int countCity = Convert.ToInt32(kataArray[0]);

            List<City> daftarKota = new List<City>();

            for (int i = 0; i < countCity; i++)
            {
                contentLine = contentFile.ReadLine();
                kataArray = contentLine.Split(' ');
                City Kota = new City(kataArray[0], Convert.ToInt32(kataArray[1]));
                daftarKota.Add(Kota);
            }

            contentFile.Close();

            return daftarKota;
        }


        public MyGraph BacaKonfigurasi()
        {
            StreamReader contentFile = new StreamReader(strFilename2);
            contentFile.BaseStream.Seek(0, SeekOrigin.Begin);
            string contentLine = contentFile.ReadLine();
            string[] kataArray;

            int countHub = Convert.ToInt32(contentLine);

            MyGraph resultGraph = new MyGraph();

            List<City> daftarKota = BacaKonfigurasiKota();

            List<PairOfCity> daftarHub = new List<PairOfCity>();

            for (int i = 0; i < countHub; i++)
            {
                contentLine = contentFile.ReadLine();
                kataArray = contentLine.Split(' ');
                float TrX = float.Parse(kataArray[2]);
                City KotaA = new City();
                City KotaB = new City();
                foreach (City kota in daftarKota)
                {
                    if (kataArray[0] == kota.Nama)
                    {
                        KotaA = kota;
                    }
                    if (kataArray[1] == kota.Nama)
                    {
                        KotaB = kota;
                    }
                }
                PairOfCity Hub = new PairOfCity(KotaA, KotaB, TrX);
                daftarHub.Add(Hub);
            }

            resultGraph.nodes = daftarKota;
            resultGraph.edges = daftarHub;
            resultGraph.antrian = new Queue<PairOfCity>();

            contentFile.Close();

            return resultGraph;
        }
    }
}
