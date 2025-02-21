using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

[ApiController]
[Route("random")]
public class RandomController : ControllerBase
{
    private static readonly Random _random = new Random();

    [HttpGet("number")]
    public IActionResult GetRandomNumber([FromQuery] int? min, [FromQuery] int? max)
    {
        if (min.HasValue && max.HasValue && min <= max)
        {
            return Ok(_random.Next(min.Value, max.Value + 1));
        }
        return Ok(_random.Next());
    }

    [HttpGet("decimal")]
    public IActionResult GetRandomDecimal()
    {
        return Ok(_random.NextDouble() * (1.0 - 0.0) + 0.0); // Asegura el rango [0,1]
    }

    [HttpGet("string")]
    public IActionResult GetRandomString([FromQuery] int length = 8)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        var randomString = new string(Enumerable.Repeat(chars, length)
            .Select(s => s[_random.Next(s.Length)]).ToArray());
        return Ok(randomString);
    }
}