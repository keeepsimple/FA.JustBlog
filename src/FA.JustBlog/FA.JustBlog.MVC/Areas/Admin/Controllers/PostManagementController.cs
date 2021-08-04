using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FA.JustBlog.MVC.Areas.Admin.Controllers
{
    public class PostManagementController : Controller
    {
        // GET: Admin/PostManagement
        public ActionResult Index()
        {
            return View();
        }
    }
}