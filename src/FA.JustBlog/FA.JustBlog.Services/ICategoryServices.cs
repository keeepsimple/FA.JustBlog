using FA.JustBlog.Models.Common;
using FA.JustBlog.Services.BaseServices;
using System.Threading.Tasks;

namespace FA.JustBlog.Services
{
    public interface ICategoryServices : IBaseService<Category>
    {
        /// <summary>
        /// Get category by url slug
        /// </summary>
        /// <param name="urlSlug"></param>
        /// <returns></returns>
        Category GetCategoryByUrlSlug(string urlSlug);

        /// <summary>
        /// Get async category by url slug
        /// </summary>
        /// <param name="urlSlug"></param>
        /// <returns></returns>
        Task<Category> GetCategoryByUrlSlugAsync(string urlSlug);
    }
}
