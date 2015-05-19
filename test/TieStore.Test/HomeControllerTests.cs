using Xunit;
using System;
using System.Linq;
using System.Collections.Generic;
using TieStore.Web.Models;

namespace TieStoreTests
{
    public class HomeControllerTests
    {
        
        [Fact]
        public void PassingTest()
        {
            Product p = new Product();
            p.Price = 5;
            p.SalePrice = 5;
            Assert.False(p.OnSale);
        }
    }
}