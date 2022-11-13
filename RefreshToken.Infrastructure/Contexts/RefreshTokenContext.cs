using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RefreshToken.Infrastructure.Mappings;

namespace RefreshToken.Infrastructure.Contexts;

public class RefreshTokenContext : IdentityDbContext
{
    private readonly IConfiguration _config;

    public RefreshTokenContext(IConfiguration config)
    {
        _config = config;
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfig());

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_config.GetConnectionString("postgres"));

        base.OnConfiguring(optionsBuilder);
    }
}