using SharedLibrary.Models;
using SharedLibrary.Api;
using System.Text.Json;
using System.Collections.Generic;

namespace DataExporter
{
	public class DownloadData : JneParser
	{
		private List<PartidoPolitico> PresidentialPartyData = new List<PartidoPolitico>();
		private List<CandidatoGeneral> CandidatoGeneralData = new List<CandidatoGeneral>();
		private List<PlanDeGobierno> ResumenPlanDeGobierno = new List<PlanDeGobierno>();
		private List<HojaDeVida> HojasDeVida = new List<HojaDeVida>();

		private string path = "sample-data";
		private string path2 = "sample-data\\ASSETS\\PLANGOBIERNO\\FILEPLANGOBIERNO";
		private string path3 = "sample-data\\Assets\\Fotos-HojaVida";

		public DownloadData()
		{
			CreateDirectory(path2);
			CreateDirectory(path3);
			DownloadPresidentialPartyData();
			DownloadPresidentialPlanDeGobiernoFiles();
			DownloadPresidentialPlanDeGobiernoResumen();
			DownloadPresidentialCandidateData();
			DownloadPresidentialCandidatePictures();
			DownloadHojaDeVida();
		}		

		private void DownloadPresidentialPartyData()
		{
			var data = LoadPartyData(TipoDeEleccion.Presidencial);
			System.Console.WriteLine("Download presidential list level 0");

			PresidentialPartyData = DeSerializePresidentialPartyData(data);
			System.Console.WriteLine($"DeSerialize presidential list level 0. Found: {PresidentialPartyData.Count}");

			SaveJsonFile(path, "presidentialList0", JsonSerializer.Serialize(PresidentialPartyData));
			System.Console.WriteLine("Saved presidential list level 0");			
		}

		private List<PartidoPolitico> DeSerializePresidentialPartyData(string data)
		{
			var requestData = JsonSerializer.Deserialize<APICallList<PartidoPolitico>>(data);
			return requestData.Data;
		}

		private void DownloadPresidentialPlanDeGobiernoFiles()
		{
			foreach (var i in PresidentialPartyData)
			{
				DownloadFile(path, $"{i.strCarpeta}{i.idPlanGobierno}.pdf", APIOverview.PlanDeGobiernoFile(i.strCarpeta, i.idPlanGobierno));
			}
			System.Console.WriteLine("Saved presidential plan de gobierno level 0");
		}

		private void DownloadPresidentialPlanDeGobiernoResumen()
		{
			foreach (var i in PresidentialPartyData)
			{
				var data = LoadPlanDeGobiernoResumenData(i.idPlanGobierno);
				ResumenPlanDeGobierno.Add(DeSerializePlanDeGobiernoData(data));
			}
			System.Console.WriteLine($"Download & DeSerialize plandegobierno resumen. Found: {ResumenPlanDeGobierno.Count}");

			SaveJsonFile(path, "planDeGobierno0", JsonSerializer.Serialize(ResumenPlanDeGobierno));
			System.Console.WriteLine("Saved planDeGobierno0");
		}

		private static PlanDeGobierno DeSerializePlanDeGobiernoData(string data)
		{
			var requestData = JsonSerializer.Deserialize<APICallItem<PlanDeGobierno>>(data);
			return requestData.Data;
		}

		private void DownloadPresidentialCandidateData()
		{
			foreach (var i in PresidentialPartyData)
			{
				var data = LoadCandidateData(i.idSolicitudLista, i.idExpediente, TipoDeEleccion.Presidencial);

				var candidates = DeSerializePresidentialCandidateData(data);

				//fix because dataset has 0 here always
				foreach(var candidate in candidates)
				{
					candidate.idOrganizacionPolitica = i.idOrganizacionPolitica;
				}

				CandidatoGeneralData.AddRange(candidates);
			}
			System.Console.WriteLine($"Download & DeSerialize presidential list level 1. Found: {CandidatoGeneralData.Count}");

			SaveJsonFile(path, "presidentialList1", JsonSerializer.Serialize(CandidatoGeneralData));
			System.Console.WriteLine("Saved presidential list level 1");
		}		

		private List<CandidatoGeneral> DeSerializePresidentialCandidateData(string data)
		{
			var requestData = JsonSerializer.Deserialize<APICallList<CandidatoGeneral>>(data);
			return requestData.Data;
		}

		private void DownloadPresidentialCandidatePictures()
		{
			foreach (var i in CandidatoGeneralData)
			{
				DownloadFile(path, $"{i.strRutaArchivo}", APIOverview.ImageCandidatos(i.strRutaArchivo));
			}
			System.Console.WriteLine("Downloaded presidential candidate images");
		}

		private void DownloadHojaDeVida()
		{
			foreach (var i in CandidatoGeneralData)
			{
				var data = LoadHojaDeVidaData(i.idHojaVida, i.idOrganizacionPolitica);
				if (!string.IsNullOrEmpty(data))
				{
					HojasDeVida.Add(DeSerializeHojasDeVidaData(data));
				}					
			}
			System.Console.WriteLine($"Download & DeSerialize hojas de vida. Found: {HojasDeVida.Count}");

			SaveJsonFile(path, "presidentialList2", JsonSerializer.Serialize(HojasDeVida));
			System.Console.WriteLine("Saved presidential hojas de vida (presidentialList2)");
		}

		private HojaDeVida DeSerializeHojasDeVidaData(string data)
		{
			var requestData = JsonSerializer.Deserialize<APICallItem<HojaDeVida>>(data);
			return requestData.Data;
		}
	}
}
