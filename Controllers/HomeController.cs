using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace azure_api.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class HomeController : ControllerBase
{

    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet("signIn")]
    public IActionResult SignIn()
    {
        var userClaims = User.Identity as System.Security.Claims.ClaimsIdentity;
        var name = userClaims?.FindFirst("name")?.Value;
        return Ok();
    }

}