using System;
			
namespace ArijitDatta.DesignPatterns.Behavioral.Visitor
{
	// The 'Visitable' interface
	public interface IEmployee
	{
		void Accept(IEmployeeVisitor visitor);
	}
	
	// The 'Concrete Visitable' class
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
	
	// The 'Concrete Visitable' class
	public class StoreEmployee : IEmployee
	{
		public string Name;
		public StoreEmployee(string name)
		{
			Name = name;
		}
		public void Accept(IEmployeeVisitor visitor)
		{
			visitor.Visit(this);
		}
	}
	
	// The 'Visitor' interface
	public interface IEmployeeVisitor
	{
		void Visit(WorkshopEmployee emp);
		void Visit(StoreEmployee emp);
	}
	
	// The 'Concrete Visitor' class
	public class EmployeeSalaryVisitor : IEmployeeVisitor
	{
		public void Visit(WorkshopEmployee emp)
		{
			Console.WriteLine("Salary paid to workshop employee: " + emp.Name);
		}
		
		public void Visit(StoreEmployee emp)
		{
			Console.WriteLine("Salary paid to store employee: " + emp.Name);
		}
	}
	
	// The 'Concrete Visitor' class
	public class EmployeeBonusVisitor : IEmployeeVisitor
	{
		public void Visit(WorkshopEmployee emp)
		{
			Console.WriteLine("Bonus paid to workshop employee: " + emp.Name);
		}
		
		public void Visit(StoreEmployee emp)
		{
			Console.WriteLine("Store employees are not eligible for bonus.");
		}
	}
	
	public class Program
	{
		// Client Code
		public static void Main()
		{
			var workshopEmploee = new WorkshopEmployee("Josua");
			var storeEmploee = new StoreEmployee("Neelu");
			
			var salary = new EmployeeSalaryVisitor();
			workshopEmploee.Accept(salary);
			storeEmploee.Accept(salary);
			
			Console.WriteLine("---------------------------------------------------");
			
			var bonus = new EmployeeBonusVisitor();
			workshopEmploee.Accept(bonus);
			storeEmploee.Accept(bonus);
		}
	}
}