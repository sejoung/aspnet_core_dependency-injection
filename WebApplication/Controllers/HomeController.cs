﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication.Models;
using WebApplication.MyDependency.IOC;

namespace WebApplication.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IEnumerable<IMyDependency> _dependency;

		public HomeController(ILogger<HomeController> logger,IEnumerable<IMyDependency> dependency)
		{
			_logger = logger;
			_dependency = dependency;
		}

		public IActionResult Index()
		{
			_dependency.First(dependency => dependency.GetType() == typeof(MyDependency.IOC.MyDependency)).WriteMessage("잘나옴");
			
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
		}
	}
}