namespace SharedLibrary.Models.HojaDeVidaModels
{
	public class EducacionBasica
	{
		/// <summary>
		/// Ejemplo: 133580
		/// </summary>
		public int idHVEduBasica { get; set; }

			/// <summary>
			/// Ejemplo: "1"
			/// </summary>
		public string strTengoEduBasica { get; set; }

		/// <summary>
		/// Ejemplo: "1"
		/// </summary>
		public string strEduPrimaria { get; set; }

		/// <summary>
		/// Ejemplo: "1"
		/// </summary>
		public string strConcluidoEduPrimaria { get; set; }

		/// <summary>
		/// Ejemplo: "1"
		/// </summary>
		public string strEduSecundaria { get; set; }

		/// <summary>
		/// Ejemplo: "1"
		/// </summary>
		public string strConcluidoEduSecundaria { get; set; }

		/// <summary>
		/// Ejemplo: 1
		/// </summary>
		public int idEstado { get; set; }

		/// <summary>
		/// Ejemplo: null
		/// </summary>
		public string strUsuario { get; set; }

		/// <summary>
		/// Ejemplo: 134404
		/// </summary>
		public int idHojaVida { get; set; }
	}
}
