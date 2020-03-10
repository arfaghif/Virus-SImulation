using System;

namespace versiCMD
{
	public class PairOfCity
	{
		private readonly City cityA;
		private readonly City cityB;
		private readonly float TrAB;

		public City CityA
		{
			get
			{
				return cityA;
			}
		}
		public City CityB
		{
			get
			{
				return cityB;
			}
		}
		public PairOfCity(City a, City b, float tr)
		{
			cityA = a;
			cityB = b;
			TrAB = tr;
			//cek=false;
		}
		public double hitungSAB(int hari_awal, int hari_akhir)
		{
			return CityA.hitungI(hari_awal, hari_akhir) * TrAB;
		}

		public int kapanterinfeksi(int hari_awal, int hari_akhir)
		{
			if (hitungSAB(hari_awal, hari_akhir) > 1)
			{
				return ((int)Math.Floor((Math.Log(((cityA.Populasi * TrAB) - 1) / (cityA.Populasi - 1), Constant.euler) * -1 / Constant.gamma) + hari_awal)) + 1;
			}
			else
			{
				return 0;
			}
		}

	}
}
