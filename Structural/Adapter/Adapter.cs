using System;

namespace ArijitDatta.DesignPatterns.Structural.Adapter
{
	// Target Interface
	public interface IProduct
	{
		void AddToCart();
	}
	public class Product : IProduct
	{
		double ManufacturingCost = 59.67;
		double ProfitPercentage = 33.34;
		public void AddToCart()
		{
			var price = (ManufacturingCost * ProfitPercentage) / 100;
			Console.WriteLine(string.Format("${0} added to shopping cart", price.ToString("N2")));
		}
	}
	
	// Adaptee Class
	public class Service
	{
		double PayPerHour = 24.59;
		double PersonHour = 2.5;
		public double GetServiceCost()
		{
			var cost = PayPerHour * PersonHour;
			return cost;
		}
	}
	
	// Adapter Class
	public class SellableService : IProduct
	{
		private Service service = new Service();
		public void AddToCart()
		{
			var price = service.GetServiceCost();
			Console.WriteLine(string.Format("${0} added to shopping cart", price.ToString("N2")));
		}
	}
	
	public class Program
	{
		// Client Code
		public static void Main()
		{
			IProduct product = new Product();
			product.AddToCart();
			
			IProduct service = new SellableService();
			service.AddToCart();
		}
	}
}