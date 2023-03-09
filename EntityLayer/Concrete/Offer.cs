using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreLayer.Entity;

namespace EntityLayer.Concrete
{
    public class Offer : Entity
    {
        public int UserId { get; set; }
        public int TakeUserId { get; set; }
        public int ProductId { get; set; }
        public int OfferPrice { get; set; }
        public bool IsActived { get; set; }
        public virtual User User { get; set; }
        public virtual Product Product { get; set; }
    }
}