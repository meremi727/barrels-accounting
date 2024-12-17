namespace Accounting.Domain;

/// <summary>
/// Склад.
/// </summary>
public abstract class Storage
{
    #region Public

    #region Properties

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
    /// Возвращает все МХ, принадлежащие данному складу.
    /// </summary>
    public IEnumerable<StoragePlace> StoragePlaces { get; init; } = null!;

    /// <summary>
    /// Возвращает МХ установленный по-умолчанию.
    /// </summary>
    public StoragePlace? DefaultStoragePlace { get; set; }

    #endregion

    #endregion
}