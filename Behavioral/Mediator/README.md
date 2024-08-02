# Mediator Design Pattern

## Definition
The  mediator pattern defines an object that encapsulates how a set of objects interact. It promotes loose coupling by keeping objects from referring to each other explicitly, and it allows their interaction to be varied independently. Client classes can use the mediator to send messages to other clients, and can receive messages from other clients via an event on the mediator class.

## Structure
![ScreenShot](/Assets/Images/Mediator_UML.jpg)

## Real-Time Code Example
We can use mediator design pattern to implement a marketplace. The marketplace can work as a mediator where a seller can sell an item and a buyer can buy that item.
[source code](Mediator.cs)

<b>Mediator</b> defines an interface for communicating with Colleague objects
```
	public interface IMarketPlace
    {
		void ProcessSale(string item);
	}
```

<b>ConcreteMediator</b> implements cooperative behavior by coordinating Colleague objects. It knows and maintains its colleagues.
```
	public class MarketPlace : IMarketPlace
	{
		Seller _seller;
		Buyer _buyer;
		public MarketPlace(Seller seller, Buyer buyer)
		{
			_seller = seller;
			_buyer = buyer;
		}
		
		public void ProcessSale(string item)
		{
			_seller.Sell(item);
			_buyer.Buy(item);
		}
	}
```

<b>Colleague</b> classes knows its Mediator object. Each colleague communicates with its mediator whenever it would have otherwise communicated with another colleague
```
	public class Seller
    {
        string _name;
        public Seller(string name)
        {
            _name = name;
        }
        public void Sell(string item)
        {
            Console.WriteLine(string.Format("Seller {0} is selling {1}.", _name, item));
        }
    }	

	public class Buyer
    {
        string _name;
        public Buyer(string name)
        {
            _name = name;
        }
        public void Buy(string item)
        {
            Console.WriteLine(string.Format("Buyer {0} is buying {1}.", _name, item));
        }
    }
```

<b>Client Code:</b>
```
    Seller seller = new Seller("Denis");
    Buyer buyer = new Buyer("Kwako");
    
    IMarketPlace marketPlace = new MarketPlace(seller, buyer);
    marketPlace.ProcessSale("A Washing Machine");
```

<b>Output:</b>
```
Seller Denis is selling A Washing Machine.
Buyer Kwako is buying A Washing Machine.    
```