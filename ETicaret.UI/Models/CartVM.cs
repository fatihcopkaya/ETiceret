using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace ETicaret.UI.Models
{
    public class CartVM
    {
        public Cart Cart { get; set; }
        public List<Product> Products { get; set; }
        public List<Cart> Carts { get; set; }
    }
}