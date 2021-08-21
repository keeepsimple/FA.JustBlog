using FA.JustBlog.Data.Infrastructure;
using FA.JustBlog.Models.Common;
using FA.JustBlog.Services.BaseServices;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace FA.JustBlog.Services
{
    public class CategoryServices : BaseServices<Category>, ICategoryServices
    {
        public CategoryServices(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public override IEnumerable<Category> GetAll()
        {
            return _unitOfWork.GenericRepository<Category>().GetQuery().Include("Posts").ToList();
        }

        public override async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _unitOfWork.GenericRepository<Category>().GetQuery().Include("Posts").ToListAsync();
        }

        public Category GetCategoryByUrlSlug(string urlSlug)
        {
            return _unitOfWork.CategoryRepository.GetQuery().FirstOrDefault(x=>x.UrlSlug == urlSlug);
        }

        public async Task<Category> GetCategoryByUrlSlugAsync(string urlSlug)
        {
            return await _unitOfWork.CategoryRepository.GetQuery().FirstOrDefaultAsync(x=>x.UrlSlug == urlSlug);
        }
    }
}
