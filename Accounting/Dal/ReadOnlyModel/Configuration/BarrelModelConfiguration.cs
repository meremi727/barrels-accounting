using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BarrelsAccounting.Accounting.Dal.ReadOnlyModel.Configuration;

/// <summary>
/// Конфигурация для сущности <see cref="BarrelModel"/>.
/// </summary>
public class BarrelModelConfiguration : IEntityTypeConfiguration<BarrelModel>
{
    /// <inheritdoc/>
    public void Configure(EntityTypeBuilder<BarrelModel> builder)
    {
        builder.ToTable("Barrel");

        builder.Property(b => b.Id)
               .HasColumnName("Id")
               .IsRequired();

        builder.Property(b => b.Code)
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
               .HasConversion<string>()
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

        builder.OwnsOne(b => b.CodeAttributes);
		builder.Navigation(b => b.CodeAttributes)
			   .AutoInclude();

        builder.OwnsOne(b => b.BatchAttributes);
		builder.Navigation(b => b.BatchAttributes)
			   .AutoInclude();
    }
}