# Interpreter Design Pattern

## Definition
The interpreter pattern is a design pattern that specifies how to evaluate sentences in a language. This design pattern facilitates the interpretation and evaluation of expressions or language grammars.

## Structure
![ScreenShot](/Assets/Images/Interpreter_UML.jpg)

## Real-Time Code Example
We are building a query language using interpreter design pattern.
[source code](Interpreter.cs)

<b>AbstractExpression</b> declares an interface for executing an operation.
```
	public interface IExpression
	{
		List<string> Interpret(Context ctx);
	}
```

<b>TerminalExpression</b> implements an Interpret operation associated with terminal symbols in the grammar. An instance is required for every terminal symbol in the sentence.
```
	public class OrderbyExpression : IExpression
	{
		private string _sortOrder;
		
		public OrderbyExpression(string sortOrder)
		{
			_sortOrder = sortOrder;
		}
		public List<string> Interpret(Context context)
		{
			context.SortOrder = _sortOrder;
			return context.GetResult();
		}
	}
```

<b>NonterminalExpression</b> classes are responsible for handling composite expressions, which consist of multiple sub-expressions. 
```
	public class SelectExpression : IExpression
	{
		private string _column;
		public FromExpression From { get; set; }
		
		public SelectExpression(string column)
		{
			_column = column;
		}
		
		public List<string> Interpret(Context context)
		{
			context.Column = _column;
			return From.Interpret(context);
		}
	}

    public class FromExpression : IExpression
	{
		private string _table;
		public OrderbyExpression Orderby { get; set; }
		
		public FromExpression(string table)
		{
			_table = table;
		}
		
		public List<string> Interpret(Context context)
		{
			context.Table = _table;
			return Orderby.Interpret(context);
		}
	}
```

<b>Context</b> contains information that is global to the interpreter.
```
	public class Context 
	{
		private Dictionary<string, Table> tables = new Dictionary<string, Table>();
		public string Column { get; set; }
		public string Table { get; set; }
		public string SortOrder { get; set; }
		
		public Context()
		{
			loadTables();
		}
		
		public List<string> GetResult()
		{
			var result = new List<string>();
			
			Table table = tables[Table];
			
			foreach (Record row in table.Rows)
			{
				if (Column == "FirstName")
					result.Add(row.FirstName);
				else 
					result.Add(row.LastName);
			}
			
			if (SortOrder == "ASC")
				result = result.OrderBy(r => r).ToList();
			else
				result = result.OrderByDescending(r => r).ToList();
			
			return result;
		}
		
		private void loadTables()
		{
			var teacher = new Table();
			teacher.AddRow("Tom", "Dalton");
			teacher.AddRow("Dan", "Tu");
			teacher.AddRow("Sumit", "Bhat");
			tables.Add("Teacher", teacher);
			
			var student = new Table();
			student.AddRow("Rajesh", "Kuthrapally");
			student.AddRow("Sheldon", "Cooper");
			student.AddRow("Leonard", "Hofsteder");
			student.AddRow("Howard", "Wollowitz");
			tables.Add("Student", student);
		}
	}
```

<b>Interpreter</b> is responsible for coordinating the interpretation process. It manages the context, creates expression objects representing the input expression, and interprets the expression by traversing and evaluating the expression tree. 
```
	public class Interpreter
	{
		Context _context;
		public Interpreter(Context context)
		{
			_context = context;
		}
		
		public List<string> Interpret(string _select, string _from, string _orderby) 
		{
			var exp = buildExpressionTree(_select, _from, _orderby);
			return 	exp.Interpret(_context);
		}
		
		private IExpression buildExpressionTree(string _select, string _from, string _orderby) 
		{
			var selectExp = new SelectExpression(_select)
			{
				From = new FromExpression(_from)
				{
					Orderby = new OrderbyExpression(_orderby)
				}
			};
				
			return 	selectExp;
		}

	}
```

<b>Client Code:</b>
```
    var context = new Context();
    var interpreter = new Interpreter(context);
    
    var students = interpreter.Interpret("FirstName", "Student", "DESC");
    
    Console.WriteLine("Result of students query:");
    foreach (var student in students)
    {
        Console.WriteLine(" " + student);
    }
    
    Console.WriteLine();
    
    var context1 = new Context();
    var interpreter1 = new Interpreter(context1);
    var teachers = interpreter1.Interpret("LastName", "Teacher", "ASC");
    
    Console.WriteLine("Result of teachers query:");
    foreach (var teacher in teachers)
    {
        Console.WriteLine(" " + teacher);
    }
```

<b>Output:</b>
```
Result of students query:
 Sheldon
 Rajesh
 Leonard
 Howard

Result of teachers query:
 Bhat
 Dalton
 Tu    
```