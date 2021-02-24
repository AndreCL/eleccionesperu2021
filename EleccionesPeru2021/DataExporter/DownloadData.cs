using SharedLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace DataExporter
{
	public partial class DownloadData : JneParser
	{	
		private List<UbigeoItemLite> ubigeosUnique = new List<UbigeoItemLite>();

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
			DownloadCongress();

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

		//todo: Simplify/merge below
		protected List<CandidatoGeneral> DownloadCandidateData(List<PartidoPolitico> partidosPoliticos, TipoDeEleccion tipoDeEleccion)
		{
			List<CandidatoGeneral> finalList = new List<CandidatoGeneral>();

			switch (tipoDeEleccion)
			{
				case TipoDeEleccion.Presidencial:
					foreach (var i in partidosPoliticos)
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
					Console.WriteLine($"Download & DeSerialize presidential list level 1. Found: {CandidatoGeneralData.Count}");

					SaveJsonFile(pathPres, "presidentialList1", JsonSerializer.Serialize(CandidatoGeneralData));
					Console.WriteLine("Saved presidential list level 1");
					break;
				case TipoDeEleccion.Congresal:
					foreach (var i in partidosPoliticos)
					{
						var data = LoadCandidateData(i.idSolicitudLista, i.idExpediente, tipoDeEleccion);

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
							candidate.idOrganizacionPolitica = i.idOrganizacionPolitica;
						}

						finalList.AddRange(candidates);
					}
					Console.WriteLine($"Download & DeSerialize {tipoDeEleccion} list level 1. Found: {finalList.Count}");

					SaveJsonFile(pathCong, $"Candidate{partidosPoliticos[0].strUbigeo}", JsonSerializer.Serialize(finalList));
					Console.WriteLine($"Saved Candidate{partidosPoliticos[0].strUbigeo}");

					DownloadCongressCandidatePictures(finalList);

					DownloadCongressHDV(finalList, partidosPoliticos[0].strUbigeo);
					break;
				case TipoDeEleccion.Andino:
					break;
				default:
					break;
			}

			return finalList;
		}
	}
}
