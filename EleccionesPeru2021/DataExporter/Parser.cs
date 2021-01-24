using System.IO;
using System.Net;

namespace DataExporter
{
	public class Parser
	{
		protected static  void CreateDirectory(string path)
		{
			Directory.CreateDirectory(path);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="path"></param>
		/// <param name="filename">without .json extension</param>
		/// <param name="content"></param>
		protected static void SaveJsonFile(string path, string filename, string content)
		{
			File.WriteAllText(@$"{path}\{filename}.json", content);
		}

		protected static void DownloadFile(string path, string filename, string url)
		{
			using (var client = new WebClient())
			{
				try
				{
					client.DownloadFile(url, $"{path}\\{filename}");
				}
				catch (System.Exception)
				{
					System.Console.WriteLine($"file {url} not found");
				}
				
			}
		}
	}
}
