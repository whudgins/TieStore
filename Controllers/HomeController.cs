using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using TieStore.Web.Models;
using Microsoft.Data.Entity;

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
            // horribly ugly, but due to the lack of MSSQL / SQLite
            // https://github.com/aspnet/EntityFramework/releases/tag/7.0.0-beta4
            Array products = GetAllProducts();
            if (products != null && products.Length == 0) CreateProducts();
            return View(GetOnSaleProducts());
        }       

        public List<Product> CreateProducts() {
                var products = new List<Product> {
                    new Product {Id = 1, CategoryId=1,Name = "Tie 1", Description = "Tie description goes here.", Price = 5.0, SalePrice = 5.0},
                    new Product {Id = 2, CategoryId=1,Name = "Tie 2", Description = "Tie description goes here.", Price = 10.0, SalePrice = 9.0},
                    new Product {Id = 3, CategoryId=1,Name = "Tie 3", Description = "Tie description goes here.", Price = 5.0, SalePrice = 4.0, },
                    new Product {Id = 4, CategoryId=1,Name = "Tie 4", Description = "Tie description goes here.", Price = 5.0, SalePrice = 5.0},
                    new Product {Id = 5, CategoryId=2,Name = "Product 5", Description = "Tie description goes here.", Price = 10.0, SalePrice = 9.0},
                    new Product {Id = 6, CategoryId=2,Name = "Product 6", Description = "Tie description goes here.", Price = 5.0, SalePrice = 4.0, },
                    new Product {Id = 7, CategoryId=2,Name = "Product 7", Description = "Tie description goes here.", Price = 5.0, SalePrice = 4.0},
                    new Product {Id = 8, CategoryId=2,Name = "Product 8", Description = "Tie description goes here.", Price = 10.0, SalePrice = 9.0},
                    new Product {Id = 9, CategoryId=3,Name = "Product 9", Description = "Tie description goes here.", Price = 5.0, SalePrice = 4.0, },
                    new Product {Id = 10, CategoryId=3,Name = "Product 10", Description = "Tie description goes here.", Price = 5.0, SalePrice = 4.0},
                    new Product {Id = 11, CategoryId=3,Name = "Product 11", Description = "Tie description goes here.", Price = 10.0, SalePrice = 9.0},
                    new Product {Id = 12, CategoryId=3, Name = "Product 12", Description = "Tie description goes here.", Price = 5.0, SalePrice = 4.0, },
                    new Product {Id = 13, CategoryId=4, Name = "Product 13", Description = "Tie description goes here.", Price = 5.0, SalePrice = 4.0},
                    new Product {Id = 14, CategoryId=4, Name = "Product 14", Description = "Tie description goes here.", Price = 10.0, SalePrice = 9.0},
                    new Product {Id = 15, CategoryId=4, Name = "Product 15", Description = "Tie description goes here.", Price = 5.0, SalePrice = 4.0, },
                    new Product {Id = 16, CategoryId=4, Name = "Product 16", Description = "Tie description goes here.", Price = 5.0, SalePrice = 4.0, }
                };
                products.ForEach(p => _dbContext.Products.Add(p));
                
                var categories = new List<Category> {
                    new Category {Id = 1, Name = "Category 1", Description = "Tie description goes here."},
                    new Category {Id = 2, Name = "Category 2", Description = "Tie description goes here."},
                    new Category {Id = 3, Name = "Category 3", Description = "Tie description goes here." },
                    new Category {Id = 4, Name = "Category 4", Description = "Tie description goes here."}
                };
                categories.ForEach(c => _dbContext.Categories.Add(c));
               
                _dbContext.SaveChanges();
                return products;
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
            
            public Product GetAProduct()
            {
                Product product =  _dbContext.Products.FirstOrDefault();
                if (product != null) {
                    return product;
                } else {
                    return new Product {Id = 0, Name = "Bad Product", Description = "Why won't u read DB", Price = 5.0, SalePrice = 4.0};
                }
            }
            public Array GetOnSaleProducts()
            {
               return  _dbContext.Products.Where(p=> p.OnSale).ToArray();
            }
            
            public Array GetAllProducts()
            {
                Array products = _dbContext.Products.ToArray();
                foreach (Product p in products) {
                    Console.WriteLine(p.ToString());
                }
                return products;
            }
       
    }
}
