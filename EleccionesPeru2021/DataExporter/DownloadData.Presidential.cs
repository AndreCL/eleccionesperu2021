using SharedLibrary.Models;

namespace DataExporter
{
	public partial class DownloadData :JneParser
	{
		protected void DownloadPresidential()
		{
			var partidos = DownloadPartyData(TipoDeEleccion.Presidencial, pathPres, "presidentialList0");
			var candidates = DownloadCandidateData(partidos, TipoDeEleccion.Presidencial, pathPres, "presidentialList1");
			DownloadHojaDeVida(candidates, pathPres, "presidentialList2");
			DownloadPlanDeGobiernoResumen(partidos, pathPres, "planDeGobierno0");
			DownloadPlanDeGobiernoFiles(partidos);					
			DownloadCandidatePictures(candidates);			
		}		
	}
}
