namespace SharedLibrary.Models
{
	public class UbigeoItemLite
	{
        /// <summary>
        /// Ejemplo: "PERUANOS RESIDENTES EN EL EXTRANJERO"
        /// </summary>
        public string strDistritoElectoral { get; set; }

        /// <summary>
        /// Ejemplo: "140101"
        /// </summary>
        public string strUbigeoDistritoElectoral { get; set; }
    }

    public class UbigeoItem
    {
        /// <summary>
        /// Ejemplo: "911301"
        /// </summary>
		public string strUbigeo { get; set; }

            /// <summary>
            /// Ejemplo: "91"
            /// </summary>
        public string strUbiDepartamento { get; set; }

        /// <summary>
        /// Ejemplo: "13"
        /// </summary>
        public string strUbiProvincia { get; set; }

        /// <summary>
        /// Ejemplo: "01"
        /// </summary>
        public string strUbiDistrito { get; set; }

        /// <summary>
        /// Ejemplo: "AFRICA"
        /// </summary>
        public string strDepartamento { get; set; }

        /// <summary>
        /// Ejemplo: "ANGOLA"
        /// </summary>
        public string strProvincia { get; set; }

        /// <summary>
        /// Ejemplo: "LUANDA"
        /// </summary>
        public string strDistrito { get; set; }

        /// <summary>
        /// Ejemplo: 1536
        /// </summary>
        public int idJuradoElectoral { get; set; }

        /// <summary>
        /// Ejemplo: "LIMA CENTRO 1"
        /// </summary>
        public string strJuradoElectoral { get; set; }

        /// <summary>
        /// Ejemplo: "PERUANOS RESIDENTES EN EL EXTRANJERO"
        /// </summary>
        public string strDistritoElectoral { get; set; }

        /// <summary>
        /// Ejemplo: "140101"
        /// </summary>
        public string strUbigeoDistritoElectoral { get; set; }

    }
}
