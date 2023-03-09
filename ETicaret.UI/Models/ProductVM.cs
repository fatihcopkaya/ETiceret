using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace ETicaret.UI.Models
{
    public class ProductVM
    {
        public Product Product { get; set; }
        public List<Product> Products { get; set; }
        public List<Category> Categories {get; set;}
        public User User { get; set; }
        public Category Category { get; set; }
        public ProductPhoto ProductPhoto { get; set; }
        public Comment Comment { get; set; }
        public List<Cart> Carts { get; set; }
        public Cart Cart { get; set; }
        public List<Offer> Offers { get; set; }
        public Offer Offer { get; set; }
        
       
       
    }
}