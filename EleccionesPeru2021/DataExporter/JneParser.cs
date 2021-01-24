using SharedLibrary.Api;
using SharedLibrary.Models;
using System.Net;

namespace DataExporter
{
	public class JneParser: Parser
	{
		protected static string LoadPartyData(TipoDeEleccion tipoDeEleccion)
		{
			using (WebClient wc = new WebClient())
			{
				return wc.DownloadString(APIOverview.ListaPartidos(tipoDeEleccion));
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
	}
}
