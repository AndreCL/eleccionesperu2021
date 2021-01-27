namespace SharedLibrary.Models.HojaDeVidaModels
{
	public class Ingresos
	{
		/// <summary>
		/// Ejemplo: 132904
		/// </summary>
		public int idHVIngresos { get; set; }

		/// <summary>
		/// Ejemplo: "1"
		/// </summary>
		public string strTengoIngresos { get; set; }

		/// <summary>
		/// Ejemplo: "2019"
		/// </summary>
		public string strAnioIngresos { get; set; }

		/// <summary>
		/// Ejemplo: 0
		/// </summary>
		public decimal decRemuBrutaPublico { get; set; }

		/// <summary>
		/// Ejemplo: 0
		/// </summary>
		public decimal decRemuBrutaPrivado { get; set; }

		/// <summary>
		/// Ejemplo: 0
		/// </summary>
		public decimal decRentaIndividualPublico { get; set; }

		/// <summary>
		/// Ejemplo: 20000
		/// </summary>
		public decimal decRentaIndividualPrivado { get; set; }

		/// <summary>
		/// Ejemplo: 0
		/// </summary>
		public decimal decOtroIngresoPublico { get; set; }

		/// <summary>
		/// Ejemplo: 12000
		/// </summary>
		public decimal decOtroIngresoPrivado { get; set; }

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
