using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreLayer.Entity;

namespace EntityLayer.Concrete
{
    public class Category : Entity
    {

        public int? ParentId { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public int OrderBy { get; set; }
        public string SlugUrl { get; set; }
        public bool IsActived { get; set; }
        public virtual Category Parent { get; set; }
        public virtual ICollection<Category> Children { get; set; }
        public virtual ICollection<Product> Products { get; set; }

    }
}