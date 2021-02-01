using SharedLibrary.Models.HojaDeVidaModels;
using System.Text.Json.Serialization;

namespace SharedLibrary.Models
{
	public class HojaDeVida
	{
		[JsonPropertyName("oDatosPersonales")]
		public DatosPersonales DatosPersonales { get; set; }

		[JsonPropertyName("lExperienciaLaboral")]
		public ExperienciaLaboral[] ExperienciasLaborales { get; set; }

		[JsonPropertyName("oEduBasica")]
		public EducacionBasica EduBasica { get; set; }

		[JsonPropertyName("oEduTecnico")]
		public EducacionTecnica EduTecnico { get; set; }

		[JsonPropertyName("oEduNoUniversitaria")]
		public EducacionNoUniversitaria EduNoUniversitaria { get; set; }

		[JsonPropertyName("lEduUniversitaria")]
		public EducacionUniversitaria[] EduUniversitaria { get; set; }

		[JsonPropertyName("oEduPosgrago")]
		public EducacionPostGrado EduPosgrado { get; set; }

		[JsonPropertyName("lCargoPartidario")]
		public CargoPartidario[] CargoPartidario { get; set; }

		[JsonPropertyName("lCargoEleccion")]
		public CargoEleccion[] CargoEleccion { get; set; }

		/// <summary>
		/// MENCIÓN DE LAS RENUNCIAS EFECTUADAS A OTROS PARTIDOS, 
		/// MOVIMIENTOS DE ALCANCE REGIONAL O DEPARTAMENTAL U 
		/// ORGANIZACIONES POLÍTICAS DE ALCANCE PROVINCIAL Y DISTRITAL DE SER EL CASO
		/// </summary>
		[JsonPropertyName("lRenunciaOP")]
		public RenunciaOP[] RenunciaOP { get; set; }

		[JsonPropertyName("lSentenciaPenal")]
		public SentenciaPenal[] SentenciaPenal { get; set; }

		[JsonPropertyName("lSentenciaObliga")]
		public SentenciaObliga[] SentenciaObliga { get; set; }

		[JsonPropertyName("oIngresos")]
		public Ingresos Ingresos { get; set; }

		[JsonPropertyName("lBienInmueble")]
		public BienInmueble[] BienInmueble { get; set; }

		[JsonPropertyName("lBienMueble")]
		public BienMueble[] BienMueble { get; set; }

		/// <summary>
		/// En presidencial ha estado siempre vacío
		/// </summary>
		[JsonPropertyName("lBienMuebleOtro")]
		public object[] BienMuebleOtro { get; set; }		

		[JsonPropertyName("oInfoAdicional")]
		public InfoAdicional InfoAdicional { get; set; }

		[JsonPropertyName("lCargoElecPostula")]
		public CargoEleccion2[] CargoElecPostula { get; set; }

		[JsonPropertyName("lCargoElecHistorico")]
		public CargoEleccion2[] CargoElecHistorico { get; set; }

		public object[] lAnotacionMarginal { get; set; }
		//todo: que es?
	}
}
