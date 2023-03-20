using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreLayer.Entity;

namespace EntityLayer.Concrete
{
    public class Cart : Entity
    {
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public int Quantity { get; set; }
        public bool IsActived { get; set; }
        public int Total { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
         public virtual Order Order { get; set; }

    }
}