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
    public class PostsController : ApiController
    {
        private readonly IPostServices _postServices;

        public PostsController(IPostServices postServices)
        {
            _postServices = postServices;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            return Ok(await _postServices.GetAllAsync());
        }

        // GET: api/Categories/5
        [HttpGet]
        [ResponseType(typeof(Post))]
        public async Task<IHttpActionResult> GetById(Guid id)
        {
            Post post = await _postServices.GetByIdAsync(id);
            if (post == null)
            {
                return NotFound();
            }

            return Ok(post);
        }

        // PUT: api/Categories/5
        [HttpPut]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Update(Guid id, PostEditViewModel postEditViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var post = await _postServices.GetByIdAsync(id);

            if (post == null)
            {
                return BadRequest();
            }

            post.Title = postEditViewModel.Title;
            post.ShortDescription = postEditViewModel.ShortDescription;
            post.UrlSlug = postEditViewModel.UrlSlug;
            post.PostContent = postEditViewModel.PostContent;
            post.Published = postEditViewModel.Published;
            post.ImageUrl = postEditViewModel.ImageUrl;
            post.ImageSlider = postEditViewModel.ImageSlider;

            var result = await _postServices.UpdateAsync(post);

            if (!result)
            {
                return BadRequest();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Categories
        [HttpPost]
        [ResponseType(typeof(Post))]
        public async Task<IHttpActionResult> Create(PostEditViewModel postEditViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var post = new Post
            {
                Id = postEditViewModel.Id,
                Title = postEditViewModel.Title,
                ShortDescription = postEditViewModel.ShortDescription,
                UrlSlug = postEditViewModel.UrlSlug,
                PostContent = postEditViewModel.PostContent,
                Published = postEditViewModel.Published,
                ImageUrl = postEditViewModel.ImageUrl,
                ImageSlider = postEditViewModel.ImageSlider,
                CategoryId = postEditViewModel.CategoryId
            };

            var result = await _postServices.AddAsync(post);

            if (result <= 0)
            {
                return BadRequest(ModelState);
            }

            var postViewModel = new PostViewModel
            {
                Id = post.Id,
                Title = post.Title,
                UrlSlug = post.UrlSlug,
                PostContent = post.PostContent,
                ShortDescription = post.ShortDescription,
                Published = post.Published,
                ImageSlider = post.ImageSlider,
                ImageUrl = post.ImageUrl,
                ViewCount = post.ViewCount,
                RateCount = post.RateCount,
                TotalRate = post.TotalRate,
                IsDeleted = post.IsDeleted,
                InsertedAt = post.InsertedAt,
                UpdatedAt = post.UpdatedAt
            };

            return CreatedAtRoute("DefaultApi", new { id = post.Id }, postViewModel);
        }

        // DELETE: api/Categories/5
        [HttpDelete]
        [ResponseType(typeof(bool))]
        public async Task<IHttpActionResult> Delete(Guid id)
        {
            var post = await _postServices.GetByIdAsync(id);
            if (post == null)
            {
                return BadRequest();
            }

            var result = await _postServices.DeleteAsync(post);

            if (!result)
            {
                return BadRequest();
            }

            return Ok(true);
        }
    }
}