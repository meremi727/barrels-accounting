using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BarrelsAccounting.Accounting.Domain;

namespace BarrelsAccounting.Accounting.Dal.Configurations;

/// <summary>
/// Конфигурация для сущности <see cref="ProductionStorage"/>.
/// </summary>
public class ProductionStorageConfiguration : IEntityTypeConfiguration<ProductionStorage>
{
    /// <inheritdoc/>
    public void Configure(EntityTypeBuilder<ProductionStorage> builder)
    {
        builder.HasMany(ps => ps.Aggregates)
               .WithOne()
               .HasForeignKey(a => a.StorageId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}