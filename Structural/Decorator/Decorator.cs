using System;
			
namespace ArijitDatta.DesignPatterns.Structural.Decorator
{
	// The 'Component' abstract class
	public abstract class AbstractEmployee
    {
        public abstract void ProcessSalary();
    }
	
	// The 'Component' abstract class
	public class Employee : AbstractEmployee
    {
		public string Name { get; set; }
		public double YearlyCompensation { get; set; }
		public int YearsOfService { get; set; }
		public override void ProcessSalary()
		{
			double salary = YearlyCompensation / 52;
			Console.WriteLine(string.Format("${0} paid to {1}.", salary.ToString("N2"), Name));
		}
    }
	
	// The 'Decorator' abstract class
	public abstract class EmployeeDecorator : AbstractEmployee
    {
		protected Employee employee;
		public EmployeeDecorator(Employee emp)
		{
			this.employee = emp;
		}
		public override void ProcessSalary()
		{
			employee.ProcessSalary();
		}
    }
	
	// The 'Concrete Decorator' class
	public class EmployeeBonus : EmployeeDecorator
    {
		public EmployeeBonus(Employee emp) : base(emp)
		{
		}
		public override void ProcessSalary()
		{
			double bonus = employee.YearlyCompensation * employee.YearsOfService / 100;
			double salary = (employee.YearlyCompensation / 52) + bonus;
			Console.WriteLine(string.Format("${0} paid to {1} with ${2} yearly bonus ammount.", salary.ToString("N2"), employee.Name, bonus.ToString("N2")));
		}
    }
	
	public class Program
	{
		// Client Code
		public static void Main()
		{
			var employee = new Employee 
			{
				Name = "Employee 1",
				YearlyCompensation = 131259.89,
				YearsOfService = 12
			};
			employee.ProcessSalary();
			
			var empBonus = new EmployeeBonus(employee);
			empBonus.ProcessSalary();
		}
	}
}