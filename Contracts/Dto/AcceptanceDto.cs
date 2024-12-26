namespace BarrelsAccounting.Contracts.Dto;

public record AcceptanceDto(Guid storagePlaceId, IEnumerable<AcceptanceBarrelDto> barrels);


public record AcceptanceBarrelDto(string id, string code, string ral, string batch, string number, double bruttoWeight, double nettoWeight, DateOnly productionDate);