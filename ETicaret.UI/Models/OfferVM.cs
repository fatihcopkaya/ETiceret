using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace ETicaret.UI.Models
{
    public class OfferVM
    {
        public List<Product> Products { get; set; }
        public List<Offer> Offers { get; set; }
        public Product Product { get; set; }
        public Offer Offer { get; set; }
        
        
    }
}