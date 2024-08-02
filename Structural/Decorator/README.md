# Decorator Design Pattern

## Definition
The decorator pattern is a design pattern that allows behavior to be added to an individual object, dynamically, without affecting the behavior of other instances of the same class.

## Structure
![ScreenShot](/Assets/Images/Decorator_UML.png)

## Real-Time Code Example
Let us consider a scenario where there is a program that process salary of the employees. Now we got a new requirement that the employees will get bonus along with their salary. We can use decorator design pattern to handle such scenario without making any changes to the Employee class.
[source code](Decorator.cs)

<b>Component</b> defines the interface for objects that can have responsibilities added to them dynamically.
```
	public abstract class AbstractEmployee
    {
        public abstract void ProcessSalary();
    }
```

<b>ConcreteComponent</b> defines an object to which additional responsibilities can be attached.
```
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
```

<b>Decorator</b> maintains a reference to a Component object and defines an interface that conforms to Component's interface.
```
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
```

<b>ConcreteDecorator</b> adds responsibilities to the component.
```
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
```


<b>Client Code:</b>
```
    var employee = new Employee 
    {
        Name = "Employee 1",
        YearlyCompensation = 131259.89,
        YearsOfService = 12
    };
    employee.ProcessSalary();
    
    var empBonus = new EmployeeBonus(employee);
    empBonus.ProcessSalary();
```

<b>Output:</b>
```
$2,524.23 paid to Employee 1.
$18,275.42 paid to Employee 1 with $15,751.19 yearly bonus ammount.    
```
