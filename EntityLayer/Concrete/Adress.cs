using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreLayer.Entity;

namespace EntityLayer.Concrete
{
    public class Adress : Entity
    {
        public int UserId { get; set; }
        public string City { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Zip { get; set; }
        public bool IsActived { get; set; }
        public string AdressDetail { get; set; }
        public virtual User User { get; set; }
         public virtual Order Order { get; set; }

    }
}