using BarrelsAccounting.Accounting.Domain;

namespace BarrelsAccounting.Accounting.Dal.ReadOnlyModel;

/// <summary>
/// Представляет модель бочки, которая обогащена навигационными свойствами.
/// </summary>
public class BarrelModel
{
	#region Properties

	#region Original

	/// <summary>
	/// Возвращает уникальный идентификатор бочки.
	/// </summary>
	public string Id { get; init; } = null!;

	/// <summary>
	/// Возвращает кодовое обозначение бочки.
	/// </summary>
	public string Code { get; init; } = null!;

	/// <summary>
	/// Возвращает цветовое обозначение RAL.
	/// </summary>
	public string Ral { get; init; } = null!;

	/// <summary>
	/// Возвращает номер партии поставщика.
	/// </summary>
	public string Batch { get; init; } = null!;

	/// <summary>
	/// Возвращает номер бочки поставщика.
	/// </summary>
	public string Number { get; init; } = null!;

	/// <summary>
	/// Возвращает массу бочки нетто.
	/// </summary>
	public double NettoWeight { get; init; }

	/// <summary>
	/// Возвращает массу бочки брутто.
	/// </summary>
	public double BruttoWeight { get; init; }

	/// <summary>
	/// Возвращает дату производства бочки у поставщика.
	/// </summary>
	public DateOnly ProductionDate { get; init; }

	/// <summary>
	/// Возвращает статус бочки в системе.
	/// </summary>
	public BarrelStatus Status { get; init; }

	/// <summary>
	/// Возвращает "флаг" слива.
	/// Истина - бочка имеет состав краски, отличный от заявленного на маркировке.
	/// </summary>
	public bool IsDrained { get; init; }

	/// <summary>
	/// Возвращает дату и время создания бочки в системе.
	/// </summary>
	public DateTime CreatedDateTime { get; init; }

	/// <summary>
	/// Возвращает дату и время удаления бочки из системы.
	/// </summary>
	public DateTime? DeletedDateTime { get; init; }

	/// <summary>
	/// Возвращает "флаг" удаления бочки в системе.
	/// </summary>
	public bool IsDeleted => DeletedDateTime is not null;

	/// <summary>
	/// Возвращает идентификатор объекта хранилища, в котором находится бочка.
	/// </summary>
	public Guid? StorageObjectId { get; init; }

	#endregion

	#region Navigation

	/// <summary>
	/// Возвращает атрибуты партии.
	/// </summary>
	public BatchModel? BatchAttributes { get; init; }

	/// <summary>
	/// Возвращает атрибуты обозначения.
	/// </summary>
	public CodeModel? CodeAttributes { get; init; }

	#endregion

	#endregion
}
