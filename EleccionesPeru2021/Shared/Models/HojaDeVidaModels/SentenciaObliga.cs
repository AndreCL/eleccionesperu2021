namespace SharedLibrary.Models.HojaDeVidaModels
{
	public class SentenciaObliga
	{
		/// <summary>
		/// Ejemplo: 130823
		/// </summary>
		public int idHVSentenciaObliga { get; set; }

		/// <summary>
		/// Ejemplo: "2"
		/// </summary>
		public string strTengoSentenciaObliga { get; set; }

		/// <summary>
		/// Ejemplo: 1
		/// </summary>
		public int intItemSentenciaObliga { get; set; }

		/// <summary>
		/// Ejemplo: 0
		/// </summary>
		public int idParamMateriaSentencia { get; set; }

		/// <summary>
		/// Ejemplo: ""
		/// </summary>
		public string strMateriaSentencia { get; set; }

		/// <summary>
		/// Ejemplo: ""
		/// </summary>
		public string strExpedienteObliga { get; set; }

		/// <summary>
		/// Ejemplo: ""
		/// </summary>
		public string strOrganoJuridicialObliga { get; set; }

		/// <summary>
		/// Ejemplo: ""
		/// </summary>
		public string strFalloObliga { get; set; }

		/// <summary>
		/// Ejemplo: 1
		/// </summary>
		public int idEstado { get; set; }

		/// <summary>
		/// Ejemplo: null
		/// </summary>
		public string strEstado { get; set; }

		/// <summary>
		/// Ejemplo: null
		/// </summary>
		public string strUsuario { get; set; }

		/// <summary>
		/// Ejemplo: 134404
		/// </summary>
		public int idHojaVida { get; set; }

		/// <summary>
		/// Ejemplo: null
		/// </summary>
		public string strOrder { get; set; }
	}
}
