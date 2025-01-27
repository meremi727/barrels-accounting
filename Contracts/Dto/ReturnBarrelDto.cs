namespace BarrelsAccounting.Contracts.Dto;

/// <summary>
/// Dto для возврата бочки.
/// </summary>
/// <param name="StoragePlaceId"> Идентификатор МХ, куда возвращается бочка. </param>
/// <param name="BarrelId"> Идентификатор бочки. </param>
/// <param name="BruttoWeight"> Вес БРУТТО. </param>
/// <param name="IsDrained"> Флаг слива. </param>
public record ReturnBarrelDto(Guid StoragePlaceId, string BarrelId, double BruttoWeight, bool IsDrained);