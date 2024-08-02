using System;
using System.Collections.Generic;
			
namespace ArijitDatta.DesignPatterns.Structural.Flyweight
{
	// Flyweight Interface
	public interface IFurniture 
	{
		void AddToCart();
	}
	
	// Concrete Flyweight Class 1
	public class OfficeChair : IFurniture
	{
		public void AddToCart()
		{
			var price = 149.99;
			Console.WriteLine(string.Format("Office Chair with price ${0} added to cart.", price.ToString("N2")));
			Console.WriteLine("---------------------------------------------------");
		}
	}
	
	// Concrete Flyweight Class 2
	public class GamingChair : IFurniture
	{
		public void AddToCart()
		{
			var price = 124.99;
			Console.WriteLine(string.Format("Gaming Chair with price ${0} added to cart.", price.ToString("N2")));
			Console.WriteLine("---------------------------------------------------");
		}
	}
	
	// Concrete Flyweight Class 3
	public class Desk : IFurniture
	{
		public void AddToCart()
		{
			var price = 199.99;
			Console.WriteLine(string.Format("Desk with price ${0} added to cart.", price.ToString("N2")));
			Console.WriteLine("---------------------------------------------------");
		}
	}
		
	// The 'FlyweightFactory' class
	public class FurnitureFlyweightFactory
	{
		private Dictionary<string, IFurniture> furnitures = new Dictionary<string, IFurniture>();
		
		public IFurniture GetFurniture(string key)
        {
            // Uses "lazy initialization"
            IFurniture furniture = null;
            if (furnitures.ContainsKey(key))
            {
                furniture = furnitures[key];
            }
            else
            {
                switch (key)
                {
                    case "OfficeChair": 
						furniture = new OfficeChair(); 
						break;
                    case "GamingChair": 
						furniture = new GamingChair(); 
						break;
                    case "Desk": 
						furniture = new Desk(); 
						break;
                }
                furnitures.Add(key, furniture);
            }
            return furniture;
        }
	}
	
	public class Program
	{
		// Client Code
		public static void Main()
		{
			var furnitureFlyweightFactory = new FurnitureFlyweightFactory();
			
			var officeChair = furnitureFlyweightFactory.GetFurniture("OfficeChair");
			officeChair.AddToCart();
			
			
			var gamingChair = furnitureFlyweightFactory.GetFurniture("GamingChair");
			gamingChair.AddToCart();
			
			var desk = furnitureFlyweightFactory.GetFurniture("Desk");
			desk.AddToCart();
		}
	}
}