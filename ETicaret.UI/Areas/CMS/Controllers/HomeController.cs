using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ETicaret.UI.CMS.Controllers
{
    [Area("CMS")]
    public class HomeController : Controller
    {

        [Route("/cms/")]
        public IActionResult Index()
        {
            return View();
        }


    }
}