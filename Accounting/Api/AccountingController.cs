using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using BarrelsAccounting.Contracts.Dto;

namespace BarrelsAccounting.Accounting.Api;

[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
[ApiController]
[Route("/accounting")]
public class AccountingController : ControllerBase
{
    [HttpPost("/accept")]
    public IActionResult Accept([FromBody] AcceptanceDto barrels)
    {
        throw new NotImplementedException();
    }
}