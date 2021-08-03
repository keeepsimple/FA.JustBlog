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

        public TagsController(ITagServices tagServices)
        {
            _tagServices = tagServices;
        }

        public ActionResult PopularTags()
        {
            var popularTags = Task.Run(() => _tagServices.GetPopularTagAsync(5)).Result;
            return PartialView("_PopularTags", popularTags);
        }
    }
}