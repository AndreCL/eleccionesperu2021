using System.IO;

namespace DataExporter
{
	public class Parser
	{
		protected void CreateDirectory(string path)
		{
			Directory.CreateDirectory(path);
		}

		protected void SaveJsonFile(string path, string filename, string content)
		{
			File.WriteAllText(@$"{path}\{filename}.json", content);
		}
	}
}
