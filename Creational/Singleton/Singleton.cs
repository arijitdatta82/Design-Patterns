using System;

namespace ArijitDatta.DesignPatterns.Creational.Singleton
{
	public sealed class Logger
	{
		// Static readonly member to hold the single instance
		private static readonly Logger _loggerInstance = new Logger();
		// Private Constructor
		private Logger()
		{
		}
		// Static method for global access
		public static Logger GetInstance()
		{
			// Return the same instance
			return _loggerInstance;
		}
		public void WriteLog(string message)
		{
			Console.WriteLine(message);
		}
	}
	
	public class Program
	{
		// Client Code
		public static void Main()
		{
			var singletonLoggerInstance = Logger.GetInstance();
			
			singletonLoggerInstance.WriteLog("Writing log using Singleton Design Pattern");
		}
	}
}