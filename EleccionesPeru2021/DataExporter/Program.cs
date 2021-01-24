using System;

namespace DataExporter
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine($"Start: {DateTime.Now}");
			var DownloadData = new DownloadData();

			Console.WriteLine($"End: {DateTime.Now}");
		}
	}
}
