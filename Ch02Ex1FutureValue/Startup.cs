using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ch02Ex1FutureValue
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        /// <summary>
        /// Method ConfigureServices() allows us to add controller with Views to this MVC Project.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            //AddControllersWithViews() enables the Services required by the Controllers and Razor Views of the MVC App.
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// <summary>
        /// Configure() method defines weather we are in the Developer mode/ Production Mode. So the MiddleWare can be accessed differently for changes to configuration.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //Below are the Services this MVC App is using.
            //Statement below checks if the web hosting environment is a Development env.
            if (env.IsDevelopment())
            {
               //If ture, Middleware handles exceptions by displaying page for Developers.
               app.UseDeveloperExceptionPage();
            }
            else
            {
                // If false, Middleware handles exceptions by displaying page that the Developers Customizes for end users. This is for Production Env case.
                app.UseExceptionHandler("/Home/Error");
                //UseHsts() method configures the middleware to send HTTP-HSTS header to the clients.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            //UseEndpoints() method sets the Default Controller for this app to the Home Controller and sets the default action the the Index() action.
            //Hence, when app starts, the UseEndpoints() method calls the index() action method of the HomeController.cs file and displays the Index() view.
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
