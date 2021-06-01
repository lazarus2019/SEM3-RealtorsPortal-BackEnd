using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NETAPI_SEM3.Middlewares;
using NETAPI_SEM3.Models;
using NETAPI_SEM3.Services;
using System.Reflection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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

			services.Configure<IdentityOptions>(options =>
			{
				// Default Password settings.
				options.Password.RequireDigit = false;
				options.Password.RequireLowercase = false;
				options.Password.RequireNonAlphanumeric = false;
				options.Password.RequireUppercase = false;
				options.Password.RequiredLength = 6;
				options.Password.RequiredUniqueChars = 1;
			});

			services.AddIdentity<IdentityUser, IdentityRole>()
				.AddEntityFrameworkStores<ProjectSem3DBContext>()
				.AddDefaultTokenProviders();


			// Add services
			services.AddScoped<NewsService, NewsServiceImpl>();
			services.AddScoped<NewsImageService, NewsImageServiceImpl>();
			services.AddScoped<ProfileService, ProfileServiceImpl>();
			services.AddScoped<FAQService, FAQServiceImpl>();
			services.AddScoped<MailboxService, MailboxServiceImpl>();
			services.AddScoped<SettingService, SettingServiceServiceImpl>();
			services.AddScoped<MemberService, MemberServiceImpl>();
			services.AddScoped<NewsCategoryService, NewsCategoryServiceImpl>();
			services.AddScoped<AccountService, AccountServiceImpl>();
			services.AddScoped<CategoryService, CategoryServiceImpl>();

			var emailConfig = configuration
				.GetSection("EmailConfiguration")
				.Get<EmailConfiguration>();
			services.AddSingleton(emailConfig);

			services.AddScoped<EmailService, EmailServiceImpl>();

			// Upload Image
			services.Configure<FormOptions>(o =>
			{
				o.ValueLengthLimit = int.MaxValue;
				o.MultipartBodyLengthLimit = int.MaxValue;
				o.MemoryBufferThreshold = int.MaxValue;
			});

			//Configure AutoMapper
			
			//services.AddAutoMapper(Assembly.GetExecutingAssembly());

			services.AddAuthentication()
			   .AddCookie()
			   .AddJwtBearer(cfg =>
			   {
				   cfg.TokenValidationParameters = new TokenValidationParameters()
				   {
					   ValidIssuer = configuration["Tokens:Issuer"],
					   ValidAudience = configuration["Tokens:Audience"],
					   IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Tokens:Key"]))
				   };
			   });
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			app.UseRouting();

			app.UseAuthentication();
			app.UseAuthorization();

			app.UseCors(builder => builder
				.AllowAnyHeader()
				.AllowAnyMethod()
				.SetIsOriginAllowed((host) => true)
				.AllowCredentials()
			);
			app.UseMiddleware<CorsMiddleware>();

			// Upload Image
			app.UseStaticFiles();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
