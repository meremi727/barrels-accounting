using System.Linq.Expressions;
using BarrelsAccounting.Accounting.Domain;

namespace BarrelsAccounting.Accounting.Dal;

/// <summary>
/// Репозиторий сервиса учета ЛКМ.
/// </summary>
/// <param name="context"> Контекст БД. </param>
public class AccountingRepository(AccountingDbContext context) : IAccountingRepository
{
    /// <inheritdoc/>
    /// <exception cref="ArgumentNullException"> Если бочка была <c>null</c>. </exception>
    public void AddBarrel(Barrel barrel)
    {
        ArgumentNullException.ThrowIfNull(barrel, nameof(barrel));
        context.Barrels.Add(barrel);
        context.SaveChanges();
    }

    /// <inheritdoc/>
    /// <exception cref="ArgumentNullException"> Если бочка была <c>null</c>. </exception>
    public void UpdateBarrel(Barrel barrel)
    {
        ArgumentNullException.ThrowIfNull(barrel, nameof(barrel));
        context.Barrels.Update(barrel);
        context.SaveChanges();
    }

    /// <inheritdoc/>
    public IReadOnlyCollection<Barrel> GetBarrelsByIds(IEnumerable<string> ids)
        => context.Barrels.Where(b => ids.Contains(b.Id))
                          .ToList();

    /// <inheritdoc/>
    public IReadOnlyCollection<Barrel> GetBarrels(Expression<Func<Barrel, bool>> predicate)
        => context.Barrels.Where(predicate)
                          .ToList();

    /// <inheritdoc/>
    public TStorageObject? GetStorageObjectById<TStorageObject>(Guid storageObjectId)
        where TStorageObject : StorageObject
            => context.StorageObjects.OfType<TStorageObject>()
                                     .Where(s => s.Id == storageObjectId)
                                     .SingleOrDefault();

    /// <inheritdoc/>
    public IReadOnlyCollection<TStorageObject> GetStorageObjectsByStorageId<TStorageObject>(Guid storageId)
        where TStorageObject : StorageObject
            => context.StorageObjects.OfType<TStorageObject>()
                                     .Where(s => s.StorageId == storageId)
                                     .ToList();

    /// <inheritdoc/>
    public IReadOnlyCollection<TStorage> GetStorages<TStorage>()
        where TStorage : Storage
            => context.Storages.OfType<TStorage>()
                               .ToList();

    /// <inheritdoc/>
    public TStorage? GetStorageById<TStorage>(Guid storageId)
        where TStorage : Storage
            => context.Storages.OfType<TStorage>()
                               .Where(s => s.Id == storageId)
                               .SingleOrDefault();

    private readonly AccountingDbContext context = context;
}