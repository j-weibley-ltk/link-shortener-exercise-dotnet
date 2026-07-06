namespace LinkShortener.Api.Models;

public class Link
{
    public Guid Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string TargetUrl { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }

    public List<Click> Clicks { get; set; } = new();
}
