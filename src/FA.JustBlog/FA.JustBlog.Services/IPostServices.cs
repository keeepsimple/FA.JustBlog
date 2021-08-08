using FA.JustBlog.Models.Common;
using FA.JustBlog.Services.BaseServices;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;

namespace FA.JustBlog.Services
{
    public interface IPostServices : IBaseService<Post>
    {
        Task<IEnumerable<Post>> GetPublisedPostsAsync(bool published = true);

        Task<IEnumerable<Post>> GetLatestPostAsync(int size, bool published = true);

        IEnumerable<Post> GetLatestPost(int size, bool published = true);

        Task<IEnumerable<Post>> GetPostsByMonthAsync(DateTime monthYear);

        Task<IEnumerable<Post>> FindPostAsync(int year, int month, string title);

        Task<int> CountPostsForCategoryAsync(string category);

        Task<IEnumerable<Post>> GetPostsByCategoryAsync(string category);

        Task<IEnumerable<Post>> GetPostsByCategoryAsync(Guid categoryId);

        Task<int> CountPostsForTagAsync(string tag);

        Task<IEnumerable<Post>> GetPostsByTagAsync(string tag);

        Task<IEnumerable<Post>> GetPostsByTagAsync(Guid tagId);

        Task<IEnumerable<Post>> GetMostViewedPostAsync(int size);

        IEnumerable<Post> GetMostViewedPost(int size);

        Task<IEnumerable<Post>> GetHighestPosts(int size);

    }
}
