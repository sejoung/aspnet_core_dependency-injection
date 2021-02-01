namespace WebApplication.MyDependency.NoIOC
{
	public class IndexModel
	{
		private readonly MyDependency _dependency = new MyDependency();
		
		public void message()
		{
			_dependency.WriteMessage("IndexModel.OnGet created this message.");
		}
	}
}