using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NETAPI_SEM3.Middlewares;
using NETAPI_SEM3.Models;
using NETAPI_SEM3.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETAPI_SEM3
{
	public class Startup
	{
		private IConfiguration configuration;

		public Startup(IConfiguration _configuration)
		{
			configuration = _configuration;

		}

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();

			// Khai bao ket noi database
			var connectionString = configuration.GetConnectionString("DefaultConnection");
			services.AddDbContext<ProjectSem3DBContext>(option => option.UseLazyLoadingProxies().UseSqlServer(connectionString));
			services.AddScoped<DemoService, DemoServiceImpl>();
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseCors(builder => builder
				.AllowAnyHeader()
				.AllowAnyMethod()
				.SetIsOriginAllowed((host) => true)
				.AllowCredentials()
			);
			app.UseMiddleware<CorsMiddleware>();

			app.UseRouting();
			app.UseStaticFiles();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
