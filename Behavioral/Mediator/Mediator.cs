using System;
			
namespace ArijitDatta.DesignPatterns.Behavioral.Mediator
{
	// A 'Mediator' interface
	public interface IMarketPlace
    {
		void ProcessSale(string item);
	}
	
	// A 'ConcreteMediator' class
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
	
	// A 'Colleague' class
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
	
	// A 'Colleague' class
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
	
	public class Program
	{
		// Client Code
		public static void Main()
		{
			Seller seller = new Seller("Denis");
			Buyer buyer = new Buyer("Kwako");
			
			IMarketPlace marketPlace = new MarketPlace(seller, buyer);
			marketPlace.ProcessSale("A Washing Machine");
		}
	}
}