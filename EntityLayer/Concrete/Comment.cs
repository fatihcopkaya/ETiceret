using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreLayer.Entity;

namespace EntityLayer.Concrete
{
    public class Comment : Entity
    {
        public int UserId { get; set; }
        public string Content { get; set; }
        public bool IsActived { get; set; }
        public User User { get; set; }
        

    }
}