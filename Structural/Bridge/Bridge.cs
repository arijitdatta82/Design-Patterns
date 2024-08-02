using System;

namespace ArijitDatta.DesignPatterns.Structural.Bridge
{
	// Abstraction 
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
	
	// Refine Abstraction 1
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
	
	// Refine Abstraction 2
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
	
	// Implementer
	public interface IDataSaver
	{
		void save(string info);
	}
	
	// Concrete Implementation 1
	public class RelationalDataSaver : IDataSaver
	{
		public void save(string info)
		{
			Console.WriteLine(info + " saving to relational database.");
		}
	}
	
	// Concrete Implementation 2
	public class NoSQLDataSaver : IDataSaver
	{
		public void save(string info)
		{
			Console.WriteLine(info + " saving to NoSQL database.");
		}
	}
	
	public class Program
	{
		// Client Code
		public static void Main()
		{
			var member = new Member(new RelationalDataSaver()) { ContactInfo = "email: member_abc@xyz.com"};
			member.SaveToDB();
			
			var guest = new Guest(new NoSQLDataSaver()) { ContactInfo = "email: guest_123@xyz.com"};
			guest.SaveToDB();
		}
	}
}