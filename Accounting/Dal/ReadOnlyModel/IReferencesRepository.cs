namespace BarrelsAccounting.Accounting.Dal.ReadOnlyModel;

/// <summary>
/// Интерфейс репозитория справочной информации.
/// </summary>
public interface IReferencesRepository
{
    /// <summary>
    /// Возвращает все цветовые обозначения RAL.
    /// </summary>
    /// <returns> Коллекция цветовых обозначений RAL. </returns>
    IReadOnlyCollection<RalModel> GetRals();

    /// <summary>
    /// Возвращает цветовое обозначение RAL по его коду.
    /// </summary>
    /// <param name="code"> Код цветового обозначения RAL. </param>
    /// <returns> Цветовое обозначение RAL или <c>null</c>, если не найдено. </returns>
    RalModel? GetRal(string code);

    /// <summary>
    /// Возвращает все кодовые обозначения.
    /// </summary>
    /// <returns> Коллекция кодовых обозначений. </returns>
    IReadOnlyCollection<CodeModel> GetCodes();

    /// <summary>
    /// Возвращает кодовое обозначение по коду материала.
    /// </summary>
    /// <param name="materialCode"> Код материала. </param>
    /// <returns> Кодовое обозначение или <c>null</c>, если не найдено. </returns>
    CodeModel? GetCode(string materialCode);

    /// <summary>
    /// Возвращает все партии.
    /// </summary>
    /// <returns> Коллекция партий. </returns>
    IReadOnlyCollection<BatchModel> GetBatches();

    /// <summary>
    /// Возвращает партию по ее номеру.
    /// </summary>
    /// <param name="batchNumber"> Номер партии. </param>
    /// <returns> Партия или <c>null</c>, если не найдена. </returns>
    BatchModel? GetBatch(string batchNumber);
}