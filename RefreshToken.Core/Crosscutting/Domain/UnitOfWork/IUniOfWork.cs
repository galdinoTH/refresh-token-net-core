using Microsoft.EntityFrameworkCore;

namespace RefreshToken.Core.Crosscutting.Domain.UnitOfWork;

public interface IUnitOfWork<TContext> : IDisposable where TContext : DbContext
{
    Task<bool> CommitAsync();
}
