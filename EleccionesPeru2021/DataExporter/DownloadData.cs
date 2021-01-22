using SharedLibrary.Models;
using System.Net;
using SharedLibrary;
using System.Text.Json;
using System.Collections.Generic;

namespace DataExporter
{
	public class DownloadData : Parser
	{
		private List<PartidoPolitico> PresidentialPartyData = new List<PartidoPolitico>();
		private List<CandidatoGeneral> CandidatoGeneralData = new List<CandidatoGeneral>();

		private string path = "sample-data";
		private string path2 = "sample-data\\ASSETS\\PLANGOBIERNO\\FILEPLANGOBIERNO";
		private string path3 = "sample-data\\Assets\\Fotos-HojaVida";

		public DownloadData()
		{
			CreateDirectory(path2);
			CreateDirectory(path3);
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

			foreach(var i in CandidatoGeneralData)
			{
				DownloadFile(path, $"{i.strRutaArchivo}", $@"https://declara.jne.gob.pe/{i.strRutaArchivo}");
			}
			System.Console.WriteLine("Downloaded presidential candidate images");
		}

		private List<CandidatoGeneral> DeSerializePresidentialCandidateData(string data)
		{
			var requestData = JsonSerializer.Deserialize<APICall<CandidatoGeneral>>(data);
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

			foreach(var i in PresidentialPartyData)
			{
				DownloadFile(path, $"{i.strCarpeta}{i.idPlanGobierno}.pdf", $@"https://declara.jne.gob.pe/{i.strCarpeta}{i.idPlanGobierno}.pdf");
			}
			System.Console.WriteLine("Saved presidential plan de gobierno level 0");

		}

		private List<PartidoPolitico> DeSerializePresidentialPartyData(string data)
		{
			var requestData = JsonSerializer.Deserialize<APICall<PartidoPolitico>>(data);
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
