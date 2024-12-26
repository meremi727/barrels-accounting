using Accounting.Domain;
using Microsoft.EntityFrameworkCore;

namespace Accounting.Dal;

/// <summary>
/// Класс контекста БД сервиса учета.
/// </summary>
/// <param name="options"></param>
public class AccountingDbContext(DbContextOptions<AccountingDbContext> options) : DbContext(options)
{
    #region Properties

    /// <summary>
    /// Возвращает все бочки.
    /// </summary>
    public DbSet<Barrel> Barrels { get; private set; } = null!;

    /// <summary>
    /// Возвращает все МХ.
    /// </summary>
    public DbSet<StoragePlace> StoragePlaces { get; private set; } = null!;

    /// <summary>
    /// Возвращает все агрегаты.
    /// </summary>
    public DbSet<Aggregate> Aggregates { get; private set; } = null!;

    /// <summary>
    /// Возвращает все объекты хранилища.
    /// </summary>
    public DbSet<StorageObject> StorageObjects { get; private set; } = null!;

    /// <summary>
    /// Возвращает все склады производства.
    /// </summary>
    public DbSet<ProductionStorage> ProductionStorages { get; private set; } = null!;

    /// <summary>
    /// Возвращает все склады приемки.
    /// </summary>
    public DbSet<AcceptanceStorage> AcceptanceStorages { get; private set; } = null!;

    /// <summary>
    /// Возвращает все склады.
    /// </summary>
    public DbSet<Storage> Storages { get; private set; } = null!;

    #endregion

    #region Override

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // modelBuilder.ApplyConfiguration()
        // Apply configurations
    }

    #endregion
}