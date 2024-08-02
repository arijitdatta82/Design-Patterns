# Factory Method Design Pattern

## Definition
Define an interface for creating an object, but let subclasses decide which class to instantiate. The Factory method lets a class defer instantiation it uses to subclasses.

## Structure
![ScreenShot](/Assets/Images/Factory_Method_UML.jpg)

## Real-Time Code Example
In this real time example, we are using factory method design patter. We have multiple products inherited from IProduct interface. We are using factory method 'GetProduct()' to create an instance of the product.
[source code](FactoryMethod.cs)

<b>Product</b> defines the interface of objects the factory method creates.
```
    public interface IProduct
	{
		string PrintProduct();
		void SetPrice(double price);
	}
```

<b>ConcreteProduct</b> implements the Product interface.
```
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
```

<b>Creator</b> declares the factory method, which returns an object of type Product. Creator may also define a default implementation of the factory method that returns a default ConcreteProduct object.
```
    public abstract class ProductAbstractFactory
	{
		protected abstract IProduct CreateProduct();

		public IProduct GetProduct() // Factory Method.
		{
			return this.CreateProduct();
		}
	}
```

<b>ConcreteCreator</b> overrides the factory method to return an instance of a ConcreteProduct.
```
	public class MicrowaveConcreteFactory : ProductAbstractFactory
	{
		protected override IProduct CreateProduct()
		{
			IProduct product = new Microwave();
			product.SetPrice(49.49);
			return product;
		}
	}
```
<b>Client Code:</b>
```
	ProductAbstractFactory microwaveFactory = new MicrowaveConcreteFactory();
	IProduct microwave = microwaveFactory.GetProduct();
	Console.WriteLine(microwave.PrintProduct());
	
	ProductAbstractFactory refrigeratorFactory = new RefrigeratorConcreteFactory();
	IProduct refrigerator = refrigeratorFactory.GetProduct();
	Console.WriteLine(refrigerator.PrintProduct());
```

<b>Output:</b>
```
    Microwave Price: $49.49
    Refrigerator Price: $399.99
```