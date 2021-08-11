using FA.JustBlog.Models.Common;
using FA.JustBlog.Services.BaseServices;
using System.Threading.Tasks;

namespace FA.JustBlog.Services
{
    public interface ICategoryServices : IBaseService<Category>
    {
        Category GetCategoryByUrlSlug(string urlSlug);

        Task<Category> GetCategoryByUrlSlugAsync(string urlSlug);
    }
}
