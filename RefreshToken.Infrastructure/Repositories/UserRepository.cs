using RefreshToken.Core.Crosscutting.Infraestructure;
using RefreshToken.Domain.Entity;
using RefreshToken.Domain.Repositories.Interfaces;
using RefreshToken.Infrastructure.Contexts;

namespace RefreshToken.Infrastructure.Repositories
{
    public class UserRepository : PostgresRepository<User>, IUserRepository
    {
        public UserRepository(RefreshTokenContext context) : base(context) { }
    }
}
