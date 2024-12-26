namespace BarrelsAccounting.Accounting.Domain;

/// <summary>
/// Агрегат. Устройство на производстве, в котором смешиваются краски. 
/// В него можно списывать бочки.
/// </summary>
public class Aggregate : StorageObject
{
    /// <summary>
	/// Возвращает объем емкости.
	/// </summary>
	public double Volume { get; }
}
