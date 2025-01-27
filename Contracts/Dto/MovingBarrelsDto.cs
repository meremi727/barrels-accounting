namespace BarrelsAccounting.Contracts.Dto;

/// <summary>
/// Dto для перемещения бочки.
/// </summary>
/// <param name="StoragePlaceId"> Идентификатор МХ, куда будет перемещена бочка.  </param>
/// <param name="BarrelId"> Идентификатор бочки. </param>
public record MovingBarrelsDto(Guid StoragePlaceId, string BarrelId);