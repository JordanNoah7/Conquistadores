using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ConquistadorItemCuadernilloRepository : IConquistadorItemCuadernilloRepository
{
    private AppDbContext _dbContext;

    public ConquistadorItemCuadernilloRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<decimal> GetAvanceAsync(int ConqId)
    {
        try
        {
            var ClasId = await _dbContext.ClaseConquistadores
                .Where(cc => cc.ConqId == ConqId && cc.AudiFechCrea.Year == DateTime.Now.Year)
                .OrderByDescending(cc => cc.AudiFechCrea)
                .Select(cc => cc.ClasId)
                .FirstOrDefaultAsync();

            var items = await _dbContext.ItemsCuadernillo
                .Where(ic => ic.ClasId == ClasId)
                .CountAsync();

            var done = await _dbContext.ConquistadorItemsCuadernillo
                .Where(ci => ci.ConqId == ConqId && ci.ClasId == ClasId && ci.CoicCompleto == true)
                .CountAsync();

            return items > 0 ? (decimal)done / items : 0;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}
