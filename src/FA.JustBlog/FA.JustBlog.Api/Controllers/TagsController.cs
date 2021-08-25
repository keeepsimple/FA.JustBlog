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
    public class TagsController : ApiController
    {
        private readonly ITagServices _tagServices;

        public TagsController(ITagServices tagServices)
        {
            _tagServices = tagServices;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            return Ok(await _tagServices.GetAllAsync());
        }

        // GET: api/Categories/5
        [HttpGet]
        [ResponseType(typeof(Tag))]
        public async Task<IHttpActionResult> GetById(Guid id)
        {
            Tag tag = await _tagServices.GetByIdAsync(id);
            if (tag == null)
            {
                return NotFound();
            }

            return Ok(tag);
        }

        // PUT: api/Categories/5
        [HttpPut]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Update(Guid id,TagEditViewModel tagEditViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var tag = await _tagServices.GetByIdAsync(id);

            if (tag == null)
            {
                return BadRequest();
            }

            tag.Name = tagEditViewModel.Name;
            tag.Description = tagEditViewModel.Description;
            tag.UrlSlug = tagEditViewModel.UrlSlug;

            var result = await _tagServices.UpdateAsync(tag);

            if (!result)
            {
                return BadRequest();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Categories
        [HttpPost]
        [ResponseType(typeof(Tag))]
        public async Task<IHttpActionResult> Create(TagEditViewModel tagEditViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tag = new Tag
            {
                Id = tagEditViewModel.Id,
                Name = tagEditViewModel.Name,
                UrlSlug = tagEditViewModel.UrlSlug,
                Description = tagEditViewModel.Description
            };
            
            var result = await _tagServices.AddAsync(tag);

            if (result <= 0)
            {
                return BadRequest(ModelState);
            }

            var tagViewModel = new TagViewModel
            {
                Id = tag.Id,
                Name = tag.Name,
                UrlSlug = tag.UrlSlug,
                Description = tag.Description,
                IsDeleted = tag.IsDeleted,
                InsertedAt = tag.InsertedAt,
                UpdatedAt = tag.UpdatedAt
            };

            return CreatedAtRoute("DefaultApi", new { id = tag.Id }, tagViewModel);
        }

        // DELETE: api/Categories/5
        [HttpDelete]
        [ResponseType(typeof(bool))]
        public async Task<IHttpActionResult> Delete(Guid id)
        {
            var tag = await _tagServices.GetByIdAsync(id);
            if(tag == null)
            {
                return BadRequest();
            }

            var result = await _tagServices.DeleteAsync(tag);

            if(!result)
            {
                return BadRequest();
            }

            return Ok(true);
        }
    }
}