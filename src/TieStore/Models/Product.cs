using System.ComponentModel.DataAnnotations;
using Microsoft.Data.Entity;
using System;
using System.Linq;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TieStore.Web.Models
{
    public class ApplicationUser : IdentityUser {}
    

    public class Product
    {
        
        [Required]
        public int Id { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        [MinLength(4)]
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
		public double SalePrice { get; set; }
        public bool OnSale { get { return !(Price == SalePrice);} }
       
        public override string ToString() {
            return "Product:" + Id + ", " + Name + ", " + Description + ", Price $" + Price.ToString() + ", Sale Price $" + SalePrice.ToString() + ", On Sale? " + OnSale.ToString();
        }
    }
    
    public class Category
    {
        
        [Required]
        public int Id { get; set; }
        [Required]
        [MinLength(4)]
        public string Name { get; set; }
        public string Description { get; set; }
       
        public Array Products { 
            get {
                ProductDbContext db = new ProductDbContext();
                return db.Products.Select(p => p.Id == Id).ToArray();  
            }
        }
       
        public override string ToString() {
            return "Category:" + Id + ", " + Name + ", " + Description;
        }
    }

    public class ProductDbContext : IdentityDbContext<ApplicationUser>
    {
		public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
	}
    
    
}