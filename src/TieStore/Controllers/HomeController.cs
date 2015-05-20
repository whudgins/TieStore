using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using TieStore.Web.Models;

namespace TieStore.Web
{
    public class HomeController : Controller
    {
        private readonly ProductDbContext _dbContext;
        
        public HomeController(ProductDbContext dbContext) 
        {
        	_dbContext = dbContext;
        }
        
        public IActionResult Index()
        {
            // Checks for products, creates if not present.
            // Due to unable to create / persist in Startup.cs, not sure why
            Array products = GetAllProducts();
            if (products != null && products.Length == 0) CreateProducts();
            return View(GetAllProducts());
        }
        
        // Creates all data bc of In-Mem DB
        // horribly ugly, but due to the lack of MSSQL / SQLite
        // https://github.com/aspnet/EntityFramework/releases/tag/7.0.0-beta4       
        public List<Product> CreateProducts() {
            var products = new List<Product> {
                new Product {Id = 1, CategoryId=1,Name = "Blue Tie", Description = "Tie description goes here.", Price = 5.0, SalePrice = 5.0, Featured = true},
                new Product {Id = 2, CategoryId=1,Name = "Red Tie", Description = "Tie description goes here.", Price = 10.0, SalePrice = 9.0, Featured = false},
                new Product {Id = 3, CategoryId=1,Name = "Green Tie", Description = "Tie description goes here.", Price = 5.0, SalePrice = 4.0, Featured = false},
                new Product {Id = 4, CategoryId=1,Name = "Checkered Tie", Description = "Tie description goes here.", Price = 5.0, SalePrice = 5.0, Featured = false},
                new Product {Id = 5, CategoryId=2,Name = "Gingham Bow Tie", Description = "Tie description goes here.", Price = 10.0, SalePrice = 9.0, Featured = true},
                new Product {Id = 6, CategoryId=2,Name = "Red Silk Bow Tie", Description = "Tie description goes here.", Price = 5.0, SalePrice = 4.0, Featured = false},
                new Product {Id = 7, CategoryId=2,Name = "Blue Check Bow Tie", Description = "Tie description goes here.", Price = 5.0, SalePrice = 4.0, Featured = false},
                new Product {Id = 8, CategoryId=2,Name = "Orange Pre-Tied Bow Tie", Description = "Tie description goes here.", Price = 10.0, SalePrice = 9.0, Featured = false},
                new Product {Id = 9, CategoryId=3,Name = "Yellow Socks", Description = "Tie description goes here.", Price = 5.0, SalePrice = 4.0, Featured = true },
                new Product {Id = 10, CategoryId=3,Name = "Striped Red Socks", Description = "Tie description goes here.", Price = 5.0, SalePrice = 4.0, Featured = false},
                new Product {Id = 11, CategoryId=3,Name = "Blue & Green Dot Socks", Description = "Tie description goes here.", Price = 10.0, SalePrice = 9.0, Featured = true},
                new Product {Id = 12, CategoryId=3, Name = "Paisley Socks", Description = "Tie description goes here.", Price = 5.0, SalePrice = 4.0, Featured = false },
                new Product {Id = 13, CategoryId=4, Name = "Woven Belt", Description = "Tie description goes here.", Price = 5.0, SalePrice = 4.0, Featured = false},
                new Product {Id = 14, CategoryId=4, Name = "Leather Belt", Description = "Tie description goes here.", Price = 10.0, SalePrice = 9.0, Featured = true},
                new Product {Id = 15, CategoryId=4, Name = "Yellow Shoelaces", Description = "Tie description goes here.", Price = 5.0, SalePrice = 4.0, Featured = false },
                new Product {Id = 16, CategoryId=4, Name = "Brown Shoelaces", Description = "Tie description goes here.", Price = 5.0, SalePrice = 4.0, Featured = true }
            };
            products.ForEach(p => _dbContext.Products.Add(p));
            
            var categories = new List<Category> {
                new Category {Id = 1, Name = "Category 1", Description = "Tie description goes here."},
                new Category {Id = 2, Name = "Category 2", Description = "Tie description goes here."},
                new Category {Id = 3, Name = "Category 3", Description = "Tie description goes here." },
                new Category {Id = 4, Name = "Category 4", Description = "Tie description goes here."}
            };
            categories.ForEach(c => _dbContext.Categories.Add(c));
           Console.WriteLine("Creating data.");
            _dbContext.SaveChanges();
            return products;
        }
        
        public Array GetAllProducts()
        {
            return _dbContext.Products.Where(p => p.Featured).ToArray();
        }       
    }
}
