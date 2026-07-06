using LinkShortener.Api.Data;
using LinkShortener.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LinkShortener.Api.Controllers;

[ApiController]
public class RedirectController : ControllerBase
{
    private readonly AppDbContext _db;
    private readonly ClickRecorder _clickRecorder;

    public RedirectController(AppDbContext db, ClickRecorder clickRecorder)
    {
        _db = db;
        _clickRecorder = clickRecorder;
    }

    [HttpGet("/{code}")]
    public async Task<IActionResult> RedirectToTarget(string code)
    {
        var link = await _db.Links.FirstOrDefaultAsync(l => l.Code == code);
        if (link is null)
        {
            return NotFound();
        }

        await _clickRecorder.RecordAsync(link.Id);

        return Redirect(link.TargetUrl);
    }
}
