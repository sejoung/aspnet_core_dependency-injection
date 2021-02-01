using System;

namespace WebApplication.MyDependency.NoIOC
{
	public class MyDependency
	{
		public void WriteMessage(string message)
		{
			Console.WriteLine($"MyDependency.WriteMessage called. Message: {message}");
		}
	}
}