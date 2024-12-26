using Accounting.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Accounting.Dal.Configurations;

/// <summary>
/// Конфигурация для сущности <see cref="Barrel"/>.
/// </summary>
public class BarrelConfiguration : IEntityTypeConfiguration<Barrel>
{
    /// <inheritdoc/>
    public void Configure(EntityTypeBuilder<Barrel> builder)
    {
        builder.ToTable("Barrel");

        // PRIMARY KEY
        builder.HasKey(b => b.Id);

        // INDEXES
        #warning Не определены индексы для сущности Barrel

        builder.Property(b => b.Id)
               .HasColumnName("Id")
               .IsRequired();

        builder.Property(b => b.ProviderCode)
               .HasColumnName("ProviderCode")
               .IsRequired();

        builder.Property(b => b.Ral)
               .HasColumnName("Ral")
               .IsRequired();

        builder.Property(b => b.Batch)
               .HasColumnName("Batch")
               .IsRequired();

        builder.Property(b => b.Number)
               .HasColumnName("Number")
               .IsRequired();

        builder.Property(b => b.NettoWeight)
               .HasColumnName("NettoWeight")
               .IsRequired();

        builder.Property(b => b.BruttoWeight)
               .HasColumnName("BruttoWeight")
               .IsRequired();

        builder.Property(b => b.ProductionDate)
               .HasColumnName("ProductionDate")
               .IsRequired();

        builder.Property(b => b.Status)
               .HasColumnName("Status")
               .IsRequired();

        builder.Property(b => b.IsDrained)
               .HasColumnName("IsDrained")
               .IsRequired();

        builder.Property(b => b.CreatedDateTime)
               .HasColumnName("CreatedDateTime")
               .IsRequired();

        builder.Property(b => b.DeletedDateTime)
               .HasColumnName("DeletedDateTime")
               .IsRequired(false);

        builder.Property(b => b.StorageObjectId)
               .HasColumnName("StorageObjectId")
               .IsRequired(false);
    }
}