using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using CoreLayer.Entity;

namespace EntityLayer.Concrete
{
    public class Comment : Entity
    {
        
        public virtual int ProductId { get; set; }
        public int UserId { get; set; }
        public string CommentUsername { get; set; }
        public string Content { get; set; }
        public bool IsActived { get; set; }
        public DateTime CreatedTime { get; set; }
        public virtual User User { get; set; }
        public virtual Product Product { get; set; }
        

    }
}