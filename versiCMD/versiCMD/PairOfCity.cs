using System;

namespace versiCMD
{
	public class PairOfCity
	{
		private readonly City cityA;
		private readonly City cityB;
		private readonly int TrAB;
		//private bool cek;
		/*public bool Cek
		 *{
		 *	get
		 *	{
		 *		return cek;
		 *	}
		 *	set
		 *	{
		 *		cek=value;
		 *	}
		 *}
		 */
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
			//cek=false;
		}
		public double hitungSAB(int hari_awal, int hari_akhir)
		{
			return cityA.hitungI(hari_awal, hari_akhir) * TrAB;
		}

		public int kapanterinfeksi(int hari_awal, int hari_akhir)
		{
			if (hitungSAB(hari_awal,hari_akhir) > 1)
			{
				double a= ((Math.Log((cityA.Populasi * TrAB - 1) / (cityA.Populasi - 1), Constant.euler) * -1 / Constant.gamma) + hari_awal) + 1;
				int i;
				for(i=1; i<=Math.Floor(a) + 1 ; i++){
					if (i>a){
						break;
					}
				}
				//cityB.hariTerinfeksi=i+cityA.hariTerinfeksi;
				return i;
			}
			else
			{
				return 0;
			}
		}

	}
}
