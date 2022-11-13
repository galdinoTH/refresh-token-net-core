using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RefreshToken.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
