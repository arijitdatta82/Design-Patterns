# Template Method Design Pattern

## Definition
The template method design pattern is a behavioral design pattern that defines the skeleton of an algorithm in a superclass but allows subclasses to override specific steps of the algorithm without changing its structure.

## Structure
![ScreenShot](/Assets/Images/Template_Method_UML.jpg)

## Real-Time Code Example
Let's suppose we have a program that helps to process purchase orders. In order to make the processing it calls a function to process payment and then ship the product. The purchase order can be either for a physical purchase or a digital purchase. With help of template method (ProcessPurchase) design pattern we can handle physical purchase and digital purchase differently.
[source code](TemplateMethod.cs)

<b>AbstractClass</b> defines abstract primitive operations that concrete subclasses define to implement steps of an algorithm. This implements a template method defining the skeleton of an algorithm. The template method calls primitive operations as well as operations defined in AbstractClass or those of other objects.
```
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
```

<b>ConcreteClass</b> implements the primitive operations to carry out subclass-specific steps of the algorithm
```
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
```

<b>Client Code:</b>
```
    PurchaseProcessor laptop = new PhysicalProductPurchaseProcessor { PurchasedItem = "Laptop", Amount = 445.99 };
    laptop.ProcessPurchase();
    
    Console.WriteLine("---------------------------------------------------");
    
    PurchaseProcessor antivirus = new DigitalProductPurchaseProcessor { PurchasedItem = "Antivirus", Amount = 25.49 };
    antivirus.ProcessPurchase();
```

<b>Output:</b>
```
Processing payment of $445.99 for physical purchase.
Shipping Laptop to customer's address.
---------------------------------------------------
Processing payment of $25.49 for digital purchase.
Sending activation code for Antivirus to customer via email.    
```