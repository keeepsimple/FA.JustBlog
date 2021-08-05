using FA.JustBlog.Models.Common;
using FA.JustBlog.Services;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FA.JustBlog.MVC.Controllers
{
    public class PostsController : Controller
    {
        private readonly IPostServices _postServices;

        public PostsController(IPostServices postServices)
        {
            _postServices = postServices;
        }

        // GET: Posts
        //public async Task<ActionResult> Index(int? pageIndex = 1, int pageSize = 4)
        //{
        //    Expression<Func<Post, bool>> filter = null;

        //    Func<IQueryable<Post>, IOrderedQueryable<Post>> orderBy = o => o.OrderBy(p => p.PublishedDate);
        //    var posts = await _postServices.GetAsync(filter: filter, orderBy: orderBy,
        //        pageIndex: pageIndex ?? 1, pageSize: pageSize);
        //    return View(posts);
        //}

        public async Task<ActionResult> Index()
        {
            var allPost = await _postServices.GetAllAsync();
            return View(allPost);
        }

        public async Task<ActionResult> Details(Guid id)
        {
            var post = await _postServices.GetByIdAsync(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            ViewBag.PostTitle = post.Title;
            return View(post);
        }

        public ActionResult LastestPosts()
        {
            var lastestPosts = Task.Run(() => _postServices.GetLatestPostAsync(5)).Result;
            ViewBag.PartialViewTitle = "Lastest Posts";
            return PartialView("_ListPosts", lastestPosts);
        }

        public ActionResult MostViewedPosts()
        {
            var mostViewedPosts = Task.Run(() => _postServices.GetMostViewedPostAsync(5)).Result;
            ViewBag.PartialViewTitle = "Most View Posts";
            return PartialView("_ListPosts", mostViewedPosts);
        }

        //public ActionResult HighestPosts()
        //{
        //    var lastestPosts = Task.Run(() => _postServices.GetHighestPosts(5)).Result;
        //    ViewBag.PartialViewTitle = "Highest Posts";
        //    return PartialView("_ListPost", lastestPosts);
        //}
    }
}