using BarrelsAccounting.Accounting.Domain;
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

              builder.HasKey(b => b.Id);

              builder.Property(b => b.Id)
                     .HasColumnName("Id")
                     .IsRequired();

              builder.Property(b => b.Code)
                     .HasColumnName("Code")
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

              builder.OwnsOne(b => b.BatchAttributes);
              builder.Navigation(b => b.BatchAttributes)
                        .AutoInclude();

              builder.OwnsOne(b => b.BatchAttributes,
                    nb =>
                    {
                           nb.ToTable("Batch");
                           nb.HasKey(b => b.BatchNumber);
                           nb.HasIndex(b => b.BatchNumber);

                           nb.Property(b => b.BatchNumber)
                            .HasColumnName("BatchNumber")
                            .IsRequired();

                           nb.Property(b => b.AttestationStatus)
                            .HasColumnName("AttestationStatus")
                            .IsRequired(false);
                           nb.WithOwner()
                             .HasForeignKey(b => b.BatchNumber)
                             .HasPrincipalKey(barrel => barrel.Code);
                    });

              builder.Navigation(b => b.BatchAttributes)
                     .AutoInclude();


              builder.OwnsOne(b => b.CodeAttributes,
                    nb =>
                    {
                           nb.ToTable("Code");
                           nb.HasKey(c => c.MaterialCode);
                           nb.HasIndex(c => c.MaterialCode);

                           nb.Property(c => c.MaterialCode)
                                  .HasColumnName("MaterialCode")
                                  .IsRequired();

                           nb.Property(c => c.Gloss)
                                  .HasColumnName("Gloss")
                                  .IsRequired(false);

                           nb.Property(c => c.Material)
                                  .HasColumnName("Material")
                                  .IsRequired(false);

                           nb.Property(c => c.MaterialType)
                                  .HasColumnName("MaterialType")
                                  .IsRequired(false);

                           nb.Property(c => c.ProviderName)
                                  .HasColumnName("ProviderName")
                                  .IsRequired(false);
                           nb.WithOwner()
                             .HasForeignKey(code => code.MaterialCode)
                             .HasPrincipalKey(barrel => barrel.Code);
                    });
              builder.Navigation(b => b.CodeAttributes)
                        .AutoInclude();

              // Костыли, чтобы использовать одну таблицу "Barrel" для двух моделей Barrel и BarrelModel
              builder.HasOne<Barrel>()
                     .WithOne()
                     .HasForeignKey<BarrelModel>(b => b.Id);
       }
}