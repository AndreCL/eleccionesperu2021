namespace SharedLibrary.Models
{
	public class Result
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string ImageRoute { get; set; }

		public bool Agree { get; set; } = true;

		public double Percentage { 
			get 
			{
				return ((_totalcounter - _disagreecounter) / _totalcounter) * 100;
			} 
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
