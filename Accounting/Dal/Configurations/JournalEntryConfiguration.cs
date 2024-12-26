using Accounting.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Accounting.Dal.Configurations;

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
        #warning Не определены индексы для сущности JournalEntry

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