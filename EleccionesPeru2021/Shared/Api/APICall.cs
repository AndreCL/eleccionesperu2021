using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SharedLibrary.Api
{
	public class APICallList<T>
	{
		[JsonPropertyName("data")]
		public List<T> Data { get; set; }
	}

	public class APICallItem<T>
	{
		[JsonPropertyName("data")]
		public T Data { get; set; }
	}
}
