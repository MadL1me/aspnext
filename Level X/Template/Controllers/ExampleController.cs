using Microsoft.AspNetCore.Mvc;

namespace Asp.AwesemeTemplate.Controllers;

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

    /// <summary>
    /// Example of synchronous Http.Get request pipeline with users/{userId} route 
    /// </summary>
    [HttpGet("users/{userId}")]
    public IEnumerable<ExampleUserDto> GetUser(int userId)
    {
        return Enumerable.Range(1, 5).Select(index => new ExampleUserDto
            {
                Age = Random.Shared.Next(0, 55),
                DateOfBirth = DateTime.Now.AddDays(index),
                Name = Names[Random.Shared.Next(Names.Length)]
            })
            .ToArray();
    }
    
    /// <summary>
    /// Example of asynchronous Http.Post request pipeline with body params users/{userId} route and IActionResult 
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    [HttpPost("users/{userId}")]
    public async Task<IActionResult> UpdateUser([FromBody] ExampleUserDto userDto) // [FromBody] attribute allows body http params
    {
        await Task.Delay(1000); // waits for 1 second, async C# example

        if (userDto is null)
            return BadRequest(); // predefined status codes

        // custom status code returns with data
        return StatusCode(StatusCodes.Status200OK, new { Value1 = true, Value2 = "Yay!"});
    }
}