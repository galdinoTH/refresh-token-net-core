using RefreshToken.Core.Crosscutting.Base;

namespace RefreshToken.Core.Crosscutting.Interfaces;

public interface IPostgresRepository<TEntity> : IDisposable where TEntity : class, IEntity
{
    Task<IQueryable<TEntity>> ListAllAsync(bool track = true);

    Task<TEntity> GetByIdAsync(Guid id);

    Task<long> CountAllAsync();

    Task DeleteByIdAsync(Guid id);

    Task InsertOrUpdateAsync(TEntity entity, params string[] ignorePropertiesUpdate);

    Task InsertRangeAsync(IList<TEntity> entities);

    Task<int> SaveChangesAsync();
}
