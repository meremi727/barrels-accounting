namespace BarrelsAccounting.Accounting.Domain;

public class Barrel
{
    #region Public

    #region Properties 

    /// <summary>
    /// Возвращает уникальный идентификатор бочки.
    /// </summary>
    public string Id { get; } = null!;

    /// <summary>
    /// Возвращает кодовое обозначение бочки.
    /// </summary>
    public string Code { get; } = null!;

    /// <summary>
    /// Возвращает цветовое обозначение RAL.
    /// </summary>
    public string Ral { get; } = null!;

    /// <summary>
    /// Возвращает номер партии поставщика.
    /// </summary>
    public string Batch { get; } = null!;

    /// <summary>
    /// Возвращает номер бочки поставщика.
    /// </summary>
    public string Number { get; } = null!;

    /// <summary>
    /// Возвращает массу бочки нетто.
    /// </summary>
    public double NettoWeight { get; private set; }

    /// <summary>
    /// Возвращает массу бочки брутто.
    /// </summary>
    public double BruttoWeight { get; private set; }

    /// <summary>
    /// Возвращает дату производства бочки у поставщика.
    /// </summary>
    public DateOnly ProductionDate { get; }

    /// <summary>
    /// Возвращает статус бочки в системе.
    /// </summary>
    public BarrelStatus Status { get; private set; }

    /// <summary>
    /// Возвращает "флаг" слива.
    /// Истина - бочка имеет состав краски, отличный от заявленного на маркировке.
    /// </summary>
    public bool IsDrained { get; private set; }

    /// <summary>
    /// Возвращает дату и время создания бочки в системе.
    /// </summary>
    public DateTime CreatedDateTime { get; }

    /// <summary>
    /// Возвращает дату и время удаления бочки из системы.
    /// </summary>
    public DateTime? DeletedDateTime { get; private set; }

    /// <summary>
    /// Возвращает "флаг" удаления бочки в системе.
    /// </summary>
    public bool IsDeleted => DeletedDateTime is not null;

    /// <summary>
    /// Возвращает идентификатор объекта хранилища, в котором находится бочка.
    /// </summary>
    public Guid? StorageObjectId { get; private set; }

    #endregion

    #region .ctor

    /// <summary>
    /// Конструктор для EF core.
    /// </summary>
    private Barrel() { }

    /// <summary>
    /// Конструктор с параметрами.
    /// </summary>
    /// <param name="id"> Уникальный идентификатор бочки. </param>
    /// <param name="code"> Кодовое обозначение бочки. </param>
    /// <param name="ral"> Цветовое обозначение RAL. </param>
    /// <param name="batch"> Номер партии поставщика. </param>
    /// <param name="number"> Номер бочки из партии. </param>
    /// <param name="nettoWeight"> Вес НЕТТО. </param>
    /// <param name="bruttoWeight"> Вес БРУТТО. </param>
    /// <param name="productionDate"> Дата производства. </param>
    /// <param name="storageObjectId"> Идентификатор объекта хранилища, в котором находится бочка. </param>
    public Barrel(string id,
                  string code,
                  string ral,
                  string batch,
                  string number,
                  double nettoWeight,
                  double bruttoWeight,
                  DateOnly productionDate,
                  Guid? storageObjectId)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(id, nameof(id));
        ArgumentException.ThrowIfNullOrWhiteSpace(code, nameof(code));
        ArgumentException.ThrowIfNullOrWhiteSpace(ral, nameof(ral));
        ArgumentException.ThrowIfNullOrWhiteSpace(batch, nameof(batch));
        ArgumentException.ThrowIfNullOrWhiteSpace(number, nameof(number));
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(nettoWeight, 0.0, nameof(nettoWeight));
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(bruttoWeight, 0.0, nameof(bruttoWeight));
        ArgumentOutOfRangeException.ThrowIfLessThan(bruttoWeight, nettoWeight, nameof(bruttoWeight));
        ArgumentOutOfRangeException.ThrowIfGreaterThan(productionDate, DateOnly.FromDateTime(DateTime.Now), nameof(productionDate));

        // Хз, что за ограничение такое, почему именно 10 лет (мб срок годности??)
        ArgumentOutOfRangeException.ThrowIfLessThan(productionDate, DateOnly.FromDateTime(DateTime.Now - TimeSpan.FromDays(3652)), nameof(productionDate));

        Id = id;
        Code = code;
        Ral = ral;
        Batch = batch;
        Number = number;
        NettoWeight = nettoWeight;
        BruttoWeight = bruttoWeight;
        ProductionDate = productionDate;
        Status = BarrelStatus.Accepted;
        IsDrained = false;
        CreatedDateTime = DateTime.UtcNow;
        DeletedDateTime = null;
        StorageObjectId = storageObjectId;
    }
    #endregion

    #region Methods

    public static Barrel Create(string id,
                                string providerCode,
                                string ral,
                                string batch,
                                string number,
                                double nettoWeight,
                                double bruttoWeight,
                                DateOnly productionDate,
                                Guid? storagePlaceId = null) =>
        new(id, providerCode, ral, batch, number, nettoWeight, bruttoWeight, productionDate, storagePlaceId);

    /// <summary>
	/// Переводит бочку в статус "Списана в производство".
	/// </summary>
	public void SetInProduction() => SetStatus(BarrelStatus.InProduction);

    /// <summary>
    /// Переводит бочку в статус "Возвращена".
    /// </summary>
    public void SetInReturned() => SetStatus(BarrelStatus.Returned);

    /// <summary>
    /// Устанавливает флаг слива.
    /// </summary>
    public void SetIsDrained() => IsDrained = true;

    /// <summary>
    /// Устанавливает объект хранилища для бочки.
    /// </summary>
    /// <param name="storageObjectId"> Идентификатор объект хранилища. </param>
    /// <exception cref="ArgumentOutOfRangeException"> Если id объект хранилища пустой. </exception>
    public void SetStorageObject(Guid storageObjectId)
    {
        ArgumentOutOfRangeException.ThrowIfEqual(storageObjectId, Guid.Empty, nameof(storageObjectId));
        StorageObjectId = storageObjectId;
    }

    /// <summary>
    /// Устанавливает вес брутто бочки.
    /// </summary>
    /// <param name="weight"> Вес бочки брутто. </param>
    /// <exception cref="ArgumentException"> Если вес бочки брутто меньше веса тары. </exception>
    public void SetBruttoWeight(double weight)
    {
        var tareWeight = BruttoWeight - NettoWeight;
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(weight, tareWeight, "Вес бочки брутто меньше веса тары.");
        BruttoWeight = weight;
        NettoWeight = weight - tareWeight;
    }

    #endregion

    #endregion

    #region Private

    /// <summary>
    /// Возвращает все возможные статусы, в которые может перейти бочка в текущем статусе.
    /// </summary>
    private IEnumerable<BarrelStatus> GetAvailableStatuses() =>
        Status switch
        {
            BarrelStatus.InProduction => [BarrelStatus.Returned],
            BarrelStatus.Returned => [BarrelStatus.InProduction],
            BarrelStatus.Accepted => [BarrelStatus.InProduction],
            _ => []
        };

    /// <summary>
    /// Устанавливает новый статус бочке.
    /// </summary>
    /// <param name="status"> Новый статус бочки. </param>
    /// <exception cref="Exception"> Невозможно изменить статус бочки. </exception>
	private void SetStatus(BarrelStatus status)
    {
        var availableStatuses = GetAvailableStatuses();
        if (!availableStatuses.Contains(status))
            throw new Exception($"Невозможно перевести бочку из статуса {Status} в статус {status}");

        Status = status;
    }

    #endregion
}