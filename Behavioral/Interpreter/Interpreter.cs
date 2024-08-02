using System;
using System.Collections.Generic;
using System.Linq;
			
namespace ArijitDatta.DesignPatterns.Behavioral.Interpreter
{
	// Expression Interface (AbstractExpression)
	public interface IExpression
	{
		List<string> Interpret(Context ctx);
	}
	
	// Non-Terminal Expression Class
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
	
	// Non-Terminal Expression Class
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
	
	// Terminal Expression Class
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
	
	// The 'Context' class
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
	
	// The 'Interpreter' class
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
	
	public class Program
	{
		// Client Code
		public static void Main()
		{
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
			
			
		}
	}
	
	public class Table
	{
		public List<Record> Rows { get; set; }
		public Table()
		{
			Rows = new List<Record>();
		}
		public void AddRow(string fname, string lname)
		{
			Rows.Add(new Record { FirstName = fname, LastName = lname });
		}
	}
	
	public class Record
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
	}
}