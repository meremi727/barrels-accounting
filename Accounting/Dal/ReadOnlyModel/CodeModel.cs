namespace BarrelsAccounting.Accounting.Dal.ReadOnlyModel;

/// <summary>
/// Представляет кодовые обозначения поставщика.
/// </summary>
public class CodeModel
{
	/// <summary>
	/// Возвращает уникальный идентификатор обозначения ЛКМ.
	/// </summary>
	public string MaterialCode { get; init; } = null!;

	/// <summary>
	/// Возвращает блеск.
	/// </summary>
	public string? Gloss { get; init; }

	/// <summary>
	/// Возвращает материал.
	/// </summary>
	public string? Material { get; init; }

	/// <summary>
	/// Возвращает тип материала.
	/// </summary>
	public string? MaterialType { get; init; }

	/// <summary>
	/// Возвращает поставщика.
	/// </summary>
	public string? ProviderName { get; init; }
}
