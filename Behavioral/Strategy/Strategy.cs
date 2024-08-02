using System;
			
namespace ArijitDatta.DesignPatterns.Behavioral.Strategy
{
	// The 'Strategy' interface
	public interface IInterestCalculator
	{
		double CalculateAmount(double principal, double rate, int time);
	}
	
	// The 'Concrete Strategy' class
	public class SimpleInterestCalculator : IInterestCalculator
	{
		public double CalculateAmount(double principal, double rate, int time)
		{
			var amount = principal * (1 + rate * time);
			return amount;
		}
	}
	
	// The 'Concrete Strategy' class
	public class CompoundInterestCalculator : IInterestCalculator
	{
		public double CalculateAmount(double principal, double rate, int time)
		{
			double interest = principal * Math.Pow((1 + (rate / time)), (time * time));
			var amount = principal + interest;
			return amount;
		}
	}
	
	// The 'Context' class
	public class LoanCalculator
	{
		double _principal; 
		double _rate; 
		int _time;
		double _amount;
		IInterestCalculator _strategy = new SimpleInterestCalculator();
		public LoanCalculator(double principal, double rate, int time)
		{
			_principal = principal;
			_rate = rate;
			_time = time;
		}
		public void SetInterestCalculatorStrategy(IInterestCalculator strategy)
		{
			_strategy = strategy;
		}
		public void CalculateLoan()
		{
			Console.WriteLine(string.Format("Calculating Loan Amount for Principal: ${0} with Rate of Interest: {1}% for {2} Years", _principal.ToString("N2"), _rate.ToString("N2"),_time));
			_amount = _strategy.CalculateAmount(_principal, _rate / 100, _time);
			Console.WriteLine(string.Format("Total Loan Amount ${0} is Calculated with {1} Strategy", _amount.ToString("N2"), _strategy.GetType().Name));
		}
	}
	
	public class Program
	{
		// Client Code
		public static void Main()
		{
			LoanCalculator loanCalc = new LoanCalculator(100000, 5.59, 20);
			loanCalc.CalculateLoan();
			
			Console.WriteLine("---------------------------------------------------");
			
			loanCalc.SetInterestCalculatorStrategy(new CompoundInterestCalculator());
			loanCalc.CalculateLoan();
			
		}
	}
}