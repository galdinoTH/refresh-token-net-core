using RefreshToken.Domain.Entity;
using RefreshToken.Core.Crosscutting.Interfaces;

namespace RefreshToken.Domain.Repositories.Interfaces;

public interface IUserRepository : IPostgresRepository<User>
{
}
