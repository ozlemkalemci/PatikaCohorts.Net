using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using PatikaPaparaBootcamp.Application.Interfaces;
using PatikaPaparaBootcamp.Application.Services;
using PatikaPaparaBootcamp.Application.Validations;
using PatikaPaparaBootcamp.Infrastructure.Interfaces;
using PatikaPaparaBootcamp.Infrastructure.Repositories;
using PatikaPaparaBootcamp.Middlewares;
using System.Linq;

namespace PatikaPaparaBootcamp
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers()
					.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ClientValidator>());

			services.Configure<ApiBehaviorOptions>(options =>
			{
				options.InvalidModelStateResponseFactory = context =>
				{
					var errors = context.ModelState
						.Where(e => e.Value.Errors.Count > 0)
						.Select(e => new
						{
							Field = e.Key,
							Errors = e.Value.Errors.Select(x => x.ErrorMessage)
						});

					return new BadRequestObjectResult(new
					{
						Status = 400,
						Message = "Validation failed",
						Errors = errors
					});
				};
			});

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "PatikaPaparaBootcamp", Version = "v1" });
			});
			services.AddSingleton<IClientRepository, InMemoryClientRepository>();
			services.AddScoped<IClientService, ClientService>();


		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PatikaPaparaBootcamp v1"));
			}

			app.UseMiddleware<ErrorHandlerMiddleware>();

			app.UseHttpsRedirection();
			app.UseRouting();
			app.UseAuthorization();
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}