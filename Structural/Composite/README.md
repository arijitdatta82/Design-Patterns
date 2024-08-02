# Composite Design Pattern

## Definition
The composite pattern describes a group of objects that are treated the same way as a single instance of the same type of object. The intent of a composite is to "compose" objects into tree structures to represent part-whole hierarchies. Implementing the composite pattern lets clients treat individual objects and compositions uniformly.

## Structure
![ScreenShot](/Assets/Images/Composite_UML.jpg)

## Real-Time Code Example
In this real-time example, we are using composite design pattern to build a hierarchy of workers. Workers can be employee or contractor. An employee can have multiple subordinates but a contractor cannot. Employee becomes a composite class in this example whereas, Contractor is a leaf class.
[source code](Composite.cs)

<b>Component</b> declares the interface for objects in the composition. It implements default behavior for the interface common to all classes, as appropriate. Component declares an interface for accessing and managing its child components.
```
	public abstract class Worker
    {
        protected string Name;
        public Worker(string name)
        {
            Name = name;
        }
		protected void PrintName()
		{
			Console.WriteLine(Name);
		}
        public abstract void AddSubordinate(Worker worker);
        public abstract void RemoveSubordinate(Worker worker);
        public abstract void ShowInfo();
    }
```

<b>Leaf</b> represents leaf objects in the composition. A leaf has no children. It defines behavior for primitive objects in the composition.
```
	public class Contractor : Worker
    {
        public Contractor(string name)
            : base(name)
        {
        }
        public override void AddSubordinate(Worker worker)
        {
            Console.WriteLine("Cannot add subordinate to a contractor");
        }
        public override void RemoveSubordinate(Worker worker)
        {
            Console.WriteLine("Cannot remove subordinate");
        }
        public override void ShowInfo()
        {
            PrintName();
        }
    }
```

<b>Composite</b> defines behavior for components having children. It stores child components and implements child-related operations in the Component interface.
```
	public class Employee : Worker
    {
		List<Worker> subordinates = new List<Worker>();
        public Employee(string name)
            : base(name)
        {
        }
        public override void AddSubordinate(Worker worker)
        {
            subordinates.Add(worker);
        }
        public override void RemoveSubordinate(Worker worker)
        {
            subordinates.Remove(worker);
        }
        public override void ShowInfo()
        {
            PrintName();
			if (subordinates.Count > 0)
			{
				Console.WriteLine("Subordinates:");
				foreach (var subordinate in subordinates)
				{
					subordinate.ShowInfo();
				}
				Console.WriteLine("=============");
			}
			
        }
    }
```

<b>Client Code:</b>
```
    var emp1 = new Employee("Employee 1");
    var emp2 = new Employee("Employee 2");
    var contr1 = new Contractor("Contractor 1");
    emp1.ShowInfo();		
    contr1.ShowInfo();
    
    Console.WriteLine();
    
    var mgr = new Employee("Manager 1");
    mgr.AddSubordinate(emp1);
    mgr.AddSubordinate(emp2);
    mgr.AddSubordinate(contr1);
    mgr.ShowInfo();	
```

<b>Output:</b>
```
Employee 1
Contractor 1

Manager 1
Subordinates:
Employee 1
Employee 2
Contractor 1
=============    
```
