using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NETAPI_SEM3.Models;
using NETAPI_SEM3.Middlewares;
using NETAPI_SEM3.Services;
using NETAPI_SEM3.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
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
            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            //Configure SqlServer
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<DatabaseContext>(option => option.UseLazyLoadingProxies().UseSqlServer(connectionString));



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



            //services.AddIdentity<User, IdentityRole>(options =>
            //{
            //    options.User.RequireUniqueEmail = false;
            //})
            //.AddEntityFrameworkStores<DatabaseContext>()
            //.AddDefaultTokenProviders();

            //configuration Identity
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<DatabaseContext>();





            //Configure Service
           services.AddScoped<DemoService, DemoServiceImpl>();
            services.AddScoped<AdsPackageService, AdsPackageServiceImpl>();
            services.AddScoped<MemberService, MemberServiceImpl>();
            services.AddScoped<PropertyService, PropertyServiceImpl>();
            services.AddScoped<ReportService, ReportServiceImpl>();
            services.AddScoped<CategoryService, CategoryServiceImpl>();
            services.AddScoped<RoleService, RoleServiceImpl>();
            services.AddScoped<StatusService, StatusServiceImpl>();
            services.AddScoped<ImageService, ImageServiceImpl>();
            services.AddScoped<InvoiceService, InvoiceServiceImpl>();
            services.AddScoped<AccountService, AccountServiceImpl>();
            //Configure AutoMapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

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
            app.UseStaticFiles();

            app.UseCors(builder => builder
                .AllowAnyHeader()
                .AllowAnyMethod()
                .SetIsOriginAllowed((host) => true)
                .AllowCredentials()
            );
            app.UseMiddleware<CorsMiddleware>();
            //app.UseMiddleware<JWTMiddleware>();
            

            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
