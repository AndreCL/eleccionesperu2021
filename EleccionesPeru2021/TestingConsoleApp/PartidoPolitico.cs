using System.Collections.Generic;

namespace WebApp.Models
{
	public class PartidoPolitico
	{
		/// <summary>
		/// Ejemplos:
		/// Presidencial: 0
		/// </summary>
		public int idProcesoElectoral { get; set; }

		/// <summary>
		/// Ejemplos:
		/// Presidencial: 2
		/// </summary>
		public int idTipoEleccion { get; set; }

		/// <summary>
		/// null
		/// </summary>
		public string strUbiDepartamento { get; set; }

		/// <summary>
		/// null
		/// </summary>
		public string strUbiProvincia { get; set; }

		/// <summary>
		/// null
		/// </summary>
		public string strUbiDistrito { get; set; }

		/// <summary>
		/// Ejemplo: "LIMA"
		/// </summary>
		public string strRegion { get; set; }

		/// <summary>
		/// Ejemplo: ""
		/// </summary>
		public string strProvincia { get; set; }

		/// <summary>
		/// Ejemplo: ""
		/// </summary>
		public string strDistrito { get; set; }

		/// <summary>
		/// Ejemplo: "140101"
		/// </summary>
		public string strUbigeo { get; set; }

		/// <summary>
		/// Ejemplo: 91103
		/// </summary>
		public int idExpediente { get; set; }

		/// <summary>
		/// Ejemplo: 0
		/// </summary>
		public int nuCorrelativo { get; set; }

		/// <summary>
		/// Ejemplo: "EG.2021004692"
		/// </summary>
		public string strCodExpediente { get; set; }

		/// <summary>
		/// Ejemplo: null
		/// </summary>
		public string strCodExpedientePadre { get; set; }

		/// <summary>
		/// Ejemplo: null
		/// </summary>
		public string strCodigoSolicitud { get; set; }

		/// <summary>
		/// Ejemplo: 5
		/// </summary>
		public int idOrganizacionPolitica { get; set; }

		/// <summary>
		/// Ejemplo: 	"RENACIMIENTO UNIDO NACIONAL"
		/// </summary>
		public string strOrganizacionPolitica { get; set; }

		/// <summary>
		/// Ejemplo: 23039
		/// </summary>
		public int idSolicitudLista { get; set; }

		/// <summary>
		/// Ejemplo: "INSCRITO"
		/// </summary>
		public string strEstadoLista { get; set; }

		/// <summary>
		/// Ejemplo: 0
		/// </summary>
		public int idJuradoElectoral { get; set; }

		/// <summary>
		/// Ejemplo: "LIMA CENTRO 1"
		/// </summary>
		public string strJuradoElectoral { get; set; }

		/// <summary>
		/// Ejemplo: "PARTIDOS POLITICOS"
		/// </summary>
		public string strTipoOrganizacion { get; set; }

		/// <summary>
		/// Ejemplo: 2
		/// </summary>
		public int intCandHombres { get; set; }

		/// <summary>
		/// Ejemplo: 2
		/// </summary>
		public int intCandMujeres { get; set; }

		/// <summary>
		/// Ejemplo: 0
		/// </summary>
		public int intDetalle { get; set; }

		/// <summary>
		/// Ejemplo: ""
		/// </summary>
		public string strRutaArchivo { get; set; }

		/// <summary>
		/// Ejemplo: ""
		/// </summary>
		public string strFGTieneArchivo { get; set; }

		/// <summary>
		/// Ejemplo: 0
		/// </summary>
		public int idPlanGobierno { get; set; }

		/// <summary>
		/// Ejemplo: []
		/// </summary>
		public object[] listaCandidato { get; set; }

		/// <summary>
		/// Ejemplo: "https://declara.jne.gob.pe"
		/// </summary>
		public string strAmbiente { get; set; }

		/// <summary>
		/// Ejemplo: "https://sije.jne.gob.pe"
		/// </summary>
		public string strAmbienteSIJE { get; set; }

		/// <summary>
		/// Ejemplo: "ASSETS/PLANGOBIERNO/FILEPLANGOBIERNO/"
		/// </summary>
		public string strCarpeta { get; set; }

		/// <summary>
		/// Ejemplo: null
		/// </summary>
		public string strImgDetalle { get; set; }

		/// <summary>
		/// Ejemplo: null
		/// </summary>
		public string strclassDetalle { get; set; }

		/// <summary>
		/// Ejemplo: null
		/// </summary>
		public string strclassSinDatos { get; set; }

		/// <summary>
		/// Ejemplo: null
		/// </summary>
		public string strclassLista { get; set; }

		/// <summary>
		/// Ejemplo: null
		/// </summary>
		public string strclassVerPG { get; set; }

		/// <summary>
		/// Ejemplo: null
		/// </summary>
		public string strExistePG { get; set; }

		/// <summary>
		/// Ejemplo: 1536
		/// </summary>
		public int idJuradoUbicacion { get; set; }

		/// <summary>
		/// Ejemplo: "PERUANOS RESIDENTES EN EL EXTRANJERO"
		/// </summary>
		public string strDistritoElec { get; set; } 
	}
}
