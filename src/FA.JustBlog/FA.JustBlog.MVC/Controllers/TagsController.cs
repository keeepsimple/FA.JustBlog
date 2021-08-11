using FA.JustBlog.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FA.JustBlog.MVC.Controllers
{
    public class TagsController : Controller
    {
        private readonly ITagServices _tagServices;
        private readonly IPostServices _postServices;

        public TagsController(ITagServices tagServices, IPostServices postServices)
        {
            _tagServices = tagServices;
            _postServices = postServices;
        }

        public async Task<ActionResult> Details(string urlSlug)
        {
            var tag = await _tagServices.GetTagByUrlSlugAsync(urlSlug);
            if(tag == null)
            {
                return HttpNotFound();
            }
            var posts = await _postServices.GetPostsByTagAsync(tag.Id);
            ViewBag.Name = tag.Name;
            return View("_ListPosts",posts);
        }

        public ActionResult PopularTags()
        {
            var popularTags = Task.Run(() => _tagServices.GetPopularTagAsync(5)).Result;
            return PartialView("_PopularTags", popularTags);
        }
    }
}