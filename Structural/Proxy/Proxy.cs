using System;
			
namespace ArijitDatta.DesignPatterns.Structural.Proxy
{
	// The 'Subject' Interface
	public interface ICreditCard 
	{
		void ShowLast4Digits();
		void ShowAllDigits();
	}
	
	// The 'RealSubject' class
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
	
	// The 'Proxy' class
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
	
	public class Program
	{
		// Client Code
		public static void Main()
		{
			var realCard = new CreditCard();
			realCard.ShowLast4Digits();
			realCard.ShowAllDigits();
			
			Console.WriteLine("---------------------------------------------------");
			
			var proxyCard = new ProxyCreditCard();
			proxyCard.ShowLast4Digits();
			proxyCard.ShowAllDigits();
		}
	}
}