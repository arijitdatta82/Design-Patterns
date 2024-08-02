# Visitor Design Pattern

## Definition
A visitor design pattern is a software design pattern that separates the algorithm from the object structure. Because of this separation, new operations can be added to existing object structures without modifying the structures.
Visitor design pattern allows adding new behaviors to existing class hierarchy without altering any existing code.

## Structure
![ScreenShot](/Assets/Images/Visitor_UML.jpg)

## Real-Time Code Example
Let's imagine a scenario where a company pays salary to both their workshop employees and store employees. We have WorkshopEmployee and StoreEmployee classes that inherits IEmployee interface. We have a class that processes their salary. Now, the company decides to provide bonus for their workshop employees. This example demonstrates the use of visitor design pattern to handle such scenario.
[source code](Visitor.cs) 

<b>Visitor</b> is an interface or an abstract class used to declare the visit operations for all the types of visitable classes.
```
	public interface IEmployeeVisitor
	{
		void Visit(WorkshopEmployee emp);
		void Visit(StoreEmployee emp);
	}
```

<b>ConcreteVisitor</b> implements the Visitor interface.
```
	public class EmployeeSalaryVisitor : IEmployeeVisitor
	{
		public void Visit(WorkshopEmployee emp)
		{
			Console.WriteLine("Salary paid to workshop employee:" + emp.Name);
		}
		
		public void Visit(StoreEmployee emp)
		{
			Console.WriteLine("Salary paid to store employee:" + emp.Name);
		}
	}
	
	public class EmployeeBonusVisitor : IEmployeeVisitor
	{
		public void Visit(WorkshopEmployee emp)
		{
			Console.WriteLine("Bonus paid to workshop employee:" + emp.Name);
		}
		
		public void Visit(StoreEmployee emp)
		{
			Console.WriteLine("Store employees are not eligible for bonus.");
		}
	}
```
<b>Visitable</b> is an interface which declares the accept operation. This is the entry point which enables an object to be “visited” by the visitor object.
```
    public interface IEmployee
	{
		void Accept(IEmployeeVisitor visitor);
	}
```

<b>ConcreteVisitable</b> classes implement the Visitable interface or class and defines the accept operation. The visitor object is passed to this object using the accept operation.
```
	public class WorkshopEmployee : IEmployee
	{
		public string Name;
		public WorkshopEmployee(string name)
		{
			Name = name;
		}
		public void Accept(IEmployeeVisitor visitor)
		{
			visitor.Visit(this);
		}
	}
```

<b>Client Code:</b>
```
    var workshopEmploee = new WorkshopEmployee("Josua");
    var storeEmploee = new StoreEmployee("Neelu");
    
    var salary = new EmployeeSalaryVisitor();
    workshopEmploee.Accept(salary);
    storeEmploee.Accept(salary);
    
    Console.WriteLine("---------------------------------------------------");
    
    var bonus = new EmployeeBonusVisitor();
    workshopEmploee.Accept(bonus);
    storeEmploee.Accept(bonus);
```

<b>Output:</b>
```
Salary paid to workshop employee: Josua
Salary paid to store employee: Neelu
---------------------------------------------------
Bonus paid to workshop employee: Josua
Store employees are not eligible for bonus.    
```