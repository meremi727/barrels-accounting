using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BarrelsAccounting.Accounting.Domain;

namespace BarrelsAccounting.Accounting.Dal.Configurations;

/// <summary>
/// Конфигурация для сущности <see cref="JournalEntry"/>.
/// </summary>
public class JournalEntryConfiguration : IEntityTypeConfiguration<JournalEntry>
{
    /// <inheritdoc/>
    public void Configure(EntityTypeBuilder<JournalEntry> builder)
    {
        builder.ToTable("Journal");

        // PRIMARY KEY
        builder.HasKey(j => j.Id);

        // INDEXES
        builder.HasIndex(j => j.Id);
        builder.HasIndex(j => j.DateTime);
        builder.HasIndex(j => j.OperationType);
        builder.HasIndex(j => j.StorageObjectId);

        builder.Property(j => j.Id)
               .HasColumnName("Id")
               .IsRequired();

        builder.Property(j => j.BarrelId)
               .HasColumnName("BarrelId")
               .IsRequired();

        builder.Property(j => j.DateTime)
               .HasColumnName("DateTime")
               .IsRequired();

        builder.Property(j => j.OperationPayload)
               .HasColumnName("OperationPayload")
               .IsRequired();

        builder.Property(j => j.OperationType)
               .HasColumnName("OperationType")
               .IsRequired();

        builder.Property(j => j.UserName)
               .HasColumnName("UserName")
               .IsRequired();

        builder.Property(j => j.StorageObjectId)
               .HasColumnName("StorageObjectId")
               .IsRequired(false);
    }
}