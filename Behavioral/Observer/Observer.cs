using System;
using System.Collections.Generic;
			
namespace ArijitDatta.DesignPatterns.Behavioral.Observer
{
	// The 'Observer' interface
	public interface ISubscriber
	{
		void Notiy(string Message);
	}
	
	// The 'Concrete Observer' class
	public class Subscriber : ISubscriber
	{
		string _name;
		public Subscriber(string name)
		{
			_name = name;
		}
		public void Notiy(string message)
		{
			Console.WriteLine("Hello " + _name+ ", " + message);
		}
	}
	
	// The 'Subject' class
	public abstract class Channel
	{
		protected List<ISubscriber> Subscribers = new List<ISubscriber>();
		
		public void AddSubscribers(ISubscriber subscriber)
		{
			Subscribers.Add(subscriber);
		}
		
		public abstract void NotifySubscribers();
	}
	
	// The 'Concrete Subject' class
	public class WeatherChannel : Channel
	{
		int _temperature;
		public void SetTemperature(int temperature)
		{
			_temperature = temperature;
			NotifySubscribers();
		}
		
		public override void NotifySubscribers()
		{
			foreach (var subscriber in Subscribers)
			{
				subscriber.Notiy("present temparature is " + _temperature + "F");
			}
		}
	}
	
	public class Program
	{
		// Client Code
		public static void Main()
		{
			WeatherChannel channel = new WeatherChannel();
			channel.AddSubscribers(new Subscriber("John"));
			channel.AddSubscribers(new Subscriber("Arya"));
			
			channel.SetTemperature(70);
			Console.WriteLine("---------------------------------------------------");
			channel.SetTemperature(75);
		}
	}
}