using System;
			
namespace ArijitDatta.DesignPatterns.Structural.Facade
{
	public enum ComputerType
	{
		Student,
		Office
	}
	
	// The 'Subsystem ClassA'
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
	
	// The 'Subsystem ClassB'
	public class ComputerRAM
	{
		ComputerType _computerType;
		public ComputerRAM(ComputerType computerType)
		{
			_computerType = computerType;
		}
		
		public double GetRAMPrice()
		{
			double price = 0;
			switch (_computerType)
			{
				case ComputerType.Student:
					price = 21.49;
					break;
				case ComputerType.Office:
					price = 59.99;
					break;
			}
			return price;
		}
		
		public void ShowPrice()
		{
			Console.WriteLine(string.Format("RAM Price is ${0} for {1} Computer.", GetRAMPrice().ToString("N2"), _computerType));
		}
	}
	
	// The 'Subsystem ClassC'
	public class MotherBoard
	{
		ComputerType _computerType;
		public MotherBoard(ComputerType computerType)
		{
			_computerType = computerType;
		}
		
		public double GetMotherBoardPrice()
		{
			double price = 0;
			switch (_computerType)
			{
				case ComputerType.Student:
					price = 150.59;
					break;
				case ComputerType.Office:
					price = 259.99;
					break;
			}
			return price;
		}
		
		public void ShowPrice()
		{
			Console.WriteLine(string.Format("Mother Board Price is ${0} for {1} Computer.", GetMotherBoardPrice().ToString("N2"), _computerType));
		}
	}
	
	// The 'Facade' class
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
	
	public class Program
	{
		// Client Code
		public static void Main()
		{
			var studentComputer = new ComputerFacade(ComputerType.Student);
			studentComputer.ShowPrices();
			Console.WriteLine("---------------------------------------------------");
			studentComputer.CalculateTotalPrice();
			
			Console.WriteLine();
			
			var officeComputer = new ComputerFacade(ComputerType.Office);
			officeComputer.ShowPrices();
			Console.WriteLine("---------------------------------------------------");
			officeComputer.CalculateTotalPrice();
		}
	}
}