using FA.JustBlog.MVC.ViewModels;
using FA.JustBlog.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FA.JustBlog.MVC.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryServices _categoryServices;
        private readonly IPostServices _postServices;

        public CategoriesController(ICategoryServices categoryServices, IPostServices postServices)
        {
            _categoryServices = categoryServices;
            _postServices = postServices;
        }

        public async Task<ActionResult> Details(string urlSlug)
        {
            var category = await _categoryServices.GetCategoryByUrlSlugAsync(urlSlug);
            if(category == null)
            {
                return HttpNotFound();
            }
            var posts = await _postServices.GetPostsByCategoryAsync(category.Id);
            ViewBag.Name = category.Name;
            return View("_ListPosts",posts);
        }

        public ActionResult CategoryRightMenu()
        {
            var categories = _categoryServices.GetAll().Select(x => new CategoryRightMenuViewModel
            {
                Id = x.Id,
                Name = x.Name,
                PostsCount = x.Posts.Count,
                UrlSlug = x.UrlSlug
            }) ;
            return PartialView("_CategoryRightMenu", categories);
        }
    }
}