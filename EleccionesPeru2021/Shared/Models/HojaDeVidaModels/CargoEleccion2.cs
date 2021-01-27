namespace SharedLibrary.Models.HojaDeVidaModels
{
	public class CargoEleccion2
	{
		/// <summary>
		/// Ejemplo: 	1
		/// </summary>
		public int idCargoEleccion { get; set; }

		/// <summary>
		/// Ejemplo: "PRESIDENTE DE LA REPÚBLICA"
		/// </summary>
		public string strCargoEleccion { get; set; }

		/// <summary>
		/// Ejemplo: 2
		/// </summary>
		public int idEstado { get; set; }

		/// <summary>
		/// Ejemplo: "ACTIVO (U)"
		/// </summary>
		public string strEstado { get; set; }

		/// <summary>
		/// Ejemplo: null
		/// </summary>
		public string strUsuario { get; set; }
	}
}
