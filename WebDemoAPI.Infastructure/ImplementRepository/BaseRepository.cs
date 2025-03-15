using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using WebDemoAPI.Domain.InterfaceREpository;
using WebDemoAPI.Infastructure.DataContext;

namespace WebDemoAPI.Infastructure.ImplementRepository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected IDbcontext _IDbcontext;
        protected DbSet<TEntity> _dbset;
        protected DbContext _DBcontext;
        protected DbSet<TEntity> DBset
        {
            get
            {
                if(_dbset == null)
                {
                    _dbset = _DBcontext.Set<TEntity>() as DbSet<TEntity>;
                }
                return _dbset;
            }
        }
        public BaseRepository(IDbcontext dbcontext)
        {
            _IDbcontext = dbcontext;
            _DBcontext = (DbContext)dbcontext;
        }


        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> expression = null)
        {
            IQueryable<TEntity> query = expression !=null ? DBset.Where(expression) : DBset;
            return await query.CountAsync();
        }

        public async Task<int> CountAsync(string incude, Expression<Func<TEntity, bool>> expression = null)
        {
            IQueryable<TEntity> query;
            if (!string.IsNullOrEmpty(incude))
            {
                query = BuildeQueryable(new List<string>{ incude }, expression);
                return await query.CountAsync();
                   
            }
            return await CountAsync(expression);
        }
        protected IQueryable<TEntity> BuildeQueryable(List<String> include, Expression<Func<TEntity, bool>> expression)
        {
            IQueryable<TEntity> query = DBset.AsQueryable();
            if (expression != null)
            {
                query = query.Where(expression);
            }
            if(include != null && include.Count > 0)
            {
                foreach (var item in include)
                {
                    query = query.Include(item.Trim());
                }
            }
            return query;
        }

        public async Task<IEnumerable<TEntity>> CreateAsync(IEnumerable<TEntity> entities)
        {
            DBset.AddRange(entities);
            await _IDbcontext.CommitChageAsync();
            return entities;
        }
        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            DBset.Add(entity);
            await _IDbcontext.CommitChageAsync();
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var DataEntity = await DBset.FindAsync(id);
            if (DataEntity != null)
            {
                DBset.Remove(DataEntity);
                await _IDbcontext.CommitChageAsync();   
            }
        }

        public async Task DeleteAsync(Expression<Func<TEntity, bool>> expression = null)
        {
            IQueryable<TEntity> query = expression != null ? DBset.Where(expression) : DBset;
            var Entity = query;
            if (Entity != null)
            {
                DBset.RemoveRange(Entity);
                await _IDbcontext.CommitChageAsync();
            }
        }

        public async Task<IQueryable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression = null)
        {
            IQueryable<TEntity> query = expression != null ? DBset.Where(expression) : DBset;
            return query;
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await DBset.FirstOrDefaultAsync(expression);
        }

        public async Task<TEntity> GetAsyncById(int id)
        {
            return await DBset.FindAsync(id);
        }

        public async Task<TEntity> GetAsyncById(Expression<Func<TEntity, bool>> expression = null)
        {
            return await DBset.FirstOrDefaultAsync(expression);
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            _DBcontext.Entry(entity).State = EntityState.Modified;
            await _IDbcontext.CommitChageAsync();
            return entity;
        }

        public async Task<IEnumerable<TEntity>> UpdateAsync(IEnumerable<TEntity> entities)
        {
            foreach (var item in entities)
            {
                _DBcontext.Entry(item).State = EntityState.Modified;
            }
            await _IDbcontext.CommitChageAsync();
            return entities;
        } 
    }
}
