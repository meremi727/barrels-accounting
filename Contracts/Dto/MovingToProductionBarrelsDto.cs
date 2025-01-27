namespace BarrelsAccounting.Contracts.Dto;

/// <summary>
/// Dto для списания бочки в производство.
/// </summary>
/// <param name="StoragePlaceId"> Идентификатор агрегата, куда будет списана бочка. </param>
/// <param name="BarrelId"> Идентификатор бочки. </param>
public record MovingToProductionBarrelsDto(Guid AggregateId, string BarrelId);