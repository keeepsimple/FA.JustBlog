using FA.JustBlog.Data.Infrastructure;
using FA.JustBlog.Models.Common;
using FA.JustBlog.Services.BaseServices;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace FA.JustBlog.Services
{
    public class PostServices : BaseServices<Post>, IPostServices
    {
        public PostServices(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<int> CountPostsForCategoryAsync(string category)
        {
            return await _unitOfWork.PostRepository.GetQuery().CountAsync(x=>x.Category.Name.Equals(category));
        }

        public async Task<int> CountPostsForTagAsync(string tag)
        {
            return await _unitOfWork.PostRepository.GetQuery().CountAsync(x=>x.Tags.Any(t=>t.Name.Equals(tag)));
        }

        public async Task<IEnumerable<Post>> GetHighestPosts(int size)
        {
            return await _unitOfWork.PostRepository.GetQuery().OrderByDescending(x => x.Rate).Take(size).ToListAsync();
        }

        public async Task<IEnumerable<Post>> GetLatestPostAsync(int size)
        {
            return await _unitOfWork.PostRepository.GetQuery().OrderByDescending(x => x.PublishedDate).Take(size).ToListAsync();
        }

        public async Task<IEnumerable<Post>> GetMostViewedPost(int size)
        {
            return await _unitOfWork.PostRepository.GetQuery().OrderByDescending(x=>x.ViewCount).Take(size).ToListAsync();
        }

        public async Task<IEnumerable<Post>> GetPostsByCategoryAsync(string category)
        {
            return await _unitOfWork.PostRepository.GetQuery().Where(x=>x.Category.Name.Equals(category)).ToListAsync();
        }

        public async Task<IEnumerable<Post>> GetPostsByMonthAsync(DateTime monthYear)
        {
            return await _unitOfWork.PostRepository.GetQuery().Where(x=>x.PublishedDate.Month == monthYear.Month 
                                                                    && x.PublishedDate.Year == monthYear.Year).ToListAsync();
        }

        public async Task<IEnumerable<Post>> GetPostsByTagAsync(string tag)
        {
            return await _unitOfWork.PostRepository.GetQuery().Where(x => x.Tags.Any(t => t.Name.Equals(tag))).ToListAsync();
        }

        public async Task<IEnumerable<Post>> GetPublisedPostsAsync(bool published = true)
        {
            return await _unitOfWork.PostRepository.GetQuery().Where(x => x.Published == published).ToListAsync();
        }
    }
}
