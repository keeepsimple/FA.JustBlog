using FA.JustBlog.Models.Common;
using FA.JustBlog.Services.BaseServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FA.JustBlog.Services
{
    public interface ITagServices : IBaseService<Tag>
    {
        /// <summary>
        /// Get tag by url slug
        /// </summary>
        /// <param name="urlSlug"></param>
        /// <returns></returns>
        Tag GetTagByUrlSlug(string urlSlug);

        /// <summary>
        /// Get tag async by url slug
        /// </summary>
        /// <param name="urlSlug"></param>
        /// <returns></returns>
        Task<Tag> GetTagByUrlSlugAsync(string urlSlug);

        /// <summary>
        /// Get async popular tag
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        Task<IEnumerable<Tag>> GetPopularTagAsync(int size);

        /// <summary>
        /// Get popular tags 
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        IEnumerable<Tag> GetPopularTags(int size);
    }
}
