using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace WebApplication.Filter
{
	public class RequestSetOptionsStartupFilter : IStartupFilter
	{
		public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
		{
			return builder =>
			{
				builder.UseMiddleware<RequestSetOptionsMiddleware>();
				next(builder);
			};
		}
	}
}