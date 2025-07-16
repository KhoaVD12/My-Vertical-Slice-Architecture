using Lab3_Presentation.Database;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Lab3_Presentation.Middleware.BaseRepo;

public class BaseRepo<TEntity> : IBaseRepo<TEntity> where TEntity : class
{
    private readonly Context _context;
    protected readonly DbSet<TEntity> _dbSet;

    public BaseRepo(Context context)
    {
        _context = context;
        _dbSet = _context.Set<TEntity>();
    }

    // Get entity by Id (assuming entities have a primary key named 'Id')
    public async Task<TEntity> GetByIdAsync(long id)
    {
        return await _dbSet.FindAsync(id);
    }

    // Get all entities
    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    // Find entities with a condition (filter)
    public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _dbSet.Where(predicate).ToListAsync();
    }

    // Add a new entity
    public async Task AddAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    // Add multiple entities
    public async Task AddRangeAsync(IEnumerable<TEntity> entities)
    {
        await _dbSet.AddRangeAsync(entities);
        await _context.SaveChangesAsync();
    }

    // Update an entity
    public async Task UpdateAsync(TEntity entity)
    {
        _dbSet.Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
    // Update multiple entities
    public async Task UpdateRangeAsync(IEnumerable<TEntity> entities)
    {
        _dbSet.UpdateRange(entities);
        await _context.SaveChangesAsync();
    }

    // Remove an entity
    public async Task RemoveAsync(TEntity entity)
    {
        _dbSet.Remove(entity);
        await _context.SaveChangesAsync();
    }

    // Remove multiple entities
    public async Task RemoveRangeAsync(IEnumerable<TEntity> entities)
    {
        _dbSet.RemoveRange(entities);
        await _context.SaveChangesAsync();
    }
}
