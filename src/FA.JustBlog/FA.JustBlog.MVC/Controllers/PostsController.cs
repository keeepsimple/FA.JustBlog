using FA.JustBlog.Models.Common;
using FA.JustBlog.Services;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Services.Description;

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
        //public async Task<ActionResult> Index(int? pageIndex = 1, int pageSize = 3)
        //{
        //    Expression<Func<Post, bool>> filter = null;

        //    Func<IQueryable<Post>, IOrderedQueryable<Post>> orderBy = o => o.Where(x => x.Published == true).OrderBy(p => p.PublishedDate);
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
            ViewBag.PublishedDate = ConvertTimePublished(post.PublishedDate);
            return View(post);
        }

        //public async Task<ActionResult> Details(int year, int month, string title)
        //{
        //    var post = await _postServices.FindPostAsync(year,month,title);
        //    if (post == null)
        //    {
        //        return HttpNotFound();
        //    }    
        //    return View(post);
        //}

        public ActionResult LastestPosts()
        {
            var lastestPosts = Task.Run(() => _postServices.GetLatestPostAsync(5)).Result;
            return PartialView("_LastestPosts", lastestPosts);
        }

        public ActionResult MostViewedPosts()
        {
            var mostViewedPosts = Task.Run(() => _postServices.GetMostViewedPostAsync(5)).Result;
            return PartialView("_PopularPosts", mostViewedPosts);
        }


        //public ActionResult HighestPosts()
        //{
        //    var lastestPosts = Task.Run(() => _postServices.GetHighestPosts(5)).Result;
        //    ViewBag.PartialViewTitle = "Highest Posts";
        //    return PartialView("_ListPost", lastestPosts);
        //}

        //convert published time to text
        public string ConvertTimePublished(DateTime publishedDate)
        {
            const int second = 1;
            const int minute = 60 * second;
            const int hour = 60 * minute;
            const int day = 24 * hour;
            const int month = 30 * day;

            var time = new TimeSpan(DateTime.Now.Ticks - publishedDate.Ticks);
            double interval = Math.Abs(time.TotalSeconds);

            if (interval < 1 * minute)
            {
                return time.Seconds == 1 ? "one second ago" : time.Seconds + " seconds ago";
            }

            if (interval < 59 * minute)
            {
                return time.Minutes == 1 ? "one minute ago" : time.Minutes + " minutes ago";
            }

            if (interval < 24 * hour)
            {
                return time.Hours == 1 ? "an hour ago" : time.Hours + " hours ago";
            }

            if (interval < 30 * day)
            {
                return time.Days == 1 ? "one day ago" : time.Days + " days ago";
            }

            if (interval < 12 * month)
            {
                int months = Convert.ToInt32(Math.Floor((double)time.Days / 30));
                return months == 1 ? "one month ago" : months + " months ago";
            }
            else
            {
                int years = Convert.ToInt32(Math.Floor((double)time.Days / 365));
                return years == 1 ? "one year ago" : years + " years ago";
            }
        }
    }
}