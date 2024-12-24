namespace Accounting.Domain;

public class JournalEntry
{
    #region .ctor
    /// <summary>
    /// Инициализирует экземпляр класса <see cref="JournalEntry" />.
    /// </summary>
    /// <param name="operationDateTime"> Дата и время операции. </param>
    /// <param name="barrelId"> Идентификатор бочки. </param>
    /// <param name="operationType"> Имя события. </param>
    /// <param name="storageObjectId"> Идентификатор объекта хранилища, на котором произошло событие. </param>
    /// <param name="userName"> Имя пользователя. </param>
    /// <param name="operationPayload"> Сериализованное событие об операции с бочкой. </param>
    /// <exception cref="ArgumentException"> Если аргумент не задан, содержит пустую строку или только пробелы. </exception>
    /// <exception cref="ArgumentOutOfRangeException"> Если переданный идентификатор объекта хранилища пустой. </exception>
    public JournalEntry(DateTime operationDateTime, string barrelId, string operationType, Guid? storageObjectId, string userName, string operationPayload)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(barrelId, nameof(barrelId));
        if (storageObjectId is not null)
            ArgumentOutOfRangeException.ThrowIfEqual((Guid)storageObjectId, Guid.Empty, nameof(storageObjectId));

        ArgumentException.ThrowIfNullOrWhiteSpace(userName, nameof(userName));
        ArgumentException.ThrowIfNullOrWhiteSpace(operationPayload, nameof(operationPayload));
 
        Id = Guid.NewGuid();
        DateTime = operationDateTime;
        BarrelId = barrelId;
        OperationType = operationType;
        StorageObjectId = storageObjectId;
        UserName = userName;
        OperationPayload = operationPayload;
    }

    /// <summary>
    /// Для EF Core
    /// </summary>
    private JournalEntry() { }

    #endregion

    #region Properties
    /// <summary>
    /// Возвращает уникальный идентификатор бочки.
    /// </summary>
    public string BarrelId { get; init; } = null!;

    /// <summary>
    /// Возвращает дату и время возникновения события.
    /// </summary>
    public DateTime DateTime { get; init; }

    /// <summary>
    /// Возвращает уникальный идентификатор события журнала.
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// Возвращает данные по операции.
    /// </summary>
    public string OperationPayload { get; init; } = null!;

    /// <summary>
    /// Возвращает имя операции.
    /// </summary>
    public string OperationType { get; init; } = null!;

    /// <summary>
    /// Возвращает имя пользователя.
    /// </summary>
    public string UserName { get; init; } = null!;

    /// <summary>
    /// Возвращает идентификатор объекта хранилища.
    /// </summary>
    public Guid? StorageObjectId { get; init; }
    #endregion
}