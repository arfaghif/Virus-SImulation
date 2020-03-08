using System;

namespace versiCMD
{
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
		
		
	}
}
