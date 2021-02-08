using SharedLibrary.Api;
using SharedLibrary.Models;
using System.Collections.Generic;
using System.Text.Json;

namespace DataExporter
{
	public partial class DownloadData
	{
		//presidential
		private List<PartidoPolitico> PresidentialPartyData = new List<PartidoPolitico>();
		private List<CandidatoGeneral> CandidatoGeneralData = new List<CandidatoGeneral>();
		private List<PlanDeGobierno> ResumenPlanDeGobierno = new List<PlanDeGobierno>();
		private List<HojaDeVida> HojasDeVida = new List<HojaDeVida>();

		public void DownloadPresidential()
		{
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

			PresidentialPartyData = DeSerializePartyData(data);

			//Remove the ones that are out
			var removed = PresidentialPartyData.RemoveAll(x =>
			x.strEstadoLista.Equals("IMPROCEDENTE", System.StringComparison.InvariantCultureIgnoreCase) ||
			x.strEstadoLista.Equals("TACHADO", System.StringComparison.InvariantCultureIgnoreCase) ||
			x.strEstadoLista.Equals("INADMISIBLE", System.StringComparison.InvariantCultureIgnoreCase));

			System.Console.WriteLine($"Removed {removed} invalid parties");

			System.Console.WriteLine($"DeSerialize presidential list level 0. Found: {PresidentialPartyData.Count}");

			SaveJsonFile(pathPres, "presidentialList0", JsonSerializer.Serialize(PresidentialPartyData));
			System.Console.WriteLine("Saved presidential list level 0");
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
				if (!string.IsNullOrEmpty(data) && !data.StartsWith("{\"data\":null"))
				{
					ResumenPlanDeGobierno.Add(DeSerializePlanDeGobiernoData(data));
				}

			}
			System.Console.WriteLine($"Download & DeSerialize plandegobierno resumen. Found: {ResumenPlanDeGobierno.Count}");

			SaveJsonFile(pathPres, "planDeGobierno0", JsonSerializer.Serialize(ResumenPlanDeGobierno));
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

				var candidates = DeSerializeCandidateData(data);

				//fix because dataset has 0 here always
				foreach (var candidate in candidates)
				{
					candidate.idOrganizacionPolitica = i.idOrganizacionPolitica;
				}

				CandidatoGeneralData.AddRange(candidates);
			}
			System.Console.WriteLine($"Download & DeSerialize presidential list level 1. Found: {CandidatoGeneralData.Count}");

			SaveJsonFile(pathPres, "presidentialList1", JsonSerializer.Serialize(CandidatoGeneralData));
			System.Console.WriteLine("Saved presidential list level 1");
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
				if (i.idHojaVida != 0)
				{
					var data = LoadHojaDeVidaData(i.idHojaVida, i.idOrganizacionPolitica);
					if (!string.IsNullOrEmpty(data) && !data.StartsWith("{\"data\":null"))
					{
						HojasDeVida.Add(DeSerializeHojasDeVidaData(data));
					}
				}
				else
				{
					System.Console.WriteLine($"{i.strCandidato} has no hoja de vida");
				}
			}
			System.Console.WriteLine($"Download & DeSerialize hojas de vida. Found: {HojasDeVida.Count}");

			SaveJsonFile(pathPres, "presidentialList2", JsonSerializer.Serialize(HojasDeVida));
			System.Console.WriteLine("Saved presidential hojas de vida (presidentialList2)");
		}

		private HojaDeVida DeSerializeHojasDeVidaData(string data)
		{
			var requestData = JsonSerializer.Deserialize<APICallItem<HojaDeVida>>(data);
			return requestData.Data;
		}
	}
}
