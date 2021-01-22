using SharedLibrary.Models;

namespace SharedLibrary
{
	public static class APIOverview
	{
		private static readonly string _nrEleccion = "110";

		public static string ListaPartidos(TipoDeEleccion tipoDeEleccion)
		{
			return $"https://plataformaelectoral.jne.gob.pe/Candidato/GetExpedientesLista/{_nrEleccion}-{(int)tipoDeEleccion}-------0-";
		}

		public static string ListaCandidatos(TipoDeEleccion tipoDeEleccion, int idSolicitudLista, int idExpediente)
		{
			return $"https://plataformaelectoral.jne.gob.pe/Candidato/GetCandidatos/{(int)tipoDeEleccion}-{_nrEleccion}-{idSolicitudLista}-{idExpediente}";
		}

		public static string HojaDeVidaCandidato(int idHojaVida, int idOrganizacionPolitica)
		{
			return $"https://plataformaelectoral.jne.gob.pe/HojaVida/GetHVConsolidado?param={idHojaVida}-0-{idOrganizacionPolitica}-{_nrEleccion}";
		}

		public static string PlanDeGobierno(int idPlanDeGobierno)
		{
			return $"https://plataformaelectoral.jne.gob.pe/Candidato/GetPlanGobiernoById/{idPlanDeGobierno}";
		}
	}
}
