using System;
namespace ProductConsole
{
	public class Sales
	{
		public int salesId { get; set; }

		public string name { get; set; }

		public int amount { get; set; }

		public DateTime salesDate { get; set; }

		//public int reportId;

		public void GetSales()
		{
			int[] salesid = new int[2];
			string[] saleName = new string[2];
			salesid[0] = 1;
			salesid[1] = 2;
			saleName[0] = "Keyboard";
			saleName[1] = "Mouse";
		}

		public void GetSalesDetails<T>(T input)
		{
			Console.WriteLine(input);
		}
        
    }
}

