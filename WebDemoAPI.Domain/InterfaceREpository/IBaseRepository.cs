using System;
using System.Collections.Generic;
using System.Formats.Tar;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WebDemoAPI.Domain.InterfaceREpository
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<IQueryable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression);
        Task<TEntity> GetAsyncById(int  id);
        Task<TEntity> GetAsyncById(Expression<Func<TEntity, bool>> expression = null);
        Task<IEnumerable<TEntity>> CreateAsync(IEnumerable<TEntity> entities);
        Task<TEntity> CreateAsync(TEntity entity);
        Task DeleteAsync(int id);
        Task DeleteAsync(Expression<Func<TEntity, bool>> expression = null);
        Task<TEntity> UpdateAsync (TEntity entity);
        Task<IEnumerable<TEntity>> UpdateAsync(IEnumerable<TEntity> entities);
        Task<int> CountAsync(Expression<Func<TEntity, bool>> expression = null);
        Task<int> CountAsync(string incude, Expression<Func<TEntity, bool>> expression = null);
    }
}
