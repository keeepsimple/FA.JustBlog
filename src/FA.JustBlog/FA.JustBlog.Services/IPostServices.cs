using FA.JustBlog.Models.Common;
using FA.JustBlog.Services.BaseServices;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;

namespace FA.JustBlog.Services
{
    public interface IPostServices : IBaseService<Post>
    {
        /// <summary>
        /// Get async published post or unpublished post
        /// </summary>
        /// <param name="published"></param>
        /// <returns></returns>
        Task<IEnumerable<Post>> GetPublisedPostsAsync(bool published = true);

        /// <summary>
        /// Get async lastest post 
        /// </summary>
        /// <param name="size"></param>
        /// <param name="published"></param>
        /// <returns></returns>
        Task<IEnumerable<Post>> GetLatestPostAsync(int size, bool published = true);

        /// <summary>
        /// Get lastest post
        /// </summary>
        /// <param name="size"></param>
        /// <param name="published"></param>
        /// <returns></returns>
        IEnumerable<Post> GetLatestPost(int size, bool published = true);

        /// <summary>
        /// Get async post by month
        /// </summary>
        /// <param name="monthYear"></param>
        /// <returns></returns>
        Task<IEnumerable<Post>> GetPostsByMonthAsync(DateTime monthYear);

        /// <summary>
        /// Find async post
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        Task<Post> FindPostAsync(int year, int month, string title);

        /// <summary>
        /// Count async posts for category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        Task<int> CountPostsForCategoryAsync(string category);

        /// <summary>
        /// Get async post by category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        Task<IEnumerable<Post>> GetPostsByCategoryAsync(string category);

        /// <summary>
        /// Get async post by categoryid
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        Task<IEnumerable<Post>> GetPostsByCategoryAsync(Guid categoryId);

        /// <summary>
        /// Count async posts for tag
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        Task<int> CountPostsForTagAsync(string tag);

        /// <summary>
        /// Get async posts by tag
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        Task<IEnumerable<Post>> GetPostsByTagAsync(string tag);

        /// <summary>
        /// Get async posts by tag id
        /// </summary>
        /// <param name="tagId"></param>
        /// <returns></returns>
        Task<IEnumerable<Post>> GetPostsByTagAsync(Guid tagId);

        /// <summary>
        /// Get async most viewed post
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        Task<IEnumerable<Post>> GetMostViewedPostAsync(int size);

        /// <summary>
        /// Get most viewed post
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        IEnumerable<Post> GetMostViewedPost(int size);

        /// <summary>
        /// Get highest posts
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        Task<IEnumerable<Post>> GetHighestPosts(int size);

    }
}
