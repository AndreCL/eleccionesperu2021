namespace SharedLibrary.Models.HojaDeVidaModels
{
	public class RenunciaOP
	{
		/// <summary>
		/// Ejemplo: 131960
		/// </summary>
		public int idHVRenunciaOP { get; set; }

		/// <summary>
		/// Ejemplo: "2"
		/// </summary>
		public string strTengoRenunciaOP { get; set; }

		/// <summary>
		/// Ejemplo: 1
		/// </summary>
		public int intItemRenunciaOP { get; set; }

		/// <summary>
		/// Ejemplo: 0
		/// </summary>
		public int idOrgPolRenunciaOP { get; set; }

		/// <summary>
		/// Ejemplo: ""
		/// </summary>
		public string strOrgPolRenunciaOP { get; set; }

		/// <summary>
		/// Ejemplo: ""
		/// </summary>
		public string strAnioRenunciaOP { get; set; }

		/// <summary>
		/// Ejemplo: ""
		/// </summary>
		public string strFechaRegistro { get; set; }

		/// <summary>
		/// Ejemplo: 1
		/// </summary>
		public int idEstado { get; set; }

		/// <summary>
		/// Ejemplo: "74872982"
		/// </summary>
		public string strUsuario { get; set; }

		/// <summary>
		/// Ejemplo: 134404
		/// </summary>
		public int idHojaVida { get; set; }

		/// <summary>
		/// Ejemplo: null
		/// </summary>
		public object cadenaRenuncia { get; set; }
		//todo: Que es?

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
