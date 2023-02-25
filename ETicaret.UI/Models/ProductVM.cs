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
        public List<Category> Categories {get; set;}
        public User User { get; set; }
        public Category Category { get; set; }
        
       
       
    }
}