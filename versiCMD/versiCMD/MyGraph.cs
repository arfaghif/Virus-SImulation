using System;
using System.Collections;
using System.Collections.Generic;

namespace versiCMD 
{
	public class MyGraph
	{
		private readonly List<City> nodes;
		private readonly List<PairOfCity>  edges;
		private Queue<PairOfCity> antrian;
		
		public MyGraph()
		{
			//
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
