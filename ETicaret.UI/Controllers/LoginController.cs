using BusiniessLayer.Abstract;
using DataAccessLayer.Concrete.Context;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;


namespace ETicaret.UI.Controllers
{
   
    public class LoginController : Controller
    {
       private readonly IUserService _userService;
       EticaretContext c = new EticaretContext();

        public LoginController(IUserService userService)
        {
            _userService = userService;
        }
          public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(User user, string returnUrl)
        {

            var users = await _userService.SignInAsync(user);
            if (!users.Success)
            {
                TempData["Error"] = users.Message;
                return View(user);
            }
            if(users.Data.Role == "Admin")
            {
                return RedirectToAction("Category","Cms");
            }
            TempData["Success"] = users.Message;
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");

        }
        public async Task<IActionResult> Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {

            await _userService.Register(user);


            return RedirectToAction(nameof(LoginController.Login));
        }
       
    }
}