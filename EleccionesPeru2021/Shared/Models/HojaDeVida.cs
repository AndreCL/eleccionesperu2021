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

		//todo: Got to here
		//public object oEduTecnico { get; set; }
		//public object oEduNoUniversitaria { get; set; }
		//public object[] lEduUniversitaria { get; set; }
		//public object oEduPosgrago { get; set; }
		//public object[] lCargoPartidario { get; set; }
		//public object[] lCargoEleccion { get; set; }
		//public object[] lRenunciaOP { get; set; }
		//public object[] lSentenciaPenal { get; set; }
		//public object[] lSentenciaObliga { get; set; }
		//public object oIngresos { get; set; }
		//public object[] lBienInmueble { get; set; }
		//public object[] lBienMueble { get; set; }
		//public object[] lBienMuebleOtro { get; set; }
		//public object oInfoAdicional { get; set; }
		//public object[] lCargoElecPostula { get; set; }
		//public object[] lCargoElecHistorico { get; set; }
		//public object[] lAnotacionMarginal { get; set; }
	}
}
