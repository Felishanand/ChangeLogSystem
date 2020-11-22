using ChangeLogSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ChangeLogSystem.Data.Common
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : class
    {
        ChangeLogDbContext GetDbContext { get; }

        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate);

        TEntity Create();

        Task DeleteAsync(Expression<Func<TEntity, bool>> predicate, bool saveChanges = true);

        Task DeleteAsyc(List<TEntity> entities, bool saveChanges = true);

        TEntity Find(Guid id);

        Task<TEntity> FirstAsync(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate);

        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate, params string[] navigationPropertyPaths);

        Task<List<TEntity>> GetAllAsync();

        Task InsertAsync(TEntity entity, bool saveChanges = true);

        Task InsertAsync(List<TEntity> entities, bool saveChanges = true);

        Task<TEntity> LastOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> LastOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, params string[] navigationPropertyPaths);

        Task SaveChangesAsync();

        Task UpdateAsync(TEntity entity, bool saveChanges = true);

        Task UpdateAsync(List<TEntity> entities, bool saveChanges = true);
    }
}