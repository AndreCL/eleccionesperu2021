using SharedLibrary.Models;

namespace DataExporter
{
	public partial class DownloadData : JneParser
	{
		protected void DownloadAndin()
		{
			var partyData = DownloadPartyData(TipoDeEleccion.Andino, pathAndin, "partidos");
			var candidateData = DownloadCandidateData(partyData, TipoDeEleccion.Andino, pathAndin, "candidatos");
			DownloadHojaDeVida(candidateData, pathAndin, "hojasDeVida");
			DownloadPlanDeGobiernoResumen(partyData, pathAndin, "planDeGobierno");
			DownloadPlanDeGobiernoFiles(partyData);
			DownloadCandidatePictures(candidateData);
		}
	}
}
