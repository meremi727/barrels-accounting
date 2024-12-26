using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BarrelsAccounting.Accounting.Dal.ReadOnlyModel.Configuration;

/// <summary>
/// Конфигурация для сущности <see cref="RalModel"/>.
/// </summary>
public class RalModelConfiguration : IEntityTypeConfiguration<RalModel>
{
    /// <inheritdoc/>
    public void Configure(EntityTypeBuilder<RalModel> builder)
    {
        builder.ToTable("Ral");

        builder.HasKey(r => r.Code);

        builder.HasIndex(r => r.Code);

        builder.Property(r => r.Code)
               .HasColumnName("Code")
               .IsRequired();

        builder.Property(r => r.Description)
               .HasColumnName("Description")
               .IsRequired();
    }
}