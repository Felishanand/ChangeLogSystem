using ChangeLogSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ChangeLogSystem.Data.Common
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly IServiceProvider _serviceProvider;
        private ChangeLogDbContext _dbContext;
        private bool disposed;

        public BaseRepository(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _dbContext = serviceProvider.GetService<ChangeLogDbContext>();
        }

        public ChangeLogDbContext GetDbContext => _dbContext;

        public virtual async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbContext.Set<TEntity>().AnyAsync(predicate);
        }

        public virtual TEntity Create()
        {
            return Activator.CreateInstance<TEntity>();
        }

        public virtual async Task DeleteAsyc(List<TEntity> entities, bool saveChanges = true)
        {
            foreach (TEntity entity in entities)
            {
                if (_dbContext.Entry(entity).State == EntityState.Deleted)
                {
                    _dbContext.Set<TEntity>().Attach(entity);
                }
            }

            _dbContext.Set<TEntity>().RemoveRange(entities);

            if (saveChanges)
            {
                await _dbContext.SaveChangesAsync();
            }
        }

        public virtual async Task DeleteAsync(Expression<Func<TEntity, bool>> predicate, bool saveChanges = true)
        {
            IList<TEntity> entities = await GetAllAsync(predicate);

            foreach (TEntity entity in entities)
            {
                if (_dbContext.Entry(entity).State == EntityState.Deleted)
                {
                    _dbContext.Set<TEntity>().Attach(entity);
                }

                _dbContext.Set<TEntity>().RemoveRange(entity);

                if (saveChanges)
                {
                    await _dbContext.SaveChangesAsync();
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposiing)
        {
            if (disposed)
            {
                return;
            }

            if (disposiing && _dbContext != null)
            {
                _dbContext.Dispose();
                _dbContext = null;
            }
        }

        public virtual TEntity Find(Guid id)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }

        public virtual async Task<TEntity> FirstAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbContext.Set<TEntity>().Where(predicate).FirstAsync();
        }

        public virtual async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbContext.Set<TEntity>().Where(predicate).FirstOrDefaultAsync();
        }

        public virtual async Task<List<TEntity>> GetAllAsync()
        {
            return await _dbContext.Set<TEntity>().ToListAsync();
        }

        public virtual async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbContext.Set<TEntity>().Where(predicate).ToListAsync();
        }

        public virtual async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate, params string[] navigationPropertyPaths)
        {
            IQueryable<TEntity> query = _dbContext.Set<TEntity>();

            foreach (string navigationPropertyPath in navigationPropertyPaths)
            {
                query = query.Include(navigationPropertyPath);
            }

            return await query.Where(predicate).ToListAsync();
        }

        public virtual async Task InsertAsync(TEntity entity, bool saveChanges = true)
        {
            try
            {
                _dbContext.Set<TEntity>().Add(entity);

                if (saveChanges)
                {
                    await _dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public virtual async Task InsertAsync(List<TEntity> entities, bool saveChanges = true)
        {
            _dbContext.Set<TEntity>().AddRange(entities);

            if (saveChanges)
            {
                await _dbContext.SaveChangesAsync();
            }
        }

        public virtual async Task<TEntity> LastOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbContext.Set<TEntity>().Where(predicate).LastOrDefaultAsync();
        }

        public virtual async Task<TEntity> LastOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, params string[] navigationPropertyPaths)
        {
            IQueryable<TEntity> query = _dbContext.Set<TEntity>();

            foreach (string navigationPropertyPath in navigationPropertyPaths)
            {
                query = query.Include(navigationPropertyPath);
            }

            return await query.Where(predicate).LastOrDefaultAsync();
        }

        public virtual async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task UpdateAsync(TEntity entity, bool saveChanges = true)
        {
            _dbContext.Set<TEntity>().Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;

            if (saveChanges)
            {
                await _dbContext.SaveChangesAsync();
            }
        }

        public virtual async Task UpdateAsync(List<TEntity> entities, bool saveChanges = true)
        {
            foreach (TEntity entity in entities)
            {
                _dbContext.Set<TEntity>().Attach(entity);
                _dbContext.Entry(entity).State = EntityState.Modified;
            }

            if (saveChanges)
            {
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}