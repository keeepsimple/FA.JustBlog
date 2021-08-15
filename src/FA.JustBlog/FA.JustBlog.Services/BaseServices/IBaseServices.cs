using FA.JustBlog.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FA.JustBlog.Services.BaseServices
{
    public interface IBaseService<TEntity>
    {
        /// <summary>
        /// Add <typeparamref name="TEntity"/>
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int Add(TEntity entity);

        /// <summary>
        /// Add async <typeparamref name="TEntity"/>
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<int> AddAsync(TEntity entity);

        /// <summary>
        /// Add range of <typeparamref name="TEntity"/>
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        int AddRange(IEnumerable<TEntity> entities);

        /// <summary>
        /// Add range async of <typeparamref name="TEntity"/>
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        Task<int> AddRangeAsync(IEnumerable<TEntity> entities);

        /// <summary>
        /// Update an <typeparamref name="TEntity"/>
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool Update(TEntity entity);

        /// <summary>
        /// Update async <typeparamref name="TEntity"/>
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<bool> UpdateAsync(TEntity entity);

        /// <summary>
        /// Delete by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(Guid id);

        /// <summary>
        /// Delete async by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync(Guid id);

        /// <summary>
        /// Get <typeparamref name="TEntity"/> by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TEntity GetById(Guid id);

        /// <summary>
        /// Get async <typeparamref name="TEntity"/> by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TEntity> GetByIdAsync(Guid id);

        /// <summary>
        /// Get all <typeparamref name="TEntity"/>
        /// </summary>
        /// <returns></returns>
        IEnumerable<TEntity> GetAll();

        /// <summary>
        /// Get all async <typeparamref name="TEntity"/>
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> GetAllAsync();

        /// <summary>
        /// Return entities with paging, filtering, ordering
        /// </summary>
        /// <param name="filter">x=>x.Name.Contains("abc")</param>
        /// <param name="orderBy">q => q.OrderByDescending(c => c.Name);</param>
        /// <param name="includeProperties">"Products", "Authors, Category, Publisher"</param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<Paginated<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "", int pageIndex = 1, int pageSize = 10);
    }
}
