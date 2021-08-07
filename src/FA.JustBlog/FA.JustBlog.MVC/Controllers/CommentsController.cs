using FA.JustBlog.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FA.JustBlog.MVC.Controllers
{
    public class CommentsController : Controller
    {
        private readonly ICommentServices _commentServices;
        private readonly IPostServices _postServices;

        public CommentsController(ICommentServices commentServices, IPostServices postServices)
        {
            _commentServices = commentServices;
            _postServices = postServices;
        }

        public ActionResult Index()
        {
            var cmts = _commentServices.GetAll();
            return View(cmts);
        }
    }
}