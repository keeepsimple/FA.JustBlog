using FA.JustBlog.Models.Common;
using FA.JustBlog.Services;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FA.JustBlog.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostServices _postServices;

        public HomeController(IPostServices postServices)
        {
            _postServices = postServices;
        }

        public async Task<ActionResult> Index(int? pageIndex = 1, int pageSize = 4)
        {
            Expression<Func<Post, bool>> filter = null;

            Func<IQueryable<Post>, IOrderedQueryable<Post>> orderBy = o => o.OrderByDescending(p => p.PublishedDate);
            var newestPosts = await _postServices.GetAsync(filter: filter, orderBy: orderBy,
                pageIndex: pageIndex ?? 1, pageSize: pageSize); 
            return View(newestPosts);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [ChildActionOnly]
        public ActionResult AboutCard()
        {
            return PartialView("_AboutMe");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}