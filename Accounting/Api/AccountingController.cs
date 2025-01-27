using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using BarrelsAccounting.Accounting.Services;
using BarrelsAccounting.Contracts.Dto;
using BarrelsAccounting.Accounting.Domain;
using BarrelsAccounting.Accounting.Dal;

namespace BarrelsAccounting.Accounting.Api;

// [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
[AllowAnonymous]
[ApiController]
[Route("/accounting")]
public class AccountingController(AccountingDbContext context) : ControllerBase
{
    private readonly AccountingDbContext context = context;

    [HttpPost("/accept")]
    public IActionResult Accept([FromBody] AcceptanceDto barrels)
    {
        var storage = new AcceptanceStorage{
            Id = Guid.NewGuid(),
            Code = "Код склада",
            Name = "Приемка 1"
        };

        var sp = new StoragePlace{
            Id = Guid.NewGuid(),
            Barcode = "Штрих код МХ",
            Name = "Название МХ",
            StorageId = storage.Id
        };

        var b = new Barrel("1", "CPU100 WR", "8029", "1002", "123", 123, 125, new DateOnly(2022, 10, 12), sp.Id);
        context.Storages.Add(storage);
                // context.SaveChanges();
        context.StoragePlaces.Add(sp);
                // context.SaveChanges();
        context.Barrels.Add(b); 
        context.SaveChanges();
        return Ok();
    }

    [HttpGet]
    public IActionResult AA()
    {
        return Ok();
    }
}