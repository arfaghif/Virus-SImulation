using System;
using System.Collections;
using System.Collections.Generic;

namespace versiCMD 
{
	public class MyGraph
	{
		private readonly List<City> nodes;
		private readonly List<PairOfCity> edges;
		private Queue<PairOfCity> antrian;
		public MyGraph()
		{
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
		public void run(int T, City A)
		{
			//
		}
	}
}
