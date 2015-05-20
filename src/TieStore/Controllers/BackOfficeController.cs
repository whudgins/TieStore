using System;
using System.Linq;
using Microsoft.AspNet.Mvc;
using TieStore.Web.Models;

namespace TieStore {
    public class BackOfficeController : Controller {
         private readonly ProductDbContext _dbContext;
        
        public BackOfficeController(ProductDbContext dbContext) 
        {
        	_dbContext = dbContext;
        }
        
        // GET: /BackOffice/Index
        public IActionResult Index()
        {
            return View();
        }
        
        // GET: /BackOffice/Create
        public IActionResult Create()
        {
            return View();
        } 
        
        // POST: /BackOffice/Create
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Create(Product product)
        {
            Console.WriteLine("Creating:" + product.ToString());
            if (ModelState.IsValid) {
                _dbContext.Add(product);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }
        
        // GET: /BackOffice/ListAll
        public IActionResult ListAll()
        {
            return View(_dbContext.Products.OrderBy(p => p.Id).ToArray());
        } 
    }
}

