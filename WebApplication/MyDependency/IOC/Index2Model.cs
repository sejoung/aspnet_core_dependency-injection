namespace WebApplication.MyDependency.IOC
{
	public class Index2Model
	{
		private readonly IMyDependency _myDependency;

		public Index2Model(IMyDependency myDependency)
		{
			_myDependency = myDependency;
		}

		public void message()
		{
			_myDependency.WriteMessage("Index2Model.OnGet");
		}
	}
}