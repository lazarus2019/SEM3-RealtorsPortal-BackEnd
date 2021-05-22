using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
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
			services.AddControllers().AddNewtonsoftJson(options =>
		options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

			// Khai bao ket noi database
			var connectionString = configuration.GetConnectionString("DefaultConnection");
			services.AddDbContext<ProjectSem3DBContext>(option => option.UseLazyLoadingProxies().UseSqlServer(connectionString));
			// Add services
			services.AddScoped<NewsService, NewsServiceImpl>();
			services.AddScoped<NewsImageService, NewsImageServiceImpl>();
			services.AddScoped<ProfileService, ProfileServiceImpl>();
			services.AddScoped<FAQService, FAQServiceImpl>();


			// Upload Image
			services.Configure<FormOptions>(o =>
			{
				o.ValueLengthLimit = int.MaxValue;
				o.MultipartBodyLengthLimit = int.MaxValue;
				o.MemoryBufferThreshold = int.MaxValue;
			});
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

			// Upload Image
			app.UseStaticFiles();


			app.UseRouting();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
