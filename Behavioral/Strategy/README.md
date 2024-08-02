# Strategy Design Pattern

## Definition
The strategy design pattern defines a family of algorithms, encapsulate each one, and make them interchangeable. This pattern lets the algorithm vary independently from clients that use it. 

## Structure
![ScreenShot](/Assets/Images/Strategy_UML.jpg)

## Real-Time Code Example
In this real time example, we are calculating loan amount for based on simple or compound interest. With help of strategy design pattern, the client code can decide whether to use simple interest strategy or compound interest strategy.
[source code](Strategy.cs)

<b>Strategy</b> declares an interface common to all supported algorithms. Context uses this interface to call the algorithm defined by a ConcreteStrategy.
```
	public interface IInterestCalculator
	{
		double CalculateAmount(double principal, double rate, int time);
	}
```

<b>ConcreteStrategy</b> implements the algorithm using the Strategy interface.
```
	public class SimpleInterestCalculator : IInterestCalculator
	{
		public double CalculateAmount(double principal, double rate, int time)
		{
			var amount = principal * (1 + rate * time);
			return amount;
		}
	}
```

<b>Context</b> is configured with a ConcreteStrategy object that maintains a reference to a Strategy object.
```
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
```

<b>Client Code:</b>
```
    LoanCalculator loanCalc = new LoanCalculator(100000, 5.59, 20);
    loanCalc.CalculateLoan();
    
    Console.WriteLine("---------------------------------------------------");
    
    loanCalc.SetInterestCalculatorStrategy(new CompoundInterestCalculator());
    loanCalc.CalculateLoan();
```

<b>Output:</b>
```
Calculating Loan Amount for Principal: $100,000.00 with Rate of Interest: 5.59% for 20 Years
Total Loan Amount $211,800.00 is Calculated with SimpleInterestCalculator Strategy
---------------------------------------------------
Calculating Loan Amount for Principal: $100,000.00 with Rate of Interest: 5.59% for 20 Years
Total Loan Amount $405,396.42 is Calculated with CompoundInterestCalculator Strategy    
```