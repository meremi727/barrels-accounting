using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BarrelsAccounting.Accounting.Domain;

namespace BarrelsAccounting.Accounting.Dal.Configurations;

/// <summary>
/// Конифгурация для сущности <see cref="StorageObject"/>.
/// </summary>
public class StorageObjectConfiguration : IEntityTypeConfiguration<StorageObject>
{
    /// <inheritdoc/>
    public void Configure(EntityTypeBuilder<StorageObject> builder)
    {
        builder.ToTable("StorageObject");

        // PRIMARY KEY
        builder.HasKey(so => so.Id);

        // INDEXES
        #warning Не определены индексы для сущности StorageObject

        builder.Property(so => so.Id)
               .HasColumnName("Id")
               .IsRequired();

        builder.Property(so => so.Barcode)
               .HasColumnName("Barcode")
               .IsRequired();

        builder.Property(so => so.Name)
               .HasColumnName("Name")
               .IsRequired();

        builder.Property(so => so.StorageId)
               .HasColumnName("StorageId")
               .IsRequired();

        builder.HasDiscriminator<string>("StorageObjectTypeDiscriminator")
               .HasValue<StoragePlace>("StoragePlace")
               .HasValue<Aggregate>("Aggregate");
    }
}