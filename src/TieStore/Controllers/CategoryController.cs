using System;
using System.Linq;
using Microsoft.AspNet.Mvc;
using TieStore.Web.Models;

namespace TieStore.Web
{
    public class CategoryController : Controller
    {
        private readonly ProductDbContext _dbContext;

		public CategoryController(ProductDbContext dbContext) 
		{
			_dbContext = dbContext;
		}
        
        // GET: /Category/{id}
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Id(int? id)
        {
            Console.WriteLine(id);
            if (id.HasValue) {
                try {
                    return View(GetCategoryById((int)id));
                }
                catch (Exception e) {
                    return new HttpNotFoundResult();
                }
            }
            return new HttpNotFoundResult();
        }
        
        // GET: /Category/PriceAsc/{id}
        [HttpGet]
        [AllowAnonymous]
        public IActionResult PriceAsc(int? id)
        {
            Console.WriteLine(id);
            if (id.HasValue) {
                try {
                    return View(GetCategoryByPriceAscending((int)id));
                }
                catch (Exception e) {
                    return new HttpNotFoundResult();
                }
            }
            return new HttpNotFoundResult();
        }
        
        // GET: /Category/PriceDesc/{id}
        public IActionResult PriceDesc(int? id)
        {
            Console.WriteLine(id);
            if (id.HasValue) {
                try {
                    return View(GetCategoryByPriceDescending((int)id));
                }
                catch (Exception e) {
                    return new HttpNotFoundResult();
                }
            }
            return new HttpNotFoundResult();
        }
        
        // GET: /Category/Sale
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Sale()
        {
            return View(_dbContext.Products.Where(p=> p.OnSale).OrderBy(p => p.Name).ToArray());
        }
        
        // GET: /Category/SaleAsc
        // Sorts on SalePrice Ascending
        [HttpGet]
        [AllowAnonymous]
        public IActionResult SaleAsc()
        {
            return View(_dbContext.Products.Where(p=> p.OnSale).OrderBy(p => p.SalePrice).ToArray());
        }
        
        // GET: /Category/SaleDesc
        // Sorts on SalePrice Descending
        [HttpGet]
        [AllowAnonymous]
        public IActionResult SaleDesc()
        {
            return View(_dbContext.Products.Where(p=> p.OnSale).OrderByDescending(p => p.SalePrice).ToArray());
        }
        
        
        // Begin data search methods
        public Array GetCategoryById(int id)
        {
            Category category = _dbContext.Categories.FirstOrDefault(c => c.Id == id);
            Array products = _dbContext.Products.Where(p => p.CategoryId == id).OrderBy(p => p.Name).ToArray();
            if (products != null) {
                return products;
            } else {
                throw new Exception();
            }
        }
        
        public Array GetCategoryByPriceAscending(int id)
        {
            Category category = _dbContext.Categories.FirstOrDefault(c => c.Id == id);
            Array products = _dbContext.Products.Where(p => p.CategoryId == id).OrderBy(p => p.SalePrice).ToArray();
            if (products != null) {
                return products;
            } else {
                throw new Exception();
            }
        }
        
        public Array GetCategoryByPriceDescending(int id)
        {
            Category category = _dbContext.Categories.FirstOrDefault(c => c.Id == id);
            Array products = _dbContext.Products.Where(p => p.CategoryId == id).OrderByDescending(p => p.SalePrice).ToArray();
            if (products != null) {
                return products;
            } else {
                throw new Exception();
            }
        }
    }
}
