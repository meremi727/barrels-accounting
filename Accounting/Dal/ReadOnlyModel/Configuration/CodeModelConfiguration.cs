using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BarrelsAccounting.Accounting.Dal.ReadOnlyModel.Configuration;

/// <summary>
/// Конфигурация для сущности <see cref="CodeModel"/>.
/// </summary>
public class CodeModelConfiguration : IEntityTypeConfiguration<CodeModel>
{
    /// <inheritdoc/>
    public void Configure(EntityTypeBuilder<CodeModel> builder)
    {
        builder.ToTable("Code");

        builder.HasKey(c => c.MaterialCode);

        builder.HasIndex(c => c.MaterialCode);

        builder.Property(c => c.MaterialCode)
               .HasColumnName("MaterialCode")
               .IsRequired();

        builder.Property(c => c.Gloss)
               .HasColumnName("Gloss")
               .IsRequired(false);
        
        builder.Property(c => c.Material)
               .HasColumnName("Material")
               .IsRequired(false);

        builder.Property(c => c.MaterialType)
               .HasColumnName("MaterialType")
               .IsRequired(false);
        
        builder.Property(c => c.ProviderName)
               .HasColumnName("ProviderName")
               .IsRequired(false);
    }
}