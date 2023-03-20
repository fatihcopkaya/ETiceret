using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusiniessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace ETicaret.UI.Components
{
    public class CommentListViewComponent : ViewComponent
    {
        private readonly ICommentService _commentService;
         private readonly IUserService _userService;

        public CommentListViewComponent(ICommentService commentService, IUserService userService)
        {
            _commentService = commentService;
            _userService = userService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
           
            var list = await _commentService.GetCommentListByPorduct(id);
            return View(list.Data);
        }
    }
}