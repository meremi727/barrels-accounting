using BarrelsAccounting.Accounting.Dal.ReadOnlyModel;

namespace BarrelsAccounting.Accounting.Dal;

/// <summary>
/// Контекст БД справочной информации.
/// </summary>
/// <param name="context"> Параметры подключения. </param>
public class ReferencesRepository(ReferencesDbContext context) : IReferencesRepository
{
    /// <inheritdoc/>
    public IReadOnlyCollection<RalModel> GetRals()
        => context.Rals.ToList();

    /// <inheritdoc/>
    public RalModel? GetRal(string code)
        => context.Rals.Where(r => r.Code == code)
                       .FirstOrDefault();

    /// <inheritdoc/>
    public IReadOnlyCollection<CodeModel> GetCodes()
        => context.Codes.ToList();

    /// <inheritdoc/>
    public CodeModel? GetCode(string materialCode)
        => context.Codes.Where(c => c.MaterialCode == materialCode)
                        .FirstOrDefault();  

    /// <inheritdoc/>
    public IReadOnlyCollection<BatchModel> GetBatches()
        => context.Batches.ToList();

    /// <inheritdoc/>
    public BatchModel? GetBatch(string batchNumber)
        => context.Batches.Where(b => b.BatchNumber == batchNumber)
                          .FirstOrDefault();

    private readonly ReferencesDbContext context = context;
}