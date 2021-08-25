using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using FA.JustBlog.Api.ViewModels;
using FA.JustBlog.Data;
using FA.JustBlog.Models.Common;
using FA.JustBlog.Services;

namespace FA.JustBlog.Api.Controllers
{
    public class CategoriesController : ApiController
    {
        private readonly ICategoryServices _categoryServices;

        public CategoriesController(ICategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            return Ok(await _categoryServices.GetAllAsync());
        }

        // GET: api/Categories/5
        [HttpGet]
        [ResponseType(typeof(Category))]
        public async Task<IHttpActionResult> GetById(Guid id)
        {
            Category category = await _categoryServices.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        // PUT: api/Categories/5
        [HttpPut]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Update(Guid id,CategoryEditViewModel categoryEditViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var category = await _categoryServices.GetByIdAsync(id);

            if (category == null)
            {
                return BadRequest();
            }

            category.Name = categoryEditViewModel.Name;
            category.Description = categoryEditViewModel.Description;
            category.UrlSlug = categoryEditViewModel.UrlSlug;

            var result = await _categoryServices.UpdateAsync(category);

            if (!result)
            {
                return BadRequest();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Categories
        [HttpPost]
        [ResponseType(typeof(Category))]
        public async Task<IHttpActionResult> Create(CategoryEditViewModel categoryEditViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var category = new Category
            {
                Id = categoryEditViewModel.Id,
                Name = categoryEditViewModel.Name,
                UrlSlug = categoryEditViewModel.UrlSlug,
                Description = categoryEditViewModel.Description
            };

            var result = await _categoryServices.AddAsync(category);

            if (result <= 0)
            {
                return BadRequest(ModelState);
            }

            var categoryViewModel = new CategoryViewModel
            {
                Id = category.Id,
                Name = category.Name,
                UrlSlug = category.UrlSlug,
                Description = category.Description,
                IsDeleted = category.IsDeleted,
                InsertedAt = category.InsertedAt,
                UpdatedAt = category.UpdatedAt
            };

            return CreatedAtRoute("DefaultApi", new { id = category.Id }, categoryViewModel);
        }

        // DELETE: api/Categories/5
        [HttpDelete]
        [ResponseType(typeof(bool))]
        public async Task<IHttpActionResult> Delete(Guid id)
        {
            var category = await _categoryServices.GetByIdAsync(id);
            if(category == null)
            {
                return BadRequest();
            }

            var result = await _categoryServices.DeleteAsync(category);
            if(!result)
            {
                return BadRequest();
            }
            return Ok(true);
        }
    }
}