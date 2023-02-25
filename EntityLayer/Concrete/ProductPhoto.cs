using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreLayer.Entity;

namespace EntityLayer.Concrete
{
    public class ProductPhoto : Entity
    {
        public int ProductId { get; set; }
        public int? Index { get; set; }
        public string FileCode { get; set; }
        public bool IsActived { get; set; }
        public virtual Product Product { get; set; }

    }
}