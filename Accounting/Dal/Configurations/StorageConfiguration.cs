using Accounting.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Accounting.Dal.Configurations;

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
        #warning Не определены индексы для сущности Storage

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