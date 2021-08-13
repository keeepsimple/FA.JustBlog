using FA.JustBlog.Services;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FA.JustBlog.MVC.Controllers
{
    public class CommentsController : Controller
    {
        private readonly ICommentServices _commentServices;

        public CommentsController(ICommentServices commentServices)
        {
            _commentServices = commentServices;
        }

        //[HttpPost]
        //public async Task<ActionResult> Create(Guid postId, string commentName, string commentEmail, string commentTitle, string commentBody)
        //{

        //}
    }
}