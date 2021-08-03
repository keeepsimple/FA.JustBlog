using FA.JustBlog.Models.Common;
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
    public class CategoryManagementController : Controller
    {
        private readonly ICategoryServices _categoryServices;

        public CategoryManagementController(ICategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }

        // GET: Admin/CategoryManagerment
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

            Expression<Func<Category, bool>> filter = null;
            if (string.IsNullOrEmpty(searchString))
            {
                filter = c => c.Name.Contains(searchString);
            }

            Func<IQueryable<Category>, IOrderedQueryable<Category>> orderBy = null;
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

            var categories = await _categoryServices.GetAsync(orderBy: orderBy, filter: filter, pageIndex: pageIndex ?? 1, pageSize: pageSize);

            return View(categories);
        }

        // GET: Admin/CategoryManagerment/Create
        public ActionResult Create()
        {
            var categoryViewModel = new CategoryViewModel();
            return View(categoryViewModel);
        }

        // POST: Admin/CategoryManagerment/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryViewModel categoryViewModel)
        {
            if (ModelState.IsValid)
            {
                var category = new Category
                {
                    Id = Guid.NewGuid(),
                    Name = categoryViewModel.Name,
                    UrlSlug = categoryViewModel.UrlSlug,
                    Description = categoryViewModel.Description
                };
                _categoryServices.Add(category);
                return RedirectToAction("Index");
            }

            return View(categoryViewModel);
        }

        // GET: Admin/CategoryManagerment/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = _categoryServices.GetById((Guid)id);
            if (category == null)
            {
                return HttpNotFound();
            }

            var categoryViewModel = new CategoryViewModel
            {
                Id = category.Id,
                Name = category.Name,
                UrlSlug = category.UrlSlug,
                Description = category.Description
            };
            return View(categoryViewModel);
        }

        // POST: Admin/CategoryManagerment/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public async Task<ActionResult> Edit(CategoryViewModel categoryViewModel)
        {
            if (ModelState.IsValid)
            {
                var category = await _categoryServices.GetByIdAsync(categoryViewModel.Id);
                if (category == null)
                {
                    return HttpNotFound();
                }

                category.Name = categoryViewModel.Name;
                category.UrlSlug = categoryViewModel.UrlSlug;
                category.Description = categoryViewModel.Description;

                _categoryServices.Update(category);
                return RedirectToAction("Index");
            }
            return View(categoryViewModel);
        }

        // POST: Admin/CategoryManagerment/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult Delete(Guid id)
        {
            Category category = _categoryServices.GetById(id);
            var result = _categoryServices.Delete(category.Id);
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
