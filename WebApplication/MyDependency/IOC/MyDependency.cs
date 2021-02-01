using System;

namespace WebApplication.MyDependency.IOC
{
	public class MyDependency : IMyDependency
	{
		public void WriteMessage(string message)
		{
			Console.WriteLine($"MyDependency.WriteMessage Message: {message}");
		}
	}
}