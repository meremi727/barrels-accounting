namespace Accounting.Domain;

/// <summary>
/// Объект хранилище. 
/// Абстрактная сущность, размещаемая на складах, в которой могут содержаться бочки.
/// </summary>
public abstract class StorageObject
{
    #region Public

    #region Properties

    /// <summary>
    /// Возвращает уникальный идентификатор объекта хранилища.
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// Возвращает штрих-код.
    /// </summary>
    public string Barcode { get; init; }

    /// <summary>
    /// Возвращает наименование объекта хранилища.
    /// </summary>
    public string Name { get; init; }

    /// <summary>
    /// Возвращает идентификатор склада, на котором расположен данный объект хранилище.
    /// </summary>
    public Guid StorageId { get; init; }

    #endregion

    #endregion
}
