using System.Linq.Expressions;
using BarrelsAccounting.Accounting.Dal.ReadOnlyModel;

namespace BarrelsAccounting.Accounting.Dal;

/// <summary>
/// Репозиторий поиска бочек.
/// </summary>
public class SearchRepository(SearchDbContext context) : ISearchRepository
{
    /// <inheritdoc/>
    public IReadOnlyCollection<BarrelModel> Find(Expression<Func<BarrelModel, bool>> predicate)
        => context.Barrels.Where(predicate)
                          .ToList();

    /// <inheritdoc/>
    public IReadOnlyCollection<BarrelModel> FindBy(IReadOnlyCollection<string> ids)
        => context.Barrels.Where(b => ids.Contains(b.Id))
                          .ToList();

    private readonly SearchDbContext context = context;
}