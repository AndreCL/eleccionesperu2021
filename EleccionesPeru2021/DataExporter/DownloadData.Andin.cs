using SharedLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DataExporter
{
	public partial class DownloadData : JneParser
	{
		protected void DownloadAndin()
		{
			var partyData = DownloadPartyData(TipoDeEleccion.Andino, pathAndin, "partidos");

			var candidateData = DownloadCandidateData(partyData, TipoDeEleccion.Andino);

			//todo: hdv
			//todo: download plan de trabajo
			//todo: download resumen de plan de trabajo
		}
	}
}
