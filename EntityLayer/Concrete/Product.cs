using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreLayer.Entity;

namespace EntityLayer.Concrete
{
    public class Product : Entity
    {
        public int CategoryId { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        // public int Price { get; set; }
        public bool IsActived { get; set; }
        public string FileCode { get; set; }
        public int OrderBy { get; set; }
        public string SlugUrl { get; set; }
        public virtual Category Category { get; set; }
        public virtual User User { get; set; }
        // public DateTime CreatedTime { get; set; }
        
        public virtual ICollection<ProductPhoto> ProductPhotos { get; set; }
    }
}