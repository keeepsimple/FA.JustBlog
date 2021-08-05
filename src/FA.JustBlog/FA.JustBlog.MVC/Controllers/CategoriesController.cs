﻿using FA.JustBlog.Services;
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

        public async Task<ActionResult> Details(Guid id)
        {
            var category = await _categoryServices.GetByIdAsync(id);
            if(category == null)
            {
                return HttpNotFound();
            }
            var posts = await _postServices.GetPostsByCategoryAsync(category.Id);
            ViewBag.CategoryName = category.Name;
            return View(posts);
        }
    }
}