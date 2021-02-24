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
			var ubigeos = DownloadUbigeoData();
			DownloadCongressPartyData(ubigeos);
		}

		private void DownloadCongressPartyData(List<UbigeoItemLite> ubigeos)
		{
			foreach (var ubigeo in ubigeos)
			{
				var parties = DownloadPartyData(TipoDeEleccion.Congresal, pathCong, 
					$"Party{ubigeo.strUbigeoDistritoElectoral}", ubigeo.strUbigeoDistritoElectoral);
								
				//In here because one file per ubigeo
				var candidates = DownloadCandidateData(parties, TipoDeEleccion.Congresal, pathCong, 
					$"Candidate{ubigeo.strUbigeoDistritoElectoral}");
				DownloadHojaDeVida(candidates, pathCong, $"HDV{ubigeo.strUbigeoDistritoElectoral}");
				DownloadCandidatePictures(candidates);
			}
		}				

		private List<UbigeoItemLite> DownloadUbigeoData()
		{
			var result = new List<UbigeoItemLite>();

			var data = LoadListaDeUbigeo(TipoDeEleccion.Congresal);
			Console.WriteLine("Download ubigeo list");

			var ubigeos = new List<UbigeoItem>();
			ubigeos = DeSerializeUbigeoData(data);
			Console.WriteLine($"Found {ubigeos.Count} ubigeos");

			//Only uniques
			foreach (var item in ubigeos)
			{
				if (result.Count == 0 ||
					!result.Any(x => x.strUbigeoDistritoElectoral.Equals(item.strUbigeoDistritoElectoral,
					StringComparison.InvariantCultureIgnoreCase)))
				{
					result.Add(new UbigeoItemLite
					{
						strDistritoElectoral = item.strDistritoElectoral,
						strUbigeoDistritoElectoral = item.strUbigeoDistritoElectoral
					});
				}
			}
			Console.WriteLine($"Found {result.Count} unique ubigeos");

			SaveJsonFile(pathCong, "ubigeoCon", JsonSerializer.Serialize(result));
			Console.WriteLine("Saved ubigeoCon.json");

			return result;
		}

		private List<UbigeoItem> DeSerializeUbigeoData(string data)
		{
			var requestData = JsonSerializer.Deserialize<APICallList<UbigeoItem>>(data);
			return requestData.Data;
		}
	}
}
