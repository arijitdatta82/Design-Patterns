# Observer Design Pattern

## Definition
The Observer design pattern defines a one-to-many dependency between objects so that when one object changes state, all its dependents are notified and updated automatically. 

## Structure
![ScreenShot](/Assets/Images/Observer_UML.jpg)

## Real-Time Code Example
This real time example shows how we can use observer design pattern to implement weather channel. Many people can subscribe to the weather channel. Whenever there is a change in the state of the channel all the subscribers shall be notified.
[source code](Observer.cs)

Subject</b> knows its observers. Any number of Observer objects may observe a subject. It provides an interface for attaching and detaching Observer objects.
```
	public abstract class Channel
	{
		protected List<ISubscriber> Subscribers = new List<ISubscriber>();
		
		public void AddSubscribers(ISubscriber subscriber)
		{
			Subscribers.Add(subscriber);
		}
		
		public abstract void NotifySubscribers();
	}
```

<b>ConcreteSubject</b> stores state of interest to ConcreteObserver and sends a notification to its observers when its state changes.
```
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
```

<b>Observer</b> defines an updating interface for objects that should be notified of changes in a subject.
```
	public interface ISubscriber
	{
		void Notiy(string Message);
	}
```

<b>ConcreteObserver</b> maintains a reference to a ConcreteSubject object and stores state that should stay consistent with the subject's state. It implements the Observer updating interface to keep its state consistent with the subject's
```
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
```

<b>Client Code:</b>
```
    WeatherChannel channel = new WeatherChannel();
    channel.AddSubscribers(new Subscriber("John"));
    channel.AddSubscribers(new Subscriber("Arya"));
    
    channel.SetTemperature(70);
    Console.WriteLine("---------------------------------------------------");
    channel.SetTemperature(75);
```

<b>Output:</b>
```
Hello John, present temparature is 70F
Hello Arya, present temparature is 70F
---------------------------------------------------
Hello John, present temparature is 75F
Hello Arya, present temparature is 75F    
```