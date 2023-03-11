using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusiniessLayer.Abstract;
using DataAccessLayer.Concrete.Context;
using Microsoft.AspNetCore.Mvc;

namespace ETicaret.UI.Components
{
    public class AdressListViewComponent : ViewComponent
    {
        EticaretContext c = new EticaretContext();
        private readonly IAdressService _adressService;
        public AdressListViewComponent(IAdressService adressService)
        {
            _adressService = adressService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var usermail = User.Identity.Name;
            var userId = c.Users.Where(x => x.FirstName == usermail).Select(y => y.Id).FirstOrDefault(); 
            var list = await _adressService.GetAdressList(userId);
            return View(list.Data);
        }
    }
}