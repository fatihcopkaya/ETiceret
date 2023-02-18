using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreLayer.Entity;

namespace EntityLayer.Concrete
{
    public class SubCategory : Entity
    {
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int MyProperty { get; set; }
        
    }
}