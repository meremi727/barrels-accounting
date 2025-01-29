using BarrelsAccounting.Accounting.Dal.ReadOnlyModel;
using BarrelsAccounting.Accounting.Dal.ReadOnlyModel.Configuration;
using Microsoft.EntityFrameworkCore;

namespace BarrelsAccounting.Accounting.Dal;

/// <summary>
/// Конекст БД для поиска бочек.
/// </summary>
/// <param name="options"> Параметры подключения. </param>
public class SearchDbContext(DbContextOptions<SearchDbContext> options) : DbContext(options)
{
    /// <summary>
    /// Возвращает все неудаленные бочки.
    /// </summary>
    public DbSet<BarrelModel> Barrels { get; private set; } = null!;

    /// <inheritdoc/>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        var type = typeof(BarrelModelConfiguration);
		modelBuilder.ApplyConfigurationsFromAssembly(type.Assembly);
		modelBuilder.Entity<BarrelModel>()
                    .HasQueryFilter(barrel => !barrel.IsDeleted);
    }
}