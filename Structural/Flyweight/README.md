# Flyweight Design Pattern

## Definition
The Flyweight design pattern is a structural pattern that focuses on optimizing memory usage by sharing a common state among multiple objects. It aims to reduce the number of objects created and to decrease memory footprint, particularly useful when dealing with a large number of similar objects.

## Structure
![ScreenShot](/Assets/Images/Flyweight_UML.jpg)

## Real-Time Code Example
With help of flyweight design pattern, we are building a cart system where a furniture can be added to the cart only once. 
[source code](Flyweight.cs)

<b>Flyweight</b> declares an interface through which flyweights can receive and act on extrinsic state.
```
	public interface IFurniture 
	{
		void AddToCart();
	}
```

<b>ConcreteFlyweight</b> implements the Flyweight interface and adds storage for intrinsic state, if any. A ConcreteFlyweight object must be sharable. Any state it stores must be intrinsic, that is, it must be independent of the ConcreteFlyweight object's context.
```
	public class OfficeChair : IFurniture
	{
		public void AddToCart()
		{
			var price = 149.99;
			Console.WriteLine(string.Format("Office Chair with price ${0} added to cart.", price.ToString("N2")));
			Console.WriteLine("---------------------------------------------------");
		}
	}
	
	public class GamingChair : IFurniture
	{
		public void AddToCart()
		{
			var price = 124.99;
			Console.WriteLine(string.Format("Gaming Chair with price ${0} added to cart.", price.ToString("N2")));
			Console.WriteLine("---------------------------------------------------");
		}
	}
	
	public class Desk : IFurniture
	{
		public void AddToCart()
		{
			var price = 199.99;
			Console.WriteLine(string.Format("Desk with price ${0} added to cart.", price.ToString("N2")));
			Console.WriteLine("---------------------------------------------------");
		}
	}
```

<b>FlyweightFactory</b> creates and manages flyweight objects and ensures that flyweight are shared properly. When a client requests a flyweight, the FlyweightFactory objects assets an existing instance or creates one, if none exists.
```
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
```


<b>Client Code:</b>
```
    var furnitureFlyweightFactory = new FurnitureFlyweightFactory();
    
    var officeChair = furnitureFlyweightFactory.GetFurniture("OfficeChair");
    officeChair.AddToCart();
    
    
    var gamingChair = furnitureFlyweightFactory.GetFurniture("GamingChair");
    gamingChair.AddToCart();
    
    var desk = furnitureFlyweightFactory.GetFurniture("Desk");
    desk.AddToCart();
```

<b>Output:</b>
```
Office Chair with price $149.99 added to cart.
---------------------------------------------------
Gaming Chair with price $124.99 added to cart.
---------------------------------------------------
Desk with price $199.99 added to cart.
---------------------------------------------------    
```
