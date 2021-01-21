using SharedLibrary.Models;
using System.Net;
using SharedLibrary;
using System.Text.Json;
using System.Collections.Generic;
using SharedLibrary.ApiCall;

namespace DataExporter
{
	public class DownloadData : Parser
	{
		private List<PartidoPolitico> PresidentialPartyData = new List<PartidoPolitico>();
		private List<CandidatoGeneral> CandidatoGeneralData = new List<CandidatoGeneral>();

		private string path = "sample-data";

		public DownloadData()
		{
			CreateDirectory(path);
			DownloadPresidentialPartyData();
			DownloadPresidentialCandidateData();
		}

		private void DownloadPresidentialCandidateData()

		{

			foreach(var i in PresidentialPartyData)
			{
				var data = loadPresidentialCandidateData(i.idSolicitudLista, i.idExpediente);
				CandidatoGeneralData.AddRange(DeSerializePresidentialCandidateData(data));		
			}
			System.Console.WriteLine($"Download & DeSerialize presidential list level 1. Found: {CandidatoGeneralData.Count}");

			SaveJsonFile(path, "presidentialList1", JsonSerializer.Serialize(CandidatoGeneralData));
			System.Console.WriteLine("Saved presidential list level 1");
		}

		private List<CandidatoGeneral> DeSerializePresidentialCandidateData(string data)
		{
			var requestData = JsonSerializer.Deserialize<APICallCandidatoGeneral>(data);
			return requestData.data;
		}

		private string loadPresidentialCandidateData(int idSolicitudLista, int idExpediente)
		{
			using (WebClient wc = new WebClient())
			{
				return wc.DownloadString(APIOverview.PresidentialDetails(idSolicitudLista, idExpediente));
			}
		}

		private void DownloadPresidentialPartyData()
		{
			var data = loadPresidentialPartyData();
			System.Console.WriteLine("Download presidential list level 0");

			PresidentialPartyData = DeSerializePresidentialPartyData(data);
			System.Console.WriteLine($"DeSerialize presidential list level 0. Found: {PresidentialPartyData.Count}");

			SaveJsonFile(path, "presidentialList0", JsonSerializer.Serialize(PresidentialPartyData));
			System.Console.WriteLine("Saved presidential list level 0");
			
		}

		private List<PartidoPolitico> DeSerializePresidentialPartyData(string data)
		{
			var requestData = JsonSerializer.Deserialize<APICallPartidoPolitico>(data);
			return requestData.data;
		}

		private string loadPresidentialPartyData()
		{
			using (WebClient wc = new WebClient())
			{
				return wc.DownloadString(APIOverview.PresidentialURL);
			}			
		}

		


	}
}
