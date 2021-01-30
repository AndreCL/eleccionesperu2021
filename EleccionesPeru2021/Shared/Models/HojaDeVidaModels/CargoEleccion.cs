namespace SharedLibrary.Models.HojaDeVidaModels
{
	public class CargoEleccion
	{
		/// <summary>
		/// Ejemplo: 132418
		/// </summary>
		public int idHVCargoEleccion { get; set; }

		/// <summary>
		/// 1: Si, 2: No ha llenado
		/// </summary>
		public string strCargoEleccion { get; set; }

		/// <summary>
		/// Ejemplo: 1
		/// </summary>
		public int intItemCargoEleccion { get; set; }

		/// <summary>
		/// Ejemplo: 0
		/// </summary>
		public int idOrgPolCargoElec { get; set; }

		/// <summary>
		/// Ejemplo: ""
		/// </summary>
		public string strOrgPolCargoElec { get; set; }

		/// <summary>
		/// Ejemplo: ""
		/// </summary>
		public string strAnioCargoElecDesde { get; set; }

		/// <summary>
		/// Ejemplo: ""
		/// </summary>
		public string strAnioCargoElecHasta { get; set; }

		/// <summary>
		/// Ejemplo: 1
		/// </summary>
		public int idEstado { get; set; }

		/// <summary>
		/// Ejemplo: null
		/// </summary>
		public string strUsuario { get; set; }

		/// <summary>
		/// Ejemplo: 0
		/// </summary>
		public int idCargoEleccion { get; set; }

		/// <summary>
		/// Ejemplo: ""
		/// </summary>
		public string strCargoEleccion2 { get; set; }

		/// <summary>
		/// Ejemplo: 134404
		/// </summary>
		public int idHojaVida { get; set; }

		/// <summary>
		/// Ejemplo: null
		/// </summary>
		public string strOrder { get; set; }

		/// <summary>
		/// Ejemplo: ""
		/// </summary>
		public string strComentario { get; set; }
	}
}
