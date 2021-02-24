using SharedLibrary.Api;
using SharedLibrary.Models;
using System.Collections.Generic;
using System.Text.Json;
using System;

namespace DataExporter
{
	public partial class DownloadData :JneParser
	{
		private List<CandidatoGeneral> CandidatoGeneralData = new List<CandidatoGeneral>();
		private List<PlanDeGobierno> ResumenPlanDeGobierno = new List<PlanDeGobierno>();
		private List<HojaDeVida> HojasDeVida = new List<HojaDeVida>();

		protected void DownloadPresidential()
		{
			var parties = DownloadPartyData(TipoDeEleccion.Presidencial, pathPres, "presidentialList0");
			DownloadPresidentialPlanDeGobiernoFiles(parties);
			DownloadPresidentialPlanDeGobiernoResumen(parties);
			DownloadCandidateData(parties, TipoDeEleccion.Presidencial);
			DownloadPresidentialCandidatePictures();
			DownloadHojaDeVida();
		}

		private void DownloadPresidentialPlanDeGobiernoFiles(List<PartidoPolitico> partidosPoliticos)
		{
			foreach (var i in partidosPoliticos)
			{
				DownloadFile(path, $"{i.strCarpeta}{i.idPlanGobierno}.pdf", APIOverview.PlanDeGobiernoFile(i.strCarpeta, i.idPlanGobierno));
			}
			Console.WriteLine("Saved presidential plan de gobierno level 0");
		}

		private void DownloadPresidentialPlanDeGobiernoResumen(List<PartidoPolitico> partidosPoliticos)
		{
			foreach (var i in partidosPoliticos)
			{
				var data = LoadPlanDeGobiernoResumenData(i.idPlanGobierno);
				if (!string.IsNullOrEmpty(data) && !data.StartsWith("{\"data\":null"))
				{
					ResumenPlanDeGobierno.Add(DeSerializePlanDeGobiernoData(data));
				}

			}
			Console.WriteLine($"Download & DeSerialize plandegobierno resumen. Found: {ResumenPlanDeGobierno.Count}");

			SaveJsonFile(pathPres, "planDeGobierno0", JsonSerializer.Serialize(ResumenPlanDeGobierno));
			Console.WriteLine("Saved planDeGobierno0");
		}

		private static PlanDeGobierno DeSerializePlanDeGobiernoData(string data)
		{
			var requestData = JsonSerializer.Deserialize<APICallItem<PlanDeGobierno>>(data);
			return requestData.Data;
		}

		private void DownloadPresidentialCandidatePictures()
		{
			foreach (var i in CandidatoGeneralData)
			{
				DownloadFile(path, $"{i.strRutaArchivo}", APIOverview.ImageCandidatos(i.strRutaArchivo));
			}
			Console.WriteLine("Downloaded presidential candidate images");
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
					Console.WriteLine($"{i.strCandidato} has no hoja de vida");
				}
			}
			Console.WriteLine($"Download & DeSerialize hojas de vida. Found: {HojasDeVida.Count}");

			SaveJsonFile(pathPres, "presidentialList2", JsonSerializer.Serialize(HojasDeVida));
			Console.WriteLine("Saved presidential hojas de vida (presidentialList2)");
		}

		private static HojaDeVida DeSerializeHojasDeVidaData(string data)
		{
			var requestData = JsonSerializer.Deserialize<APICallItem<HojaDeVida>>(data);
			return requestData.Data;
		}
	}
}
