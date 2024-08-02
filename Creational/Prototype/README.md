# Prototype Design Pattern

## Definition
The prototype design pattern is a creational pattern in software development that allows for the creation of new objects by cloning existing ones.

## Structure
![ScreenShot](/Assets/Images/Prototype_UML.jpg)

## Real-Time Code Example
In this real-time example we first create an object of TVEpisode class. The next object of that class is having all common attributes except the episode name. We are using prototype design pattern to create new objects by cloning from existing object.
[source code](Prototype.cs)

<b>Prototype</b> declares an interface for cloning itself.
```
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
```

<b>ConcretePrototype</b>  implements an operation for cloning itself.
```
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
```

<b>Client Code:</b>
```
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
```

<b>Output:</b>
```
Episode Name: Episode 1: Winter Is Coming
TV-Series Name: Game of Thrones
Season: Season 1
Producer: David Benioff
Broadcasting Network: HBO

Episode Name: Episode 2: The Kingsroad
TV-Series Name: Game of Thrones
Season: Season 1
Producer: David Benioff
Broadcasting Network: HBO    
```
