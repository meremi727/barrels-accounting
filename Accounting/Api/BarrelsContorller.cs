using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BarrelsAccounting.Accounting.Api;

[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
[ApiController]
[Route("/barrels")]
public class BarrelsContorller : ControllerBase
{
    // [HttpGet]
    // public ActionResult<IEnumerable<
}