using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace versiCMD 
{
	public class MyGraph
	{
		private readonly List<City> nodes;
		private readonly List<PairOfCity>  edges;
		private Queue<PairOfCity> antrian;
		
		public MyGraph()
		{
			char infeksi;
			//baca buat nodes
			using (StreamReader reader = new StreamReader("C:\Users\Asus\Documents\GitHub\StimaTB2\versiCMD\versiCMD\adjacent.txt"))
			{
				string line = reader.ReadLine();
				int idx=Convert.ToInt32(line[0].toString());
				infeksi = line[2];
				for (int i=0; i<idx; i++)
				{
					line = reader.ReadLine();
					char city = line[0]; 
					int populasi = Convert.ToInt32(line[2].toString());
					for(int j=3; j<line.Length; j++)
					{
						populasi*=10;
						populasi+=Convert.ToInt32(line[j].toString());
					}
					City a = new City(city,populasi);
					if(city==infeksi)
					{
						a.Status=3;
					}
					nodes.Add(a);
				}
			}
			//baca buat edges
			using (StreamReader reader = new StreamReader("C:\Users\Asus\Documents\GitHub\StimaTB2\versiCMD\versiCMD\adjacent.txt"))
			{
				string line = reader.ReadLine();
				int idx=Convert.ToInt32(line[0].toString());
				for (int i=0; i<idx; i++)
				{
					line = reader.ReadLine(); 
					char a = line[0];
					char b = line[2];
					dobble Tr=Convert.ToInt32(line[4].toString());
					City A;
					City B;
					foreach(City city in nodes)
					{
						if(city.Nama==a)
						{
							A=city;
						}
						else if(city.Nama==b)
						{
							B=city;
						}
					}
					if(Tr!=1)
					{
						for(int j=6; j<line.Length; j++)
						{
							int nilai=Convert.ToInt32(line[j].toString());
							if(nilai!=0)
							{
								for(int k=j+1; k<line.Length; k++)
								{
									nilai*=10;
									nilai+=Convert.ToInt32(line[k].toString());
								}
								for(int k=6; k<line.Length; k++){
									nilai/=10;
								}
								Tr=nilai;
								break;
							}
						}
					}
					PairOfCity C = new PairOfCity(A,B,Tr);
					edges.Add(C);
				}
			}
			foreach(PairOfCity pairOfCity in edges){
				if(edges.CityA==infeksi){
					antrian.Enqueue(pairOfCity);
				}
			}
		}
		public List<PairOfCity> cariEdgeA(City a) {
			List<PairOfCity> pairOfCities = new List<PairOfCity>();
			foreach(PairOfCity pairOfCity in edges)
			{
				if(a == pairOfCity.CityA /*&& !PairOfCity.Cek*/)
				{
					pairOfCities.Add(pairOfCity);
					//pairOfCity.Cek=true;
				}
			}
			return pairOfCities;
		}
		public void run(int hari)
		{
			List<PairOfCity> pairOfCities;
			PairOfCity pairOfCity;
			while (antrian.Count > 0)
			{

				pairOfCity = antrian.Dequeue();
				int kapan = pairOfCity.kapanterinfeksi(pairOfCity.CityA.hariTerinfeksi, hari);
				if (kapan != 0)
				{
					pairOfCity.CityB.hariTerinfeksi = kapan;
					pairOfCity.CityB.Status = 3;
					if (kapan < hari)
					{
						pairOfCities = cariEdgeA(pairOfCity.CityB);
						foreach (PairOfCity edgeCityB in pairOfCities)
						{	if (edgeCityB.CityB.Status != 3)
							{
								antrian.Enqueue(edgeCityB);
								edgeCityB.CityB.Status = 1;
							}
						}
					}
				}
			}
		}
	}
}
