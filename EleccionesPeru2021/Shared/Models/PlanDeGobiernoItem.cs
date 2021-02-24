namespace SharedLibrary.Models
{
	public class PlanDeGobiernoItem
	{
		/// <summary>
		/// Ejemplo: 125569
		/// </summary>
		public int idPlanGobDimension { get; set; }

			/// <summary>
			/// Unico en uso en Plan de trabajo de Parlamento andino
			/// Ejemplo: "PLANIFICACIÓN DEL TERRITORIO, VIVIENDA Y SERVICIOS"
			/// </summary>
		public string strPGProblema { get; set; }

		/// <summary>
		/// Ejemplo: "1. PLANIFICACIÓN TERRITORIAL: USO RACIONAL Y SOSTENIBLE DE NUESTRA GEOGRAFÍA Y NATURALEZA.\n2. 
		/// VIVIENDA DIGNA EN ENTORNOS ESTIMULANTES. (CIUDAD) (VIVIENDA)\n3. SERVICIOS DE TRANSPORTE CON VISIÓN MULTIMODAL 
		/// Y ALCANCE NACIONAL"
		/// </summary>
		public string strPGObjetivo { get; set; }

		/// <summary>
		/// Ejemplo: "1. 15% ADICIONAL AL 2026.\n2. META DE INVERSIÓN ANUAL EN INFRAESTRUCTURA DE 15 MIL MILLONES DE 
		/// SOLES EN EL PERÍODO 2021- 2026.\n3. 100% DE PAVIMENTACIÓN AL 2026.\nDISMINUCIÓN DE 6.3% A 0% AL 2026."
		/// </summary>
		public string strPGMeta { get; set; }

		/// <summary>
		/// Ejemplo: "1. % INCREMENTO DE LA SUPERFICIE AGRÍCOLA CON RIEGO.\n2. NIVEL DE EJECUCIÓN DE PROYECTOS EN 
		/// INFRAESTRUCTURA. \nACCIÓN ESTRATÉGICA: CIERRE DE LA BRECHA DE INFRAESTRUCTURA.\n3. NÚMERO DE RED VIAL 
		/// NACIONAL PAVIMENTADA. PORCENTAJE DE CARGA NO ATENDIDA AL AÑO POR INFRAESTRUCTURA FERROVIARIA DEFICIENTE."
		/// </summary>
		public string strPGIndicador { get; set; }

		/// <summary>
		/// Ejemplo: null
		/// </summary>
		public string strFechaRegistro { get; set; }

		/// <summary>
		/// Ejemplo: null
		/// </summary>
		public string strUsuario { get; set; }

		/// <summary>
		/// Ejemplo: 1
		/// </summary>
		public int idEstado { get; set; }

		/// <summary>
		/// Ejemplo: 3
		/// </summary>
		public int idPGDimension { get; set; }

		/// <summary>
		/// Ejemplo: 0
		/// </summary>
		public int idPlanGobierno { get; set; }

		/// <summary>
		/// Ejemplo: 100
		/// </summary>
		public int intPorcentaje { get; set; }
	}
}
