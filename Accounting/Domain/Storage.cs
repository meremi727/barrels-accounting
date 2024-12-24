namespace Accounting.Domain;

/// <summary>
/// Склад.
/// </summary>
public abstract class Storage
{
    /// <summary>
    /// Возвращает уникальный идентификатор склада.
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// Возвращает код склада.
    /// </summary>
    public string Code { get; init; } = null!;

    /// <summary>
    /// Возвращает наименование склада.
    /// </summary>
    public string Name { get; init; } = null!;

    /// <summary>
    /// Возвращает идентификатор МХ установленного по-умолчанию.
    /// </summary>
    public Guid? StoragePlaceId { get; set; }
}