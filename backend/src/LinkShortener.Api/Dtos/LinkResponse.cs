namespace LinkShortener.Api.Dtos;

public class LinkResponse
{
    public Guid Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string ShortUrl { get; set; } = string.Empty;
    public string TargetUrl { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
}
