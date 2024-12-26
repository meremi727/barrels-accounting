namespace BarrelsAccounting.Accounting.Dal.ReadOnlyModel;

/// <summary>
/// Представляет данные о партии.
/// </summary>
public class BatchModel
{
	/// <summary>
	/// Возвращает номер партии.
	/// </summary>
	public string BatchNumber { get; init; } = null!;

	/// <summary>
	/// Возвращает статус аттестации.
	/// </summary>
	public string? AttestationStatus { get; init; }
}
