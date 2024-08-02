# Proxy Design Pattern (aka Surrogate)

## Definition
The proxy pattern, also known as the surrogate design pattern, is a software design pattern that creates a placeholder or proxy for another object to control access to it. 

The proxy acts as an interface to the real object, allowing the client to access it without directly accessing the original. The proxy can forward requests to the real object, or it can provide additional functionality.

## Structure
![ScreenShot](/Assets/Images/Proxy_UML.jpg)

## Real-Time Code Example
In this example, we have a CreditCard class. This class implements two methods. ShowAllDigits and ShowLast4Digits. In some uses, we don't want to expose ShowAllDigits method as it may cause security issue for the credit card. So we can use proxy design pattern to create a ProxyCreditCard class which can work as a proxy to the real CreditCard class.
[source code](Proxy.cs)

<b>Subject</b> defines the common interface for RealSubject and Proxy so that a Proxy can be used anywhere a RealSubject is expected.
```
	public interface ICreditCard 
	{
		void ShowLast4Digits();
		void ShowAllDigits();
	}
```

<b>RealSubject</b> defines the real object that the proxy represents.
```
	public class CreditCard : ICreditCard
	{
		public void ShowLast4Digits()
		{
			var display = "1234";
			Console.WriteLine("Last 4 Digits:" + display);
		}		
		public void ShowAllDigits()
		{
			var display = "5555-6666-7777-1234";
			Console.WriteLine("All Digits:" + display);
		}
	}
```

<b>Proxy</b> maintains a reference that lets the proxy access the real subject. Proxy may refer to a Subject if the RealSubject and Subject interfaces are the same. It provides an interface identical to Subject's so that a proxy can be substituted for for the real subject. Proxy controls access to the real subject and may be responsible for creating and deleting it.
```
	public class ProxyCreditCard : ICreditCard
	{
		CreditCard creditCard = new CreditCard();
		public void ShowLast4Digits()
		{
			creditCard.ShowLast4Digits();
		}		
		public void ShowAllDigits()
		{
			Console.WriteLine("This is a proxy class. Cannot show all digits.");
		}
	}
```

<b>Client Code:</b>
```
    var realCard = new CreditCard();
    realCard.ShowLast4Digits();
    realCard.ShowAllDigits();
    
    Console.WriteLine("---------------------------------------------------");
    
    var proxyCard = new ProxyCreditCard();
    proxyCard.ShowLast4Digits();
    proxyCard.ShowAllDigits();
```

<b>Output:</b>
```
Last 4 Digits:1234
All Digits:5555-6666-7777-1234
---------------------------------------------------
Last 4 Digits:1234
This is a proxy class. Cannot show all digits.   
```
