using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusiniessLayer.Abstract;
using ETicaret.UI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ETicaret.UI.Components
{
    public class ImageViewComponent : ViewComponent
    {
         private readonly IDocumentService _documentService;

        public ImageViewComponent(IDocumentService documentService)
        {
            _documentService = documentService;
        }
        public async Task<IViewComponentResult> InvokeAsync(string FileCode)
        {
            var row = await _documentService.GetDocumentByIdAsync(FileCode);
            if(row.Success)
            {
                var file = row.Data;
                return View(new ImageVM()
                {
                    Image = string.Concat(file.Image_Url, file.DocumentFolderName, file.DocumentName)
                });
            }
            return View(new ImageVM());
        } 
    }
}