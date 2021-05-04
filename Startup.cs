using ASP_APIServer1.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_APIServer1
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
			//services.AddDbContext<MyDBContext>(option => option.UseLazyLoadingProxies().UseSqlServer(connectionString));
			services.AddScoped<DemoService, DemoServiceImpl>();
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseRouting();
			app.UseStaticFiles();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
