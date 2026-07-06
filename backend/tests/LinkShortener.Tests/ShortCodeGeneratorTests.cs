using LinkShortener.Api.Data;
using LinkShortener.Api.Services;
using Microsoft.EntityFrameworkCore;

namespace LinkShortener.Tests;

public class ShortCodeGeneratorTests
{
    [Fact]
    public async Task GenerateAsync_ReturnsCodeOfExpectedLength()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
        using var db = new AppDbContext(options);
        var generator = new ShortCodeGenerator(db);

        var code = await generator.GenerateAsync();

        Assert.False(string.IsNullOrEmpty(code));
        Assert.Equal(7, code.Length);
    }
}
