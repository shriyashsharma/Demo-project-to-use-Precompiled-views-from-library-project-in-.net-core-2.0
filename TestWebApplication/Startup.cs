using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryProject.Controllers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.FileProviders;

namespace TestWebApplication
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
			// This will retrieve the assembly for your custom library.
			var assembly = typeof(HomeLibraryController).GetTypeInfo().Assembly;

			// This will add the assembly as an application part. ASP.NET Core will then find controllers within it.
			services.AddMvc()
					.AddApplicationPart(assembly);
			// This will simply add the Views of compiled dll file 
			services.Configure<RazorViewEngineOptions>(options =>
			{
				options.FileProviders.Add(new EmbeddedFileProvider(
									 typeof(HomeLibraryController).GetTypeInfo().Assembly));

			});
			
			//http://localhost:50644/HomeLibrary/AboutLibrary
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=HomeLibrary}/{action=AboutLibrary}/{id?}");
            });
        }
    }
}
