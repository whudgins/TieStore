using Xunit;
using TieStore.Web;
using TieStore.Web.Models;
using Microsoft.Framework.DependencyInjection;

namespace TieStoreTests
{
    public class HomeControllerTests
    {
        ProductDbContext db;
        HomeController hc;
        IServiceCollection services;
        
        public HomeControllerTests() {
            services.AddMvc();
            services.AddEntityFramework().AddInMemoryStore().AddDbContext<ProductDbContext>();
            db = new ProductDbContext();
            hc = new HomeController(db);
            hc.CreateProducts();
        }
        
        [Fact]
        public void CategoryAssignment()
        {
           var p = hc.GetProductById(16);
           Assert.Null(p);
        }
    }
}