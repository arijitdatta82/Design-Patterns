# Facade Design Pattern

## Definition
Facade Method Design Pattern provides a unified interface to a set of interfaces in a subsystem. Facade defines a high-level interface that makes the subsystem easier to use.


## Structure
![ScreenShot](/Assets/Images/Facade_UML.png)

## Real-Time Code Example
In this real-time example, we are building computer configuration and calculating the price using facade design pattern. Student computer and office computer have different configuration. ComputerFacade class works as the interface to the main program, and it hides the internal complexity of processing of the computer configuration subsystem classes. 
[source code](Facade.cs)

<b>Facade</b> knows which subsystem classes are responsible for a request. It delegates client requests to appropriate subsystem objects.
```
	public class ComputerFacade
	{
		ComputerType _computerType;
		ComputerProcessor _computerProcessor;
		ComputerRAM _computerRAM;
		MotherBoard _motherBoard;
		
		public ComputerFacade(ComputerType computerType)
		{
			_computerType = computerType;
			_computerProcessor = new ComputerProcessor(computerType);
			_computerRAM = new ComputerRAM(computerType);
			_motherBoard = new MotherBoard(computerType);
		}
		
		public void ShowPrices()
		{
			_computerProcessor.ShowPrice();
			_computerRAM.ShowPrice();
			_motherBoard.ShowPrice();
		}
		
		public void CalculateTotalPrice()
		{
			double price = _computerProcessor.GetProcessorPrice() + _computerRAM.GetRAMPrice() + _motherBoard.GetMotherBoardPrice();
			Console.WriteLine(string.Format("Total Price is ${0} for {1} Computer.", price.ToString("N2"), _computerType));
		}
	}
```

<b>Subsystem classes</b> implement subsystem functionality. They handle work assigned by the Facade object and have no knowledge of the facade and keep no reference to it.
```
	public class ComputerProcessor
	{
		ComputerType _computerType;
		public ComputerProcessor(ComputerType computerType)
		{
			_computerType = computerType;
		}
		
		public double GetProcessorPrice()
		{
			double price = 0;
			switch (_computerType)
			{
				case ComputerType.Student:
					price = 59.99;
					break;
				case ComputerType.Office:
					price = 135.59;
					break;
			}
			return price;
		}
		
		public void ShowPrice()
		{
			Console.WriteLine(string.Format("Processor Price is ${0} for {1} Computer.", GetProcessorPrice().ToString("N2"), _computerType));
		}
	}
```

<b>Client Code:</b>
```
    var studentComputer = new ComputerFacade(ComputerType.Student);
    studentComputer.ShowPrices();
    Console.WriteLine("---------------------------------------------------");
    studentComputer.CalculateTotalPrice();
    
    Console.WriteLine();
    
    var officeComputer = new ComputerFacade(ComputerType.Office);
    officeComputer.ShowPrices();
    Console.WriteLine("---------------------------------------------------");
    officeComputer.CalculateTotalPrice();
```

<b>Output:</b>
```
Processor Price is $59.99 for Student Computer.
RAM Price is $21.49 for Student Computer.
Mother Board Price is $150.59 for Student Computer.
---------------------------------------------------
Total Price is $232.07 for Student Computer.

Processor Price is $135.59 for Office Computer.
RAM Price is $59.99 for Office Computer.
Mother Board Price is $259.99 for Office Computer.
---------------------------------------------------
Total Price is $455.57 for Office Computer.    
```
