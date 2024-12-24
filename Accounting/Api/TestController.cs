using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Accounting.Api;

[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
[ApiController]
[Route("/Test")]
public class TestController : Controller
{
    [HttpGet]
    public IResult Get()
    {
        // this.HttpContext.Request.Headers.TryGetValue("Authorization", out var val);

        return Results.Ok(123);
    }
}