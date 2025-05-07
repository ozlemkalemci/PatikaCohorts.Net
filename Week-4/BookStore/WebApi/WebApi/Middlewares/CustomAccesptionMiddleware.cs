using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using WebApi.Services;

namespace WebApi.Middlewares
{
	public class CustomAccesptionMiddleware
	{
		private readonly RequestDelegate _next;
		private readonly ILoggerService _logger;

		public CustomAccesptionMiddleware(RequestDelegate next, ILoggerService logger)
		{
			_next = next;
			_logger = logger;
		}

		public async Task Invoke(HttpContext context)
		{
			var watch = Stopwatch.StartNew();

			try
			{
				string message = "[Request] HTTP" + context.Request.Method + " - " + context.Request.Path;
				_logger.Write(message);
				await _next(context);
				watch.Stop();
				message = "[Request] HTTP" + context.Request.Method + " - " + context.Request.Path;
				_logger.Write(message);
				await _next(context);

			}
			catch (Exception ex)
			{
				watch.Stop();
				await HandleException(context, ex, watch);
			}

		}

		private Task HandleException(HttpContext context, Exception ex, Stopwatch watch)
		{
			string message = "[Error]  HTTP " + context.Request.Method + " - " + context.Response.StatusCode + "Error Message" + " in " + watch.Elapsed.TotalMilliseconds + " ms";
			_logger.Write(message);
			context.Response.ContentType = "application/json";
			context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

			var result = JsonConvert.SerializeObject(new {error = ex.Message}, formatting: Formatting.None);

			return context.Response.WriteAsync(result);
		}
	}

	public static class CustomExceptionMiddlewareExtension
	{
		public static IApplicationBuilder UseCustomExceptionMiddleware(this IApplicationBuilder builder)
		{
			return builder.UseMiddleware<CustomAccesptionMiddleware>();
		}
	}
}
