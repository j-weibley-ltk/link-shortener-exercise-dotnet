using LinkShortener.Api.Controllers;
using LinkShortener.Api.Data;
using LinkShortener.Api.Dtos;
using LinkShortener.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LinkShortener.Tests;

public class LinksControllerTests
{
    private static AppDbContext CreateContext()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
        return new AppDbContext(options);
    }

    [Fact]
    public async Task Create_ReturnsCreated()
    {
        var db = CreateContext();
        var controller = new LinksController(db, new ShortCodeGenerator(db), new ConfigurationBuilder().Build());

        var result = await controller.Create(new CreateLinkRequest { TargetUrl = "https://example.com" });

        var created = Assert.IsType<CreatedResult>(result.Result);
        Assert.Equal(201, created.StatusCode);
    }
}
