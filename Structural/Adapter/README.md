# Adapter Design Pattern (aka Wrapper)

## Definition
An adapter allows two incompatible interfaces to work together. Interfaces may be incompatible, but the inner functionality should suit the need. The adapter design pattern allows otherwise incompatible classes to work together by converting the interface of one class into an interface expected by the clients.

## Structure
![ScreenShot](/Assets/Images/Adapter_UML.jpg)

## Real-Time Code Example
Let’s consider a scenario where a company is selling products online. The AddToCart() function calculates the product price based on manufacturing expense and profit margin. Now, the company wants to sell services and the price to be calculated based on pay per hour. With help of adapter design pattern, we can accommodate the Service class in our program and use the SellableService class to adapt the service features. 
[source code](Adapter.cs)

<b>Target</b> defines the domain-specific interface that client uses.
```
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
```

<b>Adapter</b> adapts the interface Adaptee to the Target interface.
```
	public class SellableService : IProduct
	{
		private Service service = new Service();
		public void AddToCart()
		{
			var price = service.GetServiceCost();
			Console.WriteLine(string.Format("${0} added to shopping cart", price.ToString("N2")));
		}
	}
```

<b>Adaptee</b> defines an existing interface that needs adapting.
```
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
```

<b>Client Code:</b>
```
    IProduct product = new Product();
    product.AddToCart();
    
    IProduct service = new SellableService();
    service.AddToCart();
```

<b>Output:</b>
```
$19.89 added to shopping cart
$61.48 added to shopping cart   
```