using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace RefreshToken.Infrastructure.Contexts;

public class RefreshTokenContext : IdentityDbContext
{
    public RefreshTokenContext(DbContextOptions<RefreshTokenContext> options) : base(options) { }

}