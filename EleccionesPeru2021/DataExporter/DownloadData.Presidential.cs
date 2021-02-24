using SharedLibrary.Api;
using SharedLibrary.Models;
using System.Collections.Generic;
using System.Text.Json;
using System;

namespace DataExporter
{
	public partial class DownloadData :JneParser
	{
		protected void DownloadPresidential()
		{
			var partidos = DownloadPartyData(TipoDeEleccion.Presidencial, pathPres, "presidentialList0");
			var candidates = DownloadCandidateData(partidos, TipoDeEleccion.Presidencial, pathPres, "presidentialList1");
			var hojasDeVida = DownloadHojaDeVida(candidates, pathPres, "presidentialList2");
			var resumenPlanDeGobierno = DownloadPresidentialPlanDeGobiernoResumen(partidos);
			DownloadPresidentialPlanDeGobiernoFiles(partidos);					
			DownloadCandidatePictures(candidates);			
		}

		private void DownloadPresidentialPlanDeGobiernoFiles(List<PartidoPolitico> partidos)
		{
			foreach (var partido in partidos)
			{
				DownloadFile(path, $"{partido.strCarpeta}{partido.idPlanGobierno}.pdf", APIOverview.PlanDeGobiernoFile(partido.strCarpeta, partido.idPlanGobierno));
			}
			Console.WriteLine("Saved presidential plan de gobierno level 0");
		}

		private List<PlanDeGobierno> DownloadPresidentialPlanDeGobiernoResumen(List<PartidoPolitico> partidos)
		{
			List<PlanDeGobierno> result = new List<PlanDeGobierno>();

			foreach (var partido in partidos)
			{
				var data = LoadPlanDeGobiernoResumenData(partido.idPlanGobierno);
				if (!string.IsNullOrEmpty(data) && !data.StartsWith("{\"data\":null"))
				{
					result.Add(DeSerializePlanDeGobiernoData(data));
				}

			}
			Console.WriteLine($"Download & DeSerialize plandegobierno resumen. Found: {result.Count}");

			SaveJsonFile(pathPres, "planDeGobierno0", JsonSerializer.Serialize(result));
			Console.WriteLine("Saved planDeGobierno0");

			return result;
		}

		private static PlanDeGobierno DeSerializePlanDeGobiernoData(string data)
		{
			var requestData = JsonSerializer.Deserialize<APICallItem<PlanDeGobierno>>(data);
			return requestData.Data;
		}		
	}
}
