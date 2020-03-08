using System;

namespace versiCMD
{
	static class Constant
	{
		public const double euler = Math.E;
		public const double gamma = 0.25;
	}
	public class City
	{

		private readonly string nama;
		private readonly int populasi;
		private string status;
		public int Status
        {
			get
			{
				switch (status)
				{
					case "Belum diidentifikasi":
						return 0;
						break;
					case "Sedang diidentifikasi":
						return 1;
						break;
					case "Tidak Terinfeksi":
						return 2;
						break;
					default:
						return 3;
						break;
				}
			}
            
			set
            {
					if (value >= 0 && value <= 3)
					{
						switch (value)
						{
							case 0:
								status = "Belum diidentifikasi";
								break;
							case 1:
								status = "Sedang diidentifikasi";
								break;
							case 2:
								status = "Tidak Terinfeksi";
								break;
							case 3:
								status = "Terinfeksi";
								break;
						}
					}
            }
        }
		public int Populasi
		{
			get
			{
				return populasi;
			}
		}


		public City(string nm, int pop)
		{
			nama = nm;
			populasi = pop;
			status = "Belum diidentifikasi";
		}
		public City(string nm, int pop, int stat) 
		{
			nama = nm;
			populasi = pop;
			Status = stat;
		}
		public void printCity()
        {
			Console.WriteLine(nama);
			Console.WriteLine(populasi);
			Console.WriteLine(status);
        }
		
		public double hitungI(int hari_awal, int hari_akhir)
		{
			return populasi / (1 + ((populasi - 1) * Math.Pow(Constant.euler, -1 * Constant.gamma * (hari_akhir - hari_awal))));
		}
	}
}
