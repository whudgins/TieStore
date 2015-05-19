using System;
using System.Linq;
using Microsoft.AspNet.Mvc;
using TieStore.Web.Models;

namespace TieStore.Web
{
    public class ProductController : Controller
    {
        private readonly ProductDbContext _dbContext;

		public ProductController(ProductDbContext dbContext) 
		{
			_dbContext = dbContext;
		}
        // GET: /Product/{id}
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Id(int? id)
        {
            Console.WriteLine(id);
            if (id.HasValue) {
                return View(GetProductById((int)id));
            }
            return View(GetProductById(0));
        }

        public Product GetProductById(int id)
        {
            Product product =  _dbContext.Products.FirstOrDefault(p => p.Id == id);
            if (product != null) {
                return product;
            } else {
                return new Product {Id = 0, Name = "Bad Product", Description = "Why won't u read DB", Price = 5.0, SalePrice = 4.0};
            }
        }

        public Array GetAllProducts()
        {
            return _dbContext.Products.ToArray();
        }
    }
}
