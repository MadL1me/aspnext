#if (AddZitadelAuth)
using System.Security.Claims;
using AspnextTemplate.Infrastructure.Zitadel;
using Microsoft.AspNetCore.Authorization;
using Zitadel.Authentication;
using System.Security.Claims;
#endif
using Microsoft.AspNetCore.Mvc;
#if (AddObservability)
using AspnextTemplate.Domain.Observability;
using OpenTelemetry.Trace;
#endif

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
#if (AddObservability)
    private readonly Tracer _tracer;
    private readonly IMetricsProvider _metricsProvider;
#endif

    // In this controller we're using service provider just for convinience and
    // ease of template development
    // In real controllers, inject interfaces directly.
    public ExampleController(IServiceProvider serviceProvider)
    {
        _logger = serviceProvider.GetService<ILogger<ExampleController>>() ?? throw new ArgumentNullException();
#if (AddObservability)
        _tracer = serviceProvider.GetService<Tracer>() ?? throw new ArgumentNullException();
        _metricsProvider = serviceProvider.GetService<IMetricsProvider>() ?? throw new ArgumentNullException();
#endif
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
    #region Zitadel

    // Endpoint without auth
    [HttpPost("non-authorize")]
    public object NonAuthorize() => Result();

    // Goes to Introspect endpoint of Zitadel to validate token
    [HttpPost("introspect/valid")]
    [Authorize(AuthenticationSchemes = AuthConstants.Schema)]
    public object IntrospectValidToken() => Result();

    // Authorization by custom PolicyName
    // For this example, Role should be exact name to be passed
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

    #endregion
#endif

#if (AddObservability)
    // Showcase of tracing and metrics in action
    [HttpPost("observe")]
    public object ObserveAndTrace()
    {
        using var span = _tracer.StartActiveSpan("Observe-Parent");

        using (var child1 = _tracer.StartActiveSpan("child1"))
        {
            child1.SetAttribute("test", "some value");
            _logger.LogInformation("child1 trace information");
        }

        using (var child2 = _tracer.StartActiveSpan("child2"))
        {
            child2.SetAttribute("test", "another value");
            _logger.LogInformation("child2 trace information");
        }

        _metricsProvider.IncTestMetric(12345);

        return Ok();
    }
#endif
}
