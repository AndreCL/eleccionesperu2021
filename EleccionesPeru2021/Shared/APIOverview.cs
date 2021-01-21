namespace SharedLibrary
{
	public static class APIOverview
	{
		public static string PresidentialURL = "https://plataformaelectoral.jne.gob.pe/Candidato/GetExpedientesLista/110-1-------0-";

		public static string PresidentialDetails (int idSolicitudLista, int idExpediente)
		{
			return $"https://plataformaelectoral.jne.gob.pe/Candidato/GetCandidatos/1-110-{idSolicitudLista}-{idExpediente}";
		}
	}
}
