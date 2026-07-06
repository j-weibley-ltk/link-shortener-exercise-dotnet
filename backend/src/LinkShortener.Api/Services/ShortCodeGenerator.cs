using LinkShortener.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace LinkShortener.Api.Services;

public class ShortCodeGenerator
{
    private const string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
    private const int CodeLength = 7;

    private readonly AppDbContext _db;
    private readonly Random _random = new();

    public ShortCodeGenerator(AppDbContext db)
    {
        _db = db;
    }

    public async Task<string> GenerateAsync()
    {
        var code = RandomCode();
        while (await _db.Links.AnyAsync(l => l.Code == code))
        {
            code = RandomCode();
        }
        return code;
    }

    private string RandomCode()
    {
        var chars = new char[CodeLength];
        for (var i = 0; i < CodeLength; i++)
        {
            chars[i] = Alphabet[_random.Next(Alphabet.Length)];
        }
        return new string(chars);
    }
}
