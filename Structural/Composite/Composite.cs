using System;
using System.Collections.Generic;

namespace ArijitDatta.DesignPatterns.Structural.Composite
{
	// The 'Component' abstract class
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
	
	// The 'Leaf' class
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
	
	// The 'Composite' class
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
	
	public class Program
	{
		// Client Code
		public static void Main()
		{
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
		}
	}
}