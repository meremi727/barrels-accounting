namespace BarrelsAccounting.Accounting.Dal.ReadOnlyModel;

/// <summary>
/// Представляет обозначение ЛКМ по системе RAL.
/// </summary>
public class RalModel
{
	/// <summary>
	/// Возвращает код по системе RAL.
	/// </summary>
	public string Code { get; init; } = null!;

	/// <summary>
	/// Возвращает обозначение.
	/// </summary>
	public string Description { get; init; } = null!;
}
