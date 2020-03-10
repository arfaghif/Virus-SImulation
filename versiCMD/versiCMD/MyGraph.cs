using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace versiCMD
{
	public class MyGraph
	{
		public List<City> nodes;
		public List<PairOfCity> edges;
		public Queue<PairOfCity> antrian;

		public MyGraph()
		{

		}

		public MyGraph(Config Konfigurasi)
		{
			MyGraph res = new MyGraph();
			res = Konfigurasi.BacaKonfigurasi();
			nodes = res.nodes;
			edges = res.edges;
			antrian = res.antrian;
		}

		public List<PairOfCity> cariEdgeA(City a)
		{
			List<PairOfCity> pairOfCities = new List<PairOfCity>();
			foreach (PairOfCity pairOfCity in edges)
			{
				if (a == pairOfCity.CityA)
				{
					pairOfCities.Add(pairOfCity);
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
						{
							if (edgeCityB.CityB.Status != 3)
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
