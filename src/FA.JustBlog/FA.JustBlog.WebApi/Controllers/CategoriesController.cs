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
using FA.JustBlog.Data;
using FA.JustBlog.Models.Common;
using FA.JustBlog.Services;

namespace FA.JustBlog.WebApi.Controllers
{
    public class CategoriesController : ApiController
    {
        private readonly ICategoryServices _categoryServices;

        public CategoriesController(ICategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }

        // GET: api/Categories
        public async Task<IHttpActionResult> GetCategories()
        {
            var categories = await _categoryServices.GetAllAsync();
            return Ok();
        }

        // GET: api/Categories/5
        [ResponseType(typeof(Category))]
        public async Task<IHttpActionResult> GetCategory(Guid id)
        {
            Category category = await _categoryServices.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        // PUT: api/Categories/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCategory(Guid id, Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var exist = await _categoryServices.GetByIdAsync(id);

            if (exist == null)
            {
                return BadRequest();
            }
            exist.Name = category.Name;
            exist.UrlSlug = category.UrlSlug;
            exist.Description = category.Description;
            var result = await _categoryServices.UpdateAsync(category);

            if (!result)
            {
                return BadRequest();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Categories
        [ResponseType(typeof(Category))]
        public async Task<IHttpActionResult> PostCategory(Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _categoryServices.AddAsync(category);

            if (result <= 0)
            {
                return BadRequest(ModelState);
            }

            return Ok(category);
        }

        // DELETE: api/Categories/5
        [ResponseType(typeof(Category))]
        public async Task<IHttpActionResult> DeleteCategory(Guid id)
        {
            if (CategoryExists(id))
            {
                await _categoryServices.DeleteAsync(id);
            }
            else
            {
                return NotFound();
            }

            return Ok();
        }

        private bool CategoryExists(Guid id)
        {
            return _categoryServices.GetAll().Count(e => e.Id == id) > 0;
        }
    }
}