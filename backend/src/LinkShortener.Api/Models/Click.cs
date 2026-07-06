namespace LinkShortener.Api.Models;

public class Click
{
    public Guid Id { get; set; }
    public Guid LinkId { get; set; }
    public Link Link { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
}
