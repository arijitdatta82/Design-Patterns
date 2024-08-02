using System;

namespace ArijitDatta.DesignPatterns.Creational.FactoryMethod
{
	// Product Interface
	public interface IProduct
	{
		string PrintProduct();
		void SetPrice(double price);
	}
	
	// Concrete Product
	public class Microwave : IProduct
	{
		private double _price;

		public string PrintProduct()
		{
			return String.Format("Microwave Price: ${0}", _price);
		}

		public void SetPrice(double price)
		{
			_price = price;
		}
	}

	// Concrete Product
	public class Refrigerator : IProduct
	{
		private double _price;

		public string PrintProduct()
		{
			return String.Format("Refrigerator Price: ${0}", _price);
		}

		public void SetPrice(double price)
		{
			_price = price;
		}
	}
	
	// Abstract Factory (Creator)
	public abstract class ProductAbstractFactory
	{
		protected abstract IProduct CreateProduct();

		public IProduct GetProduct() // Factory Method.
		{
			return this.CreateProduct();
		}
	}
	
	// Concrete Factory (Concrete Creator)
	public class MicrowaveConcreteFactory : ProductAbstractFactory
	{
		protected override IProduct CreateProduct()
		{
			IProduct product = new Microwave();
			product.SetPrice(49.49);
			return product;
		}
	}
	
	// Concrete Factory (Concrete Creator)
	public class RefrigeratorConcreteFactory : ProductAbstractFactory
	{
		protected override IProduct CreateProduct()
		{
			IProduct product = new Refrigerator();
			product.SetPrice(399.99);
			return product;
		}
	}

	public class Program
	{
		// Client Code
		public static void Main()
		{
			ProductAbstractFactory microwaveFactory = new MicrowaveConcreteFactory();
			IProduct microwave = microwaveFactory.GetProduct();
			Console.WriteLine(microwave.PrintProduct());
			
			ProductAbstractFactory refrigeratorFactory = new RefrigeratorConcreteFactory();
			IProduct refrigerator = refrigeratorFactory.GetProduct();
			Console.WriteLine(refrigerator.PrintProduct());
		}
	}
}