using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BarrelsAccounting.Accounting.Domain;

namespace BarrelsAccounting.Accounting.Dal.Configurations;

/// <summary>
/// Конфигурация для сущности <see cref="Storage"/>.
/// </summary>
public class StorageConfiguration : IEntityTypeConfiguration<Storage>
{
    /// <inheritdoc/>
    public void Configure(EntityTypeBuilder<Storage> builder)
    {
        builder.ToTable("Storage");

        // PRIMARY KEY
        builder.HasKey(s => s.Id);

        // INDEXES
       builder.HasIndex(s => s.Id);

        builder.Property(s => s.Id)
               .HasColumnName("Id")
               .IsRequired();

        builder.Property(s => s.Code)
               .HasColumnName("Code")
               .IsRequired();

        builder.Property(s => s.Name)
               .HasColumnName("Name")
               .IsRequired();

        builder.Property(s => s.DefaultStoragePlaceId)
               .HasColumnName("DefaultStoragePlaceId")
               .IsRequired(false);

        builder.HasDiscriminator<string>("StorageTypeDiscriminator")
               .HasValue<AcceptanceStorage>("Acceptance")
               .HasValue<ProductionStorage>("Production");
    }
}