using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreLayer.Entity;

namespace EntityLayer.Concrete
{
    public class Order : Entity
    {
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public int AdressId { get; set; }
        public int CartId { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsActived { get; set; }
        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
        public virtual Adress Adress { get; set; }
        public virtual Cart Cart { get; set; }

    }
}