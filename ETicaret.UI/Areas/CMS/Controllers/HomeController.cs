using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ETicaret.UI.Areas.Cms.Controllers
{
    
    public class HomeController : Controller
    {
       [Area("Cms")]
        public IActionResult Index()
        {
            return View();
        }

        
    }
}