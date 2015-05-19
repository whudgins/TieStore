// using System.ComponentModel.DataAnnotations;
// 
// namespace TieStore.Web.Models
// {
//     public class ProductViewModel
//     {
//         
//         [Required]
//         public int Id { get; set; }
//         [Required]
//         public int CategoryId { get; set; }
//         [Required]
//         [MinLength(4)]
//         public string Name { get; set; }
//         public string Description { get; set; }
//         public double Price { get; set; }
// 		public double SalePrice { get; set; }
//         public bool OnSale { get { return !(Price == SalePrice);} }
// 		public string CategoryName { get; set; }
// 		public string CategoryDescription { get; set; }
// 		
// 		public ProductViewModel(Product p, Category c) {
// 			Id = p.Id;
// 			CategoryId = c.Id;
// 			Name = p.Name;
// 			Description = p.Description;
// 			Price = p.Price;
// 			SalePrice = p.SalePrice;
// 			CategoryName = c.Name;
// 			CategoryDescription = c.Description;
// 		}
//        
//         public override string ToString() {
//             return "Product:" + Id + ", " + Name + ", " + Description + ", Price $" + Price.ToString() + ", Sale Price $" + SalePrice.ToString() + ", On Sale? " + OnSale.ToString();
//         }
//     }
// }