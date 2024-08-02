using System;
using System.Collections.Generic;
			
namespace ArijitDatta.DesignPatterns.Behavioral.Command
{
	// The 'Abstract Command' Class
	public abstract class CartCommand
	{
		protected ShoppingCart shoppingCart;
        public CartCommand(ShoppingCart cart)
        {
            this.shoppingCart = cart;
        }
        public abstract void Execute();
	}
	
	// The 'Concrete Command' Class
	public class AddToCartCommand : CartCommand
	{
		private string _item;
        public AddToCartCommand(ShoppingCart cart, string item) : base (cart)
        {          
			_item = item;
        }
        public override void Execute()
		{
			shoppingCart.AddProduct(_item);
		}
	}
	
	// The 'Concrete Command' Class
	public class RemoveFromCartCommand : CartCommand
	{
		private string _item;
        public RemoveFromCartCommand(ShoppingCart cart, string item) : base (cart)
        {          
			_item = item;
        }
        public override void Execute()
		{
			shoppingCart.RemoveProduct(_item);
		}
	}
	
	// The 'Receiver' Class
	public class ShoppingCart 
	{
		List<string> _products = new List<string>();
		public void AddProduct(string item)
		{
			_products.Add(item);
			Console.WriteLine(item + " added to shopping cart.");
		}
		
		public void RemoveProduct(string item)
		{
			_products.Remove(item);
			Console.WriteLine(item + " removed from shopping cart.");
		}
	}
	
	// The 'Invoker' Class
	public class CartAction
	{
		ShoppingCart shoppingCart = new ShoppingCart();
		public void Add(string item)
		{
			CartCommand command = new AddToCartCommand(shoppingCart, item);
			command.Execute();
		}
		public void Remove(string item)
		{
			CartCommand command = new RemoveFromCartCommand(shoppingCart, item);
			command.Execute();
		}
	}
	
	public class Program
	{
		// Client Code
		public static void Main()
		{
			CartAction cartAction = new CartAction();
			cartAction.Add("Rice 10-lb");
			cartAction.Add("Sugar 5-lb");
			cartAction.Add("Olive Oil 1-gal");
			cartAction.Remove("Sugar 5-lb");
		}
	}
}