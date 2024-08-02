using System;
			
namespace ArijitDatta.DesignPatterns.Behavioral.TemplateMethod
{
	// The 'Abstract Class' abstract class
	public abstract class PurchaseProcessor
	{
		public string PurchasedItem { get; set; }
		public double Amount { get; set; }
		public abstract void ProcessPayment();
        public abstract void ShipProduct();
		public void ProcessPurchase()
		{
			ProcessPayment();;
			ShipProduct();
		}
	}
	
	// A 'Concrete Class' class
	public class PhysicalProductPurchaseProcessor : PurchaseProcessor
	{
		public override void ProcessPayment()
		{
			Console.WriteLine(string.Format("Processing payment of ${0} for physical purchase.", Amount.ToString("N2")));
		}
		public override void ShipProduct()
		{
			Console.WriteLine(string.Format("Shipping {0} to customer's address.", PurchasedItem));
		}
	}	
	
	
	// A 'Concrete Class' class
	public class DigitalProductPurchaseProcessor : PurchaseProcessor
	{
		public override void ProcessPayment()
		{
			Console.WriteLine(string.Format("Processing payment of ${0} for digital purchase.", Amount.ToString("N2")));
		}
		public override void ShipProduct()
		{
			Console.WriteLine(string.Format("Sending activation code for {0} to customer via email.", PurchasedItem));
		}
	}
	
	public class Program
	{
		// Client Code
		public static void Main()
		{
			PurchaseProcessor laptop = new PhysicalProductPurchaseProcessor { PurchasedItem = "Laptop", Amount = 445.99 };
			laptop.ProcessPurchase();
			
			Console.WriteLine("---------------------------------------------------");
			
			PurchaseProcessor antivirus = new DigitalProductPurchaseProcessor { PurchasedItem = "Antivirus", Amount = 25.49 };
			antivirus.ProcessPurchase();
		}
	}
}