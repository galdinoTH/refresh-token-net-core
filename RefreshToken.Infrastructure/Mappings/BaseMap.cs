using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RefreshToken.Core.Crosscutting.Base;

namespace RefreshToken.Infrastructure.Mappings;

public class BaseMap<T> : IEntityTypeConfiguration<T> where T : BaseEntity
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.HasKey((T x) => x.Id);
        builder.Property((T x) => x.Active).IsRequired().HasDefaultValue(true);
        builder.Property((T x) => x.CreatedAt).IsRequired();
        builder.Property((T x) => x.UpdatedAt);
        builder.Property((T x) => x.RegisteredById);
        builder.Property((T x) => x.LastChangeById);
    }
}
