using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BarrelsAccounting.Accounting.Dal.ReadOnlyModel.Configuration;

/// <summary>
/// Конфигурация для сущности <see cref="BatchModel"/>.
/// </summary>
public class BatchModelConfiguration : IEntityTypeConfiguration<BatchModel>
{
    /// <inheritdoc/>
    public void Configure(EntityTypeBuilder<BatchModel> builder)
    {
        builder.ToTable("Batch");

        builder.HasKey(b => b.BatchNumber);

        builder.HasIndex(b => b.BatchNumber);

        builder.Property(b => b.BatchNumber)
               .HasColumnName("Number")
               .IsRequired();
        
        builder.Property(b => b.AttestationStatus)
               .HasColumnName("AttestationStatus")
               .IsRequired(false);
    }
}