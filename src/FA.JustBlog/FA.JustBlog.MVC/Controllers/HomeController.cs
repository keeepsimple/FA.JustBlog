using FA.JustBlog.Models.Common;
using FA.JustBlog.MVC.ViewModels;
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
        private readonly ICategoryServices _categoryServices;

        public HomeController(IPostServices postServices, ICategoryServices categoryServices)
        {
            _postServices = postServices;
            _categoryServices = categoryServices;
        }

        public async Task<ActionResult> Index(int? pageIndex = 1, int pageSize = 3)
        {
            Expression<Func<Post, bool>> filter = null;

            Func<IQueryable<Post>, IOrderedQueryable<Post>> orderBy = o => o.Where(x=>x.Published==true).OrderByDescending(p => p.PublishedDate);
            var newestPosts = await _postServices.GetAsync(filter: filter, orderBy: orderBy,
                pageIndex: pageIndex ?? 1, pageSize: pageSize); 
            return View(newestPosts);
        }

        public ActionResult Menu()
        {
            var categories = _categoryServices.GetAll();
            var popularCategories = categories.OrderByDescending(p => p.Posts.Count()).Take(2);
            var remainCategories = categories.OrderByDescending(p => p.Posts.Count()).Skip(2);
            var categoryMenuViewModel = new CategoryMenuViewModel()
            {
                PopularCategories = popularCategories,
                RemainCategories = remainCategories
            };
            return PartialView("_Menu", categoryMenuViewModel);
        }

        public ActionResult PostSlider()
        {
            var posts = _postServices.GetMostViewedPost(4);
            return PartialView("_PostSlider", posts);
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