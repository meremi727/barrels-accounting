using System.Linq.Expressions;

namespace BarrelsAccounting.Accounting.Domain;

public interface IJournalRepository
{
    /// <summary>
    /// Добавляет запись в журнал.
    /// </summary>
    /// <param name="entry"> Новая запись. </param>
    void AddEntry(JournalEntry entry);

    /// <summary>
    /// Находит все записи, удовлетворяющие условию.
    /// </summary>
    /// <param name="predicate"> Условие отбора. </param>
    /// <returns> Перечень записей журнала, удволетворяющих условию. </returns>
    IReadOnlyCollection<JournalEntry> FindBy(Expression<Func<JournalEntry, bool>> predicate);
}