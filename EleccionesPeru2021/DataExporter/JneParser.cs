using SharedLibrary.Api;
using SharedLibrary.Models;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;

namespace DataExporter
{
	public class JneParser : Parser
	{
		protected static string LoadPartyData(TipoDeEleccion tipoDeEleccion, string strUbigeo = "")
		{
			using (WebClient wc = new WebClient())
			{
				return wc.DownloadString(APIOverview.ListaPartidos(tipoDeEleccion, strUbigeo));
			}
		}

		protected static string LoadCandidateData(int idSolicitudLista, int idExpediente, TipoDeEleccion tipoDeEleccion)
		{
			using (WebClient wc = new WebClient())
			{
				return wc.DownloadString(APIOverview.ListaCandidatos(tipoDeEleccion, idSolicitudLista, idExpediente));
			}
		}

		protected static string LoadPlanDeGobiernoResumenData(int idPlanGobierno)
		{
			using (WebClient wc = new WebClient())
			{
				return wc.DownloadString(APIOverview.PlanDeGobiernoResumen(idPlanGobierno));
			}
		}

		protected static string LoadHojaDeVidaData(int idHojaVida, int idOrganizacionPolitica)
		{
			using (WebClient wc = new WebClient())
			{
				return wc.DownloadString(APIOverview.HojaDeVidaCandidato(idHojaVida, idOrganizacionPolitica));
			}
		}

		protected static string LoadListaDeUbigeo(TipoDeEleccion tipoDeEleccion)
		{
			using (WebClient wc = new WebClient())
			{
				return wc.DownloadString(APIOverview.ListaDeUbigeo(tipoDeEleccion));
			}
		}

		protected List<PartidoPolitico> DeSerializePartyData(string data)
		{
			var requestData = JsonSerializer.Deserialize<APICallList<PartidoPolitico>>(data);
			return requestData.Data;
		}

		protected List<CandidatoGeneral> DeSerializeCandidateData(string data)
		{
			var requestData = JsonSerializer.Deserialize<APICallList<CandidatoGeneral>>(data);
			return requestData.Data;
		}

		protected static HojaDeVida DeSerializeHojasDeVidaData(string data)
		{
			var requestData = JsonSerializer.Deserialize<APICallItem<HojaDeVida>>(data);
			return requestData.Data;
		}

		protected static PlanDeGobierno DeSerializePlanDeGobiernoData(string data)
		{
			var requestData = JsonSerializer.Deserialize<APICallItem<PlanDeGobierno>>(data);
			return requestData.Data;
		}

	}
}
