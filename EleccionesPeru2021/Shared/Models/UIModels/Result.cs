﻿namespace SharedLibrary.Models.UIModels
{
	public class Result
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string ImageRoute { get; set; }

		public bool Agree { get; set; } = true;

		public double AgreePercentage { 
			get 
			{
				return ((_totalcounter - _disagreecounter) / _totalcounter) * 100;
			} 
		}

		public void Disqualify()
		{
			_totalcounter += 100;
			_disagreecounter += 100;
		}

		private double _totalcounter;

		private double _disagreecounter;

		public void AddCounter(bool agree)
		{
			_totalcounter++;
			if (!agree)
			{
				Agree = false;
				_disagreecounter++;
			}
		}
	}
}
