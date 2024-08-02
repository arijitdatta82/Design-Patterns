# Command Design Pattern

## Definition
The command design pattern is a behavioral design pattern in which an object is used to encapsulate all information needed to perform an action or trigger an event at a later time.

## Structure
![ScreenShot](/Assets/Images/Command_UML.jpg)

## Real-Time Code Example
We are using command design pattern to develop a shopping cart. Items can be added to the cart or can be removed from the cart. Both add and remove works as commands and command classes are being invoked to perform the operation.
[source code](Command.cs)

<b>Command</b> declares an interface for executing an operation.
```
	public abstract class CartCommand
	{
		protected ShoppingCart shoppingCart;
        public CartCommand(ShoppingCart cart)
        {
            this.shoppingCart = cart;
        }
        public abstract void Execute();
	}
```

<b>ConcreteCommand</b> defines a binding between a Receiver object and an action. It implements Execute by invoking the corresponding operation(s) on Receiver.
```
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
```

<b>Invoker</b> asks the command to carry out the request.
```
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
```

<b>Receiver</b> knows how to perform the operations associated with carrying out the request.
```
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
```

<b>Client Code:</b>
```
    CartAction cartAction = new CartAction();
    cartAction.Add("Rice 10-lb");
    cartAction.Add("Sugar 5-lb");
    cartAction.Add("Olive Oil 1-gal");
    cartAction.Remove("Sugar 5-lb");
```

<b>Output:</b>
```
Rice 10-lb added to shopping cart.
Sugar 5-lb added to shopping cart.
Olive Oil 1-gal added to shopping cart.
Sugar 5-lb removed from shopping cart.    
```