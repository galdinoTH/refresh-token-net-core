using Microsoft.EntityFrameworkCore;
using RefreshToken.Core.Crosscutting.Base;
using RefreshToken.Core.Crosscutting.Interfaces;
using System.Reflection;

namespace RefreshToken.Core.Crosscutting.Infraestructure;

public abstract class PostgresRepository<TEntity> : IPostgresRepository<TEntity>, IDisposable where TEntity : BaseEntity, IEntity
{
    public DbContext Context;

    protected PostgresRepository()
    {
    }

    protected PostgresRepository(DbContext context)
    {
        Context = context;
    }

    ~PostgresRepository()
    {
        Dispose(disposing: false);
    }

    public DbSet<TEntity> DbSet()
    {
        return Context.Set<TEntity>();
    }

    public async Task<IQueryable<TEntity>> ListAllAsync(bool track = true)
    {
        IQueryable<TEntity> query = null;
        if (DbSet().Any())
        {
            query = await Task.Run(() => DbSet().AsQueryable());
            if (!track)
            {
                query = query.AsNoTracking();
            }
        }

        return query;
    }

    public async Task<TEntity> GetByIdAsync(Guid id)
    {
        return await DbSet().FindAsync(id);
    }

    public async Task<long> CountAllAsync()
    {
        int num = ((await DbSet().AnyAsync()) ? (await DbSet().AsNoTracking().CountAsync()) : 0);
        return num;
    }

    public async Task InsertOrUpdateAsync(TEntity entity, params string[] ignorePropertiesUpdate)
    {
        TEntity context = await GetByIdAsync(entity.Id);
        if (context == null)
        {
            await DbSet().AddAsync(entity);
            return;
        }

        Context.Entry(context).CurrentValues.SetValues(entity);
        Context.Entry(context).State = EntityState.Modified;
        if (ignorePropertiesUpdate == null || ignorePropertiesUpdate.Length == 0)
        {
            return;
        }

        foreach (string p in ignorePropertiesUpdate)
        {
            if (entity.GetType().GetProperties().Any((PropertyInfo i) => i.Name == p))
            {
                Context.Entry(context).Property(p).IsModified = false;
            }
        }
    }

    public async Task InsertRangeAsync(IList<TEntity> entities)
    {
        await DbSet().AddRangeAsync(entities);
    }

    public async Task DeleteByIdAsync(Guid id)
    {
        TEntity context = await GetByIdAsync(id);
        if (context != null)
        {
            Context.Entry(context).State = EntityState.Deleted;
            DbSet().Remove(context);
        }
    }

    public async Task<int> SaveChangesAsync()
    {
        return await Context.SaveChangesAsync();
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing && Context != null)
        {
            Context.Dispose();
            Context = null;
        }
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
