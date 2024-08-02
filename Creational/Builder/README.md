# Builder Design Pattern

## Definition
The intent of the Builder design pattern is to separate the construction of a complex object from its representation. By doing so, the same construction process can create different representations.

## Structure
![ScreenShot](/Assets/Images/Builder_UML.jpg)

## Real-Time Code Example
In this example we are constructing personal computer. A sequence of actions to be performed to build the final product. Like, SetCPU, SetRAM and SetStorage. We are using builder design pattern to construct the computer. 
[source code](Builder.cs)

<b>Builder</b> specifies an abstract interface for creating parts of a Product object.
```
	public interface IComputerBuilder
	{
		void SetCPU();
		void SetRAM();
		void SetStorage();
		Computer GetResult();
	}
```

<b>ConcreteBuilder</b> constructs and assembles parts of the product by implementing the Builder interface. It defines and keeps track of the representation it creates.
```
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
```

<b>Director</b> constructs an object using the Builder interface.
```
	public class ComputerDirector
	{
		public ComputerDirector(IComputerBuilder builder)
		{
			builder.SetCPU();
			builder.SetRAM();
			builder.SetStorage();
		}
	}
```

<b>Product</b> represents the complex object under construction. ConcreteBuilder builds the product's internal representation and defines the process by which it's assembled. It includes classes that define the constituent parts, including interfaces for assembling the parts into the final result.
```
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
```

<b>Client Code:</b>
```
    var myComputerBuilder = new PersonamComputerBuilder();
    new ComputerDirector(myComputerBuilder);
    myComputerBuilder.GetResult().PrintComputerInfo();	
```

<b>Output:</b>
```
CPU: INTEL CORE i5
RAM: 16 GB DDR
Storage: 1 TB SSD    
```
