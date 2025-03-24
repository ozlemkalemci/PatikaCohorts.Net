// Middlewares/ValidationMiddleware.cs
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using FluentValidation;
using System.Text.Json;
using System.Linq;

namespace PatikaPaparaBootcamp.Middlewares
{
	public class ValidationMiddleware
	{
		private readonly RequestDelegate _next;

		public ValidationMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task InvokeAsync(HttpContext context)
		{
			if (!context.Request.ContentType?.Contains("application/json") ?? true)
			{
				await _next(context);
				return;
			}

			// Proceed
			try
			{
				await _next(context);
			}
			catch (ValidationException ex)
			{
				context.Response.ContentType = "application/json";
				context.Response.StatusCode = 400;

				var response = new
				{
					status = 400,
					error = "Validation Error",
					errors = ex.Errors.Select(e => new { field = e.PropertyName, message = e.ErrorMessage })
				};

				await context.Response.WriteAsync(JsonSerializer.Serialize(response));
			}
		}
	}
}
