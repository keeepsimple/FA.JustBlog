using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Services.Description;
using System.Xml.Linq;
using FA.JustBlog.Data;
using FA.JustBlog.Models.Common;
using FA.JustBlog.MVC.Areas.Admin.ViewModels;
using FA.JustBlog.Services;

namespace FA.JustBlog.MVC.Areas.Admin.Controllers
{
    public class CommentManagementController : Controller
    {
        private readonly ICommentServices _commentServices;
        private readonly IPostServices _postServices;

        public CommentManagementController(ICommentServices commentServices, IPostServices postServices)
        {
            _commentServices = commentServices;
            _postServices = postServices;
        }

        // GET: Admin/CommentManagement
        public async Task<ActionResult> Index(string sortOrder, string currentFilter, string searchString,
            int? pageIndex = 1, int pageSize = 2)
        {
            ViewData["CurrentPageSize"] = pageSize;
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["EmailSortParm"] = sortOrder == "Email" ? "email_desc" : "Email";
            ViewData["CommentHeaderSortParm"] = sortOrder == "CommentHeader" ? "commentHeader_desc" : "CommentHeader";
            ViewData["CommentTimeSortParm"] = sortOrder == "CommentTime" ? "commentTime_desc" : "CommentTime";
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

            Expression<Func<Comment, bool>> filter = null;

            if (!string.IsNullOrEmpty(searchString))
            {
                filter = c => c.Name.Contains(searchString);
            }

            Func<IQueryable<Comment>, IOrderedQueryable<Comment>> orderBy = null;

            switch (sortOrder)
            {
                case "name_desc":
                    orderBy = q => q.OrderByDescending(c => c.Name);
                    break;
                case "Email":
                    orderBy = q => q.OrderBy(c => c.Email);
                    break;
                case "email_desc":
                    orderBy = q => q.OrderByDescending(c => c.Email);
                    break;
                case "CommentTime":
                    orderBy = q => q.OrderBy(c => c.CommentTime);
                    break;
                case "commentTime_desc":
                    orderBy = q => q.OrderByDescending(c => c.CommentTime);
                    break;
                case "CommentHeader":
                    orderBy = q => q.OrderBy(c => c.CommentHeader);
                    break;
                case "commentHeader_desc":
                    orderBy = q => q.OrderByDescending(c => c.CommentHeader);
                    break;
                case "UpdatedAt":
                    orderBy = q => q.OrderBy(c => c.UpdatedAt);
                    break;
                case "updatedAt_desc":
                    orderBy = q => q.OrderByDescending(c => c.UpdatedAt);
                    break;
                default:
                    orderBy = q => q.OrderBy(c => c.Name);
                    break;
            }

            var comments = await _commentServices.GetAsync(filter: filter, orderBy: orderBy, pageIndex: pageIndex ?? 1, pageSize: pageSize);

            return View(comments);
        }

        // GET: Admin/CommentManagement/Create
        public ActionResult Create()
        {
            ViewBag.PostId = new SelectList(_postServices.GetAll(), "Id", "Title");
            var comment = new CommentViewModel();
            return View(comment);
        }

        // POST: Admin/CommentManagement/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public async Task<ActionResult> Create(CommentViewModel commentViewModel)
        {
            if (ModelState.IsValid)
            {
                var comment = new Comment
                {
                    Id = Guid.NewGuid(),
                    Name = commentViewModel.Name,
                    Email = commentViewModel.Email,
                    CommentHeader = commentViewModel.CommentHeader,
                    CommentText = commentViewModel.CommentText,
                    PostId = commentViewModel.PostId,
                };
                var result = await _commentServices.AddAsync(comment);
                if (result>0)
                {
                    TempData["Message"] = "Create successful!";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Message"] = "Create failed!";

                }
            }

            ViewBag.PostId = new SelectList(_postServices.GetAll(), "Id", "Title", commentViewModel.PostId);
            return View(commentViewModel);
        }

        // GET: Admin/CommentManagement/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            var comment = await _commentServices.GetByIdAsync((Guid)id);
            var commentViewModel = new CommentViewModel
            {
                Id = comment.Id,
                Name = comment.Name,
                Email = comment.Email,
                CommentHeader = comment.CommentHeader,
                CommentText = comment.CommentText,
                PostId = comment.PostId
            };
            ViewBag.PostId = new SelectList(_postServices.GetAll(), "Id", "Title", commentViewModel.PostId);
            return View(commentViewModel);
        }

        // POST: Admin/CommentManagement/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public async Task<ActionResult> Edit(CommentViewModel commentViewModel)
        {
            if (ModelState.IsValid)
            {
                var comment = await _commentServices.GetByIdAsync(commentViewModel.Id);
                if (comment == null)
                {
                    return HttpNotFound();
                }
                comment.Name = commentViewModel.Name;
                comment.Email = commentViewModel.Email;
                comment.CommentHeader = commentViewModel.CommentHeader;
                comment.CommentText = commentViewModel.CommentText;
                comment.PostId = commentViewModel.PostId;
                var result = await _commentServices.UpdateAsync(comment);
                if (result)
                {
                    TempData["Message"] = "Update successful!";
                }
                else
                {
                    TempData["Message"] = "Update failed!";

                }
                return RedirectToAction("Index");
            }
            ViewBag.PostId = new SelectList(_postServices.GetAll(), "Id", "Title", commentViewModel.PostId);
            return View(commentViewModel);
        }

        // POST: Admin/CommentManagement/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var result = await _commentServices.DeleteAsync(id);
            if (result)
            {
                TempData["Message"] = "Delete successful";
            }
            else
            {
                TempData["Message"] = "Delete successful";
            }
            return RedirectToAction("Index");
        }
    }
}
