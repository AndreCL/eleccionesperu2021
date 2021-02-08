using SharedLibrary.Models;
using SharedLibrary.Api;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;

namespace DataExporter
{
	public partial class DownloadData : JneParser
	{	
		private List<UbigeoItemLite> ubigeosUnique = new List<UbigeoItemLite>();

		private string path = "sample-data";
		private string pathPres = "sample-data\\pres";
		private string pathCong = "sample-data\\cong";
		private string path2 = "sample-data\\ASSETS\\PLANGOBIERNO\\FILEPLANGOBIERNO";
		private string path3 = "sample-data\\Assets\\Fotos-HojaVida";

		public DownloadData()
		{
			CreateDirectory(path2);
			CreateDirectory(path3);
			CreateDirectory(pathCong);
			CreateDirectory(pathPres);

			DownloadPresidential();

			/*Congress*/
			DownloadUbigeoData();
			DownloadCongressPartyData();			
		}		

		private void DownloadCongressPartyData()
		{
			foreach(var item in ubigeosUnique)
			{
				var data = LoadPartyData(TipoDeEleccion.Congresal, item.strUbigeoDistritoElectoral);
				System.Console.WriteLine($"Download congress list {item.strUbigeoDistritoElectoral}");

				var SerialData = DeSerializePartyData(data);

				//Remove the ones that are out
				var removed = SerialData.RemoveAll(x =>
				x.strEstadoLista.Equals("IMPROCEDENTE", System.StringComparison.InvariantCultureIgnoreCase) ||
				x.strEstadoLista.Equals("TACHADO", System.StringComparison.InvariantCultureIgnoreCase) ||
				x.strEstadoLista.Equals("INADMISIBLE", System.StringComparison.InvariantCultureIgnoreCase));

				System.Console.WriteLine($"Removed {removed} invalid parties");

				System.Console.WriteLine($"DeSerialize presidential list level 0. Found: {SerialData.Count}");

				SaveJsonFile(pathCong, $"Party{item.strUbigeoDistritoElectoral}", JsonSerializer.Serialize(SerialData));
				System.Console.WriteLine($"Saved Party{item.strUbigeoDistritoElectoral}");

				//In here because one file per ubigeo
				DownloadCongressCandidateData(SerialData);
			}
		}

		private void DownloadCongressCandidateData(List<PartidoPolitico> partidosPoliticos)
		{
			List<CandidatoGeneral> finalList = new List<CandidatoGeneral>();

			foreach (var i in partidosPoliticos)
			{
				var data = LoadCandidateData(i.idSolicitudLista, i.idExpediente, TipoDeEleccion.Congresal);

				var candidates = DeSerializeCandidateData(data);

				//fix because dataset has 0 here always
				foreach (var candidate in candidates)
				{
					candidate.idOrganizacionPolitica = i.idOrganizacionPolitica;
				}

				finalList.AddRange(candidates);
			}
			System.Console.WriteLine($"Download & DeSerialize congreso list level 1. Found: {finalList.Count}");

			SaveJsonFile(pathCong, $"Candidate{partidosPoliticos[0].strUbigeo}", JsonSerializer.Serialize(finalList));
			System.Console.WriteLine($"Saved Candidate{partidosPoliticos[0].strUbigeo}");

			DownloadCongressCandidatePictures(finalList);

			DownloadCongressHDV(finalList, partidosPoliticos[0].strUbigeo);
		}		

		private void DownloadCongressCandidatePictures(List<CandidatoGeneral> candidatos)
		{
			foreach (var i in candidatos)
			{
				DownloadFile(path, $"{i.strRutaArchivo}", APIOverview.ImageCandidatos(i.strRutaArchivo));
			}
			System.Console.WriteLine("Downloaded congress candidate images");
		}

		private void DownloadCongressHDV(List<CandidatoGeneral> candidatos, string strUbigeo)
		{
			var finalList = new List<HojaDeVida>();

			foreach (var i in candidatos)
			{
				if (i.idHojaVida != 0)
				{
					var data = LoadHojaDeVidaData(i.idHojaVida, i.idOrganizacionPolitica);
					if (!string.IsNullOrEmpty(data) && !data.StartsWith("{\"data\":null"))
					{
						finalList.Add(DeSerializeHojasDeVidaData(data));
					}
				}
				else
				{
					System.Console.WriteLine($"{i.strCandidato} has no hoja de vida");
				}
			}
			System.Console.WriteLine($"Download & DeSerialize hojas de vida. Found: {finalList.Count}");

			SaveJsonFile(pathCong, $"HDV{strUbigeo}", JsonSerializer.Serialize(finalList));
			System.Console.WriteLine($"Saved HDV{strUbigeo}");
		}

		private void DownloadUbigeoData()
		{
			var data = LoadListaDeUbigeo(TipoDeEleccion.Congresal);
			System.Console.WriteLine("Download ubigeo list");

			var ubigeos = new List<UbigeoItem>();
			ubigeos = DeSerializeUbigeoData(data);
			System.Console.WriteLine($"Found {ubigeos.Count} ubigeos");

			//Only uniques
			foreach (var item in ubigeos)
			{
				if (ubigeosUnique.Count == 0 ||
					!ubigeosUnique.Any(x => x.strUbigeoDistritoElectoral.Equals(item.strUbigeoDistritoElectoral,
					System.StringComparison.InvariantCultureIgnoreCase)))
				{
					ubigeosUnique.Add(new UbigeoItemLite
					{
						strDistritoElectoral = item.strDistritoElectoral,
						strUbigeoDistritoElectoral = item.strUbigeoDistritoElectoral
					});
				}
			}
			System.Console.WriteLine($"Found {ubigeosUnique.Count} unique ubigeos");

			SaveJsonFile(pathCong, "ubigeoCon", JsonSerializer.Serialize(ubigeosUnique));
			System.Console.WriteLine("Saved ubigeoCon.json");
		}

		private List<UbigeoItem> DeSerializeUbigeoData(string data)
		{
			var requestData = JsonSerializer.Deserialize<APICallList<UbigeoItem>>(data);
			return requestData.Data;
		}		
	}
}
