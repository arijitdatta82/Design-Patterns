using System;
	
namespace ArijitDatta.DesignPatterns.Creational.AbstractFactory
{
	// Product Interface (Abstruct Products)
	public interface IBilling
	{
		void SendBill();
	}
	// Product Interface (Abstruct Products)
	public interface IPromotion
	{
		void SendPromotion();
	}
	// Concrete Product
	public class ElectronicBilling : IBilling
	{
		public void SendBill()
		{
			Console.WriteLine("Bill is sent by email.");
		}
	}
	// Concrete Product
	public class ElectronicPromotion : IPromotion
	{
		public void SendPromotion()
		{
			Console.WriteLine("Promotion is sent by email.");
		}
	}
	// Concrete Product
	public class PhysicalBilling : IBilling
	{
		public void SendBill()
		{
			Console.WriteLine("Bill is sent by physical mail.");
		}
	}
	// Concrete Product
	public class PhysicalPromotion : IPromotion
	{
		public void SendPromotion()
		{
			Console.WriteLine("Promotion is sent by physical mail.");
		}
	}
	
	// Abstract Factory Interface
	interface ISubscriberFactory {
		IBilling CreateBill();
		IPromotion CreatePromotion();
	}
	// Concrete Factory
	public class ElectronicSubscriber : ISubscriberFactory
	{
		public IBilling CreateBill()
		{
			return new ElectronicBilling();
		}
		public IPromotion CreatePromotion()
		{
			return new ElectronicPromotion();
		}
	}
	// Concrete Factory
	public class PhysicalSubscriber : ISubscriberFactory
	{
		public IBilling CreateBill()
		{
			return new PhysicalBilling();
		}
		public IPromotion CreatePromotion()
		{
			return new PhysicalPromotion();
		}
	}
	
	public class Program
	{
		// Client Code
		public static void Main()
		{
			ISubscriberFactory eSubscriber = new ElectronicSubscriber();
			var eBill = eSubscriber.CreateBill();
			eBill.SendBill();
			var ePromotion = eSubscriber.CreatePromotion();
			ePromotion.SendPromotion();
			
			ISubscriberFactory phSubscriber = new PhysicalSubscriber();
			var phBill = phSubscriber.CreateBill();
			phBill.SendBill();
			var phPromotion = phSubscriber.CreatePromotion();
			phPromotion.SendPromotion();
		}
	}
}
