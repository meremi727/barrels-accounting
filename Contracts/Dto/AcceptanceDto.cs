namespace BarrelsAccounting.Contracts.Dto;

/// <summary>
/// Dto для принятия новой бочки.
/// </summary>
/// <param name="StoragePlaceId"> Идентификатор МХ, в которое принимается бочка.  </param>
/// <param name="Barrel"> Бочка. </param>
public record AcceptanceDto(Guid StoragePlaceId, AcceptanceBarrelDto Barrel);

/// <summary>
/// Dto бочки для принятия.
/// </summary>
/// <param name="Id"> Идентификатор. </param>
/// <param name="Code"> Код. </param>
/// <param name="Ral"> Цвет. </param>
/// <param name="Batch"> Партия. </param>
/// <param name="Number"> Номер в партии. </param>
/// <param name="BruttoWeight"> Вес БРУТТО. </param>
/// <param name="NettoWeight"> Вес НЕТТО. </param>
/// <param name="ProductionDate"> Дата производства. </param>
public record AcceptanceBarrelDto(string Id, string Code, string Ral, string Batch, string Number, double BruttoWeight, double NettoWeight, DateOnly ProductionDate);