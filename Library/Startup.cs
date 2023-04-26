using FluentValidation.AspNetCore;
using Library.Context;
using Library.Models;
using Library.RepositoryPattern.Base;
using Library.RepositoryPattern.Concrete;
using Library.RepositoryPattern.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
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

namespace Library
{
	public class Startup
	{
		readonly IConfiguration _configuration;

		public Startup(IConfiguration configuration)
		{
			_configuration= configuration;
		}

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<MyDbContext>(options => options.UseSqlServer(_configuration["ConnectionStrings:Mssql"]));

			services.AddControllersWithViews().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Startup>());

			services.AddScoped<IRepository<BookType>, Repository<BookType>>();

			services.AddScoped<IRepository<AppUser>, Repository<AppUser>>();


			//services.AddScoped<IRepository<Author>, Repository<Author>>();   //Author için repository ekledim .

			services.AddScoped<IAuthorRepository, AuthorRepository>();

			services.AddScoped<IBookRepository, BookRepository>();

			//  services.AddScoped<IBookTypeRepository, BookTypeRepository>();

			//services.AddScoped<IBookTypeRepository, BookTypeRepository>();

			services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
			{
				options.LoginPath="/Auth/Login";
				options.Cookie.Name= "UserDetail";
				options.AccessDeniedPath= "/Auth/Login";
			});
			services.AddAuthorization(options =>
			{
				options.AddPolicy("AdminPolicy", policy => policy.RequireClaim("role", "admin"));
				options.AddPolicy("UserPolicy", policy => policy.RequireClaim("role", "admin", "user"));

			});




		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env, MyDbContext context)
		{
			context.Database.Migrate();
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthentication();

			app.UseAuthorization(); // kimlik kontrolü 

			app.UseEndpoints(endpoints =>
			{
			    endpoints.MapControllerRoute(
				         name: "management",
	                     pattern: "/Management",
	                     defaults: new { area = "Management", controller = "Home", action = "Index" });
				// endpoints.MapDefaultControllerRoute();


				endpoints.MapControllerRoute(
						name: "DefaultArea",
						pattern: "{area:exists}/{controller=Home}/{action=Index }/{id?}"   // areas? or area?
						);
				endpoints.MapControllerRoute(
				name: "Default",
				pattern: "{controller=Auth}/{action=Login}/{id?}"
				);

				/*endpoints.MapGet("/", async context =>
                {   
                    await context.Response.WriteAsync("Hello World!");
                });
                */
			});
		}
	}
}
