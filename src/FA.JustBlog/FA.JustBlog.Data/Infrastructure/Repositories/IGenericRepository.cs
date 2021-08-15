using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FA.JustBlog.Data.Infrastructure.Repositories
{
    public interface IGenericRepository<TEntity>
    {
        /// <summary>
        /// Get a <typeparamref name="TEntity"/> by id with async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TEntity> GetByIdAsync(Guid id);

        TEntity GetById(Guid id);

        /// <summary>
        /// Add an <typeparamref name="TEntity"/>
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        void Add(TEntity entity);

        /// <summary>
        /// Add list of <typeparamref name="TEntity"/>
        /// </summary>
        /// <param name="entities"></param>
        void Add(IEnumerable<TEntity> entities);

        /// <summary>
        /// Delete an <typeparamref name="TEntity"/>
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        void Delete(TEntity entity, bool isHardDelete = false);

        /// <summary>
        /// Delete list of <typeparamref name="TEntity"/>
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="isHardDelete"></param>
        void Delete(IEnumerable<TEntity> entities, bool isHardDelete = false);

        /// <summary>
        /// Delete an <typeparamref name="TEntity"/> have condition
        /// </summary>
        /// <param name="where"></param>
        /// <param name="isHardDelete"></param>
        void Delete(Expression<Func<TEntity, bool>> where, bool isHardDelete = false);

        /// <summary>
        /// Get query
        /// </summary>
        /// <returns></returns>
        IQueryable<TEntity> GetQuery();

        /// <summary>
        /// Get query have condition
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        IQueryable<TEntity> GetQuery(Expression<Func<TEntity, bool>> where);

        /// <summary>
        /// Get list of <typeparamref name="TEntity"/>
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <param name="includeProperties"></param>
        /// <param name="canLoadDeleted"></param>
        /// <returns></returns>
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, 
            IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "", bool canLoadDeleted = false);

        /// <summary>
        /// Update an <typeparamref name="TEntity"/>
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        void Update(TEntity entity);
    }
}
