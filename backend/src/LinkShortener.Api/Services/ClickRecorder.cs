using LinkShortener.Api.Data;
using LinkShortener.Api.Models;

namespace LinkShortener.Api.Services;

public class ClickRecorder
{
    private readonly AppDbContext _db;

    public ClickRecorder(AppDbContext db)
    {
        _db = db;
    }

    public async Task RecordAsync(Guid linkId)
    {
        _db.Clicks.Add(new Click
        {
            Id = Guid.NewGuid(),
            LinkId = linkId,
            CreatedAt = DateTime.UtcNow,
        });
        await _db.SaveChangesAsync();
    }
}
