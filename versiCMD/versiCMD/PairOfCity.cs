using System;

namespace versiCMD
{
	public class PairOfCity
	{
		private readonly City cityA;
		private readonly City cityB;
		private readonly int TrAB;
		public City CityA
		{
			get
			{
				return cityA;
			}
		}
		public PairOfCity(City a, City b, int tr)
		{
			cityA = a;
			cityB = b;
			TrAB = tr;
		}
		public double hitungSAB(int hari_awal, int hari_akhir)
		{
			return cityA.hitungI(hari_awal, hari_akhir) * TrAB;
		}

		public int kapanterinfeksi(int hari_awal, int hari_akhir)
		{
			if (hitungSAB(hari_awal,hari_akhir) > 1)
			{
				return (int)Math.Floor((Math.Log((cityA.Populasi * TrAB - 1) / (cityA.Populasi - 1), Constant.euler) * -1 / Constant.gamma) + hari_awal) + 1;
			}
			else
			{
				return 0;
			}
		}

	}
}