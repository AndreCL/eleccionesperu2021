using SharedLibrary.Models;

namespace SharedLibrary.Api
{
	public static class APIOverview
	{
		private static readonly string _nrEleccion = "110";

		public static string ListaPartidos(TipoDeEleccion tipoDeEleccion, string strUbigeo = "")
		{
			return $"https://plataformaelectoral.jne.gob.pe/Candidato/GetExpedientesLista/{_nrEleccion}-{(int)tipoDeEleccion}-{strUbigeo}------0-";
		}

		public static string ListaCandidatos(TipoDeEleccion tipoDeEleccion, int idSolicitudLista, int idExpediente)
		{
			return $"https://plataformaelectoral.jne.gob.pe/Candidato/GetCandidatos/{(int)tipoDeEleccion}-{_nrEleccion}-{idSolicitudLista}-{idExpediente}";
		}

		public static string HojaDeVidaCandidato(int idHojaVida, int idOrganizacionPolitica)
		{
			return $"https://plataformaelectoral.jne.gob.pe/HojaVida/GetHVConsolidado?param={idHojaVida}-0-{idOrganizacionPolitica}-{_nrEleccion}";
		}

		public static string PlanDeGobiernoResumen(int idPlanGobierno)
		{
			return $"https://plataformaelectoral.jne.gob.pe/Candidato/GetPlanGobiernoById/{idPlanGobierno}";
		}

		public static string PlanDeGobiernoFile(string strCarpeta, int idPlanGobierno)
		{
			return $"https://declara.jne.gob.pe/{strCarpeta}{idPlanGobierno}.pdf";
		}

		public static string ImageCandidatos(string strRutaArchivo)
		{
			return $"https://declara.jne.gob.pe/{strRutaArchivo}";
		}

		public static string ListaDeUbigeo(TipoDeEleccion tipoDeEleccion)
		{
			return $"https://plataformaelectoral.jne.gob.pe/JEE/GetUbigeoporJEE?id={(int)tipoDeEleccion}-{_nrEleccion}-0";
		}
	}
}
