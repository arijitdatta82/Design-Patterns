using System;
	
namespace ArijitDatta.DesignPatterns.Creational.Builder
{
	// Product Class
	public class Computer
	{
		public string CPU { get; set; }
		public string RAM { get; set; }
		public string Storage { get; set; }
		public void PrintComputerInfo()
		{
			Console.WriteLine("CPU: " + CPU);
			Console.WriteLine("RAM: " + RAM);
			Console.WriteLine("Storage: " + Storage);
		}
	}	
	
	// Builder interface
	public interface IComputerBuilder
	{
		void SetCPU();
		void SetRAM();
		void SetStorage();
		Computer GetResult();
	}
	
	// ConcreteBuilder
	public class PersonamComputerBuilder : IComputerBuilder
	{
		Computer _computer = new Computer();
		public void SetCPU()
		{
			_computer.CPU = "INTEL CORE i5";
		}
		public void SetRAM()
		{
			_computer.RAM = "16 GB DDR";
		}
		public void SetStorage()
		{
			_computer.Storage = "1 TB SSD";
		}
		public Computer GetResult()
		{
			return _computer;	
		}
	}
	
	// Director
	public class ComputerDirector
	{
		public ComputerDirector(IComputerBuilder builder)
		{
			builder.SetCPU();
			builder.SetRAM();
			builder.SetStorage();
		}
	}
	
	public class Program
	{
		// Client Code
		public static void Main()
		{
			var myComputerBuilder = new PersonamComputerBuilder();
			new ComputerDirector(myComputerBuilder);
			myComputerBuilder.GetResult().PrintComputerInfo();	
		}
	}
}
