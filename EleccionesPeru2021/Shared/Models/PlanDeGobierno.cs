namespace SharedLibrary.Models
{
	public class PlanDeGobierno
	{
		/// <summary>
		/// Ejemplo: 16521
		/// </summary>
		public int idPlanGobierno { get; set; }

			/// <summary>
			/// Ejemplo: 2840
			/// </summary>
		public int idOrganizacionPolitica { get; set; }

		/// <summary>
		/// Ejemplo: 0
		/// </summary>
		public int idProcesoElectoral { get; set; }

		/// <summary>
		/// Ejemplo: "000000"
		/// </summary>
		public string strUbigeo { get; set; }

		/// <summary>
		/// Ejemplo:	1
		/// </summary>
		public int idTipoEleccion { get; set; }

		/// <summary>
		/// Ejemplo: "0000000284000110"
		/// </summary>
		public string strCodigoRegistroPG { get; set; }

		/// <summary>
		/// Ejemplo: 	"1"
		/// </summary>
		public string strTieneArchivo { get; set; }

		/// <summary>
		/// Ejemplo:	"21/12/2020 11:11:22 p.m."
		/// </summary>
		public string strFechaRegistro { get; set; }

		/// <summary>
		/// Ejemplo: 	null
		/// </summary>
		public string strUsuario { get; set; }

		/// <summary>
		/// Ejemplo: 	1
		/// </summary>
		public int idEstado { get; set; }

		/// <summary>
		/// Ejemplo: 	100
		/// </summary>
		public int intPorcentaje { get; set; }

		/// <summary>
		/// Ejemplo: 	"1"
		/// </summary>
		public string strCompleto { get; set; }

		/// <summary>
		/// Ejemplo: 	26
		/// </summary>
		public int idParamPlanGob { get; set; }

		/// <summary>
		/// Ejemplo: 	"PARTIDO MORADO"
		/// </summary>
		public string strOrganizacionPolitica { get; set; }

		/// <summary>
		/// Ejemplo: 	"PRESIDENCIAL"
		/// </summary>
		public string strTipoEleccion { get; set; }

		/// <summary>
		/// Ejemplo: 	null
		/// </summary>
		public string strEstado { get; set; }

		/// <summary>
		/// Ejemplo: 	null
		/// </summary>
		public string strDepartamento { get; set; }

		/// <summary>
		/// Ejemplo: 	null
		/// </summary>
		public string strProvincia { get; set; }

		/// <summary>
		/// Ejemplo: 	null
		/// </summary>
		public string strDistrito { get; set; }

		/// <summary>
		/// Ejemplo: 	""
		/// </summary>
		public string strDescripcionUbigeo { get; set; }

		/// <summary>
		/// Ejemplo: 	null
		/// </summary>
		public string strParamPlanGob { get; set; }

		/// <summary>
		/// Ejemplo: 	null
		/// </summary>
		public string strArchivo { get; set; }

		/// <summary>
		/// Ejemplo: 	"Plan de gobierno y Anexo 5 final integrado.pdf"
		/// </summary>
		public string strRutaArchivo { get; set; }

		/// <summary>
		/// Ejemplo: 	false
		/// </summary>
		public bool strExisteArchivoFisico { get; set; }

		/// <summary>
		/// Ejemplo: 	false
		/// </summary>
		public bool strPlanGobiernoExistente { get; set; }

		/// <summary>
		/// Ejemplo: "24/01/2021 03:59:53 a.m."
		/// </summary>
		public string strFechaResumenGenerado { get; set; }

		public PlanDeGobiernoItem[] ListPGDSocial { get; set; }

		public PlanDeGobiernoItem[] ListPGDEconomica { get; set; }

		public PlanDeGobiernoItem[] ListPGDAmbiental { get; set; }

		public PlanDeGobiernoItem[] ListPGDInstitucional { get; set; }
	}
}
