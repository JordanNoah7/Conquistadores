using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public static class AppDbContextExtensions
{
    public static IQueryable<string> SplitString(this AppDbContext _dbContext, string inputString, char separator)
    {
        return _dbContext
            .Set<string>()
            .FromSqlRaw("SELECT Value FROM SplitString({0}, {1})", inputString, separator);
    }
}
