using SharedLibrary.Api;
using SharedLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace DataExporter
{
	public partial class DownloadData : JneParser
	{	

		private readonly string path = "sample-data";
		private readonly string pathPres = "sample-data\\pres";
		private readonly string pathCong = "sample-data\\cong";
		private readonly string pathAndin = "sample-data\\andin";
		private readonly string path2 = "sample-data\\ASSETS\\PLANGOBIERNO\\FILEPLANGOBIERNO";
		private readonly string path3 = "sample-data\\Assets\\Fotos-HojaVida";

		public DownloadData()
		{
			CreateDirectory(path2);
			CreateDirectory(path3);
			CreateDirectory(pathCong);
			CreateDirectory(pathPres);
			CreateDirectory(pathAndin);

			DownloadPresidential();
			//DownloadCongress();
			DownloadAndin();			
		}

		private List<PartidoPolitico> DownloadPartyData(TipoDeEleccion tipoDeEleccion, string outputPath, 
			string outputFilename, string ubigeo = "")
		{
			List<PartidoPolitico> result = new List<PartidoPolitico>();

			var data = LoadPartyData(tipoDeEleccion, ubigeo);
			Console.WriteLine($"Download {tipoDeEleccion} party data");

			result = DeSerializePartyData(data);

			//Remove the ones that are out
			var removed = result.RemoveAll(x =>
				x.strEstadoLista.Equals("IMPROCEDENTE", StringComparison.InvariantCultureIgnoreCase) ||
				x.strEstadoLista.Equals("TACHADO", StringComparison.InvariantCultureIgnoreCase) ||
				x.strEstadoLista.Equals("RENUNCIA", StringComparison.InvariantCultureIgnoreCase) ||
				x.strEstadoLista.Equals("EXCLUSION", StringComparison.InvariantCultureIgnoreCase) ||
				x.strEstadoLista.Equals("RETIRO", StringComparison.InvariantCultureIgnoreCase) ||
				x.strEstadoLista.Equals("INADMISIBLE", StringComparison.InvariantCultureIgnoreCase));

			Console.WriteLine($"Removed {removed} improcendente/tachado/inadmisible parties");

			Console.WriteLine($"Serialize party data {tipoDeEleccion}. Found: {result.Count}");

			SaveJsonFile(outputPath, outputFilename, JsonSerializer.Serialize(result));
			Console.WriteLine($"Saved {outputPath}\\{outputFilename}");

			return result;
		}


		/// <summary>
		/// All saved in same folder
		/// </summary>
		/// <param name="candidatos"></param>
		private void DownloadCandidatePictures(List<CandidatoGeneral> candidatos)
		{
			foreach (var candidato in candidatos)
			{
				DownloadFile(path, $"{candidato.strRutaArchivo}", APIOverview.ImageCandidatos(candidato.strRutaArchivo));
			}
			Console.WriteLine($"Downloaded {candidatos.Count} candidate images");
		}

		protected List<CandidatoGeneral> DownloadCandidateData(List<PartidoPolitico> partidos, TipoDeEleccion tipoDeEleccion, 
			string outputPath, string outputFilename)
		{
			List<CandidatoGeneral> result = new List<CandidatoGeneral>();

			foreach (var partido in partidos)
			{
				var data = LoadCandidateData(partido.idSolicitudLista, partido.idExpediente, tipoDeEleccion);

				var candidates = DeSerializeCandidateData(data);

				//Remove the ones that are out
				var removed = candidates.RemoveAll(x =>
				x.strEstadoExp.Equals("IMPROCEDENTE", StringComparison.InvariantCultureIgnoreCase) ||
				x.strEstadoExp.Equals("TACHADO", StringComparison.InvariantCultureIgnoreCase) ||
				x.strEstadoExp.Equals("INADMISIBLE", StringComparison.InvariantCultureIgnoreCase) ||
				x.strEstadoExp.Equals("RENUNCIA", StringComparison.InvariantCultureIgnoreCase) ||
				x.strEstadoExp.Equals("RETIRO", StringComparison.InvariantCultureIgnoreCase) ||
				x.strEstadoExp.Equals("EXCLUSION", StringComparison.InvariantCultureIgnoreCase));

				Console.WriteLine($"Removed {removed} invalid candidates");

				//fix because dataset has 0 here always
				foreach (var candidate in candidates)
				{
					if(candidate.idOrganizacionPolitica == 0)
					{
						candidate.idOrganizacionPolitica = partido.idOrganizacionPolitica;
					}					
				}

				result.AddRange(candidates);
			}
			Console.WriteLine($"Download & DeSerialize candidate list. Found: {result.Count}");

			SaveJsonFile(outputPath, outputFilename, JsonSerializer.Serialize(result));
			Console.WriteLine($"Saved {outputPath}\\{outputFilename}");

			return result;
		}

		private List<HojaDeVida> DownloadHojaDeVida(List<CandidatoGeneral> candidatos, string outputPath, string outputFilename)
		{
			var result = new List<HojaDeVida>();

			foreach (var candidato in candidatos)
			{
				if (candidato.idHojaVida != 0)
				{
					var data = LoadHojaDeVidaData(candidato.idHojaVida, candidato.idOrganizacionPolitica);
					if (!string.IsNullOrEmpty(data) && !data.StartsWith("{\"data\":null"))
					{
						result.Add(DeSerializeHojasDeVidaData(data));
					}
				}
				else
				{
					Console.WriteLine($"{candidato.strCandidato} has no hoja de vida");
				}
			}
			Console.WriteLine($"Download & DeSerialize hojas de vida. Found: {result.Count}");

			SaveJsonFile(outputPath, outputFilename, JsonSerializer.Serialize(result));
			Console.WriteLine($"Saved {outputPath}\\{outputFilename}");

			return result;
		}

		private List<PlanDeGobierno> DownloadPlanDeGobiernoResumen(List<PartidoPolitico> partidos, 
			string outputPath, string outputFilename)
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

			SaveJsonFile(outputPath, outputFilename, JsonSerializer.Serialize(result));
			Console.WriteLine($"Saved {outputPath}\\{outputFilename}");

			return result;
		}

		/// <summary>
		/// All saved in same folder
		/// </summary>
		/// <param name="partidos"></param>
		private void DownloadPlanDeGobiernoFiles(List<PartidoPolitico> partidos)
		{
			foreach (var partido in partidos)
			{
				if(partido.idPlanGobierno != 0)
				{
					DownloadFile(path, $"{partido.strCarpeta}{partido.idPlanGobierno}.pdf", APIOverview.PlanDeGobiernoFile(partido.strCarpeta, partido.idPlanGobierno));
				}
			}
			Console.WriteLine("Saved presidential plan de gobierno level 0");
		}
	}
}
