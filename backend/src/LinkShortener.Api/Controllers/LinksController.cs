using LinkShortener.Api.Data;
using LinkShortener.Api.Dtos;
using LinkShortener.Api.Models;
using LinkShortener.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LinkShortener.Api.Controllers;

[ApiController]
[Route("api/links")]
public class LinksController : ControllerBase
{
    private readonly AppDbContext _db;
    private readonly ShortCodeGenerator _shortCodeGenerator;
    private readonly IConfiguration _config;

    public LinksController(AppDbContext db, ShortCodeGenerator shortCodeGenerator, IConfiguration config)
    {
        _db = db;
        _shortCodeGenerator = shortCodeGenerator;
        _config = config;
    }

    [HttpPost]
    public async Task<ActionResult<LinkResponse>> Create(CreateLinkRequest request)
    {
        var code = await _shortCodeGenerator.GenerateAsync();

        var link = new Link
        {
            Id = Guid.NewGuid(),
            Code = code,
            TargetUrl = request.TargetUrl,
            CreatedAt = DateTime.UtcNow,
        };

        _db.Links.Add(link);
        await _db.SaveChangesAsync();

        return Created($"/api/links/{link.Id}", ToResponse(link));
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<LinkResponse>>> GetAll()
    {
        var links = await _db.Links.OrderByDescending(l => l.CreatedAt).ToListAsync();
        return links.Select(ToResponse).ToList();
    }

    [HttpGet("{id}/clicks")]
    public IActionResult GetClicks(Guid id)
    {
        // TODO: implement click analytics — see README
        return StatusCode(StatusCodes.Status501NotImplemented, new { error = "Not implemented" });
    }

    private LinkResponse ToResponse(Link link)
    {
        var baseUrl = _config["BaseUrl"] ?? "http://localhost:5000";
        return new LinkResponse
        {
            Id = link.Id,
            Code = link.Code,
            ShortUrl = $"{baseUrl}/{link.Code}",
            TargetUrl = link.TargetUrl,
            CreatedAt = link.CreatedAt,
        };
    }
}
