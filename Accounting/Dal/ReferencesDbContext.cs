using BarrelsAccounting.Accounting.Dal.ReadOnlyModel;
using Microsoft.EntityFrameworkCore;

namespace BarrelsAccounting.Accounting.Dal;

/// <summary>
/// Контекст БД для справочной информации.
/// </summary>
/// <param name="options"> Параметры подключения. </param>
public class ReferencesDbContext(DbContextOptions<ReferencesDbContext> options) : DbContext(options)
{
    /// <summary>
    /// Возвращает все цветовые обозначения.
    /// </summary>
    public DbSet<RalModel> Rals { get; private set; } = null!;

    /// <summary>
    /// Возвращает все кодовые обозначения.
    /// </summary>
    public DbSet<CodeModel> Codes { get; private set; } = null!;

    /// <summary>
    /// Возвращает все партии.
    /// </summary>
    public DbSet<BatchModel> Batches { get; private set; } = null!;

    /// <inheritdoc/>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        var type = typeof(RalModel);
		modelBuilder.ApplyConfigurationsFromAssembly(type.Assembly);
    }
}