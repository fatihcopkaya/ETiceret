using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CoreLayer.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace CoreLayer.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBaseAsync<TEntity, TContext> : IEntityRepositoryAsync<TEntity> where TEntity : class, IEntity, new() where TContext : DbContext, new()
    {
        public async Task AddAsync(TEntity entity)
        {
           using var _context = new TContext();
           await _context.Set<TEntity>().AddAsync(entity);
           await _context.SaveChangesAsync();
        }

        public async Task<TEntity> GetAsync(int id)
        {
            using var _context = new TContext();
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            using var _context = new TContext();
            IQueryable<TEntity> queryable = _context.Set<TEntity>();
            if(filter != null)
            {
                queryable = queryable.Where(filter);

            }
            if(include != null)
            {
                queryable = include(queryable);
            }
            return await queryable.AsNoTracking().SingleOrDefaultAsync();
        }

        public async Task<TEntity> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes)
        {
            using var _context = new TContext();
            IQueryable<TEntity> queryable = _context.Set<TEntity>();
            if(filter != null)
            {
                queryable = queryable.Where(filter);
            }
            if(includes != null)
            {
                foreach(Expression<Func<TEntity, object>> include in includes)
                {
                    queryable = queryable.Include(include);

                }
            }
            return await queryable.FirstOrDefaultAsync();

        
        }

        public async Task<IList<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includes)
        {
            using var _context = new TContext();
            IQueryable<TEntity> queryable = _context.Set<TEntity>();
            if (filter != null)
            {
                queryable = queryable.Where(filter);
            }
            if(includes != null)
            {
                foreach(Expression<Func<TEntity, object>> include in includes)   
                {
                    queryable = queryable.Include(include);
                }
            } 
            if(orderBy != null)
            {
                return await orderBy(queryable).ToListAsync();
            }
            return await queryable.ToListAsync();
        }

        public async Task RemoveAsync(TEntity entity)
        {
            using var _context = new TContext();
            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            using var _context = new TContext();
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}