using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;
using Xunit.Abstractions;

namespace WebApplicationTest.ControllerTest
{
	public class HomeControllerTests : IClassFixture<WebApplicationFactory<WebApplication.Startup>>

	{
		private readonly ITestOutputHelper _testOutputHelper;
		private readonly WebApplicationFactory<WebApplication.Startup> _factory;


		public HomeControllerTests(ITestOutputHelper testOutputHelper,
			WebApplicationFactory<WebApplication.Startup> factory)
		{
			_testOutputHelper = testOutputHelper;
			_factory = factory;
		}

		[Fact]
		public async Task Index_Test()
		{
			var response = await _factory.CreateClient().GetAsync("");

			_testOutputHelper.WriteLine(await response.Content.ReadAsStringAsync());
		}
	}
}