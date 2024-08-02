# Bridge Design Pattern

## Definition
The bridge pattern is a structural design pattern that is meant to decouple an abstraction from its implementation so that the two can vary independently.

## Structure
![ScreenShot](/Assets/Images/Bridge_UML.jpg)

## Real-Time Code Example
In this real-time example we are using bridge design pattern to save customer data. Customer can be either a member or a guest. In this example we are saving member information to a relational database and guest information in a no-sql database. 
[source code](Bridge.cs)

<b>Abstraction</b> defines the abstraction's interface and maintains a reference to an object of type Implementor.
```
	public abstract class Customer
	{
		protected IDataSaver _dataSaver;
		public string ContactInfo { get; set; }
		public Customer(IDataSaver dataSaver)
		{
			_dataSaver = dataSaver;
		}
		public abstract void SaveToDB();
	}
```

<b>RefinedAbstraction</b> extends the interface defined by Abstraction.
```
	public class Member : Customer
	{
		public Member(IDataSaver dataSaver) : base (dataSaver)
		{
		}
		public override void SaveToDB()
		{
			var message = "Member info " + ContactInfo;
			_dataSaver.save(message);
		}
	}
	
	public class Guest : Customer
	{
		public Guest(IDataSaver dataSaver) : base (dataSaver)
		{
		}
		public override void SaveToDB()
		{
			var message = "Guest info " + ContactInfo;
			_dataSaver.save(message);
		}
	}
```

<b>Implementor</b> defines the interface for implementation classes. This interface doesn't have to correspond exactly to Abstraction's interface; in fact the two interfaces can be quite different. Typically the Implementation interface provides only primitive operations, and Abstraction defines higher-level operations based on these primitives.
```
    public interface IDataSaver
	{
		void save(string info);
	}
```

<b>ConcreteImplementor</b> implements the Implementor interface and defines its concrete implementation.
```
	public class RelationalDataSaver : IDataSaver
	{
		public void save(string info)
		{
			Console.WriteLine(info + " saving to relational database.");
		}
	}

	public class NoSQLDataSaver : IDataSaver
	{
		public void save(string info)
		{
			Console.WriteLine(info + " saving to NoSQL database.");
		}
	}
```

<b>Client Code:</b>
```
    var member = new Member(new RelationalDataSaver()) { ContactInfo = "email: member_abc@xyz.com"};
    member.SaveToDB();
    
    var guest = new Guest(new NoSQLDataSaver()) { ContactInfo = "email: guest_123@xyz.com"};
    guest.SaveToDB();
```

<b>Output:</b>
```
Member info email: member_abc@xyz.com saving to relational database.
Guest info email: guest_123@xyz.com saving to NoSQL database.    
```
