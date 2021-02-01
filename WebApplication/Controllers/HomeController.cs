using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication.DILifeTime;
using WebApplication.Models;
using WebApplication.MyDependency.IOC;
using WebApplication.Service;

namespace WebApplication.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IEnumerable<IMyDependency> _dependency;
		private readonly IOperationTransient _transientOperation;
		private readonly IOperationSingleton _singletonOperation;
		private readonly IOperationScoped _scopedOperation;
		private readonly TestServiceScoped _testServiceScoped;
		private readonly TestServiceTransient _testServiceTransient;

		public HomeController(ILogger<HomeController> logger, IEnumerable<IMyDependency> dependency, IOperationTransient transientOperation, IOperationSingleton singletonOperation, IOperationScoped scopedOperation, TestServiceScoped testServiceScoped, TestServiceTransient testServiceTransient)
		{
			_logger = logger;
			_dependency = dependency;
			_transientOperation = transientOperation;
			_singletonOperation = singletonOperation;
			_scopedOperation = scopedOperation;
			_testServiceScoped = testServiceScoped;
			_testServiceTransient = testServiceTransient;
		}

		public IActionResult Index()
		{
			
			_logger.LogInformation($"Transient: {_transientOperation.OperationId}");
			_logger.LogInformation($"Scoped: {_scopedOperation.OperationId}");
			_logger.LogInformation($"Singleton: {_singletonOperation.OperationId}");
			_dependency.First(dependency => dependency.GetType() == typeof(MyDependency3)).WriteMessage("잘나옴");
			_testServiceScoped.Get();
			_testServiceTransient.Get();
			return View();
		}

		public IActionResult Privacy()
		{
			_testServiceTransient.Get();
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
		}
	}
}