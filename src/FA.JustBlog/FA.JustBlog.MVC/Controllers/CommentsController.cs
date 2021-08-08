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

        public ActionResult GetCommentByPost(Guid id)
        {
            var comments = Task.Run(() => _commentServices.GetCommentsForPostAsync(id)).Result;
            return PartialView("_Comment", comments);
        }
    }
}