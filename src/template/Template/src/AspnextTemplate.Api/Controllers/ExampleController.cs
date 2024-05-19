#if (AddZitadelAuth)
using System.Security.Claims;
using AspnextTemplate.Infrastructure.Zitadel;
using Microsoft.AspNetCore.Authorization;
using Zitadel.Authentication;
using System.Security.Claims;
#endif
using Microsoft.AspNetCore.Mvc;

namespace AspnextTemplate.Api.Controllers;

public record ExampleUserDto
{
    public string Name { get; init; }
    public int Age { get; init; }
    public DateTime DateOfBirth { get; init; }
}

[ApiController]
[Route("[controller]")]
public class ExampleController : ControllerBase
{
    private static readonly string[] Names = { "John", "Albert", "Mark " };

    private readonly ILogger<ExampleController> _logger;

    public ExampleController(ILogger<ExampleController> logger)
    {
        _logger = logger;
    }

    // Example of synchronous Http.Get request pipeline with users/{userId} route
    [HttpGet("users/{userId}")]
    public ActionResult<IEnumerable<ExampleUserDto>> GetUser(int userId)
    {
        // default OK function
        return Ok(Enumerable.Range(1, 5).Select(index => new ExampleUserDto
            {
                Age = Random.Shared.Next(0, 55),
                DateOfBirth = DateTime.Now.AddDays(index),
                Name = Names[Random.Shared.Next(Names.Length)]
            })
            .ToArray());
    }

    // Example of asynchronous Http.Post request pipeline with body params users/{userId} route and IActionResult
    [HttpPost("users/{userId}")]
    public async Task<IActionResult> UpdateUser([FromBody] ExampleUserDto userDto) // [FromBody] attribute allows body http params
    {
        await Task.Delay(1000); // waits for 1 second, async C# example

        if (userDto is null)
            return BadRequest(); // predefined status codes

        // custom status code returns with data
        return StatusCode(StatusCodes.Status200OK, new { Value1 = true, Value2 = "Yay!"});
    }
#if (AddZitadelAuth)

    [HttpPost("non-authorize")]
    public object NonAuthorize() => Result();

    [HttpPost("introspect/valid")]
    [Authorize(AuthenticationSchemes = AuthConstants.Schema)]
    public object IntrospectValidToken() => Result();

    // Authorization by custom PolicyNam
    [HttpPost("introspect/requires-role")]
    [Authorize(Policy = AuthConstants.SomePolicyName)]
    public object IntrospectRequiresRole() => Result();

    private object Result() => new
    {
        Ping = "Pong",
        Timestamp = DateTime.Now,
        AuthType = User.Identity?.AuthenticationType,
        UserName = User.Identity?.Name,
        UserId = User.FindFirstValue(OidcClaimTypes.Subject),
        Claims = User.Claims.Select(c => new { c.Type, c.Value }).ToList(),
        IsInAdminRole = User.IsInRole("Admin"),
        IsInUserRole = User.IsInRole("User"),
        InChargeRole = User.IsInRole("charge"),
    };
#endif
}
