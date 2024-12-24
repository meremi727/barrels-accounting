namespace Accounting.Domain;

/// <summary>
/// Склад производства.
/// </summary>
public class ProductionStorage : Storage
{
    /// <summary>
    /// Возвращает агрегаты, которые есть на складе производства.
    /// </summary>
    public IEnumerable<Aggregate> Aggregates { get; set; } = null!;
}