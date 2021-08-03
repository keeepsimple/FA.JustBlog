﻿using FA.JustBlog.Models.Common;
using FA.JustBlog.MVC.Areas.Admin.ViewModels;
using FA.JustBlog.Services;
using System;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FA.JustBlog.MVC.Areas.Admin.Controllers
{
    public class TagManagementController : Controller
    {
        private readonly ITagServices _tagServices;

        public TagManagementController(ITagServices tagServices)
        {
            _tagServices = tagServices;
        }

        // GET: Admin/TagManagerment
        public async Task<ActionResult> Index(string sortOrder, string currentFilter, string searchString, int? pageIndex = 1, int pageSize = 3)
        {
            ViewData["CurrentPageSize"] = pageSize;
            ViewData["CurrentSortOrder"] = sortOrder;
            ViewData["NameSortParm"] = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["TotalPostsSortParm"] = sortOrder == "TotalPosts" ? "totalPosts_desc" : "TotalPosts";
            ViewData["InsertedAtSortParm"] = sortOrder == "InsertedAt" ? "insertedAt_desc" : "InsertedAt";
            ViewData["UpdatedAtSortParm"] = sortOrder == "UpdatedAt" ? "updatedAt_desc" : "UpdatedAt";

            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewData["CurrentFilter"] = searchString;

            Expression<Func<Tag, bool>> filter = null;
            if (string.IsNullOrEmpty(searchString))
            {
                filter = c => c.Name.Contains(searchString);
            }

            Func<IQueryable<Tag>, IOrderedQueryable<Tag>> orderBy = null;
            switch (sortOrder)
            {
                case "name_desc": orderBy = x => x.OrderByDescending(c => c.Name); break;
                case "InsertedAt": orderBy = x => x.OrderBy(c => c.Name); break;
                case "insertedAt_desc": orderBy = x => x.OrderByDescending(c => c.Name); break;
                case "TotalPosts": orderBy = q => q.OrderBy(c => c.Posts.Count); break;
                case "totalPosts_desc": orderBy = q => q.OrderByDescending(c => c.Posts.Count); break;
                case "UpdatedAt": orderBy = q => q.OrderBy(c => c.UpdatedAt); break;
                case "updatedAt_desc": orderBy = q => q.OrderByDescending(c => c.UpdatedAt); break;
                default: orderBy = x => x.OrderBy(c => c.Name); break;
            }

            var categories = await _tagServices.GetAsync(orderBy: orderBy, filter: filter, pageIndex: pageIndex ?? 1, pageSize: pageSize);

            return View(categories);
        }

        // GET: Admin/TagManagerment/Create
        public ActionResult Create()
        {
            var TagViewModel = new TagViewModel();
            return View(TagViewModel);
        }

        // POST: Admin/TagManagerment/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TagViewModel TagViewModel)
        {
            if (ModelState.IsValid)
            {
                var tag = new Tag
                {
                    Id = Guid.NewGuid(),
                    Name = TagViewModel.Name,
                    UrlSlug = TagViewModel.UrlSlug,
                    Description = TagViewModel.Description
                };
                _tagServices.Add(tag);
                return RedirectToAction("Index");
            }

            return View(TagViewModel);
        }

        // GET: Admin/TagManagerment/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tag Tag = _tagServices.GetById((Guid)id);
            if (Tag == null)
            {
                return HttpNotFound();
            }

            var TagViewModel = new TagViewModel
            {
                Id = Tag.Id,
                Name = Tag.Name,
                UrlSlug = Tag.UrlSlug,
                Description = Tag.Description
            };
            return View(TagViewModel);
        }

        // POST: Admin/TagManagerment/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public async Task<ActionResult> Edit(TagViewModel TagViewModel)
        {
            if (ModelState.IsValid)
            {
                var Tag = await _tagServices.GetByIdAsync(TagViewModel.Id);
                if (Tag == null)
                {
                    return HttpNotFound();
                }

                Tag.Name = TagViewModel.Name;
                Tag.UrlSlug = TagViewModel.UrlSlug;
                Tag.Description = TagViewModel.Description;

                _tagServices.Update(Tag);
                return RedirectToAction("Index");
            }
            return View(TagViewModel);
        }

        // POST: Admin/TagManagerment/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult Delete(Guid id)
        {
            Tag Tag = _tagServices.GetById(id);
            var result = _tagServices.Delete(Tag.Id);
            if (result)
            {
                TempData["Message"] = "Delete Successful";
            }
            else
            {
                TempData["Message"] = "Delete Failed";
            }
            return RedirectToAction("Index");
        }
    }
}