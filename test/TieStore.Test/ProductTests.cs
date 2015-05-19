using Xunit;
using TieStore.Web.Models;

namespace TieStoreTests
{
    public class ProductTests
    {
        [Fact]
        public void SaleTest()
        {
            Product p = new Product();
            p.Price = 5;
            p.SalePrice = 5;
            Assert.False(p.OnSale);
        }
    }
}