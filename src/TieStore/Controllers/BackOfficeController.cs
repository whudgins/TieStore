using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using TieStore.Web.Models;
using Microsoft.Data.Entity;

namespace TieStore {
    public class BackOfficeController : Controller {
         private readonly ProductDbContext _dbContext;
        
        public BackOfficeController(ProductDbContext dbContext) 
        {
        	_dbContext = dbContext;
        }
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Create()
        {
            return View();
        } 
        
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
        
        public IActionResult ListAll()
        {
            return View(_dbContext.Products.OrderBy(p => p.Id).ToArray());
        } 
    }
}

