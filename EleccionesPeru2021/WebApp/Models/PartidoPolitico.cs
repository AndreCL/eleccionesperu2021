using System.Collections.Generic;

namespace WebApp.Models
{
	public class PartidoPolitico
	{
		/// <summary>
		/// Ejemplos:
		/// Congresal: 0
		/// </summary>
		int idProcesoElectoral { get; set; } 
		
		/// <summary>
		/// Ejemplos:
		/// Congresal: 2
		/// </summary>
		int idTipoEleccion { get; set; } 

		/// <summary>
		/// null
		/// </summary>
		string strUbiDepartamento { get; set; } 

		/// <summary>
		/// null
		/// </summary>
		string strUbiProvincia { get; set; } 

		/// <summary>
		/// null
		/// </summary>
		string strUbiDistrito { get; set; } 

		/// <summary>
		/// Ejemplo: "LIMA"
		/// </summary>
		string strRegion { get; set; } 

		/// <summary>
		/// Ejemplo: ""
		/// </summary>
		string strProvincia { get; set; }

		/// <summary>
		/// Ejemplo: ""
		/// </summary>
		string strDistrito { get; set; }

		/// <summary>
		/// Ejemplo: "140101"
		/// </summary>
		string strUbigeo { get; set; }

		/// <summary>
		/// Ejemplo: 91103
		/// </summary>
		int idExpediente { get; set; } 

		/// <summary>
		/// Ejemplo: 0
		/// </summary>
		int nuCorrelativo { get; set; }

		/// <summary>
		/// Ejemplo: "EG.2021004692"
		/// </summary>
		string strCodExpediente { get; set; } 

		/// <summary>
		/// Ejemplo: null
		/// </summary>
		string strCodExpedientePadre { get; set; } 

		/// <summary>
		/// Ejemplo: null
		/// </summary>
		string strCodigoSolicitud { get; set; }

		/// <summary>
		/// Ejemplo: "RENACIMIENTO UNIDO NACIONAL"
		/// </summary>
		int idOrganizacionPolitica { get; set; }

		/// <summary>
		/// Ejemplo: 23039
		/// </summary>
		int idSolicitudLista { get; set; }

		/// <summary>
		/// Ejemplo: "INSCRITO"
		/// </summary>
		string strEstadoLista { get; set; } 

		/// <summary>
		/// Ejemplo: 0
		/// </summary>
		int idJuradoElectoral { get; set; }

		/// <summary>
		/// Ejemplo: "LIMA CENTRO 1"
		/// </summary>
		string strJuradoElectoral { get; set; }

		/// <summary>
		/// Ejemplo: "PARTIDOS POLITICOS"
		/// </summary>
		string strTipoOrganizacion { get; set; } 

		/// <summary>
		/// Ejemplo: 2
		/// </summary>
		int intCandHombres { get; set; } 

		/// <summary>
		/// Ejemplo: 2
		/// </summary>
		int intCandMujeres { get; set; } 

		/// <summary>
		/// Ejemplo: 0
		/// </summary>
		int intDetalle { get; set; } 

		/// <summary>
		/// Ejemplo: ""
		/// </summary>
		string strRutaArchivo { get; set; } 

		/// <summary>
		/// Ejemplo: ""
		/// </summary>
		string strFGTieneArchivo { get; set; } 

		/// <summary>
		/// Ejemplo: 0
		/// </summary>
		int idPlanGobierno { get; set; }

		/// <summary>
		/// Ejemplo: []
		/// </summary>
		List<string> listaCandidato { get; set; }

		/// <summary>
		/// Ejemplo: "https://declara.jne.gob.pe"
		/// </summary>
		string strAmbiente { get; set; }

		/// <summary>
		/// Ejemplo: "https://sije.jne.gob.pe"
		/// </summary>
		string strAmbienteSIJE { get; set; }

		/// <summary>
		/// Ejemplo: "ASSETS/PLANGOBIERNO/FILEPLANGOBIERNO/"
		/// </summary>
		string strCarpeta { get; set; } 

		/// <summary>
		/// Ejemplo: null
		/// </summary>
		string strImgDetalle { get; set; }

		/// <summary>
		/// Ejemplo: null
		/// </summary>
		string strclassDetalle { get; set; } 

		/// <summary>
		/// Ejemplo: null
		/// </summary>
		string strclassSinDatos { get; set; } 

		/// <summary>
		/// Ejemplo: null
		/// </summary>
		string strclassLista { get; set; }

		/// <summary>
		/// Ejemplo: null
		/// </summary>
		string strclassVerPG { get; set; }

		/// <summary>
		/// Ejemplo: null
		/// </summary>
		string strExistePG { get; set; }

		/// <summary>
		/// Ejemplo: 1536
		/// </summary>
		int idJuradoUbicacion { get; set; }

		/// <summary>
		/// Ejemplo: "PERUANOS RESIDENTES EN EL EXTRANJERO"
		/// </summary>
		string strDistritoElec { get; set; } 
	}
}
