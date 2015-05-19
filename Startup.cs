using System;
using Microsoft.AspNet.Builder;
using Microsoft.Framework.DependencyInjection;
using TieStore.Web.Models;

namespace TieStore
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMvc();
            var usingMono = Type.GetType("Mono.Runtime") != null;
            if (usingMono) {
                services.AddEntityFramework().AddInMemoryStore().AddDbContext<ProductDbContext>();
            }
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseErrorPage();

            app.UseMvc(routes =>
            {
                routes.MapRoute("Home", "{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute("Products", "{controller=Product}/{Action=Id}/{id=1}");
                routes.MapRoute("Categories", "{controller=Category}/{Action=Id}/{id=1}");
            });

            app.UseWelcomePage();
        }
    }
}
