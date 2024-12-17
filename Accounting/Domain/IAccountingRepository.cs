// using System.Linq.Expressions;

// namespace Accounting.Domain;

// /// <summary>
// /// Интерфейс репозитория сервиса учета ЛКМ.
// /// </summary>
// public interface IAccountingRepository
// {
// 	#region Overridable
// 	/// <summary>
// 	/// Добавляет бочку.
// 	/// </summary>
// 	/// <param name="barrel"> Бочка. </param>
// 	void Add(Barrel barrel);

// 	/// <summary>
// 	/// Возвращает бочки по указанным идентификаторам.
// 	/// </summary>
// 	/// <param name="ids"> Идентификаторы для поиска. </param>
// 	/// <returns> Коллекция не удаленных бочек. </returns>
// 	IReadOnlyCollection<Barrel> FindBy(IReadOnlyCollection<string> ids);

// 	/// <summary>
// 	/// Находит и возвращает бочки по предикату.
// 	/// </summary>
// 	/// <param name="predicate"> Предикат. </param>
// 	/// <returns> Коллекция не удаленных бочек. </returns>
// 	IEnumerable<Barrel> FindBy(Expression<Func<Barrel, bool>> predicate);

// 	/// <summary>
// 	/// Находит и возвращает МХ по идентификатору.
// 	/// </summary>
// 	/// <param name="id">Идентификатор МХ.</param>
// 	/// <returns>МХ или <c>null</c>, если не найдено.</returns>
// 	Storage? FindStorageBy(Guid id);

// 	/// <summary>
// 	/// Находит и возвращает коллекцию МХ по идентификатору склада.
// 	/// </summary>
// 	/// <param name="warehouseId">Идентификатор склада.</param>
// 	/// <returns>Коллекцию МХ или пустую коллекцию, если не найдены.</returns>
// 	IReadOnlyCollection<Storage> FindStoragesBy(Guid warehouseId);

// 	/// <summary>
// 	/// Находит и возвращает объект склада по идентификатору.
// 	/// </summary>
// 	/// <param name="id">Идентификатор.</param>
// 	/// <returns>Объект склада или <c>null</c>, если объект склада не найден.</returns>
// 	TWarehouseObject? FindWarehouseObjectById<TWarehouseObject>(Guid id) where TWarehouseObject : WarehouseObject;

// 	/// <summary>
// 	/// Возвращает склад приемки по идентификатору.
// 	/// </summary>
// 	/// <returns>Склад приемки или <c>null</c>, если не найден.</returns>
// 	AcceptanceWarehouse? GetAcceptanceWarehouseById(Guid id);

// 	/// <summary>
// 	/// Возвращает склады приемки.
// 	/// </summary>
// 	/// <returns>Склады приемки или пустую коллекцию, если не найдены.</returns>
// 	IReadOnlyCollection<AcceptanceWarehouse> GetAcceptanceWarehouses();

// 	/// <summary>
// 	/// Возвращает склад производства по идентификатору.
// 	/// </summary>
// 	/// <returns>Склад производства или <c>null</c>, если не найден.</returns>
// 	ProductionWarehouse? GetProductionWarehouseById(Guid id);

// 	/// <summary>
// 	/// Возвращает склады производства.
// 	/// </summary>
// 	/// <returns> Склады производства. </returns>
// 	IReadOnlyCollection<ProductionStorage> GetProductionStorages();

// 	/// <summary>
// 	/// Возвращает объекты склада.
// 	/// </summary>
// 	/// <returns> Объекты склада. </returns>
// 	IReadOnlyCollection<StorageObject> GetStorageObjects();

// 	/// <summary>
// 	/// Помечает бочку удаленной.
// 	/// </summary>
// 	/// <param name="barrel"> Бочка. </param>
// 	void Remove(Barrel barrel);

// 	/// <summary>
// 	/// Обновляет бочку.
// 	/// </summary>
// 	/// <param name="barrel"> Бочка. </param>
// 	void Update(Barrel barrel);

// 	#endregion
// }
