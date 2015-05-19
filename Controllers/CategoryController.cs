using System;
using System.Linq;
using Microsoft.AspNet.Mvc;
using TieStore.Web.Models;
using System.Collections.Generic;

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
        
        public List<ProductViewModel> GetCategoryById(int id)
        {
            Category category = _dbContext.Categories.FirstOrDefault(c => c.Id == id);
            Array products = _dbContext.Products.Where(p => p.CategoryId == id).ToArray();
            if (products != null) {
                return createProductViewModels(products, category);
            } else {
                throw new Exception();
            }
        }
        
                // GET: /Category/{id}
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Sale()
        {
            return View(_dbContext.Products.Where(p=> p.OnSale).ToArray());
        }
        
        public List<ProductViewModel> createProductViewModels(Array products, Category c) {
			List<ProductViewModel> viewModels = new List<ProductViewModel>();
			foreach (Product product in products) {
				var vm = new ProductViewModel(product, c);
				viewModels .Add(vm);
			}
			return viewModels;
		}
    }
}
