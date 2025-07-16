using System.Linq.Expressions;

namespace Lab3_Presentation.Middleware.BaseRepo;

public interface IBaseRepo<TEntity> where TEntity : class
{
    Task<TEntity> GetByIdAsync(long id);               // Get entity by ID
    Task<IEnumerable<TEntity>> GetAllAsync();         // Get all entities
    Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);  // Find by condition

    Task AddAsync(TEntity entity);                    // Add new entity
    Task AddRangeAsync(IEnumerable<TEntity> entities);  // Add multiple entities

    Task UpdateAsync(TEntity entity);                      // Update an entity
    Task UpdateRangeAsync(IEnumerable<TEntity> entities);
    Task RemoveAsync(TEntity entity);                      // Delete an entity
    Task RemoveRangeAsync(IEnumerable<TEntity> entities);  // Delete multiple entities
}
