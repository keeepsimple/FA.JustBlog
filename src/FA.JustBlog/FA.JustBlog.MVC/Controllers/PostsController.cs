using FA.JustBlog.Models.Common;
using FA.JustBlog.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;
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
        public async Task<ActionResult> Index(int? pageIndex = 1, int? pageSize = 2)
        {
            Expression<Func<Post, bool>> filter = null;

            Func<IQueryable<Post>, IOrderedQueryable<Post>> orderBy = o => o.OrderBy(p => p.Title);
            var posts = await _postServices.GetAsync(filter: filter, orderBy: orderBy,
                pageIndex: pageIndex ?? 1, pageSize: pageSize ?? 2);
            return View(posts);
        }

        [HttpGet]
        public async Task<ActionResult> Details(Guid id)
        {
            var post = await _postServices.GetByIdAsync(id);
            return View(post);
        }

        public ActionResult LastestPosts()
        {
            var lastestPosts = Task.Run(() => _postServices.GetLatestPostAsync(5)).Result;
            return PartialView("_ListPosts", lastestPosts);
        }

        public async Task<ActionResult> MostViewedPosts()
        {
            var mostViewedPosts = await _postServices.GetMostViewedPost(5);
            return PartialView("_ListPosts", mostViewedPosts);
        }
    }
}