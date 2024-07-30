using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class AsistenciaRepository : IAsistenciaRepository
{
    private readonly AppDbContext _dbContext;

    public AsistenciaRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> GetPuntosAsync(int ConqId)
    {
        try
        {
            var result = await _dbContext.Asistencias
                .Where(a => a.ConqId == ConqId && a.AsisFecha.Year == DateTime.Now.Year)
                .GroupBy(a => a.ConqId)
                .Select(g => g.Sum(a => a.AsisTotal))
                .FirstOrDefaultAsync();

            return result > 0 ? result : 0;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}
