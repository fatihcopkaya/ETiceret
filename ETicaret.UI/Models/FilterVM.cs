using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace ETicaret.UI.Models
{
    public class FilterVM
    {
        public List<Category> Categories { get; set; }
        public Category Category { get; set; }
    }
}