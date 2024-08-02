using System;
			
namespace ArijitDatta.DesignPatterns.Behavioral.ChainOfResponsibility
{
	// The 'Handler' abstract class
    public abstract class Handler
    {
        protected Handler nextHandler;
        public void SetNext(Handler next)
        {
            nextHandler = next;
        }
        public abstract void HandleRequest(int request);
    }
	
	// The 'Concrete Handler' Class
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
	
	// The 'Concrete Handler' Class
	public class TenHandler : Handler
	{
		public override void HandleRequest(int request)
		{
			int num = request / 10;
			int rem = request % 10;
			if (num > 0)
				Console.WriteLine(num + " $10 bills despatched");
			if (rem > 0)
				nextHandler.HandleRequest(rem);
		}
	}
	
	// The 'Concrete Handler' Class
	public class FiveHandler : Handler
	{
		public override void HandleRequest(int request)
		{
			int num = request / 5;
			int rem = request % 5;
			if (num > 0)
				Console.WriteLine(num + " $5 bills despatched");
			if (rem > 0)
				nextHandler.HandleRequest(rem);
		}
	}
	
	// The 'Concrete Handler' Class
	public class OneHandler : Handler
	{
		public override void HandleRequest(int request)
		{
			Console.WriteLine(request + " $1 bills despatched");
		}
	}
	
	public class Program
	{
		// Client Code
		public static void Main()
		{
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
		}
	}
}