using System.Linq.Expressions;

namespace BarrelsAccounting.Accounting.Domain;

/// <summary>
/// Интерфейс репозитория сервиса учета ЛКМ.
/// </summary>
public interface IAccountingRepository
{
	#region Barrel

	/// <summary>
	/// Добавляет новую бочку.
	/// </summary>
	/// <param name="barrel"> Бочка. </param>
	void AddBarrel(Barrel barrel);

	/// <summary>
	/// Обновляет указанную бочку.
	/// </summary>
	/// <param name="barrel"> Бочка. </param>
	void UpdateBarrel(Barrel barrel);

	/// <summary>
	/// Помечает указанную бочку удаленной.
	/// </summary>
	/// <param name="barrel"> Бочка. </param>
	void RemoveBarrel(Barrel barrel);

	/// <summary>
	/// Возвращает бочки по указанным идентификаторам, которые не были помечены удаленными.
	/// </summary>
	/// <param name="ids"> Коллекция идентификаторов. </param>
	/// <returns> Коллекция всех найденных бочек по переданным идентификаторам. </returns>
	IReadOnlyCollection<Barrel> GetBarrelsByIds(IEnumerable<string> ids);

	/// <summary>
	/// Возвращает все бочки, удовлетворяющие предикату, которые не были помечены на удаление.
	/// </summary>
	/// <param name="predicate"> Условие отбора. </param>
	/// <returns> Коллекция всех найденных бочек по переданному условию. </returns>
	IReadOnlyCollection<Barrel> GetBarrels(Expression<Func<Barrel, bool>> predicate);

	#endregion

	#region StorageObject

	/// <summary>
	/// Возвращает объект хранилище по его идентификатору.
	/// </summary>
	/// <typeparam name="TStorageObject"> Тип объекта хранилища. </typeparam>
	/// <param name="storageObjectId"> Идентификатор. </param>
	/// <returns> Объект, или <c>null</c>, если не найден. </returns>
	TStorageObject? GetStorageObjectById<TStorageObject>(Guid storageObjectId)
		where TStorageObject : StorageObject;

	#region StoragePlace

	/// <summary>
	/// Возвращает МХ по его идентификатору.
	/// </summary>
	/// <param name="id"> Идентификатор. </param>
	/// <returns> МХ или <c>null</c>, если МХ не найден. </returns>
	StoragePlace? GetStoragePlaceById(Guid id);

	/// <summary>
	/// Возвращает все МХ для данного склада.
	/// </summary>
	/// <param name="productionStorageId"> Идентификатор склада. </param>
	/// <returns> Коллекция всех МХ данного склада. </returns>
	IReadOnlyCollection<StoragePlace> GetStoragePlacesByStorageId(Guid storageId);

	#endregion

	#region Aggregate

	/// <summary>
	/// Возвращает агрегат по ег идентификатору.
	/// </summary>
	/// <param name="id"> Идентификатор. </param>
	/// <returns> Агрегат или <c>null</c>, если агрегат не найден. </returns>
	Aggregate? GetAggregateById(Guid id);

	/// <summary>
	/// Возвращает все агрегаты для данного склада производства.
	/// </summary>
	/// <param name="productionStorageId"> Идентификатор склада производства. </param>
	/// <returns> Коллекция всех агрегатов данного склада производства. </returns>
	IReadOnlyCollection<StoragePlace> GetStoragePlacesByProductionStorageId(Guid productionStorageId);

	#endregion

	#endregion

	#region Storages

	/// <summary>
	/// Возвращает все склады данного типа.
	/// </summary>
	/// <typeparam name="TStorage"> Тип склада. </typeparam>
	/// <returns> Коллекция всех складов данного типа. </returns>
	IReadOnlyCollection<TStorage> GetStorages<TStorage>()
		where TStorage : Storage;

	/// <summary>
	/// Возвращает склад данного типа по его идентификатору.
	/// </summary>
	/// <typeparam name="TStorage"> Тип склада. </typeparam>
	/// <param name="storageId"> Идентификатор склада. </param>
	/// <returns> Склад или <c>null</c>, если не найден. </returns>
	TStorage? GetStorageById<TStorage>(Guid storageId)
		where TStorage : Storage;

	#endregion
}
