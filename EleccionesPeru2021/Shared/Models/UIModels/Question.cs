using System;
using System.Collections.Generic;

namespace SharedLibrary.Models.UIModels
{
	public class Question
	{
		public string Title { get; set; }

		public string Description { get; set; }

		public List<string> Options { get; set; }

		public Action<string> OnNext { get; set; }

		public void Next(string option)
		{
			OnNext?.Invoke(option);
		}
	}
}
