using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace WebApplication.Filter
{
	public class RequestSetOptionsMiddleware
	{
		private readonly RequestDelegate _next;

		public RequestSetOptionsMiddleware( RequestDelegate next )
		{
			_next = next;
		}

		// Test with https://localhost:5001/Home/Privacy/?option=Hello
		public async Task Invoke(HttpContext httpContext)
		{
			var option = httpContext.Request.Query["option"];

			if (!string.IsNullOrWhiteSpace(option))
			{
				Console.WriteLine(option);
				httpContext.Items["option"] = WebUtility.HtmlEncode(option);
			}

			await _next(httpContext);
		}
	}
}