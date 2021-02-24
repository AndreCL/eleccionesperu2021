using SharedLibrary.Models;

namespace DataExporter
{
	public partial class DownloadData : JneParser
	{
		protected void DownloadAndin()
		{
			var partyData = DownloadPartyData(TipoDeEleccion.Andino, pathAndin, "partidos");

			var candidateData = DownloadCandidateData(partyData, TipoDeEleccion.Andino, pathAndin, "candidatos");

			var hojasDeVida = DownloadHojaDeVida(candidateData, pathAndin, "hojasDeVida");

			//todo: download plan de trabajo
			//todo: download resumen de plan de trabajo

			DownloadCandidatePictures(candidateData);
		}
	}
}
