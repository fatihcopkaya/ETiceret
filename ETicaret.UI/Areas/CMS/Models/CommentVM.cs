using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace ETicaret.UI.Areas.Cms.Models
{
    public class CommentVM
    {
        public List<Comment> Comments { get; set; }
        public List<Product> Products { get; set; }
    }
}