# Chain of Responsibility Design Pattern

## Definition
The chain-of-responsibility design pattern is a behavioral pattern in object-oriented design that allows requests to be passed along a chain of handlers.

## Structure
![ScreenShot](/Assets/Images/Chain_of_Responsibility_UML.jpg)

## Real-Time Code Example
Lets write a code that counts number of notes to be despatched by an ATM machine. We will provide an amount as an input and the code will tell us how many notes for $20, $10, $5 or $1 to be despatched. The code is written using chain-of-responsibility design pattern.
[source code](ChainOfResponsibility.cs)

<b>Handler</b> defines an interface for handling the requests
```
    public abstract class Handler
    {
        protected Handler nextHandler;
        public void SetNext(Handler next)
        {
            nextHandler = next;
        }
        public abstract void HandleRequest(int request);
    }
```

<b>ConcreteHandler</b> handles requests it is responsible for. It can access its successor. The ConcreteHandler can either handle the request, or it forwards the request to its successor
```
	public class TwentyHandler : Handler
	{
		public override void HandleRequest(int request)
		{
			int num = request / 20;
			int rem = request % 20;
			if (num > 0)
				Console.WriteLine(num + " $20 bills despatched");
			if (rem > 0)
				nextHandler.HandleRequest(rem);
		}
	}
```

<b>Client Code:</b>
```
    Handler twenty = new TwentyHandler();
    Handler ten = new TenHandler();
    Handler five = new FiveHandler();
    Handler one = new OneHandler();
    
    // Setup Chain of Responsibility
    twenty.SetNext(ten);
    ten.SetNext(five);
    five.SetNext(one);
    
    twenty.HandleRequest(117);
    Console.WriteLine("------------------------------");
    twenty.HandleRequest(18);
    Console.WriteLine("------------------------------");
    twenty.HandleRequest(9);
```

<b>Output:</b>
```
5 $20 bills despatched
1 $10 bills despatched
1 $5 bills despatched
2 $1 bills despatched
------------------------------
1 $10 bills despatched
1 $5 bills despatched
3 $1 bills despatched
------------------------------
1 $5 bills despatched
4 $1 bills despatched    
```