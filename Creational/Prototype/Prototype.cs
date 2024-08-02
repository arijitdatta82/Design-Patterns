using System;

namespace ArijitDatta.DesignPatterns.Creational.Prototype
{
	// Abstruct Prototype
	public abstract class AbstructTVEpisode
	{
		public string EpisodeName { get; set; }
		public string TVSeriesName { get; set; }
		public string Season { get; set; }
		public string ProducerName { get; set; }
		public string BroadcastingNetwork { get; set; }
		public abstract AbstructTVEpisode CloneEpisode(string episodeName);
		public void PrintEpisode()
		{
			Console.WriteLine("Episode Name: " + EpisodeName);
			Console.WriteLine("TV-Series Name: " + TVSeriesName);
			Console.WriteLine("Season: " + Season);
			Console.WriteLine("Producer: " + ProducerName);
			Console.WriteLine("Broadcasting Network: " + BroadcastingNetwork);
			Console.WriteLine("");
		}
	}
	
	// Concrete Prototype
	public class TVEpisode : AbstructTVEpisode
	{
		// Clone Method
		public override AbstructTVEpisode CloneEpisode(string episodeName)
        {    
            var newEpisode = this.MemberwiseClone() as AbstructTVEpisode;
			newEpisode.EpisodeName = episodeName;
			return newEpisode;
        }
	}

	public class Program
	{
        // Client Code
		public static void Main()
		{
			var episode1 = new TVEpisode
			{
				EpisodeName = "Episode 1: Winter Is Coming",
				TVSeriesName = "Game of Thrones",
				Season = "Season 1",
				ProducerName = "David Benioff",
				BroadcastingNetwork = "HBO"
			};
			
			// Call Clone Method
			var episode2 = episode1.CloneEpisode("Episode 2: The Kingsroad");
			
			episode1.PrintEpisode();
			episode2.PrintEpisode();
		}
	}
}