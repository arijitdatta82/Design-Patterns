# Abstract Factory Design Pattern

## Definition
An interface for creating families of related or dependent objects without specifying their concrete classes.

## Structure
![ScreenShot](/Assets/Images/Abstract_Factory_UML.jpg)

## Real-Time Code Example
Let's imagine a scenario where a company sends bills and promotions to its subscribers. Physical subscribers receive promotions and bills via physical mail whereas, electronic subscribers receive emails for promotions and bills. We can use abstract factory design pattern to implement such scenario.
[source code](AbstractFactory.cs)

<b>AbstractFactory</b> declares an interface for operations that create abstract products.
```
	interface ISubscriberFactory {
		IBilling CreateBill();
		IPromotion CreatePromotion();
	}
```

<b>ConcreteFactory</b> implements the operations to create concrete product objects.
```
	public class ElectronicSubscriber : ISubscriberFactory
	{
		public IBilling CreateBill()
		{
			return new ElectronicBilling();
		}
		public IPromotion CreatePromotion()
		{
			return new ElectronicPromotion();
		}
	}
    
	public class PhysicalSubscriber : ISubscriberFactory
	{
		public IBilling CreateBill()
		{
			return new PhysicalBilling();
		}
		public IPromotion CreatePromotion()
		{
			return new PhysicalPromotion();
		}
	}
```

<b>AbstractProduct</b> declares an interface for a type of product object.
```
	public interface IBilling
	{
		void SendBill();
	}
    
	public interface IPromotion
	{
		void SendPromotion();
	}
```

<b>Product</b> defines a product object to be created by the corresponding concrete factory
implements the AbstractProduct interface.
```
	public class ElectronicBilling : IBilling
	{
		public void SendBill()
		{
			Console.WriteLine("Bill is sent by email.");
		}
	}
    
	public class ElectronicPromotion : IPromotion
	{
		public void SendPromotion()
		{
			Console.WriteLine("Promotion is sent by email.");
		}
	}
    
	public class PhysicalBilling : IBilling
	{
		public void SendBill()
		{
			Console.WriteLine("Bill is sent by physical mail.");
		}
	}
    
	public class PhysicalPromotion : IPromotion
	{
		public void SendPromotion()
		{
			Console.WriteLine("Promotion is sent by physical mail.");
		}
	}
```

<b>Client Code:</b>
```
    ISubscriberFactory eSubscriber = new ElectronicSubscriber();
    var eBill = eSubscriber.CreateBill();
    eBill.SendBill();
    var ePromotion = eSubscriber.CreatePromotion();
    ePromotion.SendPromotion();
    
    ISubscriberFactory phSubscriber = new PhysicalSubscriber();
    var phBill = phSubscriber.CreateBill();
    phBill.SendBill();
    var phPromotion = phSubscriber.CreatePromotion();
    phPromotion.SendPromotion();
```

<b>Output:</b>
```
Bill is sent by email.
Promotion is sent by email.
Bill is sent by physical mail.
Promotion is sent by physical mail.
```
