namespace BarrelsAccounting.Accounting.Domain;

/// <summary>
/// Перечисление возможных статусов бочки в системе.
/// </summary>
public enum BarrelStatus
{
    /// <summary>
    /// Принята на склад.
    /// </summary>
    Accepted,

    /// <summary>
    /// Списана в производство.
    /// </summary>
    InProduction,

    /// <summary>
    /// Возвращена с производства.
    /// </summary>
    Returned
}