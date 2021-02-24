using SharedLibrary.Api;
using SharedLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace DataExporter
{
	public partial class DownloadData : JneParser
    {
		protected void DownloadCongress()
		{
			DownloadUbigeoData();
			DownloadCongressPartyData();
		}

		private void DownloadCongressPartyData()
		{
			foreach (var item in ubigeosUnique)
			{
				var parties = DownloadPartyData(TipoDeEleccion.Congresal, pathCong, 
					$"Party{item.strUbigeoDistritoElectoral}", item.strUbigeoDistritoElectoral);
								
				//In here because one file per ubigeo
				DownloadCandidateData(parties, TipoDeEleccion.Congresal);
			}
		}

		private void DownloadCongressCandidatePictures(List<CandidatoGeneral> candidatos)
		{
			foreach (var i in candidatos)
			{
				DownloadFile(path, $"{i.strRutaArchivo}", APIOverview.ImageCandidatos(i.strRutaArchivo));
			}
			Console.WriteLine("Downloaded congress candidate images");
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
					Console.WriteLine($"{i.strCandidato} has no hoja de vida");
				}
			}
			Console.WriteLine($"Download & DeSerialize hojas de vida. Found: {finalList.Count}");

			SaveJsonFile(pathCong, $"HDV{strUbigeo}", JsonSerializer.Serialize(finalList));
			Console.WriteLine($"Saved HDV{strUbigeo}");
		}

		private void DownloadUbigeoData()
		{
			var data = LoadListaDeUbigeo(TipoDeEleccion.Congresal);
			Console.WriteLine("Download ubigeo list");

			var ubigeos = new List<UbigeoItem>();
			ubigeos = DeSerializeUbigeoData(data);
			Console.WriteLine($"Found {ubigeos.Count} ubigeos");

			//Only uniques
			foreach (var item in ubigeos)
			{
				if (ubigeosUnique.Count == 0 ||
					!ubigeosUnique.Any(x => x.strUbigeoDistritoElectoral.Equals(item.strUbigeoDistritoElectoral,
					StringComparison.InvariantCultureIgnoreCase)))
				{
					ubigeosUnique.Add(new UbigeoItemLite
					{
						strDistritoElectoral = item.strDistritoElectoral,
						strUbigeoDistritoElectoral = item.strUbigeoDistritoElectoral
					});
				}
			}
			Console.WriteLine($"Found {ubigeosUnique.Count} unique ubigeos");

			SaveJsonFile(pathCong, "ubigeoCon", JsonSerializer.Serialize(ubigeosUnique));
			Console.WriteLine("Saved ubigeoCon.json");
		}

		private List<UbigeoItem> DeSerializeUbigeoData(string data)
		{
			var requestData = JsonSerializer.Deserialize<APICallList<UbigeoItem>>(data);
			return requestData.Data;
		}
	}
}
