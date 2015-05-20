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
            Console.WriteLine("Getting PDP for Product #" + id);
            if (id.HasValue) {
                return View(_dbContext.Products.FirstOrDefault(p => p.Id == id));
            }
            return new HttpNotFoundResult();
        }
    }
}
