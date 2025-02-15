using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BarrelsAccounting.Accounting.Domain;

namespace BarrelsAccounting.Accounting.Dal.Configurations;

/// <summary>
/// Конфигурация для сущности <see cref="Aggregate"/>.
/// </summary>
public class AggregateConfiguration : IEntityTypeConfiguration<Aggregate>
{
    /// <inheritdoc/>
    public void Configure(EntityTypeBuilder<Aggregate> builder)
    {
        builder.Property(a => a.Volume)
               .HasColumnName("Volume")
               .IsRequired();
    }
}