using BarrelsAccounting.Accounting.Domain;

namespace BarrelsAccounting.Accounting.Services;

public interface IStoragesService
{
    /// <summary>
    /// Возвращает все склады, которые доступны текущему пользователю.
    /// </summary>
    /// <returns> Коллекция доступных складов. </returns>
    IReadOnlyCollection<Storage> GetAvailableStorages();

    IReadOnlyCollection<ProductionStorage> GetProductionStorages();

    IReadOnlyCollection<AcceptanceStorage> GetAcceptanceStorages();

    IReadOnlyCollection<StoragePlace> GetStoragePlacesByStorage();
}