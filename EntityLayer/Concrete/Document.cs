using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreLayer.Entity;

namespace EntityLayer.Concrete
{
    public class Document : Entity
    {
        public string DocumentUnique { get; set; }
        public string DocumentName { get; set; }
        public string DocumentType { get; set; }
        public string DocumentSize { get; set; }
        public string DocumentFolderName { get; set; }
        public string Storage_Url { get; set; }
        public string? Image_Url { get; set; } = " ";
        public string? Video_Url { get; set; } = " ";
        public DateTime CreateDate { get; set; }
    }
}